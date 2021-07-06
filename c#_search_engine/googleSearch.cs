using System;
using System.Xml.XPath;
using System.Xml.Xsl;
//using System.Json.Linq.JObject;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
//using System.Web.Script.Serialization;
using System.Threading;
using System.Net;

namespace c__search_engine
{
    class googleSearch : searchEngine
    {
        public override double getAmountOfResults(string data)
        {
            Operations newoperation = new Operations();
            double amount = 0;
            try
            {
                string cadresultini="totalResults\"";
                string cadresultend="searchTerms\"";                         
                string apiKey = "AIzaSyA9ZJn3Q69HHopeOljWIc-MOjbcXApbBHs";
                string cx = "f528620106e550893";
                string query = data;
                WebClient webClient = new WebClient();
                webClient.Headers.Add("searchfight", "searchfigth");
                string results = webClient.DownloadString(String.Format("https://www.googleapis.com/customsearch/v1?key={0}&cx={1}&q={2}&alt=json", apiKey, cx, query));
                int addini = cadresultini.Length+3;
                int removeend = 12;
                results = results.Replace("\n","_");
                results = results.Replace("\t","_");
                int posstart = results.IndexOf(cadresultini);
                int posend = results.IndexOf(cadresultend);
                posstart += addini;
                posend -= removeend;
                amount = newoperation.getAmount(results,posstart,(posend-posstart));
                string data1 = results.Substring(posstart,(posend-posstart));
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return amount;
        }
        
    }
}