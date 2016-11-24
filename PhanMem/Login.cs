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
        SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Thiếu thông tin tài khoản. Nhập lại!");
            }
            else
            {
                
                con.Open();
                SqlDataAdapter check = new SqlDataAdapter("Select email from account where email= '"+ txtEmail.Text +"' and password= '"+ txtPass.Text +"' ", con);
                DataTable dt = new DataTable();
                check.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    this.Hide();
                    Default df = new Default();
                    df.Show();
                }
                else
                {
                    MessageBox.Show("Thông tin đăng nhập không chính xác!");
                }
                
            }
        }

    
    }
}
