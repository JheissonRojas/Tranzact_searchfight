using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace c__search_engine
{
    public class StartSearch
    {
        public const string SearchEngine1 = "Bing";
        public const string SearchEngine2 = "Google";
        public static searchEngine creatorSearchEngine(string type){
            switch (type){
                case SearchEngine1:
                    return new bingSearch();
                case SearchEngine2:
                    return new googleSearch();
                default: return null;
            }
        }
    
        
    }
}