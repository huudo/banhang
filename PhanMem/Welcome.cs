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
    public partial class Welcome : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");
        public Welcome()
        {
            
            InitializeComponent(); 
            //label1.BackColor = System.Drawing.Color.Transparent;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPass.Text) || string.IsNullOrEmpty(txtRePass.Text) || string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtNameStore.Text))
            {
                MessageBox.Show("Thiếu thông tin tài khoản. Nhập lại!");
            }
            else
            {
                if (txtPass.Text != txtRePass.Text)
                {
                    MessageBox.Show("Mật khẩu xác nhận không chính xác!");
                }
                else
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }                    
                    var query = "INSERT INTO account (email,username,password,name)" +
                    "VALUES(@email,@username,@password,@name)";
                    var cmd = new SqlCommand(query, con);
                    //cmd.Parameters.AddWithValue("@ma", 5);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@password", txtPass.Text);
                    cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@name", txtNameStore.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công! ");
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            this.Hide();
            Login form = new Login();
            form.Show();
        }


        
    }
}
