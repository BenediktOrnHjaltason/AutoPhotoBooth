using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiritLab.Forms
{
    public partial class Slideshow : Form
    {
        private LinkedList<Image> images = new LinkedList<Image>();

        private bool slideshowRunning;
        private int currentImageIndex;

        public Slideshow()
        {
            InitializeComponent();
        }

        public void AddImage(Image bitmap)
        {
            images.AddFirst(bitmap);
            currentImageIndex = 0;

            if (!slideshowRunning) 
            {
                StartSlideshow();
            }
        }

        private async void StartSlideshow()
        {
            currentImageIndex = 0;
            slideshowRunning = true;
            while (slideshowRunning) 
            {
                pictureBoxSlideshow.Image = images.ElementAt(currentImageIndex);
                lbCounter.Text = $"{currentImageIndex + 1} / {images.Count}";

                currentImageIndex = currentImageIndex + 1 <= images.Count - 1 ? ++currentImageIndex : 0;

                await Task.Delay(5000);
            }
        }

        private void Slideshow_FormClosing(object sender, FormClosingEventArgs e)
        {
            slideshowRunning = false;

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void Slideshow_Load(object sender, EventArgs e)
        {
            if (images.Count > 0 && !slideshowRunning) 
            {
                StartSlideshow();
            }
        }
    }
}
