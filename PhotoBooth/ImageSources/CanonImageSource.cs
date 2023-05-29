using EDSDK;
using SpiritLab;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace SpiritLab
{
    public class CanonImageSource : IImageSource
    {
        private SDKHandler _sdkHandler;

        public Bitmap capturedStill { get; set; }
        public Bitmap capturedLiveViewFrame { get; set; }

        public CanonImageSource() { }

        public void Initialize()
        {
            _sdkHandler = new SDKHandler();
            _sdkHandler.SDKObjectEvent += EdsObjectEventReceiver;
            _sdkHandler.ImageDownloaded += ReceiveDownloadedImage;
            _sdkHandler.LiveViewUpdated += ReceiveLiveViewstream;
        }

        public List<string> GetImageSourceNames() 
        {
            return _sdkHandler.GetCameraList().Select(x => x.Info.szDeviceDescription).ToList();
        }

        public void SetActiveSource(string name)
        {
            var cameraList = _sdkHandler.GetCameraList();

            foreach(var camera in cameraList) 
            {
                if (camera.Info.szDeviceDescription == name)
                {
                    Debug.WriteLine("Set active camera: " + name);
                    _sdkHandler.OpenSession(camera);

                    break;
                }
            }
        }

        public async Task<Bitmap> TakeStillImage()
        {
            capturedStill = null;
            _sdkHandler.TakePhoto();

            while(capturedStill == null) 
            {
                await Task.Delay(25);
            }

            return capturedStill;
        }

        Action<Bitmap> OnLiveViewReceived;
        public void StartLiveView(Action<Bitmap> onLiveViewReceived)
        {
            OnLiveViewReceived += onLiveViewReceived;
            _sdkHandler.StartLiveView();
        }

        public Bitmap GetLiveViewFrame()
        {
            return capturedLiveViewFrame;
        }

        public void Close()
        { 
            _sdkHandler.CloseSession();
        }

        public uint EdsObjectEventReceiver(uint inEvent, IntPtr inRef, IntPtr inContext)
        {
            if (inEvent == 516)
            {
                _sdkHandler.DownloadImage(inRef);
            }

            return 0;
        }

        public void ReceiveDownloadedImage(Bitmap bitmap)
        {
            if (bitmap != null)
            {
                capturedStill = bitmap;
            }
        }

        public void ReceiveLiveViewstream(Stream str)
        {
            if (str != null)
            {
                capturedLiveViewFrame = (Bitmap)Image.FromStream(str);
                OnLiveViewReceived?.Invoke(capturedLiveViewFrame);
            }
        }
    }
}
