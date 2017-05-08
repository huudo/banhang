using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
namespace PhanMem
{
    public partial class ucSanPham : UserControl
    {
        SqlConnection con = ConnectDatabase.querryConnect();
        private int id_bangGia = 0;
        private float giaDo = 0;
        public ucSanPham()
        {
            InitializeComponent();
        }
        public class sPham
        {
            public string maSP { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public double khoiluong { get; set; }
            public float giaDoHang { get; set; }
            public float ck1 { get; set; }
            public float ck2 { get; set; }
            public float ck3 { get; set; }
            public float giaNetNhap { get; set; }
            public float giaBanRa1 { get; set; }
            public float giaBanRa2 { get; set; }
            public float giaBanRa3 { get; set; }
            public float giaBanRa4 { get; set; }

        }
        List<sPham> spList = new List<sPham>();

        private void ucSanPham_Load(object sender, EventArgs e)
        {
            spList.Clear();
            dataGridView1.AllowUserToAddRows = false;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            SqlCommand cmd4 = new SqlCommand("SELECT id FROM banggia WHERE status = 1", con);
            SqlDataReader dr4;
            dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                id_bangGia = Int32.Parse(dr4["id"].ToString());
                //passEmail = dr2["password"].ToString();
            }
            dr4.Close();

            SqlCommand cmd = new SqlCommand("SELECT * FROM sanpham WHERE id_banggia = '" + id_bangGia + "' ", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                spList.Add(new sPham
                {
                    maSP = dr["mahang"].ToString(),
                    name = dr["name"].ToString(),
                    type = dr["donvi"].ToString(),
                    khoiluong = Int32.Parse(dr["khoiluong"].ToString()),
                    giaDoHang = float.Parse(dr["giado"].ToString()),
                    ck1 = float.Parse(dr["ck1"].ToString()),
                    ck2 = float.Parse(dr["ck2"].ToString()),
                    ck3 = float.Parse(dr["ck3"].ToString()),
                    giaNetNhap = float.Parse(dr["gianet"].ToString()),
                    giaBanRa1 = float.Parse(dr["giaban1"].ToString()),
                    giaBanRa2 = float.Parse(dr["giaban2"].ToString()),
                    giaBanRa3 = float.Parse(dr["giaban3"].ToString()),
                    giaBanRa4 = float.Parse(dr["giaban4"].ToString()),
                });
            }
            dr.Close();

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            loadDataGrid(spList);
        }
        public void loadDataGrid(List<sPham> spList)
        {
            string firstColumn = "";
            string secondColumn = "";
            string threeColumn = "";
            string fourColumn = "";
            string fiveColumn = "";
            string sixColumn = "";
            for (int i = 0; i < spList.Count; i++)
            {
                firstColumn = (i + 1).ToString();
                secondColumn = spList[i].maSP;
                threeColumn = spList[i].name;
                fourColumn = (spList[i].khoiluong).ToString();
                fiveColumn = string.Format("{0:n0}", spList[i].giaDoHang);
                sixColumn = string.Format("{0:n0}", spList[i].giaNetNhap);
                string[] row = { firstColumn, secondColumn, threeColumn, fourColumn, fiveColumn, sixColumn };
                dataGridView1.Rows.Add(row);
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

            int i = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()) - 1;
            txtMa.Text = (spList[i].maSP).ToString();
            txtName.Text = spList[i].name;
            txtDonVi.Text = spList[i].type;
            txtKhoiLuong.Text = (spList[i].khoiluong).ToString();
            txtCK1.Text = (spList[i].ck1).ToString();
            txtCK2.Text = (spList[i].ck2).ToString();
            txtCK3.Text = (spList[i].ck3).ToString();
            txtGiaDo.Text = string.Format("{0:n0}", spList[i].giaDoHang);
            giaDo = spList[i].giaDoHang;
            txtGiaNet.Text = string.Format("{0:n0}", spList[i].giaNetNhap);
            txtGiaban1.Text = string.Format("{0:n0}", spList[i].giaBanRa1);
            txtGiaban2.Text = string.Format("{0:n0}", spList[i].giaBanRa2);
            txtGiaban3.Text = string.Format("{0:n0}", spList[i].giaBanRa3);
            txtGiaban4.Text = string.Format("{0:n0}", spList[i].giaBanRa4);
        }

