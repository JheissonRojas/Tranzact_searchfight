using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace c__search_engine
{
    class GetDataToSearch: DataGetter
    {
        public override string getData(){
            string data = ".net";  
            try{
               string fileName = "WordsToSearch.txt";
                string path = Path.Combine(Environment.CurrentDirectory, @"", fileName);
                data = File.ReadAllText(path);
                
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return data;
            
        }
    }
}