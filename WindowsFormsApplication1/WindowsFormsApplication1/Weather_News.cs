using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml;
using System.Net;

namespace WindowsFormsApplication1
{
    class Weather_News
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
                temp = temp.Replace("\r", "");
                temp = temp.Replace("\n", "");
                temp = temp.Replace("&nbsp", "");
                //temp = temp.Trim();
                hashtable1.Add("description", temp);
                alist.Add(hashtable1);
            }
            return alist;
        }

        public static String Getjokes()
        {
            string site = "http://www.djdkx.com/open/randxml";
            string info;
            XmlDocument doc = new XmlDocument();
            XmlNode node;
            //http://www.djdkx.com/open/randxml随机笑话接口
            try
            {
                WebClient webclient = new WebClient();
                webclient.BaseAddress = site;
                webclient.Encoding = Encoding.UTF8;
                info = webclient.DownloadString(site);

                doc.Load(site);
                node = doc.SelectSingleNode("//content");
                info = node.InnerText;
                info = info.Replace("<br/>", "");
                info = info.Replace("&nbsp;", "");
                info = info.Replace("  ", "").Trim();
            }
            catch (WebException e)
            {
                info = e.Message;
            }
            return info;
        }

        public static Hashtable Getweather(string location)
        {
            //返回嵌套HASH表结构

            String basesite = "http://api.map.baidu.com/telematics/v3/weather";
            string ak = "62E1eef36b2a1e58016f864a5afea444";
            XmlDocument doc = new XmlDocument();
            new XmlReaderSettings().IgnoreComments = true;
            WebClient webclient = new WebClient();
            webclient.BaseAddress = basesite;
            webclient.Encoding = Encoding.UTF8;
            webclient.QueryString.Add("location", location);
            webclient.QueryString.Add("ak", ak);
            try
            {
                doc.Load(webclient.OpenRead(basesite));
            }
            catch (WebException e)
            {
                Hashtable temp = new Hashtable(2);
                temp.Add("error", e.Message);
                temp.Add("status", e.Message);
                return temp;
            }
            Hashtable data = new Hashtable(15);
            data.Add("error", doc.SelectSingleNode("//error").InnerText);
            data.Add("status", doc.SelectSingleNode("//status").InnerText);
            data.Add("date", doc.SelectSingleNode("//date").InnerText);
            /*if (Convert.ToInt32(state["error"])== 0 )
                return "ok";
            return "no";*/
            //测试代码段
            if (Convert.ToInt32(data["error"]) != 0)
                return data;
            data.Add("city", doc.SelectSingleNode("//currentCity").InnerText);
            data.Add("pm25", doc.SelectSingleNode("//pm25").InnerText);
            XmlNodeList nodelist = doc.SelectNodes("//des");
            data.Add("cloth", nodelist[0].InnerText);
            data.Add("carwash", nodelist[1].InnerText);
            data.Add("tourism", nodelist[2].InnerText);
            data.Add("sick", nodelist[3].InnerText);
            data.Add("sport", nodelist[4].InnerText);
            data.Add("light", nodelist[5].InnerText);
            
            Hashtable today = new Hashtable(6);
            Hashtable tomorrow = new Hashtable(6);
            Hashtable afterday = new Hashtable(6);
            XmlNode xnode = doc.SelectSingleNode("//weather_data");
            XmlNodeList templist = xnode.SelectNodes("./date");
            today.Add("date", templist[0].InnerText);
            tomorrow.Add("date", templist[1].InnerText);
            afterday.Add("date", templist[2].InnerText);

            templist=xnode.SelectNodes("./dayPictureUrl");
            today.Add("daypicurl",templist[0].InnerText);
            tomorrow.Add("daypicurl",templist[1].InnerText);
            afterday.Add("daypicurl", templist[2].InnerText);

            templist = xnode.SelectNodes("./nightPictureUrl");
            today.Add("night",templist[0].InnerText);
            tomorrow.Add("night", templist[1].InnerText);
            afterday.Add("night", templist[2].InnerText);

            templist = xnode.SelectNodes("./weather");
            today.Add("weather",templist[0].InnerText);
            tomorrow.Add("weather", templist[1].InnerText);
            afterday.Add("weather", templist[2].InnerText);

            templist = xnode.SelectNodes("./wind");
            today.Add("wind",templist[0].InnerText);
            tomorrow.Add("wind", templist[1].InnerText);
            afterday.Add("wind", templist[2].InnerText);

            templist = xnode.SelectNodes("./temperature");
            today.Add("temperature",templist[0].InnerText);
            tomorrow.Add("temperature", templist[1].InnerText);
            afterday.Add("temperature", templist[2].InnerText);



            data.Add("today", today);
            data.Add("tomorrow", tomorrow);
            data.Add("afterday", afterday);

            return data;
        }
    }
}
