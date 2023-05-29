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
using SpiritLab.Utilities;
using System.IO;
using System.Drawing.Imaging;
using SpiritLab.CustomTypes;
using SpiritLab.Configuration;
using SpiritLab.Forms;

namespace SpiritLab
{
    public partial class SpiritLabForm : Form
    {
        private PhotoBooth _photoBooth = new PhotoBooth();

        private const string configPath = "C:/ProgramData/Spirit Lab/config.json";
        private CountDown _countdownUI;
        private Slideshow _slideshowUI;
        private CameraLiveView _cameraLiveView;
        

        public SpiritLabForm()
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

            _photoBooth.Initialize();

            /*
            
            var cameraList = _sdkHandler.GetCameraList();

            Debug.WriteLine("number of cameras:" + cameraList.Count);

            _sdkHandler.SDKObjectEvent += EdsObjectEventReceiver;
            _sdkHandler.ImageDownloaded += ReceiveDownloadedImage;
            

            _sdkHandler.TakePhoto();
            */
        }

        

        #region Photo shoot

        private void btnGetCameras_Click(object sender, EventArgs e)
        {
            cboCamera.Items.Clear();
            cboCamera.Enabled = btnStartPhotoshoot.Enabled = btnLiveView.Enabled = false;

            var imageSourcesNames = _photoBooth.GetImageSourceNames();

            if (imageSourcesNames.Any() ) 
            {
                cboCamera.Enabled = btnStartPhotoshoot.Enabled = btnLiveView.Enabled = true;

                foreach (var cameraName in imageSourcesNames)
                    cboCamera.Items.Add(cameraName);

                cboCamera.SelectedIndex = 0;
            }
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

                _countdownUI = new CountDown();
                _slideshowUI = new Slideshow();

                btnOpenCountDownUI.Enabled = btnOpenSlideshowUI.Enabled = true;

                RunPhotoBooth();
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

                btnOpenCountDownUI.Enabled = btnOpenSlideshowUI.Enabled = false;
            }
        }

        private async void RunPhotoBooth()
        {
            _countdownUI.SetCountdownVisible(false);
            await CountDown(5);

            picReference.Image =  Utils.ResizeImage(_photoBooth.TakeReferenceImage().GetAwaiter().GetResult(), new Size(picReference.Width, picReference.Height));

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

                var result = await _photoBooth.CompareNewImage();

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

        private void SpiritLabForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigurationHandler.SaveConfig(new Config { FileSaveThreshold = trackBarSaveFileThreshold.Value }, configPath);

            _photoBooth.Close();
        }

        private void btnLiveView_Click(object sender, EventArgs e)
        {
            _cameraLiveView = new CameraLiveView();
            _photoBooth.StartLiveView(_cameraLiveView.UpdateLiveView);
            _cameraLiveView.Show();
        }

        private void cboCamera_SelectedValueChanged(object sender, EventArgs e)
        {
            _photoBooth.SetActiveImageSource(cboCamera.SelectedItem.ToString());
        }
    }
}
