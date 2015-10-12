using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racegame
{
    public partial class Racegame : Form
    {

        public int speedX = 10;
        public int speedY = 8;
        public int fuel = 10000;

        public Racegame()
        {
            InitializeComponent();
            GameTimer.Enabled = true;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            FuelHandler();
            Auto.Location = new Point(Auto.Location.X + speedX, Auto.Location.Y + speedY);
            BorderHandler();
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
            if (Auto.Location.X >= 1024 - Auto.Size.Width)
            {
                speedX = -speedX;
            }
            if (Auto.Location.X <= 0)
            {
                speedX = -speedX;
            }
            if (Auto.Location.Y >= 768 - 2 * Auto.Size.Height)
            {
                speedY = -speedY;
            }
            if (Auto.Location.Y <= 0)
            {
                speedY = -speedY;
            }
        }
        
    }
}

