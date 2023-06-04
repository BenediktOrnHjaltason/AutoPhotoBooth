using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        private const string _configPath = "C:/ProgramData/Spirit Lab/config.json";
        private Config _config;
        private CountDown _countdownUI = new CountDown();
        private Slideshow _slideshowUI = new Slideshow();
        private CameraLiveView _cameraLiveView;

        System.Media.SoundPlayer _soundPlayer = new System.Media.SoundPlayer(@"SuccessSound.wav");
        

        public SpiritLabForm()
        {
            InitializeComponent();

            btnStartPhotoshoot.Enabled = false;

            lblRefImageNotifier.Visible =
            lblRefImageCountdown.Visible =
            lblDiffPercentage.Visible =
            lblSavedToFile.Visible = false;

            _config = ConfigurationHandler.LoadConfig(_configPath);

            if (_config == null)
                _config = new Config();

            trackBarSaveFileThreshold.Value = _config.PhotoBoothConfig.FileSaveThreshold;
            lblTrackBarFileSave.Text = _config.PhotoBoothConfig.FileSaveThreshold.ToString();
            numUpDownShootInterval.Value = _config.PhotoBoothConfig.ShootInterval;
            numUpDownSlideshowInterval.Value = _config.PhotoBoothConfig.SlideshowInterval;

            _slideshowUI.Initialize((int)numUpDownSlideshowInterval.Value);
            _countdownUI.Initialize();

            UpdateTrackBarThresholdLabel();

            _photoBooth.Initialize();
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

                photoShootRunning =
                lblRefImageNotifier.Visible =
                lblRefImageCountdown.Visible = true;

                lblRefImageCountdown.Text = "5";

                RunPhotoBooth();
            }

            else
            {
                photoShootRunning =
                lblRefImageNotifier.Visible =
                lblRefImageCountdown.Visible =
                lblDiffPercentage.Visible = false;
                btnStartPhotoshoot.Text = "Start";
                lblRefImageNotifier.Text = "Saving reference in:";
                
                lblRefImageCountdown.Text = "0";

                lblSavedToFile.Visible = false;


                _slideshowUI.Initialize((int)numUpDownSlideshowInterval.Value);
                _countdownUI.Initialize();
            }
        }

        private async void RunPhotoBooth()
        {
            _countdownUI.SetCountdownVisible(false);
            await CountDown(5);

            picReference.Image =  Utils.ResizeImage(await _photoBooth.TakeReferenceImage(), new Size(picReference.Width, picReference.Height));

            lblRefImageNotifier.Text = "Next image in:";

            while (photoShootRunning)
            {
                _countdownUI.UpdateCommunication("Might we have a picture of you?");
                _countdownUI.SetCountdownVisible(true);
                lblRefImageCountdown.Visible = true;

                await CountDown((int)numUpDownShootInterval.Value);

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
                    _soundPlayer.Play();
                    _countdownUI.UpdateCommunication("");
                    _countdownUI.SetCountdownVisible(true);
                    _countdownUI.UpdateCounter("✔");
                    lblSavedToFile.Visible = true;

                    var bitmap = new Bitmap(result.NewImage);

                    if (!Directory.Exists("C:/ProgramData/Spirit Lab/PhotoShoot"))
                        Directory.CreateDirectory("C:/ProgramData/Spirit Lab/PhotoShoot");

                    bitmap.Save(Path.Combine("C:/ProgramData/Spirit Lab/PhotoShoot", $"{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.bmp"), ImageFormat.Bmp);

                    bitmap.Dispose();

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
            ConfigurationHandler.SaveConfig(new Config { PhotoBoothConfig = new PhotoBoothConfig { FileSaveThreshold = trackBarSaveFileThreshold.Value,
                                                                                                   ShootInterval = (int)numUpDownShootInterval.Value,
                                                                                                   SlideshowInterval = (int)numUpDownSlideshowInterval.Value}}, _configPath);

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
