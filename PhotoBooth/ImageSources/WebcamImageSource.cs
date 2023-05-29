using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Video;
using System.Drawing;
using System.Diagnostics;
using EDSDK;

namespace SpiritLab
{
    public class WebcamImageSource : IImageSource
    {
        public Bitmap capturedStill { get; set; }
        public Bitmap capturedLiveViewFrame { get; set; }
        

        private FilterInfoCollection filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        private VideoCaptureDevice videoCaptureDevice;

        public WebcamImageSource() { }

        public void Initialize()
        {
            
        }

        public List<string> GetImageSourceNames() 
        {
            var cameras = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            List<string> cameraNames = new List<string>();

            foreach (FilterInfo filterInfo in cameras)
                cameraNames.Add(filterInfo.Name);

            return cameraNames;
        }

        public void SetActiveSource(string name)
        {
            for (int i = 0; i < filterInfoCollection.Count; i++) 
            {
                if (filterInfoCollection[i].Name == name)
                {
                    Debug.WriteLine($"Set active image source: {name}");

                    videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[i].MonikerString);
                    videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                    videoCaptureDevice.Start();
                }
            }
        }

        Action<Bitmap> OnLiveViewReceived;
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            capturedLiveViewFrame = (Bitmap)eventArgs.Frame.Clone();
            OnLiveViewReceived?.Invoke(capturedLiveViewFrame);
        }

        public async Task<Bitmap> TakeStillImage()
        {
            return capturedLiveViewFrame;
        }

        public Bitmap GetLiveViewFrame()
        {

            return capturedLiveViewFrame;
        }

        
        public void StartLiveView(Action<Bitmap> onLiveViewReceived)
        {
            OnLiveViewReceived += onLiveViewReceived;
        }

        public void Close()
        {
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
                videoCaptureDevice.Stop();
        }
    }
}
