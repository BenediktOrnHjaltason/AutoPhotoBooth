using SpiritLab.Utilities;
using System.Drawing;
using System.Windows.Forms;

namespace SpiritLab
{
    public partial class CameraLiveView : Form
    {
        public CameraLiveView()
        {
            InitializeComponent();
        }

        public void UpdateLiveView(Image image) 
        {
            pictureBoxLiveView?.Image?.Dispose();


            pictureBoxLiveView.Image = image;
        }

        private void CameraLiveView_FormClosing(object sender, FormClosingEventArgs e)
        {
            PhotoBooth.StopLiveView();
        }
    }
}
