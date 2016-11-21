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
    public partial class SanPham : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=TUAN-PC\SQLEXPRESS;Initial Catalog=banhang;Integrated Security=True;");
        public SanPham()
        {
            InitializeComponent();
        }
        void DisplayData()
        {

            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM sanpham", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["mahang"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["name"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["khoiluong"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["giadokg"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["ck1"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item["gianetbao"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item["giabanbao1"].ToString();
            }
        }
        void CalculatePrice()
        {

            int ck1 = 0;
            int ck2 = 0;
            int ck3 = 0;
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


            int weight = Int32.Parse(txtKg.Text);
            double giaKg = float.Parse(txtGiaKg.Text);
            double giaBao = 0;
            double giaNetKg = 0;
            double giaNetBao = 0;
            double banKg1 = 0;
            double banKg2 = 0;
            double banKg3 = 0;
            double banKg4 = 0;
            double banBao1 = 0;
            double banBao2 = 0;
            double banBao3 = 0;
            double banBao4 = 0;

            giaBao = giaKg * weight;
            giaNetKg = (giaKg * (100 - ck1) / 100 - ck2 - ck3);
            giaNetBao = giaNetKg * weight;
            banBao1 = giaNetBao + 5000;
            banBao2 = giaNetBao + 10000;
            banBao3 = giaNetBao + 15000;
            banBao4 = giaNetBao + 20000;
            banKg1 = banBao1 / weight;
            banKg2 = banBao2 / weight;
            banKg3 = banBao3 / weight;
            banKg4 = banBao4 / weight;

            txtGiaBao.Text = string.Format("{0:n0}", giaBao);
            txtGiaNetKg.Text = string.Format("{0:n0}", giaNetKg);
            txtGiaNetBao.Text = string.Format("{0:n0}", giaNetBao);
            txtBanKg1.Text = string.Format("{0:n0}", banKg1);
            txtBanKg2.Text = string.Format("{0:n0}", banKg2);
            txtBanKg3.Text = string.Format("{0:n0}", banKg3);
            txtBanKg4.Text = string.Format("{0:n0}", banKg4);

            txtBanBao1.Text = string.Format("{0:n0}", banBao1);
            txtBanBao2.Text = string.Format("{0:n0}", banBao2);
            txtBanBao3.Text = string.Format("{0:n0}", banBao3);
            txtBanBao4.Text = string.Format("{0:n0}", banBao4);

            /*txtGiaBao.Text = Math.Round(giaBao, 0).ToString();
            txtGiaNetKg.Text = Math.Round(giaNetKg, 0).ToString();
            txtGiaNetBao.Text =  Math.Round(giaNetBao, 0).ToString();
            txtBanKg1.Text = banKg1.ToString();
            txtBanKg2.Text = banKg2.ToString();
            txtBanKg3.Text = banKg3.ToString();
            txtBanKg4.Text = banKg4.ToString();

            txtBanBao1.Text = banBao1.ToString();
            txtBanBao2.Text = banBao2.ToString();
            txtBanBao3.Text = banBao3.ToString();
            txtBanBao4.Text = banBao4.ToString();*/




        }
        void checkNumber(KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            DisplayData();
        }
        private void txtMa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKg_TextChanged(object sender, EventArgs e)
        {
           // CalculatePrice();
        }

        private void txtGiaKg_TextChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

        private void txtCK1_TextChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

        private void txtCK2_TextChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

        private void txtCK3_TextChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter check = new SqlDataAdapter("Select mahang from sanpham where mahang= '" + txtMa.Text + "'  ", con);
            DataTable dt = new DataTable();
            check.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Mã hàng đã tồn tại! Vui lòng cập nhật!");
                con.Close();
            }
            else
            {
                var query = "INSERT INTO sanpham (mahang,name,khoiluong,giadokg,giadobao,ck1,ck2,ck3,gianetkg,gianetbao,giabankg1,giabankg2,giabankg3,giabankg4,giabanbao1,giabanbao2,giabanbao3,giabanbao4)" +
                "VALUES(@mahang,@name,@khoiluong,@giadokg,@giadobao,@ck1,@ck2,@ck3,@gianetkg,@gianetbao,@giabankg1,@giabankg2,@giabankg3,@giabankg4,@giabanbao1,@giabanbao2,@giabanbao3,@giabanbao4)";

                var cmd = new SqlCommand(query, con);
               

                cmd.Parameters.AddWithValue("@mahang", txtMa.Text);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@khoiluong", float.Parse(txtKg.Text));
                cmd.Parameters.AddWithValue("@giadokg", float.Parse(txtGiaKg.Text));
                cmd.Parameters.AddWithValue("@giadobao", decimal.Parse(txtGiaBao.Text, NumberStyles.Currency));
                cmd.Parameters.AddWithValue("@ck1", int.Parse(txtCK1.Text));
                cmd.Parameters.AddWithValue("@ck2", int.Parse(txtCK2.Text));
                cmd.Parameters.AddWithValue("@ck3", float.Parse(txtCK3.Text));
                cmd.Parameters.AddWithValue("@gianetkg", decimal.Parse(txtGiaNetKg.Text, NumberStyles.Currency));
                cmd.Parameters.AddWithValue("@gianetbao", decimal.Parse(txtGiaNetBao.Text, NumberStyles.Currency));
                cmd.Parameters.AddWithValue("@giabankg1", decimal.Parse(txtBanKg1.Text, NumberStyles.Currency));
                cmd.Parameters.AddWithValue("@giabankg2", decimal.Parse(txtBanKg2.Text, NumberStyles.Currency));
                cmd.Parameters.AddWithValue("@giabankg3", decimal.Parse(txtBanKg3.Text, NumberStyles.Currency));
                cmd.Parameters.AddWithValue("@giabankg4", decimal.Parse(txtBanKg4.Text, NumberStyles.Currency));
                cmd.Parameters.AddWithValue("@giabanbao1", decimal.Parse(txtBanBao1.Text, NumberStyles.Currency));
                cmd.Parameters.AddWithValue("@giabanbao2", decimal.Parse(txtBanBao2.Text, NumberStyles.Currency));
                cmd.Parameters.AddWithValue("@giabanbao3", decimal.Parse(txtBanBao3.Text, NumberStyles.Currency));
                cmd.Parameters.AddWithValue("@giabanbao4", decimal.Parse(txtBanBao4.Text, NumberStyles.Currency));
                cmd.ExecuteNonQuery();
              
                con.Close();
                DisplayData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM sanpham WHERE(mahang ='" + txtMa.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Xóa thành công!");
                DisplayData();
            }
            catch
            {
                MessageBox.Show("Mã hàng không tồn tại!");
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                con.Open();
                var query = "SELECT * from sanpham WHERE mahang = @mahang";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@mahang", dataGridView1.SelectedRows[0].Cells[0].Value);
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtMa.Text = dr["mahang"].ToString();
                    txtName.Text = dr["name"].ToString();
                    txtKg.Text = dr["khoiluong"].ToString();
                    txtGiaKg.Text = dr["giadokg"].ToString();
                    txtGiaBao.Text = string.Format("{0:n0}", dr["giadobao"]);
                    txtCK1.Text = string.Format("{0:n0}", dr["ck1"]);
                    txtCK2.Text = string.Format("{0:n0}", dr["ck2"].ToString());
                    txtCK3.Text = string.Format("{0:n0}", dr["ck3"].ToString());
                    txtGiaNetKg.Text = string.Format("{0:n0}", dr["gianetkg"]);
                    txtGiaNetBao.Text = string.Format("{0:n0}", dr["gianetbao"]);
                    txtBanKg1.Text = string.Format("{0:n0}", dr["giabankg1"]);
                    txtBanKg2.Text = string.Format("{0:n0}", dr["giabankg2"]);
                    txtBanKg3.Text = string.Format("{0:n0}", dr["giabankg3"]);
                    txtBanKg4.Text = string.Format("{0:n0}", dr["giabankg4"]);
                    txtBanBao1.Text = string.Format("{0:n0}", dr["giabanbao1"]);
                    txtBanBao2.Text = string.Format("{0:n0}", dr["giabanbao2"]);
                    txtBanBao3.Text = string.Format("{0:n0}", dr["giabanbao3"]);
                    txtBanBao4.Text = string.Format("{0:n0}", dr["giabanbao4"]);

                }
                dr.Close();
                con.Close();

            }
            catch
            {

            }         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
