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
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=TUAN-PC\SQLEXPRESS;Initial Catalog=banhang;Integrated Security=True");
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlDataAdapter cmd = new SqlDataAdapter("Select type from users where username= '" + username.Text + "' and password='" + password.Text + "' ", con);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            if (dt.Rows.Count == 1) {
                this.Hide();
                SanPham a = new SanPham();
                a.Show();
            }else{
                lblInfo.Visible = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
