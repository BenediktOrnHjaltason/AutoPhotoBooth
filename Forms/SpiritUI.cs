﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spirit_Studio.Forms
{
    public partial class SpiritUI : Form
    {
        public SpiritUI()
        {
            InitializeComponent();

            lblCountdown.Parent = picDisplay;

            lblCountdown.BackColor = Color.Transparent;
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
    }
}
