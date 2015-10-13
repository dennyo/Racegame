namespace Racegame
{
    partial class Racegame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Racegame));
            this.Auto = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.FuelBox = new System.Windows.Forms.PictureBox();
            this.ItemBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Auto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuelBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Auto
            // 
            this.Auto.BackColor = System.Drawing.Color.Lime;
            this.Auto.Location = new System.Drawing.Point(215, 104);
            this.Auto.Name = "Auto";
            this.Auto.Size = new System.Drawing.Size(81, 50);
            this.Auto.TabIndex = 0;
            this.Auto.TabStop = false;
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 17;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // FuelBox
            // 
            this.FuelBox.BackColor = System.Drawing.Color.Blue;
            this.FuelBox.Location = new System.Drawing.Point(12, 12);
            this.FuelBox.Name = "FuelBox";
            this.FuelBox.Size = new System.Drawing.Size(200, 10);
            this.FuelBox.TabIndex = 1;
            this.FuelBox.TabStop = false;
            // 
            // ItemBox
            // 
            this.ItemBox.BackColor = System.Drawing.Color.Yellow;
            this.ItemBox.Location = new System.Drawing.Point(528, 113);
            this.ItemBox.Name = "ItemBox";
            this.ItemBox.Size = new System.Drawing.Size(43, 41);
            this.ItemBox.TabIndex = 3;
            this.ItemBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(773, 577);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 50);
            this.label1.TabIndex = 4;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(773, 640);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 50);
            this.label2.TabIndex = 5;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Racegame
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1008, 712);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ItemBox);
            this.Controls.Add(this.FuelBox);
            this.Controls.Add(this.Auto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1024, 736);
            this.Name = "Racegame";
            this.Text = "Racegame";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            ((System.ComponentModel.ISupportInitialize)(this.Auto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuelBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Auto;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.PictureBox FuelBox;
        private System.Windows.Forms.PictureBox ItemBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

