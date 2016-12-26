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
    public partial class SanPham : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");
        public SanPham()
        {
            InitializeComponent();
        }
        int id_bangGia = 0;
        float giaDo = 0;
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
        private void SanPham_Load(object sender, EventArgs e)
        {
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
                firstColumn = (i+1).ToString();
                secondColumn = spList[i].maSP;
                threeColumn = spList[i].name;
                fourColumn = (spList[i].khoiluong).ToString();
                fiveColumn = string.Format("{0:n0}", spList[i].giaDoHang);
                sixColumn = string.Format("{0:n0}", spList[i].giaNetNhap);
                string[] row = { firstColumn, secondColumn, threeColumn, fourColumn, fiveColumn,sixColumn};
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

            float ck1 = 0;
            float ck2 = 0;
            float ck3 = 0;

            int khoiLuong = 0;
            float giaNet = 0;
            float giaban1 = 0;
            float giaban2 = 0;
            float gianban3 = 0;
            float giaban4 = 0;

            if (!string.IsNullOrEmpty(txtCK1.Text))
            {
                ck1 = float.Parse(txtCK1.Text);
            }
            if (!string.IsNullOrEmpty(txtCK2.Text))
            {
                ck2 = float.Parse(txtCK2.Text);
            }
            if (!string.IsNullOrEmpty(txtCK3.Text))
            {
                ck3 = float.Parse(txtCK3.Text);
            }
            if (!string.IsNullOrEmpty(txtKhoiLuong.Text))
            {
                khoiLuong = Int32.Parse(txtKhoiLuong.Text);
            }
            
            giaNet = giaDo * (100 - ck1) / 100 - (ck2 + ck3) * khoiLuong;
            giaban1 = giaNet + 5000;
            giaban2 = giaNet + 10000;
            gianban3 = giaNet + 15000;
            giaban4 = giaNet + 20000;

            txtGiaNet.Text = string.Format("{0:n0}", giaNet);
            txtGiaban1.Text = string.Format("{0:n0}", giaban1);
            txtGiaban2.Text = string.Format("{0:n0}", giaban2);
            txtGiaban3.Text = string.Format("{0:n0}", gianban3);
            txtGiaban4.Text = string.Format("{0:n0}", giaban4);
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

     
    }
}
