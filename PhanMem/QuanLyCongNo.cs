using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PhanMem
{
    public partial class QuanLyCongNo : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");
        public QuanLyCongNo()
        {
            InitializeComponent();
        }

        private void QuanLyCongNo_Load(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmdTo = new SqlCommand("SELECT SUM(tongno) as tongno FROM quanlyno WHERE type =2 AND tongno > 0 ", con);
            SqlDataReader readTo = cmdTo.ExecuteReader();
            while (readTo.Read())
            {

                if (readTo["tongno"].ToString() != "")
                {
                    lblCanThu.Text = string.Format("{0:n0}", readTo["tongno"]);
                  
                }
                else
                {
                    lblCanThu.Text = "0";
                }

            }
            readTo.Close();
            SqlCommand cmdTo2 = new SqlCommand("SELECT SUM(tongno) as tongno FROM quanlyno WHERE type = 1 AND tongno > 0 ", con);
            SqlDataReader readTo2 = cmdTo2.ExecuteReader();
            while (readTo2.Read())
            {

                if (readTo2["tongno"].ToString() != "")
                {
                    lblCanTra.Text = string.Format("{0:n0}", readTo2["tongno"]);

                }
                else
                {
                    lblCanTra.Text = "0";
                }

            }
            readTo2.Close();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            NoPhaiTra fram = new NoPhaiTra();
            fram.Show();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            QuanLyNo fram = new QuanLyNo();
            fram.Show();
        }
    }
}
