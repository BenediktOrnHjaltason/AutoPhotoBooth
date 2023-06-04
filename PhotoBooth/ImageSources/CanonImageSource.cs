using EDSDK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace SpiritLab
{
    public class CanonImageSource : IImageSource
    {
        private SDKHandler _sdkHandler;

        public Bitmap capturedStill = null;
        public Bitmap capturedLiveViewFrame = null;

        public CanonImageSource() { }

        public void Initialize()
        {
            Debug.WriteLine("CannonImageSource: Initializing!");

            _sdkHandler = new SDKHandler();
            _sdkHandler.SDKObjectEvent += SDKObjectEventReceiver;
            _sdkHandler.ImageDownloaded += ReceiveDownloadedImage;
            _sdkHandler.LiveViewUpdated += ReceiveLiveViewStream;
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

        ImagePurpose LastImagePurpose;
        public async Task<Bitmap> TakeStillImage(ImagePurpose purpose)
        {
            LastImagePurpose = purpose;

            if (purpose == ImagePurpose.REFERENCE)
            {
                PhotoBooth.CapturedReference = null;
            }

            else PhotoBooth.CapturedComparison = null;

            _sdkHandler.TakePhoto();

            if (purpose == ImagePurpose.REFERENCE)
            {
                PhotoBooth.CapturedReference = null;

                while (PhotoBooth.CapturedReference == null)
                {
                    await Task.Delay(100);
                }

                return PhotoBooth.CapturedReference;
            }
            else
            {
                PhotoBooth.CapturedComparison = null;

                while (PhotoBooth.CapturedComparison == null)
                {
                    await Task.Delay(100);
                }

                return PhotoBooth.CapturedComparison;
            }
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

        public uint SDKObjectEventReceiver(uint inEvent, IntPtr inRef, IntPtr inContext)
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
                if (LastImagePurpose == ImagePurpose.REFERENCE) 
                {
                    PhotoBooth.CapturedReference = bitmap;
                }
                else PhotoBooth.CapturedComparison = bitmap;
            }
        }

        public void ReceiveLiveViewStream(Stream str)
        {
            if (str != null)
            {
                capturedLiveViewFrame = (Bitmap)Image.FromStream(str);
                OnLiveViewReceived?.Invoke(capturedLiveViewFrame);
            }
        }
    }
}
