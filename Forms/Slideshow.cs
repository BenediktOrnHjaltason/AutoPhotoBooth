using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPhotoBooth.Forms
{
    public partial class Slideshow : Form
    {
        private LinkedList<Image> _images = new LinkedList<Image>();

        private bool _slideshowRunning;
        private int _currentImageIndex;
        private int _interval;

        public Slideshow()
        {
            InitializeComponent();
        }

        public void Initialize(int interval)
        {
            lbCounter.Text = "0 / 0";
            _slideshowRunning = false;
            _currentImageIndex = 0;

            foreach (Image image in _images)
                image.Dispose();
                
            _images.Clear();

            pictureBoxSlideshow.Image = null;
            _interval = interval;
        }

        public void AddImage(Image bitmap)
        {
            
            _images.AddFirst((Bitmap)Utilities.Utils.ResizeImage(bitmap, new Size(pictureBoxSlideshow.Width, pictureBoxSlideshow.Height)).Clone());
            _currentImageIndex = 0;

            if (_images.Count > 5) 
            {
                _images.ElementAt(_images.Count - 1).Dispose();
                _images.RemoveLast();
            }

            if (!_slideshowRunning) 
            {
                StartSlideshow();
            }
        }

        private async void StartSlideshow()
        {
            _currentImageIndex = 0;
            _slideshowRunning = true;
            while (_slideshowRunning) 
            {
                pictureBoxSlideshow.Image?.Dispose();
                pictureBoxSlideshow.Image = (Bitmap)_images.ElementAt(_currentImageIndex).Clone();
                lbCounter.Text = $"{_currentImageIndex + 1} / {_images.Count}";

                _currentImageIndex = _currentImageIndex + 1 <= _images.Count - 1 ? ++_currentImageIndex : 0;

                await Task.Delay(_interval * 1000);
            }
        }

        private void Slideshow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _slideshowRunning = false;

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void Slideshow_Load(object sender, EventArgs e)
        {
            if (_images.Count > 0 && !_slideshowRunning) 
            {
                StartSlideshow();
            }
        }
    }
}
