using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racegame
{
    public partial class MainMenu : Form
    {
        public SoundPlayer player;
        public Racegame racegame;

        public MainMenu()
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
            Racegame frm = new Racegame(this);
            this.racegame = frm;
            frm.Show();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e) {
            this.Dispose();
        }
    }
}
