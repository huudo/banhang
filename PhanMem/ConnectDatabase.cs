using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace PhanMem
{
    class ConnectDatabase
    {
        public static SqlConnection querryConnect()
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");
            SqlConnection con = new SqlConnection(@"workstation id=quanlybh.mssql.somee.com;packet size=4096;user id=huudotrong_SQLLogin_1;pwd=tykj2yevh4;data source=quanlybh.mssql.somee.com;persist security info=False;initial catalog=quanlybh ");
            return con;
        }
    }
}
