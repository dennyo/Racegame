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
    public partial class CharacterSelect : Form
    {
        public SoundPlayer player;
        MainMenu main;

        public CharacterSelect(MainMenu main, SoundPlayer player)
        {
            InitializeComponent();
            this.player = player;
            this.main = main;
            player = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, "THEMESONG.wav"));
            player.PlayLooping();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }


        private void button9_Click(object sender, EventArgs e)
        {
            player.Stop();
            this.Hide();
            Racegame frm = new Racegame(main);
            frm.ShowDialog();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            player.Stop();
            this.Hide();
            MainMenu frm = new MainMenu();
            frm.ShowDialog();
            this.Close();
        }
    }
  }
