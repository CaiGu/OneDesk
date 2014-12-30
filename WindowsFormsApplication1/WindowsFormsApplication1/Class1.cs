using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml;
using System.Collections;

namespace WindowsFormsApplication1
{
    class Class1
    {

        public static ArrayList Getnews(int index1, int index2)
        {
            string basesite = "http://rss.sina.com.cn/sina_all_opml.xml";
            XmlDocument basexml = new XmlDocument();            
            WebClient webclient = new WebClient();
            string temp;
            ArrayList alist = new ArrayList();
            Hashtable hashtable = new Hashtable(3);

            webclient.BaseAddress = basesite;
            webclient.Encoding = Encoding.UTF8;

            try
            {
                temp = webclient.DownloadString(basesite);
                basexml.LoadXml("<?xml version=\"1.0\"?>\n" + temp);
                temp = webclient.DownloadString(basexml.SelectSingleNode("//body").ChildNodes.Item(index1).ChildNodes.Item(index2).Attributes["xmlUrl"].Value);
            }
            catch (WebException e)
            {
                hashtable.Add("title", "error");
                hashtable.Add("url", "");
                hashtable.Add("desctiption", e.Message);
                alist.Add(hashtable);
                return alist;
            }
            basexml.LoadXml(temp);
            hashtable.Add("title", basexml.SelectSingleNode("//description").InnerText);
            hashtable.Add("url", "");
            hashtable.Add("description", "");
            alist.Add(hashtable);
            XmlNodeList xlist = basexml.DocumentElement.SelectNodes("//item");
            foreach (XmlNode xnode in xlist)
            {                
                Hashtable hashtable1 = new Hashtable(3);
                hashtable1.Add("title", xnode.SelectSingleNode("./title").InnerText);
                hashtable1.Add("url", xnode.SelectSingleNode("./link").InnerText);
                temp = xnode.SelectSingleNode("./description").InnerText;
                temp = temp.Replace(" ", "");
                temp = temp.Replace("\r","");
                temp=temp.Replace("\n","");
                temp = temp.Replace("&nbsp", "");
                //temp = temp.Trim();
                hashtable1.Add("description", temp);
                alist.Add(hashtable1);
            }
            return alist;
                
            
            
        }


    }
}
