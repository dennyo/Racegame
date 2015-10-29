using RaceGame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racegame {
    public class Banana {
        //This is the powerup of the banana
        private int X;
        private int Y;
        private Game game;
        private Image Banana_Image;
        public Rectangle rect;
        public Image image;
        public bool Active = true;

        public Banana(Game g, int X, int Y) {
            this.game = g;
            this.X = X;
            this.Y = Y;
            this.rect = new Rectangle(X, Y, 42, 42);
            Banana_Image = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "Banana.png"));
        }

        public void Draw(Graphics g) {
            if(!Active) return;
            g.DrawImage(Banana_Image,  rect);
        }

        public async void Collision(Player p) {
            if(!p.Immune && game.CircleCollision(p.rect, rect)) {
                p.PlayEffectSound("spinout");
                Active = false;
                p.Hit = true;

                await Task.Delay(1500);
                p.Hit = false;
                game.BananaItems.Remove(this);
            }
        }

    }
}
