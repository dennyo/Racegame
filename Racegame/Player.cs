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
using System.Windows.Media;

namespace RaceGame {
   public class Player {
        public bool FinishPassed = false;
        private int totalCheckpoints;
        public int laps = 1;
        public float X;
        public float Y;
        public int Height;
        public int Width;
        public Rectangle rect;
        public float SpeedX = 0;
        public float SpeedY = 0;
        public int MaxSpeed = 9;
        public float Speed = 0;
        public int Health = 100;
        public int Fuel = 7500;
        public int PitstopCounter = 0;
        public float Angle = 0f;
        public Keys up, down, right, left, action;
        public bool Finished = false;
        public bool GameEnded = false;
        public bool Brake = false;
        public bool Gas = false;
        public bool Collision = false;
        private bool UpActive = false;
        private bool DownActive = false;
        private bool RightActive = false;
        private bool LeftActive = false;
        private bool horn = false;
        private bool Horn = false;
        private bool ActivatePowerup = false;
        private bool SpeedBoost = false;
        public bool Immune = false;
        public bool Hit = false;
        public bool IsPitstop = false;
        private string name;
        private Bitmap image;
        public bool HasItem = false;
        public Character Character;
        private Form Main;
        public PictureBox FuelBox;
        public PowerupItem currentPowerup = PowerupItem.None;
        public PictureBox ItemFrame;
        public Label SpeedLabel;
        public System.Windows.Forms.Timer FuelTimer;
        double[] angles = new double[23] {8.65, 23.35, 35.45, 47.55, 59.65, 71.75, 83.85, 96.15, 108.25, 120.35, 132.45, 144.55, 156.65, 171.35, 191.25, 213.75, 236.25, 258.75, 281.25, 303.75, 326.25, 348.75, 368.65};
        Dictionary<int[], ColorHandler> kleuren = new Dictionary<int[], ColorHandler>();
        SoundPlayer FinishPlayer = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, "sounds/Finish Tune.wav"));
        List<int> checkpointsPassed = new List<int>();
        Location lastCheckpoint;
        private MediaPlayer HornPlayer;
        public Label lapCounter;
        private Location start;
        public string victory;


        public Player(string name, Character character, Form main, Bitmap imagew, Keys up, Keys down, Keys right, Keys left, Keys action, PictureBox fuel, PictureBox itemframe, System.Windows.Forms.Timer fuelTimer, Label speedLabel, int totalCheckpoints, Location start) {
            this.up = up;
            this.down = down;
            this.right = right;
            this.left = left;
            this.action = action;
            this.Character = character;
            this.Main = main;
            this.FuelBox = fuel;
            this.ItemFrame = itemframe;
            this.FuelTimer = fuelTimer;
            this.SpeedLabel = speedLabel;
            this.name = name;
            this.Width = 64;
            this.Height = 64;
            this.start = start;
            this.rect = new Rectangle(0, 0, Width, Width);
            this.totalCheckpoints = totalCheckpoints;
            checkpointsPassed.Add(255);
            this.X = start.X;
            this.Y = start.Y;
            this.Angle = start.Angle;
            //lastCheckpoint zetten
            main.KeyDown += ControlDownHandler;
            kleuren.Add(new int[3] {255, 150, 0}, ColorHandler.Pitstop);
            kleuren.Add(new int[3] {0, 255, 0}, ColorHandler.Gras);
            kleuren.Add(new int[3] {255, 255, 0 }, ColorHandler.Finish);
            kleuren.Add(new int[3] {255, 0, 255 }, ColorHandler.Gat);


            kleuren.Add(new int[3] {255, 0, 150 }, ColorHandler.Wall_Red);
            kleuren.Add(new int[3] {0, 255, 150 }, ColorHandler.Wall_Green);
            kleuren.Add(new int[3] {150, 0, 255 }, ColorHandler.Wall_Blue);
            kleuren.Add(new int[3] {0, 255, 255 }, ColorHandler.Wall_Light_Blue);

            main.KeyDown += ControlDownHandler;
            main.KeyUp += new System.Windows.Forms.KeyEventHandler(ControlUpHandler);
            VictoryTune(Character);
        }

        public string getCharacterUrl(Character ch, int number)
        {
            switch (ch)
            {
                case Character.David:
                    return "cars/david/D" + number + ".png";

                case Character.Jos:
                    return "cars/jos/Jos" + number + ".png";

                case Character.Fiona:
                    return "cars/fiona/F" + number + ".png";

                case Character.Jop:
                    return "cars/jop/Jop" + number + ".png";

                case Character.Sibbele:
                    return "cars/sibbele/Sib" + number + ".png";

                case Character.Joris:
                    return "cars/joris/Joris" + number + ".png";

                case Character.Nynke:
                    return "cars/nynke/F" + number + ".png";

                case Character.Dick:
                    return "cars/dick/D" + number + ".png";

                default:
                    return "";

            }
        }

        public void VictoryTune(Character ch)
        {
            switch (ch)
            {
                case Character.David:
                    victory = "sounds/David_Victory.wav";
                    break;
                case Character.Jos:
                    victory = "sounds/Jos_Victory.wav";
                    break;
                case Character.Fiona:
                    victory = "sounds/Fiona_Victory.wav";
                    break;
                case Character.Jop:
                    victory = "sounds/Jop_Victory.wav";
                    break;
                case Character.Sibbele:
                    victory = "sounds/Sibbele_Victory.wav";
                    break;
                case Character.Joris:
                    victory = "sounds/Joris_Victory.wav";
                    break;
                case Character.Nynke:
                    victory = "sounds/Nynke_Victory.wav";
                    break;
                case Character.Dick:
                    victory = "sounds/Dick_Victory.wav";
                    break;
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


            if(Horn) {
            }

            if(Gas && !Hit) {
                if(SpeedX <= MaxSpeed && SpeedY <= MaxSpeed && Speed < MaxSpeed) {
                    if(SpeedBoost) {
                        Speed += 0.8f;
                    }else {
                        Speed += 0.2f;
                    }
                }
            }

            if(((!Gas && !Brake) || Speed > MaxSpeed)) {
                if(Speed > -1 && Speed < 1) {
                    Speed = 0;
                }
                if(Speed < 0 || Hit) {
                    Speed += 0.5f;
                }else if(Speed > 0 || Hit) {
                    Speed -= 0.5f;
                }
            }

            if((Brake || (Hit && Speed > 0)) && Speed > - MaxSpeed) {
                Speed -= 0.2f;
            }

            SpeedX = (float) Speed * ((float)Math.Cos(Math.PI / 180 * Angle));
            SpeedY = (float) Speed * ((float)Math.Sin(Math.PI / 180 * Angle));
            X += SpeedX;
            Y += SpeedY;
            

            if(Angle <= -356 || Angle >= 356) {
                Angle = 0;
            }
            if(((LeftActive && !DownActive) || (RightActive && DownActive && Speed < 0)) && Speed != 0 && !Hit) {
                Angle -= Math.Abs(3 * Math.Abs(Speed) / 7 + 1);
            }
            if (((RightActive && !DownActive) || (LeftActive && DownActive && Speed < 0)) && Speed != 0 && !Hit) {
                Angle += Math.Abs(3 * Math.Abs(Speed) / 7 + 1);
            }
            if(!GameEnded && !Hit && !Collision) {
                MaxSpeed = 9;
            }
            if(GameEnded) {
                MaxSpeed = 0;
            }

        }
        
        public async void FinishHandler(Label message, Bitmap image)
        {
            int xCenter = (int)(X + Width / 2);
            int yCenter = (int)(Y + Height / 2);
            System.Drawing.Color col = image.GetPixel(xCenter, yCenter);

            if (checkpointsPassed.Count == totalCheckpoints && getColor(col.R, col.G, col.B) == ColorHandler.Finish)
            {
                laps++;
                checkpointsPassed.Clear();

                //if(laps != 0 && laps < 6) lapCounter.Image = new Bitmap(Path.Combine(Environment.CurrentDirectory, "laps/" + laps + ".png"));

                if (laps >= 6)
                {
                    Finished = true;
                    FinishPlayer.Play();
                    await WaitMethod();
                    message.Visible = true;
                    if (Character == Character.David)
                    {
                        message.Image = new Bitmap(Path.Combine(Environment.CurrentDirectory, "textboxes/DavidWins.png"));
                    }
                    if (Character == Character.Jos)
                    {
                        message.Image = new Bitmap(Path.Combine(Environment.CurrentDirectory, "textboxes/JosWins.png"));
                    }
                    if (Character == Character.Fiona)
                    {
                        message.Image = new Bitmap(Path.Combine(Environment.CurrentDirectory, "textboxes/FionaWins.png"));
                    }
                    if (Character == Character.Jop)
                    {
                        message.Image = new Bitmap(Path.Combine(Environment.CurrentDirectory, "textboxes/JopWins.png"));
                    }
                    if (Character == Character.Sibbele)
                    {
                        message.Image = new Bitmap(Path.Combine(Environment.CurrentDirectory, "textboxes/SibbeleWins.png"));
                    }
                    if (Character == Character.Joris)
                    {
                        message.Image = new Bitmap(Path.Combine(Environment.CurrentDirectory, "textboxes/JorisWins.png"));
                    }
                    if (Character == Character.Nynke)
                    {
                        message.Image = new Bitmap(Path.Combine(Environment.CurrentDirectory, "textboxes/NynkeWins.png"));
                    }
                    if (Character == Character.Dick)
                    {
                        message.Image = new Bitmap(Path.Combine(Environment.CurrentDirectory, "textboxes/DickWins.png"));
                    }
                    await WaitMethod2();
                    SoundPlayer Victory = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, victory));
                    Victory.PlayLooping();
                }
            }
        }
        async System.Threading.Tasks.Task WaitMethod()
        {
            await System.Threading.Tasks.Task.Delay(2000);
        }
        async System.Threading.Tasks.Task WaitMethod2()
        {
            await System.Threading.Tasks.Task.Delay(3000);
        }
        public void CheckpointChecker(Game g, Bitmap image) {
            if(lastCheckpoint == null) lastCheckpoint = (g.RespawnPoints.Count == 0 ? start : g.RespawnPoints[0]);
            int xCenter = (int) (X + Width / 2);
            int yCenter = (int) (Y + Height / 2);

            System.Drawing.Color col = image.GetPixel(xCenter, yCenter);
            if(col.R % 5 == 0 && col.G == 0 && col.B == 0 && col.R >= 255 - totalCheckpoints * 10) {
                if(!checkpointsPassed.Contains(col.R)) checkpointsPassed.Add(col.R);
                if(g.RespawnPoints.Count > 0) lastCheckpoint = g.RespawnPoints[checkpointsPassed.Count - 1];
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

        public void HandleWalls(Bitmap image) {
            int xCenter = (int) (X + Width / 2);
            int yCenter = (int) (Y + (Height /3 * 2));
            System.Drawing.Color col = image.GetPixel(xCenter, yCenter);

            switch(getColor(col.R, col.G, col.B)) {
                
                case ColorHandler.Wall_Red:
                    X -= Math.Abs(Speed);
                    //X -= Math.Abs(Speed) + 10;
                    break;

                case ColorHandler.Wall_Green:
                    //X += Math.Abs(Speed) + 10;
                    X += Math.Abs(Speed);
                    break;
                    
                case ColorHandler.Wall_Blue:
                    //Y += Math.Abs(Speed) + 10;
                    Y += Math.Abs(Speed);
                    break;

                case ColorHandler.Wall_Light_Blue:
                    //Y -= Math.Abs(Speed) + 10;
                    Y -= Math.Abs(Speed);
                    break;

            }


        }

        public async void HandleColor(Bitmap image) {


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
            System.Drawing.Color col = image.GetPixel(xCenter, yCenter);
            //Console.WriteLine(temp);
            switch(getColor(col.R, col.G, col.B)) {

                case ColorHandler.Gat:
                    if(!Hit) {
                        Hit = true;
                        MaxSpeed = 0;
                        Speed = 0;


                        Thread t = new Thread(() => {
                            while(Width > 2 || Height > 2) {
                                Width -= 2;
                                X++;
                                Height -= 2;
                                Y++;
                                Thread.Sleep(20);
                            }
                        });
                        t.IsBackground = true;
                        t.Start();

                        await Task.Delay(1500);

                        X = lastCheckpoint.X;
                        Y = lastCheckpoint.Y;
                        Angle = lastCheckpoint.Angle;
                        Width = 64;
                        Height = 64;
                        Hit = false;
                        await Task.Delay(100);
                    }   
                    break;

                case ColorHandler.Gras:
                    if(!SpeedBoost) MaxSpeed = 5;
                    break;

                case ColorHandler.Water:
                    if(!SpeedBoost) MaxSpeed = 5;
                    break;

                case ColorHandler.Pitstop:
                    if(!IsPitstop) PitstopCounter++;
                    IsPitstop = true;
                    MaxSpeed = 3;
                    if(Health > 90) {
                        Health = 100;
                    }else if(Health < 100) {
                        Health += 10;
                    }

                    if(Fuel > 7400) {
                        Fuel = 7500;
                    }else if(Fuel < 7500) {
                        Fuel += 100;
                    }
                    break;

                case ColorHandler.None:
                    IsPitstop = false;
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
                if(currentPowerup != PowerupItem.None && !Hit) ActivatePowerup = true;

                /*string sound = "";
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

                HornSound = sound;
                if(HornEnded) Horn = true;*/

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

        public async void PowerupHandler(Game g) {
            if(!ActivatePowerup) return; 
            ActivatePowerup = false;
            PowerupItem temp = currentPowerup;
            currentPowerup = PowerupItem.None;
            ItemFrame.Image = null;

            int XTemp = (int) (X - Speed * ((float)Math.Cos(Math.PI / 180 * Angle)));
            int YTemp = (int) (Y - Speed * ((float)Math.Sin(Math.PI / 180 * Angle)));

            switch(temp) {
                //Doe dingen hier met het geselecteerde item
                case PowerupItem.Banana:
                    //als banaan etc...
                    Immune = true;
                    Banana banana = new Banana(g, XTemp + 10, YTemp + 10);
                    g.BananaItems.Add(banana);
                    await Task.Delay(2000);
                    Immune = false;
                    break;
                    
                case PowerupItem.Shell:
                    Immune = true;
                    Shell shell = new Shell(g, X, Y, Angle);
                    g.ShellItems.Add(shell);
                    await Task.Delay(2000);
                    Immune = false;

                    break;

                case PowerupItem.Mushroom:
                    SpeedBoost = true;
                    MaxSpeed = 14;
                    Speed+=2;
                    await Task.Delay(1000);
                    SpeedBoost = false;
                    break;

            }

            HasItem = false;
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
