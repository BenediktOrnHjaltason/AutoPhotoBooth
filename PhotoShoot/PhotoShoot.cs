using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using Spirit_Studio.CustomTypes;


namespace Spirit_Studio
{
    public class PhotoShoot
    {
        FilterInfoCollection filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        VideoCaptureDevice videoCaptureDevice;

        public PhotoShoot() { }

        ~PhotoShoot()
        {
            if (videoCaptureDevice.IsRunning)
                videoCaptureDevice.Stop();
        }

        public void Initialize(int selectedCameraIndex)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[selectedCameraIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }

        Bitmap capturedStill;

        Bitmap savedReference;
        Bitmap savedNewImage;


        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            capturedStill = (Bitmap)eventArgs.Frame.Clone();
        }

        public string[] GetCameras()
        {
            videoCaptureDevice = new VideoCaptureDevice();

            var cameras = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            List<string> cameraNames = new List<string>();

            foreach (FilterInfo filterInfo in cameras)
                cameraNames.Add(filterInfo.Name);

            return cameraNames.ToArray();
        }

        public Image TakeReferenceImage()
        {
            savedReference = capturedStill;

            return savedReference;
        }

        public PhotoshootResult TakeSpiritImage()
        {
            savedNewImage = capturedStill;

            ImageDifference difference = ComputerVision.GetAbsDifference(savedReference, savedNewImage);

            return new PhotoshootResult
            {
                ProcessedImage = difference.ProcessedImage,
                NewImage = savedNewImage,
                DifferencePercentage = difference.Percentage,
            };
        }
    }
}
