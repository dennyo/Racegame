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

        public Racegame(MainMenu main)
        {
            InitializeComponent();
            this.main = main;
            this.player = player;
            GameTimer.Enabled = true;
            
            g = this.CreateGraphics();
            p2 = new Player(Character.David, g, this, null, Keys.Up, Keys.Down, Keys.Right, Keys.Left, Keys.RShiftKey, 600, 400, 64, 64, FuelBox2, HealthBox, Groen, ItemBox, ItemFrame, Fueladder2, Speed2, Ronde2);
            p1 = new Player(Character.Nynke, g, this, null, Keys.W, Keys.S, Keys.D, Keys.A, Keys.LShiftKey, 200, 500, 64, 64, FuelBox, HealthBox1, Groen, ItemBox, ItemFrame, Fueladder, Speed1, Ronde1);
            Game game = new Game(main, this, p1, p2, Map.Standard, "THEMESONG.wav", Finish, FinishMessage, Checkpoint);
            this.game = game;
            //this.KeyDown += p1.ControlHandler;

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            game.Execute();
        }

        private void Racegame_Paint(object sender, PaintEventArgs e) {
            game.Racegame_Paint(sender, e);
        }
    }
}
    


