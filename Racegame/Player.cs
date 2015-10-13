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
        public int laps = 0;
        public int X;
        public int Y;
        private int MaxSize;
        public int Height;
        public int Width;
        public int SpeedX = 0;
        public int SpeedY = 0;
        public int Health = 100;
        public int Fuel = 10000;
        public float Angle = 0f;
        public Keys up, down, right, left;
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
            //t.FillRectangle(new SolidBrush(Color.Green), 0, 0, Width, Height);
            t.DrawImage(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "car.jpg")), new Point(0, 0));
            image = new Bitmap(temp);
            temp.Save(Path.Combine(Environment.CurrentDirectory, "test.jpg"));
            t.Dispose();

        }

        public void DrawPlayer(Graphics g) {
            g.DrawImage(RotateImage(), X, Y);
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

        public void Move(Form form) {
            form.Invalidate();
            if(UpActive) {
                //X += (int)(10 * Math.Cos(Angle));
                //Y += (int)(10 * Math.Sin(Angle));
                Console.WriteLine(Angle);
                if(SpeedX > 0 && SpeedY > 0) {
                    if((Angle > -80 && Angle < -10 ) || (Angle > 280 && Angle < 360)){
                        //Move right upper
                        X += SpeedX;
                        Y -= SpeedY;
                    }else if((Angle < 80 && Angle > 10) || (Angle < -280 && Angle > -360)){
                        //Move right lower
                        Y += SpeedY;
                        X += SpeedX;
                    }else if(Angle <= 10 && Angle >= -10){
                        //Move right
                        X += SpeedX;
                    }else if((Angle <= -80 && Angle >= -100) || (Angle >= 260 && Angle <= 280)) {
                        //Move up
                        Y -= SpeedY;
                    }else if((Angle < -100 && Angle > -170) || (Angle > 190 && Angle < 260)) {
                        //Move left upper
                        X -= SpeedX;
                        Y -= SpeedY;
                    }else if((Angle > -260 && Angle < -190) || (Angle > 100 && Angle < 170)) {
                        //Move left lower
                        Y += SpeedX;
                        X -= SpeedY;
                    }else if((Angle >= -190 && Angle <= -160) || (Angle > 170 && Angle < 190)) {
                        //Move left
                        X -= SpeedX;
                    }else if((Angle >= -280 && Angle <= -260) || (Angle <= 100 && Angle >= 80)) {
                        //Down
                        Y += SpeedY;
                    }
                }
            }
                /*if((Angle < 90 && Angle > 0) || (Angle > -360 && Angle < -270)) {
                    //Console.WriteLine("Right lower");
                    X += 1;
                    Y -= 1;
                }else if((Angle > 90 && Angle < 180) || (Angle > -270 && Angle < -180)) {
                    //Console.WriteLine("Left lower");
                    X -= 1;
                    Y -= 1;
                }else if((Angle > 180 && Angle < 270) || (Angle > -180 && Angle < -90)) {
                    //Console.WriteLine("Left upper");
                    X -= 1;
                    Y += 1;
                }else if((Angle > 270 && Angle < 360) || (Angle > -90 && Angle < 0)) {
                    //Console.WriteLine("Right upper");
                    X += 1;
                    Y += 1;
                }else if(Angle == 0 || Angle == 360 || Angle == -360) {
                    X+= 1;
                }else if(Angle == 90 || Angle == -270) {
                    Y -= 1;
                }else if(Angle == 180 || Angle == -180) {
                    X -= 1;
                }*/
                
                

            //}
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
                SpeedX = 4;
                SpeedY = 4;
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
                SpeedY = 0;
                SpeedX = 0;
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
