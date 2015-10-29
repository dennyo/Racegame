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
using System.Windows.Input;
using System.Windows.Media;

namespace Racegame
{
    public partial class Super_InformatiKart : Form
    {
        public float angle = 0;
        private int CurrentImage = 1;
        Graphics g;
        Player p1;
        Player p2;
        MainMenu main;
        SoundPlayer player, mainplayer, introplayer;
        public Game game;
        private bool PlayerUp = true;
        public bool PlaySelected = true;
        public bool QuitSelected = false;
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
        public bool MapChosen = false;
        public bool Map1Selected = true;
        public bool Map2Selected = false;
        public bool Map3Selected = false;
        public bool Map4Selected = false;
        public bool Map5Selected = false;
        public bool Map6Selected = false;
        public bool Map7Selected = false;
        public bool Map8Selected = false;
        public int counter = 0;
        public Map MapChoice;
        Image Selector = new Bitmap(Path.Combine(Environment.CurrentDirectory, "Map select icon.png"));
        public Character p1choice;
        public Character p2choice;
        Image Selector1 = new Bitmap(Path.Combine(Environment.CurrentDirectory, "Character Select icon 1P.png"));
        Image Selector2 = new Bitmap(Path.Combine(Environment.CurrentDirectory, "Character Select icon 2P.png"));
        private List<Bitmap> BackgroundImages = new List<Bitmap>();

        public Super_InformatiKart()
        {
            InitializeComponent();
            timer1.Enabled = true;
            this.Opacity = 0;
            for (int i = 1; i <= 44; i++)
            {
                BackgroundImages.Add(new Bitmap(Path.Combine(Environment.CurrentDirectory, "Main/T" + i + ".png")));
            }
        }
        
        public void PlaySound(string sound) {
            MediaPlayer mp = new MediaPlayer();
            mp.Open(new Uri(Path.Combine(Environment.CurrentDirectory, "sounds/" + sound + ".wav")));
            mp.Play();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            
            if (keyData == Keys.Down)
            {
                DownArrowActive = true;
            }
            if (keyData == Keys.Up)
            {
                UpArrowActive = true;
            }
            if (keyData == Keys.Left)
            {
                LeftArrowActive = true;
            }
            if (keyData == Keys.Right)
            {
                RightArrowActive = true;
            }
            if (keyData == Keys.Return)
            {
                EnterPressed = true;
            }
            if (keyData == Keys.Escape)
            {
                Application.Restart();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.2;
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Main.Visible == true)
            {
                PlayExitSelect();
                MainSelection();
            }
            if (CharacterSelection.Visible == true)
            {
                SelectionHandler();
                ChoosingHandler();
            }
            if (MapSelection.Visible == true)
            {
                MapSelectionHandler();
                MapChoosingHandler();
            }
        }

