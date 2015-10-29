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
using System.Diagnostics;

namespace Racegame {

    public enum PowerupItem {Banana, Mushroom, Shell, RedShell, None };

    public class Powerup {
       
        private int X;
        private int Y;
        private static Random rand;
        private int CurrentImage = 0;
        private List<Image> ImageSequence = new List<Image>();
        private Image Banana, Mushroom, Shell, RedShell;
        public Rectangle rect;
        private PowerupItem current;
        public Image image;
        private bool Disabled = false;
        private bool Hit = false;

        public Powerup(int X, int Y) {
    // This generates the powerups images so it circles between them in de top screen. And stops at one.
            this.X = X;
            this.Y = Y;
            rand = new Random();
            this.rect = new Rectangle(0, 0, 42, 42);

            for(int i = 1; i <= 8; i++) {
                ImageSequence.Add(Image.FromFile(Path.Combine(Environment.CurrentDirectory, "powerup/Box" + i + ".png")));
            }
            
            Mushroom = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "powerup/MushroomIcon.png"));
            Banana = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "powerup/BananaIcon.png"));
            Shell = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "powerup/ShellIcon.png"));
            RedShell = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "powerup/RedShellIcon.png"));
        }

        public void AddCount() {
            if(CurrentImage < 14) {
                CurrentImage++;
            } else {
                CurrentImage = 0;
            }   
        }

        public void Draw(Graphics g) {
            if(Hit || Disabled) return;
            g.DrawImage(ImageSequence[CurrentImage / 2],  rect);
        }

        public void SpinItemBox(Player p) {
            p.PlayItemBoxSound();
            p.HasItem = true;
            Thread t = new Thread(() => {
                for(int i = 0; i < 50; i++) {
                    switch(rand.Next(4)) {
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
                        case 3:
                            p.ItemFrame.Image = RedShell;
                            current = PowerupItem.RedShell;
                            break;
                    }
                    Thread.Sleep(80);

                }
                p.currentPowerup = current;

            });

            t.IsBackground = true;
            t.Start();


        }
        
        public void Collision(Game game, Player p) {
            rect = new Rectangle(X, Y, 42, 42);
            if(game.CircleCollision(p.rect, rect) && !Hit && !Disabled && !p.HasItem) {
                Hit = true;
                Disabled = true;
                Enable();
                SpinItemBox(p);
            }
        }

        private async void Enable() {
            await Task.Delay(6000);
            Hit = false;
            Disabled = false;
        }

    }
}
