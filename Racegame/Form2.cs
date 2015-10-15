using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racegame
{
    public partial class Form2 : Form
    {
        public SoundPlayer player;

        public Form2()
        {
            InitializeComponent();
            player = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, "THEMESONG.wav"));
            player.PlayLooping();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {        
            player.Stop();
            Racegame frm = new Racegame(this, player);
            frm.Show();
        }
        // Create Form2.
        public class Form1 : Form
        {
            public Form1()
            {
                
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e) {
            this.Dispose();
        }
    }
}
