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
            PictureBox mainImageBox,
            PictureBox newImageBox,
            Label lblCountdown,
            Label lblNotifier,
            Label lblDifferencePercentage)
        {
            lblNotifier.Text = "Next image in:";
            lblNotifier.Refresh();

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

            lblCountdown.Visible = false;
            lblNotifier.Visible = false;

            savedNewImage = capturedStill;

            double? differencePercentage = 0;
            Image convertedImage = ComputerVision.GetAbsDifference(savedReference, savedNewImage, out differencePercentage);
            lblDifferencePercentage.Text = $"Difference: {differencePercentage.Value.ToString("0.0")}%";

            Image resizedConvertedImage = ComputerVision.resizeImage(convertedImage, new Size(mainImageBox.Width, mainImageBox.Height));
            Image resizedNewImage = ComputerVision.resizeImage(savedNewImage, new Size(newImageBox.Width, newImageBox.Height));

            mainImageBox.Image = resizedConvertedImage;
            newImageBox.Image = resizedNewImage;


            mainImageBox.Refresh();
            newImageBox.Refresh();
        }
    }
}
