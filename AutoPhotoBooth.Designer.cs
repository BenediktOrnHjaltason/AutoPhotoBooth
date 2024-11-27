
namespace AutoPhotoBooth
{
    partial class AutoPhotoBoothForm
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
            this.components = new System.ComponentModel.Container();
            this.cboCamera = new System.Windows.Forms.ComboBox();
            this.btnStartPhotoshoot = new System.Windows.Forms.Button();
            this.picCamera = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPhotoBooth = new System.Windows.Forms.TabPage();
            this.settingsButton = new System.Windows.Forms.Button();
            this.btnLiveView = new System.Windows.Forms.Button();
            this.btnOpenSlideshowUI = new System.Windows.Forms.Button();
            this.btnOpenCountDownUI = new System.Windows.Forms.Button();
            this.lblSavedToFile = new System.Windows.Forms.Label();
            this.lblDiffPercentage = new System.Windows.Forms.Label();
            this.lblNewImage = new System.Windows.Forms.Label();
            this.picNewImage = new System.Windows.Forms.PictureBox();
            this.btnGetCameras = new System.Windows.Forms.Button();
            this.labelReference = new System.Windows.Forms.Label();
            this.picReference = new System.Windows.Forms.PictureBox();
            this.lblRefImageNotifier = new System.Windows.Forms.Label();
            this.lblRefImageCountdown = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPhotoBooth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNewImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboCamera
            // 
            this.cboCamera.Enabled = false;
            this.cboCamera.FormattingEnabled = true;
            this.cboCamera.Location = new System.Drawing.Point(245, 28);
            this.cboCamera.Margin = new System.Windows.Forms.Padding(4);
            this.cboCamera.Name = "cboCamera";
            this.cboCamera.Size = new System.Drawing.Size(476, 24);
            this.cboCamera.TabIndex = 0;
            this.cboCamera.SelectedValueChanged += new System.EventHandler(this.cboCamera_SelectedValueChanged);
            // 
            // btnStartPhotoshoot
            // 
            this.btnStartPhotoshoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartPhotoshoot.Location = new System.Drawing.Point(752, 772);
            this.btnStartPhotoshoot.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartPhotoshoot.Name = "btnStartPhotoshoot";
            this.btnStartPhotoshoot.Size = new System.Drawing.Size(201, 102);
            this.btnStartPhotoshoot.TabIndex = 1;
            this.btnStartPhotoshoot.Text = "&Start";
            this.btnStartPhotoshoot.UseVisualStyleBackColor = true;
            this.btnStartPhotoshoot.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick_Start);
            // 
            // picCamera
            // 
            this.picCamera.Location = new System.Drawing.Point(97, 64);
            this.picCamera.Margin = new System.Windows.Forms.Padding(4);
            this.picCamera.Name = "picCamera";
            this.picCamera.Size = new System.Drawing.Size(1264, 651);
            this.picCamera.TabIndex = 2;
            this.picCamera.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPhotoBooth);
            this.tabControl1.Location = new System.Drawing.Point(15, 30);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2195, 966);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPhotoBooth
            // 
            this.tabPhotoBooth.Controls.Add(this.settingsButton);
            this.tabPhotoBooth.Controls.Add(this.btnLiveView);
            this.tabPhotoBooth.Controls.Add(this.btnOpenSlideshowUI);
            this.tabPhotoBooth.Controls.Add(this.btnOpenCountDownUI);
            this.tabPhotoBooth.Controls.Add(this.lblSavedToFile);
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
            this.tabPhotoBooth.Location = new System.Drawing.Point(4, 25);
            this.tabPhotoBooth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPhotoBooth.Name = "tabPhotoBooth";
            this.tabPhotoBooth.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPhotoBooth.Size = new System.Drawing.Size(2187, 937);
            this.tabPhotoBooth.TabIndex = 1;
            this.tabPhotoBooth.Text = "Photo booth";
            this.tabPhotoBooth.UseVisualStyleBackColor = true;
            // 
            // settingsButton
            // 
            this.settingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsButton.Location = new System.Drawing.Point(1304, 769);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(142, 123);
            this.settingsButton.TabIndex = 18;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // btnLiveView
            // 
            this.btnLiveView.Enabled = false;
            this.btnLiveView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLiveView.Location = new System.Drawing.Point(731, 22);
            this.btnLiveView.Margin = new System.Windows.Forms.Padding(4);
            this.btnLiveView.Name = "btnLiveView";
            this.btnLiveView.Size = new System.Drawing.Size(132, 38);
            this.btnLiveView.TabIndex = 17;
            this.btnLiveView.Text = "Live View";
            this.btnLiveView.UseVisualStyleBackColor = true;
            this.btnLiveView.Click += new System.EventHandler(this.btnLiveView_Click);
            // 
            // btnOpenSlideshowUI
            // 
            this.btnOpenSlideshowUI.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenSlideshowUI.Location = new System.Drawing.Point(993, 832);
            this.btnOpenSlideshowUI.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenSlideshowUI.Name = "btnOpenSlideshowUI";
            this.btnOpenSlideshowUI.Size = new System.Drawing.Size(217, 91);
            this.btnOpenSlideshowUI.TabIndex = 16;
            this.btnOpenSlideshowUI.Text = "Slideshow";
            this.btnOpenSlideshowUI.UseVisualStyleBackColor = true;
            this.btnOpenSlideshowUI.Click += new System.EventHandler(this.btnOpenSlideshowUI_Click);
            // 
            // btnOpenCountDownUI
            // 
            this.btnOpenCountDownUI.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenCountDownUI.Location = new System.Drawing.Point(993, 727);
            this.btnOpenCountDownUI.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenCountDownUI.Name = "btnOpenCountDownUI";
            this.btnOpenCountDownUI.Size = new System.Drawing.Size(217, 97);
            this.btnOpenCountDownUI.TabIndex = 15;
            this.btnOpenCountDownUI.Text = "Countdown";
            this.btnOpenCountDownUI.UseVisualStyleBackColor = true;
            this.btnOpenCountDownUI.Click += new System.EventHandler(this.btnOpenCountDownUI_Click);
            // 
            // lblSavedToFile
            // 
            this.lblSavedToFile.AutoSize = true;
            this.lblSavedToFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSavedToFile.Location = new System.Drawing.Point(1935, 500);
            this.lblSavedToFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSavedToFile.Name = "lblSavedToFile";
            this.lblSavedToFile.Size = new System.Drawing.Size(213, 39);
            this.lblSavedToFile.TabIndex = 14;
            this.lblSavedToFile.Text = "Saved to file!";
            // 
            // lblDiffPercentage
            // 
            this.lblDiffPercentage.AutoSize = true;
            this.lblDiffPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiffPercentage.Location = new System.Drawing.Point(1947, 329);
            this.lblDiffPercentage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiffPercentage.Name = "lblDiffPercentage";
            this.lblDiffPercentage.Size = new System.Drawing.Size(181, 39);
            this.lblDiffPercentage.TabIndex = 11;
            this.lblDiffPercentage.Text = "Difference:";
            // 
            // lblNewImage
            // 
            this.lblNewImage.AutoSize = true;
            this.lblNewImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewImage.Location = new System.Drawing.Point(1583, 378);
            this.lblNewImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewImage.Name = "lblNewImage";
            this.lblNewImage.Size = new System.Drawing.Size(140, 29);
            this.lblNewImage.TabIndex = 10;
            this.lblNewImage.Text = "New image";
            // 
            // picNewImage
            // 
            this.picNewImage.Location = new System.Drawing.Point(1385, 412);
            this.picNewImage.Margin = new System.Windows.Forms.Padding(4);
            this.picNewImage.Name = "picNewImage";
            this.picNewImage.Size = new System.Drawing.Size(529, 303);
            this.picNewImage.TabIndex = 9;
            this.picNewImage.TabStop = false;
            // 
            // btnGetCameras
            // 
            this.btnGetCameras.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetCameras.Location = new System.Drawing.Point(97, 21);
            this.btnGetCameras.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetCameras.Name = "btnGetCameras";
            this.btnGetCameras.Size = new System.Drawing.Size(140, 36);
            this.btnGetCameras.TabIndex = 8;
            this.btnGetCameras.Text = "Get cameras";
            this.btnGetCameras.UseVisualStyleBackColor = true;
            this.btnGetCameras.Click += new System.EventHandler(this.btnGetCameras_Click);
            // 
            // labelReference
            // 
            this.labelReference.AutoSize = true;
            this.labelReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReference.Location = new System.Drawing.Point(1583, 30);
            this.labelReference.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelReference.Name = "labelReference";
            this.labelReference.Size = new System.Drawing.Size(129, 29);
            this.labelReference.TabIndex = 7;
            this.labelReference.Text = "Reference";
            // 
            // picReference
            // 
            this.picReference.Location = new System.Drawing.Point(1385, 64);
            this.picReference.Margin = new System.Windows.Forms.Padding(4);
            this.picReference.Name = "picReference";
            this.picReference.Size = new System.Drawing.Size(529, 303);
            this.picReference.TabIndex = 6;
            this.picReference.TabStop = false;
            // 
            // lblRefImageNotifier
            // 
            this.lblRefImageNotifier.AutoSize = true;
            this.lblRefImageNotifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefImageNotifier.Location = new System.Drawing.Point(48, 804);
            this.lblRefImageNotifier.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRefImageNotifier.Name = "lblRefImageNotifier";
            this.lblRefImageNotifier.Size = new System.Drawing.Size(319, 39);
            this.lblRefImageNotifier.TabIndex = 5;
            this.lblRefImageNotifier.Text = "Saving reference in:";
            // 
            // lblRefImageCountdown
            // 
            this.lblRefImageCountdown.AutoSize = true;
            this.lblRefImageCountdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 90F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefImageCountdown.Location = new System.Drawing.Point(400, 741);
            this.lblRefImageCountdown.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRefImageCountdown.Name = "lblRefImageCountdown";
            this.lblRefImageCountdown.Size = new System.Drawing.Size(0, 170);
            this.lblRefImageCountdown.TabIndex = 4;
            // 
            // AutoPhotoBoothForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2224, 1002);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AutoPhotoBoothForm";
            this.Text = "Auto Photo Booth";
            this.Deactivate += new System.EventHandler(this.AutoPhotoBoothForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoPhotoBoothForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPhotoBooth.ResumeLayout(false);
            this.tabPhotoBooth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNewImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCamera;
        private System.Windows.Forms.Button btnStartPhotoshoot;
        private System.Windows.Forms.PictureBox picCamera;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPhotoBooth;
        private System.Windows.Forms.Label labelReference;
        private System.Windows.Forms.PictureBox picReference;
        private System.Windows.Forms.Label lblRefImageNotifier;
        private System.Windows.Forms.Label lblRefImageCountdown;
        private System.Windows.Forms.Button btnGetCameras;
        private System.Windows.Forms.Label lblNewImage;
        private System.Windows.Forms.PictureBox picNewImage;
        private System.Windows.Forms.Label lblDiffPercentage;
        private System.Windows.Forms.Label lblSavedToFile;
        private System.Windows.Forms.Button btnOpenCountDownUI;
        private System.Windows.Forms.Button btnOpenSlideshowUI;
        private System.Windows.Forms.Button btnLiveView;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button settingsButton;
    }
}

