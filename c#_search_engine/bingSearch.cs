using System;
using System.Xml.XPath;
using System.Xml.Xsl;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Net;

namespace c__search_engine
{
    class bingSearch : searchEngine
    {
        public override double getAmountOfResults(string data)
        {
            
            Operations newoperation = new Operations();
            double amount = 0;
            try
            {
               
                string url = "https://www.bing.com/search?q=" + data;
                var webPage = new HtmlWeb().Load(url);
                var divContent = webPage.DocumentNode.SelectSingleNode("//span[@class='sb_count']");
                string text = divContent.InnerHtml;
                amount = newoperation.getAmount(text,0,text.IndexOf('r')-1);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return amount;
        }
        
    }
}