namespace Spirit_Studio.Forms
{
    partial class Settings
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
            this.lbPictureInterval = new System.Windows.Forms.Label();
            this.lbSlideshowInterval = new System.Windows.Forms.Label();
            this.lbChangeThreshold = new System.Windows.Forms.Label();
            this.lbTimeLimit = new System.Windows.Forms.Label();
            this.numUpDownPictureInterval = new System.Windows.Forms.NumericUpDown();
            this.numUpDownSlideshowInterval = new System.Windows.Forms.NumericUpDown();
            this.numUpDownShootDuration = new System.Windows.Forms.NumericUpDown();
            this.trackBarSaveFileThresholdMultiplier = new System.Windows.Forms.TrackBar();
            this.lblTrackBarFileSave = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownPictureInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownSlideshowInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownShootDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSaveFileThresholdMultiplier)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPictureInterval
            // 
            this.lbPictureInterval.AutoSize = true;
            this.lbPictureInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPictureInterval.Location = new System.Drawing.Point(65, 156);
            this.lbPictureInterval.Name = "lbPictureInterval";
            this.lbPictureInterval.Size = new System.Drawing.Size(137, 24);
            this.lbPictureInterval.TabIndex = 0;
            this.lbPictureInterval.Text = "Picture interval:";
            // 
            // lbSlideshowInterval
            // 
            this.lbSlideshowInterval.AutoSize = true;
            this.lbSlideshowInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSlideshowInterval.Location = new System.Drawing.Point(65, 186);
            this.lbSlideshowInterval.Name = "lbSlideshowInterval";
            this.lbSlideshowInterval.Size = new System.Drawing.Size(166, 24);
            this.lbSlideshowInterval.TabIndex = 1;
            this.lbSlideshowInterval.Text = "Slideshow interval:";
            // 
            // lbChangeThreshold
            // 
            this.lbChangeThreshold.AutoSize = true;
            this.lbChangeThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChangeThreshold.Location = new System.Drawing.Point(65, 40);
            this.lbChangeThreshold.Name = "lbChangeThreshold";
            this.lbChangeThreshold.Size = new System.Drawing.Size(170, 24);
            this.lbChangeThreshold.TabIndex = 2;
            this.lbChangeThreshold.Text = "Change threshold: ";
            // 
            // lbTimeLimit
            // 
            this.lbTimeLimit.AutoSize = true;
            this.lbTimeLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimeLimit.Location = new System.Drawing.Point(65, 214);
            this.lbTimeLimit.Name = "lbTimeLimit";
            this.lbTimeLimit.Size = new System.Drawing.Size(137, 24);
            this.lbTimeLimit.TabIndex = 3;
            this.lbTimeLimit.Text = "Shoot duration:";
            // 
            // numUpDownPictureInterval
            // 
            this.numUpDownPictureInterval.Location = new System.Drawing.Point(271, 159);
            this.numUpDownPictureInterval.Name = "numUpDownPictureInterval";
            this.numUpDownPictureInterval.Size = new System.Drawing.Size(55, 22);
            this.numUpDownPictureInterval.TabIndex = 4;
            this.numUpDownPictureInterval.ValueChanged += new System.EventHandler(this.numUpDownPictureInterval_ValueChanged);
            // 
            // numUpDownSlideshowInterval
            // 
            this.numUpDownSlideshowInterval.Location = new System.Drawing.Point(271, 189);
            this.numUpDownSlideshowInterval.Name = "numUpDownSlideshowInterval";
            this.numUpDownSlideshowInterval.Size = new System.Drawing.Size(55, 22);
            this.numUpDownSlideshowInterval.TabIndex = 5;
            this.numUpDownSlideshowInterval.ValueChanged += new System.EventHandler(this.numUpDownSlideshowInterval_ValueChanged);
            // 
            // numUpDownShootDuration
            // 
            this.numUpDownShootDuration.Location = new System.Drawing.Point(270, 217);
            this.numUpDownShootDuration.Name = "numUpDownShootDuration";
            this.numUpDownShootDuration.Size = new System.Drawing.Size(56, 22);
            this.numUpDownShootDuration.TabIndex = 6;
            this.numUpDownShootDuration.ValueChanged += new System.EventHandler(this.numUpDownShootDuration_ValueChanged);
            // 
            // trackBarSaveFileThresholdMultiplier
            // 
            this.trackBarSaveFileThresholdMultiplier.Location = new System.Drawing.Point(270, 40);
            this.trackBarSaveFileThresholdMultiplier.Maximum = 250;
            this.trackBarSaveFileThresholdMultiplier.Name = "trackBarSaveFileThresholdMultiplier";
            this.trackBarSaveFileThresholdMultiplier.Size = new System.Drawing.Size(354, 56);
            this.trackBarSaveFileThresholdMultiplier.TabIndex = 8;
            this.trackBarSaveFileThresholdMultiplier.Scroll += new System.EventHandler(this.trackBarSaveFileThresholdMultiplier_Scroll);
            // 
            // lblTrackBarFileSave
            // 
            this.lblTrackBarFileSave.AutoSize = true;
            this.lblTrackBarFileSave.Location = new System.Drawing.Point(278, 90);
            this.lblTrackBarFileSave.Name = "lblTrackBarFileSave";
            this.lblTrackBarFileSave.Size = new System.Drawing.Size(294, 16);
            this.lblTrackBarFileSave.TabIndex = 9;
            this.lblTrackBarFileSave.Text = "Change percentage required to save new image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(348, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "seconds";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(348, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "seconds";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(348, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "minutes (0 = unlimited)";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 297);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTrackBarFileSave);
            this.Controls.Add(this.trackBarSaveFileThresholdMultiplier);
            this.Controls.Add(this.numUpDownShootDuration);
            this.Controls.Add(this.numUpDownSlideshowInterval);
            this.Controls.Add(this.numUpDownPictureInterval);
            this.Controls.Add(this.lbTimeLimit);
            this.Controls.Add(this.lbChangeThreshold);
            this.Controls.Add(this.lbSlideshowInterval);
            this.Controls.Add(this.lbPictureInterval);
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownPictureInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownSlideshowInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownShootDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSaveFileThresholdMultiplier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPictureInterval;
        private System.Windows.Forms.Label lbSlideshowInterval;
        private System.Windows.Forms.Label lbChangeThreshold;
        private System.Windows.Forms.Label lbTimeLimit;
        private System.Windows.Forms.NumericUpDown numUpDownPictureInterval;
        private System.Windows.Forms.NumericUpDown numUpDownSlideshowInterval;
        private System.Windows.Forms.NumericUpDown numUpDownShootDuration;
        private System.Windows.Forms.TrackBar trackBarSaveFileThresholdMultiplier;
        private System.Windows.Forms.Label lblTrackBarFileSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}