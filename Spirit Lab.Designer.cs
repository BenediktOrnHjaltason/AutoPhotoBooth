
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
            this.labelEmf = new System.Windows.Forms.Label();
            this.tabPhotoshoot = new System.Windows.Forms.TabPage();
            this.tabRandom = new System.Windows.Forms.TabPage();
            this.labelValue = new System.Windows.Forms.Label();
            this.labelZeros = new System.Windows.Forms.Label();
            this.labelOnes = new System.Windows.Forms.Label();
            this.labelOnesOccurences = new System.Windows.Forms.Label();
            this.labelZerosOccurenses = new System.Windows.Forms.Label();
            this.btnRandomStartStop = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabKeyboard.SuspendLayout();
            this.tabPhotoshoot.SuspendLayout();
            this.tabRandom.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboCamera
            // 
            this.cboCamera.FormattingEnabled = true;
            this.cboCamera.Location = new System.Drawing.Point(54, 31);
            this.cboCamera.Name = "cboCamera";
            this.cboCamera.Size = new System.Drawing.Size(253, 21);
            this.cboCamera.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(879, 592);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(123, 32);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick_Start);
            // 
            // picCamera
            // 
            this.picCamera.Location = new System.Drawing.Point(54, 57);
            this.picCamera.Name = "picCamera";
            this.picCamera.Size = new System.Drawing.Size(948, 529);
            this.picCamera.TabIndex = 2;
            this.picCamera.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Camera";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabKeyboard);
            this.tabControl1.Controls.Add(this.tabPhotoshoot);
            this.tabControl1.Controls.Add(this.tabRandom);
            this.tabControl1.Location = new System.Drawing.Point(31, 24);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1052, 653);
            this.tabControl1.TabIndex = 4;
            // 
            // tabKeyboard
            // 
            this.tabKeyboard.Controls.Add(this.labelEmf);
            this.tabKeyboard.Location = new System.Drawing.Point(4, 22);
            this.tabKeyboard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabKeyboard.Name = "tabKeyboard";
            this.tabKeyboard.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabKeyboard.Size = new System.Drawing.Size(1044, 627);
            this.tabKeyboard.TabIndex = 0;
            this.tabKeyboard.Text = "Keyboard";
            this.tabKeyboard.UseVisualStyleBackColor = true;
            // 
            // labelEmf
            // 
            this.labelEmf.AutoSize = true;
            this.labelEmf.Font = new System.Drawing.Font("Microsoft Sans Serif", 150.6F);
            this.labelEmf.Location = new System.Drawing.Point(293, 189);
            this.labelEmf.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEmf.Name = "labelEmf";
            this.labelEmf.Size = new System.Drawing.Size(519, 227);
            this.labelEmf.TabIndex = 0;
            this.labelEmf.Text = "EMF";
            // 
            // tabPhotoshoot
            // 
            this.tabPhotoshoot.Controls.Add(this.picCamera);
            this.tabPhotoshoot.Controls.Add(this.label1);
            this.tabPhotoshoot.Controls.Add(this.cboCamera);
            this.tabPhotoshoot.Controls.Add(this.btnStart);
            this.tabPhotoshoot.Location = new System.Drawing.Point(4, 22);
            this.tabPhotoshoot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPhotoshoot.Name = "tabPhotoshoot";
            this.tabPhotoshoot.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPhotoshoot.Size = new System.Drawing.Size(1044, 627);
            this.tabPhotoshoot.TabIndex = 1;
            this.tabPhotoshoot.Text = "Photoshoot";
            this.tabPhotoshoot.UseVisualStyleBackColor = true;
            // 
            // tabRandom
            // 
            this.tabRandom.Controls.Add(this.label2);
            this.tabRandom.Controls.Add(this.btnRandomStartStop);
            this.tabRandom.Controls.Add(this.labelZerosOccurenses);
            this.tabRandom.Controls.Add(this.labelOnesOccurences);
            this.tabRandom.Controls.Add(this.labelOnes);
            this.tabRandom.Controls.Add(this.labelZeros);
            this.tabRandom.Controls.Add(this.labelValue);
            this.tabRandom.Location = new System.Drawing.Point(4, 22);
            this.tabRandom.Name = "tabRandom";
            this.tabRandom.Size = new System.Drawing.Size(1044, 627);
            this.tabRandom.TabIndex = 2;
            this.tabRandom.Text = "Random number generator";
            this.tabRandom.UseVisualStyleBackColor = true;
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 300F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValue.Location = new System.Drawing.Point(61, 74);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(412, 453);
            this.labelValue.TabIndex = 0;
            this.labelValue.Text = "#";
            // 
            // labelZeros
            // 
            this.labelZeros.AutoSize = true;
            this.labelZeros.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelZeros.Location = new System.Drawing.Point(530, 308);
            this.labelZeros.Name = "labelZeros";
            this.labelZeros.Size = new System.Drawing.Size(177, 153);
            this.labelZeros.TabIndex = 1;
            this.labelZeros.Text = "0:";
            // 
            // labelOnes
            // 
            this.labelOnes.AutoSize = true;
            this.labelOnes.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOnes.Location = new System.Drawing.Point(530, 155);
            this.labelOnes.Name = "labelOnes";
            this.labelOnes.Size = new System.Drawing.Size(177, 153);
            this.labelOnes.TabIndex = 2;
            this.labelOnes.Text = "1:";
            // 
            // labelOnesOccurences
            // 
            this.labelOnesOccurences.AutoSize = true;
            this.labelOnesOccurences.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOnesOccurences.Location = new System.Drawing.Point(731, 155);
            this.labelOnesOccurences.Name = "labelOnesOccurences";
            this.labelOnesOccurences.Size = new System.Drawing.Size(140, 153);
            this.labelOnesOccurences.TabIndex = 3;
            this.labelOnesOccurences.Text = "0";
            // 
            // labelZerosOccurenses
            // 
            this.labelZerosOccurenses.AutoSize = true;
            this.labelZerosOccurenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelZerosOccurenses.Location = new System.Drawing.Point(731, 308);
            this.labelZerosOccurenses.Name = "labelZerosOccurenses";
            this.labelZerosOccurenses.Size = new System.Drawing.Size(140, 153);
            this.labelZerosOccurenses.TabIndex = 4;
            this.labelZerosOccurenses.Text = "0";
            // 
            // btnRandomStartStop
            // 
            this.btnRandomStartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandomStartStop.Location = new System.Drawing.Point(382, 546);
            this.btnRandomStartStop.Name = "btnRandomStartStop";
            this.btnRandomStartStop.Size = new System.Drawing.Size(253, 47);
            this.btnRandomStartStop.TabIndex = 5;
            this.btnRandomStartStop.Text = "Start";
            this.btnRandomStartStop.UseVisualStyleBackColor = true;
            this.btnRandomStartStop.Click += new System.EventHandler(this.btnRandomStartStop_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(624, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 31);
            this.label2.TabIndex = 6;
            this.label2.Text = "100 siste tall:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 727);
            this.Controls.Add(this.tabControl1);
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
            this.tabRandom.ResumeLayout(false);
            this.tabRandom.PerformLayout();
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
        private System.Windows.Forms.TabPage tabRandom;
        private System.Windows.Forms.Label labelZerosOccurenses;
        private System.Windows.Forms.Label labelOnesOccurences;
        private System.Windows.Forms.Label labelOnes;
        private System.Windows.Forms.Label labelZeros;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.Button btnRandomStartStop;
        private System.Windows.Forms.Label label2;
    }
}

