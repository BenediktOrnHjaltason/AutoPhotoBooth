
namespace SpiritLab.Forms
{
    partial class CountDown
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
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.lblCommunication = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.BackColor = System.Drawing.Color.Transparent;
            this.picDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picDisplay.Location = new System.Drawing.Point(0, 0);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(1422, 805);
            this.picDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            // 
            // lblCountdown
            // 
            this.lblCountdown.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCountdown.BackColor = System.Drawing.Color.Transparent;
            this.lblCountdown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblCountdown.Font = new System.Drawing.Font("Times New Roman", 360F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountdown.ForeColor = System.Drawing.Color.Green;
            this.lblCountdown.Location = new System.Drawing.Point(23, 54);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(1378, 864);
            this.lblCountdown.TabIndex = 1;
            this.lblCountdown.Text = "00:00";
            this.lblCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCommunication
            // 
            this.lblCommunication.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCommunication.AutoSize = true;
            this.lblCommunication.BackColor = System.Drawing.Color.Transparent;
            this.lblCommunication.Font = new System.Drawing.Font("Microsoft Sans Serif", 150F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommunication.ForeColor = System.Drawing.Color.Green;
            this.lblCommunication.Location = new System.Drawing.Point(534, 0);
            this.lblCommunication.Name = "lblCommunication";
            this.lblCommunication.Size = new System.Drawing.Size(0, 226);
            this.lblCommunication.TabIndex = 2;
            this.lblCommunication.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CountDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1422, 805);
            this.Controls.Add(this.lblCommunication);
            this.Controls.Add(this.lblCountdown);
            this.Controls.Add(this.picDisplay);
            this.Name = "CountDown";
            this.Text = "Countdown";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CountDownUI_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Label lblCountdown;
        private System.Windows.Forms.Label lblCommunication;
    }
}