        private void CalculatePrice()
        {
            float ck1static = 0;
            float ck2static = 0;
            float ck3static = 0;

            int khoiLuongstatic = 0;
            float giaNetstatic = 0;
            float giaban1static = 0;
            float giaban2static = 0;
            float giaban3static = 0;
            float giaban4static = 0;

            if (!string.IsNullOrEmpty(txtCK1.Text))
            {
                ck1static = float.Parse(txtCK1.Text);
            }
            if (!string.IsNullOrEmpty(txtCK2.Text))
            {
                ck2static = float.Parse(txtCK2.Text);
            }
            if (!string.IsNullOrEmpty(txtCK3.Text))
            {
                ck3static = float.Parse(txtCK3.Text);
            }
            if (!string.IsNullOrEmpty(txtKhoiLuong.Text))
            {
                khoiLuongstatic = Int32.Parse(txtKhoiLuong.Text);
            }

            giaNetstatic = giaDo * (100 - ck1static) / 100 - (ck2static + ck3static) * khoiLuongstatic;
            giaban1static = giaNetstatic + 5000;
            giaban2static = giaNetstatic + 10000;
            giaban3static = giaNetstatic + 15000;
            giaban4static = giaNetstatic + 20000;

            txtGiaNet.Text = string.Format("{0:n0}", giaNetstatic);
            txtGiaban1.Text = string.Format("{0:n0}", giaban1static);
            txtGiaban2.Text = string.Format("{0:n0}", giaban2static);
            txtGiaban3.Text = string.Format("{0:n0}", giaban3static);
            txtGiaban4.Text = string.Format("{0:n0}", giaban4static);
            btnUpdate.Visible = true;
        }

        private void txtKhoiLuong_TextChanged(object sender, EventArgs e)
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            float ck1static = float.Parse(txtCK1.Text);
            float ck2static = float.Parse(txtCK2.Text);
            float ck3static = float.Parse(txtCK3.Text);

            int khoiLuongstatic = Int32.Parse(txtKhoiLuong.Text);
            float giaNetstatic = float.Parse(decimal.Parse(txtGiaNet.Text, NumberStyles.Currency).ToString());
            float giaban1static = float.Parse(decimal.Parse(txtGiaban1.Text, NumberStyles.Currency).ToString());
            float giaban2static = float.Parse(decimal.Parse(txtGiaban2.Text, NumberStyles.Currency).ToString());
            float giaban3static = float.Parse(decimal.Parse(txtGiaban3.Text, NumberStyles.Currency).ToString());
            float giaban4static = float.Parse(decimal.Parse(txtGiaban4.Text, NumberStyles.Currency).ToString());

            string maHang = txtMa.Text;
            string nameSP = txtName.Text;
            string donVi = txtDonVi.Text;

            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            String querryUpdate = "UPDATE sanpham SET name=@name,khoiluong = @khoiluong ,ck1=@ck1,ck2=@ck2,ck3=@ck3,gianet=@gianet,"
                + "giaban1=@giaban1,giaban2=@giaban2,giaban3=@giaban3,giaban4=@giaban4 WHERE mahang = '" + maHang + "' AND id_banggia = '" + id_bangGia + "' ";
            var cmdUpdate = new SqlCommand(querryUpdate, con);
            cmdUpdate.Parameters.AddWithValue("@name", nameSP);
            cmdUpdate.Parameters.AddWithValue("@khoiluong", khoiLuongstatic);
            cmdUpdate.Parameters.AddWithValue("@ck1", ck1static);
            cmdUpdate.Parameters.AddWithValue("@ck2", ck2static);
            cmdUpdate.Parameters.AddWithValue("@ck3", ck3static);
            cmdUpdate.Parameters.AddWithValue("@gianet", giaNetstatic);
            cmdUpdate.Parameters.AddWithValue("@giaban1", giaban1static);
            cmdUpdate.Parameters.AddWithValue("@giaban2", giaban2static);
            cmdUpdate.Parameters.AddWithValue("@giaban3", giaban3static);
            cmdUpdate.Parameters.AddWithValue("@giaban4", giaban4static);

            cmdUpdate.ExecuteNonQuery();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            loadAgain();
            MessageBox.Show("Cập nhật thành công!");
        }
        private void loadAgain()
        {
            spList.Clear();
            dataGridView1.Rows.Clear();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM sanpham WHERE id_banggia = '" + id_bangGia + "' ", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                spList.Add(new sPham
                {
                    maSP = dr["mahang"].ToString(),
                    name = dr["name"].ToString(),
                    type = dr["donvi"].ToString(),
                    khoiluong = Int32.Parse(dr["khoiluong"].ToString()),
                    giaDoHang = float.Parse(dr["giado"].ToString()),
                    ck1 = float.Parse(dr["ck1"].ToString()),
                    ck2 = float.Parse(dr["ck2"].ToString()),
                    ck3 = float.Parse(dr["ck3"].ToString()),
                    giaNetNhap = float.Parse(dr["gianet"].ToString()),
                    giaBanRa1 = float.Parse(dr["giaban1"].ToString()),
                    giaBanRa2 = float.Parse(dr["giaban2"].ToString()),
                    giaBanRa3 = float.Parse(dr["giaban3"].ToString()),
                    giaBanRa4 = float.Parse(dr["giaban4"].ToString()),
                });
            }
            dr.Close();

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            loadDataGrid(spList);
        }
        void checkNumber(KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
        }

        private void txtKhoiLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumber(e);
        }

    }
}
