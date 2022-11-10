using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spirit_Studio.CustomTypes;
using System.Diagnostics;
using Spirit_Studio.Utilities;

namespace Spirit_Studio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            btnStartPhotoshoot.Enabled = false;

            lblRefImageNotifier.Visible = false;
            lblRefImageCountdown.Visible = false;
        }

        private PhotoShoot photoShoot = new PhotoShoot();

        #region Photo shoot

        private void btnGetCameras_Click(object sender, EventArgs e)
        {
            foreach (var cameraName in photoShoot.GetCameras())
                cboCamera.Items.Add(cameraName);

            btnStartPhotoshoot.Enabled = cboCamera.Items.Count > 0;

            cboCamera.SelectedIndex = 0;
        }

        private bool photoShootRunning = false;
        private void OnClick_Start(object sender, MouseEventArgs e)
        {
            if (photoShootRunning == false)
            {
                btnStartPhotoshoot.Text = "Stop";

                photoShootRunning = true;

                lblRefImageNotifier.Visible = true;
                lblRefImageCountdown.Visible = true;

                photoShoot.Initialize(cboCamera.SelectedIndex);
                RunPhotoShoot();
            }

            else
            {
                photoShootRunning = false;
                btnStartPhotoshoot.Text = "Stop";
                lblRefImageNotifier.Text = "Saving reference image in";
                lblRefImageNotifier.Visible = false;
                lblRefImageCountdown.Text = "5";
                lblRefImageCountdown.Visible = false;
            }
        }

        private async void RunPhotoShoot()
        {
            await CountDown(5);

            picReference.Image =  Utils.ResizeImage(photoShoot.TakeReferenceImage(), new Size(picReference.Width, picReference.Height));

            lblRefImageNotifier.Text = "Next image in";

            while (photoShootRunning)
            {
                await CountDown(5);

                PhotoshootResult result = photoShoot.TakeSpiritImage();

                lblDiffPercentage.Text = $"Difference: {result.DifferencePercentage.ToString("0.000")}%";

                picNewImage.Image = Utils.ResizeImage(result.NewImage, new Size(picNewImage.Width, picNewImage.Height));
                picCamera.Image = Utils.ResizeImage(result.ProcessedImage, new Size(picCamera.Width, picCamera.Height));
            }
            

            //SetNotificationLabelsVisible(false);
            //RefreshLabels();

        }

        private async Task CountDown(int duration)
        {
            int countDownIterator = duration;

            while (countDownIterator > 0)
            {
                lblRefImageCountdown.Text = countDownIterator.ToString();

                await Task.Delay(1000);

                countDownIterator--;
            }
        }

        #endregion

        #region RandomNumbers

        private bool randomNumbersRunning = false;
        private Random random = new Random();
        private int lastGeneratedValue;
        private int sumGeneratedZeros = 0;
        private int sumGeneratedOnes = 0;

        private List<int> generatedValuesQueue = new List<int>();

        private void btnRandomStartStop_Click(object sender, EventArgs e)
        {
            randomNumbersRunning = !randomNumbersRunning;

            if (randomNumbersRunning)
            {
                btnRandomStartStop.Text = "Stop";
                GenerateRandomNumbers();
            }
            else
            {
                btnRandomStartStop.Text = "Start";
                labelValue.Text = "#";

                sumGeneratedOnes = sumGeneratedZeros = 0;
                labelOnesPercentage.Text = labelZerosPercentages.Text = labelOnesTotal.Text = labelZerosTotal.Text = "0";
            }
        }

        private async void GenerateRandomNumbers()
        {
            while(randomNumbersRunning)
            {
                lastGeneratedValue = random.Next(0, 2);

                labelValue.Text = lastGeneratedValue.ToString();

                if (lastGeneratedValue == 0)
                    sumGeneratedZeros++;
                else if (lastGeneratedValue == 1)
                    sumGeneratedOnes++;

                labelOnesTotal.Text = sumGeneratedOnes.ToString();
                labelZerosTotal.Text = sumGeneratedZeros.ToString();

                labelZerosPercentages.Text = (((float)sumGeneratedZeros / ((float)sumGeneratedZeros + (float)sumGeneratedOnes)) * 100.0f).ToString("0.0");
                labelOnesPercentage.Text = (100.0f - float.Parse(labelZerosPercentages.Text)).ToString();

                await Task.Delay(50);
            }
        }

        #endregion
    }
}
