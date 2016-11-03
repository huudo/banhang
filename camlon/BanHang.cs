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
    public partial class BanHang : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=TUAN-PC\SQLEXPRESS;Initial Catalog=banhang;Integrated Security=True");
        public BanHang()
        {
            InitializeComponent();
            
        }

        private void BanHang_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT mahang FROM sanpham WHERE mahang like '%" + textBox1.Text + "%' ", con);
                SqlDataReader dr ;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox1.AutoCompleteCustomSource.Add(dr["mahang"].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex) {

            }
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
            try
            {
                int n = Int32.Parse(textBox2.Text);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT giaban FROM sanpham WHERE mahang = '" + textBox1.Text + "' ", con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int gia = Int32.Parse(dr["giaban"].ToString());
                    textBox3.Text = (n*gia).ToString();
                }
                dr.Close();
                con.Close();
                
            }
            catch
            {

            }
        }

        private void addCart_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                int n = Int32.Parse(textBox2.Text);
                string name ="";
                string gia ="";
                SqlCommand cmd = new SqlCommand("SELECT * FROM sanpham WHERE mahang = '" + textBox1.Text + "' ", con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    gia = dr["giaban"].ToString();
                    name = dr["name"].ToString();
                }
                dr.Close();
                con.Close();
                string firstColum = textBox1.Text;
                string secondColum = name;
                string threeColum = gia;
                string fourColum = textBox2.Text;
                string fiveColum = textBox3.Text;
                string[] row = { firstColum, secondColum, threeColum, fourColum,fiveColum };
                dataGridView1.Rows.Add(row);

            }catch { 
            
            }
            
            
        }

    }
}
