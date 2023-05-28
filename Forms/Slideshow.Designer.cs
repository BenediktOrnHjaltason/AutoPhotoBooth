namespace SpiritLab.Forms
{
    partial class Slideshow
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
            this.lbCounter = new System.Windows.Forms.Label();
            this.pictureBoxSlideshow = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSlideshow)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCounter
            // 
            this.lbCounter.AutoSize = true;
            this.lbCounter.Font = new System.Drawing.Font("Marlett", 70F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCounter.ForeColor = System.Drawing.Color.LimeGreen;
            this.lbCounter.Location = new System.Drawing.Point(23, 21);
            this.lbCounter.Name = "lbCounter";
            this.lbCounter.Size = new System.Drawing.Size(227, 108);
            this.lbCounter.TabIndex = 0;
            this.lbCounter.Text = "0 / 0";
            // 
            // pictureBoxSlideshow
            // 
            this.pictureBoxSlideshow.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxSlideshow.Name = "pictureBoxSlideshow";
            this.pictureBoxSlideshow.Size = new System.Drawing.Size(1507, 798);
            this.pictureBoxSlideshow.TabIndex = 1;
            this.pictureBoxSlideshow.TabStop = false;
            // 
            // Slideshow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1541, 822);
            this.Controls.Add(this.lbCounter);
            this.Controls.Add(this.pictureBoxSlideshow);
            this.Name = "Slideshow";
            this.Text = "Slideshow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Slideshow_FormClosing);
            this.Load += new System.EventHandler(this.Slideshow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSlideshow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCounter;
        private System.Windows.Forms.PictureBox pictureBoxSlideshow;
    }
}