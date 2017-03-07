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
    public partial class Login : Form
    {
        SqlConnection con = ConnectDatabase.querryConnect();
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static class MyStaticValues
        {
            public static string username { get; set; }
            public static int account_id { get; set; }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Thiếu thông tin tài khoản. Nhập lại!");
            }
            else
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                SqlDataAdapter check = new SqlDataAdapter("Select id,username from users where username= '" + txtUserName.Text + "' and password= '" + txtPass.Text + "' ", con);
                DataTable dt = new DataTable();
                check.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    this.Hide();
                    MyStaticValues.username = txtUserName.Text;
                    foreach (DataRow item in dt.Rows)
                    {
                        MyStaticValues.account_id = Int32.Parse(item["id"].ToString());
                    }
                    frmMain frm = new frmMain();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Thông tin đăng nhập không chính xác!");
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                
            }
        }

    
    }
}
