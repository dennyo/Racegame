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
<<<<<<< HEAD
            p2 = new Player(Character.David, g, this, null, Keys.Up, Keys.Down, Keys.Right, Keys.Left, Keys.RShiftKey, 600, 400, 64, 64);
            p1 = new Player(Character.Nynke, g, this, null, Keys.W, Keys.S, Keys.D, Keys.A, Keys.LShiftKey, 200, 500, 64, 64);

=======
            p2 = new Player(Character.David, g, this, null, Keys.Up, Keys.Down, Keys.Right, Keys.Left, Keys.RShiftKey, 600, 400, 64, 64, FuelBox2, HealthBox, Groen, ItemBox, ItemFrame, Fueladder2, Speed2, Ronde2);
            p1 = new Player(Character.Nynke, g, this, null, Keys.W, Keys.S, Keys.D, Keys.A, Keys.LShiftKey, 200, 500, 64, 64, FuelBox, HealthBox1, Groen, ItemBox, ItemFrame, Fueladder, Speed1, Ronde1);
            Game game = new Game(main, this, p1, p2, Map.Standard, "THEMESONG.wav", Finish, FinishMessage, Checkpoint);
            this.game = game;
>>>>>>> f27e1051844d211b776a8e8bea2a34c52251f2c9
            //this.KeyDown += p1.ControlHandler;

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
<<<<<<< HEAD
            FuelHandler();
            BorderHandler();
            p2.Move(this);
            p1.Move(this);
            CollisionHandler();
            ItemHandler();
            SpeedMeter();
            Checkpointhandler();
            RondeTeller();
            //PlayerCollision();
            Console.WriteLine(p1.SpeedY);
            FinishHandler();
        }

        public void FuelHandler()
        {
            Fueling(p1, FuelBox, HealthBox);
            Fueling(p2, FuelBox2, HealthBox1);
        }

        public void Fueling(Player a, PictureBox b, PictureBox c)
        {
            a.Fuel -= Math.Abs(Convert.ToInt16(a.Speed));
            Size fuelboxsize = new Size(a.Fuel / 250 * 10, 10);
            b.Size = fuelboxsize;
            Size healthboxsize = new Size(a.Health * 4, 10);
            c.Size = healthboxsize;

            if (a.Fuel <= 0)
            {
                a.Speed = 0;
            }
        }

        public void BorderHandler()
        {
            Borders(p1);
            Borders(p2);
        }

        public void Borders(Player a)
        {
            if (a.X >= ClientSize.Width - p1.Width && a.SpeedX >= 0)
            {
                a.Health -= Math.Abs(Convert.ToInt16(a.Speed));
                a.Speed = 0;
                a.X -= 10;
            }
            if (a.X <= 0)
            {
                a.Health -= Math.Abs(Convert.ToInt16(a.Speed));
                a.Speed = 0;
                a.X += 10;
            }
            if (a.Y >= ClientSize.Height - 2 * a.Height && a.SpeedY >= 0)
            {
                a.Health -= Math.Abs(Convert.ToInt16(a.Speed));
                a.Speed = 0;
                a.Y -= 10;
            }
            if (a.Y <= 0)
            {
                a.Health -= Math.Abs(Convert.ToInt16(a.Speed));
                a.Speed = 0;
                a.Y += 10;
            }

            if (a.Health <= 0)
            {
                a.Speed = 0;
            }
        }

        private void Racegame_Paint(object sender, PaintEventArgs e)
        {
            p1.DrawPlayer(e.Graphics);
            e.Graphics.ResetTransform();
            p2.DrawPlayer(e.Graphics);
            e.Graphics.ResetTransform();

            //e.Graphics.Dispose();
        }

        public void CollisionHandler()
        {
            CheckCollision(p1, Groen);
            CheckCollision(p2, Groen);
            
        }

        public void CheckCollision(Player a, PictureBox b)
        {
            ///Moet nog even naar gekeken worden want dit moet er wel zijn!
            if (a.X + a.MaxSize >= b.Location.X &&
                a.X <= b.Location.X + b.Size.Width &&
                a.Y + a.MaxSize >= b.Location.Y &&
                a.Y <= b.Location.Y + b.Size.Height)
            {
                a.Speed = 0;
                a.Speed = 0;
            }
        }

        public void ItemHandler()
        {

            CheckItems(p1, ItemBox);
            CheckItems(p2, ItemBox);
        }

        public void CheckItems(Player a, PictureBox b)
        {
            ///Moet nog even naar gekeken worden want dit moet er wel zijn!

            if (a.X + a.Width >= b.Location.X &&
                a.X <= b.Location.X + b.Size.Width &&
                a.Y + a.Height >= b.Location.Y &&
                a.Y <= b.Location.Y + b.Size.Height &&
                b.Visible == true)
            {
                b.Visible = false;
                GetItem();
                boost(a);
                RespawnHandler();
            }
        }

        public async void GetItem()
        {
            Random rand = new Random();
            int number = rand.Next(4);
            ItemFrame.Visible = true;
            for (int i = 0; i < 30; i++)
            {
                if (number == 0)
                {
                    ItemFrame.Image = Banana;
                }
                if (number == 1)
                {
                    ItemFrame.Image = Mushroom;
                }
                if (number == 2)
                {
                    ItemFrame.Image = Fuel;
                }
                number = rand.Next(3);
                await WaitMethod3();
            }


        }

        public void RespawnHandler()
        {
            if (ItemBox.Visible == false)
            {
                RespawnItems(ItemBox);
            }
        }

        public async void RespawnItems(PictureBox b)
        {
            await WaitMethod();
            b.Visible = true;
=======
            game.Execute();
>>>>>>> f27e1051844d211b776a8e8bea2a34c52251f2c9
        }

        private void Racegame_Paint(object sender, PaintEventArgs e) {
            game.Racegame_Paint(sender, e);
        }
