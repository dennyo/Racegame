using RaceGame;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racegame {

    public enum Character { David, Jos, Fiona, Jop, Sibbele, Joris, Nynke, Dick };
    public enum Map {Standard, Koopa_Beach, Rainbow_Road, Donut_Plains, Ghost_Valley, Bowser_Castle, Choco_Island, Vanilla_Lake };
    public enum ColorHandler {Gras, Water, Pitstop, Gat, Finish, None };

    public class Game {

        public bool isLoaded = false;
        public bool CheckpointPassed = false;
        public bool FinishPassed = false;
        public Rectangle muur = new Rectangle(650 ,200 , 150, 150);

        Image Banana = new Bitmap(Path.Combine(Environment.CurrentDirectory, "Banana.png"));
        Image Mushroom = new Bitmap(Path.Combine(Environment.CurrentDirectory, "Mushroom.png"));
        Image Fuel = new Bitmap(Path.Combine(Environment.CurrentDirectory, "fuel.png"));
        Bitmap colormap;
        Bitmap checkpoints;
        Powerup pw;

        SoundPlayer soundtrack;
        SoundPlayer mainMenuSound;
        Player p1;
        Player p2;
        Map map;
        public Form form;
        Label FinishMessage;
        MainMenu main;
        int checkpointPoints;

        public Game(MainMenu main, Form form, Player p1, Player p2, Map map, string soundtrack, Label FinishMessage, int checkpointAmount) {
            this.p1 = p1;
            this.p2 = p2;
            this.map = map;
            this.form = form;
            this.main = main;
            this.FinishMessage = FinishMessage;
            this.mainMenuSound = main.player;
            pw = new Powerup(this, 300, 200);

            SoundPlayer soundplayer = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, soundtrack));
            this.soundtrack = soundplayer;
            main.player.Stop();
            soundplayer.PlayLooping();

            for(int i = 0; i < checkpointAmount; i++) {
                checkpointPoints += 255 - i * 10;
            }

            p1.FuelTimer.Interval = 17;
            p1.FuelTimer.Tick += new System.EventHandler(this.Fueladder_Tick);

            p2.FuelTimer.Interval = 17;
            p2.FuelTimer.Tick += new System.EventHandler(this.Fueladder2_Tick);

            switch(map) {
                case Map.Koopa_Beach:

                    break;

                case Map.Rainbow_Road:
                    
                    break;

                case Map.Standard:
                    colormap = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Standard/colormap.png")));
                    checkpoints = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Standard/checkpoints.png")), new Size(form.ClientSize.Width, form.ClientSize.Height));

                    break;

                case Map.Bowser_Castle:

                    break;

            }

            //pw.SpinItemBox(p1);
            //pw.Rotate();

        }

        public void Execute() {

            FuelHandler();
            BorderHandler();
            p2.Move(form);
            p1.Move(form);
            CollisionHandler();
            CollisionHandler(p1, muur);
            CollisionHandler(p2, muur);
            ItemHandler();
            SpeedMeter();
            Checkpointhandler();
            PlayerCollision();
            FinishHandler();
            p1.rect.X = Convert.ToInt32(p1.X);
            p1.rect.Y = Convert.ToInt32(p1.Y);
            p2.rect.X = Convert.ToInt32(p2.X);
            p2.rect.Y = Convert.ToInt32(p2.Y);
            ColorHandler();
            pw.Collision(p1);
            pw.Collision(p2);

            pw.AddCount();
        }

        public void ColorHandler() {
            p1.HandleColor(colormap);
            p2.HandleColor(colormap);
        }

        public void FuelHandler()
        {
            Fueling(p1, p1.FuelBox, p1.HealthBox);
            Fueling(p2, p2.FuelBox, p2.HealthBox);
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
            if (a.X >= form.ClientSize.Width - p1.Width && a.SpeedX >= 0)
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
            if (a.Y >= form.ClientSize.Height - a.Height && a.SpeedY >= 0)
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

        public void Racegame_Paint(object sender, PaintEventArgs e)
        {
            p1.DrawPlayer(e.Graphics);
            e.Graphics.ResetTransform();
            p2.DrawPlayer(e.Graphics);
            e.Graphics.ResetTransform();
            pw.Draw(e.Graphics);


            //e.Graphics.Dispose();
        }

        public void CollisionHandler()
        {
            CheckCollision(p1, p1.Groen);
            CheckCollision(p2, p2.Groen);
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

        public async void CollisionHandler(Player a, Rectangle muur)
        {
            bool Collision = CollisionDetection(a.rect, muur);
            if (Collision == true)
            {

                if (a.rect.X + 16 < muur.Left && a.rect.Y + 16 < muur.Bottom && a.rect.Y + 48 > muur.Top)
                {
                    a.X -= Math.Abs(p1.Speed) + 10;
                    if (Math.Abs(a.Angle) < 45)
                    {
                        a.Speed = 0;
                    }
                    else if(a.Angle < -135 && a.Angle > -225)
                    {
                        a.Speed = 0;
                    }
                    else if(a.Angle > 135 && a.Angle < 225)
                    {
                        a.Speed = 0;
                    }

                    else { 
                    if (a.Speed > 10)
                        {
                            a.Speed = 10;
                        }
                        await WaitMethod4();
                        a.Speed = a.Speed / 2;
                        await WaitMethod4();
                        a.Speed = a.Speed / 2;
                        await WaitMethod4();
                        a.Speed = a.Speed / 2;
                        await WaitMethod4();
                        a.Speed = a.Speed / 2;
                        await WaitMethod4();
                        a.Speed = 0;
                    }

                }

                else if (a.rect.X + 48 > muur.Right && a.rect.Y + 16 < muur.Bottom && a.rect.Y + 48 > muur.Top)
                {
                    a.X += Math.Abs(p1.Speed) + 10;
                    if (Math.Abs(a.Angle) < 45)
                    {
                        a.Speed = 0;
                    }
                    else if (a.Angle < -135 && a.Angle > -225)
                    {
                        a.Speed = 0;
                    }
                    else if (a.Angle > 135 && a.Angle < 225)
                    {
                        a.Speed = 0;
                    }

                    else
                    {
                        if (a.Speed > 10)
                        {
                            a.Speed = 10;
                        }
                        await WaitMethod4();
                        a.Speed = a.Speed / 2;
                        await WaitMethod4();
                        a.Speed = a.Speed / 2;
                        await WaitMethod4();
                        a.Speed = a.Speed / 2;
                        await WaitMethod4();
                        a.Speed = a.Speed / 2;
                        await WaitMethod4();
                        a.Speed = 0;
                    }

                }
                else if (a.rect.Y + 16 < muur.Top)
                {
                    a.Y -= Math.Abs(p1.Speed) + 10;
                    if (a.Angle < 315 && a.Angle > 225)
                    {
                        a.Speed = 0;
                    }
                    else if (a.Angle > -135 && a.Angle < -45)
                    {
                        a.Speed = 0;
                    }
                    else if (a.Angle < 135 && a.Angle > 45)
                    {
                        a.Speed = 0;
                    }
                    else if (a.Angle > -225 && a.Angle < -315)
                    {
                        a.Speed = 0;
                    }

                    else
                    {
                        if (a.Speed > 10)
                        {
                            a.Speed = 10;
                        }
                        await WaitMethod4();
                        a.Speed = a.Speed / 2;
                        await WaitMethod4();
                        a.Speed = a.Speed / 2;
                        await WaitMethod4();
                        a.Speed = a.Speed / 2;
                        await WaitMethod4();
                        a.Speed = a.Speed / 2;
                        await WaitMethod4();
                        a.Speed = 0;
                    }
                }
                else if (a.rect.Y + 48 > muur.Bottom)
                {
                    a.Y += Math.Abs(p1.Speed) + 10;
                    if (a.Angle < 315 && a.Angle > 225)
                    {
                        a.Speed = 0;
                    }
                    else if (a.Angle > -135 && a.Angle < -45)
                    {
                        a.Speed = 0;
                    }
                    else if (a.Angle < 135 && a.Angle > 45)
                    {
                        a.Speed = 0;
                    }
                    else if (a.Angle > -225 && a.Angle < -315)
                    {
                        a.Speed = 0;
                    }

                    else
                    {
                        if (a.Speed > 10)
                        {
                            a.Speed = 10;
                        }
                        await WaitMethod4();
                        a.Speed = a.Speed / 2;
                        await WaitMethod4();
                        a.Speed = a.Speed / 2;
                        await WaitMethod4();
                        a.Speed = a.Speed / 2;
                        await WaitMethod4();
                        a.Speed = a.Speed / 2;
                        await WaitMethod4();
                        a.Speed = 0;
                    }
                }


            }
            }

        public void ItemHandler()
        {
            //CheckItems(p1, p1.ItemBox);
            //CheckItems(p2, p2.ItemBox);
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
            p1.ItemFrame.Visible = true;
            for (int i = 0; i < 30; i++)
            {
                if (number == 0)
                {
                    p1.ItemFrame.Image = Banana;
                }
                if (number == 1)
                {
                    p1.ItemFrame.Image = Mushroom;
                }
                if (number == 2)
                {
                    p1.ItemFrame.Image = Fuel;
                }
                number = rand.Next(3);
                await WaitMethod3();
            }


        }

        public void RespawnHandler()
        {
            /*if (p1.ItemBox.Visible == false)
            {
                RespawnItems(p1.ItemBox);
            }*/
        }

        public async void RespawnItems(PictureBox b)
        {
            await WaitMethod();
            b.Visible = true;
        }

        public async void boost(Player a)
        {
            if (a == p1)
            {
                p1.FuelTimer.Enabled = true;
            }
            else
            {
                p2.FuelTimer.Enabled = true;
            }
            a.Speed = 20;
            a.MaxSpeed *= 2;
            await WaitMethod2();
            if(a.Speed >= 14) { 
            a.Speed = 14;
        }
            a.MaxSpeed /= 2;
            if (a == p1)
            {
                p1.FuelTimer.Enabled = false;
            }
            else
            {
                p2.FuelTimer.Enabled = false;
            }
        }

        async System.Threading.Tasks.Task WaitMethod()
        {
            await System.Threading.Tasks.Task.Delay(10000);
        }
        async System.Threading.Tasks.Task WaitMethod2()
        {
            await System.Threading.Tasks.Task.Delay(2000);
        }
        async System.Threading.Tasks.Task WaitMethod3()
        {
            await System.Threading.Tasks.Task.Delay(50);
        }
        async System.Threading.Tasks.Task WaitMethod4()
        {
            await System.Threading.Tasks.Task.Delay(200);
        }

        public void SpeedMeter()
        {
            Speed(p1, p1.SpeedLabel);
            Speed(p2, p2.SpeedLabel);
        }

        public void Speed(Player a, Label b)
        {
            double speed = Math.Sqrt(Math.Pow(a.SpeedX, 2) + Math.Pow(a.SpeedY, 2));
            b.Text = "Speed: " + Math.Round(speed, 0);
        }

        public void Checkpointhandler()
        {
            p1.CheckpointChecker(checkpoints);
            p2.CheckpointChecker(checkpoints);
        }

        public void FinishHandler()
        {
            p1.FinishHandler(FinishMessage, checkpoints);
            p2.FinishHandler(FinishMessage, checkpoints);
            
            if(p1.Finished || p2.Finished) {
                p1.MaxSpeed = 0;
                p1.GameEnded = true;
                p2.MaxSpeed = 0;
                p2.GameEnded = true;

            }
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



            bool iscolliding = CircleCollision(p1.rect, p2.rect);
            if(iscolliding == true)
            {
                p1.Speed = 0;
                p2.Speed = 0;
            }
            
        }

        

        public bool CircleCollision(Rectangle Circle1, Rectangle Circle2)
        {

            int R1 = Circle1.Width / 2;
            int R2 = Circle2.Width / 2;
            int Cx1 = Convert.ToInt32(0.5 * (Circle1.Left + Circle1.Right));
            int Cy1 = Convert.ToInt32(0.5 * (Circle1.Top + Circle1.Bottom));
            int Cx2 = Convert.ToInt32(0.5 * (Circle2.Left + Circle2.Right));
            int Cy2 = Convert.ToInt32(0.5 * (Circle2.Top + Circle2.Bottom));
            int Radius = R1 + R2;

            var deltaX = Cx1 - Cx2;
            var deltaY = Cy1 - Cy2;

            return deltaX * deltaX + deltaY * deltaY <= Radius * Radius;

        }

        public bool CollisionDetection(Rectangle circle, Rectangle rectangle)
        {

            // clamp(value, min, max) - limits value to the range min..max
            int Cx1 = Convert.ToInt32(0.5 * (circle.Left + circle.Right));
            int Cy1 = Convert.ToInt32(0.5 * (circle.Top + circle.Bottom));
            // Find the closest point to the circle within the rectangle
            float closestX = Clamp(Cx1, rectangle.Left, rectangle.Right);
            float closestY = Clamp(Cy1, rectangle.Top, rectangle.Bottom);

            // Calculate the distance between the circle's center and this closest point
            float distanceX = Cx1 - closestX;
            float distanceY = Cy1 - closestY;
            int Radius = circle.Width / 2;

            // If the distance is less than the circle's radius, an intersection occurs
            float distanceSquared = (distanceX * distanceX) + (distanceY * distanceY);
            return distanceSquared < (Radius * Radius);

        }

        public float Clamp(
         float value,
         float min,
         float max)
        {
            if (value > max)
            {
                return max;
            }
            if (value < min)
            {
                return min;
            }
            if (min <= value && value >= max)
            {
                return value;
            }
            else
            {
                return value;
            }
        }

        private void Racegame_FormClosing(object sender, FormClosingEventArgs e) {
            main.Show();
            main.player.PlayLooping();
        }

    }
}
