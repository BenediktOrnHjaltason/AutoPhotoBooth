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
        private const string configPath = "C:/ProgramData/Spirit Lab/config.json";
        private CountDownUI _spiritUI;
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
            EDSDKLib.EdsInitializeSDK();

            IntPtr cameraList = IntPtr.Zero;
            var error1 = EDSDKLib.EdsGetCameraList(out cameraList);

            int cameraCount = 0;
            var error2 = EDSDKLib.EdsGetChildCount(cameraList, out cameraCount);

            IntPtr cameraRef = IntPtr.Zero;

            EDSDKLib.EdsGetChildAtIndex(cameraList, 0, out cameraRef);

            Debug.WriteLine("Camera count: " + cameraCount);

            EDSDKLib.EdsDeviceInfo cameraInfo = new EDSDKLib.EdsDeviceInfo();

            var error3 =  EDSDKLib.EdsGetDeviceInfo(cameraRef, out cameraInfo);

            Debug.WriteLine($"Camera info:{cameraInfo.szDeviceDescription}");

            var error4 = EDSDKLib.EdsOpenSession(cameraRef);

            Debug.WriteLine("OpenSession error: " + error4);
            */

            _sdkHandler = new SDKHandler();

            var cameraList = _sdkHandler.GetCameraList();

            Debug.WriteLine("number of cameras:" + cameraList.Count);

            _sdkHandler.SDKObjectEvent += EdsObjectEventReceiver;
            _sdkHandler.ImageDownloaded += ReceiveDownloadedImage;
            

            _sdkHandler.OpenSession(cameraList.First());



            _sdkHandler.TakePhoto();

            //sdkHandler.DownloadImage(,)
        }

        public uint EdsObjectEventReceiver(uint inEvent, IntPtr inRef, IntPtr inContext)
        {

            Debug.WriteLine($"EdsObjectEventReceiver CALLED. InEvent {inEvent}");

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
            Debug.WriteLine("ReceiveLiveViewStream CALLED");

            if (str != null) 
            {
                pictureBoxtTextCameraReceive.Image = Image.FromStream(str);
            }
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
                btnStartPhotoshoot.Text = "Stop after\nnext";

                photoShootRunning = true;

                lblRefImageNotifier.Visible = true;
                lblRefImageCountdown.Visible = true;

                photoShoot.Initialize(cboCamera.SelectedIndex);

                _spiritUI = new CountDownUI();
                //_spiritUI.Show();

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
            _spiritUI.SetCountdownVisible(false);
            await CountDown(5);

            picReference.Image =  Utils.ResizeImage(photoShoot.TakeReferenceImage(), new Size(picReference.Width, picReference.Height));

            lblRefImageNotifier.Text = "Next image in";

            while (photoShootRunning)
            {
                _spiritUI.UpdateCommunication("Might we have a picture of you?");
                _spiritUI.SetCountdownVisible(true);
                lblRefImageCountdown.Visible = true;

                await CountDown(5);

                if (!photoShootRunning)
                    break;

                _spiritUI.SetCountdownVisible(false);
                _spiritUI.SetImageVisible(false);


                PhotoshootResult result = photoShoot.TakeSpiritImage();

                lblDiffPercentage.Visible = true;
                lblDiffPercentage.Text = $"Difference:\n{result.DifferencePercentage.ToString("0.000")}%";

                picNewImage.Image = Utils.ResizeImage(result.NewImage, new Size(picNewImage.Width, picNewImage.Height));
                _spiritUI.UpdateImage(result.NewImage);
                _spiritUI.SetImageVisible(true);

                picCamera.Image = Utils.ResizeImage(result.ProcessedImage, new Size(picCamera.Width, picCamera.Height));

                if (result.DifferencePercentage > trackBarSaveFileThreshold.Value)
                {
                    _spiritUI.UpdateCommunication("Thank you!");
                    lblSavedToFile.Visible = true;
                    result.NewImage.Save(Path.Combine("C:/ProgramData/Spirit Lab/PhotoShoot", $"{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.bmp"), ImageFormat.Bmp);
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

                if (_spiritUI != null)
                    _spiritUI.UpdateCounter(countDownIterator.ToString());

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

            photoShoot.CloseVideoContext();
            _sdkHandler.CloseSession();
        }

        private void btnOpenSpiritUI_Click(object sender, EventArgs e)
        {

            
            //if (_spiritUI != null)
                _spiritUI.Show();

        }
    }
}
