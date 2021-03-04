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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadXML(@"http://qibao.gyyx.cn/Buy/GetItemInfoXMLByItemId/66630823");
        }

        private void ReadXML(string path)
        {
            XDocument xdoc = XDocument.Load(path); //加载xml文件
            XElement rootSchool = xdoc.Root; //获取根元素
            //Console.WriteLine(rootSchool.Name); //根元素的名字
            IEnumerable<XElement> xeles = rootSchool.Elements(); //获取根元素下所有的直接子元素
            string[,] array = GetXmlArray(xeles);
            for (int i=0;i<array.Length/2;i++)
            {
                textBox1.AppendText(array[i, 0]);
                textBox1.AppendText("=");
                textBox1.AppendText(array[i, 1]);
                textBox1.AppendText("\r\n");
            }
        }

        private string[,] GetXmlArray(IEnumerable<XElement> xElement)
        {
            List<string> listname = new List<string>();
            List<string> listvalue = new List<string>();
            foreach (XElement xele1 in xElement)
            {
                if (xele1.HasElements)
                {
                    foreach (XElement xele2 in xele1.Elements())
                    {
                        if (xele2.HasElements)
                        {
                            foreach (XElement xele3 in xele2.Elements())
                            {
                                if (xele3.HasElements)
                                {
                                    foreach (XElement xele4 in xele3.Elements())
                                    {
                                        if (xele4.HasElements)
                                        {
                                            foreach (XElement xele5 in xele4.Elements())
                                            {
                                                if (xele5.HasElements)
                                                {

                                                    foreach (XElement xele6 in xele5.Elements())
                                                    {
                                                        listname.Add(xele1.Name.ToString() + "-" + xele2.Name.ToString() + "-" + xele3.Name.ToString() + "-" + xele4.Name.ToString() + "-" + xele5.Name.ToString() + "-" + xele6.Name.ToString());
                                                        listvalue.Add(xele1.Value);
                                                    }
                                                }
                                                else
                                                {
                                                    listname.Add(xele1.Name.ToString() + "-" + xele2.Name.ToString() + "-" + xele3.Name.ToString() + "-" + xele4.Name.ToString() + "-" + xele5.Name.ToString());
                                                    listvalue.Add(xele5.Value);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            listname.Add(xele1.Name.ToString() + "-" + xele2.Name.ToString() + "-" + xele3.Name.ToString() + "-" + xele4.Name.ToString());
                                            listvalue.Add(xele4.Value);
                                        }

                                    }
                                }
                                else
                                {
                                    listname.Add(xele1.Name.ToString() + "-" + xele2.Name.ToString() + "-" + xele3.Name.ToString());
                                    listvalue.Add(xele3.Value);
                                }
                            }
                        }
                        else
                        {
                            listname.Add(xele1.Name.ToString() + "-" + xele2.Name.ToString());
                            listvalue.Add(xele2.Value);
                        }
                    }
                }
                else
                {
                    listname.Add(xele1.Name.ToString());
                    listvalue.Add(xele1.Value);
                }
            }
            string[,] array = new string[listname.Count, 2];
            for (int i = 0; i < listname.Count; i++)
            {
                array[i, 0] = listname[i];
                array[i, 1] = listvalue[i];
            }
            return array;
        }
    }
}
