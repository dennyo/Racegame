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
        public bool FinishPassed = false;
        private int totalCheckpoints;
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
        public bool Finished = false;
        public bool GameEnded = false;
        public bool Brake = false;
        public bool Gas = false;
        private bool UpActive = false;
        private bool DownActive = false;
        private bool RightActive = false;
        private bool LeftActive = false;
        private bool horn = false;
        private string name;
        //wat
        public string p1char;
        public string p2char;
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
        Dictionary<int[], ColorHandler> kleuren = new Dictionary<int[], ColorHandler>();
        List<int> checkpointsPassed = new List<int>();
        Location lastCheckpoint;


        public Player(string name, Character character, Graphics g, Form main, Bitmap imagew, Keys up, Keys down, Keys right, Keys left, Keys action, int x, int y, int width, int height, PictureBox fuel, PictureBox healthBox, PictureBox groen, PictureBox itembox, PictureBox itemframe, System.Windows.Forms.Timer fuelTimer, Label speedLabel, Label rondeLabel, int totalCheckpoints) {
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
            this.name = name;
            this.HealthBox = healthBox;
            this.rect = new Rectangle(0, 0, Width, Width);
            this.totalCheckpoints = totalCheckpoints;

            main.KeyDown += ControlDownHandler;
            kleuren.Add(new int[3] {255, 150, 0}, ColorHandler.Pitstop);
            kleuren.Add(new int[3] {0, 255, 0}, ColorHandler.Gras);
            kleuren.Add(new int[3] {255, 255, 0 }, ColorHandler.Finish);

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

        public string getCharacterUrl(Character ch, int number)
        {
            switch (ch)
            {
                case Character.David:
                    return "cars/D" + number + ".png";

                case Character.Jos:
                    return "cars/Jos" + number + ".png";

                case Character.Fiona:
                    return "cars/fiona" + number + ".png";

                case Character.Jop:
                    return "cars/jop" + number + ".png";

                case Character.Sibbele:
                    return "cars/sibbele" + number + ".png";

                case Character.Joris:
                    return "cars/joris" + number + ".png";

                case Character.Nynke:
                    return "cars/nynke" + number + ".png";

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
                g.DrawRectangle(pen, new Rectangle(0, 0, Width, Width));
                g.DrawEllipse(pen, new Rectangle(0 , 0, Width, Width));
                g.DrawRectangle(pen, new Rectangle(0, 0, Width, Width));*/

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
                    Speed += 0.2f;
                }
            }

            if((!Gas && !Brake) || Speed > MaxSpeed) {
                if(Speed > -1 && Speed < 1) {
                    Speed = 0;
                }
                if(Speed < 0) {
                    Speed += 0.5f;
                }else if(Speed > 0) {
                    Speed -= 0.5f;
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
            if((LeftActive) || (RightActive && DownActive)) {
                Angle -= Math.Abs(2 * Math.Abs(Speed) / 7 + 1);
            }
            if((RightActive) || (LeftActive && DownActive)) {
                Angle += Math.Abs(2 * Math.Abs(Speed) / 7 + 1);
            }
            Console.WriteLine(GameEnded);
            if(!GameEnded) {
                MaxSpeed = 9;
            }

        }

        public void FinishHandler(Label message, Bitmap image) {
            int xCenter = (int) (X + Width / 2);
            int yCenter = (int) (Y + Height / 2);
            Color col = image.GetPixel(xCenter, yCenter);

            if(checkpointsPassed.Count == totalCheckpoints && getColor(col.R, col.G, col.B) == ColorHandler.Finish) {
                laps++;
                Console.WriteLine("Lap: " + laps);
                checkpointsPassed.Clear();
                if (laps >= 4) {
                    Finished = true;
                    message.Visible = true;
                    message.Text = name + " wins!";
                }
            }
        }
        	
        public void CheckpointChecker(Bitmap image) {
            
            int xCenter = (int) (X + Width / 2);
            int yCenter = (int) (Y + Height / 2);
            Color col = image.GetPixel(xCenter, yCenter);
            if(col.R % 5 == 0 && col.G == 0 && col.B == 0 && col.R >= 255 - totalCheckpoints * 10) {
                if(!checkpointsPassed.Contains(col.R)){
                    checkpointsPassed.Add(col.R);
                    lastCheckpoint = new Location(X, Y, Angle);
                    Console.WriteLine("Check: " + checkpointsPassed.Count);
                }
            }


        }

        public ColorHandler getColor(int R, int G, int B) {
            foreach(int[] color in kleuren.Keys) {
                if(color[0] == R && color[1] == G && color[2] == B) {
                    return kleuren[color];
                }
            }
            return ColorHandler.None;
        }

        public void HandleColor(Bitmap image) {


            //Oranje
            //R 255
            //G 150
            //0

            //Groen
            //G 255
            //R 0
            //B 0
            
            int xCenter = (int) (X + Width / 2);
            int yCenter = (int) (Y + Height / 2);
            Color col = image.GetPixel(xCenter, yCenter);

            switch(getColor(col.R, col.G, col.B)) {

                case ColorHandler.Gat:

                    break;

                case ColorHandler.Gras:
                    MaxSpeed = 5;
                    break;

                case ColorHandler.Water:

                    break;

                case ColorHandler.Pitstop:
                    MaxSpeed = 3;
                    if(Health > 90) {
                        Health = 100;
                    }else if(Health < 100) {
                        Health += 10;
                    }

                    if(Fuel > 9900) {
                        Fuel = 10000;
                    }else if(Fuel < 10000) {
                        Fuel += 100;
                    }
                    break;

                default:

                    break;
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

                if (Character == Character.Jos) {
                    sound = "r2d2.wav";
                }

                //PlaySound(sound);
            }

        }

        /*
        Kleiner maken van plaatje
                
                if(Width > 0) {
                    Width--;
                    X++;
                }
                if(Height > 0) {
                    Height--;
                    Y++;
                }
                */
        
        public void PlaySound(string sound) {
            new System.Threading.Thread(() => {
                var c = new System.Windows.Media.MediaPlayer();
                c.Open(new System.Uri(Path.Combine(Environment.CurrentDirectory, sound)));
                c.Play();

            }).Start();
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
