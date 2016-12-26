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
    public partial class NoPhaiTra : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");
        public NoPhaiTra()
        {
            InitializeComponent();
        }
        public void showData()
        {
            double totalDebt = 0;
            string firstColumn = "";
            string secondColumn = "";
            string threeColumn = "";
            string fourColumn = "";
            string fiveColumn = "";
            string sixColumn = "";
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            // Tinh tong no
            SqlCommand cmdTo = new SqlCommand("SELECT * FROM quanlyno WHERE type = 1  AND tongno > 0 ", con);
            SqlDataReader readTo = cmdTo.ExecuteReader();

            while (readTo.Read())
            {

                if (readTo["tongno"].ToString() != "")
                {
                    totalDebt += double.Parse(readTo["tongno"].ToString());
                    firstColumn = readTo["id_don"].ToString();
                    secondColumn = readTo["id_No"].ToString();
                    threeColumn = readTo["date"].ToString();
                    fourColumn = string.Format("{0:n0}", readTo["total"]);
                    fiveColumn = string.Format("{0:n0}", readTo["tongtra"]);
                    sixColumn = string.Format("{0:n0}", readTo["tongno"]); 

                    string[] row = { firstColumn, secondColumn, threeColumn, fourColumn, fiveColumn, sixColumn };
                    dataGridView1.Rows.Add(row);
                }
                else
                {

                }

            }
            readTo.Close();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            lblTongNo.Text = string.Format("{0:n0}", totalDebt);
        }
        private void NoPhaiTra_Load(object sender, EventArgs e)
        {
            showData();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string id_maNo = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string id_maHang = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                DetailTraNo frm = new DetailTraNo(id_maNo, id_maHang);
                frm.ShowDialog();

                //WHEN SHOWDIALOG() END
                frm.Dispose();
                dataGridView1.Rows.Clear();
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                showData();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch
            {

            }
        }
    }
}
