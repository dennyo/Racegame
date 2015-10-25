using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
using RaceGame;
using System.Media;

namespace Racegame
{
    public partial class Racegame : Form
    {
        public float angle = 0;
        Graphics g;
        Player p1;
        Player p2;
        MainMenu main;
        SoundPlayer player;
        public Game game;
        int countDown = 7;

        public Racegame(MainMenu main, Character c1, Character c2, Map map1)
        {
            InitializeComponent();         
            this.main = main;
            StartTimer.Enabled = true;
            g = this.CreateGraphics();
            p2 = new Player("Player 2", c2, this, null, Keys.Up, Keys.Down, Keys.Right, Keys.Left, Keys.ControlKey, 500, 140, 64, 64, FuelBox2, Player2Box, Fueladder2, Speed2, 3);
            p1 = new Player("Player 1", c1, this, null, Keys.W, Keys.S, Keys.D, Keys.A, Keys.ShiftKey, 520, 80, 64, 64, FuelBox, Player1Box, Fueladder, Speed1, 3);
            Game game = new Game(main, this, p1, p2, map1, "Standard.wav", FinishMessage, 3);
            this.game = game;
            this.BackgroundImage = game.circuit;

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            game.Execute();
        }



        private void Racegame_Paint(object sender, PaintEventArgs e)
        {
            game.Racegame_Paint(sender, e);

            //e.Graphics.Dispose();
        }

        private void StartTimer_Tick(object sender, EventArgs e)
        {
            countDown--;
            countDownHandler();         
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Return &&
                PlayerControls.Visible == true)
            {
                countDown = 4;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public void countDownHandler()
        {
            if (countDown <= 4)
            {
                PlayerControls.Visible = false;
            }
            if(countDown == 4)
            {
                Lakitu.BackgroundImage = new Bitmap(Path.Combine(Environment.CurrentDirectory, "Lakitu1.png"));
            }
            if(countDown == 3)
            {
                Lakitu.BackgroundImage = new Bitmap(Path.Combine(Environment.CurrentDirectory, "Lakitu2.png"));
            }
            if(countDown == 2)
            {
                Lakitu.BackgroundImage = new Bitmap(Path.Combine(Environment.CurrentDirectory, "Lakitu3.png"));
            }
            if(countDown == 1)
            {
                Lakitu.BackgroundImage = new Bitmap(Path.Combine(Environment.CurrentDirectory, "Lakitu4.png"));
                GameTimer.Enabled = true;
            }
            if(countDown == 0)
            {
                Lakitu.Visible = false;
                StartTimer.Enabled = false;
            }
        }
    }
}

       