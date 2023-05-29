using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Video;
using System.Drawing;

namespace SpiritLab
{
    public class WebcamImageSource : IImageSource
    {
        private FilterInfoCollection filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        private VideoCaptureDevice videoCaptureDevice;

        public WebcamImageSource() { }

        public void Initialize()
        {
            //videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[selectedCameraIndex].MonikerString);
            //videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            //videoCaptureDevice.Start();
        }

        public List<string> GetImageSourceNames() 
        {
            var cameras = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            List<string> cameraNames = new List<string>();

            foreach (FilterInfo filterInfo in cameras)
                cameraNames.Add(filterInfo.Name);

            return cameraNames;
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            //capturedLiveViewFrame = (Bitmap)eventArgs.Frame.Clone();
        }

        public void Close()
        {
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
                videoCaptureDevice.Stop();
        }
    }
}
