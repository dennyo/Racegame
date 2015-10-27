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
    public enum Map {Standard, Donut_Plains, Ghost_Valley, Bowser_Castle, Choco_Island, Koopa_Beach, Vanilla_Lake, Rainbow_Road};
    public enum ColorHandler {Gras, Water, Pitstop, Gat, Finish, None, Wall_Red, Wall_Green, Wall_Blue, Wall_Light_Blue };
    public enum ColorHandler_Walls {Red, Green, Blue, Light_Blue };

    public class Game {

        public bool isLoaded = false;
        public bool CheckpointPassed = false;
        public bool FinishPassed = false;
        //public Rectangle muur = new Rectangle(650 ,200 , 150, 150);

        public List<Banana> BananaItems = new List<Banana>();
        public List<Shell> ShellItems = new List<Shell>();
        public List<Powerup> Powerups = new List<Powerup>();
        public List<Location> RespawnPoints = new List<Location>();

        Image Banana = new Bitmap(Path.Combine(Environment.CurrentDirectory, "Banana.png"));
        Image Mushroom = new Bitmap(Path.Combine(Environment.CurrentDirectory, "Mushroom.png"));
        Image Fuel = new Bitmap(Path.Combine(Environment.CurrentDirectory, "fuel.png"));
        public Bitmap colormap;
        public Bitmap checkpoints;
        public Bitmap wallmap;
        public Bitmap circuit;

        SoundPlayer soundtrack;
        SoundPlayer mainMenuSound;
        Player p1;
        Player p2;
        Map map;
        public Form form;
        Label FinishMessage;
        MainMenu main;
        Racegame rg;
        int checkpointPoints;
        public string SoundTrack;
        public string Intro;

        public Game(MainMenu main, Racegame rg, Form form, Player p1, Player p2, Map map, string soundtrack, string intro, Label FinishMessage, int checkpointAmount, List<Powerup> Powerups, List<Location> RespawnPoints) {
            this.p1 = p1;
            this.p2 = p2;
            this.map = map;
            this.form = form;
            this.main = main;
            this.FinishMessage = FinishMessage;
            this.rg = rg;
            this.Powerups = Powerups;
            this.RespawnPoints = RespawnPoints;

            SoundPlayer soundplayer = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, soundtrack));
            this.soundtrack = soundplayer;
            soundplayer.PlayLooping();

            this.SoundTrack = soundtrack;
            this.Intro = intro;
            
            for(int i = 0; i < checkpointAmount; i++) {
                checkpointPoints += 255 - i * 10;
            }

            p1.FuelTimer.Interval = 17;
            p1.FuelTimer.Tick += new System.EventHandler(this.Fueladder_Tick);

            p2.FuelTimer.Interval = 17;
            p2.FuelTimer.Tick += new System.EventHandler(this.Fueladder2_Tick);

            switch(map) {

                case Map.Standard:
                    circuit = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Standard/circuit.png")));
                    colormap = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Standard/colormap.png")));
                    checkpoints = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Standard/checkpoints.png")), new Size(form.ClientSize.Width, form.ClientSize.Height));
                    wallmap = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Standard/wallmap.png")), new Size(form.ClientSize.Width, form.ClientSize.Height));
                    break;
                case Map.Donut_Plains:
                    circuit = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Donut_Plains/circuit.png")));
                    colormap = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Donut_Plains/colormap.png")));
                    checkpoints = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Donut_Plains/checkpoints.png")), new Size(form.ClientSize.Width, form.ClientSize.Height));
                    wallmap = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Donut_Plains/wallmap.png")), new Size(form.ClientSize.Width, form.ClientSize.Height));
                    break;
                case Map.Ghost_Valley:
                    circuit = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Ghost_Valley/circuit.png")));
                    colormap = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Ghost_Valley/colormap.png")));
                    checkpoints = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Ghost_Valley/checkpoints.png")), new Size(form.ClientSize.Width, form.ClientSize.Height));
                    wallmap = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Ghost_Valley/wallmap.png")), new Size(form.ClientSize.Width, form.ClientSize.Height));
                    break;
                case Map.Bowser_Castle:
                    circuit = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Bowsers_Castle/circuit.png")));
                    colormap = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Bowsers_Castle/colormap.png")));
                    checkpoints = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Bowsers_Castle/checkpoints.png")), new Size(form.ClientSize.Width, form.ClientSize.Height));
                    wallmap = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Bowsers_Castle/wallmap.png")), new Size(form.ClientSize.Width, form.ClientSize.Height));
                    break;
                case Map.Choco_Island:
                    circuit = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Choco_Island/circuit.png")));
                    colormap = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Choco_Island/colormap.png")));
                    checkpoints = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Choco_Island/checkpoints.png")), new Size(form.ClientSize.Width, form.ClientSize.Height));
                    wallmap = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Choco_Island/wallmap.png")), new Size(form.ClientSize.Width, form.ClientSize.Height));
                    break;
                case Map.Koopa_Beach:
                    circuit = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Koopa_Beach/circuit.png")));
                    colormap = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Koopa_Beach/colormap.png")));
                    checkpoints = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Koopa_Beach/checkpoints.png")), new Size(form.ClientSize.Width, form.ClientSize.Height));
                    break;
                case Map.Vanilla_Lake:
                    circuit = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Vanilla_Lake/circuit.png")));
                    colormap = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Vanilla_Lake/colormap.png")));
                    checkpoints = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Vanilla_Lake/checkpoints.png")), new Size(form.ClientSize.Width, form.ClientSize.Height));
                    wallmap = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Vanilla_Lake/wallmap.png")), new Size(form.ClientSize.Width, form.ClientSize.Height));
                    break;
                case Map.Rainbow_Road:
                    circuit = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Rainbow_Road/circuit.png")));
                    colormap = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Rainbow_Road/colormap.png")));
                    checkpoints = new Bitmap(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Rainbow_Road/checkpoints.png")), new Size(form.ClientSize.Width, form.ClientSize.Height));
                    break; 
            }

            //pw.SpinItemBox(p1);
            //pw.Rotate();

        }
        public void Sounds(int i, int l)
        {
            if (i == 0)
            {
                SoundPlayer soundplayer = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, "sounds/Race Fanfare.wav"));
                soundplayer.Play();
            }
            if (i == 3)
            {
                SoundPlayer soundplayer = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, "sounds/Countdown.wav"));
                soundplayer.Play();
            }
            if (i == 7)
            {
                SoundPlayer soundplayer = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, Intro));
                soundplayer.Play();
            }
            if (i == (l + 8))
            {
                SoundPlayer soundtrackplayer = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, SoundTrack));
                soundtrackplayer.Play();
            }
        }

        public void PlaySoundTrack()
        {
            SoundPlayer soundtrackplayer = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, SoundTrack));
            soundtrackplayer.Play();
        }
        public void Execute() {
            rg.Invalidate();
            FuelHandler();
            BorderHandler();
            p2.Move(form);
            p1.Move(form);
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

            p1.PowerupHandler(this);
            p2.PowerupHandler(this);

            foreach(Powerup pw in Powerups) {
                pw.Collision(this, p1);
                pw.Collision(this, p2);
                pw.AddCount();
            }

            foreach(Banana ban in BananaItems) {
                if(!p1.Hit) ban.Collision(p1);
                if(!p2.Hit) ban.Collision(p2);
            }

            foreach(Shell she in ShellItems) {
                if(!p1.Hit) she.Collision(p1);
                if(!p2.Hit) she.Collision(p2);
            }
        }

        public void ColorHandler() {
            p1.HandleColor(colormap);
            p2.HandleColor(colormap);
            if(map != Map.Koopa_Beach && map != Map.Rainbow_Road) {
                p1.HandleWalls(wallmap);
                p2.HandleWalls(wallmap);
            }
        }
        
        public void FuelHandler()
        {
            Fueling(p1, p1.FuelBox);
            Fueling(p2, p2.FuelBox);
        }

        public void Fueling(Player a, PictureBox b)
        {
            a.Fuel -= Math.Abs(Convert.ToInt16(a.Speed));
            Size fuelboxsize = new Size(a.Fuel / 250 * 19 / 10, 18);
            b.Size = fuelboxsize;
            if(a.Fuel <= 2500) {
                b.BackColor = Color.Yellow;
            }else {
                b.BackColor = Color.Red;
            }
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
            foreach(Powerup pw in Powerups) {
                pw.Draw(e.Graphics);
            }

            foreach(Banana ban in BananaItems) {
                ban.Draw(e.Graphics);
            }

            try {
                foreach(Shell she in ShellItems) {
                    she.Draw(e.Graphics, wallmap);
                }
            }catch(Exception) { }
            //e.Graphics.Dispose();


            if(p1.Y < p2.Y) {
                p2.DrawPlayer(e.Graphics);
                e.Graphics.ResetTransform();
                p1.DrawPlayer(e.Graphics);
                e.Graphics.ResetTransform();
            } else {
                p1.DrawPlayer(e.Graphics);
                e.Graphics.ResetTransform();
                p2.DrawPlayer(e.Graphics);
                e.Graphics.ResetTransform();
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
            
            //double speed = Math.Sqrt(Math.Pow(a.SpeedX, 2) + Math.Pow(a.SpeedY, 2));
            double speed =  (149 / 14) * a.Speed;
            b.Width = Convert.ToInt32(speed);
        }

        public void Checkpointhandler()
        {
            p1.CheckpointChecker(this, checkpoints);
            p2.CheckpointChecker(this, checkpoints);
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
            bool iscolliding = CircleCollision(p1.rect, p2.rect);
            if(iscolliding == true)
            {
                p1.X += (p1.X - p2.X) * (Math.Abs(p2.Speed) / 9 + 0.4f) / 4;
                p1.Y += (p1.Y - p2.Y) * (Math.Abs(p2.Speed) / 9 + 0.4f) / 4;
                p2.X += (p2.X - p1.X) * (Math.Abs(p1.Speed) / 9 + 0.4f) / 4;
                p2.Y += (p2.Y - p1.Y) * (Math.Abs(p1.Speed) / 9 + 0.4f) / 4;
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

        }

    }

