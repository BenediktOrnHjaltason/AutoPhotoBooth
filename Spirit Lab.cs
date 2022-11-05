using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Diagnostics;

namespace Spirit_Studio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        private void OnClick_Start(object sender, MouseEventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cboCamera.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            picCamera.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                cboCamera.Items.Add(filterInfo.Name);

            cboCamera.SelectedIndex = 0;

            videoCaptureDevice = new VideoCaptureDevice();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice.IsRunning)
                videoCaptureDevice.Stop();
        }

        #region RandomNumbers

        private bool randomNumbersRunning = false;
        private Random random = new Random();
        private int lastGeneratedValue;
        private int poolGeneratedZeros = 0;
        private int poolGeneratedOnes = 0;

        private Queue<int> generatedValuesQueue = new Queue<int>();

        private void btnRandomStartStop_Click(object sender, EventArgs e)
        {
            randomNumbersRunning = !randomNumbersRunning;

            if (randomNumbersRunning)
            {
                btnRandomStartStop.Text = "Stop";
                GenerateRandomNumberRecursive();
            }
            else
            {
                btnRandomStartStop.Text = "Start";
                labelValue.Text = "#";

                poolGeneratedOnes = poolGeneratedZeros = 0;
                labelOnesOccurences.Text = labelZerosOccurenses.Text = "0";

                generatedValuesQueue.Clear();
            }
        }

        private async void GenerateRandomNumberRecursive()
        {
            lastGeneratedValue = random.Next(0, 2);
            generatedValuesQueue.Enqueue(lastGeneratedValue);
            labelValue.Text = lastGeneratedValue.ToString();

            if (lastGeneratedValue == 0)
                poolGeneratedZeros++;
            else if (lastGeneratedValue == 1)
                poolGeneratedOnes++;


            if (generatedValuesQueue.Count > 100)
            {
                int dequeuedValue = generatedValuesQueue.Dequeue();

                if (dequeuedValue == 0)
                    poolGeneratedZeros--;
                else if (dequeuedValue == 1)
                    poolGeneratedOnes--;
            }

            labelOnesOccurences.Text = poolGeneratedZeros.ToString();
            labelZerosOccurenses.Text = poolGeneratedOnes.ToString();

            await Task.Delay(100);

            if (randomNumbersRunning)
                GenerateRandomNumberRecursive();
        }

        #endregion
    }
}
