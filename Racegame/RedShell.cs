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

namespace Racegame
{
    public class RedShell
    {
        private string DavidIVookDaviddeBouwerGeorgischდავითაღმაშენებელიDavitAghmasjenebeliKoetaisi107324januari1122waskoningvanGeorgiëvan1089tot1125HijwasdeenigezoonvankoningGeorgeIIuithetBagrationenhuisenstondaandebasisvandegrootstebloeiperiodevanGeorgiëdeGeorgischeGoudenEeuw11001225zieGeschiedenisvanGeorgiëTijdenszijngeboorteenjeugdbeleefdeGeorgiëeenvanhaarmoeilijksteperiodendoorstelselmatigeaanvallenvandeislamitischeSeltsjoekendieeenjihaduitvochtentegenhetchristelijkevorstendomZijnvaderdieniettegendeproblemenwasopgewassenwerdgedwongenaftetredentengunstevanzijntoen16jarigezoon = "Waarom heb je dit helemaal gelezen?";
        private float X;
        private float Y;
        private float Angle;
        private Point one = new Point(885, 175);
        private Point two = new Point(935, 410);
        private Point three = new Point(580, 425);
        private Point four = new Point(540, 670);
        private Point five = new Point(115, 625);
        private Point six = new Point(350, 200);
        private bool attackplayer = false;
        private bool attackplayer2 = false;
        private bool targetplayer = false;
        private bool targetplayer2 = false;
        private bool startchecked = false;
        private bool targetchecked = false;
        private Point[] points;
        private int[] xmin;
        private int[] xmax;
        private int[] ymin;
        private int[] ymax;
        private float[] xDistances;
        private float[] yDistances;
        private float[] truexDistances;
        private float[] trueyDistances;
        private bool[] reached;
        private bool[] calc;
        int xCenter;
        int yCenter;
        float xDistancePlayer;
        float yDistancePlayer;
        float xDistancePlayer2;
        float yDistancePlayer2;
        int counter = 0;
        

        private Game game;
        private Image RedShell_Image;
        public Rectangle rect;
        public Image image;
        public bool Active = true;
        Dictionary<int[], ColorHandler> kleuren = new Dictionary<int[], ColorHandler>();
        private Stopwatch sw;


