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
        //SqlConnection con = new SqlConnection(@"Data Source=TUAN-PC;Initial Catalog=quanly;Integrated Security=True;");
        SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");
        
        public KhachHang()
        {
            InitializeComponent();
        }
        private int customerId = 0;
        void DisplayData()
        {
            dataList.Rows.Clear();
            dataList.AllowUserToAddRows = false;
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM customer", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataList.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataList.Rows.Add();
                dataList.Rows[n].Cells[0].Value = item["id"].ToString();
                dataList.Rows[n].Cells[1].Value = item["name"].ToString();
                dataList.Rows[n].Cells[2].Value = item["address"].ToString();
                dataList.Rows[n].Cells[3].Value = item["phone"].ToString();
            }
        }
        private void KhachHang_Load(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            btnDel.Visible = false;
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
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                
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
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                DisplayData();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmdQr = new SqlCommand("SELECT SUM(tongno) as tongNo FROM  quanlyno WHERE customerId = '"+ customerId +"' ", con);
            SqlDataReader dr;
            dr = cmdQr.ExecuteReader();
            var checkNo = false;
            while (dr.Read())
            {
                if (dr["tongNo"].ToString() == "" || dr["tongNo"].ToString() == "0")
                {

                    checkNo = false;
                    
                }
                else
                {
                    checkNo = true;
                }
               
            }
            dr.Close();
            if (!checkNo)
            {
                var query = "DELETE FROM customer WHERE id = '" + customerId + "' ";
                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã xóa! ");
                DisplayData();
            }
            else
            {
                MessageBox.Show("Khách chưa thanh toán hết nợ!");
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            btnDel.Visible = false;
            btnUpdate.Visible = false;
        }

        private void dataList_MouseClick(object sender, MouseEventArgs e)
        {
            btnUpdate.Visible = true;
            btnDel.Visible = true;
            try
            {
                string id = dataList.SelectedRows[0].Cells[0].Value.ToString();
                customerId = Int32.Parse(id);
                txtName.Text = dataList.SelectedRows[0].Cells[1].Value.ToString();
                txtAddress.Text = dataList.SelectedRows[0].Cells[2].Value.ToString();
                txtPhone.Text = dataList.SelectedRows[0].Cells[3].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Thiếu Dữ Liệu!");
            }
            else
            {
                string name = txtName.Text.ToString();
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                SqlDataAdapter check = new SqlDataAdapter("Select name from customer where name = N'" + name + "'  ", con);
                DataTable dt = new DataTable();
                check.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Khách hàng đã tồn tại! Vui lòng cập nhật!");
                }
                else
                {
                    var query = "UPDATE  customer SET name = @name, address= @address,phone = @phone WHERE id = '" + customerId + "' ";
                    var cmd = new SqlCommand(query, con);
                    //cmd.Parameters.AddWithValue("@ma", 5);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công! ");
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                btnUpdate.Visible = false;
                btnDel.Visible = false;
                DisplayData();
            }

        }
    }
}
