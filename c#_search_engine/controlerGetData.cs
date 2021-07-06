using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace c__search_engine
{
    class ControlerGetData
    {
        public string data;
        public string getDataToSearch(){
            GetDataToSearch newdata = new GetDataToSearch();
            data = newdata.getData();
            return data;
        }
        
    }
}