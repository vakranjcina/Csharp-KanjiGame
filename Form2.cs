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
    public partial class Form2 : Form
    {
        string[] xml = new string[500];
        public string[] strii = new string[50];
        public Form2()
        {
            InitializeComponent();
            readingXML();
        }
        private void readingXML()
        {
            XmlDocument docu2 = new XmlDocument();
            docu2.Load("grade1xml.xml");
            int i = 0;
            foreach (XmlNode node in docu2.DocumentElement.ChildNodes)
            {
                foreach (XmlNode locNode in node)
                {
                    xml[i] = locNode.InnerText + " | ";
                    if (locNode.Name == "english1")
                        xml[i] = locNode.InnerText + Environment.NewLine;
                    i += 1;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            foreach (string node in xml)
                label2.Text += node;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            Form1 fori = new Form1();
            foreach (string str in strii)
                label2.Text += str;
        }
    }
}
