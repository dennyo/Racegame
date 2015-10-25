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
            this.ItemBox = new System.Windows.Forms.PictureBox();
            this.Speed2 = new System.Windows.Forms.Label();
            this.Fueladder = new System.Windows.Forms.Timer(this.components);
            this.Player1Box = new System.Windows.Forms.PictureBox();
            this.FuelBox2 = new System.Windows.Forms.PictureBox();
            this.Speed1 = new System.Windows.Forms.Label();
            this.Fueladder2 = new System.Windows.Forms.Timer(this.components);
            this.FinishMessage = new System.Windows.Forms.Label();
            this.PlayAgain = new System.Windows.Forms.Button();
            this.MainMenu = new System.Windows.Forms.Button();
            this.Interface = new System.Windows.Forms.PictureBox();
            this.Player2Box = new System.Windows.Forms.PictureBox();
            this.StartTimer = new System.Windows.Forms.Timer(this.components);
            this.PlayerControls = new System.Windows.Forms.PictureBox();
            this.Lakitu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FuelBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player1Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuelBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Interface)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player2Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerControls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lakitu)).BeginInit();
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 17;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // FuelBox
            // 
            this.FuelBox.BackColor = System.Drawing.Color.Lime;
            this.FuelBox.Location = new System.Drawing.Point(726, 31);
            this.FuelBox.Name = "FuelBox";
            this.FuelBox.Size = new System.Drawing.Size(76, 18);
            this.FuelBox.TabIndex = 1;
            this.FuelBox.TabStop = false;
            // 
            // ItemBox
            // 
            this.ItemBox.BackColor = System.Drawing.Color.Yellow;
            this.ItemBox.Location = new System.Drawing.Point(94, 153);
            this.ItemBox.Name = "ItemBox";
            this.ItemBox.Size = new System.Drawing.Size(43, 41);
            this.ItemBox.TabIndex = 3;
            this.ItemBox.TabStop = false;
            // 
            // Speed2
            // 
            this.Speed2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(19)))), ((int)(((byte)(127)))));
            this.Speed2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Speed2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Speed2.Image = ((System.Drawing.Image)(resources.GetObject("Speed2.Image")));
            this.Speed2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Speed2.Location = new System.Drawing.Point(658, 7);
            this.Speed2.Name = "Speed2";
            this.Speed2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Speed2.Size = new System.Drawing.Size(149, 21);
            this.Speed2.TabIndex = 4;
            this.Speed2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Player1Box
            // 
            this.Player1Box.BackColor = System.Drawing.Color.Black;
            this.Player1Box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Player1Box.Location = new System.Drawing.Point(106, 12);
            this.Player1Box.Name = "Player1Box";
            this.Player1Box.Size = new System.Drawing.Size(56, 56);
            this.Player1Box.TabIndex = 8;
            this.Player1Box.TabStop = false;
            // 
            // FuelBox2
            // 
            this.FuelBox2.BackColor = System.Drawing.Color.Lime;
            this.FuelBox2.Location = new System.Drawing.Point(202, 31);
            this.FuelBox2.Name = "FuelBox2";
            this.FuelBox2.Size = new System.Drawing.Size(75, 18);
            this.FuelBox2.TabIndex = 9;
            this.FuelBox2.TabStop = false;
            // 
            // Speed1
            // 
            this.Speed1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(19)))), ((int)(((byte)(127)))));
            this.Speed1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Speed1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Speed1.Image = ((System.Drawing.Image)(resources.GetObject("Speed1.Image")));
            this.Speed1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Speed1.Location = new System.Drawing.Point(202, 7);
            this.Speed1.Name = "Speed1";
            this.Speed1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Speed1.Size = new System.Drawing.Size(149, 21);
            this.Speed1.TabIndex = 10;
            this.Speed1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FinishMessage
            // 
            this.FinishMessage.BackColor = System.Drawing.Color.Transparent;
            this.FinishMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinishMessage.ForeColor = System.Drawing.SystemColors.Highlight;
            this.FinishMessage.Location = new System.Drawing.Point(143, 103);
            this.FinishMessage.Name = "FinishMessage";
            this.FinishMessage.Size = new System.Drawing.Size(781, 387);
            this.FinishMessage.TabIndex = 13;
            this.FinishMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FinishMessage.Visible = false;
            // 
            // PlayAgain
            // 
            this.PlayAgain.AutoSize = true;
            this.PlayAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayAgain.Location = new System.Drawing.Point(457, 448);
            this.PlayAgain.Name = "PlayAgain";
            this.PlayAgain.Size = new System.Drawing.Size(158, 56);
            this.PlayAgain.TabIndex = 14;
            this.PlayAgain.Text = "Restart";
            this.PlayAgain.UseVisualStyleBackColor = true;
            this.PlayAgain.Visible = false;
            // 
            // MainMenu
            // 
            this.MainMenu.AutoSize = true;
            this.MainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenu.Location = new System.Drawing.Point(401, 434);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(288, 56);
            this.MainMenu.TabIndex = 14;
            this.MainMenu.Text = "Back To Menu";
            this.MainMenu.UseVisualStyleBackColor = true;
            this.MainMenu.Visible = false;
            // 
            // Interface
            // 
            this.Interface.BackColor = System.Drawing.Color.Transparent;
            this.Interface.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Interface.BackgroundImage")));
            this.Interface.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Interface.Location = new System.Drawing.Point(-10, 0);
            this.Interface.Name = "Interface";
            this.Interface.Size = new System.Drawing.Size(1024, 168);
            this.Interface.TabIndex = 15;
            this.Interface.TabStop = false;
            // 
            // Player2Box
            // 
            this.Player2Box.BackColor = System.Drawing.Color.Black;
            this.Player2Box.Location = new System.Drawing.Point(842, 12);
            this.Player2Box.Name = "Player2Box";
            this.Player2Box.Size = new System.Drawing.Size(56, 56);
            this.Player2Box.TabIndex = 16;
            this.Player2Box.TabStop = false;
            // 
            // StartTimer
            // 
            this.StartTimer.Enabled = true;
            this.StartTimer.Interval = 1000;
            this.StartTimer.Tick += new System.EventHandler(this.StartTimer_Tick);
            // 
            // PlayerControls
            // 
            this.PlayerControls.BackColor = System.Drawing.Color.Black;
            this.PlayerControls.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PlayerControls.BackgroundImage")));
            this.PlayerControls.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PlayerControls.Location = new System.Drawing.Point(187, 234);
            this.PlayerControls.Name = "PlayerControls";
            this.PlayerControls.Size = new System.Drawing.Size(650, 336);
            this.PlayerControls.TabIndex = 17;
            this.PlayerControls.TabStop = false;
            // 
            // Lakitu
            // 
            this.Lakitu.BackColor = System.Drawing.Color.Transparent;
            this.Lakitu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Lakitu.Location = new System.Drawing.Point(434, 330);
            this.Lakitu.Name = "Lakitu";
            this.Lakitu.Size = new System.Drawing.Size(160, 160);
            this.Lakitu.TabIndex = 18;
            this.Lakitu.TabStop = false;
            // 
            // Racegame
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.PlayerControls);
            this.Controls.Add(this.Lakitu);
            this.Controls.Add(this.Player2Box);
            this.Controls.Add(this.Player1Box);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.ItemBox);
            this.Controls.Add(this.Speed1);
            this.Controls.Add(this.FuelBox2);
            this.Controls.Add(this.Speed2);
            this.Controls.Add(this.FuelBox);
            this.Controls.Add(this.Interface);
            this.Controls.Add(this.FinishMessage);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(1042, 815);
            this.MinimumSize = new System.Drawing.Size(1042, 815);
            this.Name = "Racegame";
            this.Text = "Racegame";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Racegame_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.FuelBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player1Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuelBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Interface)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player2Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerControls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lakitu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.PictureBox FuelBox;
        private System.Windows.Forms.PictureBox ItemBox;
        private System.Windows.Forms.Label Speed2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer Fueladder;
        private System.Windows.Forms.PictureBox Player1Box;
        private System.Windows.Forms.PictureBox FuelBox2;
        private System.Windows.Forms.Label Speed1;
        private System.Windows.Forms.Timer Fueladder2;
        private System.Windows.Forms.Label FinishMessage;
        private System.Windows.Forms.Button PlayAgain;
        private System.Windows.Forms.Button MainMenu;
        private System.Windows.Forms.PictureBox Interface;
        private System.Windows.Forms.PictureBox Player2Box;
        private System.Windows.Forms.Timer StartTimer;
        private System.Windows.Forms.PictureBox PlayerControls;
        private System.Windows.Forms.PictureBox Lakitu;
    }
}