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
            CharacterSelect frm = new CharacterSelect(this, player);
            frm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
