using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

namespace Spirit_Studio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            btnStartPhotoshoot.Enabled = false;

            labelReferenceImageNotifier.Visible = false;
            labelReferenceImageCountdown.Visible = false;
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

        bool photoShootStarted = false;
        private void OnClick_Start(object sender, MouseEventArgs e)
        {
            if (photoShootStarted == false)
            {
                photoShootStarted = true;

                labelReferenceImageNotifier.Visible = true;
                labelReferenceImageCountdown.Visible = true;

                photoShoot.Initialize(cboCamera.SelectedIndex);
                StartPhotoShoot();
            }

            else Debug.WriteLine("REGISTERING CLICK WHILE ASYNC METHOD IS SETTING LABEL CONTENTS");
        }

        private async void StartPhotoShoot()
        {
            await photoShoot.TakeReferenceImage(picReference, labelReferenceImageCountdown);

            await photoShoot.TakeSpiritImagesContinuous(picCamera, picNewImage, labelReferenceImageCountdown, labelReferenceImageNotifier);
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
