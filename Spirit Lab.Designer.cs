
namespace SpiritLab
{
    partial class SpiritLabForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpiritLabForm));
            this.cboCamera = new System.Windows.Forms.ComboBox();
            this.btnStartPhotoshoot = new System.Windows.Forms.Button();
            this.picCamera = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPhotoBooth = new System.Windows.Forms.TabPage();
            this.numUpDownSlideshowInterval = new System.Windows.Forms.NumericUpDown();
            this.numUpDownShootInterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblShootInterval = new System.Windows.Forms.Label();
            this.btnLiveView = new System.Windows.Forms.Button();
            this.btnOpenSlideshowUI = new System.Windows.Forms.Button();
            this.btnOpenCountDownUI = new System.Windows.Forms.Button();
            this.lblSavedToFile = new System.Windows.Forms.Label();
            this.lblTrackBarFileSave = new System.Windows.Forms.Label();
            this.trackBarSaveFileThresholdMultiplier = new System.Windows.Forms.TrackBar();
            this.lblDiffPercentage = new System.Windows.Forms.Label();
            this.lblNewImage = new System.Windows.Forms.Label();
            this.picNewImage = new System.Windows.Forms.PictureBox();
            this.btnGetCameras = new System.Windows.Forms.Button();
            this.labelReference = new System.Windows.Forms.Label();
            this.picReference = new System.Windows.Forms.PictureBox();
            this.lblRefImageNotifier = new System.Windows.Forms.Label();
            this.lblRefImageCountdown = new System.Windows.Forms.Label();
            this.tabRandom = new System.Windows.Forms.TabPage();
            this.labelZerosTotal = new System.Windows.Forms.Label();
            this.labelOnesTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRandomStartStop = new System.Windows.Forms.Button();
            this.labelZerosPercentages = new System.Windows.Forms.Label();
            this.labelOnesPercentage = new System.Windows.Forms.Label();
            this.labelOnes = new System.Windows.Forms.Label();
            this.labelZeros = new System.Windows.Forms.Label();
            this.labelValue = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPhotoBooth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownSlideshowInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownShootInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSaveFileThresholdMultiplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNewImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReference)).BeginInit();
            this.tabRandom.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboCamera
            // 
            this.cboCamera.Enabled = false;
            this.cboCamera.FormattingEnabled = true;
            this.cboCamera.Location = new System.Drawing.Point(184, 23);
            this.cboCamera.Name = "cboCamera";
            this.cboCamera.Size = new System.Drawing.Size(358, 21);
            this.cboCamera.TabIndex = 0;
            this.cboCamera.SelectedValueChanged += new System.EventHandler(this.cboCamera_SelectedValueChanged);
            // 
            // btnStartPhotoshoot
            // 
            this.btnStartPhotoshoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartPhotoshoot.Location = new System.Drawing.Point(564, 627);
            this.btnStartPhotoshoot.Name = "btnStartPhotoshoot";
            this.btnStartPhotoshoot.Size = new System.Drawing.Size(151, 83);
            this.btnStartPhotoshoot.TabIndex = 1;
            this.btnStartPhotoshoot.Text = "&Start";
            this.btnStartPhotoshoot.UseVisualStyleBackColor = true;
            this.btnStartPhotoshoot.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick_Start);
            // 
            // picCamera
            // 
            this.picCamera.Location = new System.Drawing.Point(73, 52);
            this.picCamera.Name = "picCamera";
            this.picCamera.Size = new System.Drawing.Size(948, 529);
            this.picCamera.TabIndex = 2;
            this.picCamera.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPhotoBooth);
            this.tabControl1.Controls.Add(this.tabRandom);
            this.tabControl1.Location = new System.Drawing.Point(11, 24);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1646, 785);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPhotoBooth
            // 
            this.tabPhotoBooth.Controls.Add(this.button1);
            this.tabPhotoBooth.Controls.Add(this.numUpDownSlideshowInterval);
            this.tabPhotoBooth.Controls.Add(this.numUpDownShootInterval);
            this.tabPhotoBooth.Controls.Add(this.label1);
            this.tabPhotoBooth.Controls.Add(this.lblShootInterval);
            this.tabPhotoBooth.Controls.Add(this.btnLiveView);
            this.tabPhotoBooth.Controls.Add(this.btnOpenSlideshowUI);
            this.tabPhotoBooth.Controls.Add(this.btnOpenCountDownUI);
            this.tabPhotoBooth.Controls.Add(this.lblSavedToFile);
            this.tabPhotoBooth.Controls.Add(this.lblTrackBarFileSave);
            this.tabPhotoBooth.Controls.Add(this.trackBarSaveFileThresholdMultiplier);
            this.tabPhotoBooth.Controls.Add(this.lblDiffPercentage);
            this.tabPhotoBooth.Controls.Add(this.lblNewImage);
            this.tabPhotoBooth.Controls.Add(this.picNewImage);
            this.tabPhotoBooth.Controls.Add(this.btnGetCameras);
            this.tabPhotoBooth.Controls.Add(this.labelReference);
            this.tabPhotoBooth.Controls.Add(this.picReference);
            this.tabPhotoBooth.Controls.Add(this.lblRefImageNotifier);
            this.tabPhotoBooth.Controls.Add(this.lblRefImageCountdown);
            this.tabPhotoBooth.Controls.Add(this.picCamera);
            this.tabPhotoBooth.Controls.Add(this.cboCamera);
            this.tabPhotoBooth.Controls.Add(this.btnStartPhotoshoot);
            this.tabPhotoBooth.Location = new System.Drawing.Point(4, 22);
            this.tabPhotoBooth.Margin = new System.Windows.Forms.Padding(2);
            this.tabPhotoBooth.Name = "tabPhotoBooth";
            this.tabPhotoBooth.Padding = new System.Windows.Forms.Padding(2);
            this.tabPhotoBooth.Size = new System.Drawing.Size(1638, 759);
            this.tabPhotoBooth.TabIndex = 1;
            this.tabPhotoBooth.Text = "Photo booth";
            this.tabPhotoBooth.UseVisualStyleBackColor = true;
            // 
            // numUpDownSlideshowInterval
            // 
            this.numUpDownSlideshowInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numUpDownSlideshowInterval.Location = new System.Drawing.Point(1313, 633);
            this.numUpDownSlideshowInterval.Name = "numUpDownSlideshowInterval";
            this.numUpDownSlideshowInterval.Size = new System.Drawing.Size(59, 29);
            this.numUpDownSlideshowInterval.TabIndex = 21;
            // 
            // numUpDownShootInterval
            // 
            this.numUpDownShootInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numUpDownShootInterval.Location = new System.Drawing.Point(1251, 603);
            this.numUpDownShootInterval.Maximum = new decimal(new int[] {
            3599,
            0,
            0,
            0});
            this.numUpDownShootInterval.Name = "numUpDownShootInterval";
            this.numUpDownShootInterval.Size = new System.Drawing.Size(87, 29);
            this.numUpDownShootInterval.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1035, 635);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "Slideshow interval secs:";
            // 
            // lblShootInterval
            // 
            this.lblShootInterval.AutoSize = true;
            this.lblShootInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShootInterval.Location = new System.Drawing.Point(1035, 602);
            this.lblShootInterval.Name = "lblShootInterval";
            this.lblShootInterval.Size = new System.Drawing.Size(172, 24);
            this.lblShootInterval.TabIndex = 18;
            this.lblShootInterval.Text = "Shoot interval secs:";
            // 
            // btnLiveView
            // 
            this.btnLiveView.Enabled = false;
            this.btnLiveView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLiveView.Location = new System.Drawing.Point(548, 18);
            this.btnLiveView.Name = "btnLiveView";
            this.btnLiveView.Size = new System.Drawing.Size(99, 31);
            this.btnLiveView.TabIndex = 17;
            this.btnLiveView.Text = "Live View";
            this.btnLiveView.UseVisualStyleBackColor = true;
            this.btnLiveView.Click += new System.EventHandler(this.btnLiveView_Click);
            // 
            // btnOpenSlideshowUI
            // 
            this.btnOpenSlideshowUI.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenSlideshowUI.Location = new System.Drawing.Point(745, 676);
            this.btnOpenSlideshowUI.Name = "btnOpenSlideshowUI";
            this.btnOpenSlideshowUI.Size = new System.Drawing.Size(163, 74);
            this.btnOpenSlideshowUI.TabIndex = 16;
            this.btnOpenSlideshowUI.Text = "Slideshow";
            this.btnOpenSlideshowUI.UseVisualStyleBackColor = true;
            this.btnOpenSlideshowUI.Click += new System.EventHandler(this.btnOpenSlideshowUI_Click);
            // 
            // btnOpenCountDownUI
            // 
            this.btnOpenCountDownUI.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenCountDownUI.Location = new System.Drawing.Point(745, 591);
            this.btnOpenCountDownUI.Name = "btnOpenCountDownUI";
            this.btnOpenCountDownUI.Size = new System.Drawing.Size(163, 79);
            this.btnOpenCountDownUI.TabIndex = 15;
            this.btnOpenCountDownUI.Text = "Countdown";
            this.btnOpenCountDownUI.UseVisualStyleBackColor = true;
            this.btnOpenCountDownUI.Click += new System.EventHandler(this.btnOpenCountDownUI_Click);
            // 
            // lblSavedToFile
            // 
            this.lblSavedToFile.AutoSize = true;
            this.lblSavedToFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSavedToFile.Location = new System.Drawing.Point(1451, 406);
            this.lblSavedToFile.Name = "lblSavedToFile";
            this.lblSavedToFile.Size = new System.Drawing.Size(171, 31);
            this.lblSavedToFile.TabIndex = 14;
            this.lblSavedToFile.Text = "Saved to file!";
            // 
            // lblTrackBarFileSave
            // 
            this.lblTrackBarFileSave.AutoSize = true;
            this.lblTrackBarFileSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrackBarFileSave.Location = new System.Drawing.Point(1035, 722);
            this.lblTrackBarFileSave.Name = "lblTrackBarFileSave";
            this.lblTrackBarFileSave.Size = new System.Drawing.Size(416, 24);
            this.lblTrackBarFileSave.TabIndex = 13;
            this.lblTrackBarFileSave.Text = "Change percentage required to save new image";
            // 
            // trackBarSaveFileThresholdMultiplier
            // 
            this.trackBarSaveFileThresholdMultiplier.Location = new System.Drawing.Point(1039, 676);
            this.trackBarSaveFileThresholdMultiplier.Maximum = 1000;
            this.trackBarSaveFileThresholdMultiplier.Minimum = 1;
            this.trackBarSaveFileThresholdMultiplier.Name = "trackBarSaveFileThresholdMultiplier";
            this.trackBarSaveFileThresholdMultiplier.Size = new System.Drawing.Size(394, 45);
            this.trackBarSaveFileThresholdMultiplier.TabIndex = 12;
            this.trackBarSaveFileThresholdMultiplier.Value = 1;
            this.trackBarSaveFileThresholdMultiplier.Scroll += new System.EventHandler(this.trackBarSaveFileThreshold_Scroll);
            // 
            // lblDiffPercentage
            // 
            this.lblDiffPercentage.AutoSize = true;
            this.lblDiffPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiffPercentage.Location = new System.Drawing.Point(1460, 267);
            this.lblDiffPercentage.Name = "lblDiffPercentage";
            this.lblDiffPercentage.Size = new System.Drawing.Size(147, 31);
            this.lblDiffPercentage.TabIndex = 11;
            this.lblDiffPercentage.Text = "Difference:";
            // 
            // lblNewImage
            // 
            this.lblNewImage.AutoSize = true;
            this.lblNewImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewImage.Location = new System.Drawing.Point(1187, 307);
            this.lblNewImage.Name = "lblNewImage";
            this.lblNewImage.Size = new System.Drawing.Size(109, 25);
            this.lblNewImage.TabIndex = 10;
            this.lblNewImage.Text = "New image";
            // 
            // picNewImage
            // 
            this.picNewImage.Location = new System.Drawing.Point(1039, 335);
            this.picNewImage.Name = "picNewImage";
            this.picNewImage.Size = new System.Drawing.Size(397, 246);
            this.picNewImage.TabIndex = 9;
            this.picNewImage.TabStop = false;
            // 
            // btnGetCameras
            // 
            this.btnGetCameras.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetCameras.Location = new System.Drawing.Point(73, 17);
            this.btnGetCameras.Name = "btnGetCameras";
            this.btnGetCameras.Size = new System.Drawing.Size(105, 29);
            this.btnGetCameras.TabIndex = 8;
            this.btnGetCameras.Text = "Get cameras";
            this.btnGetCameras.UseVisualStyleBackColor = true;
            this.btnGetCameras.Click += new System.EventHandler(this.btnGetCameras_Click);
            // 
            // labelReference
            // 
            this.labelReference.AutoSize = true;
            this.labelReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReference.Location = new System.Drawing.Point(1187, 24);
            this.labelReference.Name = "labelReference";
            this.labelReference.Size = new System.Drawing.Size(101, 25);
            this.labelReference.TabIndex = 7;
            this.labelReference.Text = "Reference";
            // 
            // picReference
            // 
            this.picReference.Location = new System.Drawing.Point(1039, 52);
            this.picReference.Name = "picReference";
            this.picReference.Size = new System.Drawing.Size(397, 246);
            this.picReference.TabIndex = 6;
            this.picReference.TabStop = false;
            // 
            // lblRefImageNotifier
            // 
            this.lblRefImageNotifier.AutoSize = true;
            this.lblRefImageNotifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefImageNotifier.Location = new System.Drawing.Point(36, 653);
            this.lblRefImageNotifier.Name = "lblRefImageNotifier";
            this.lblRefImageNotifier.Size = new System.Drawing.Size(255, 31);
            this.lblRefImageNotifier.TabIndex = 5;
            this.lblRefImageNotifier.Text = "Saving reference in:";
            // 
            // lblRefImageCountdown
            // 
            this.lblRefImageCountdown.AutoSize = true;
            this.lblRefImageCountdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 90F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefImageCountdown.Location = new System.Drawing.Point(300, 602);
            this.lblRefImageCountdown.Name = "lblRefImageCountdown";
            this.lblRefImageCountdown.Size = new System.Drawing.Size(0, 135);
            this.lblRefImageCountdown.TabIndex = 4;
            // 
            // tabRandom
            // 
            this.tabRandom.Controls.Add(this.labelZerosTotal);
            this.tabRandom.Controls.Add(this.labelOnesTotal);
            this.tabRandom.Controls.Add(this.label3);
            this.tabRandom.Controls.Add(this.label2);
            this.tabRandom.Controls.Add(this.btnRandomStartStop);
            this.tabRandom.Controls.Add(this.labelZerosPercentages);
            this.tabRandom.Controls.Add(this.labelOnesPercentage);
            this.tabRandom.Controls.Add(this.labelOnes);
            this.tabRandom.Controls.Add(this.labelZeros);
            this.tabRandom.Controls.Add(this.labelValue);
            this.tabRandom.Location = new System.Drawing.Point(4, 22);
            this.tabRandom.Name = "tabRandom";
            this.tabRandom.Size = new System.Drawing.Size(1638, 759);
            this.tabRandom.TabIndex = 2;
            this.tabRandom.Text = "Random number generator";
            this.tabRandom.UseVisualStyleBackColor = true;
            // 
            // labelZerosTotal
            // 
            this.labelZerosTotal.AutoSize = true;
            this.labelZerosTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelZerosTotal.Location = new System.Drawing.Point(584, 308);
            this.labelZerosTotal.Name = "labelZerosTotal";
            this.labelZerosTotal.Size = new System.Drawing.Size(140, 153);
            this.labelZerosTotal.TabIndex = 9;
            this.labelZerosTotal.Text = "0";
            // 
            // labelOnesTotal
            // 
            this.labelOnesTotal.AutoSize = true;
            this.labelOnesTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOnesTotal.Location = new System.Drawing.Point(584, 155);
            this.labelOnesTotal.Name = "labelOnesTotal";
            this.labelOnesTotal.Size = new System.Drawing.Size(140, 153);
            this.labelOnesTotal.TabIndex = 8;
            this.labelOnesTotal.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(641, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 31);
            this.label3.TabIndex = 7;
            this.label3.Text = "Total:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(991, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 31);
            this.label2.TabIndex = 6;
            this.label2.Text = "Percentages:";
            // 
            // btnRandomStartStop
            // 
            this.btnRandomStartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandomStartStop.Location = new System.Drawing.Point(574, 550);
            this.btnRandomStartStop.Name = "btnRandomStartStop";
            this.btnRandomStartStop.Size = new System.Drawing.Size(253, 47);
            this.btnRandomStartStop.TabIndex = 5;
            this.btnRandomStartStop.Text = "Start";
            this.btnRandomStartStop.UseVisualStyleBackColor = true;
            this.btnRandomStartStop.Click += new System.EventHandler(this.btnRandomStartStop_Click);
            // 
            // labelZerosPercentages
            // 
            this.labelZerosPercentages.AutoSize = true;
            this.labelZerosPercentages.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelZerosPercentages.Location = new System.Drawing.Point(929, 308);
            this.labelZerosPercentages.Name = "labelZerosPercentages";
            this.labelZerosPercentages.Size = new System.Drawing.Size(140, 153);
            this.labelZerosPercentages.TabIndex = 4;
            this.labelZerosPercentages.Text = "0";
            // 
            // labelOnesPercentage
            // 
            this.labelOnesPercentage.AutoSize = true;
            this.labelOnesPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOnesPercentage.Location = new System.Drawing.Point(929, 155);
            this.labelOnesPercentage.Name = "labelOnesPercentage";
            this.labelOnesPercentage.Size = new System.Drawing.Size(140, 153);
            this.labelOnesPercentage.TabIndex = 3;
            this.labelOnesPercentage.Text = "0";
            // 
            // labelOnes
            // 
            this.labelOnes.AutoSize = true;
            this.labelOnes.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOnes.Location = new System.Drawing.Point(352, 153);
            this.labelOnes.Name = "labelOnes";
            this.labelOnes.Size = new System.Drawing.Size(177, 153);
            this.labelOnes.TabIndex = 2;
            this.labelOnes.Text = "1:";
            // 
            // labelZeros
            // 
            this.labelZeros.AutoSize = true;
            this.labelZeros.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelZeros.Location = new System.Drawing.Point(352, 306);
            this.labelZeros.Name = "labelZeros";
            this.labelZeros.Size = new System.Drawing.Size(177, 153);
            this.labelZeros.TabIndex = 1;
            this.labelZeros.Text = "0:";
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 300F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValue.Location = new System.Drawing.Point(3, 72);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(412, 453);
            this.labelValue.TabIndex = 0;
            this.labelValue.Text = "#";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(1503, 641);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 80);
            this.button1.TabIndex = 22;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SpiritLabForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1668, 814);
            this.Controls.Add(this.tabControl1);
            this.Name = "SpiritLabForm";
            this.Text = "Spirit Lab";
            this.Deactivate += new System.EventHandler(this.SpiritLabForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpiritLabForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPhotoBooth.ResumeLayout(false);
            this.tabPhotoBooth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownSlideshowInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownShootInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSaveFileThresholdMultiplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNewImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReference)).EndInit();
            this.tabRandom.ResumeLayout(false);
            this.tabRandom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCamera;
        private System.Windows.Forms.Button btnStartPhotoshoot;
        private System.Windows.Forms.PictureBox picCamera;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPhotoBooth;
        private System.Windows.Forms.TabPage tabRandom;
        private System.Windows.Forms.Label labelZerosPercentages;
        private System.Windows.Forms.Label labelOnesPercentage;
        private System.Windows.Forms.Label labelOnes;
        private System.Windows.Forms.Label labelZeros;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.Button btnRandomStartStop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelZerosTotal;
        private System.Windows.Forms.Label labelOnesTotal;
        private System.Windows.Forms.Label labelReference;
        private System.Windows.Forms.PictureBox picReference;
        private System.Windows.Forms.Label lblRefImageNotifier;
        private System.Windows.Forms.Label lblRefImageCountdown;
        private System.Windows.Forms.Button btnGetCameras;
        private System.Windows.Forms.Label lblNewImage;
        private System.Windows.Forms.PictureBox picNewImage;
        private System.Windows.Forms.Label lblDiffPercentage;
        private System.Windows.Forms.TrackBar trackBarSaveFileThresholdMultiplier;
        private System.Windows.Forms.Label lblTrackBarFileSave;
        private System.Windows.Forms.Label lblSavedToFile;
        private System.Windows.Forms.Button btnOpenCountDownUI;
        private System.Windows.Forms.Button btnOpenSlideshowUI;
        private System.Windows.Forms.Button btnLiveView;
        private System.Windows.Forms.Label lblShootInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numUpDownSlideshowInterval;
        private System.Windows.Forms.NumericUpDown numUpDownShootInterval;
        private System.Windows.Forms.Button button1;
    }
}

