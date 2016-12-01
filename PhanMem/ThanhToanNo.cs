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
        int id_don = 0;
        double tongTienHang = 0;
        double daTra = 0;
        double conNo = 0;
        double traThem = 0;
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
            txtPayment.Enabled = false;
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
            // Tinh tong no
            SqlCommand cmdTo = new SqlCommand("SELECT *  FROM banhang WHERE customer= N'" + customerName + "' and no > 0 ", con);
            SqlDataReader readTo = cmdTo.ExecuteReader();

            while (readTo.Read())
            {
                firstColumn = readTo["id"].ToString();
                secondColumn = readTo["date"].ToString();
                threeColumn = string.Format("{0:n0}", readTo["sum"]);
                fourColumn = string.Format("{0:n0}", readTo["pay"]);
                fiveColum = string.Format("{0:n0}", readTo["no"]);
                sumNo += double.Parse(readTo["sum"].ToString());
                payment += double.Parse(readTo["pay"].ToString());
                conLai += double.Parse(readTo["no"].ToString());
                string[] row = { firstColumn, secondColumn, threeColumn, fourColumn, fiveColum };
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
                traThem = 0;
                txtPayment.Text = "0";
                txtPayment.Enabled = true;
                txtThanhToan.Visible = false;
                id_don = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                lblSumNo.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                tongTienHang = double.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                lblDaTra.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                daTra = double.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                lblConNo.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                conNo = double.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            }
            catch
            {

            }
        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtThanhToan_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            double thanhtoan = daTra + traThem;
            var query = "UPDATE banhang SET sum= '" + tongTienHang + "',pay = '" + thanhtoan + "',no = '" + conNo + "' WHERE id = '" + id_don + "' ";
            var cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@ma", 5);
            //cmd.Parameters.AddWithValue("@tongNo", tongNo);
            //cmd.Parameters.AddWithValue("@payment", (daTra+traThem));
            //cmd.Parameters.AddWithValue("@conLai", conNo);
            //cmd.Parameters.AddWithValue("@id", id_don);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Update thành công! ");
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            ShowData();
            txtThanhToan.Visible = false;
            txtPayment.Clear();
        }

        private void txtPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtThanhToan.Visible = true;
                traThem = double.Parse(txtPayment.Text);
                conNo = tongTienHang - traThem - daTra;
                lblConNo.Text = string.Format("{0:n0}", conNo);
                
            }
        }  
    }
}
