using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace 问道扫货
{
    class XmlToArray
    {
        public Array ReadXML(string path)
        {
            XDocument xdoc = XDocument.Load(path); //加载xml文件
            XElement rootSchool = xdoc.Root; //获取根元素
            //Console.WriteLine(rootSchool.Name); //根元素的名字
            IEnumerable<XElement> xeles = rootSchool.Elements(); //获取根元素下所有的直接子元素
            string[,] array = GetXmlArray(xeles);
            return array;
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
