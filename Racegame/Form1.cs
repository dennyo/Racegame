using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racegame
{
    public partial class Racegame : Form
    {

        public int speedX = 10;
        public int speedY = 10;
        public int fuel = 10000;
        public int laps = 0;

        public Racegame()
        {
            InitializeComponent();
            GameTimer.Enabled = true;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            //FuelHandler();
            Auto.Location = new Point(Auto.Location.X + speedX, Auto.Location.Y + speedY);
            BorderHandler();
            CollisionHandler();
            ItemHandler();
            SpeedMeter();
            RondeTeller();
        }

        public void FuelHandler()
        {
            fuel -= Math.Abs((speedX + speedY));
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
            if (Auto.Location.X >= 1024 - Auto.Size.Width)
            {
                speedX = -speedX;
            }
            if (Auto.Location.X <= 0)
            {
                speedX = -speedX;
            }
            if (Auto.Location.Y >= 768 - 2 * Auto.Size.Height)
            {
                speedY = -speedY;
            }
            if (Auto.Location.Y <= 0)
            {
                speedY = -speedY;
            }
        }

        public void CollisionHandler()
        {
            
        }

        public void CheckCollision(PictureBox b)
        {
            if (Auto.Location.X + Auto.Size.Width >= b.Location.X &&
                Auto.Location.X <= b.Location.X + b.Size.Width &&
                Auto.Location.Y + Auto.Size.Height >= b.Location.Y &&
                Auto.Location.Y <= b.Location.Y + b.Size.Height)
            {
                speedX = 0;
                speedY = 0;
                Auto.BackColor = Color.Orange;
            }
        }

        public void ItemHandler()
        {
            CheckItems(ItemBox);
        }

        public void CheckItems(PictureBox b)
        {
            if (Auto.Location.X + Auto.Size.Width >= b.Location.X &&
                Auto.Location.X <= b.Location.X + b.Size.Width &&
                Auto.Location.Y + Auto.Size.Height >= b.Location.Y &&
                Auto.Location.Y <= b.Location.Y + b.Size.Height &&
                b.Visible == true)
            {
                b.Visible = false;
                boost();
                RespawnHandler();
            }
        }

        public void RespawnHandler()
        {
            RespawnItems(ItemBox);
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

        public void Checkpoints()
        {

        }

        public void RondeTeller()
        {
            for (int i = 0; i < 4; i++)
            {
                if (Auto.Location.X >= 500 && Auto.Location.X <= 510 && Auto.Location.Y >= 400 && Auto.Location.Y <= 768)
                    // deze getallen moeten aangepast worden aan de positie van de finish!
                {
                    laps = laps + 1;
                    break;
                }

                this.label2.Text = "Lap: " + laps;

                if (laps == 4)
                {
                    speedX = 0;
                    speedY = 0;
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }




    }
}

