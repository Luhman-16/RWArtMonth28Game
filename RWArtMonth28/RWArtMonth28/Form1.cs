using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RWArtMonth28.Properties;
using System.Xml;

namespace RWArtMonth28
{
    public partial class Form1 : Form
    {
        public enum Character
        {
            None,
            Enot,
            Survivor,
            Monk,
            ArtiHunter,
            Gourmand,
            Scavenger,
            Rivulet,
            Spearmaster,
            Saint
        }

        public XmlDocument mScenarios;
        XmlElement mCurrentElement;
        XmlNode mStoryNode;
        bool mEnableNext;
        int mCurrentPage;
        int mStory;
        bool mDie;
        Character mCurrentLeft;
        Character mCurrentRight;


        public Form1()
        {
            InitializeComponent();
            mScenarios = new XmlDocument();
            mScenarios.Load(@".\Resources\Scenarios.xml");
            mCurrentElement = mScenarios.DocumentElement;
            mStoryNode = mCurrentElement.FirstChild;

            mEnableNext = true;
            mCurrentPage = 2;
            mStory = 0;
            mDie = false;

            mCurrentLeft = Character.Enot;
            mCurrentRight = Character.None;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetScenario(Character.None, Character.None, "Welcome to my silly little game :3 \n You must be SILLY to be able to play. GET OUT IF YOU ARE NOT SILLY!!!!11!!! \n anYWAYYY, press any arrow keys to go to the next page" +
                "\nThis game was made by Luhman16 on tumblr, feel free to contact me if you have any questions, requests, want the full game code, or if you just feel silly");
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            mStory = 0;
            int Childs = mStoryNode.ChildNodes.Count;
            mStoryNode = mStoryNode.ChildNodes[Childs - 4 + mStory];
            string Page = mStoryNode.FirstChild.InnerText;
            mCurrentLeft = GetCharacter(true);
            mCurrentRight = GetCharacter(false);

            mEnableNext = true;

            Form1_KeyUp(null, null);
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            mStory = 1;

            int Childs = mStoryNode.ChildNodes.Count;
            mStoryNode = mStoryNode.ChildNodes[Childs - 4 + mStory];
            string Page = mStoryNode.FirstChild.InnerText;
            System.Console.WriteLine(Page);
            mCurrentLeft = GetCharacter(true);
            mCurrentRight = GetCharacter(false);

            mEnableNext = true;

            Form1_KeyUp(null, null);
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            mStory = 2;

            int Childs = mStoryNode.ChildNodes.Count;
            mStoryNode = mStoryNode.ChildNodes[Childs - 4 + mStory];
            string Page = mStoryNode.FirstChild.InnerText;
            System.Console.WriteLine(Page);
            mCurrentLeft = GetCharacter(true);
            mCurrentRight = GetCharacter(false);

            mEnableNext = true;

            Form1_KeyUp(null, null);
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            mStory = 3;

            int Childs = mStoryNode.ChildNodes.Count;
            mStoryNode = mStoryNode.ChildNodes[Childs - 4 + mStory];
            string Page = mStoryNode.FirstChild.InnerText;
            System.Console.WriteLine(Page);
            mCurrentLeft = GetCharacter(true);
            mCurrentRight = GetCharacter(false);

            mEnableNext = true;

            Form1_KeyUp(null, null);
        }

        public void SetScenario(Character CharaLeft, Character CharaRight, string Text)
        {
            SetPictureBox(pictureBox_Left, CharaLeft);
            SetPictureBox(pictureBox_Right, CharaRight);

            CheckSpecial(Text);

            label1.Text = Text;

            btn_1.Enabled = false;
            btn_2.Enabled = false;
            btn_3.Enabled = false;
            btn_4.Enabled = false;
            btn_1.Text = "";
            btn_2.Text = "";
            btn_3.Text = "";
            btn_4.Text = "";

        }

        public void SetScenario(Character CharaLeft, Character CharaRight, string Text, string Button1, string Button2, string Button3, string Button4)
        {
            SetPictureBox(pictureBox_Left, CharaLeft);
            SetPictureBox(pictureBox_Right, CharaRight);

            CheckSpecial(Text);

            label1.Text = Text;

            btn_1.Enabled = true;
            btn_2.Enabled = true;
            btn_3.Enabled = true;
            btn_4.Enabled = true;
            btn_1.Text = Button1;
            btn_2.Text = Button2;
            btn_3.Text = Button3;
            btn_4.Text = Button4;

            System.Threading.Thread.Sleep(100);
        }

