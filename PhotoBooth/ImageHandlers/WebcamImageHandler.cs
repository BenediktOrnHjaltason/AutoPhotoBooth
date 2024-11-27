using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AForge.Video;
using System.Drawing;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using AutoPhotoBooth.Configuration;
using AutoPhotoBooth.CustomTypes;

namespace AutoPhotoBooth
{
    public class WebcamImageHandler : IImageHandler
    {
        public Bitmap capturedLiveViewFrame = null;

        private FilterInfoCollection filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        private VideoCaptureDevice videoCaptureDevice;

        public WebcamImageHandler() { }

        public List<string> GetImageHandlerNames() 
        {
            var cameras = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            List<string> cameraNames = new List<string>();

            foreach (FilterInfo filterInfo in cameras)
                cameraNames.Add(filterInfo.Name);

            return cameraNames;
        }

        public void SetActiveHandler(string name)
        {
            for (int i = 0; i < filterInfoCollection.Count; i++) 
            {
                if (filterInfoCollection[i].Name == name)
                {
                    Debug.WriteLine($"Set active image handler: {name}");

                    videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[i].MonikerString);
                    videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                    videoCaptureDevice.Start();
                }
            }
        }

        Action<Bitmap> OnLiveViewReceived;
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            capturedLiveViewFrame?.Dispose();
            capturedLiveViewFrame = (Bitmap)eventArgs.Frame.Clone();
            OnLiveViewReceived?.Invoke(capturedLiveViewFrame);
        }

        public async Task<Bitmap> TakeStillImage(ImagePurpose purpose)
        {
            if (purpose == ImagePurpose.REFERENCE)
            {
                PhotoBooth.CapturedReference?.Dispose();
                PhotoBooth.CapturedReference = (Bitmap)capturedLiveViewFrame.Clone();

                return PhotoBooth.CapturedReference;
            }
            else
            {
                PhotoBooth.CapturedComparison?.Dispose();
                PhotoBooth.CapturedComparison = (Bitmap)capturedLiveViewFrame.Clone();

                return PhotoBooth.CapturedComparison;
            }
        }

        public void StopLiveView()
        {

        }

        public void StartLiveView(Action<Bitmap> onLiveViewReceived)
        {
            OnLiveViewReceived += onLiveViewReceived;
        }

        public void SaveToPositiveResults()
        {
            PhotoBooth.CapturedComparison.Save(Path.Combine(ConfigurationHandler.PositiveResultSavePath, $"{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.bmp"), ImageFormat.Bmp);
        }

        public void DeleteComparison()
        {
            PhotoBooth.CapturedComparison?.Dispose();
        }

        public void Close()
        {
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
                videoCaptureDevice.Stop();
        }

        public void Dispose()
        {
            filterInfoCollection.Clear();
            videoCaptureDevice = null;
        }
    }
}
