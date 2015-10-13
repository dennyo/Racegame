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
    class Player {

        public int X;
        public int Y;
        private int MaxSize;
        public int Height;
        public int Width;
        public float Angle = 0f;
        private Keys up, down, right, left;
        private bool UpActive = false;
        private bool DownActive = false;
        private bool RightActive = false;
        private bool LeftActive = false;
        public Graphics g;
        private Bitmap image;

        public Player(Graphics g, Bitmap imagew, Keys up, Keys down, Keys right, Keys left, int x, int y, int width, int height) {
            this.X = x;
            this.Y = y;
            this.up = up;
            this.down = down;
            this.right = right;
            this.left = left;
            this.Width = width;
            this.Height = height;
            this.g = g;
            this.MaxSize = (int) Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2));

            //Temporary code for a rectangle player.
            Image temp = new Bitmap(Width, Width);
            Graphics t = Graphics.FromImage(temp);
            t.FillRectangle(new SolidBrush(Color.Green), 0, 0, Width, Height);
            image = new Bitmap(temp);
            temp.Save(Path.Combine(Environment.CurrentDirectory, "test.jpg"));
            t.Dispose();
            DrawPlayer(g);

        }

        public void DrawPlayer(Graphics g) {
            g.DrawImage(RotateImage(), X, Y);
            g.Dispose();
            Console.WriteLine(Angle);
        }

        private Bitmap RotateImage() {
            MaxSize = (int) Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2));
            MaxSize = (int)(MaxSize * 1.34);
            int tempx = (int) (MaxSize / 4.0f + MaxSize / 4);
            int tempy = (int) (MaxSize / 4.0f + MaxSize / 4);

            Bitmap toReturn = new Bitmap(MaxSize, MaxSize);

            using(Graphics g = Graphics.FromImage(toReturn)){
                g.TranslateTransform(tempx, tempy);
                g.RotateTransform(Angle);
                g.TranslateTransform(- tempx, - tempy);
                g.DrawImage(image, new Point((MaxSize - Width) / 3, (MaxSize - Height) / 2));

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

        public void Move() {
            //if(UpActive) {
                //X += (int)(10 * Math.Cos(Angle));
                //Y += (int)(10 * Math.Sin(Angle));
                //Console.WriteLine(Math.Sin(Angle));
                if((Angle <= 90 && Angle >= 0) || (Angle >= -360 && Angle <= -270)) {
                    //Console.WriteLine("Right lower");
                    Console.WriteLine(X + ":" + Y);
                    Console.WriteLine(Math.Asin(Math.Sin(Angle) * 512));
                }else if((Angle >= 90 && Angle <= 180) || (Angle >= -270 && Angle <= -180)) {
                    //Console.WriteLine("Left lower");
                }else if((Angle >= 180 && Angle <= 270) || (Angle >= -180 && Angle <= -90)) {
                    //Console.WriteLine("Left upper");
                }else if((Angle >= 270 && Angle <= 360) || (Angle >= -90 && Angle <= 0)) {
                    //Console.WriteLine("Right upper");
                //}

            }
            if(Angle <= -356 || Angle >= 356) {
                Angle = 0;
            }
            if(LeftActive) {
                Angle -= 4f;
            }
            if(RightActive) {
                Angle += 4f;
            }
        }

        public void ControlDownHandler(object sender, System.Windows.Forms.KeyEventArgs e) {
            if(e.KeyCode == up) {
                UpActive = true;
            }else if(e.KeyCode == left) {
                LeftActive = true;
            }else if(e.KeyCode == right) {
                RightActive = true;
            }else if(e.KeyCode == down) {
                DownActive = true;
            }

        }
        
        public void ControlUpHandler(object sender, System.Windows.Forms.KeyEventArgs e) {
            if(e.KeyCode == up) {
                UpActive = false;
            }else if(e.KeyCode == left) {
                LeftActive = false;
            }else if(e.KeyCode == right) {
                RightActive = false;
            }else if(e.KeyCode == down) {
                DownActive = false;
            }
        }



    }
}
