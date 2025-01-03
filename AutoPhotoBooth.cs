﻿using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoPhotoBooth.Utilities;
using AutoPhotoBooth.CustomTypes;
using AutoPhotoBooth.Configuration;
using AutoPhotoBooth.Forms;
using Spirit_Studio.Forms;

namespace AutoPhotoBooth
{
    public partial class AutoPhotoBoothForm : Form
    {
        private PhotoBooth _photoBooth = new PhotoBooth();

        private Config _config;
        private CountDown _countdownUI = new CountDown();
        private Slideshow _slideshowUI = new Slideshow();
        private Settings _settingsUI;
        private CameraLiveView _cameraLiveView;

        private ushort _referencePhotoCountdown = 10;

        System.Media.SoundPlayer _soundPlayer = new System.Media.SoundPlayer(@"SuccessSound.wav");
        
        public AutoPhotoBoothForm()
        {
            InitializeComponent();

            btnStartPhotoshoot.Enabled = false;

            lblRefImageNotifier.Visible =
            lblRefImageCountdown.Visible =
            lblDiffPercentage.Visible =
            lblSavedToFile.Visible = false;

            _config = ConfigurationHandler.LoadConfig();

            _settingsUI = new Settings(_config.PhotoBoothConfig);

            _slideshowUI.Initialize(_settingsUI.Config.SlideshowInterval);
            _countdownUI.Initialize();
            _photoBooth.Initialize();
        }

        #region Photo shoot
        
        private void btnGetCameras_Click(object sender, EventArgs e)
        {
            cboCamera.Items.Clear();
            cboCamera.Enabled = btnStartPhotoshoot.Enabled = btnLiveView.Enabled = false;
            
            var imageSourcesNames = _photoBooth.GetImageHandlerNames();

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
                btnLiveView.Enabled = false;

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

                _slideshowUI.Initialize(_settingsUI.Config.SlideshowInterval);
                _countdownUI.Initialize();

                btnLiveView.Enabled = true;

                GC.Collect();
            }
        }

        private async void RunPhotoBooth()
        {
            _countdownUI.SetCountdownVisible(false);
            await CountDown(_referencePhotoCountdown);

            picReference.Image?.Dispose();
            picReference.Image = Utils.ResizeImage(await _photoBooth.TakeReferenceImage(), new Size(picReference.Width, picReference.Height));

            lblRefImageNotifier.Text = "Next image in:";

            while (photoShootRunning)
            {
                _countdownUI.UpdateCommunication("📷");
                _countdownUI.SetCountdownVisible(true);
                _countdownUI.SetCameraIconVisible(true);
                lblRefImageCountdown.Visible = true;

                await CountDown(_settingsUI.Config.PictureInterval);

                if (!photoShootRunning)
                    break;

                _countdownUI.SetCountdownVisible(false);
                _countdownUI.SetCameraIconVisible(false);
                _countdownUI.SetImageVisible(false);

                var result = await _photoBooth.CompareNewImage();

                lblDiffPercentage.Visible = true;
                lblDiffPercentage.Text = $"Difference:\n{result.DifferencePercentage.ToString("0.000")}%";

                picNewImage.Image?.Dispose();
                picNewImage.Image = (Bitmap)Utils.ResizeImage(result.NewImage, new Size(picNewImage.Width, picNewImage.Height)).Clone();
                _countdownUI.UpdateImage((Bitmap)result.NewImage.Clone());
                _countdownUI.SetImageVisible(true);

                picCamera.Image?.Dispose();
                picCamera.Image = (Bitmap)Utils.ResizeImage(result.ProcessedImage, new Size(picCamera.Width, picCamera.Height)).Clone();

                if (result.DifferencePercentage > _settingsUI.SaveThreshold)
                {
                    _soundPlayer.Play();
                    _countdownUI.UpdateCommunication("");
                    _countdownUI.SetCountdownVisible(true);
                    _countdownUI.UpdateCounter("✔");
                    lblSavedToFile.Visible = true;

                    _photoBooth.SaveToPositiveResults();

                    _slideshowUI.AddImage((Bitmap)result.NewImage.Clone());
                }
                else
                {
                    lblSavedToFile.Visible = false;
                    _photoBooth.DeleteComparison();
                }

                result.Dispose();

                lblRefImageCountdown.Visible = false;

                await Task.Delay(3000);

                GC.Collect();
            }

            picCamera?.Image?.Dispose();
            picCamera.Image = null;
            picReference?.Image?.Dispose();
            picReference.Image = null;
            picNewImage?.Image?.Dispose();
            picNewImage.Image = null;
            GC.Collect();
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
                    _countdownUI.UpdateCounter(FormatCountdownString(countDownIterator));

                await Task.Delay(1000);

                countDownIterator--;
            }
        }

        private string FormatCountdownString(int counter)
        {
            int minutes = counter / 60;
            int seconds = counter % 60;

            string minutes_s = minutes > 0 ? (minutes.ToString() + ":") : "";

            string seconds_s;

            if (minutes > 0)
            {
                seconds_s = seconds < 10 ? ("0" + seconds.ToString()) : seconds.ToString();
            }
            else seconds_s = seconds.ToString();

            return $"{minutes_s}{seconds_s}";
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

        private void btnLiveView_Click(object sender, EventArgs e)
        {
            _cameraLiveView?.Dispose();
            _cameraLiveView = new CameraLiveView();
            _photoBooth.StartLiveView(_cameraLiveView.UpdateLiveView);
            _cameraLiveView.Show();
        }

        private void cboCamera_SelectedValueChanged(object sender, EventArgs e)
        {
            _photoBooth.SetActiveImageHandler(cboCamera.SelectedItem.ToString());
        }

        private void AutoPhotoBoothForm_Deactivate(object sender, EventArgs e)
        {
            ConfigurationHandler.SaveConfig(new Config
            {
                PhotoBoothConfig = new PhotoBoothConfig
                {
                    FileSaveThresholdMultiplier = _settingsUI.Config.FileSaveThresholdMultiplier,
                    PictureInterval = _settingsUI.Config.PictureInterval,
                    SlideshowInterval = _settingsUI.Config.SlideshowInterval,
                    ShootDuration = _settingsUI.Config.ShootDuration
                }
            });
        }

        private void AutoPhotoBoothForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _photoBooth.Close();
            _photoBooth.Dispose();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            _settingsUI.Show();
        }
    }
}
