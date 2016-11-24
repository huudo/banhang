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
using System.Globalization;
using System.Net.Mail;
using System.IO;



namespace PhanMem
{
    public partial class BaoCao : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=TUAN-PC;Initial Catalog=quanly;Integrated Security=True;");
        SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");

        public BaoCao()
        {
            InitializeComponent();
           
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {
            cbxDonvi.Items.Add("Bao/Túi");
            cbxDonvi.Items.Add("Kg/Lon");
            cbxDonvi.SelectedIndex = cbxDonvi.FindStringExact("Bao/Túi");            
        }
        public class sPham
        {
            public string maSP { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public double khoiluong { get; set; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var spList = new List<sPham>();
            
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT mahang,name,type,khoiluong FROM sanpham", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                spList.Add(new sPham
                {
                    maSP = dr["mahang"].ToString(),
                    name = dr["name"].ToString(),
                    type = dr["type"].ToString(),
                    khoiluong = double.Parse(dr["khoiluong"].ToString()),                    
                });
            }
            dr.Close();
            searData(spList);
                /*
                 string firstColumn = "";
                    string secondColumn = "";
                    string threeColumn = "";
                    string fourColumn = "";
                    string fiveColumn = "";
                    string sixColumn = "0";
               
                    string maSP = dr["mahang"].ToString();
                    firstColumn = dr["mahang"].ToString();
                    secondColumn = dr["name"].ToString();
                    fourColumn = dr["type"].ToString();

                    int kthuocBao = Int32.Parse(dr["khoiluong"].ToString());
                    SqlCommand cmdQr = new SqlCommand("SELECT SUM(soluong) as soluong FROM nhaphang_list WHERE id_mahang= '" + maSP + "' and  donvi = 'bao' ",con);
               
                
                        SqlDataReader read = cmdQr.ExecuteReader();
                        if (read.HasRows)                     
                        {
                            while (read.Read()) { 
                                fiveColumn = read["soluong"].ToString();
                            }
                        }
                        else
                        {
                            fiveColumn = "0";
                        }
                    string[] row = { firstColumn, secondColumn, threeColumn, fourColumn, fiveColumn, sixColumn };
                    dataGridView1.Rows.Add(row);
                 */
                
            con.Close();

        }
        public void searData(List<sPham> spList)
        {
            
            string dateFrom = timeFrom.Value.ToString("yyy/MM/dd");
            string dateTo = timeTo.Value.ToString("yyy/MM/dd");
            for (int i = 0; i < spList.Count; i++)
            {
                string firstColumn = "";
                string secondColumn = "";
                string threeColumn = "";
                string fourColumn = "";
                string fiveColumn = "";
                string sixColumn = "0";
                int sumNhap = 0;
                int sumBan = 0;
                int hangTonKho = 0;
                string maSP = spList[i].maSP;
                firstColumn = spList[i].maSP;
                secondColumn = spList[i].name;
                threeColumn = spList[i].type;

                double kthuocBao = spList[i].khoiluong;
                // Tinh so luong nhap den dateTo
               // MessageBox.Show(dateTo);
                SqlCommand cmdTo = new SqlCommand("SELECT SUM(soluong) as soluong FROM nhaphang_list WHERE id_mahang= '" + maSP + "' and date <= '" + dateTo + "'  and donvi = 'bao' ", con);
                SqlDataReader readTo = cmdTo.ExecuteReader();

                while (readTo.Read())
                {
                    if (readTo["soluong"].ToString() != "")
                    {
                        sumNhap += Int32.Parse(readTo["soluong"].ToString());
                    }
                    else
                    {
                        sumNhap += 0;
                        //MessageBox.Show("asd");

                    }

                }
                readTo.Close();
                // Tinh so luong ban den dateTo
                SqlCommand cmdFrom = new SqlCommand("SELECT SUM(soluong) as soluong FROM banhang_list WHERE id_mahang= '" + maSP + "' and date <= '" + dateTo + "'  and donvi = 'bao' ", con);
                SqlDataReader readFrom = cmdFrom.ExecuteReader();

                while (readFrom.Read())
                {
                    if (readFrom["soluong"].ToString() != "")
                    {
                        sumBan += Int32.Parse(readFrom["soluong"].ToString());
                    }
                    else
                    {
                        sumBan += 0;
                        //MessageBox.Show("asd");

                    }

                }
                readFrom.Close();

                SqlCommand cmdQr = new SqlCommand("SELECT SUM(soluong) as soluong FROM nhaphang_list WHERE id_mahang= '" + maSP + "' and date <= '"+ dateTo +"' and date >= '"+ dateFrom +"' and donvi = 'bao' ", con);
                SqlDataReader read = cmdQr.ExecuteReader();

                while (read.Read())
                {
                    if (read["soluong"].ToString() != "")
                    {
                        fourColumn = read["soluong"].ToString();
                        
                    }
                    else
                    {
                        fourColumn = "0";
                        //MessageBox.Show("asd");

                    }

                }
                read.Close();
                SqlCommand cmdQr2 = new SqlCommand("SELECT SUM(soluong) as soluong FROM banhang_list WHERE id_mahang= '" + maSP + "' and date <= '" + dateTo + "' and date >= '" + dateFrom + "' and  donvi = 'bao' ", con);
                SqlDataReader read2 = cmdQr2.ExecuteReader();

                while (read2.Read())
                {
                    if (read2["soluong"].ToString() != "")
                    {
                        //hangTonKho = sumNhap - Int32.Parse(read2["soluong"].ToString());
                        fiveColumn = read2["soluong"].ToString();                                   
                    }
                    else
                    {
                        fiveColumn = "0";
                        //hangTonKho = sumNhap;
                        //MessageBox.Show("asd");
                    }
                }
                hangTonKho = sumNhap - sumBan;
                sixColumn = hangTonKho.ToString();
                string[] row = { firstColumn, secondColumn, threeColumn, fourColumn, fiveColumn, sixColumn };
                dataGridView1.Rows.Add(row);
                read2.Close();
               // MessageBox.Show(hangTonKho.ToString());                
            }
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            dataGridView1.Rows.Clear();
            var spList = new List<sPham>();
            SqlCommand cmd = new SqlCommand("SELECT mahang,name,type,khoiluong FROM sanpham WHERE mahang LIKE '%" + txtMa.Text + "%' ", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                spList.Add(new sPham
                {
                    maSP = dr["mahang"].ToString(),
                    name = dr["name"].ToString(),
                    type = dr["type"].ToString(),
                    khoiluong = double.Parse(dr["khoiluong"].ToString()),
                });
            }
            dr.Close();
           
            searData(spList);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        private void timeFrom_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