<<<<<<< HEAD

        public bool Rondes(Player a, Label b)
        {
            {
                ///Moet nog even naar gekeken worden want dit moet er wel zijn!

                if (a.X + a.Width >= Finish.Location.X &&
                a.X <= Finish.Location.X + Finish.Size.Width &&
                a.Y + a.Height >= Finish.Location.Y &&
                a.Y <= Finish.Location.Y + Finish.Size.Height &&
                a.CheckpointPassed == true)
                {
                    a.laps = a.laps + 1;
                    a.CheckpointPassed = false;
                }

                b.Text = "Lap: " + a.laps;
                return a.CheckpointPassed;
            }
        }

        public void FinishHandler()
        {
            p1.FinishPassed = Finishing(p1, FinishMessage);
            p2.FinishPassed = Finishing(p2, FinishMessage);
            if (FinishPassed == true)
            {
                p1.Speed = 0;
                p2.Speed = 0;
            }
        }
        public bool Finishing(Player a, Label b)
        {
            if (a.laps >= 4 && FinishPassed == false)
            {
                this.FinishMessage.Visible = true;
                this.MainMenu.Visible = true;
                if (a == p1)
                {
                    this.FinishMessage.Text = "Player 1 wins!";
                }
                else if (a == p2)
                {
                    this.FinishMessage.Text = "Player 2 wins!";
                }
                FinishPassed = true;
            }
            return FinishPassed;

        }

        private void Fueladder_Tick(object sender, EventArgs e)
        {
            p1.Fuel += Convert.ToInt16(p1.Speed);
        }
        private void Fueladder2_Tick(object sender, EventArgs e)
        {
            p2.Fuel += Convert.ToInt16(p2.Speed);
        }


        public void PlayerCollision()
        {
            if (p1.X + p1.MaxSize - 18 >= p2.X + 18 &&
               p1.X + 18 <= p2.X + p2.Width - 18 &&
               p1.Y + p1.MaxSize - 18 >= p2.Y + 18 &&
               p1.Y + 18 <= p2.Y + p2.Height - 18)
            {
                p1.Health -= Convert.ToInt16(p1.Speed + p2.Speed);
                p2.Health -= Convert.ToInt16(p1.Speed + p2.Speed);
                p1.Speed = 0;
                p2.Speed = 0;
            }


        }
        private void Racegame_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();
            player.PlayLooping();
        }
     

=======
>>>>>>> f27e1051844d211b776a8e8bea2a34c52251f2c9
    }
}
    

    


