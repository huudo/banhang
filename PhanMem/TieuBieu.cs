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
    public partial class TieuBieu : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");
        public TieuBieu()
        {
            InitializeComponent();
        }

        private void TieuBieu_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            string firstColumn = "";
            string secondColumn = "";
            string threeColumn = "";
            string fourColumn = "";
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT TOP 5 id_mahang,SUM(soluong) as soluongban, SUM(tienhang) as doanhthu, SUM(loinhuan) as tonglai  FROM banhang_list  GROUP BY id_mahang ORDER BY soluongban DESC", con);
            SqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                firstColumn = read["id_mahang"].ToString();
                secondColumn = read["soluongban"].ToString();
                threeColumn = string.Format("{0:n0}", read["doanhthu"]);
                fourColumn = string.Format("{0:n0}", read["tonglai"]);
                string[] rowAdd = { firstColumn ,secondColumn,threeColumn,fourColumn};
                dataGridView1.Rows.Add(rowAdd);
            }
            read.Close();
            if (con.State != ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
