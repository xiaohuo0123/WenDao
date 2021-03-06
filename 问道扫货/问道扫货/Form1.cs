using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace 问道扫货
{
    public partial class Form1 : Form
    {
        XmlToArray XmlToArray = new XmlToArray();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[,] array = (string[,])XmlToArray.ReadXML(@"http://qibao.gyyx.cn/Buy/GetItemInfoXMLByItemId/66630823");
            for (int i = 0; i < array.Length / 2; i++)
            {
                textBox1.AppendText(array[i, 0]);
                textBox1.AppendText("=");
                textBox1.AppendText(array[i, 1]);
                textBox1.AppendText("\r\n");
            }
        }
    }
}
