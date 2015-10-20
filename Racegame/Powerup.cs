using RaceGame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racegame {

    public enum PowerupItem {Banana, Mushroom, Shell };

    class Powerup {

        private int X;
        private int Y;
        private Game game;
        private static Random rand;
        private int CurrentImage = 1;
        private Dictionary<int, Image> ImageSequence = new Dictionary<int, Image>();
        private Image Banana, Mushroom, Shell;
        private PictureBox pb;
        public Rectangle rect;
        private PowerupItem current;
        private bool Disabled = false;
        private bool Hit = false;

        public Powerup(Game g, int X, int Y) {
            this.game = g;
            this.X = X;
            this.Y = Y;
            rand = new Random();
            this.rect = new Rectangle(0, 0, 42, 42);
            pb = new PictureBox();
            pb.Width = 42;
            pb.Height = 42;
            pb.BackColor = Color.Transparent;
            pb.Location = new Point(X, Y);
            g.form.Controls.Add(pb);

            for(int i = 1; i <= 8; i++) {
                ImageSequence.Add(i, Image.FromFile(Path.Combine(Environment.CurrentDirectory, "powerup/Box" + i + ".png")));
            }
            
            Mushroom = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "powerup/MushroomIcon.png"));
            Banana = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "powerup/BananaIcon.png"));
            Shell = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "powerup/ShellIcon.png"));

            /*
                            Bitmap toReturn = new Bitmap(Width, Width);

                            Image img = Image.FromFile(Path.Combine(Environment.CurrentDirectory, getCharacterUrl(this.Character, getImageNumber(Angle))));
                g.DrawImage(img, new Rectangle(new Point(0, 0), new Size(Width, Height)));
                */
        }

        public void Rotate() {
            Thread t = new Thread(() => {
                while(true) {
                    Bitmap image = new Bitmap(42, 42);
                    Graphics g = Graphics.FromImage(image);
                    g.DrawImage(ImageSequence[CurrentImage], new Rectangle(new Point(0, 0), new Size(42, 42)));
                    pb.Image = image;
                    g.Dispose();
                    if(CurrentImage < 8) {
                        CurrentImage++;
                    } else {
                        CurrentImage = 1;
                    }   
                    Thread.Sleep(100);
                }
            });
            t.IsBackground = true;
            t.Start();
               
        }

        public void SpinItemBox(Player p) {
            Thread t = new Thread(() => {
                for(int i = 0; i < 30; i++) {
                    switch(rand.Next(3)) {
                        case 0:
                            p.ItemFrame.Image = Banana;
                            current = PowerupItem.Banana;
                            break;

                        case 1:
                            p.ItemFrame.Image = Mushroom;
                            current = PowerupItem.Mushroom;
                            break;

                        case 2:
                            p.ItemFrame.Image = Shell;
                            current = PowerupItem.Shell;
                            break;
                    }
                    Thread.Sleep(50);

                }
            });

            t.IsBackground = true;
            t.Start();

            switch(current) {
                //Doe dingen hier met het geselecteerde item
                case PowerupItem.Banana:
                    //als banaan etc...
                    break;

                case PowerupItem.Shell:

                    break;

                case PowerupItem.Mushroom:

                    break;

            }

        }
        
        public void Collision(Player p) {
            rect = new Rectangle(X, Y, 42, 42);
            if(game.CircleCollision(p.rect, rect) && !Hit && !Disabled) {
                Hit = true;
                Disabled = true;
                pb.Visible = false;
                Enable();
                SpinItemBox(p);
            }
        }

        private async void Enable() {
            await Task.Delay(10000);
            Hit = false;
            Disabled = false;
            pb.Visible = true;
            Console.WriteLine("done");
        }

    }
}
