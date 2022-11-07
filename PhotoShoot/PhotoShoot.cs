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

        Image capturedStill;

        Image savedReference;
        Image savedNewImage;


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

        int countdownDuration = 5;
        DateTime referenceCountdownEnd;
        DateTime referenceCountdownStart;
        int countdownIterator = 0;

        public async Task TakeReferenceImage(
            PictureBox referenceImage, 
            Label lblCountdown)
        {
            referenceCountdownStart = DateTime.Now;
            referenceCountdownEnd = referenceCountdownStart.AddSeconds(countdownDuration);

            await Task.Delay(100);

            while (DateTime.Now < referenceCountdownEnd)
            {
                if (DateTime.Now > referenceCountdownStart.AddSeconds(countdownIterator))
                {
                    countdownIterator++;

                    lblCountdown.Text = (countdownDuration - countdownIterator + 1).ToString();
                    lblCountdown.Refresh();
                }
            }

            //picCamera.Image =

            referenceImage.Image = ComputerVision.resizeImage(capturedStill, new Size(referenceImage.Width, referenceImage.Height));
            referenceImage.Refresh();

            savedReference = capturedStill;

            lblCountdown.Text = "";
            countdownIterator = 0;
            
        }

        public async Task TakeSpiritImagesContinuous(
            PictureBox mainImage,
            Label lblCountdown,
            Label lblNotifier)
        {
            lblNotifier.Text = "Next image in:";

            referenceCountdownStart = DateTime.Now;
            referenceCountdownEnd = referenceCountdownStart.AddSeconds(countdownDuration);

            while (DateTime.Now < referenceCountdownEnd)
            {
                if (DateTime.Now > referenceCountdownStart.AddSeconds(countdownIterator))
                {
                    countdownIterator++;

                    lblCountdown.Text = (countdownDuration - countdownIterator + 1).ToString();
                    lblCountdown.Refresh();
                }
            }

            savedNewImage = capturedStill;
            mainImage.Image = ComputerVision.resizeImage(
                ComputerVision.GetAbsDifference(savedReference, savedNewImage), new Size(mainImage.Width, mainImage.Height));

            //mainImage.Image = ComputerVision.resizeImage(capturedStill, new Size(mainImage.Width, mainImage.Height));
        }
    }
}
