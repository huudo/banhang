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
    public partial class KhachHang : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=TUAN-PC;Initial Catalog=quanly;Integrated Security=True;");
        public KhachHang()
        {
            InitializeComponent();
        }
        void DisplayData()
        {
            dataList.AllowUserToAddRows = false;
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM customer", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataList.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataList.Rows.Add();
                dataList.Rows[n].Cells[0].Value = item["name"].ToString();
                dataList.Rows[n].Cells[1].Value = item["address"].ToString();
                dataList.Rows[n].Cells[2].Value = item["phone"].ToString();
                
            }
        }
        private void KhachHang_Load(object sender, EventArgs e)
        {
            DisplayData();
        }
        // ACTION ADD CUSTOMER
        private void button1_Click(object sender, EventArgs e)
        {
           if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrEmpty(txtPhone.Text))
           {
               MessageBox.Show("Thiếu Dữ Liệu!");
           }
           else 
           {
                string name = txtName.Text.ToString();
                con.Open();
                SqlDataAdapter check = new SqlDataAdapter("Select name from customer where name = N'" + name + "'  ", con);
                DataTable dt = new DataTable();
                check.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Khách hàng đã tồn tại! Vui lòng cập nhật!");
                   
                }
                else
                {
                    var query = "INSERT INTO customer (name,address,phone)" +
                    "VALUES(@name,@address,@phone)";
                    var cmd = new SqlCommand(query, con);
                    //cmd.Parameters.AddWithValue("@ma", 5);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công! ");

                }
                con.Close();
           }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
      
        }

        private void dataList_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                con.Open();
                var query = "SELECT * from customer WHERE name = @name";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", dataList.SelectedRows[0].Cells[0].Value);
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    txtName.Text = dr["name"].ToString();
                    txtAddress.Text = dr["address"].ToString();
                    txtPhone.Text = dr["phone"].ToString();

                }
                dr.Close();
                con.Close();

            }
            catch
            {

            }         
        }

      
    }
}
