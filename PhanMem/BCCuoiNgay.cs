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
    public partial class BCCuoiNgay : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");
        public BCCuoiNgay()
        {
            InitializeComponent();
        }

        private void BCCuoiNgay_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            lblDate.Text = date.ToString("dd/MM/yyy");
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;
            string firstColumn = "";
            string secondColumn = "";
            string threeColumn = "";
            string fourColumn = "";
            string fiveColumn = "";
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT  id_don, total , profit,tongno,tongtra  FROM quanlyno WHERE type = 2 AND date = '" + date.ToString("yyy/MM/dd") + "' ", con);
            SqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                firstColumn = "MH"+read["id_don"].ToString();
                secondColumn = string.Format("{0:n0}", read["total"]);
                threeColumn = string.Format("{0:n0}", read["profit"]);
                fourColumn = string.Format("{0:n0}", read["tongtra"]);
                fiveColumn = string.Format("{0:n0}", read["tongno"]);
                string[] rowAdd = { firstColumn, secondColumn, threeColumn, fourColumn,fiveColumn };
                dataGridView1.Rows.Add(rowAdd);
            }
            read.Close();
            SqlCommand cmd2 = new SqlCommand("SELECT  id_don, total ,tongno,tongtra  FROM quanlyno WHERE type = 1 AND date = '" + date.ToString("yyy/MM/dd") + "' ", con);
            SqlDataReader read2 = cmd2.ExecuteReader();

            while (read2.Read())
            {
                firstColumn = "NH" + read2["id_don"].ToString();
                secondColumn = string.Format("{0:n0}", read2["total"]);
                threeColumn = string.Format("{0:n0}", read2["tongtra"]);
                fourColumn = string.Format("{0:n0}", read2["tongno"]);
                string[] rowAdd2 = { firstColumn, secondColumn, threeColumn, fourColumn };
                dataGridView2.Rows.Add(rowAdd2);
            }
            read2.Close();
            if (con.State != ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
