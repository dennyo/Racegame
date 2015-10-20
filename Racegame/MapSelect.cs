using RaceGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racegame
{
    public partial class MapSelect : Form
    {
        public SoundPlayer player;
        MainMenu main;
        public bool DownArrowActive = false;
        public bool UpArrowActive = false;
        public bool LeftArrowActive = false;
        public bool RightArrowActive = false;
        public bool MapChosen = false;
        public bool Map1Selected = true;
        public bool Map2Selected = false;
        public bool Map3Selected = false;
        public bool Map4Selected = false;
        public bool Map5Selected = false;
        public bool Map6Selected = false;
        public bool Map7Selected = false;
        public bool Map8Selected = false;
        public bool EnterPressed = false;
        public Map MapChoice;
        Image Selector = new Bitmap(Path.Combine(Environment.CurrentDirectory, "Map select icon.png"));

        public MapSelect(MainMenu main, SoundPlayer player, Character c1, Character c2)
        {
            InitializeComponent();
            this.player = player;
            this.main = main;
            player = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, "THEMESONG.wav"));
            player.PlayLooping();
            timer1.Enabled = true;
            MenuButton.Visible = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                LeftArrowActive = true;
            }
            if (keyData == Keys.Right)
            {
                RightArrowActive = true;
            }
            if (keyData == Keys.Up)
            {
                UpArrowActive = true;
            }
            if (keyData == Keys.Down)
            {
                DownArrowActive = true;
            }
            if (keyData == Keys.Escape)
            {
                player.Stop();
                this.Hide();
                MainMenu frm = new MainMenu();
                frm.ShowDialog();
                this.Close();
            }
            if (keyData == Keys.Return)
            {
                EnterPressed = true;
                if (MapChosen == true)
                {
                    player.Stop();
                    this.Hide();
                    Racegame frm = new Racegame(main, p1choice, p2choice);
                    frm.ShowDialog();
                    this.Close();
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void ChoosingHandler()
        {
            if (MapChosen == false)
            {
                Choosing();
            }
            if (MapChosen == true)
            {
                PlayButton.Visible = true;
            }
        }

        public void SelectionHandler()
        {
            Selections();
            SelectorPosition();
        }

        public void Selections()
        {
            if (Map1Selected == true)
            {
                if (UpArrowActive == true)
                {
                    Map1Selected = false;
                    Map5Selected = true;
                    UpArrowActive = false;
                }
                if (DownArrowActive == true)
                {
                    Map1Selected = false;
                    Map5Selected = true;
                    DownArrowActive = false;
                }
                if (LeftArrowActive == true)
                {
                    Map1Selected = false;
                    Map4Selected = true;
                    LeftArrowActive = false;
                }
                if (RightArrowActive == true)
                {
                    Map1Selected = false;
                    Map2Selected = true;
                    RightArrowActive = false;
                }
            }
            if (Map2Selected == true)
            {
                if (UpArrowActive == true)
                {
                    Map2Selected = false;
                    Map6Selected = true;
                    UpArrowActive = false;
                }
                if (DownArrowActive == true)
                {
                    Map2Selected = false;
                    Map6Selected = true;
                    DownArrowActive = false;
                }
                if (LeftArrowActive == true)
                {
                    Map2Selected = false;
                    Map1Selected = true;
                    LeftArrowActive = false;
                }
                if (RightArrowActive == true)
                {
                    Map2Selected = false;
                    Map3Selected = true;
                    RightArrowActive = false;
                }
            }
            if (Map3Selected == true)
            {
                if (UpArrowActive == true)
                {
                    Map3Selected = false;
                    Map7Selected = true;
                    UpArrowActive = false;
                }
                if (DownArrowActive == true)
                {
                    Map3Selected = false;
                    Map7Selected = true;
                    DownArrowActive = false;
                }
                if (LeftArrowActive == true)
                {
                    Map3Selected = false;
                    Map2Selected = true;
                    LeftArrowActive = false;
                }
                if (RightArrowActive == true)
                {
                    Map3Selected = false;
                    Map4Selected = true;
                    RightArrowActive = false;
                }
            }
            if (Map4Selected == true)
            {
                if (UpArrowActive == true)
                {
                    Map4Selected = false;
                    Map8Selected = true;
                    UpArrowActive = false;
                }
                if (DownArrowActive == true)
                {
                    Map4Selected = false;
                    Map8Selected = true;
                    DownArrowActive = false;
                }
                if (LeftArrowActive == true)
                {
                    Map4Selected = false;
                    Map3Selected = true;
                    LeftArrowActive = false;
                }
                if (RightArrowActive == true)
                {
                    Map4Selected = false;
                    Map1Selected = true;
                    RightArrowActive = false;
                }
            }
            if (Map5Selected == true)
            {
                if (UpArrowActive == true)
                {
                    Map5Selected = false;
                    Map1Selected = true;
                    UpArrowActive = false;
                }
                if (DownArrowActive == true)
                {
                    Map5Selected = false;
                    Map1Selected = true;
                    DownArrowActive = false;
                }
                if (LeftArrowActive == true)
                {
                    Map5Selected = false;
                    Map8Selected = true;
                    LeftArrowActive = false;
                }
                if (RightArrowActive == true)
                {
                    Map5Selected = false;
                    Map6Selected = true;
                    RightArrowActive = false;
                }
            }
            if (Map6Selected == true)
            {
                if (UpArrowActive == true)
                {
                    Map6Selected = false;
                    Map2Selected = true;
                    UpArrowActive = false;
                }
                if (DownArrowActive == true)
                {
                    Map6Selected = false;
                    Map2Selected = true;
                    DownArrowActive = false;
                }
                if (LeftArrowActive == true)
                {
                    Map6Selected = false;
                    Map5Selected = true;
                    LeftArrowActive = false;
                }
                if (RightArrowActive == true)
                {
                    Map6Selected = false;
                    Map7Selected = true;
                    RightArrowActive = false;
                }
            }
            if (Map7Selected == true)
            {
                if (UpArrowActive == true)
                {
                    Map7Selected = false;
                    Map3Selected = true;
                    UpArrowActive = false;
                }
                if (DownArrowActive == true)
                {
                    Map7Selected = false;
                    Map3Selected = true;
                    DownArrowActive = false;
                }
                if (LeftArrowActive == true)
                {
                    Map7Selected = false;
                    Map6Selected = true;
                    LeftArrowActive = false;
                }
                if (RightArrowActive == true)
                {
                    Map7Selected = false;
                    Map8Selected = true;
                    RightArrowActive = false;
                }
            }
            if (Map8Selected == true)
            {
                if (UpArrowActive == true)
                {
                    Map8Selected = false;
                    Map4Selected = true;
                    UpArrowActive = false;
                }
                if (DownArrowActive == true)
                {
                    Map8Selected = false;
                    Map4Selected = true;
                    DownArrowActive = false;
                }
                if (LeftArrowActive == true)
                {
                    Map8Selected = false;
                    Map7Selected = true;
                    LeftArrowActive = false;
                }
                if (RightArrowActive == true)
                {
                    Map8Selected = false;
                    Map5Selected = true;
                    RightArrowActive = false;
                }
            }
        }

        public Map Choosing()
        {
            if (Map1Selected == true && EnterPressed == true)
            {
                MapChosen = true;
                MapChoice = Map.Standard;
                EnterPressed = false;
            }
            if (Map2Selected == true && EnterPressed == true)
            {
                MapChosen = true;
                MapChoice = Map.Standard;
                EnterPressed = false;
            }
            if (Map3Selected == true && EnterPressed == true)
            {
                MapChosen = true;
                MapChoice = Map.Standard;
                EnterPressed = false;
            }
            if (Map4Selected == true && EnterPressed == true)
            {
                MapChosen = true;
                MapChoice = Map.Standard;
                EnterPressed = false;
            }
            if (Map5Selected == true && EnterPressed == true)
            {
                MapChosen = true;
                MapChoice = Map.Standard;
                EnterPressed = false;
            }
            if (Map6Selected == true && EnterPressed == true)
            {
                MapChosen = true;
                MapChoice = Map.Standard;
                EnterPressed = false;
            }
            if (Map7Selected == true && EnterPressed == true)
            {
                MapChosen = true;
                MapChoice = Map.Standard;
                EnterPressed = false;
            }
            if (Map8Selected == true && EnterPressed == true)
            {
                MapChosen = true;
                MapChoice = Map.Standard;
                EnterPressed = false;
            }
            return MapChoice;
        }

        public void SelectorPosition()
        {
            if (Map1Selected == true)
            {
                pictureBox1.BackgroundImage = Selector;
            }
            if (Map1Selected == false)
            {
                pictureBox1.BackgroundImage = null;
            }
            if (Map2Selected == true)
            {
                pictureBox2.BackgroundImage = Selector;
            }
            if (Map2Selected == false)
            {
                pictureBox2.BackgroundImage = null;
            }
            if (Map3Selected == true)
            {
                pictureBox3.BackgroundImage = Selector;
            }
            if (Map3Selected == false)
            {
                pictureBox3.BackgroundImage = null;
            }
            if (Map4Selected == true)
            {
                pictureBox4.BackgroundImage = Selector;
            }
            if (Map4Selected == false)
            {
                pictureBox4.BackgroundImage = null;
            }
            if (Map5Selected == true)
            {
                pictureBox5.BackgroundImage = Selector;
            }
            if (Map5Selected == false)
            {
                pictureBox5.BackgroundImage = null;
            }
            if (Map6Selected == true)
            {
                pictureBox6.BackgroundImage = Selector;
            }
            if (Map6Selected == false)
            {
                pictureBox6.BackgroundImage = null;
            }
            if (Map7Selected == true)
            {
                pictureBox7.BackgroundImage = Selector;
            }
            if (Map7Selected == false)
            {
                pictureBox7.BackgroundImage = null;
            }
            if (Map8Selected == true)
            {
                pictureBox8.BackgroundImage = Selector;
            }
            if (Map8Selected == false)
            {
                pictureBox8.BackgroundImage = null;
            }
        }

       
        private void MenuButton_Click(object sender, EventArgs e)
        {
            player.Stop();
            this.Hide();
            MainMenu frm = new MainMenu();
            frm.ShowDialog();
            this.Close();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            player.Stop();
            this.Hide();
            Racegame frm = new Racegame(main, p1choice, p2choice);
            frm.ShowDialog();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SelectionHandler();
            ChoosingHandler();
        }

    }
}
