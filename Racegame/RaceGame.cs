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

        public Racegame(MainMenu main, Character c1, Character c2)
        {
            InitializeComponent();
            
            this.main = main;
            this.player = main.player;
            GameTimer.Enabled = true;

            g = this.CreateGraphics();
            p2 = new Player("Player 2", c2, g, this, null, Keys.Up, Keys.Down, Keys.Right, Keys.Left, Keys.ControlKey, 500, 140, 64, 64, FuelBox2, HealthBox, Groen, Player2Box, Fueladder2, Speed2, Ronde2, 3);
            p1 = new Player("Player 1", c1, g, this, null, Keys.W, Keys.S, Keys.D, Keys.A, Keys.ShiftKey, 520, 80, 64, 64, FuelBox, HealthBox1, Groen, Player1Box, Fueladder, Speed1, Ronde1, 3);
            Game game = new Game(main, this, p1, p2, Map.Standard, "Standard.wav", FinishMessage, 3);
            this.game = game;

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
    }
}

       