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
    public partial class BCLoiNhuan : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");
        public BCLoiNhuan()
        {
            InitializeComponent();
        }
        public class sPham
        {
            public string maSP { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public double khoiluong { get; set; }
        }
        public void searData(List<sPham> spList)
        {
            string firstColumn1 = "";
            string secondColumn1 = "";
            string threeColumn1 = "";
            string fourColumn1 = "";
            string fiveColumn1 = "";
            double tongXuat = 0;
            double tongNhap = 0;
            double tongLoiNhuan = 0;
            string dateFrom = timeFrom.Value.ToString("yyy/MM/dd");
            string dateTo = timeTo.Value.ToString("yyy/MM/dd");
            for (int i = 0; i < spList.Count; i++)
            {
                string firstColumn = "";
                string secondColumn = "";
                string threeColumn = "";
                string fourColumn = "";
                string fiveColumn = "";
                string maSP = spList[i].maSP;
                firstColumn = spList[i].maSP;
                secondColumn = spList[i].name;
                // Tinh so luong nhap den dateTo
                // MessageBox.Show(dateTo);

                SqlCommand cmdQr = new SqlCommand("SELECT SUM(tienhang) as tienhang FROM nhaphang_list WHERE id_mahang= '" + maSP + "' and date <= '" + dateTo + "' and date >= '" + dateFrom + "' ", con);
                SqlDataReader read = cmdQr.ExecuteReader();

                while (read.Read())
                {
                    if (read["tienhang"].ToString() != "")
                    {
                        threeColumn = string.Format("{0:n0}", read["tienhang"]);
                        tongNhap += double.Parse(read["tienhang"].ToString());

                    }
                    else
                    {
                        threeColumn = "0";
                        tongNhap += 0;
                        //MessageBox.Show("asd");

                    }

                }
                read.Close();
                SqlCommand cmdQr2 = new SqlCommand("SELECT SUM(tienhang) as tienhang FROM banhang_list WHERE id_mahang= '" + maSP + "' and date <= '" + dateTo + "' and date >= '" + dateFrom + "' and  donvi = 'bao' ", con);
                SqlDataReader read2 = cmdQr2.ExecuteReader();

                while (read2.Read())
                {
                    if (read2["tienhang"].ToString() != "")
                    {
                        //hangTonKho = sumNhap - Int32.Parse(read2["soluong"].ToString());
                        fourColumn = string.Format("{0:n0}", read2["tienhang"]);
                        tongXuat += double.Parse(read2["tienhang"].ToString());
                    }
                    else
                    {
                        fourColumn = "0";
                        tongXuat += 0;
                        //hangTonKho = sumNhap;
                        //MessageBox.Show("asd");
                    }
                }
                read2.Close();
                SqlCommand cmdQr3 = new SqlCommand("SELECT SUM(loinhuan) as loinhuan FROM banhang_list WHERE id_mahang= '" + maSP + "' and date <= '" + dateTo + "' and date >= '" + dateFrom + "' and  donvi = 'bao' ", con);
                SqlDataReader read3 = cmdQr3.ExecuteReader();

                while (read3.Read())
                {
                    if (read3["loinhuan"].ToString() != "")
                    {
                        //hangTonKho = sumNhap - Int32.Parse(read2["soluong"].ToString());
                        fiveColumn = string.Format("{0:n0}", read3["loinhuan"]);
                        tongLoiNhuan += double.Parse(read3["loinhuan"].ToString());
                    }
                    else
                    {
                        fiveColumn = "0";
                        tongLoiNhuan += 0;
                        //hangTonKho = sumNhap;
                        //MessageBox.Show("asd");
                    }
                }
                read3.Close();

                string[] row = { firstColumn, secondColumn, threeColumn, fourColumn, fiveColumn };
                dataGridView1.Rows.Add(row);

                // MessageBox.Show(hangTonKho.ToString());                
            }
            firstColumn1 = "Tổng";
            secondColumn1 = "";
            threeColumn1 = string.Format("{0:n0}", tongNhap);
            fourColumn1 = string.Format("{0:n0}", tongXuat); 
            fiveColumn1 = string.Format("{0:n0}", tongLoiNhuan);
            string[] rows = { firstColumn1, secondColumn1, threeColumn1, fourColumn1, fiveColumn1 };
            dataGridView1.Rows.Add(rows);
            con.Close();
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
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
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
        }

        private void BCLoiNhuan_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
        }

    }
}
