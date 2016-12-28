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
    public partial class BaoCaoSanLuong : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=TUAN-PC;Initial Catalog=quanly;Integrated Security=True;");
        SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");
        int id_bangGia = 0;
        public BaoCaoSanLuong()
        {
            InitializeComponent();
           
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {
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
            }
            dr4.Close();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            dataGridView1.AllowUserToAddRows = false;
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
            SqlCommand cmd = new SqlCommand("SELECT mahang,name,donvi,khoiluong FROM sanpham WHERE id_banggia = '" + id_bangGia + "' ", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                spList.Add(new sPham
                {
                    maSP = dr["mahang"].ToString(),
                    name = dr["name"].ToString(),
                    type = dr["donvi"].ToString(),
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
            DateTime d1 = DateTime.Parse(dateFrom);
            DateTime d2 = DateTime.Parse(dateTo);
            TimeSpan totalDays = (d2 - d1);
            if (totalDays.TotalDays < 0)
            {
                MessageBox.Show("Thời gian nhập vào không hợp lệ!");
            }
            else
            {
                string firstColumn1 = "";
                string secondColumn1 = "";
                string threeColumn1 = "";
                string fourColumn1 = "";
                string fiveColumn1 = "";
                string sixColumn1 = "0";
                double tongNhap = 0;
                double tongBan = 0;
                double tongTonKho = 0;

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
                    int totalInput = 0;
                    int totalOutput = 0;
                    string maSP = spList[i].maSP;
                    firstColumn = spList[i].maSP;
                    secondColumn = spList[i].name;
                    threeColumn = spList[i].type;

                    double kthuocBao = spList[i].khoiluong;
                    // Tinh so luong nhap den dateTo
                    // MessageBox.Show(dateTo);
                    SqlCommand cmdTo = new SqlCommand("SELECT SUM(soluong) as soluong FROM nhaphang_list WHERE id_mahang= '" + maSP + "' and date <= '" + dateTo + "' ", con);
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
                    SqlCommand cmdFrom = new SqlCommand("SELECT SUM(soluong) as soluong FROM banhang_list WHERE id_mahang= '" + maSP + "' and date <= '" + dateTo + "' ", con);
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

                    SqlCommand cmdQr = new SqlCommand("SELECT SUM(soluong) as soluong FROM nhaphang_list WHERE id_mahang= '" + maSP + "' and date <= '" + dateTo + "' and date >= '" + dateFrom + "' ", con);
                    SqlDataReader read = cmdQr.ExecuteReader();

                    while (read.Read())
                    {
                        if (read["soluong"].ToString() != "")
                        {
                            fourColumn = read["soluong"].ToString();
                            totalInput += Int32.Parse(read["soluong"].ToString());
                        }
                        else
                        {
                            fourColumn = "0";
                            //MessageBox.Show("asd");

                        }

                    }
                    read.Close();
                    SqlCommand cmdQr2 = new SqlCommand("SELECT SUM(soluong) as soluong FROM banhang_list WHERE id_mahang= '" + maSP + "' and date <= '" + dateTo + "' and date >= '" + dateFrom + "' ", con);
                    SqlDataReader read2 = cmdQr2.ExecuteReader();

                    while (read2.Read())
                    {
                        if (read2["soluong"].ToString() != "")
                        {
                            //hangTonKho = sumNhap - Int32.Parse(read2["soluong"].ToString());
                            fiveColumn = read2["soluong"].ToString();
                            totalOutput += Int32.Parse(read2["soluong"].ToString());
                        }
                        else
                        {
                            fiveColumn = "0";
                            //hangTonKho = sumNhap;
                            //MessageBox.Show("asd");
                        }
                    }
                    hangTonKho = sumNhap - sumBan;
                    tongNhap += totalInput;
                    tongBan += totalOutput;
                    tongTonKho += hangTonKho;
                    sixColumn = hangTonKho.ToString();
                    string[] row = { firstColumn, secondColumn, threeColumn, fourColumn, fiveColumn, sixColumn };
                    dataGridView1.Rows.Add(row);
                    read2.Close();

                    // MessageBox.Show(hangTonKho.ToString());                
                }
                firstColumn1 = "Tổng";
                secondColumn1 = "";
                threeColumn1 = "bao";
                fourColumn1 = tongNhap.ToString();
                fiveColumn1 = tongBan.ToString();
                sixColumn1 = tongTonKho.ToString();
                string[] rows = { firstColumn1, secondColumn1, threeColumn1, fourColumn1, fiveColumn1, sixColumn1 };
                dataGridView1.Rows.Add(rows);
                con.Close();
            }
        }



        private void txtMa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                con.Open();
                dataGridView1.Rows.Clear();
                var spList = new List<sPham>();
                SqlCommand cmd = new SqlCommand("SELECT mahang,name,donvi,khoiluong FROM sanpham WHERE id_banggia = '" + id_bangGia + "' AND mahang LIKE '%" + txtMa.Text + "%' ", con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    spList.Add(new sPham
                    {
                        maSP = dr["mahang"].ToString(),
                        name = dr["name"].ToString(),
                        type = dr["donvi"].ToString(),
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
        }
    }
}
