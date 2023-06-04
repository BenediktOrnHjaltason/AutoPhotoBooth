using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiritLab.Forms
{
    public partial class Slideshow : Form
    {
        private LinkedList<Image> images = new LinkedList<Image>();

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
            images.Clear();
            pictureBoxSlideshow.Image = null;
            _interval = interval;
        }

        public void AddImage(Image bitmap)
        {
            images.AddFirst(bitmap);
            _currentImageIndex = 0;

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
                pictureBoxSlideshow.Image = images.ElementAt(_currentImageIndex);
                lbCounter.Text = $"{_currentImageIndex + 1} / {images.Count}";

                _currentImageIndex = _currentImageIndex + 1 <= images.Count - 1 ? ++_currentImageIndex : 0;

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
            if (images.Count > 0 && !_slideshowRunning) 
            {
                StartSlideshow();
            }
        }
    }
}
