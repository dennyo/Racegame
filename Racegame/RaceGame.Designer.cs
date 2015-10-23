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
            this.Speed2 = new System.Windows.Forms.Label();
            this.Ronde1 = new System.Windows.Forms.Label();
            this.Fueladder = new System.Windows.Forms.Timer(this.components);
            this.Player1Box = new System.Windows.Forms.PictureBox();
            this.FuelBox2 = new System.Windows.Forms.PictureBox();
            this.Speed1 = new System.Windows.Forms.Label();
            this.Ronde2 = new System.Windows.Forms.Label();
            this.Fueladder2 = new System.Windows.Forms.Timer(this.components);
            this.HealthBox1 = new System.Windows.Forms.PictureBox();
            this.FinishMessage = new System.Windows.Forms.Label();
            this.PlayAgain = new System.Windows.Forms.Button();
            this.MainMenu = new System.Windows.Forms.Button();
            this.Interface = new System.Windows.Forms.PictureBox();
            this.Player2Box = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FuelBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player1Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuelBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Interface)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player2Box)).BeginInit();
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 17;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // FuelBox
            // 
            this.FuelBox.BackColor = System.Drawing.Color.Blue;
            this.FuelBox.Location = new System.Drawing.Point(616, 58);
            this.FuelBox.Name = "FuelBox";
            this.FuelBox.Size = new System.Drawing.Size(200, 10);
            this.FuelBox.TabIndex = 1;
            this.FuelBox.TabStop = false;
            // 
            // HealthBox
            // 
            this.HealthBox.BackColor = System.Drawing.Color.Red;
            this.HealthBox.Location = new System.Drawing.Point(193, 44);
            this.HealthBox.Name = "HealthBox";
            this.HealthBox.Size = new System.Drawing.Size(200, 10);
            this.HealthBox.TabIndex = 2;
            this.HealthBox.TabStop = false;
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
            this.Speed2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(72)))), ((int)(((byte)(56)))));
            this.Speed2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Speed2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Speed2.Image = ((System.Drawing.Image)(resources.GetObject("Speed2.Image")));
            this.Speed2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Speed2.Location = new System.Drawing.Point(658, 7);
            this.Speed2.Name = "Speed2";
            this.Speed2.Size = new System.Drawing.Size(149, 21);
            this.Speed2.TabIndex = 4;
            this.Speed2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Ronde1
            // 
            this.Ronde1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Ronde1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ronde1.Location = new System.Drawing.Point(773, 600);
            this.Ronde1.Name = "Ronde1";
            this.Ronde1.Size = new System.Drawing.Size(200, 50);
            this.Ronde1.TabIndex = 5;
            this.Ronde1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Player1Box
            // 
            this.Player1Box.BackColor = System.Drawing.Color.Transparent;
            this.Player1Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Player1Box.Location = new System.Drawing.Point(24, 140);
            this.Player1Box.Name = "Player1Box";
            this.Player1Box.Size = new System.Drawing.Size(64, 64);
            this.Player1Box.TabIndex = 8;
            this.Player1Box.TabStop = false;
            // 
            // FuelBox2
            // 
            this.FuelBox2.BackColor = System.Drawing.Color.Blue;
            this.FuelBox2.Location = new System.Drawing.Point(193, 60);
            this.FuelBox2.Name = "FuelBox2";
            this.FuelBox2.Size = new System.Drawing.Size(200, 10);
            this.FuelBox2.TabIndex = 9;
            this.FuelBox2.TabStop = false;
            // 
            // Speed1
            // 
            this.Speed1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(72)))), ((int)(((byte)(56)))));
            this.Speed1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Speed1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Speed1.Image = ((System.Drawing.Image)(resources.GetObject("Speed1.Image")));
            this.Speed1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Speed1.Location = new System.Drawing.Point(193, 7);
            this.Speed1.Name = "Speed1";
            this.Speed1.Size = new System.Drawing.Size(149, 21);
            this.Speed1.TabIndex = 10;
            this.Speed1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Ronde2
            // 
            this.Ronde2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Ronde2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ronde2.Location = new System.Drawing.Point(773, 663);
            this.Ronde2.Name = "Ronde2";
            this.Ronde2.Size = new System.Drawing.Size(200, 50);
            this.Ronde2.TabIndex = 11;
            this.Ronde2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HealthBox1
            // 
            this.HealthBox1.BackColor = System.Drawing.Color.Red;
            this.HealthBox1.Location = new System.Drawing.Point(616, 44);
            this.HealthBox1.Name = "HealthBox1";
            this.HealthBox1.Size = new System.Drawing.Size(200, 10);
            this.HealthBox1.TabIndex = 12;
            this.HealthBox1.TabStop = false;
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
            this.Player2Box.BackColor = System.Drawing.Color.Transparent;
            this.Player2Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Player2Box.Location = new System.Drawing.Point(920, 130);
            this.Player2Box.Name = "Player2Box";
            this.Player2Box.Size = new System.Drawing.Size(64, 64);
            this.Player2Box.TabIndex = 16;
            this.Player2Box.TabStop = false;
            // 
            // Racegame
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1026, 741);
            this.Controls.Add(this.Player2Box);
            this.Controls.Add(this.Player1Box);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.HealthBox1);
            this.Controls.Add(this.ItemBox);
            this.Controls.Add(this.HealthBox);
            this.Controls.Add(this.Ronde2);
            this.Controls.Add(this.Speed1);
            this.Controls.Add(this.FuelBox2);
            this.Controls.Add(this.Ronde1);
            this.Controls.Add(this.Speed2);
            this.Controls.Add(this.FuelBox);
            this.Controls.Add(this.Interface);
            this.Controls.Add(this.FinishMessage);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(1042, 815);
            this.MinimumSize = new System.Drawing.Size(1042, 726);
            this.Name = "Racegame";
            this.Text = "Racegame";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Racegame_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.FuelBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player1Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuelBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Interface)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player2Box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.PictureBox FuelBox;
        private System.Windows.Forms.PictureBox HealthBox;
        private System.Windows.Forms.PictureBox ItemBox;
        private System.Windows.Forms.Label Speed2;
        private System.Windows.Forms.Label Ronde1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer Fueladder;
        private System.Windows.Forms.PictureBox Player1Box;
        private System.Windows.Forms.PictureBox FuelBox2;
        private System.Windows.Forms.Label Speed1;
        private System.Windows.Forms.Label Ronde2;
        private System.Windows.Forms.Timer Fueladder2;
        private System.Windows.Forms.PictureBox HealthBox1;
        private System.Windows.Forms.Label FinishMessage;
        private System.Windows.Forms.Button PlayAgain;
        private System.Windows.Forms.Button MainMenu;
        private System.Windows.Forms.PictureBox Interface;
        private System.Windows.Forms.PictureBox Player2Box;
    }
}