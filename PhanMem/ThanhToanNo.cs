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
    public partial class ThanhToanNo : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");
        string customerName = "";

        public ThanhToanNo(string name)
        {
            InitializeComponent();
            customerName = name;            
        }

        private void ThanhToanNo_Load(object sender, EventArgs e)
        {
            lblKhachHang.Text = customerName;
            ShowData();
        }
        void ShowData()
        {
            dataGridView1.Rows.Clear();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            double sumNo = 0;
            double payment = 0;
            double conLai = 0;
            string firstColumn = "";
            string secondColumn = "";
            string threeColumn = "";
            string fourColumn = "";
            string fiveColum = "";
            string sixColum = "";
            // Tinh tong no
            SqlCommand cmdTo = new SqlCommand("SELECT *  FROM quanlyno WHERE type = 2 AND customer= N'" + customerName + "' and tongno > 0 ", con);
            SqlDataReader readTo = cmdTo.ExecuteReader();

            while (readTo.Read())
            {
                firstColumn = readTo["id_No"].ToString();
                secondColumn = readTo["id_don"].ToString();
                threeColumn = readTo["date"].ToString();
                fourColumn = string.Format("{0:n0}", readTo["total"]);
                fiveColum = string.Format("{0:n0}", readTo["tongtra"]);
                sixColum = string.Format("{0:n0}", readTo["tongno"]);
                sumNo += double.Parse(readTo["total"].ToString());
                payment += double.Parse(readTo["tongtra"].ToString());
                conLai += double.Parse(readTo["tongno"].ToString());
                string[] row = { firstColumn, secondColumn, threeColumn, fourColumn, fiveColum,sixColum };
                dataGridView1.Rows.Add(row);
            }
            readTo.Close();
            lblSumNo.Text = string.Format("{0:n0}", sumNo);
            lblDaTra.Text = string.Format("{0:n0}", payment);
            lblConNo.Text = string.Format("{0:n0}", conLai);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //traThem = 0;
                //txtPayment.Text = "0";
                //txtPayment.Enabled = true;
                //txtThanhToan.Visible = false;
                //id_don = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                //lblSumNo.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                //tongTienHang = double.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                //lblDaTra.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                //daTra = double.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                //lblConNo.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                //conNo = double.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
                
                string id_maNo = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string id_donHang = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string total = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string debt = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                Payment frm = new Payment(id_maNo, id_donHang, customerName, total, debt);
                frm.ShowDialog();
                //WHEN SHOWDIALOG() END
                frm.Dispose();
                dataGridView1.Rows.Clear();
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                ShowData();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch
            {

            }
        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {

        }
       
    }
}
