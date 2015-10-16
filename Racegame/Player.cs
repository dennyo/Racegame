using Racegame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
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
        public Rectangle rect;
        public float SpeedX = 0;
        public float SpeedY = 0;
        public int MaxSpeed = 9;
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
        public Character Character;
        private Form Main;
        public PictureBox FuelBox;
        public PictureBox HealthBox;
        public PictureBox Groen;
        public PictureBox ItemBox;
        public PictureBox ItemFrame;
        public Label SpeedLabel;
        public Label RondeLabel;
        public System.Windows.Forms.Timer FuelTimer;
        double[] angles = new double[23] {8.65, 23.35, 35.45, 47.55, 59.65, 71.75, 83.85, 96.15, 108.25, 120.35, 132.45, 144.55, 156.65, 171.35, 191.25, 213.75, 236.25, 258.75, 281.25, 303.75, 326.25, 348.75, 368.65};


        public Player(Character character, Graphics g, Form main, Bitmap imagew, Keys up, Keys down, Keys right, Keys left, Keys action, int x, int y, int width, int height, PictureBox fuel, PictureBox healthBox, PictureBox groen, PictureBox itembox, PictureBox itemframe, System.Windows.Forms.Timer fuelTimer, Label speedLabel, Label rondeLabel) {
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
            this.MaxSize = width;
            this.Character = character;
            this.Main = main;
            this.FuelBox = fuel;
            this.Groen = groen;
            this.ItemBox = itembox;
            this.ItemFrame = itemframe;
            this.FuelTimer = fuelTimer;
            this.SpeedLabel = speedLabel;
            this.RondeLabel = rondeLabel;
            this.HealthBox = healthBox;
            this.rect = new Rectangle(0, 0, Width, Width);


        main.KeyDown += ControlDownHandler;
            main.KeyUp += new System.Windows.Forms.KeyEventHandler(ControlUpHandler);

            //Temporary code for a rectangle player.
            Image temp = new Bitmap(MaxSize, MaxSize);
            Graphics t = Graphics.FromImage(temp);
            //t.FillRectangle(new SolidBrush(Color.Green), 0, 0, Width, Height);
            t.DrawImage(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Schw1.png")), new Rectangle(new Point(0, 0), new Size(Width, Height)));
            image = new Bitmap(temp);
            temp.Save(Path.Combine(Environment.CurrentDirectory, "test.jpg"));
            t.Dispose();

        }
        
        public string getCharacterUrl(Character ch, int number) {
            switch(ch) {
                case Character.Jos:
                    return "cars/jos" + number + ".png";

                case Character.Fiona:
                    return "cars/fiona" + number + ".png";

                case Character.David:
                    return "cars/D" + number + ".png";

                case Character.Jop:
                    return "cars/jop" + number + ".png";

                case Character.Nynke:
                    return "cars/nynke" + number + ".png";

                case Character.Sibbele:
                    return "cars/sibbele" + number + ".png";

                case Character.Joris:
                    return "cars/joris" + number + ".png";

                case Character.Dick:
                    return "cars/dick" + number + ".png";

                default:
                    return "";

            }
        }

        public void DrawPlayer(Graphics g) {
            g.DrawImage(RotateImage(), X, Y);
        }

        private Bitmap RotateImage() {
            Bitmap toReturn = new Bitmap(Width, Width);

            using(Graphics g = Graphics.FromImage(toReturn)){
                //g.TranslateTransform(tempx, tempy);
                //g.RotateTransform(Angle);
                //g.TranslateTransform(- tempx, - tempy);
                /*int number = 0;
                if(Angle < 0) {
                    number = (int) Math.Floor((Math.Abs(Angle) + 90) / (360 / 21) + 1);
                }else {
                    number = (int) Math.Floor((Angle + 90) / (360 / 21) + 1);
                }*/
                /*int number = (int) Math.Abs(Math.Floor((Math.Abs(Angle > 0 ? 360 - Angle : Angle) + 90) / (360 / 21)) + 1);
                if(number >= 23) number = number - 22;*/
                

                Image img = Image.FromFile(Path.Combine(Environment.CurrentDirectory, getCharacterUrl(this.Character, getImageNumber(Angle))));
                g.DrawImage(img, new Rectangle(new Point(0, 0), new Size(Width, Height)));

                //Outline box
                /*Pen pen = new Pen(Color.Black, 2);
                pen.Alignment = PenAlignment.Inset; //<-- this
<<<<<<< HEAD
                g.DrawRectangle(pen, new Rectangle(0, 0, Width, Width));
                g.DrawEllipse(pen, new Rectangle(0 , 0, Width, Width));
=======
                g.DrawRectangle(pen, new Rectangle(0, 0, Width, Width));*/
>>>>>>> 44d128ab63bef140d3b0466ab22584c468a4b31a

                //Center red dot.
                //g.FillRectangle(new SolidBrush(Color.Red), tempx, tempy, 1, 1);

                g.Dispose();
            }

            return toReturn;

        }

	    public bool isBetween(double angle1, double angle2, double check){
		    return angle1 < angle2 ? check >= angle1 && check <= angle2 : check <= angle1 && check >= angle2;
	    }

        public int getImageNumber(double angle) {
            if(angle > 360) {
                angle = angle - 360;
            }else if(angle < 0) {
                angle = Math.Abs(360 + angle);
            }
            angle = 360 - angle;

            if(angle > 8.65 && angle <= 23.35) return 6;
            if(angle > 23.35 && angle <= 35.45) return 7;
            if(angle > 35.45 && angle <= 47.55) return 8;
            if(angle > 47.55 && angle <= 59.65) return 9;
            if(angle > 59.65 && angle <= 71.75) return 10;
            if(angle > 71.75 && angle <= 83.85) return 11;
            if(angle > 83.85 && angle <= 96.15) return 12;
            if(angle > 96.15 && angle <= 108.25) return 13;
            if(angle > 108.25 && angle <= 120.35) return 14;
            if(angle > 120.35 && angle <= 132.45) return 15;
            if(angle > 132.45 && angle <= 144.55) return 16;
            if(angle > 144.55 && angle <= 156.65) return 17;
            if(angle > 156.65 && angle <= 171.35) return 18;
            if(angle > 171.35 && angle <= 191.25) return 19;
            if(angle > 191.25 && angle <= 213.75) return 20;
            if(angle > 213.75 && angle <= 236.25) return 21;
            if(angle > 236.25 && angle <= 258.75) return 22;
            if(angle > 258.75 && angle <= 281.25) return 1;
            if(angle > 281.25 && angle <= 303.75) return 2;
            if(angle > 303.75 && angle <= 326.25) return 3;
            if(angle > 326.25 && angle <= 348.75) return 4;
            if(angle > 348.75 || angle <= 8.65) return 5;

            return 1;
        }
	

        public void Move(Form form) {
            form.Invalidate();

            if(Gas) {
                if(SpeedX <= MaxSpeed && SpeedY <= MaxSpeed && Speed < MaxSpeed) {
<<<<<<< HEAD
                    Speed += 0.5f;
=======
                    Speed += 0.2f;
>>>>>>> 44d128ab63bef140d3b0466ab22584c468a4b31a
                }
            }

            if(!Gas && !Brake) {
                if(Speed > -1 && Speed < 1) {
                    Speed = 0;
                }
                if(Speed < 0) {
                    Speed += 0.2f;
                }else if(Speed > 0) {
                    Speed -= 0.2f;
                }
            }

            if(Brake && Speed > - MaxSpeed) {
                Speed -= 0.2f;
            }

            SpeedX = (float) Speed * ((float)Math.Cos(Math.PI / 180 * Angle));
            SpeedY = (float) Speed * ((float)Math.Sin(Math.PI / 180 * Angle));
            X += SpeedX;
            Y += SpeedY;
            

            if(Angle <= -356 || Angle >= 356) {
                Angle = 0;
            }
            if(LeftActive) {
                Angle -= Math.Abs(2 * Math.Abs(Speed) / 7 + 1);
            }
            if(RightActive) {
                Angle += Math.Abs(2 * Math.Abs(Speed) / 7 + 1);
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
                string sound = "";
                Random rand = new Random();
                switch(rand.Next(2)) {
                    case 0:
                        sound = "AIRPORN.wav";
                        break;

                    case 1:
                        sound = "WILLIE.wav";
                        break;
                }
                SoundPlayer player = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, sound));
                player.Play();

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
