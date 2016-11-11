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

namespace PhanMem
{
    public partial class BanHang : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=TUAN-PC\SQLEXPRESS;Initial Catalog=banhang;Integrated Security=True");
        public BanHang()
        {
            InitializeComponent();
        }
        void ClearTextBox()
        {
            txtCK1.Clear();
            txtCK2.Clear();
            txtCK3.Clear();
            txtSoLuongKg.Clear();
            txtGiaBao.Clear();
            txtGiaKg.Clear();
            txtGiaBanBao.Clear();
            txtGiaBanKg.Clear();
            txtSoLuongBao.Clear();
            txtName.Clear();
            txtTotal.Clear();
           
        }
        private void txtMa_TextChanged(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        private void BanHang_Load(object sender, EventArgs e)
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
                    txtGiaKg.Text = string.Format("{0:n0}", dr["giadokg"]);
                    txtGiaBao.Text = string.Format("{0:n0}", dr["giadobao"]);
                   
                }
               
                dr.Close();
                con.Close();

            }
        }

    }
}
