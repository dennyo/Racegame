using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racegame {

    public enum DecorationType {Star, Ghost, Mole, Red_Fish, Blue_Fish, Piranha, FireBall};

    public class Decoration {

        public int X;
        public int Y;
        private int Width;
        private int Height;
        private int Counter = 0;
        private Image image, image2;
        private DecorationType type;
        private bool one = true;
        private bool Increase = false;
        private bool Init = true;
        private Random rand;
        private Timer timer;

        public Decoration(DecorationType type, int X, int Y) {
            this.type = type;
            this.X = X;
            this.Y = Y;
            Width = 32;
            Height = 32;
            rand = new Random();
            timer = new Timer();

            timer.Enabled = true;
            timer.Interval = rand.Next(10, 30);
            timer.Tick += new EventHandler(Loop);

            switch(type) {

                case DecorationType.Blue_Fish:
                    image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Decoration/BlueFish1.png"));
                    image2 = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Decoration/BlueFish2.png"));
                    break;

                case DecorationType.FireBall:
                    image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Decoration/Fireball.png"));
                    Counter = -70;
                    break;

                case DecorationType.Ghost:
                    image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Decoration/GhostL.png"));

                    break;

                case DecorationType.Mole:
                    image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Decoration/Mole.png"));

                    break;

                case DecorationType.Piranha:
                    image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Decoration/Piranha1.png"));
                    image2 = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Decoration/Piranha2.png"));

                    break;

                case DecorationType.Red_Fish:
                    image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Decoration/RedFish1.png"));
                    image2 = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Decoration/RedFish2.png"));
                    break;

                case DecorationType.Star:
                    image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Decoration/Star.png"));
                    break;

            }

        }

        public async void Loop(object sender, EventArgs args) {
            if(Init) {
                await Task.Delay(rand.Next(1000, 6000));
                Init = false;
            }
            switch(type) {

                case DecorationType.Blue_Fish:
                    timer.Interval = 100;
                    Fish();
                    break;

                case DecorationType.FireBall:
                    timer.Interval = 50;
                    FireBall();
                    break;
                    
                case DecorationType.Ghost:

                    break;

                case DecorationType.Mole:

                    break;

                case DecorationType.Piranha:

                    break;

                case DecorationType.Red_Fish:
                    timer.Interval = 100;
                    Fish();
                    break;

                case DecorationType.Star:
                    timer.Interval = rand.Next(10, 30);
                    Star();
                    break;

            }
        }

        public void Draw(Graphics g) {
            if(one) g.DrawImage(image, new Rectangle(X, Y + Counter, Width, Height));
            if(!one) g.DrawImage(image2, new Rectangle(X, Y + Counter, Width, Height));
        }

        private void FireBall() {
            if(Increase) Counter -= 5;
            if(!Increase) Counter += 5;
            ChangeSize();
        }

        private void Fish() {
            one = !one;
        }

        private async void Star() {
            ChangeSize();
        }

        private void ChangeSize() {
            if(Width <= 0) {
                Increase = true;
                timer.Interval = 2000;
            }
            if(Width >= 32) Increase = false;
            if(Increase) {
                Width += 2;
                Height += 2;
                X -= 1;
                Y -= 1;
            } else {
                Width -= 2;
                Height -= 2;
                X += 1;
                Y += 1;
            }
        }



    }
}
