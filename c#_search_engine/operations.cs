using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace c__search_engine
{
    class Operations
    {
        public double getAmount(string cad, int startcad, int endcad )
        {
           string data; 
           double amount; 
           
           data = cad.Substring(startcad,endcad);
           data = data.Trim();
           data = data.Replace(".","");
           amount = double.Parse(data);
           return amount;
        }
        
    }
}