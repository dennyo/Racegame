using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaceGame {
   public class Player {

        public bool CheckpointPassed = false;
        public bool FinishPassed = false;
        public int laps = 1;
        public float X;
        public float Y;
        public int MaxSize;
        public int Height;
        public int Width;
        public float SpeedX = 0;
        public float SpeedY = 0;
        public int MaxSpeed = 14;
        public float Speed = 0;
        public int Health = 100;
        public int Fuel = 10000;
        public float Angle = 0f;
        public Keys up, down, right, left, action;
        public bool Brake = false;
        public bool Gas = false;
        private bool UpActive = false;
        private bool DownActive = false;
        private bool RightActive = false;
        private bool LeftActive = false;
        public Graphics g;
        private Bitmap image;

        public Player(Graphics g, Bitmap imagew, Keys up, Keys down, Keys right, Keys left, Keys action, int x, int y, int width, int height) {
            this.X = x;
            this.Y = y;
            this.up = up;
            this.down = down;
            this.right = right;
            this.left = left;
            this.action = action;
            this.Width = width;
            this.Height = height;
            this.g = g;
            this.MaxSize = (int) Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2));

            //Temporary code for a rectangle player.
            Image temp = new Bitmap(Width, Width);
            Graphics t = Graphics.FromImage(temp);
            t.FillRectangle(new SolidBrush(Color.Green), 0, 0, Width, Height);
            //t.DrawImage(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "auto.png")), new Point(0, 0));
            image = new Bitmap(temp);
            temp.Save(Path.Combine(Environment.CurrentDirectory, "test.jpg"));
            t.Dispose();

        }

        public void DrawPlayer(Graphics g) {
            g.DrawImage(RotateImage(), X, Y);
        }

        private Bitmap RotateImage() {
            MaxSize = (int) Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2));
            MaxSize = (int)(MaxSize * 1.4);
            int tempx = (int) (MaxSize / 4.0f + MaxSize / 4);
            int tempy = (int) (MaxSize / 4.0f + MaxSize / 4);

            Bitmap toReturn = new Bitmap(MaxSize, MaxSize);

            using(Graphics g = Graphics.FromImage(toReturn)){
                g.TranslateTransform(tempx, tempy);
                g.RotateTransform(Angle);
                g.TranslateTransform(- tempx, - tempy);
                g.DrawImage(image, new Point((MaxSize - Width) / 3, (MaxSize / 4)));

                //Outline box
                /*Pen pen = new Pen(Color.Black, 2);
                pen.Alignment = PenAlignment.Inset; //<-- this
                g.DrawRectangle(pen, new Rectangle(0, 0, MaxSize, MaxSize)); */

                //Center red dot.
                //g.FillRectangle(new SolidBrush(Color.Red), tempx, tempy, 1, 1);

                g.Dispose();
            }

            return toReturn;

        }

        public void Move(Form form) {
            form.Invalidate();

            if(Gas) {
                if(SpeedX <= MaxSpeed && SpeedY <= MaxSpeed && Speed < MaxSpeed) {
                    Speed += 0.1f;
                }
            }

            if(Brake) {
                Speed -= 0.1f;
            }
            Console.WriteLine(Angle);

            SpeedX = (float) Speed * ((float)Math.Cos(Math.PI / 180 * Angle));
            SpeedY = (float) Speed * ((float)Math.Sin(Math.PI / 180 * Angle));
            X += SpeedX;
            Y += SpeedY;
            

            if(Angle <= -356 || Angle >= 356) {
                Angle = 0;
            }
            if(LeftActive) {
                Angle -= 2 * Speed / 8 + 1;
            }
            if(RightActive) {
                Angle += 2 * Speed / 8 + 1;
            }
        }

        public void ControlDownHandler(object sender, System.Windows.Forms.KeyEventArgs e) {
            if(e.KeyCode == up) {
                Gas = true;
                UpActive = true;
            }
            if (e.KeyCode == left) {
                LeftActive = true;
            }
            if (e.KeyCode == right) {
                RightActive = true;
            }
            if (e.KeyCode == down) {
                DownActive = true;
                Brake = true;
            }
            if(e.KeyCode == action) {
                //Code voor actions hier
            }

        }
        
        public void ControlUpHandler(object sender, System.Windows.Forms.KeyEventArgs e) {
            if(e.KeyCode == up) {
                Gas = false;
                UpActive = false;
            }
            if (e.KeyCode == left) {
                LeftActive = false;
            }
            if (e.KeyCode == right) {
                RightActive = false;
            }
            if (e.KeyCode == down) {
                DownActive = false;
                Brake = false;
            }
        }



    }
}
