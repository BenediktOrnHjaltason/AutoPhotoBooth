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
using System.IO;
using System.Drawing.Imaging;
using Spirit_Studio.Forms;
using EDSDK;

namespace Spirit_Studio
{
    public partial class Form1 : Form
    {
        private PhotoShoot _photoShoot = new PhotoShoot();

        private const string configPath = "C:/ProgramData/Spirit Lab/config.json";
        private CountDown _countdownUI;
        private Slideshow _slideshowUI;
        private SDKHandler _sdkHandler;

        public Form1()
        {
            InitializeComponent();

            btnStartPhotoshoot.Enabled = false;

            lblRefImageNotifier.Visible =
            lblRefImageCountdown.Visible =
            lblDiffPercentage.Visible =
            lblSavedToFile.Visible = false;

            Config config = ConfigurationHandler.LoadConfig(configPath);

            if(config != null)
            {
                trackBarSaveFileThreshold.Value = config.FileSaveThreshold;
                lblTrackBarFileSave.Text = config.FileSaveThreshold.ToString();
            }

            UpdateTrackBarThresholdLabel();

            /*
            _sdkHandler = new SDKHandler();
            
            
            var cameraList = _sdkHandler.GetCameraList();

            Debug.WriteLine("number of cameras:" + cameraList.Count);

            _sdkHandler.SDKObjectEvent += EdsObjectEventReceiver;
            _sdkHandler.ImageDownloaded += ReceiveDownloadedImage;
            
            _sdkHandler.OpenSession(cameraList.First());

            _sdkHandler.TakePhoto();
            */
        }

        public uint EdsObjectEventReceiver(uint inEvent, IntPtr inRef, IntPtr inContext)
        {
            if ( inEvent == 516 ) 
            {
                _sdkHandler.DownloadImage(inRef);
            }

            return 0;
        }

        public void ReceiveDownloadedImage(Bitmap bitmap)
        {
            if (bitmap != null)
            {
                pictureBoxtTextCameraReceive.Image = Utils.ResizeImage(bitmap, pictureBoxtTextCameraReceive.Size);

                _sdkHandler.LiveViewUpdated += ReceiveLiveViewstream;
                _sdkHandler.StartLiveView();
            }
        }

        public void ReceiveLiveViewstream(Stream str)
        {
            if (str != null) 
            {
                pictureBoxtTextCameraReceive.Image = Image.FromStream(str);
            }
        }

        #region Photo shoot

        private void btnGetCameras_Click(object sender, EventArgs e)
        {
            foreach (var cameraName in _photoShoot.GetCameras())
                cboCamera.Items.Add(cameraName);

            btnStartPhotoshoot.Enabled = cboCamera.Items.Count > 0;

            cboCamera.SelectedIndex = 0;
        }

        private bool photoShootRunning = false;
        private void OnClick_Start(object sender, MouseEventArgs e)
        {
            if (photoShootRunning == false)
            {
                btnStartPhotoshoot.Text = "Stop after\nnext";

                photoShootRunning = true;

                lblRefImageNotifier.Visible = true;
                lblRefImageCountdown.Visible = true;

                _photoShoot.Initialize(cboCamera.SelectedIndex);

                _countdownUI = new CountDown();
                _slideshowUI = new Slideshow();

                RunPhotoShoot();
            }

            else
            {
                photoShootRunning = false;
                btnStartPhotoshoot.Text = "Start";
                lblRefImageNotifier.Text = "Saving reference image in";
                lblRefImageNotifier.Visible = false;
                lblRefImageCountdown.Text = "5";
                lblRefImageCountdown.Visible = false;
                lblDiffPercentage.Visible = false;
            }
        }

        private async void RunPhotoShoot()
        {
            _countdownUI.SetCountdownVisible(false);
            await CountDown(5);

            picReference.Image =  Utils.ResizeImage(_photoShoot.TakeReferenceImage(), new Size(picReference.Width, picReference.Height));

            lblRefImageNotifier.Text = "Next image in";

            while (photoShootRunning)
            {
                _countdownUI.UpdateCommunication("Might we have a picture of you?");
                _countdownUI.SetCountdownVisible(true);
                lblRefImageCountdown.Visible = true;

                await CountDown(5);

                if (!photoShootRunning)
                    break;

                _countdownUI.SetCountdownVisible(false);
                _countdownUI.SetImageVisible(false);


                PhotoshootResult result = _photoShoot.TakeSpiritImage();

                lblDiffPercentage.Visible = true;
                lblDiffPercentage.Text = $"Difference:\n{result.DifferencePercentage.ToString("0.000")}%";

                picNewImage.Image = Utils.ResizeImage(result.NewImage, new Size(picNewImage.Width, picNewImage.Height));
                _countdownUI.UpdateImage(result.NewImage);
                _countdownUI.SetImageVisible(true);

                picCamera.Image = Utils.ResizeImage(result.ProcessedImage, new Size(picCamera.Width, picCamera.Height));

                if (result.DifferencePercentage > trackBarSaveFileThreshold.Value)
                {
                    _countdownUI.UpdateCommunication("Thank you!");
                    lblSavedToFile.Visible = true;
                    result.NewImage.Save(Path.Combine("C:/ProgramData/Spirit Lab/PhotoShoot", $"{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.bmp"), ImageFormat.Bmp);
                    _slideshowUI.AddImage(result.NewImage);
                }
                else lblSavedToFile.Visible = false;

                lblRefImageCountdown.Visible = false;

                await Task.Delay(3000);
            }

            picCamera.Image = null;
            picReference.Image = null;
            picNewImage.Image = null;
        }

        private async Task CountDown(int duration)
        {
            int countDownIterator = duration;

            while (countDownIterator > 0)
            {
                if (!photoShootRunning)
                    break;

                lblRefImageCountdown.Text = countDownIterator.ToString();

                if (_countdownUI != null)
                    _countdownUI.UpdateCounter(countDownIterator.ToString());

                await Task.Delay(1000);

                countDownIterator--;
            }
        }

        private void trackBarSaveFileThreshold_Scroll(object sender, EventArgs e)
        {
            UpdateTrackBarThresholdLabel();
        }

        private void UpdateTrackBarThresholdLabel()
        {
            lblTrackBarFileSave.Text = $"Change percentage required to save new image: {trackBarSaveFileThreshold.Value}%";
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigurationHandler.SaveConfig(new Config { FileSaveThreshold = trackBarSaveFileThreshold.Value }, configPath);

            _photoShoot.CloseVideoContext();
            //_sdkHandler.CloseSession();
        }

        private void btnOpenSlideshowUI_Click(object sender, EventArgs e)
        {
            if (_slideshowUI != null)
            _slideshowUI.Show();
        }

        private void btnOpenCountDownUI_Click(object sender, EventArgs e)
        {
            if (_countdownUI != null)
                _countdownUI.Show();
        }
    }
}
