using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing;
using System.Windows.Forms;


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

        public async Task TakeReferenceImage(
            PictureBox referenceImage, 
            Label lblReferenceImageCountdown,
            Label lblReferenceImageNotifierText)
        {
            int countdownDuration = 5;
            DateTime referenceCountdownEnd;
            DateTime referenceCountdownStart;
            int countdownIterator = 0;

            referenceCountdownStart = DateTime.Now;
            referenceCountdownEnd = referenceCountdownStart.AddSeconds(5);

            await Task.Delay(100);

            while (DateTime.Now < referenceCountdownEnd)
            {
                if (DateTime.Now > referenceCountdownStart.AddSeconds(countdownIterator))
                {
                    countdownIterator++;

                    lblReferenceImageCountdown.Text = (countdownDuration - countdownIterator + 1).ToString();
                    lblReferenceImageCountdown.Refresh();
                }
            }

            //picCamera.Image =

            referenceImage.Image = ComputerVision.resizeImage(capturedStill, new Size(referenceImage.Width, referenceImage.Height));

            lblReferenceImageCountdown.Text = "";
            lblReferenceImageNotifierText.Text = "Next image in:";
        }
    }
}
