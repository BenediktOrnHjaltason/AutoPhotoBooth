
namespace Spirit_Studio
{
    partial class Form1
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
            this.cboCamera = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.picCamera = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabKeyboard = new System.Windows.Forms.TabPage();
            this.tabPhotoshoot = new System.Windows.Forms.TabPage();
            this.labelEmf = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabKeyboard.SuspendLayout();
            this.tabPhotoshoot.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboCamera
            // 
            this.cboCamera.FormattingEnabled = true;
            this.cboCamera.Location = new System.Drawing.Point(72, 38);
            this.cboCamera.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboCamera.Name = "cboCamera";
            this.cboCamera.Size = new System.Drawing.Size(336, 24);
            this.cboCamera.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(1172, 729);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(164, 39);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick_Start);
            // 
            // picCamera
            // 
            this.picCamera.Location = new System.Drawing.Point(72, 70);
            this.picCamera.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picCamera.Name = "picCamera";
            this.picCamera.Size = new System.Drawing.Size(1264, 651);
            this.picCamera.TabIndex = 2;
            this.picCamera.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Camera";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabKeyboard);
            this.tabControl1.Controls.Add(this.tabPhotoshoot);
            this.tabControl1.Location = new System.Drawing.Point(41, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1403, 804);
            this.tabControl1.TabIndex = 4;
            // 
            // tabKeyboard
            // 
            this.tabKeyboard.Controls.Add(this.labelEmf);
            this.tabKeyboard.Location = new System.Drawing.Point(4, 25);
            this.tabKeyboard.Name = "tabKeyboard";
            this.tabKeyboard.Padding = new System.Windows.Forms.Padding(3);
            this.tabKeyboard.Size = new System.Drawing.Size(1395, 775);
            this.tabKeyboard.TabIndex = 0;
            this.tabKeyboard.Text = "Keyboard";
            this.tabKeyboard.UseVisualStyleBackColor = true;
            // 
            // tabPhotoshoot
            // 
            this.tabPhotoshoot.Controls.Add(this.picCamera);
            this.tabPhotoshoot.Controls.Add(this.label1);
            this.tabPhotoshoot.Controls.Add(this.cboCamera);
            this.tabPhotoshoot.Controls.Add(this.btnStart);
            this.tabPhotoshoot.Location = new System.Drawing.Point(4, 25);
            this.tabPhotoshoot.Name = "tabPhotoshoot";
            this.tabPhotoshoot.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhotoshoot.Size = new System.Drawing.Size(1395, 775);
            this.tabPhotoshoot.TabIndex = 1;
            this.tabPhotoshoot.Text = "Photoshoot";
            this.tabPhotoshoot.UseVisualStyleBackColor = true;
            // 
            // labelEmf
            // 
            this.labelEmf.AutoSize = true;
            this.labelEmf.Font = new System.Drawing.Font("Microsoft Sans Serif", 150.6F);
            this.labelEmf.Location = new System.Drawing.Point(391, 233);
            this.labelEmf.Name = "labelEmf";
            this.labelEmf.Size = new System.Drawing.Size(652, 286);
            this.labelEmf.TabIndex = 0;
            this.labelEmf.Text = "EMF";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1490, 895);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabKeyboard.ResumeLayout(false);
            this.tabKeyboard.PerformLayout();
            this.tabPhotoshoot.ResumeLayout(false);
            this.tabPhotoshoot.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCamera;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox picCamera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabKeyboard;
        private System.Windows.Forms.TabPage tabPhotoshoot;
        private System.Windows.Forms.Label labelEmf;
    }
}