        //
        //
        // Main Menu
        //
        //
        private void MainSelection()
        {
            if (PlaySelected == true)
            {
                PlayQuit.BackgroundImage = new Bitmap(Path.Combine(Environment.CurrentDirectory, "textboxes/Play.png"));
            }

            if (PlaySelected == true &&
                EnterPressed == true &&
                FadeIn.Enabled == false)
            {
                PlaySound("MenuSelect");
                if(counter < 4) { introplayer.Stop(); }
                if (counter >= 4) { mainplayer.Stop(); }
                SoundTimer.Enabled = false;
                FadeOut.Enabled = true;
                BackgroundTimer.Enabled = false;
                PlayerTimer.Enabled = true;
                EnterPressed = false;
            }

            if (QuitSelected == true)
            {
                PlayQuit.BackgroundImage = new Bitmap(Path.Combine(Environment.CurrentDirectory, "textboxes/Quit.png"));
            }
            if (QuitSelected == true &&
                    EnterPressed == true)
            {
                Application.Exit();
            }

        }
        private void PlayExitSelect()
        {
            if (DownArrowActive == true)
            {
                PlaySelected = false;
                QuitSelected = true;
                DownArrowActive = false;
            }
            if (UpArrowActive == true)
            {
                QuitSelected = false;
                PlaySelected = true;
                UpArrowActive = false;
            }

        }
        //
        //
        // Character Selection
        //
        //

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
                FadeOut.Enabled = true;
                EnterPressed = false;
                PlayerTimer.Enabled = false;
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
                else if (DownArrowActive == true)
                {
                    DavidSelected = false;
                    SibbeleSelected = true;
                    DownArrowActive = false;
                }
                else if (LeftArrowActive == true)
                {
                    DavidSelected = false;
                    JopSelected = true;
                    LeftArrowActive = false;
                }
                else if (RightArrowActive == true)
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
                else if (DownArrowActive == true)
                {
                    JosSelected = false;
                    JorisSelected = true;
                    DownArrowActive = false;
                }
                else if (LeftArrowActive == true)
                {
                    JosSelected = false;
                    DavidSelected = true;
                    LeftArrowActive = false;
                }
                else if (RightArrowActive == true)
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
                else if (DownArrowActive == true)
                {
                    FionaSelected = false;
                    NynkeSelected = true;
                    DownArrowActive = false;
                }
                else if (LeftArrowActive == true)
                {
                    FionaSelected = false;
                    JosSelected = true;
                    LeftArrowActive = false;
                }
                else if (RightArrowActive == true)
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
                else if (DownArrowActive == true)
                {
                    JopSelected = false;
                    DickSelected = true;
                    DownArrowActive = false;
                }
                else if (LeftArrowActive == true)
                {
                    JopSelected = false;
                    FionaSelected = true;
                    LeftArrowActive = false;
                }
                else if (RightArrowActive == true)
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
                else if (DownArrowActive == true)
                {
                    SibbeleSelected = false;
                    DavidSelected = true;
                    DownArrowActive = false;
                }
                else if (LeftArrowActive == true)
                {
                    SibbeleSelected = false;
                    DickSelected = true;
                    LeftArrowActive = false;
                }
                else if (RightArrowActive == true)
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
                else if (DownArrowActive == true)
                {
                    JorisSelected = false;
                    JosSelected = true;
                    DownArrowActive = false;
                }
                else if (LeftArrowActive == true)
                {
                    JorisSelected = false;
                    SibbeleSelected = true;
                    LeftArrowActive = false;
                }
                else if (RightArrowActive == true)
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
                else if (DownArrowActive == true)
                {
                    NynkeSelected = false;
                    FionaSelected = true;
                    DownArrowActive = false;
                }
                else if (LeftArrowActive == true)
                {
                    NynkeSelected = false;
                    JorisSelected = true;
                    LeftArrowActive = false;
                }
                else if (RightArrowActive == true)
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
                else if (DownArrowActive == true)
                {
                    DickSelected = false;
                    JopSelected = true;
                    DownArrowActive = false;
                }
                else if (LeftArrowActive == true)
                {
                    DickSelected = false;
                    NynkeSelected = true;
                    LeftArrowActive = false;
                }
                else if (RightArrowActive == true)
                {
                    DickSelected = false;
                    SibbeleSelected = true;
                    RightArrowActive = false;
                }
            }
        }

        public Character ChoosingP1()
        {
            if(EnterPressed) PlaySound("menuselect");
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
            if(EnterPressed) PlaySound("menuselect");
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

        //
        //
        // Map Selection
        //
        //

        public void MapChoosingHandler()
        {
            Choosing();
            if (MapChosen == true)
            {
                FadeOut.Enabled = true;
            }
        }

        public void MapSelectionHandler()
        {
            MapSelections();
            SelectorPosition();
        }

        public void MapSelections()
        {
            if (Map1Selected == true)
            {
                mapName.BackgroundImage = new Bitmap(Path.Combine(Environment.CurrentDirectory, "titles/Mario Circuit title.png"));
                if (UpArrowActive == true)
                {
                    Map1Selected = false;
                    Map5Selected = true;
                    UpArrowActive = false;
                }
                else if (DownArrowActive == true)
                {
                    Map1Selected = false;
                    Map5Selected = true;
                    DownArrowActive = false;
                }
                else if (LeftArrowActive == true)
                {
                    Map1Selected = false;
                    Map4Selected = true;
                    LeftArrowActive = false;
                }
                else if (RightArrowActive == true)
                {
                    Map1Selected = false;
                    Map2Selected = true;
                    RightArrowActive = false;
                }
            }
            if (Map2Selected == true)
            {
                mapName.BackgroundImage = new Bitmap(Path.Combine(Environment.CurrentDirectory, "titles/Donut Plains title.png"));
                if (UpArrowActive == true)
                {
                    Map2Selected = false;
                    Map6Selected = true;
                    UpArrowActive = false;
                }
                else if (DownArrowActive == true)
                {
                    Map2Selected = false;
                    Map6Selected = true;
                    DownArrowActive = false;
                }
                else if (LeftArrowActive == true)
                {
                    Map2Selected = false;
                    Map1Selected = true;
                    LeftArrowActive = false;
                }
                else if (RightArrowActive == true)
                {
                    Map2Selected = false;
                    Map3Selected = true;
                    RightArrowActive = false;
                }
            }
            if (Map3Selected == true)
            {
                mapName.BackgroundImage = new Bitmap(Path.Combine(Environment.CurrentDirectory, "titles/Ghost Valley title.png"));
                if (UpArrowActive == true)
                {
                    Map3Selected = false;
                    Map7Selected = true;
                    UpArrowActive = false;
                }
                else if (DownArrowActive == true)
                {
                    Map3Selected = false;
                    Map7Selected = true;
                    DownArrowActive = false;
                }
                else if (LeftArrowActive == true)
                {
                    Map3Selected = false;
                    Map2Selected = true;
                    LeftArrowActive = false;
                }
                else if (RightArrowActive == true)
                {
                    Map3Selected = false;
                    Map4Selected = true;
                    RightArrowActive = false;
                }
            }
            if (Map4Selected == true)
            {
                mapName.BackgroundImage = new Bitmap(Path.Combine(Environment.CurrentDirectory, "titles/Bowser Castle title.png"));
                if (UpArrowActive == true)
                {
                    Map4Selected = false;
                    Map8Selected = true;
                    UpArrowActive = false;
                }
                else if (DownArrowActive == true)
                {
                    Map4Selected = false;
                    Map8Selected = true;
                    DownArrowActive = false;
                }
                else if (LeftArrowActive == true)
                {
                    Map4Selected = false;
                    Map3Selected = true;
                    LeftArrowActive = false;
                }
                else if (RightArrowActive == true)
                {
                    Map4Selected = false;
                    Map1Selected = true;
                    RightArrowActive = false;
                }
            }
            if (Map5Selected == true)
            {
                mapName.BackgroundImage = new Bitmap(Path.Combine(Environment.CurrentDirectory, "titles/Choco Island title.png"));
                if (UpArrowActive == true)
                {
                    Map5Selected = false;
                    Map1Selected = true;
                    UpArrowActive = false;
                }
                else if (DownArrowActive == true)
                {
                    Map5Selected = false;
                    Map1Selected = true;
                    DownArrowActive = false;
                }
                else if (LeftArrowActive == true)
                {
                    Map5Selected = false;
                    Map8Selected = true;
                    LeftArrowActive = false;
                }
                else if (RightArrowActive == true)
                {
                    Map5Selected = false;
                    Map6Selected = true;
                    RightArrowActive = false;
                }
            }
            if (Map6Selected == true)
            {
                mapName.BackgroundImage = new Bitmap(Path.Combine(Environment.CurrentDirectory, "titles/Koopa Beach title.png"));
                if (UpArrowActive == true)
                {
                    Map6Selected = false;
                    Map2Selected = true;
                    UpArrowActive = false;
                }
                else if (DownArrowActive == true)
                {
                    Map6Selected = false;
                    Map2Selected = true;
                    DownArrowActive = false;
                }
                else if (LeftArrowActive == true)
                {
                    Map6Selected = false;
                    Map5Selected = true;
                    LeftArrowActive = false;
                }
                else if (RightArrowActive == true)
                {
                    Map6Selected = false;
                    Map7Selected = true;
                    RightArrowActive = false;
                }
            }
            if (Map7Selected == true)
            {
                mapName.BackgroundImage = new Bitmap(Path.Combine(Environment.CurrentDirectory, "titles/Vanilla Lake title.png"));
                if (UpArrowActive == true)
                {
                    Map7Selected = false;
                    Map3Selected = true;
                    UpArrowActive = false;
                }
                else if (DownArrowActive == true)
                {
                    Map7Selected = false;
                    Map3Selected = true;
                    DownArrowActive = false;
                }
                else if (LeftArrowActive == true)
                {
                    Map7Selected = false;
                    Map6Selected = true;
                    LeftArrowActive = false;
                }
                else if (RightArrowActive == true)
                {
                    Map7Selected = false;
                    Map8Selected = true;
                    RightArrowActive = false;
                }
            }
            if (Map8Selected == true)
            {
                mapName.BackgroundImage = new Bitmap(Path.Combine(Environment.CurrentDirectory, "titles/Rainbow Road title.png"));
                if (UpArrowActive == true)
                {
                    Map8Selected = false;
                    Map4Selected = true;
                    UpArrowActive = false;
                }
                else if (DownArrowActive == true)
                {
                    Map8Selected = false;
                    Map4Selected = true;
                    DownArrowActive = false;
                }
                else if (LeftArrowActive == true)
                {
                    Map8Selected = false;
                    Map7Selected = true;
                    LeftArrowActive = false;
                }
                else if (RightArrowActive == true)
                {
                    Map8Selected = false;
                    Map5Selected = true;
                    RightArrowActive = false;
                }
            }
        }

        public Map Choosing()
        {
            if(EnterPressed) PlaySound("menuselect");
            if (Map1Selected == true && EnterPressed == true)
            {
                MapChosen = true;
                MapChoice = Map.Standard;
                EnterPressed = false;
            }
            if (Map2Selected == true && EnterPressed == true)
            {
                MapChosen = true;
                MapChoice = Map.Donut_Plains;
                EnterPressed = false;
            }
            if (Map3Selected == true && EnterPressed == true)
            {
                MapChosen = true;
                MapChoice = Map.Ghost_Valley;
                EnterPressed = false;
            }
            if (Map4Selected == true && EnterPressed == true)
            {
                MapChosen = true;
                MapChoice = Map.Bowser_Castle;
                EnterPressed = false;
            }
            if (Map5Selected == true && EnterPressed == true)
            {
                MapChosen = true;
                MapChoice = Map.Choco_Island;
                EnterPressed = false;
            }
            if (Map6Selected == true && EnterPressed == true)
            {
                MapChosen = true;
                MapChoice = Map.Koopa_Beach;
                EnterPressed = false;
            }
            if (Map7Selected == true && EnterPressed == true)
            {
                MapChosen = true;
                MapChoice = Map.Vanilla_Lake;
                EnterPressed = false;
            }
            if (Map8Selected == true && EnterPressed == true)
            {
                MapChosen = true;
                MapChoice = Map.Rainbow_Road;
                EnterPressed = false;
            }
            return MapChoice;
        }

        public void SelectorPosition()
        {
            if (Map1Selected == true)
            {
                pictureBox17.BackgroundImage = Selector;
            }
            if (Map1Selected == false)
            {
                pictureBox17.BackgroundImage = null;
            }
            if (Map2Selected == true)
            {
                pictureBox18.BackgroundImage = Selector;
            }
            if (Map2Selected == false)
            {
                pictureBox18.BackgroundImage = null;
            }
            if (Map3Selected == true)
            {
                pictureBox19.BackgroundImage = Selector;
            }
            if (Map3Selected == false)
            {
                pictureBox19.BackgroundImage = null;
            }
            if (Map4Selected == true)
            {
                pictureBox20.BackgroundImage = Selector;
            }
            if (Map4Selected == false)
            {
                pictureBox20.BackgroundImage = null;
            }
            if (Map5Selected == true)
            {
                pictureBox21.BackgroundImage = Selector;
            }
            if (Map5Selected == false)
            {
                pictureBox21.BackgroundImage = null;
            }
            if (Map6Selected == true)
            {
                pictureBox22.BackgroundImage = Selector;
            }
            if (Map6Selected == false)
            {
                pictureBox22.BackgroundImage = null;
            }
            if (Map7Selected == true)
            {
                pictureBox23.BackgroundImage = Selector;
            }
            if (Map7Selected == false)
            {
                pictureBox23.BackgroundImage = null;
            }
            if (Map8Selected == true)
            {
                pictureBox24.BackgroundImage = Selector;
            }
            if (Map8Selected == false)
            {
                pictureBox24.BackgroundImage = null;
            }
        }

        private void FadeIn_Tick(object sender, EventArgs e)
        {
            if (FadeOut.Enabled == false)
            {
                if (Main.Visible == true)
                {
                    if (this.Opacity == 0.2)
                    {
                        BackgroundTimer.Enabled = true;
                    }
                    if (this.Opacity == 1)
                    {
                        FadeIn.Enabled = false;
                        SoundTimer.Enabled = true;
                        introplayer = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, "sounds/Title screen intro.wav"));
                        introplayer.Play();
                    }
                    this.Opacity += 0.2;
                }
                if (CharacterSelection.Visible == true)
                {
                    if (this.Opacity == 1)
                    {
                        player = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, "sounds/Selection Screen.wav"));
                        player.PlayLooping();
                        FadeIn.Enabled = false;
                    }
                    this.Opacity += 0.2;
                }
                if (MapSelection.Visible == true)
                {
                    if (this.Opacity == 1)
                    {
                        FadeIn.Enabled = false;
                    }
                    this.Opacity += 0.2;
                }
            }
        }

        private void FadeOut_Tick(object sender, EventArgs e)
        {
            if (Main.Visible == true)
            {
                if (this.Opacity == 0)
                {
                    Main.Visible = false;
                    CharacterSelection.Visible = true;
                    FadeOut.Enabled = false;
                    FadeIn.Enabled = true;
                }
                this.Opacity -= 0.2;
            }
            if (CharacterSelection.Visible == true)
            {
                if (this.Opacity == 0 && p2Chosen == true)
                {
                    FadeOut.Enabled = false;
                    CharacterSelection.Visible = false;
                    MapSelection.Visible = true;
                    FadeIn.Enabled = true;
                }
                this.Opacity -= 0.2;
            }
            if (MapSelection.Visible == true)
            {
                if (this.Opacity == 0 && MapChosen == true)
                {
                    player.Stop();
                    FadeOut.Enabled = false;
                    this.Hide();
                    Racegame frm = new Racegame(main, p1choice, p2choice, MapChoice);
                    frm.ShowDialog();
                    this.Close();
                }
                this.Opacity -= 0.1;
            }
        }

        private void BackgroundTimer_Tick(object sender, EventArgs e)
        {
            if (CurrentImage < 44)
            {
                CurrentImage++;
            }
            else
            {
                CurrentImage = 1;
            }
            Main.BackgroundImage = BackgroundImages[CurrentImage - 1];
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void SoundTimer_Tick(object sender, EventArgs e)
        {
                if (counter < 4)
                {
                    counter++;
                }
                if (counter >= 1)
                {
                    PlayQuit.Visible = true;
                }
                if (counter == 4)
                {
                    mainplayer = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, "sounds/Title screen.wav"));
                    mainplayer.PlayLooping();
                    SoundTimer.Enabled = false;
                    counter = 0;
            }          
        }

        private void PlayerTimer_Tick(object sender, EventArgs e) {
            if (CurrentImage < 4)
            {
                CurrentImage++;
            }
            else
            {
                CurrentImage = 1;
                PlayerUp = !PlayerUp;
            }
            CharacterSelection.BackgroundImage = Image.FromFile(Path.Combine(Environment.CurrentDirectory, "chars/Charscreen" + CurrentImage + ".png"));
            Console.WriteLine(CurrentImage);

            Jop.Location = new Point(Jop.Location.X, Jop.Location.Y - (PlayerUp ? ((CurrentImage - 1)) : - ((CurrentImage - 1))));
            Nynke.Location = new Point(Nynke.Location.X, Nynke.Location.Y - (PlayerUp ? ((CurrentImage - 1)) : - ((CurrentImage - 1))));
            Fiona.Location = new Point(Fiona.Location.X, Fiona.Location.Y - (PlayerUp ? ((CurrentImage - 1)) : - ((CurrentImage - 1))));
            Sibbele.Location = new Point(Sibbele.Location.X, Sibbele.Location.Y - (PlayerUp ? ((CurrentImage - 1)) : - ((CurrentImage - 1))));
            Joris.Location = new Point(Joris.Location.X, Joris.Location.Y - (PlayerUp ? ((CurrentImage - 1)) : - ((CurrentImage - 1))));
            Dick.Location = new Point(Dick.Location.X, Dick.Location.Y - (PlayerUp ? ((CurrentImage - 1)) : - ((CurrentImage - 1))));
            Jos.Location = new Point(Jos.Location.X, Jos.Location.Y - (PlayerUp ? ((CurrentImage - 1)) : - ((CurrentImage - 1))));
            David.Location = new Point(David.Location.X, David.Location.Y - (PlayerUp ? ((CurrentImage - 1)) : - ((CurrentImage - 1))));

        }
    }
}

