using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PhanMem
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
<<<<<<< HEAD
            Application.SetCompatibleTextRenderingDefault(false);
            SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");
            con.Open();
            SqlDataAdapter check = new SqlDataAdapter("Select email from account ", con);
            DataTable dt = new DataTable();
            check.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Application.Run(new frmMain());
            }
            else
            {
                Application.Run(new Welcome());
            }
            con.Close();
=======
            Application.SetCompatibleTextRenderingDefault(false);           
            Application.Run(new Login());
           
>>>>>>> 20f7e7cdd68672c6eb044722f7ada001ea0c88bd
            
        }
    }
}
