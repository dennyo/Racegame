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
            this.Groen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Auto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuelBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Groen)).BeginInit();
            this.SuspendLayout();
            // 
            // Auto
            // 
            this.Auto.BackColor = System.Drawing.Color.Lime;
            this.Auto.Location = new System.Drawing.Point(445, 538);
            this.Auto.Name = "Auto";
            this.Auto.Size = new System.Drawing.Size(150, 100);
            this.Auto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
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
            this.ItemBox.Location = new System.Drawing.Point(278, 416);
            this.ItemBox.Name = "ItemBox";
            this.ItemBox.Size = new System.Drawing.Size(43, 41);
            this.ItemBox.TabIndex = 3;
            this.ItemBox.TabStop = false;
            // 
            // Groen
            // 
            this.Groen.BackColor = System.Drawing.Color.Black;
            this.Groen.Location = new System.Drawing.Point(662, 93);
            this.Groen.Name = "Groen";
            this.Groen.Size = new System.Drawing.Size(291, 162);
            this.Groen.TabIndex = 4;
            this.Groen.TabStop = false;
            // 
            // Racegame
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1002, 712);
            this.Controls.Add(this.Groen);
            this.Controls.Add(this.ItemBox);
            this.Controls.Add(this.FuelBox);
            this.Controls.Add(this.Auto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "Racegame";
            this.Text = "Racegame";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            ((System.ComponentModel.ISupportInitialize)(this.Auto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuelBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Groen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Auto;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.PictureBox FuelBox;
        private System.Windows.Forms.PictureBox ItemBox;
        private System.Windows.Forms.PictureBox Groen;
    }
}

