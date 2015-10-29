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
        /*This code all of it in this .cs generates the animations in the game
        First it puts in images and let the animation play in the correct map.*/
        public int X;
        public int Y;
        private int Width;
        private int Height;
        private int YCounter = 0;
        private int XCounter = 0;
        private Image image, image2;
        private DecorationType type;
        private bool one = true;
        private bool Increase = false;
        private bool XIncrease = false;
        private bool YIncrease = false;
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
                    YCounter = -70;
                    break;

                case DecorationType.Ghost:
                    image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Decoration/GhostL.png"));
                    image2 = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Decoration/GhostR.png"));

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
                    timer.Interval = 50;
                    Fish();
                    break;

                case DecorationType.FireBall:
                    timer.Interval = 50;
                    FireBall();
                    break;
                    
                case DecorationType.Ghost:
                    timer.Interval = 70;
                    Ghost();
                    break;

                case DecorationType.Mole:
                    timer.Interval = 50;
                    Mole();
                    break;

                case DecorationType.Piranha:
                    timer.Interval = 100;
                    Piranha();
                    break;

                case DecorationType.Red_Fish:
                    timer.Interval = 50;
                    Fish();
                    break;

                case DecorationType.Star:
                    timer.Interval = rand.Next(10, 30);
                    Star();
                    break;

            }
        }

        public void Draw(Graphics g) {
            if(one) g.DrawImage(image, new Rectangle(X + XCounter, Y + YCounter, Width, Height));
            if(!one) g.DrawImage(image2, new Rectangle(X + XCounter, Y + YCounter, Width, Height));
        }

        private void FireBall() {
            if(Increase) YCounter -= 5;
            if(!Increase) YCounter += 5;
            ChangeSize();
        }

        private void Mole() {
            if(Increase) YCounter -= 5;
            if(!Increase) YCounter += 5;
            ChangeSize();
        }

        private void Ghost() {
            if(XCounter > 40) {
                XIncrease = false;
                one = !one;
            }
            if(XCounter < -40) {
                XIncrease = true;
                one = !one;
            }
            if(XIncrease) {
                XCounter += 1;
            } else {
                XCounter -= 1;
            }
            if(YCounter > 10) YIncrease = false;
            if(YCounter < -10) YIncrease = true;
            if(YIncrease) {
                YCounter += 2;
            } else {
                YCounter -= 2;
            }
        }

        private void Fish() {
            one = !one;
            if(Increase) YCounter -= 5;
            if(!Increase) YCounter += 5;
            ChangeSize();
        }

        private void Piranha() {
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
            if(Width >= 32) {
                Increase = false;
                timer.Interval = 500;
            }
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
