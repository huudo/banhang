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
    public partial class Payment : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");
        private string customer_name = "";
        private string id_MaDon = "";
        private int id_maNo = 0;
        private string total = "";
        private string debt = "";
        public Payment(string maNo,string id_donHang,string customer,string totalSend,string debtSend)
        {

            InitializeComponent();
            customer_name = customer;
            id_MaDon = id_donHang;
            id_maNo = Int32.Parse(maNo);
            total = totalSend;
            debt = debtSend;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        public void showData()
        {
            if(con.State != ConnectionState.Open)
            {
                con.Open();
            }
            string firstColumn = "";
            string secondColumn = "";
            string threeColumn = "";
            // Tinh tong no
            SqlCommand cmdTo = new SqlCommand("SELECT *  FROM detailNo WHERE id_No = '"+ id_maNo +"' ", con);
            SqlDataReader readTo = cmdTo.ExecuteReader();

            while (readTo.Read())
            {
                firstColumn = readTo["date"].ToString();
                secondColumn = string.Format("{0:n0}", readTo["payment"]);  
                threeColumn = string.Format("{0:n0}", readTo["debt"]);             
                string[] row = { firstColumn, secondColumn, threeColumn };
                dataGridView1.Rows.Add(row);
            }
            readTo.Close();
            if (con.State != ConnectionState.Open)
            {
                con.Close();
            }
        }
        private void Payment_Load(object sender, EventArgs e)
        {
            btnPayment.Visible = false;
            lblCustomer.Text = customer_name;
            lbldonHang.Text = id_MaDon;
            lblTotal.Text = total;
            lblDebt.Text = debt;
            showData();
        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            btnPayment.Visible = true;
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            float pay = float.Parse(txtPayment.Text);
            
        }


    }
}