        public void SetPictureBox(PictureBox PB, Character Chara)
        {
            switch (Chara)
            {
                case Character.Enot:
                    PB.Image = RWArtMonth28.Properties.Resources.RWEnot;
                    break;
                case Character.ArtiHunter:
                    PB.Image = RWArtMonth28.Properties.Resources.RWArtiHunter;
                    break;
                case Character.Gourmand:
                    PB.Image = RWArtMonth28.Properties.Resources.RWGourmand;
                    break;
                case Character.Monk:
                    PB.Image = RWArtMonth28.Properties.Resources.RWMonk;
                    break;
                case Character.Rivulet:
                    PB.Image = RWArtMonth28.Properties.Resources.RWRivulet;
                    break;
                case Character.Saint:
                    PB.Image = RWArtMonth28.Properties.Resources.RWSaint;
                    break;
                case Character.Scavenger:
                    PB.Image = RWArtMonth28.Properties.Resources.RWScav;
                    break;
                case Character.Spearmaster:
                    PB.Image = RWArtMonth28.Properties.Resources.RWSpearmaster;
                    break;
                case Character.Survivor:
                    PB.Image = RWArtMonth28.Properties.Resources.RWSurvivor;
                    break;
                default:
                    PB.Image = null;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            if (mDie)
            {
                //Sound GG gamer
                this.Close();
            }
            else
            {
                if (mEnableNext)
                {
                    bool HasButtons = mStoryNode.LastChild.Name.Equals("Story4");
                    int RemoveLast = 9;
                    if (!HasButtons)
                    {
                        RemoveLast = 1;
                    }


                    if (mCurrentPage < mStoryNode.ChildNodes.Count - RemoveLast)
                    {
                        string Page = mStoryNode.ChildNodes[mCurrentPage].InnerText;
                        System.Console.WriteLine(Page);
                        SetScenario(mCurrentLeft, mCurrentRight, Page);

                        mCurrentPage++;
                    } else
                    {
                        if (mCurrentPage == mStoryNode.ChildNodes.Count - RemoveLast)
                        {
                            string Page = mStoryNode.ChildNodes[mCurrentPage].InnerText;
                            if (HasButtons)
                            {
                                string Button1 = mStoryNode.ChildNodes[mCurrentPage + 1].InnerText;
                                string Button2 = mStoryNode.ChildNodes[mCurrentPage + 2].InnerText;
                                string Button3 = mStoryNode.ChildNodes[mCurrentPage + 3].InnerText;
                                string Button4 = mStoryNode.ChildNodes[mCurrentPage + 4].InnerText;
                                System.Console.WriteLine(Page);
                                SetScenario(mCurrentLeft, mCurrentRight, Page, Button1, Button2, Button3, Button4);
                            }
                            else
                            {
                                SetScenario(mCurrentLeft, mCurrentRight, Page);
                                mDie = true;
                            }

                            mCurrentPage = 2;
                            mEnableNext = false;
                        }
                    }

                }

            }
        }

        public void Backflip(bool left)
        {
            PictureBox Pb = pictureBox_Right;
            if (left)
            {
                Pb = pictureBox_Left;
            }

            Pb.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            this.Update();
            System.Threading.Thread.Sleep(100);
        }

        public Character GetCharacter(bool left)
        {
            Character Chara = Character.None;
            int Index = 1;
            if (left)
            {
                Index = 0;
            }

            string CharaString = mStoryNode.ChildNodes[Index].InnerText;
            Enum.TryParse(CharaString, out Chara);

            return Chara;
        }

        public void CheckSpecial(string line)
        {
            if (line.Contains("/Backflip"))
            {
                if (line.Contains("Rivulet"))
                {
                    Backflip(false);
                }
                else if (line.Contains("Enot"))
                {
                    Backflip(true);
                }
            }
            else if (line.Contains("/Chad"))
            {
                pictureBox_Left.Image = RWArtMonth28.Properties.Resources.RWEnotVirgin;
                pictureBox_Right.Image = RWArtMonth28.Properties.Resources.RWArtihunterChad;
            }
        }
    }
}
