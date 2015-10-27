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
        private Graphics g;
        private Player p1;
        private Player p2;
        private MainMenu main;
        private SoundPlayer player;
        public Game game;
        public PictureBox InterfaceBar;
        public string Soundtrack;
        public string intro;
        int countDown = 9;
        public int IntroLength;


        public Racegame(MainMenu main, Character c1, Character c2, Map map)
        {
            InitializeComponent();
            this.main = main;
            StartTimer.Enabled = true;
            int checkpointCounter = 0;
            this.InterfaceBar = Interface;
            player1Head.BackColor = Color.FromArgb(64, 72, 56);
            player2Head.BackColor = Color.FromArgb(64, 72, 56);

            player1Head.Image = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "heads/" + c1 + "R.png")));
            player2Head.Image = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "heads/" + c2 + "L.png")));

            List<Powerup> Powerups = new List<Powerup>();
            List<Location> RespawnPoints = new List<Location>();
            Location p1Start = new Location(0, 0, 0);
            Location p2Start = new Location(0, 0, 0);

            switch (map)
            {

                case Map.Bowser_Castle:
                    checkpointCounter = 10;
                    Powerups.Add(new Powerup(438, 326));
                    Powerups.Add(new Powerup(418, 278));
                    p1Start = new Location(931, 312, -270);
                    p2Start = new Location(871, 264, -270);
                    
                    RespawnPoints.Add(new Location(348, 558, -90));
                    RespawnPoints.Add(new Location(348, 558, -90));
                    RespawnPoints.Add(new Location(348, 558, -90));
                    RespawnPoints.Add(new Location(348, 558, -90));
                    RespawnPoints.Add(new Location(284, 449, 0));
                    RespawnPoints.Add(new Location(383, 642, -180));
                    RespawnPoints.Add(new Location(348, 558, -90));
                    RespawnPoints.Add(new Location(348, 558, -90));
                    RespawnPoints.Add(new Location(348, 558, -90));
                    RespawnPoints.Add(new Location(348, 558, -90));
                    Soundtrack = "sounds/Bowser Castle.wav";
                    intro = "sounds/Bowser Castle intro.wav";
                    IntroLength = 4080;
                    break;

                case Map.Choco_Island:
                    checkpointCounter = 10;
                    Powerups.Add(new Powerup(724, 626));
                    Powerups.Add(new Powerup(786, 596));
                    p1Start = new Location(390, 274, -90);
                    p2Start = new Location(458, 314, -90);
                    Soundtrack = "sounds/Choco Island.wav";
                    intro = "sounds/Choco Island intro.wav";
                    IntroLength = 2000;
                    break;

                case Map.Donut_Plains:
                    checkpointCounter = 10;
                    Powerups.Add(new Powerup(586,258));
                    Powerups.Add(new Powerup(928,244));
                    p1Start = new Location(96, 456, -90);
                    p2Start = new Location(169, 492, -90);

                    RespawnPoints.Add(new Location(138, 375, -90));
                    RespawnPoints.Add(new Location(195, 172, 0));
                    RespawnPoints.Add(new Location(412, 161, 0));
                    RespawnPoints.Add(new Location(701, 158, 0));
                    RespawnPoints.Add(new Location(752, 321, -180));
                    RespawnPoints.Add(new Location(449, 324, -180));
                    RespawnPoints.Add(new Location(526, 452, -330));
                    RespawnPoints.Add(new Location(800, 527, -315));
                    RespawnPoints.Add(new Location(629, 648, -165));
                    RespawnPoints.Add(new Location(359, 559, -180));
                    Soundtrack = "sounds/Donut Plains.wav";
                    intro = "sounds/Donut Plains intro.wav";
                    IntroLength = 210;
                    break;

                case Map.Ghost_Valley:
                    checkpointCounter = 10;
                    Powerups.Add(new Powerup(344, 224));
                    Powerups.Add(new Powerup(418, 202));
                    p1Start = new Location(338, 690, -180);
                    p2Start = new Location(338, 620, -180);
                    
                    RespawnPoints.Add(new Location(205, 646, -180));
                    RespawnPoints.Add(new Location(47, 450, -90));
                    RespawnPoints.Add(new Location(98, 143, 0));
                    RespawnPoints.Add(new Location(352, 281, -270));
                    RespawnPoints.Add(new Location(356, 479, 0));
                    RespawnPoints.Add(new Location(602, 474, -45));
                    RespawnPoints.Add(new Location(743, 301, -90));
                    RespawnPoints.Add(new Location(900, 301, -270));
                    RespawnPoints.Add(new Location(760, 654, -180));
                    RespawnPoints.Add(new Location(552, 627, -180));
                    Soundtrack = "sounds/Ghost Valley.wav";
                    intro = "sounds/Ghost Valley intro.wav";
                    IntroLength = 6170;
                    break;

                case Map.Koopa_Beach:
                    checkpointCounter = 10;
                    Powerups.Add(new Powerup(846, 236));
                    Powerups.Add(new Powerup(768, 216));
                    p1Start = new Location(116, 254, -90);
                    p2Start = new Location(183, 284, -90);
                    
                    RespawnPoints.Add(new Location(155, 179, -60));
                    RespawnPoints.Add(new Location(279, 105, 0));
                    RespawnPoints.Add(new Location(593, 121, -330));
                    RespawnPoints.Add(new Location(508, 121, -300));
                    RespawnPoints.Add(new Location(865, 420, -270));
                    RespawnPoints.Add(new Location(760, 569, -180));
                    RespawnPoints.Add(new Location(539, 508, -180));
                    RespawnPoints.Add(new Location(296, 539, -180));
                    RespawnPoints.Add(new Location(92, 567, -105));
                    RespawnPoints.Add(new Location(116, 345, -90));
                    Soundtrack = "sounds/Koopa Beach.wav";
                    intro = "sounds/Koopa Beach intro.wav";
                    IntroLength = 15220;
                    break;

                case Map.Rainbow_Road:
                    checkpointCounter = 10;
                    Powerups.Add(new Powerup(694, 217));
                    Powerups.Add(new Powerup(767, 274));
                    p1Start = new Location(23, 344, -90);
                    p2Start = new Location(102, 392, -90);
                    
                    RespawnPoints.Add(new Location(66, 238, -90));
                    RespawnPoints.Add(new Location(291, 115, 0));
                    RespawnPoints.Add(new Location(718, 139, -270));
                    RespawnPoints.Add(new Location(575, 325, -180));
                    RespawnPoints.Add(new Location(293, 367, -270));
                    RespawnPoints.Add(new Location(566, 481, 0));
                    RespawnPoints.Add(new Location(879, 646, -180));
                    RespawnPoints.Add(new Location(538, 615, -180));
                    RespawnPoints.Add(new Location(255, 654, -180));
                    RespawnPoints.Add(new Location(65, 550, -90));
                    Soundtrack = "sounds/Rainbow Road.wav";
                    intro = "sounds/Rainbow Road intro.wav";
                    IntroLength = 13040;
                    break;

                case Map.Standard:
                    checkpointCounter = 3;
                    Powerups.Add(new Powerup(562, 380));
                    Powerups.Add(new Powerup(614, 416));
                    p1Start = new Location(532, 86, 0);
                    p2Start = new Location(502, 156, 0);
                    Soundtrack = "sounds/Mario Circuit.wav";
                    intro = "sounds/Mario Circuit intro.wav";
                    IntroLength = 10280;
                    break;

                case Map.Vanilla_Lake:
                    checkpointCounter = 10;
                    Powerups.Add(new Powerup(388, 134));
                    Powerups.Add(new Powerup(426, 188));
                    p1Start = new Location(806, 437, -90);
                    p2Start = new Location(877, 406, -90);
                    
                    RespawnPoints.Add(new Location(821, 330, -90));
                    RespawnPoints.Add(new Location(712, 135, -180));
                    RespawnPoints.Add(new Location(485, 169, -180));
                    RespawnPoints.Add(new Location(222, 198, -240));
                    RespawnPoints.Add(new Location(171, 446, -270));
                    RespawnPoints.Add(new Location(132, 634, 0));
                    RespawnPoints.Add(new Location(389, 636, 0));
                    RespawnPoints.Add(new Location(648, 636, -15));
                    RespawnPoints.Add(new Location(760, 576, -45));
                    RespawnPoints.Add(new Location(819, 432, -90));
                    Soundtrack = "sounds/Vanilla lake.wav";
                    intro = "sounds/Vanilla lake intro.wav";
                    IntroLength = 29270;
                    break;

            }


            p2 = new Player("Player 2", c2, this, null, Keys.Up, Keys.Down, Keys.Right, Keys.Left, Keys.ControlKey, FuelBox2, Player2Box, Fueladder2, Speed2, checkpointCounter, p2Start);
            p1 = new Player("Player 1", c1, this, null, Keys.W, Keys.S, Keys.D, Keys.A, Keys.ShiftKey, FuelBox, Player1Box, Fueladder, Speed1, checkpointCounter, p1Start);
            Game game = new Game(main, this, this, p1, p2, map, Soundtrack, intro, IntroLength, FinishMessage, 3, Powerups, RespawnPoints);
            this.game = game;
            this.BackgroundImage = game.circuit;
            this.Opacity = 0;
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

        private void FinishMessage_Click(object sender, EventArgs e)
        {
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
            if (keyData == Keys.Escape)
            {
                FadeOutTimer.Enabled = true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public void countDownHandler()
        {
            if (countDown == 7)
            {
                game.Sounds();
            }
            if (countDown <= 4)
            {
                PlayerControls.Visible = false;
            }
            if (countDown == 4)
            {
                Lakitu.BackgroundImage = new Bitmap(Path.Combine(Environment.CurrentDirectory, "Lakitu1.png"));
            }
            if (countDown == 3)
            {
                Lakitu.BackgroundImage = new Bitmap(Path.Combine(Environment.CurrentDirectory, "Lakitu2.png"));
            }
            if (countDown == 2)
            {
                Lakitu.BackgroundImage = new Bitmap(Path.Combine(Environment.CurrentDirectory, "Lakitu3.png"));
            }
            if (countDown == 1)
            {
                Lakitu.BackgroundImage = new Bitmap(Path.Combine(Environment.CurrentDirectory, "Lakitu4.png"));
                GameTimer.Enabled = true;
            }
            if (countDown == 0)
            {
                Lakitu.Visible = false;
                StartTimer.Enabled = false;
            }
        }

        private void FadeInTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity == 1)
            {
                FadeInTimer.Enabled = false;
            }
            else
            {
                this.Opacity += 0.05;
            }
        }

        private void Racegame_Load(object sender, EventArgs e) {

        }

        private void FadeOutTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity == 0)
            {
                FadeOutTimer.Enabled = false;
                Application.Restart();
            }
            else
            {
                this.Opacity -= 0.05;
            }
        }

        private void MainMenu_Click(object sender, EventArgs e)
        {
            FadeOutTimer.Enabled = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void Interface_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawImage(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "laps/" + (p1.laps >= 6 ? 5 : p1.laps) + ".png")), new Rectangle(201, 64, 48, 54));

            e.Graphics.DrawImage(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "laps/" + (p2.laps >= 6 ? 5 : p2.laps) + ".png")), new Rectangle(723, 64, 48, 54));

            e.Graphics.DrawImage(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "laps/of5.png")), new Rectangle(250, 82, 54, 38));
        
            e.Graphics.DrawImage(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "laps/of5.png")), new Rectangle(772, 82, 54, 38));
        }
    }
}

