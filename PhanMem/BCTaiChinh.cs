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
    public partial class BCTaiChinh : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");
        private float tienNhap = 0;
        private float loiNhuan = 0;
        private float canTra = 0;
        private float canThu = 0;
        private float daBan = 0;
        private float tonKho = 0;
        private float tongTra = 0;
        private float tienHangBan = 0;

        public BCTaiChinh()
        {
            InitializeComponent();
        }

        private void BCTaiChinh_Load(object sender, EventArgs e)
        {
            
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT total, tongno  FROM quanlyno WHERE type = 1 ", con);
            SqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                tienNhap += float.Parse(read["total"].ToString());
                canTra += float.Parse(read["tongno"].ToString());
            }
            read.Close();
            SqlCommand cmd2 = new SqlCommand("SELECT profit, total,tongno,tongtra  FROM quanlyno WHERE type = 2 ", con);
            SqlDataReader read2 = cmd2.ExecuteReader();

            while (read2.Read())
            {
                canThu += float.Parse(read2["tongno"].ToString());
                loiNhuan += float.Parse(read2["profit"].ToString());
                tienHangBan += float.Parse(read2["total"].ToString());
                tongTra += float.Parse(read2["tongtra"].ToString());
            }
            read2.Close();
            if (con.State != ConnectionState.Open)
            {
                con.Close();
            }
            daBan = tienHangBan - loiNhuan;
            tonKho = tienNhap - daBan;
            lblTotal.Text = string.Format("{0:n0}", tienNhap);
            lblLoiNhuan.Text = string.Format("{0:n0}", loiNhuan);
            lblCanThu.Text = string.Format("{0:n0}", canThu);
            lblCanTra.Text = string.Format("{0:n0}", canTra);
            lblDaBan.Text = string.Format("{0:n0}", daBan);
            lblTonKho.Text = string.Format("{0:n0}", tonKho);
            lblDoanhThu.Text = string.Format("{0:n0}", tienHangBan);
            lblDaThu.Text = string.Format("{0:n0}", tongTra);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
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
                tienNhap = 0;
                loiNhuan = 0;
                canTra = 0;
                canThu = 0;
                daBan = 0;
                tonKho = 0;
                tongTra = 0;
                tienHangBan = 0;
                float totalInput = 0;
                float totalOutput = 0;
                float totalProfit = 0;

                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                //THEO THOI GIAN
                SqlCommand cmd = new SqlCommand("SELECT total, tongno  FROM quanlyno WHERE type = 1 AND date <= '" + dateTo + "' AND date >= '" + dateFrom + "' ", con);
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    tienNhap += float.Parse(read["total"].ToString());
                    canTra += float.Parse(read["tongno"].ToString());
                }
                read.Close();
                SqlCommand cmd2 = new SqlCommand("SELECT profit, total,tongno,tongtra  FROM quanlyno WHERE type = 2 AND date <= '" + dateTo + "' AND date >= '" + dateFrom + "' ", con);
                SqlDataReader read2 = cmd2.ExecuteReader();

                while (read2.Read())
                {
                    canThu += float.Parse(read2["tongno"].ToString());
                    loiNhuan += float.Parse(read2["profit"].ToString());
                    tienHangBan += float.Parse(read2["total"].ToString());
                    tongTra += float.Parse(read2["tongtra"].ToString());
                }
                read2.Close();
                //TINH TON KHO
                SqlCommand cmd3 = new SqlCommand("SELECT total  FROM quanlyno WHERE type = 1 AND date <= '" + dateTo + "'", con);
                SqlDataReader read3 = cmd3.ExecuteReader();

                while (read3.Read())
                {
                    totalInput += float.Parse(read3["total"].ToString());

                }
                read3.Close();
                SqlCommand cmd4 = new SqlCommand("SELECT total,profit  FROM quanlyno WHERE type = 2 AND date <= '" + dateTo + "'", con);
                SqlDataReader read4 = cmd4.ExecuteReader();

                while (read4.Read())
                {
                    totalOutput += float.Parse(read4["total"].ToString());
                    totalProfit += float.Parse(read4["profit"].ToString());
                }
                read4.Close();

                if (con.State != ConnectionState.Open)
                {
                    con.Close();
                }
                daBan = tienHangBan - loiNhuan;
                tonKho = totalInput - totalOutput + totalProfit;
                lblTotal.Text = string.Format("{0:n0}", tienNhap);
                lblLoiNhuan.Text = string.Format("{0:n0}", loiNhuan);
                lblCanThu.Text = string.Format("{0:n0}", canThu);
                lblCanTra.Text = string.Format("{0:n0}", canTra);
                lblDaBan.Text = string.Format("{0:n0}", daBan);
                lblTonKho.Text = string.Format("{0:n0}", tonKho);
                lblDoanhThu.Text = string.Format("{0:n0}", tienHangBan);
                lblDaThu.Text = string.Format("{0:n0}", tongTra);
            }
            
        }
    }
}
