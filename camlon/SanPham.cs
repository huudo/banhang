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

namespace camlon
{
    public partial class SanPham : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=TUAN-PC\SQLEXPRESS;Initial Catalog=banhang;Integrated Security=True");

        public SanPham()
        {
            InitializeComponent();
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO sanpham (id,mahang,name,khoiluong,giado,chietkhau,gianhap,giaban) VALUES (2,'" + txtMa.Text + "','" + txtName.Text + "','" + txtKg.Text + "','" + txtGiado.Text + "','" + txtChietkhau.Text + "','" + txtGianhap.Text + "','" + txtGiaban.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            DisplayData();
        }
        void DisplayData() {

            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM sanpham", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows) {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["id"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["mahang"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["name"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["khoiluong"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["giado"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item["chietkhau"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item["gianhap"].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item["giaban"].ToString();


            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtMa.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtKg.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtGiado.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtChietkhau.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtGianhap.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txtGiaban.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();


        }

        private void txtGiaban_TextChanged(object sender, EventArgs e)
        {
            int tong = Int32.Parse(txtGiado.Text) + Int32.Parse(txtGianhap.Text);
            textTet.Text = tong.ToString()
        }
    }
}
