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
    public partial class BanHang : Form
    {
        Boolean check = false;
        double giabankg1 = 0;
        double giabankg2 = 0;
        double giabankg3 = 0;
        double giabankg4 = 0;

        double giabanbao1 = 0;
        double giabanbao2 = 0;
        double giabanbao3 = 0;
        double giabanbao4 = 0;
        double banKg = 0;
        double banBao = 0;
        double dauRaKg = 0;
        double dauRaBao = 0;
        double totalPrice = 0;
        double Sum = 0;
        int tangBao = 10;
        string type = "";
        string typeSmall = "";
        double khuyenMai = 0;

        SqlConnection con = new SqlConnection(@"Data Source=TUAN-PC\SQLEXPRESS;Initial Catalog=banhang;Integrated Security=True");
        public BanHang()
        {
            InitializeComponent();
        }
        void ClearTextBox()
        {
            txtCK1.Clear();
            txtCK2.Clear();
            txtCK3.Clear();
            txtSoLuongKg.Clear();
            txtGiaBao.Clear();
            txtGiaKg.Clear();
            txtGiaBanBao.Clear();
            txtGiaBanKg.Clear();
            txtSoLuongBao.Clear();
            txtName.Clear();
            txtKhoiLuong.Clear();
            txtSum.Clear();
            txtNo.Clear();
            txtPay.Clear();
            txtTotal.Clear();

        }
        void CalculateTotal()
        {
            int ck1 = 0;
            int ck2 = 0;
            int ck3 = 0;
            int soLuongkg = 0;
            int soLuongbao = 0;
            if (!string.IsNullOrEmpty(txtCK1.Text))
            {
                ck1 = Int32.Parse(txtCK1.Text);
            }
            if (!string.IsNullOrEmpty(txtCK2.Text))
            {
                ck2 = Int32.Parse(txtCK2.Text);
            }
            if (!string.IsNullOrEmpty(txtCK3.Text))
            {
                ck3 = Int32.Parse(txtCK3.Text);
            }
            if (!string.IsNullOrEmpty(txtSoLuongKg.Text))
            {
                soLuongkg = Int32.Parse(txtSoLuongKg.Text);
            }
            if (!string.IsNullOrEmpty(txtSoLuongBao.Text))
            {
                soLuongbao = Int32.Parse(txtSoLuongBao.Text);
            }
            dauRaKg = banKg * (100 - ck1) / 100 - ck2 - ck3;
            dauRaBao = dauRaKg * Int32.Parse(txtKhoiLuong.Text);
            txtGiaBanKg.Text = string.Format("{0:n0}", dauRaKg);
            txtGiaBanBao.Text = string.Format("{0:n0}", dauRaBao);
            totalPrice = soLuongkg * dauRaKg + soLuongbao * dauRaBao;
            txtTotal.Text = string.Format("{0:n0}", totalPrice);
            //khuyenMai = (ck1*banKg +ck2+ck3) * (soLuongkg + soLuongbao*)


        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        private void BanHang2_Load(object sender, EventArgs e)
        {
            try
            {
                cbxGia.Items.Add("Giá Loại 1");
                cbxGia.Items.Add("Giá Loại 2");
                cbxGia.Items.Add("Giá Loại 3");
                cbxGia.Items.Add("Giá Loại 4");

                cbxGia.SelectedIndex = cbxGia.FindStringExact("Giá Loại 1");
                txtCK1.Text = "0";
                txtCK2.Text = "0";
                txtCK3.Text = "0";
                txtPay.Text = "0";
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT mahang FROM sanpham WHERE mahang like '%" + txtMa.Text + "%' ", con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtMa.AutoCompleteCustomSource.Add(dr["mahang"].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {

            }
        } 

        private void txtMa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM sanpham WHERE mahang = '" + txtMa.Text + "' ", con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtName.Text = dr["name"].ToString();
                    txtKhoiLuong.Text = dr["khoiluong"].ToString();
                    txtGiaKg.Text = string.Format("{0:n0}", dr["gianetkg"]);
                    txtGiaBao.Text = string.Format("{0:n0}", dr["gianetbao"]);
                    type = dr["type"].ToString();

                    giabankg1 = double.Parse(dr["giabankg1"].ToString());
                    giabankg2 = double.Parse(dr["giabankg2"].ToString());
                    giabankg3 = double.Parse(dr["giabankg3"].ToString());
                    giabankg4 = double.Parse(dr["giabankg4"].ToString());

                    giabanbao1 = double.Parse(dr["giabanbao1"].ToString());
                    giabanbao2 = double.Parse(dr["giabanbao2"].ToString());
                    giabanbao3 = double.Parse(dr["giabanbao3"].ToString());
                    giabanbao4 = double.Parse(dr["giabanbao4"].ToString());


                }
                txtGiaBanKg.Text = string.Format("{0:n0}", giabankg1);
                txtGiaBanBao.Text = string.Format("{0:n0}", giabanbao1);
                banKg = giabankg1;
                banBao = giabanbao1;
                switch (type)
                {
                    case "bao": typeSmall = "Kg";
                        break;
                    case "tui": typeSmall = "Lọ";
                        break;
                    default: break;
                }
                check = true;
                dr.Close();
                con.Close();

            }
        }

        private void cbxGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxGia.Text)
            {
                case "Giá Loại 1": txtGiaBanKg.Text = string.Format("{0:n0}", giabankg1);
                    txtGiaBanBao.Text = string.Format("{0:n0}", giabanbao1);
                    banKg = giabankg1;
                    banBao = giabanbao1;
                    break;
                case "Giá Loại 2": txtGiaBanKg.Text = string.Format("{0:n0}", giabankg2);
                    txtGiaBanBao.Text = string.Format("{0:n0}", giabanbao2);
                    banKg = giabankg2;
                    banBao = giabanbao2;
                    break;
                case "Giá Loại 3": txtGiaBanKg.Text = string.Format("{0:n0}", giabankg3);
                    txtGiaBanBao.Text = string.Format("{0:n0}", giabanbao3);
                    banKg = giabankg3;
                    banBao = giabanbao3;
                    break;
                case "Giá Loại 4": txtGiaBanKg.Text = string.Format("{0:n0}", giabankg4);
                    txtGiaBanBao.Text = string.Format("{0:n0}", giabanbao4);
                    banKg = giabankg4;
                    banBao = giabanbao4;
                    break;
                default: break;
            }
            if (check)
            {
                CalculateTotal();
            }
        }

        private void txtSoLuongKg_TextChanged(object sender, EventArgs e)
        {
            if (check)
            {
                CalculateTotal();
            }
        }

        private void txtSoLuongBao_TextChanged(object sender, EventArgs e)
        {
            if (check)
            {
                CalculateTotal();
            }
        }

        private void txtCK1_TextChanged(object sender, EventArgs e)
        {
            if (check)
            {
                CalculateTotal();
            }
        }

        private void txtCK2_TextChanged(object sender, EventArgs e)
        {
            if (check)
            {
                CalculateTotal();
            }
        }

        private void txtCK3_TextChanged(object sender, EventArgs e)
        {
            if (check)
            {
                CalculateTotal();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            panel4.Visible = true; 
            int soBao = 0;
            string firstColum = txtMa.Text;
            string secondColum = txtName.Text;
            string threeColum = "";
            string fiveColum = "";
            string fourColum = "";
            string sixColum = "";
            if (!string.IsNullOrEmpty(txtSoLuongKg.Text))
            {
                threeColum = txtSoLuongKg.Text;
                fourColum = typeSmall;
                sixColum = txtGiaBanKg.Text;
            }
            else
            {
                threeColum = txtSoLuongBao.Text;
                fourColum = type;
                sixColum = txtGiaBanBao.Text;
                soBao = Int32.Parse(txtSoLuongBao.Text);
            }

            fiveColum = "Khuyến mãi";
            string sevenColum = txtTotal.Text;
            Sum += double.Parse(txtTotal.Text);
            txtSum.Text = string.Format("{0:n0}", Sum);
            string[] row = { firstColum, secondColum, threeColum, fourColum, fiveColum, sixColum, sevenColum };
            dataGridView1.Rows.Add(row);
            int tangbao = (soBao / 10);
            if (tangbao >= 1)
            {
                firstColum = txtMa.Text;
                secondColum = txtName.Text;
                threeColum = tangbao.ToString();
                fourColum = type;
                fiveColum = "Tặng Bao";
                sixColum = "0";
                sevenColum = "0";
                string[] rowAdd = { firstColum, secondColum, threeColum, fourColum, fiveColum, sixColum, sevenColum };
                dataGridView1.Rows.Add(rowAdd);
            }
            
        }

        void ExportExcel() 
        {
            Microsoft.Office.Interop.Excel.Application objexcelapp = new Microsoft.Office.Interop.Excel.Application();
            objexcelapp.Application.Workbooks.Add(Type.Missing);
            objexcelapp.Columns.ColumnWidth = 25;
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                objexcelapp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            /*For storing Each row and column value to excel sheet*/
            int maxRow = dataGridView1.Rows.Count;
            int maxColum = dataGridView1.Columns.Count;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        objexcelapp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            DateTime d1 = DateTime.Now;
            DateTime d2 = DateTime.Now.AddDays(60);
            string date = (d1 - d2).TotalDays.ToString();
            objexcelapp.Cells[maxRow + 1, maxColum - 1] = "Tổng Tiền Hàng: ";
            objexcelapp.Cells[maxRow + 1, maxColum] = Sum.ToString();


            string root = @"D:\QuanLyBanHang\BanHang";



            // If directory does not exist, create it.

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            string filename = "auto.xlsx";
            MessageBox.Show(root + @"\" + filename);
            objexcelapp.ActiveWorkbook.SaveCopyAs(root + @"\" + filename);

            objexcelapp.ActiveWorkbook.Saved = true;
            // SEND MAIL
            /*MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient();
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.UseDefaultCredentials = false; 
            SmtpServer.Host = "smtp.gmail.com";
            SmtpServer.EnableSsl = true;
            SmtpServer.Port = 587;

            mail.From = new MailAddress("qlbancam@gmail.com");
            mail.To.Add("do.trong.huu@miyatsu.vn");
            mail.Subject = "HÓA ĐƠN NHẬP HÀNG";
            mail.Body = "HÓA ĐƠN NHẬP HÀNG";

            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(@"D:\"+filename);
            mail.Attachments.Add(attachment);
            SmtpServer.Credentials = new System.Net.NetworkCredential("qlbancam@gmail.com", "mmne1212");
            SmtpServer.Send(mail); */
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            DateTime d1 = DateTime.Now;
            int banhang_id = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            String query = "select max(id) from banhang";
            cmd.Connection = con;
            cmd.CommandText = query;
            try
            {
                banhang_id = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                
            }
            catch (Exception ex)
            {                
                banhang_id = 1;
            }
            double payment = double.Parse(txtPay.Text);
            double no = double.Parse(txtNo.Text);
            String querryAdd = "INSERT INTO banhang(sum,pay,no,date) VALUES(@sum,@pay,@no,@date)";
            var cmdAdd = new SqlCommand(querryAdd, con);

            cmdAdd.Parameters.AddWithValue("@sum", Sum);
            cmdAdd.Parameters.AddWithValue("@pay", payment);
            cmdAdd.Parameters.AddWithValue("@no", no);
            cmdAdd.Parameters.AddWithValue("@date", d1);
            cmdAdd.ExecuteNonQuery();         

            for (int i = 0; i < dataGridView1.Rows.Count -1; i++)
            {
                var stringQr = "INSERT INTO banhang_list (id_don,id_mahang,soluong,donvi,dongia,tienhang,date)" +
               "VALUES(@id_don,@id_mahang,@soluong,@donvi,@dongia,@tienhang,@date)";
                var cmdRun = new SqlCommand(stringQr, con);
                cmdRun.Parameters.AddWithValue("@id_don", banhang_id);
                cmdRun.Parameters.AddWithValue("@id_mahang", dataGridView1.Rows[i].Cells["mahang"].Value);
                cmdRun.Parameters.AddWithValue("@soluong", float.Parse(dataGridView1.Rows[i].Cells["soluong"].Value.ToString()) );
                cmdRun.Parameters.AddWithValue("@donvi", dataGridView1.Rows[i].Cells["donvi"].Value.ToString());
                cmdRun.Parameters.AddWithValue("@dongia", float.Parse(dataGridView1.Rows[i].Cells["dongia"].Value.ToString()));
                cmdRun.Parameters.AddWithValue("@tienhang", float.Parse(dataGridView1.Rows[i].Cells["total"].Value.ToString()));
                cmdRun.Parameters.AddWithValue("@date", d1);                
                cmdRun.ExecuteNonQuery();                
            }
            con.Close();
           // ExportExcel();
           // ClearTextBox();
        }

        private void txtPay_TextChanged(object sender, EventArgs e)
        {
            double payment = 0;
            if (!string.IsNullOrEmpty(txtPay.Text))
            {
                payment = double.Parse(txtPay.Text);
            }
           
            txtNo.Text = (Sum - payment).ToString();
        }

    }
}
