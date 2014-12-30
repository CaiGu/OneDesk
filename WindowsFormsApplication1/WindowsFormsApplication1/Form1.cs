using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



            private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeNode tn = e.Node.Parent;
                Boolean mark = false;
                int i = tn.Index;
                int j = e.Node.Index;
                if ((i == 0) && (j == 4)) { j = 9; mark = true; }
                if (!mark)
                {
                    if (i == 1)
                    {
                        i++;
                        if (j == 3) j = 12;
                        if (j == 4) j = 4;
                        if (j == 5) j = 14;
                        mark = true;
                    }
                }
                if (!mark)
                {
                    if (i == 2) { i++; mark = true; }
                }
                if (!mark)
                {
                    if (i == 3) { i++; if (j == 4) j++; mark = true; }
                }
                if (!mark)
                {
                    if (i == 4) { i = 10; mark = true; }
                }
                if (!mark)
                {
                    if (i == 5) { i = 15; j++; }
                }

                StringBuilder temp = new StringBuilder();
                ArrayList alist = Weather_News.Getnews(i, j);
                foreach (Hashtable h in alist)
                {
                    temp.Append("<tr><td class=\"style1\" align=\"center\";><a  class=\"style2\" href=\"#\" onclick=\"window.open('" + h["url"].ToString() + "')\"> " + h["title"].ToString() + "</a><br /><a class=\"style3\">" + h["description"].ToString() + "</a></td></tr>");
                }
                StreamReader sr = new StreamReader("news.html");
                string tem = sr.ReadToEnd();
                sr.Close();
                tem = tem.Replace("wait", temp.ToString());
                MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(tem));
                webBrowser1.DocumentStream = ms;
                //ms.Close();
            }
            catch (NullReferenceException)
            {
            }
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            Random rm = new Random();
            int i = rm.Next(60000, 80000);
            string temp = "http://slide.news.sina.com.cn/w/slide_1_53109_"+i.ToString()+".html";
            webBrowser1.Navigate(temp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://weather1.sina.cn");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string temp=Weather_News.Getjokes();
            StringBuilder s1 = new StringBuilder(temp);
            s1.Append("<tr><td algin=\"center\" styles=\"height: 150px;background-color: #99CCFF;\"><a class=\"style3\">" + s1 + "</a></td></tr>");
            StreamReader sr = new StreamReader("news.html");
            string tem = sr.ReadToEnd();
            sr.Close();
            tem = tem.Replace("wait", temp.ToString());
            MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(tem));
            webBrowser1.DocumentStream = ms;
            //ms.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://weather1.sina.cn");
        }
        
        
    }
}
