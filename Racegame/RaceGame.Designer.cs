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
            this.FadeInTimer = new System.Windows.Forms.Timer(this.components);
            this.FadeOutTimer = new System.Windows.Forms.Timer(this.components);
            this.player2Head = new System.Windows.Forms.PictureBox();
            this.player1Head = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FuelBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player1Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuelBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Interface)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player2Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerControls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lakitu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2Head)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1Head)).BeginInit();
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 17;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // FuelBox
            // 
            this.FuelBox.BackColor = System.Drawing.Color.Red;
            this.FuelBox.Location = new System.Drawing.Point(212, 33);
            this.FuelBox.Name = "FuelBox";
            this.FuelBox.Size = new System.Drawing.Size(76, 18);
            this.FuelBox.TabIndex = 1;
            this.FuelBox.TabStop = false;
            // 
            // Speed2
            // 
            this.Speed2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(16)))));
            this.Speed2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Speed2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Speed2.Image = ((System.Drawing.Image)(resources.GetObject("Speed2.Image")));
            this.Speed2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Speed2.Location = new System.Drawing.Point(669, 7);
            this.Speed2.Name = "Speed2";
            this.Speed2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Speed2.Size = new System.Drawing.Size(139, 20);
            this.Speed2.TabIndex = 4;
            this.Speed2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Player1Box
            // 
            this.Player1Box.BackColor = System.Drawing.Color.Black;
            this.Player1Box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Player1Box.Location = new System.Drawing.Point(112, 12);
            this.Player1Box.Name = "Player1Box";
            this.Player1Box.Size = new System.Drawing.Size(56, 56);
            this.Player1Box.TabIndex = 8;
            this.Player1Box.TabStop = false;
            // 
            // FuelBox2
            // 
            this.FuelBox2.BackColor = System.Drawing.Color.Red;
            this.FuelBox2.Location = new System.Drawing.Point(738, 33);
            this.FuelBox2.Name = "FuelBox2";
            this.FuelBox2.Size = new System.Drawing.Size(72, 18);
            this.FuelBox2.TabIndex = 9;
            this.FuelBox2.TabStop = false;
            // 
            // Speed1
            // 
            this.Speed1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(16)))));
            this.Speed1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Speed1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Speed1.Image = ((System.Drawing.Image)(resources.GetObject("Speed1.Image")));
            this.Speed1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Speed1.Location = new System.Drawing.Point(210, 7);
            this.Speed1.Name = "Speed1";
            this.Speed1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Speed1.Size = new System.Drawing.Size(140, 20);
            this.Speed1.TabIndex = 10;
            this.Speed1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FinishMessage
            // 
            this.FinishMessage.BackColor = System.Drawing.Color.Transparent;
            this.FinishMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinishMessage.ForeColor = System.Drawing.SystemColors.Highlight;
            this.FinishMessage.Location = new System.Drawing.Point(224, 288);
            this.FinishMessage.Name = "FinishMessage";
            this.FinishMessage.Size = new System.Drawing.Size(576, 192);
            this.FinishMessage.TabIndex = 13;
            this.FinishMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FinishMessage.Visible = false;
            this.FinishMessage.Click += new System.EventHandler(this.FinishMessage_Click);
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
            this.MainMenu.Click += new System.EventHandler(this.MainMenu_Click);
            // 
            // Interface
            // 
            this.Interface.BackColor = System.Drawing.Color.Transparent;
            this.Interface.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Interface.Image = ((System.Drawing.Image)(resources.GetObject("Interface.Image")));
            this.Interface.InitialImage = null;
            this.Interface.Location = new System.Drawing.Point(0, 0);
            this.Interface.Name = "Interface";
            this.Interface.Size = new System.Drawing.Size(1024, 157);
            this.Interface.TabIndex = 15;
            this.Interface.TabStop = false;
            // 
            // Player2Box
            // 
            this.Player2Box.BackColor = System.Drawing.Color.Black;
            this.Player2Box.Location = new System.Drawing.Point(848, 12);
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
            this.PlayerControls.Location = new System.Drawing.Point(192, 320);
            this.PlayerControls.Name = "PlayerControls";
            this.PlayerControls.Size = new System.Drawing.Size(640, 304);
            this.PlayerControls.TabIndex = 17;
            this.PlayerControls.TabStop = false;
            // 
            // Lakitu
            // 
            this.Lakitu.BackColor = System.Drawing.Color.Transparent;
            this.Lakitu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Lakitu.Location = new System.Drawing.Point(432, 304);
            this.Lakitu.Name = "Lakitu";
            this.Lakitu.Size = new System.Drawing.Size(160, 160);
            this.Lakitu.TabIndex = 18;
            this.Lakitu.TabStop = false;
            // 
            // FadeInTimer
            // 
            this.FadeInTimer.Enabled = true;
            this.FadeInTimer.Interval = 50;
            this.FadeInTimer.Tick += new System.EventHandler(this.FadeInTimer_Tick);
            // 
            // FadeOutTimer
            // 
            this.FadeOutTimer.Interval = 50;
            this.FadeOutTimer.Tick += new System.EventHandler(this.FadeOutTimer_Tick);
            // 
            // player2Head
            // 
            this.player2Head.BackColor = System.Drawing.SystemColors.MenuBar;
            this.player2Head.Location = new System.Drawing.Point(936, 4);
            this.player2Head.Name = "player2Head";
            this.player2Head.Size = new System.Drawing.Size(76, 76);
            this.player2Head.TabIndex = 27;
            this.player2Head.TabStop = false;
            // 
            // player1Head
            // 
            this.player1Head.BackColor = System.Drawing.SystemColors.MenuBar;
            this.player1Head.Location = new System.Drawing.Point(12, 4);
            this.player1Head.Name = "player1Head";
            this.player1Head.Size = new System.Drawing.Size(76, 76);
            this.player1Head.TabIndex = 28;
            this.player1Head.TabStop = false;
            // 
            // Racegame
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.player1Head);
            this.Controls.Add(this.player2Head);
            this.Controls.Add(this.PlayerControls);
            this.Controls.Add(this.Lakitu);
            this.Controls.Add(this.FuelBox2);
            this.Controls.Add(this.FuelBox);
            this.Controls.Add(this.Player2Box);
            this.Controls.Add(this.Player1Box);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.Speed1);
            this.Controls.Add(this.Speed2);
            this.Controls.Add(this.FinishMessage);
            this.Controls.Add(this.Interface);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(1042, 815);
            this.MinimumSize = new System.Drawing.Size(1042, 815);
            this.Name = "Racegame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Super InformatiKart";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Load += new System.EventHandler(this.Racegame_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Racegame_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.FuelBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player1Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuelBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Interface)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player2Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerControls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lakitu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2Head)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1Head)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.PictureBox FuelBox;
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
        private System.Windows.Forms.Timer FadeInTimer;
        private System.Windows.Forms.Timer FadeOutTimer;
        private System.Windows.Forms.PictureBox player2Head;
        private System.Windows.Forms.PictureBox player1Head;
    }
}