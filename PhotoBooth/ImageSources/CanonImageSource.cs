using EDSDK;
using SpiritLab;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpiritLab
{
    public class CanonImageSource : IImageSource
    {
        private SDKHandler _sdkHandler;

        public CanonImageSource() { }

        public void Initialize()
        {
            _sdkHandler = new SDKHandler();
        }

        public List<string> GetImageSourceNames() 
        {
            return _sdkHandler.GetCameraList().Select(x => x.Info.szDeviceDescription).ToList();
        }

        public void Close()
        { 
        
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
                _sdkHandler.LiveViewUpdated += ReceiveLiveViewstream;
                _sdkHandler.StartLiveView();
            }
        }

        public void ReceiveLiveViewstream(Stream str)
        {
            if (str != null)
            {

            }
        }
    }
}
