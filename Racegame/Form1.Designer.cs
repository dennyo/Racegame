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
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.FuelBox = new System.Windows.Forms.PictureBox();
            this.HealthBox = new System.Windows.Forms.PictureBox();
            this.ItemBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Groen = new System.Windows.Forms.PictureBox();
            this.Checkpoint = new System.Windows.Forms.PictureBox();
            this.Finish = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Auto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuelBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Groen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Checkpoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Finish)).BeginInit();
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
            // HealthBox
            // 
            this.HealthBox.BackColor = System.Drawing.Color.Red;
            this.HealthBox.Location = new System.Drawing.Point(12, 12);
            this.HealthBox.Name = "HealthBox";
            this.HealthBox.Size = new System.Drawing.Size(200, 10);
            this.HealthBox.TabIndex = 2;
            this.HealthBox.TabStop = false;
            // ItemBox
            // 
            this.ItemBox.BackColor = System.Drawing.Color.Yellow;
            this.ItemBox.Location = new System.Drawing.Point(278, 416);
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
            // Groen
            // 
            this.Groen.BackColor = System.Drawing.Color.Black;
            this.Groen.Location = new System.Drawing.Point(662, 93);
            this.Groen.Name = "Groen";
            this.Groen.Size = new System.Drawing.Size(291, 162);
            this.Groen.TabIndex = 6;
            this.Groen.TabStop = false;
            // 
            // Checkpoint
            // 
            this.Checkpoint.Location = new System.Drawing.Point(429, -3);
            this.Checkpoint.Name = "Checkpoint";
            this.Checkpoint.Size = new System.Drawing.Size(100, 197);
            this.Checkpoint.TabIndex = 7;
            this.Checkpoint.TabStop = false;
            this.Checkpoint.Visible = false;
            // 
            // Finish
            // 
            this.Finish.Location = new System.Drawing.Point(458, 310);
            this.Finish.Name = "Finish";
            this.Finish.Size = new System.Drawing.Size(45, 180);
            this.Finish.TabIndex = 8;
            this.Finish.TabStop = false;
            this.Finish.Visible = false;
            // 
            // Racegame
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.FuelBox);
            this.Controls.Add(this.HealthBox);
            this.DoubleBuffered = true;
            this.ClientSize = new System.Drawing.Size(1002, 712);
            this.Controls.Add(this.Finish);
            this.Controls.Add(this.Checkpoint);
            this.Controls.Add(this.Groen);
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
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Racegame_Paint);
            this.TransparencyKey = System.Drawing.Color.Maroon;
            ((System.ComponentModel.ISupportInitialize)(this.Auto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuelBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Groen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Checkpoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Finish)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.PictureBox FuelBox;
        private System.Windows.Forms.PictureBox HealthBox;
        private System.Windows.Forms.PictureBox ItemBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox Groen;
        private System.Windows.Forms.PictureBox Checkpoint;
        private System.Windows.Forms.PictureBox Finish;
    }
}

