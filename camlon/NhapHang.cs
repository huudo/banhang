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
using System.Globalization;

namespace camlon
{       
   
    public partial class NhapHang : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=TUAN-PC\SQLEXPRESS;Initial Catalog=banhang;Integrated Security=True");
        Boolean check = false;
        public NhapHang()
        {
            InitializeComponent();
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {
           ClearTextBox();
           
        }

        private void NhapHang_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT mahang FROM sanpham WHERE mahang like '%" + txtMa.Text + "%' ", con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtMa.AutoCompleteCustomSource.Add(dr["mahang"].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {

            }
        }
        void ClearTextBox()
        {
            txtCK1.Clear();
            txtCK2.Clear();
            txtCK3.Clear();
            txtCount.Clear();
            txtGiaBao.Clear();
            txtGiaKg.Clear();
            txtGiaNetBao.Clear();
            txtGiaNetKg.Clear();
            txtName.Clear();
            txtTotal.Clear();
            check = false;
        }

        private void txtMa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {                
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM sanpham WHERE mahang = '" + txtMa.Text + "' ", con);
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txtName.Text = dr["name"].ToString();
                        txtCK1.Text = dr["ck1"].ToString();
                        txtCK2.Text = dr["ck2"].ToString();
                        txtCK3.Text = dr["ck3"].ToString();
                        txtKhoiLuong.Text = dr["khoiluong"].ToString();
                        txtGiaKg.Text = string.Format("{0:n0}",dr["giadokg"]);
                        txtGiaBao.Text =  string.Format("{0:n0}",dr["giadobao"]);
                        txtGiaNetKg.Text =  string.Format("{0:n0}",dr["gianetkg"]);
                        txtGiaNetBao.Text =  string.Format("{0:n0}",dr["gianetbao"]);                        
                    }
                    check = true;
                    dr.Close();
                    con.Close();
               
            }
        }

        private void txtCount_TextChanged(object sender, EventArgs e)
        {
            calculatePrice();
        }
        void calculatePrice()
        {
            int ck1 = 0;
            int ck2 = 0;
            int ck3 = 0;
            int soLuong = 0;
            if (!string.IsNullOrEmpty(txtCK1.Text))
            {
                ck1 = Int32.Parse(txtCK1.Text);
            }
            if (!string.IsNullOrEmpty(txtCK2.Text))
            {
                ck2 = Int32.Parse(txtCK2.Text);
            }
            if (!string.IsNullOrEmpty(txtCK3.Text))
            {
                ck3 = Int32.Parse(txtCK3.Text);
            }
            if (!string.IsNullOrEmpty(txtCount.Text))
            {
                soLuong = Int32.Parse(txtCount.Text);
            }
            int weight = Int32.Parse(txtKhoiLuong.Text);
            double giaNetKg = 0;
            double giaNetBao = 0;
            double giaKg = double.Parse(decimal.Parse(txtGiaKg.Text, NumberStyles.Currency).ToString());
            double giaBao = double.Parse(decimal.Parse(txtGiaBao.Text, NumberStyles.Currency).ToString()); 

            giaNetKg = giaKg * (100 - ck1) / 100 - ck2 - ck3;
            giaNetBao = giaNetKg * weight;       
            txtGiaNetKg.Text = string.Format("{0:n0}", giaNetKg);
            txtGiaNetBao.Text = string.Format("{0:n0}", giaNetBao);
            double price = double.Parse(decimal.Parse(txtGiaNetBao.Text, NumberStyles.Currency).ToString());
            txtTotal.Text = string.Format("{0:n0}", price * soLuong);
        }

        private void txtCK1_TextChanged(object sender, EventArgs e)
        {
            if (check)
            {
                calculatePrice();
            }
          
            
        }

        private void txtCK2_TextChanged(object sender, EventArgs e)
        {
            if (check)
            {
                calculatePrice();
            }
        }

        private void txtCK3_TextChanged(object sender, EventArgs e)
        {
            if (check)
            {
                calculatePrice();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int ck1 = 0;
                int ck2 = 0;
                int ck3 = 0;
                int soLuong = 0;
                if (!string.IsNullOrEmpty(txtCK1.Text))
                {
                    ck1 = Int32.Parse(txtCK1.Text);
                }
                if (!string.IsNullOrEmpty(txtCK2.Text))
                {
                    ck2 = Int32.Parse(txtCK2.Text);
                }
                if (!string.IsNullOrEmpty(txtCK3.Text))
                {
                    ck3 = Int32.Parse(txtCK3.Text);
                }
                if (!string.IsNullOrEmpty(txtCount.Text))
                {
                    soLuong = Int32.Parse(txtCount.Text);
                }
                int weight = Int32.Parse(txtKhoiLuong.Text);
                double total = double.Parse(decimal.Parse(txtTotal.Text, NumberStyles.Currency).ToString());
                double price = double.Parse(decimal.Parse(txtGiaBao.Text, NumberStyles.Currency).ToString());
                double khuyenmai = price*soLuong - total;
                string firstColum = txtMa.Text;
                string secondColum = txtName.Text;
                string threeColum = txtCount.Text;
                string fourColum = txtGiaBao.Text;
                string fiveColum = khuyenmai.ToString();
                string sixColum = txtGiaNetBao.Text;
                string sevenColum = txtTotal.Text;
                string[] row = { firstColum, secondColum, threeColum, fourColum, fiveColum, sixColum, sevenColum };
                dataGridView1.Rows.Add(row);
                int tangbao = (soLuong / 10);
                if (tangbao >= 1)
                {
                     firstColum = txtMa.Text;
                     secondColum = txtName.Text;
                     threeColum = tangbao.ToString();
                     fourColum = txtGiaBao.Text;
                     fiveColum = "Tặng Bao";
                     sixColum = txtGiaNetBao.Text;
                     sevenColum = "0";
                    string[] rowAdd = { firstColum, secondColum, threeColum, fourColum, fiveColum, sixColum, sevenColum };
                    dataGridView1.Rows.Add(rowAdd);
                }

            }
            catch
            {

            } 
        }

        
    }
}
