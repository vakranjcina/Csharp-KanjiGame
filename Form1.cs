using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;


namespace SeminarKanjiGame
{
    public partial class Form1 : Form
    {
        string[] kanji = new string[48];
        string[] english = new string[48];
        string[] kana = new string[48];
        int ibutton = 0;
        byte opcija = 0;
        int tocno = 0;
        int netocno = 0;
        public string[] tocnosti = new string[50];
        int brtocno = 0;
        string radioCheck = "English -> Kanji";

        public Form1()
        {
            InitializeComponent();
            readingXML();
            nextKanji();
        }
        private void readingXML()
        {
            /*čita xml*/
            XmlDocument docu1 = new XmlDocument();
            docu1.Load("grade1xml.xml");
            int i = -1;
            foreach (XmlNode node in docu1.DocumentElement.ChildNodes)
            {
                foreach (XmlNode locNode in node)
                {
                    if (locNode.Name == "gradeID")
                        i += 1;
                    if (locNode.Name == "kanji1")
                        kanji[i] = locNode.InnerText;
                    if (locNode.Name == "kana1")
                        kana[i] = locNode.InnerText;
                    if (locNode.Name == "english1")
                        english[i] = locNode.InnerText;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {   
            /*prvi od 3 gumba izbora*/
            tocnost(1);
            nextKanji();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            /*drugi od 3 gumba izbora*/
            tocnost(2);
            nextKanji();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            /*treći od 3 gumba izbora*/
            tocnost(3);
            nextKanji();
        }
        private void tocnost(int br) 
        {
            /*provjerava točnost stisnutog gumba*/
            switch (br)
            {
                case 1:
                    if (ibutton == 1){
                        label2.Text = "Correct!";
                        label2.ForeColor = System.Drawing.Color.Green;
                        tocno += 1;
                        label3.Text = "Correct: " + tocno + ", " + "False: " + netocno;
                    } else if (button1.Text != "KA"){
                        label2.Text = "Wrong!";
                        label2.ForeColor = System.Drawing.Color.Red; 
                        netocno += 1;
                        label3.Text = "Correct: " + tocno + ", " + "False: " + netocno;
                    }
                    break;
                case 2:
                    if (ibutton == 2){
                        label2.Text = "Correct!";
                        label2.ForeColor = System.Drawing.Color.Green;
                        tocno += 1;
                        label3.Text = "Correct: " + tocno + ", " + "False: " + netocno;
                    }
                    else if (button1.Text != "KA"){
                        label2.Text = "Wrong!";
                        label2.ForeColor = System.Drawing.Color.Red;
                        netocno += 1;
                        label3.Text = "Correct: " + tocno + ", " + "False: " + netocno;
                    }
                    break;
                case 3:
                    if (ibutton == 3) {
                        label2.Text = "Correct!";
                        label2.ForeColor = System.Drawing.Color.Green;
                        tocno += 1;
                        label3.Text = "Correct: " + tocno + ", " + "False: " + netocno;
                    } else if (button1.Text != "KA"){
                        label2.Text = "Wrong!";
                        label2.ForeColor = System.Drawing.Color.Red;
                        netocno += 1;
                        label3.Text = "Correct: " + tocno + ", " + "False: " + netocno;
                    }
                    break;
            }
        }
        private void nextKanji()
        {
            /*random izbor sljedečeg seta igre*/
            Random rand = new Random();
            int broj = rand.Next(1, 48);
            int but1 = rand.Next(1, 48);
            int but2 = rand.Next(1, 48);
            ibutton = rand.Next(1, 4);
            string optionL = "";
            /*provjerava da nisu button 2 i 3 isti kao i 1*/
            while (but1 == broj)
                but1 = rand.Next(1, 48);
            while (but2 == broj)
                but2 = rand.Next(1, 48);
            /*upisivanje podataka u labelu koja pita*/
            switch (opcija)
            {
                case 0:
                case 2:
                    optionL = english[broj];
                    break;
                case 1:
                case 5:
                    optionL = kana[broj];
                    break;
                case 3:
                case 4:
                    optionL = kanji[broj];
                    break;
            }
            label1.Text = optionL;
            /*upisivanje podataka u gumbove za izbor*/
            switch (opcija) 
            {
                case 0:
                case 1:
                    switch (ibutton)
                    {
                        case 1: button1.Text = kanji[broj];
                            button2.Text = kanji[but1];
                            button3.Text = kanji[but2];
                            break;
                        case 2: button2.Text = kanji[broj];
                            button1.Text = kanji[but1];
                            button3.Text = kanji[but2];
                            break;
                        case 3: button3.Text = kanji[broj];
                            button2.Text = kanji[but1];
                            button1.Text = kanji[but2];
                            break;
                    }
                    break;
                case 2:
                case 3:
                    switch (ibutton)
                    {
                        case 1: button1.Text = kana[broj];
                            button2.Text = kana[but1];
                            button3.Text = kana[but2];
                            break;
                        case 2: button2.Text = kana[broj];
                            button1.Text = kana[but1];
                            button3.Text = kana[but2];
                            break;
                        case 3: button3.Text = kana[broj];
                            button2.Text = kana[but1];
                            button1.Text = kana[but2];
                            break;
                    }
                    break;
                case 4:
                case 5:
                    switch (ibutton)
                    {
                        case 1: button1.Text = english[broj];
                            button2.Text = english[but1];
                            button3.Text = english[but2];
                            break;
                        case 2: button2.Text = english[broj];
                            button1.Text = english[but1];
                            button3.Text = english[but2];
                            break;
                        case 3: button3.Text = english[broj];
                            button2.Text = english[but1];
                            button1.Text = english[but2];
                            break;
                    }
                    break;
            }
        }
        private void radioButton2_Click(object sender, EventArgs e)
        {
            /*ovo je izbor english -> kanji radio gumb*/
            opcija = 0;
            radioCheck = "English -> Kanji";
        }
        private void radioButton1_Click(object sender, EventArgs e)
        {
            /*ovo je izbor kana -> kanji radio gumb*/
            opcija = 1;
            radioCheck = "Kana -> Kanji";
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            /*ovo je izbor english -> kana radio gumb*/
            opcija = 2;
            radioCheck = "English -> Kana";
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            /*ovo je izbor kanji -> kana radio gumb*/
            opcija = 3;
            radioCheck = "Kanji -> Kana";
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            /*ovo je izbor kanji -> enlish radio gumb*/
            opcija = 4;
            radioCheck = "Kanji -> English";
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            /*ovo je izbor kana -> enlish radio gumb*/
            opcija = 5;
            radioCheck = "Kana -> English";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            /*ovo je reset gumb*/
            gumb4();
        }
        public void gumb4() 
        {
            tocnosti[brtocno] = label3.Text + " " + radioCheck + Environment.NewLine;
            brtocno += 1;
            tocno = 0;
            netocno = 0;
            label3.Text = "Correct: " + tocno + ", " + "False: " + netocno;
            opcija = 0;
            radioButton2.PerformClick();
            label2.Text = "Tocnost";
            nextKanji();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            /*ispis xml-a koji se koristi*/
            if (tocno != 0 && netocno != 0)
                gumb4();
            int broj1 = 0;
            Form2 f2 = new Form2();
            foreach (string str1 in tocnosti)
            {
                f2.strii[broj1] = str1;
                broj1 += 1;
            }
            f2.ShowDialog();
            //this.Close();
        }
    }
}
