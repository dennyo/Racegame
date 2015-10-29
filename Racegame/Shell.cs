using RaceGame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Racegame {
    public class Shell {

        private float X;
        private float Y;
        private float Angle;
        private int Speed = 14;
        private Game game;
        private Image Shell_Image;
        public Rectangle rect;
        public Image image;
        public bool Active = true;
        Dictionary<int[], ColorHandler> kleuren = new Dictionary<int[], ColorHandler>();
        private Stopwatch sw;

        public Shell(Game g, float X, float Y, float Angle) {
            this.game = g;
            this.X = X;
            this.Y = Y;
            this.Angle = Angle;
            this.rect = new Rectangle((int)X, (int)Y, 42, 42);
            Shell_Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Shell.png"));

            kleuren.Add(new int[3] {255, 0, 150 }, ColorHandler.Wall_Red);
            kleuren.Add(new int[3] {0, 255, 150 }, ColorHandler.Wall_Green);
            kleuren.Add(new int[3] {150, 0, 255 }, ColorHandler.Wall_Blue);
            kleuren.Add(new int[3] {0, 255, 255 }, ColorHandler.Wall_Light_Blue);
            kleuren.Add(new int[3] {255, 0, 255 }, ColorHandler.Gat);

            sw = new Stopwatch();
            sw.Start();
        }

        public void Draw(Graphics g, Bitmap walls, Bitmap color) {
            if(!Active) return;
            try { 
                rect = new Rectangle((int)X, (int)Y, 42, 42);
                g.DrawImage(Shell_Image,  rect);
                Move(walls, color);
            }catch(Exception) {
                Active = false;
                game.ShellItems.Remove(this);
            }

        }

        public void Draw(Graphics g, Bitmap color) {
            if(!Active) return;
            try {             
                X += (float) Speed * ((float)Math.Cos(Math.PI / 180 * Angle));
                Y += (float) Speed * ((float)Math.Sin(Math.PI / 180 * Angle));
            
                rect = new Rectangle((int)X, (int)Y, 42, 42);
                g.DrawImage(Shell_Image,  rect);
                Move(color);
            }catch(Exception) {
                Active = false;
                game.ShellItems.Remove(this);
            }

            
            if(sw.ElapsedMilliseconds >= 5000) {
                Active = false;
                game.ShellItems.Remove(this);
            }

        }

        public void Move(Bitmap color) {
            
            int xCenter = (int) (X + 42 / 2);
            int yCenter = (int) (Y + (42 /3 * 2));
            System.Drawing.Color col = color.GetPixel(xCenter, yCenter);
            switch(getColor(col.R, col.G, col.B)) {
                
                case ColorHandler.Gat:
                    Active = false;
                    game.ShellItems.Remove(this);
                    break;

            }

            X += (float) Speed * ((float)Math.Cos(Math.PI / 180 * Angle));
            Y += (float) Speed * ((float)Math.Sin(Math.PI / 180 * Angle));
            
            if(sw.ElapsedMilliseconds >= 5000) {
                Active = false;
                game.ShellItems.Remove(this);
            }
        }

        public void Move(Bitmap image, Bitmap color) {
            
            int xCenter = (int) (X + 42 / 2);
            int yCenter = (int) (Y + (42 /3 * 2));
            System.Drawing.Color col = image.GetPixel(xCenter, yCenter);
            switch(getColor(col.R, col.G, col.B)) {
                
                case ColorHandler.Wall_Red:
                    if((Angle < 0 && Angle > -180) || (Angle > 0 && Angle < 180)) {
                        //up
                        Angle = 110;
                    }else {
                        //down
                        Angle = -110;
                    }
                    break;

                case ColorHandler.Wall_Green:
                    if((Angle < 0 && Angle > -180) || (Angle > 0 && Angle < 180)) {
                        //up
                        Angle = - 10;
                    }else {
                        //down
                        Angle = 10;
                    }
                    break;
                    
                case ColorHandler.Wall_Blue:
                    if((Angle < 0 && Angle > -180) || (Angle > 0 && Angle < 180)) {
                        //up
                        Angle = 10;
                    }else {
                        //down
                        Angle = -190;
                    }
                    break;

                case ColorHandler.Wall_Light_Blue:
                    if((Angle < 0 && Angle > -180) || (Angle > 0 && Angle < 180)) {
                        //up
                        Angle = -100;
                    }else {
                        //down
                        Angle = 100;
                    }
                    break;

            }

            X += (float) Speed * ((float)Math.Cos(Math.PI / 180 * Angle));
            Y += (float) Speed * ((float)Math.Sin(Math.PI / 180 * Angle));
            
            if(sw.ElapsedMilliseconds >= 5000) {
                Active = false;
                game.ShellItems.Remove(this);
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

        public async void Collision(Player p) {
            if(!p.Immune && game.CircleCollision(p.rect, rect)) {
                p.PlaySound("gothit");
                Active = false;
                p.Hit = true;

                await Task.Delay(2000);
                p.Hit = false;
                game.ShellItems.Remove(this);

            }

        }

    }
}
