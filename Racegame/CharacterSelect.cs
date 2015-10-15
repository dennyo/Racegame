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

        private void button1_Click(object sender, EventArgs e)
        {
            player.Stop();
            this.Hide();
            Racegame frm = new Racegame(main);
            frm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.Stop();
            this.Hide();
            Racegame frm = new Racegame(main);
            frm.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            player.Stop();
            this.Hide();
            Racegame frm = new Racegame(main);
            frm.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            player.Stop();
            this.Hide();
            Racegame frm = new Racegame(main);
            frm.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            player.Stop();
            this.Hide();
            Racegame frm = new Racegame(main);
            frm.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            player.Stop();
            this.Hide();
            Racegame frm = new Racegame(main);
            frm.ShowDialog();
            this.Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            player.Stop();
            this.Hide();
            Racegame frm = new Racegame(main);
            frm.ShowDialog();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            player.Stop();
            this.Hide();
            Racegame frm = new Racegame(main);
            frm.ShowDialog();
            this.Close();
        }
    }
  }