        public RedShell(Game g, float X, float Y, float Angle, Map map)
        {
            this.game = g;
            this.X = X;
            this.Y = Y;
            this.Angle = Angle;
            RedShell_Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "RedShell.png"));
            kleuren.Add(new int[3] { 255, 0, 150 }, ColorHandler.Wall_Red);
            kleuren.Add(new int[3] { 0, 255, 150 }, ColorHandler.Wall_Green);
            kleuren.Add(new int[3] { 150, 0, 255 }, ColorHandler.Wall_Blue);
            kleuren.Add(new int[3] { 0, 255, 255 }, ColorHandler.Wall_Light_Blue);
            sw = new Stopwatch();
            sw.Start();
            if (map == Map.Standard)
            {
                points = new Point[11];
                xmin = new int[11];
                xmax = new int[11];
                ymin = new int[11];
                ymax = new int[11];
                xDistances = new float[11];
                yDistances = new float[11];
                truexDistances = new float[11];
                trueyDistances = new float[11];
                reached = new bool[11];
                calc = new bool[11];
                points[0] = new Point(885, 175);
                points[1] = new Point(935, 410);
                points[2] = new Point(580, 425);
                points[3] = new Point(540, 670);
                points[4] = new Point(115, 625);
                points[5] = new Point(350, 200);
                points[6] = new Point(350, 200);
                points[7] = new Point(350, 200);
                points[8] = new Point(350, 200);
                points[9] = new Point(350, 200);
                points[10] = new Point(350, 200);

                xmin[0] = 0;
                xmin[1] = 761;
                xmin[2] = 670;
                xmin[3] = 385;
                xmin[4] = 385;
                xmin[5] = 0;
                xmin[6] = 0;
                xmin[7] = 0;
                xmin[8] = 0;
                xmin[9] = 0;
                xmin[10] = 0;
                xmax[0] = 760;
                xmax[1] = 1024;
                xmax[2] = 1024;
                xmax[3] = 669;
                xmax[4] = 1024;
                xmax[5] = 384;
                xmax[6] = 384;
                xmax[7] = 384;
                xmax[8] = 384;
                xmax[9] = 384;
                xmax[10] = 384;
                ymin[0] = 0;
                ymin[1] = 0;
                ymin[2] = 285;
                ymin[3] = 285;
                ymin[4] = 511;
                ymin[5] = 286;
                ymin[6] = 286;
                ymin[7] = 286;
                ymin[8] = 286;
                ymin[9] = 286;
                ymin[10] = 286;
                ymax[0] = 285;
                ymax[1] = 285;
                ymax[2] = 510;
                ymax[3] = 510;
                ymax[4] = 768;
                ymax[5] = 768;
                ymax[6] = 768;
                ymax[7] = 768;
                ymax[8] = 768;
                ymax[9] = 768;
                ymax[10] = 768;
            }
            if (map == Map.Rainbow_Road)
            {
                points = new Point[11];
                xmin = new int[11];
                xmax = new int[11];
                ymin = new int[11];
                ymax = new int[11];
                xDistances = new float[11];
                yDistances = new float[11];
                truexDistances = new float[11];
                trueyDistances = new float[11];
                reached = new bool[11];
                calc = new bool[11];
                points[0] = new Point(105, 160);
                points[1] = new Point(750, 150);
                points[2] = new Point(735, 355);
                points[3] = new Point(340, 360);
                points[4] = new Point(340, 515);
                points[5] = new Point(900, 525);
                points[6] = new Point(875, 685);
                points[7] = new Point(470, 730);
                points[8] = new Point(105, 690);
                points[9] = new Point(105, 690);
                points[10] = new Point(105, 690);

                xmin[0] = 0;
                xmin[1] = 0;
                xmin[2] = 676;
                xmin[3] = 410;
                xmin[4] = 186;
                xmin[5] = 186;
                xmin[6] = 862;
                xmin[7] = 520;
                xmin[8] = 186;
                xmin[9] = 186;
                xmin[10] = 186;
                xmax[0] = 185;
                xmax[1] = 675;
                xmax[2] = 825;
                xmax[3] = 825;
                xmax[4] = 409;
                xmax[5] = 861;
                xmax[6] = 1024;
                xmax[7] = 1024;
                xmax[8] = 519;
                xmax[9] = 519;
                xmax[10] = 519;
                ymin[0] = 200;
                ymin[1] = 0;
                ymin[2] = 0;
                ymin[3] = 306;
                ymin[4] = 306;
                ymin[5] = 456;
                ymin[6] = 0;
                ymin[7] = 646;
                ymin[8] = 600;
                ymin[9] = 600;
                ymin[10] = 600;
                ymax[0] = 768;
                ymax[1] = 199;
                ymax[2] = 305;
                ymax[3] = 400;
                ymax[4] = 455;
                ymax[5] = 585;
                ymax[6] = 645;
                ymax[7] = 768;
                ymax[8] = 768;
                ymax[9] = 768;
                ymax[10] = 768;
            }
            if (map == Map.Bowser_Castle)
            {
                points = new Point[11];
                xmin = new int[11];
                xmax = new int[11];
                ymin = new int[11];
                ymax = new int[11];
                xDistances = new float[11];
                yDistances = new float[11];
                truexDistances = new float[11];
                trueyDistances = new float[11];
                reached = new bool[11];
                calc = new bool[11];
                points[0] = new Point(930, 670);
                points[1] = new Point(720, 670);
                points[2] = new Point(750, 330);
                points[3] = new Point(265, 325);
                points[4] = new Point(275, 485);
                points[5] = new Point(535, 490);
                points[6] = new Point(520, 689);
                points[7] = new Point(80, 680);
                points[8] = new Point(90, 160);
                points[9] = new Point(935, 170);
                points[10] = new Point(935, 170);

                xmin[0] = 860;
                xmin[1] = 821;
                xmin[2] = 650;
                xmin[3] = 335;
                xmin[4] = 185;
                xmin[5] = 185;
                xmin[6] = 476;
                xmin[7] = 145;
                xmin[8] = 0;
                xmin[9] = 0;
                xmin[10] = 0;
                xmax[0] = 1024;
                xmax[1] = 1024;
                xmax[2] = 820;
                xmax[3] = 835;
                xmax[4] = 334;
                xmax[5] = 475;
                xmax[6] = 600;
                xmax[7] = 600;
                xmax[8] = 144;
                xmax[9] = 1024;
                xmax[10] = 1024;
                ymin[0] = 230;
                ymin[1] = 620;
                ymin[2] = 390;
                ymin[3] = 245;
                ymin[4] = 245;
                ymin[5] = 426;
                ymin[6] = 426;
                ymin[7] = 616;
                ymin[8] = 230;
                ymin[9] = 0;
                ymin[10] = 0;
                ymax[0] = 619;
                ymax[1] = 768;
                ymax[2] = 768;
                ymax[3] = 389;
                ymax[4] = 425;
                ymax[5] = 545;
                ymax[6] = 615;
                ymax[7] = 768;
                ymax[8] = 768;
                ymax[9] = 229;
                ymax[10] = 229;
            }


        }

        public void Draw(Graphics g, Bitmap image, Player player, Player player2)
        {
            if (!Active) return;
            rect = new Rectangle((int)X, (int)Y, 42, 42);
            g.DrawImage(RedShell_Image, rect);
            Console.WriteLine(X + " " + Y);
            Move(image, player, player2);

        }

        public void Move(Bitmap image, Player player, Player player2)
        {

            xCenter = (int)(X + 42 / 2);
            yCenter = (int)(Y + (42 / 2));
            System.Drawing.Color col = image.GetPixel(xCenter, yCenter);
            switch (getColor(col.R, col.G, col.B))
            {

                case ColorHandler.Wall_Red:
                    if ((Angle < 0 && Angle > -180) || (Angle > 0 && Angle < 180))
                    {
                        //up
                        Angle = 110;
                    }
                    else
                    {
                        //down
                        Angle = -110;
                    }
                    Active = false;
                    game.RedShellItems.Remove(this);
                    break;

                case ColorHandler.Wall_Green:
                    if ((Angle < 0 && Angle > -180) || (Angle > 0 && Angle < 180))
                    {
                        //up
                        Angle = -10;
                    }
                    else
                    {
                        //down
                        Angle = 10;
                    }
                    Active = false;
                    game.RedShellItems.Remove(this);
                    break;

                case ColorHandler.Wall_Blue:
                    if ((Angle < 0 && Angle > -180) || (Angle > 0 && Angle < 180))
                    {
                        //up
                        Angle = 10;
                    }
                    else
                    {
                        //down
                        Angle = -190;
                    }
                    Active = false;
                    game.RedShellItems.Remove(this);
                    break;

                case ColorHandler.Wall_Light_Blue:
                    if ((Angle < 0 && Angle > -180) || (Angle > 0 && Angle < 180))
                    {
                        //up
                        Angle = -100;
                    }
                    else
                    {
                        //down
                        Angle = 100;
                    }
                    Active = false;
                    game.RedShellItems.Remove(this);
                    break;
            }
            xDistancePlayer = xCenter - (player.X + player.Width / 2);
            yDistancePlayer = yCenter - (player.Y + player.Height / 2);
            xDistancePlayer2 = xCenter - (player2.X + player2.Width / 2);
            yDistancePlayer2 = yCenter - (player2.Y + player2.Height / 2);
            xDistances[0] = xCenter - points[0].X;
            yDistances[0] = yCenter - points[0].Y;
            xDistances[1] = xCenter - points[1].X;
            yDistances[1] = yCenter - points[1].Y;
            xDistances[2] = xCenter - points[2].X;
            yDistances[2] = yCenter - points[2].Y;
            xDistances[3] = xCenter - points[3].X;
            yDistances[3] = yCenter - points[3].Y;
            xDistances[4] = xCenter - points[4].X;
            yDistances[4] = yCenter - points[4].Y;
            xDistances[5] = xCenter - points[5].X;
            yDistances[5] = yCenter - points[5].Y;
            xDistances[6] = xCenter - points[6].X;
            yDistances[6] = yCenter - points[6].Y;
            xDistances[7] = xCenter - points[7].X;
            yDistances[7] = yCenter - points[7].Y;
            xDistances[8] = xCenter - points[8].X;
            yDistances[8] = yCenter - points[8].Y;
            xDistances[9] = xCenter - points[9].X;
            yDistances[9] = yCenter - points[9].Y;
            xDistances[10] = xCenter - points[10].X;
            yDistances[10] = yCenter - points[10].Y;
            if (targetchecked == false)
            {
                if (Math.Abs(xDistancePlayer) > Math.Abs(xDistancePlayer2))
                {
                    targetplayer = true;
                }
                else if (Math.Abs(xDistancePlayer) < Math.Abs(xDistancePlayer2))
                {
                    targetplayer2 = true;
                }
                targetchecked = true;
            }
            if (startchecked == false)
            {

                if (xCenter >= xmin[0] && xCenter <= xmax[0] && yCenter >= ymin[0] && yCenter <= ymax[0])
                {
                    reached[0] = false;
                    reached[1] = false;
                    reached[2] = false;
                    reached[3] = false;
                    reached[4] = false;
                    calc[0] = true;
               
                }
                else if (xCenter >= xmin[1] && xCenter <= xmax[1] && yCenter >= ymin[1] && yCenter <= ymax[1])
                {
                    reached[0] = true;
                    reached[1] = false;
                    reached[2] = false;
                    reached[3] = false;
                    reached[4] = false;
                    calc[1] = true;
                
                }
                else if (xCenter >= xmin[2] && xCenter <= xmax[2] && yCenter >= ymin[2] && yCenter <= ymax[2])
                {
                    reached[0] = true;
                    reached[1] = true;
                    reached[2] = false;
                    reached[3] = false;
                    reached[4] = false;
                    calc[2] = true;
                    counter = 2;
                }
                else if (xCenter >= xmin[3] && xCenter <= xmax[3] && yCenter >= ymin[3] && yCenter <= ymax[3])
                {
                    reached[0] = true;
                    reached[1] = true;
                    reached[2] = true;
                    reached[3] = false;
                    reached[4] = false;
                    calc[3] = true;
                
                }
                else if (xCenter >= xmin[4] && xCenter <= xmax[4] && yCenter >= ymin[4] && yCenter <= ymax[4])
                {
                    reached[0] = true;
                    reached[1] = true;
                    reached[2] = true;
                    reached[3] = true;
                    reached[4] = false;
                    calc[4] = true;
               
                }
                else if (xCenter >= xmin[5] && xCenter <= xmax[5] && yCenter >= ymin[5] && yCenter <= ymax[5])
                {
                    reached[0] = true;
                    reached[1] = true;
                    reached[2] = true;
                    reached[3] = true;
                    reached[4] = true;
                    calc[5] = true;
 
                }
                else if (xCenter >= xmin[6] && xCenter <= xmax[6] && yCenter >= ymin[6] && yCenter <= ymax[6])
                {
                    reached[0] = true;
                    reached[1] = true;
                    reached[2] = true;
                    reached[3] = true;
                    reached[4] = true;
                    reached[5] = true;
                    reached[6] = false;
                    reached[7] = false;
                    reached[8] = false;
                    reached[9] = false;
                    calc[6] = true;

                }
                else if (xCenter >= xmin[7] && xCenter <= xmax[7] && yCenter >= ymin[7] && yCenter <= ymax[7])
                {
                    reached[0] = true;
                    reached[1] = true;
                    reached[2] = true;
                    reached[3] = true;
                    reached[4] = true;
                    reached[5] = true;
                    reached[6] = true;
                    reached[7] = false;
                    reached[8] = false;
                    reached[9] = false;

                    calc[7] = true;

                }
                else if (xCenter >= xmin[8] && xCenter <= xmax[8] && yCenter >= ymin[8] && yCenter <= ymax[8])
                {
                    reached[0] = true;
                    reached[1] = true;
                    reached[2] = true;
                    reached[3] = true;
                    reached[4] = true;
                    reached[5] = true;
                    reached[6] = true;
                    reached[7] = true;
                    reached[8] = false;
                    reached[9] = false;

                    calc[8] = true;

                }
                else if (xCenter >= xmin[9] && xCenter <= xmax[9] && yCenter >= ymin[9] && yCenter <= ymax[9])
                {
                    reached[0] = true;
                    reached[1] = true;
                    reached[2] = true;
                    reached[3] = true;
                    reached[4] = true;
                    reached[5] = true;
                    reached[6] = true;
                    reached[7] = true;
                    reached[8] = true;
                    reached[9] = false;
                    calc[9] = true;

                }
                else if (xCenter >= xmin[10] && xCenter <= xmax[10] && yCenter >= ymin[10] && yCenter <= ymax[10])
                {
                    reached[0] = true;
                    reached[1] = true;
                    reached[2] = true;
                    reached[3] = true;
                    reached[4] = true;
                    reached[5] = true;
                    reached[6] = true;
                    reached[7] = true;
                    reached[8] = true;
                    reached[9] = true;
                    calc[10] = true;

                }
                startchecked = true;
            }
            Console.WriteLine(reached[0]);
            Console.WriteLine(reached[1]);
            Console.WriteLine(reached[2]);
            Console.WriteLine(reached[3]);
            Console.WriteLine(reached[4]);
            Console.WriteLine(reached[5]);
            Console.WriteLine(reached[6]);
            Console.WriteLine(reached[7]);
            Console.WriteLine(reached[8]);
            Console.WriteLine(reached[9]);
            Console.WriteLine(reached[10]);




            if (reached[0] == false && reached[1] == false && reached[2] == false
                && reached[3] == false && reached[4] == false && reached[5] == false && reached[6] == false
                && reached[7] == false && reached[8] == false && reached[9] == false &&
                attackplayer == false && attackplayer2 == false)
            {
                if (calc[0] == true)
                {
                    truexDistances[0] = Convert.ToInt32(xDistances[0]);
                    trueyDistances[0] = Convert.ToInt32(yDistances[0]);
                    calc[0] = false;
                }
                X -= truexDistances[0] / 30;
                Y -= trueyDistances[0] / 30;
                if (xDistances[0] > -20 && xDistances[0] < 20 && yDistances[0] > -20 && yDistances[0] < 20)
                {
                    reached[0] = true;
                    calc[1] = true;

                }
            }
            else if (reached[0] == true && reached[1] == false && reached[2] == false
                && reached[3] == false && reached[4] == false && reached[5] == false && reached[6] == false
                && reached[7] == false && reached[8] == false && reached[9] == false &&
                attackplayer == false && attackplayer2 == false)
            {
                if (calc[1] == true)
                {
                    truexDistances[1] = Convert.ToInt32(xDistances[1]);
                    trueyDistances[1] = Convert.ToInt32(yDistances[1]);
                    calc[1] = false;
                }
                X -= truexDistances[1] / 30;
                Y -= trueyDistances[1] / 30;
                if (xDistances[1] > -20 && xDistances[1] < 20 && yDistances[1] > -20 && yDistances[1] < 20)
                {
                    reached[1] = true;
                    calc[2] = true;

                }
            }
            else if (reached[0] == true && reached[1] == true && reached[2] == false
    && reached[3] == false && reached[4] == false && reached[5] == false && reached[6] == false
                && reached[7] == false && reached[8] == false && reached[9] == false &&
                attackplayer == false && attackplayer2 == false)
            {
                if (calc[2] == true)
                {
                    truexDistances[2] = Convert.ToInt32(xDistances[2]);
                    trueyDistances[2] = Convert.ToInt32(yDistances[2]);
                    calc[2] = false;
                }
                X -= truexDistances[2] / 30;
                Y -= trueyDistances[2] / 30;
                if (xDistances[2] > -20 && xDistances[2] < 20 && yDistances[2] > -20 && yDistances[2] < 20)
                {
                    reached[2] = true;
                    calc[3] = true;

                }
            }

            else if (reached[0] == true && reached[1] == true && reached[2] == true
    && reached[3] == false && reached[4] == false && reached[5] == false && reached[6] == false
                && reached[7] == false && reached[8] == false && reached[9] == false &&
                attackplayer == false && attackplayer2 == false)
            {
                if (calc[3] == true)
                {
                    truexDistances[3] = Convert.ToInt32(xDistances[3]);
                    trueyDistances[3] = Convert.ToInt32(yDistances[3]);
                    calc[3] = false;
                }
                X -= truexDistances[3] / 30;
                Y -= trueyDistances[3] / 30;
                if (xDistances[3] > -20 && xDistances[3] < 20 && yDistances[3] > -20 && yDistances[3] < 20)
                {
                    reached[3] = true;
                    calc[4] = true;

                }
            }
            else if (reached[0] == true && reached[1] == true && reached[2] == true
    && reached[3] == true && reached[4] == false && reached[5] == false && reached[6] == false
                && reached[7] == false && reached[8] == false && reached[9] == false &&
                attackplayer == false && attackplayer2 == false)
            {
                if (calc[4] == true)
                {
                    truexDistances[4] = Convert.ToInt32(xDistances[4]);
                    trueyDistances[4] = Convert.ToInt32(yDistances[4]);
                    calc[4] = false;
                }
                X -= truexDistances[4] / 30;
                Y -= trueyDistances[4] / 30;
                if (xDistances[4] > -20 && xDistances[4] < 20 && yDistances[4] > -20 && yDistances[4] < 20)
                {
                    reached[4] = true;
                    calc[5] = true;

                }
            }
            else if (reached[0] == true && reached[1] == true && reached[2] == true
 && reached[3] == true && reached[4] == true && reached[5] == false && reached[6] == false
                && reached[7] == false && reached[8] == false && reached[9] == false &&
                attackplayer == false && attackplayer2 == false)
            {
                if (calc[5] == true)
                {
                    truexDistances[5] = Convert.ToInt32(xDistances[5]);
                    trueyDistances[5] = Convert.ToInt32(yDistances[5]);
                    calc[5] = false;
                }
                X -= truexDistances[5] / 30;
                Y -= trueyDistances[5] / 30;
                if (xDistances[5] > -20 && xDistances[5] < 20 && yDistances[5] > -20 && yDistances[5] < 20)
                {
                    reached[5] = true;
                    calc[6] = true;

                }


            }
            else if (reached[0] == true && reached[1] == true && reached[2] == true
&& reached[3] == true && reached[4] == true && reached[5] == true && reached[6] == false
    && reached[7] == false && reached[8] == false && reached[9] == false &&
    attackplayer == false && attackplayer2 == false)
            {
                if (calc[6] == true)
                {
                    truexDistances[6] = Convert.ToInt32(xDistances[6]);
                    trueyDistances[6] = Convert.ToInt32(yDistances[6]);
                    calc[6] = false;
                }
                X -= truexDistances[6] / 30;
                Y -= trueyDistances[6] / 30;
                if (xDistances[6] > -20 && xDistances[6] < 20 && yDistances[6] > -20 && yDistances[6] < 20)
                {
                    reached[6] = true;
                    calc[7] = true;

                }


            }
            else if (reached[0] == true && reached[1] == true && reached[2] == true
&& reached[3] == true && reached[4] == true && reached[5] == true && reached[6] == true
    && reached[7] == false && reached[8] == false && reached[9] == false &&
    attackplayer == false && attackplayer2 == false)
            {
                if (calc[7] == true)
                {
                    truexDistances[7] = Convert.ToInt32(xDistances[7]);
                    trueyDistances[7] = Convert.ToInt32(yDistances[7]);
                    calc[7] = false;
                }
                X -= truexDistances[7] / 30;
                Y -= trueyDistances[7] / 30;
                if (xDistances[7] > -20 && xDistances[7] < 20 && yDistances[7] > -20 && yDistances[7] < 20)
                {
                    reached[7] = true;
                    calc[8] = true;

                }


            }
            else if (reached[0] == true && reached[1] == true && reached[2] == true
&& reached[3] == true && reached[4] == true && reached[5] == true && reached[6] == true
    && reached[7] == true && reached[8] == false && reached[9] == false &&
    attackplayer == false && attackplayer2 == false)
            {
                if (calc[8] == true)
                {
                    truexDistances[8] = Convert.ToInt32(xDistances[8]);
                    trueyDistances[8] = Convert.ToInt32(yDistances[8]);
                    calc[8] = false;
                }
                X -= truexDistances[8] / 30;
                Y -= trueyDistances[8] / 30;
                if (xDistances[8] > -20 && xDistances[8] < 20 && yDistances[8] > -20 && yDistances[8] < 20)
                {
                    reached[8] = true;
                    calc[9] = true;

                }


            }
            else if (reached[0] == true && reached[1] == true && reached[2] == true
&& reached[3] == true && reached[4] == true && reached[5] == true && reached[6] == true
    && reached[7] == true && reached[8] == true && reached[9] == false &&
    attackplayer == false && attackplayer2 == false)
            {
                if (calc[9] == true)
                {
                    truexDistances[9] = Convert.ToInt32(xDistances[9]);
                    trueyDistances[9] = Convert.ToInt32(yDistances[9]);
                    calc[9] = false;
                }
                X -= truexDistances[9] / 30;
                Y -= trueyDistances[9] / 30;
                if (xDistances[9] > -20 && xDistances[9] < 20 && yDistances[9] > -20 && yDistances[9] < 20)
                {
                    reached[9] = true;
                    calc[10] = true;
                }
            }
            else if (reached[0] == true && reached[1] == true && reached[2] == true
&& reached[3] == true && reached[4] == true && reached[5] == true && reached[6] == true
&& reached[7] == true && reached[8] == true && reached[9] == true &&
attackplayer == false && attackplayer2 == false)
            {
                if (calc[10] == true)
                {
                    truexDistances[10] = Convert.ToInt32(xDistances[10]);
                    trueyDistances[10] = Convert.ToInt32(yDistances[10]);
                    calc[10] = false;
                }
                X -= truexDistances[10] / 30;
                Y -= trueyDistances[10] / 30;

                if (xDistances[10] > -20 && xDistances[10] < 20 && yDistances[10] > -20 && yDistances[10] < 20)
                {
                    reached[0] = false;
                    reached[1] = false;
                    reached[2] = false;
                    reached[3] = false;
                    reached[4] = false;
                    reached[5] = false;
                    reached[6] = false;
                    reached[7] = false;
                    reached[8] = false;
                    reached[9] = false;
                    reached[10] = false;
                    calc[0] = true;
                }

            }


            if (targetplayer == true)
            {
                if (attackplayer == false)
                {
                    {
                        if (xDistancePlayer <= 150 && xDistancePlayer >= -150 && yDistancePlayer <= 150 && yDistancePlayer >= -150)
                        {
                            attackplayer = true;
                        }
                    }
                }
                if (attackplayer == true)
                {
                    X -= xDistancePlayer / 8;
                    Y -= yDistancePlayer / 8;

                }

            }
            if (targetplayer2 == true)
            {
                if (attackplayer2 == false)
                {
                    {
                        if (xDistancePlayer2 <= 150 && xDistancePlayer2 >= -150 && yDistancePlayer2 <= 150 && yDistancePlayer2 >= -150)
                        {
                            attackplayer2 = true;
                        }
                    }
                }
                if (attackplayer2 == true)
                {
                    X -= xDistancePlayer2 / 8;
                    Y -= yDistancePlayer2 / 8;

                }

            }
        }

        public ColorHandler getColor(int R, int G, int B)
        {
            foreach (int[] color in kleuren.Keys)
            {
                if (color[0] == R && color[1] == G && color[2] == B)
                {
                    return kleuren[color];
                }
            }
            return ColorHandler.None;
        }

        public async void Collision(Player p)
        {
            if (!p.Immune && game.CircleCollision(p.rect, rect))
            {
                p.PlaySound("gothit");
                Active = false;
                p.Hit = true;

                await Task.Delay(1000);
                p.Hit = false;
                game.RedShellItems.Remove(this);

            }

        }
    }
}