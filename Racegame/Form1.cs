using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
using RaceGame;

namespace Racegame
{
    public partial class Racegame : Form
    {

        public int speedX = 10;
        public int speedY = 10;
        public int fuel = 10000;
        public float angle = 0;
        public bool isLoaded = false;
        Graphics g;
        Player p1;
        Player p2;
        public int laps = 0;
        public bool CheckpointPassed = false;
        public int Totalhealth = 100;

        public Racegame()
        {
            InitializeComponent();
            GameTimer.Enabled = true;
            //        Player(Graphics g, System.Drawing.Color color, Keys up, Keys down, Keys right, Keys left, int x, int y, int width, int height) {
            g = this.CreateGraphics();
            p2 = new Player(g, null, Keys.Up, Keys.Down, Keys.Right, Keys.Left, 300, 400, 80, 50);
            p1 = new Player(g, null, Keys.W, Keys.S, Keys.D, Keys.A, 300, 400, 80, 50);

            //this.KeyDown += p1.ControlHandler;
            this.KeyDown += p2.ControlDownHandler;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(p2.ControlUpHandler);
            
            this.KeyDown += p1.ControlDownHandler;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(p1.ControlUpHandler);

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            FuelHandler();
            //PlayerTwo.Location = new Point(PlayerTwo.Location.X + speedX, PlayerTwo.Location.Y + speedY);
            BorderHandler();
            p2.Move(this);
            p1.Move(this);
            
        }

        public void Draw(Graphics g) {
            
            
            //FuelHandler();
            //Auto.Location = new Point(Auto.Location.X + speedX, Auto.Location.Y + speedY);
            BorderHandler();
            CollisionHandler();
            ItemHandler();
            SpeedMeter();
            CheckpointPassed = Checkpointhandler();
            CheckpointPassed = RondeTeller();

        }

        public void FuelHandler()
        {
            fuel -= Math.Abs((Math.Abs(speedX) + Math.Abs(speedY)));
            Size fuelboxsize = new Size(fuel / 50, 10);
            FuelBox.Size = fuelboxsize;
            if (fuel <= 0)
            {
                speedX = 0;
                speedY = 0;
            }
        }
       

        public void BorderHandler()
        {
            ///Moet nog even naar gekeken worden want dit moet er wel zijn!
            /*if (Auto.Location.X >= 1024 - Auto.Size.Width && speedX >= 0)
            {
                speedX = -speedX;
            }
            if (Auto.Location.X <= 0 && speedX <= 0)
            {
                speedX = -speedX;
            }
            if (Auto.Location.Y >= 768 - 2 * Auto.Size.Height && speedY >= 0)
            {
                speedY = -speedY;
            }
            if (Auto.Location.Y <= 0 && speedY <= 0)
            {
                speedY = -speedY;
            }*/
        }

        private void Racegame_Paint(object sender, PaintEventArgs e) {
            p1.DrawPlayer(e.Graphics);
            e.Graphics.ResetTransform();
            p2.DrawPlayer(e.Graphics);
            e.Graphics.ResetTransform();

            //e.Graphics.Dispose();
        }

        public void CollisionHandler()
        {
            //CheckCollision(Groen);
        }

        public void CheckCollision(PictureBox b)
        {
            ///Moet nog even naar gekeken worden want dit moet er wel zijn!
            /*if (Auto.Location.X + Auto.Size.Width >= b.Location.X &&
                Auto.Location.X <= b.Location.X + b.Size.Width &&
                Auto.Location.Y + Auto.Size.Height >= b.Location.Y &&
                Auto.Location.Y <= b.Location.Y + b.Size.Height)
            {
                speedX = 0;
                speedY = 0;
                Auto.BackColor = Color.Orange;

            }*/
        }

        public void ItemHandler()
        {
            CheckItems(ItemBox);
        }

        public void CheckItems(PictureBox b)
        {
            ///Moet nog even naar gekeken worden want dit moet er wel zijn!

            /*if (Auto.Location.X + Auto.Size.Width >= b.Location.X &&
                Auto.Location.X <= b.Location.X + b.Size.Width &&
                Auto.Location.Y + Auto.Size.Height >= b.Location.Y &&
                Auto.Location.Y <= b.Location.Y + b.Size.Height &&
                b.Visible == true)
            {
                b.Visible = false;
                boost();
                RespawnHandler();
            }*/
        }

        public void RespawnHandler()
        {
            if(ItemBox.Visible == false)
            {
                RespawnItems(ItemBox);
            }
        }
        
        public async void RespawnItems(PictureBox b)
        {
                await WaitMethod();
                b.Visible = true;
        }

        public async void boost()
        {
            speedX *= 2;
            speedY *= 2;
            await WaitMethod2();
            speedX /= 2;
            speedY /= 2;
        }

        async System.Threading.Tasks.Task WaitMethod()
        {
            await System.Threading.Tasks.Task.Delay(10000);
        }
        async System.Threading.Tasks.Task WaitMethod2()
        {
            await System.Threading.Tasks.Task.Delay(2000);
        }

        public void SpeedMeter()
        {
            double speed = Math.Sqrt(Math.Abs(Math.Pow(speedX, 2) + Math.Pow(speedY, 2)));
            this.label1.Text = "Speed: " + Math.Round(speed, 1);
        }

        public bool Checkpoints(PictureBox b)
        {
            ///Moet nog even naar gekeken worden want dit moet er wel zijn!

            /*if (Auto.Location.X + Auto.Size.Width >= b.Location.X &&
                Auto.Location.X <= b.Location.X + b.Size.Width &&
                Auto.Location.Y + Auto.Size.Height >= b.Location.Y &&
                Auto.Location.Y <= b.Location.Y + b.Size.Height &&
                CheckpointPassed == false)
            {
                CheckpointPassed = true;
            }*/
            return CheckpointPassed;

        }

        public bool Checkpointhandler()
        {
            CheckpointPassed = Checkpoints(Checkpoint);
            return CheckpointPassed;
        }

        public bool RondeTeller()
        {
            {
                ///Moet nog even naar gekeken worden want dit moet er wel zijn!

                /*if (Auto.Location.X + Auto.Size.Width >= Finish.Location.X &&
                Auto.Location.X <= Finish.Location.X + Finish.Size.Width &&
                Auto.Location.Y + Auto.Size.Height >= Finish.Location.Y &&
                Auto.Location.Y <= Finish.Location.Y + Finish.Size.Height &&
                CheckpointPassed == true)
                {
                    laps = laps + 1;
                    CheckpointPassed = false;
                }

                this.label2.Text = "Lap: " + laps;

                if (laps == 4)
                {
                    speedX = 0;
                    speedY = 0;
                }*/
                return CheckpointPassed;

            }

        }
        public int Damage()
        {
            int health = 100;
            int damageauto = 10;
            if (Auto.Location.X >= 1024 - Auto.Size.Width && speedX >= 0)
            {
                speedX = -speedX;
                int Totalhealt = health -= damageauto;
            }
            if (Auto.Location.X <= 0 && speedX <= 0)
            {
                speedX = -speedX;
                int Totalhealt = health -= damageauto;
            }
            if (Auto.Location.Y >= 768 - 2 * Auto.Size.Height && speedY >= 0)
            {
                speedY = -speedY;
                int Totalhealt = health -= damageauto;
            }
            if (Auto.Location.Y <= 0 && speedY <= 0)
            {
                speedY = -speedY;
                int Totalhealt = health -= damageauto;
            }
            return Totalhealth;
        }

    }
}

