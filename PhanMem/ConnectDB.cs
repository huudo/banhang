using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace PhanMem
{
    class ConnectDB
    {
        
        public string strConnect() 
        {
            string str =    @"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf";
            return str;
        }
       
       
         
    }
}
