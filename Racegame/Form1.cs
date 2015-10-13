using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
using RaceGame;

namespace Racegame
{
    public partial class Racegame : Form
    {

        public int speedX = 10;
        public int speedY = 8;
        public int fuel = 10000;
        public float angle = 0;
        public bool isLoaded = false;
        Graphics g;
        Player p1;
        Player p2;

        public Racegame()
        {
            InitializeComponent();
            GameTimer.Enabled = true;
            //        Player(Graphics g, System.Drawing.Color color, Keys up, Keys down, Keys right, Keys left, int x, int y, int width, int height) {
            g = this.CreateGraphics();
            p2 = new Player(g, null, Keys.Up, Keys.Down, Keys.Right, Keys.Left, 300, 400, 80, 50);
            p1 = new Player(g, null, Keys.W, Keys.S, Keys.D, Keys.A, 300, 400, 80, 50);

            //this.KeyDown += p1.ControlHandler;
            this.KeyDown += p2.ControlDownHandler;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(p2.ControlUpHandler);
            
            this.KeyDown += p1.ControlDownHandler;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(p1.ControlUpHandler);

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            FuelHandler();
            //PlayerTwo.Location = new Point(PlayerTwo.Location.X + speedX, PlayerTwo.Location.Y + speedY);
            BorderHandler();
            p2.Move(this);
            p1.Move(this);
            
        }

        public void Draw(Graphics g) {
            
            
        }

        public void FuelHandler()
        {
            fuel -= Math.Abs((speedX + speedY));
            Size fuelboxsize = new Size(fuel / 50, 10);
            FuelBox.Size = fuelboxsize;
            if (fuel <= 0)
            {
                speedX = 0;
                speedY = 0;
            }
        }
       

        public void BorderHandler()
        {
           /* if (p2.X >= 1024 - p2.Width)
            {
                speedX = -speedX;
            }
            if (p2.X <= 0)
            {
                speedX = -speedX;
            }
            if (p2.Y >= 768 - 2 * p2.Height)
            {
                speedY = -speedY;
            }
            if (p2.Y <= 0)
            {
                speedY = -speedY;
            }*/
        }

        private void Racegame_Paint(object sender, PaintEventArgs e) {
            p1.DrawPlayer(e.Graphics);
            e.Graphics.ResetTransform();
            p2.DrawPlayer(e.Graphics);
            e.Graphics.ResetTransform();

            //e.Graphics.Dispose();
        }
    }
}

