using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racegame {

    public enum DecorationType {Star, Ghost, Mole, Red_Fish, Blue_Fish, Piranha, FireBall};

    public class Decoration {

        public int X;
        public int Y;
        private int Width;
        private int Height;
        private Image image, image2;
        private DecorationType type;
        private bool one = true;
        private bool Increase = false;

        public Decoration(DecorationType type, int X, int Y) {
            this.type = type;
            this.X = X;
            this.Y = Y;

            switch(type) {

                case DecorationType.Blue_Fish:
                    image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Decoration/BlueFish1.png"));
                    image2 = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Decoration/BlueFish2.png"));
                    Fish();
                    break;

                case DecorationType.FireBall:
                    image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Decoration/Fireball.png"));

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
                    Fish();
                    break;

                case DecorationType.Star:
                    image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Decoration/Star.png"));
                    Star();
                    break;

            }

        }

        public void Draw(Graphics g) {
            if(one) g.DrawImage(image, new Rectangle(X, Y, Width, Height));
            if(!one) g.DrawImage(image2, new Rectangle(X, Y, Width, Height));
        }

        private void Fish() {
            one = !one;
        }

        private void Star() {
            if(Width == 0 || Width == 32) Increase = !Increase;
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
