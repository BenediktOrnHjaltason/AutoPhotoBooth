﻿namespace SpiritLab
{
    partial class CameraLiveView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxLiveView = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLiveView)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxLiveView
            // 
            this.pictureBoxLiveView.Location = new System.Drawing.Point(7, 9);
            this.pictureBoxLiveView.Name = "pictureBoxLiveView";
            this.pictureBoxLiveView.Size = new System.Drawing.Size(1344, 780);
            this.pictureBoxLiveView.TabIndex = 0;
            this.pictureBoxLiveView.TabStop = false;
            // 
            // CameraLiveView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 793);
            this.Controls.Add(this.pictureBoxLiveView);
            this.Name = "CameraLiveView";
            this.Text = "CameraLiveView";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLiveView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLiveView;
    }
}