using System.Drawing;
using System.Windows.Forms;

namespace SpiritLab.Forms
{
    public partial class CountDown : Form
    {
        public CountDown()
        {
            InitializeComponent();

            lblCountdown.Parent =
            lblCommunication.Parent = picDisplay;

            lblCountdown.BackColor = Color.Transparent;
        }

        public void Initialize()
        {
            lblCountdown.Text = "";
            lblCountdown.Visible = true;
            picDisplay.Image = null;
            lblCommunication.Text = "";
        }

        public void UpdateImage(Image image)
        {
            picDisplay.Image = Utilities.Utils.ResizeImage(image, new Size(picDisplay.Width, picDisplay.Height));
        }

        public void SetImageVisible(bool visible)
        {
            picDisplay.Visible = visible;
        }

        public void UpdateCounter(string text)
        {
            lblCountdown.BackColor = Color.Transparent;
            lblCountdown.Text = text;
        }

        public void SetCountdownVisible(bool visible)
        {
            lblCountdown.BackColor = Color.Transparent;
            lblCountdown.Visible = visible;
        }

        public void SetCameraIconVisible(bool visible) 
        {
            lblCommunication.Visible = visible;
        }

        public void UpdateCommunication(string text)
        {
            lblCommunication.Text = text;
        }

        private void CountDownUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
