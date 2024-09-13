using SpiritLab.Configuration;
using SpiritLab.CustomTypes;
using System;
using System.Windows.Forms;

namespace Spirit_Studio.Forms
{
    public partial class Settings : Form
    {
        public PhotoBoothConfig Config;

        //We use a small base so we can get smaller increments than the standard values from the numUpDown control
        private const float _saveThresholdBase = 0.01f;

        public float SaveThreshold { get { return _saveThresholdBase * Config.FileSaveThresholdMultiplier; } }

        public Settings(PhotoBoothConfig config)
        {
            InitializeComponent();

            Config = config;

            Initialize();
            
        }

        private void trackBarSaveFileThresholdMultiplier_Scroll(object sender, EventArgs e)
        {
            Config.FileSaveThresholdMultiplier = trackBarSaveFileThresholdMultiplier.Value;
            UpdateFileSaveThresholdLabel();
        }

        private void UpdateFileSaveThresholdLabel()
        {
            lblTrackBarFileSave.Text = $"Change percentage required to save new image: {SaveThreshold}%";
        }

        private void numUpDownPictureInterval_ValueChanged(object sender, EventArgs e)
        {
            Config.PictureInterval = (int)numUpDownPictureInterval.Value;
        }

        private void numUpDownSlideshowInterval_ValueChanged(object sender, EventArgs e)
        {
            Config.SlideshowInterval = (int)numUpDownSlideshowInterval.Value; 
        }

        private void numUpDownShootDuration_ValueChanged(object sender, EventArgs e)
        {
            Config.ShootDuration = (int)numUpDownShootDuration.Value;
        }

        private void Initialize()
        {
            trackBarSaveFileThresholdMultiplier.Value = Config.FileSaveThresholdMultiplier;
            UpdateFileSaveThresholdLabel();

            numUpDownPictureInterval.Value = Config.PictureInterval;
            numUpDownSlideshowInterval.Value = Config.SlideshowInterval;
            numUpDownShootDuration.Value = Config.ShootDuration;
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigurationHandler.SaveConfig(new Config
            {
                PhotoBoothConfig = new PhotoBoothConfig
                {
                    FileSaveThresholdMultiplier = Config.FileSaveThresholdMultiplier,
                    PictureInterval = Config.PictureInterval,
                    SlideshowInterval = Config.SlideshowInterval,
                    ShootDuration = Config.ShootDuration
                }
            });

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
