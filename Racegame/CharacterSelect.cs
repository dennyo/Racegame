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
    public partial class CharacterSelect : Form
    {
        public SoundPlayer player;
        MainMenu main;
        public bool DavidSelected = true;
        public bool JosSelected = false;
        public bool FionaSelected = false;
        public bool JopSelected = false;
        public bool NynkeSelected = false;
        public bool SibbeleSelected = false;
        public bool JorisSelected = false;
        public bool DickSelected = false;
        public bool DavidChosen = false;
        public bool JosChosen = false;
        public bool FionaChosen = false;
        public bool JopChosen = false;
        public bool NynkeChosen = false;
        public bool SibbeleChosen = false;
        public bool JorisChosen = false;
        public bool DickChosen = false;
        public bool p1Chosen = false;
        public bool p2Chosen = false;
        public bool DownArrowActive = false;
        public bool UpArrowActive = false;
        public bool LeftArrowActive = false;
        public bool RightArrowActive = false;
        public bool EnterPressed = false;
        public Character p1choice;
        public Character p2choice;
        Image Selector1 = new Bitmap(Path.Combine(Environment.CurrentDirectory, "Character Select icon 1P.png"));
        Image Selector2 = new Bitmap(Path.Combine(Environment.CurrentDirectory, "Character Select icon 2P.png"));
        public CharacterSelect(MainMenu main, SoundPlayer player)
        {
            InitializeComponent();
            this.player = player;
            this.main = main;
            player = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, "THEMESONG.wav"));
            player.PlayLooping();
            timer1.Enabled = true;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

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
            if (keyData == Keys.Return)
            {
                EnterPressed = true;
                if (button9.Visible == true)
                {
                    player.Stop();
                    this.Hide();
                    Racegame frm = new Racegame(main, p1choice, p2choice);
                    frm.ShowDialog();
                    this.Close();
                }
            }
            if (keyData == Keys.Escape)
            {
                player.Stop();
                this.Hide();
                MainMenu frm = new MainMenu();
                frm.ShowDialog();
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SelectionHandler();
            ChoosingHandler();
        }

        public void ChoosingHandler()
        {
            if (p1Chosen == false)
            {
                ChoosingP1();
            }
            if (p1Chosen == true)
            {
                ChoosingP2();
            }
            if (p1Chosen == true && p2Chosen == true)
            {
                button9.Visible = true;
            }
        }

        public void SelectionHandler()
        {
            Selections();
            if (p1Chosen == false)
            {
                Selector1Position();
            }
            if (p1Chosen == true)
            {
                Selector2Position();
            }
        }

        public void Selections()
        {
            if (DavidSelected == true)
            {
                if (UpArrowActive == true)
                {
                    DavidSelected = false;
                    SibbeleSelected = true;
                    UpArrowActive = false;
                }
                if (DownArrowActive == true)
                {
                    DavidSelected = false;
                    SibbeleSelected = true;
                    DownArrowActive = false;
                }
                if (LeftArrowActive == true)
                {
                    DavidSelected = false;
                    JopSelected = true;
                    LeftArrowActive = false;
                }
                if (RightArrowActive == true)
                {
                    DavidSelected = false;
                    JosSelected = true;
                    RightArrowActive = false;
                }
            }
            if (JosSelected == true)
            {
                if (UpArrowActive == true)
                {
                    JosSelected = false;
                    JorisSelected = true;
                    UpArrowActive = false;
                }
                if (DownArrowActive == true)
                {
                    JosSelected = false;
                    JorisSelected = true;
                    DownArrowActive = false;
                }
                if (LeftArrowActive == true)
                {
                    JosSelected = false;
                    DavidSelected = true;
                    LeftArrowActive = false;
                }
                if (RightArrowActive == true)
                {
                    JosSelected = false;
                    FionaSelected = true;
                    RightArrowActive = false;
                }
            }
            if (FionaSelected == true)
            {
                if (UpArrowActive == true)
                {
                    FionaSelected = false;
                    NynkeSelected = true;
                    UpArrowActive = false;
                }
                if (DownArrowActive == true)
                {
                    FionaSelected = false;
                    NynkeSelected = true;
                    DownArrowActive = false;
                }
                if (LeftArrowActive == true)
                {
                    FionaSelected = false;
                    JosSelected = true;
                    LeftArrowActive = false;
                }
                if (RightArrowActive == true)
                {
                    FionaSelected = false;
                    JopSelected = true;
                    RightArrowActive = false;
                }
            }
            if (JopSelected == true)
            {
                if (UpArrowActive == true)
                {
                    JopSelected = false;
                    DickSelected = true;
                    UpArrowActive = false;
                }
                if (DownArrowActive == true)
                {
                    JopSelected = false;
                    DickSelected = true;
                    DownArrowActive = false;
                }
                if (LeftArrowActive == true)
                {
                    JopSelected = false;
                    FionaSelected = true;
                    LeftArrowActive = false;
                }
                if (RightArrowActive == true)
                {
                    JopSelected = false;
                    DavidSelected = true;
                    RightArrowActive = false;
                }
            }
            if (SibbeleSelected == true)
            {
                if (UpArrowActive == true)
                {
                    SibbeleSelected = false;
                    DavidSelected = true;
                    UpArrowActive = false;
                }
                if (DownArrowActive == true)
                {
                    SibbeleSelected = false;
                    DavidSelected = true;
                    DownArrowActive = false;
                }
                if (LeftArrowActive == true)
                {
                    SibbeleSelected = false;
                    DickSelected = true;
                    LeftArrowActive = false;
                }
                if (RightArrowActive == true)
                {
                    SibbeleSelected = false;
                    JorisSelected = true;
                    RightArrowActive = false;
                }
            }
            if (JorisSelected == true)
            {
                if (UpArrowActive == true)
                {
                    JorisSelected = false;
                    JosSelected = true;
                    UpArrowActive = false;
                }
                if (DownArrowActive == true)
                {
                    JorisSelected = false;
                    JosSelected = true;
                    DownArrowActive = false;
                }
                if (LeftArrowActive == true)
                {
                    JorisSelected = false;
                    SibbeleSelected = true;
                    LeftArrowActive = false;
                }
                if (RightArrowActive == true)
                {
                    JorisSelected = false;
                    NynkeSelected = true;
                    RightArrowActive = false;
                }
            }
            if (NynkeSelected == true)
            {
                if (UpArrowActive == true)
                {
                    NynkeSelected = false;
                    FionaSelected = true;
                    UpArrowActive = false;
                }
                if (DownArrowActive == true)
                {
                    NynkeSelected = false;
                    FionaSelected = true;
                    DownArrowActive = false;
                }
                if (LeftArrowActive == true)
                {
                    NynkeSelected = false;
                    JorisSelected = true;
                    LeftArrowActive = false;
                }
                if (RightArrowActive == true)
                {
                    NynkeSelected = false;
                    DickSelected = true;
                    RightArrowActive = false;
                }
            }
            if (DickSelected == true)
            {
                if (UpArrowActive == true)
                {
                    DickSelected = false;
                    JopSelected = true;
                    UpArrowActive = false;
                }
                if (DownArrowActive == true)
                {
                    DickSelected = false;
                    JopSelected = true;
                    DownArrowActive = false;
                }
                if (LeftArrowActive == true)
                {
                    DickSelected = false;
                    NynkeSelected = true;
                    LeftArrowActive = false;
                }
                if (RightArrowActive == true)
                {
                    DickSelected = false;
                    SibbeleSelected = true;
                    RightArrowActive = false;
                }
            }
        }

        public Character ChoosingP1()
        {
            if (DavidSelected == true && EnterPressed == true)
            {
                DavidChosen = true;
                p1Chosen = true;
                p1choice = Character.David;
                EnterPressed = false;
                DavidSelected = false;
                JosSelected = true;
            }
            if (JosSelected == true && EnterPressed == true)
            {
                JosChosen = true;
                p1Chosen = true;
                p1choice = Character.Jos;
                EnterPressed = false;
                JosSelected = false;
                DavidSelected = true;

            }
            if (FionaSelected == true && EnterPressed == true)
            {
                FionaChosen = true;
                p1Chosen = true;
                p1choice = Character.Fiona;
                EnterPressed = false;
                FionaSelected = false;
                DavidSelected = true;

            }
            if (JopSelected == true && EnterPressed == true)
            {
                JopChosen = true;
                p1Chosen = true;
                p1choice = Character.Jop;
                EnterPressed = false;
                JopSelected = false;
                DavidSelected = true;

            }
            if (SibbeleSelected == true && EnterPressed == true)
            {
                SibbeleChosen = true;
                p1Chosen = true;
                p1choice = Character.Sibbele;
                EnterPressed = false;
                SibbeleSelected = false;
                DavidSelected = true;

            }
            if (JorisSelected == true && EnterPressed == true)
            {
                JorisChosen = true;
                p1Chosen = true;
                p1choice = Character.Joris;
                EnterPressed = false;
                JorisSelected = false;
                DavidSelected = true;

            }
            if (NynkeSelected == true && EnterPressed == true)
            {
                NynkeChosen = true;
                p1Chosen = true;
                p1choice = Character.Nynke;
                EnterPressed = false;
                NynkeSelected = false;
                DavidSelected = true;

            }
            if (DickSelected == true && EnterPressed == true)
            {
                DickChosen = true;
                p1Chosen = true;
                p1choice = Character.Dick;
                EnterPressed = false;
                DickSelected = false;
                DavidSelected = true;
            }
            return p1choice;
        }

        public Character ChoosingP2()
        {
            if (DavidSelected == true && EnterPressed == true)
            {
                DavidChosen = true;
                p2Chosen = true;
                p2choice = Character.David;
                EnterPressed = false;
            }
            if (JosSelected == true && EnterPressed == true)
            {
                JosChosen = true;
                p2Chosen = true;
                p2choice = Character.Jos;
                EnterPressed = false;
            }
            if (FionaSelected == true && EnterPressed == true)
            {
                FionaChosen = true;
                p2Chosen = true;
                p2choice = Character.Fiona;
                EnterPressed = false;
            }
            if (JopSelected == true && EnterPressed == true)
            {
                JopChosen = true;
                p2Chosen = true;
                p2choice = Character.Jop;
                EnterPressed = false;
            }
            if (SibbeleSelected == true && EnterPressed == true)
            {
                SibbeleChosen = true;
                p2Chosen = true;
                p2choice = Character.Sibbele;
                EnterPressed = false;
            }
            if (JorisSelected == true && EnterPressed == true)
            {
                JorisChosen = true;
                p2Chosen = true;
                p2choice = Character.Joris;
                EnterPressed = false;
            }
            if (NynkeSelected == true && EnterPressed == true)
            {
                NynkeChosen = true;
                p2Chosen = true;
                p2choice = Character.Nynke;
                EnterPressed = false;
            }
            if (DickSelected == true && EnterPressed == true)
            {
                DickChosen = true;
                p2Chosen = true;
                p2choice = Character.Dick;
                EnterPressed = false;
            }
            return p2choice;
        }

        public void Selector1Position()
        {
            if (DavidSelected == true)
            {
                PictureBox1.BackgroundImage = Selector1;
            }
            if (DavidSelected == false)
            {
                PictureBox1.BackgroundImage = null;
            }
            if (JosSelected == true)
            {
                PictureBox2.BackgroundImage = Selector1;
            }
            if (JosSelected == false)
            {
                PictureBox2.BackgroundImage = null;
            }
            if (FionaSelected == true)
            {
                PictureBox3.BackgroundImage = Selector1;
            }
            if (FionaSelected == false)
            {
                PictureBox3.BackgroundImage = null;
            }
            if (JopSelected == true)
            {
                PictureBox4.BackgroundImage = Selector1;
            }
            if (JopSelected == false)
            {
                PictureBox4.BackgroundImage = null;
            }
            if (SibbeleSelected == true)
            {
                PictureBox5.BackgroundImage = Selector1;
            }
            if (SibbeleSelected == false)
            {
                PictureBox5.BackgroundImage = null;
            }
            if (JorisSelected == true)
            {
                PictureBox6.BackgroundImage = Selector1;
            }
            if (JorisSelected == false)
            {
                PictureBox6.BackgroundImage = null;
            }
            if (NynkeSelected == true)
            {
                PictureBox7.BackgroundImage = Selector1;
            }
            if (NynkeSelected == false)
            {
                PictureBox7.BackgroundImage = null;
            }
            if (DickSelected == true)
            {
                PictureBox8.BackgroundImage = Selector1;
            }
            if (DickSelected == false)
            {
                PictureBox8.BackgroundImage = null;
            }
        }

        public void Selector2Position()
        {
            if (DavidSelected == true)
            {
                pictureBox9.BackgroundImage = Selector2;
            }
            if (DavidSelected == false)
            {
                pictureBox9.BackgroundImage = null;
            }
            if (JosSelected == true)
            {
                pictureBox10.BackgroundImage = Selector2;
            }
            if (JosSelected == false)
            {
                pictureBox10.BackgroundImage = null;
            }
            if (FionaSelected == true)
            {
                pictureBox11.BackgroundImage = Selector2;
            }
            if (FionaSelected == false)
            {
                pictureBox11.BackgroundImage = null;
            }
            if (JopSelected == true)
            {
                pictureBox12.BackgroundImage = Selector2;
            }
            if (JopSelected == false)
            {
                pictureBox12.BackgroundImage = null;
            }
            if (SibbeleSelected == true)
            {
                pictureBox13.BackgroundImage = Selector2;
            }
            if (SibbeleSelected == false)
            {
                pictureBox13.BackgroundImage = null;
            }
            if (JorisSelected == true)
            {
                pictureBox14.BackgroundImage = Selector2;
            }
            if (JorisSelected == false)
            {
                pictureBox14.BackgroundImage = null;
            }
            if (NynkeSelected == true)
            {
                pictureBox15.BackgroundImage = Selector2;
            }
            if (NynkeSelected == false)
            {
                pictureBox15.BackgroundImage = null;
            }
            if (DickSelected == true)
            {
                pictureBox16.BackgroundImage = Selector2;
            }
            if (DickSelected == false)
            {
                pictureBox16.BackgroundImage = null;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            player.Stop();
            this.Hide();
            Racegame frm = new Racegame(main, p1choice, p2choice);
            frm.ShowDialog();
            this.Close();
        }

    }
}
