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
using Microsoft.Office.Interop.Excel;

namespace PhanMem
{
    public partial class BanHang : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");
        Boolean check = false;
        double giaNet = 0;
        double giaLuaChon = 0;
        double giaBanRa = 0;
        double giaban1 = 0;
        double giaban2 = 0;
        double giaban3 = 0;
        double giaban4 = 0;
        double totalPay = 0;
        double Sum = 0;
        int quyCach = 0;
        string donviTinh = "";
        string emailNhan = "";
        int id_bangGia = 0;
        List<double> LoiNhuan = new List<double>();
        public BanHang()
        {
            InitializeComponent();
        }
        public void clearText()
        {
            txtName.Clear();
            txtCK1.Clear();
            txtCK2.Clear();
            txtCK3.Clear();
            txtDonVi.Clear();
            txtSoLuong.Clear();
            txtKhuyenMai.Clear();
            txtGiaBan.Clear();
            txtSum.Clear();
            txtNo.Clear();
            txtPay.Clear();
            txtTotal.Clear();
            txtCustomer.Clear();
            cbxGia.SelectedIndex = cbxGia.FindStringExact("Giá Loại 1");
        }
        void resetVariable()
        {
            giaNet = 0;
            check = false;
            giaban1 = 0;
            giaban2 = 0;
            giaban3 = 0;
            giaban4 = 0;
            totalPay = 0;
            quyCach = 0;
            donviTinh = "";
            emailNhan = "";
            Sum = 0;
            LoiNhuan.Clear();
            panel4.Visible = false;
            dataGridView1.Rows.Clear();

        }
        void CalculateTotal()
        {
            int ck1 = 0;
            int ck2 = 0;
            int ck3 = 0;
            int soLuong = 0;
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
            if (!string.IsNullOrEmpty(txtSoLuong.Text))
            {
                soLuong = Int32.Parse(txtSoLuong.Text);
            }

            giaBanRa = giaLuaChon * (100 - ck1) / 100 - (ck2 - ck3)*quyCach;
            txtGiaBan.Text = string.Format("{0:n0}", giaBanRa);
            totalPay = giaBanRa * soLuong;
            txtTotal.Text = string.Format("{0:n0}", totalPay);
            
        }
        private void BanHang_Load(object sender, EventArgs e)
        {
            try
            {
                button1.Visible = false;
                dataGridView1.AllowUserToAddRows = false;
                cbxGia.Items.Add("Giá Loại 1");
                cbxGia.Items.Add("Giá Loại 2");
                cbxGia.Items.Add("Giá Loại 3");
                cbxGia.Items.Add("Giá Loại 4");

                cbxGia.SelectedIndex = cbxGia.FindStringExact("Giá Loại 1");
                txtCK1.Text = "0";
                txtCK2.Text = "0";
                txtCK3.Text = "0";
                //txtPay.Text = "0";
                con.Open();
                SqlCommand cmd4 = new SqlCommand("SELECT id FROM banggia WHERE status = 1", con);
                SqlDataReader dr4;
                dr4 = cmd4.ExecuteReader();
                while (dr4.Read())
                {
                    id_bangGia = Int32.Parse(dr4["id"].ToString());
                    //passEmail = dr2["password"].ToString();
                }
                dr4.Close();
                SqlCommand cmd = new SqlCommand("SELECT mahang FROM sanpham WHERE id_banggia = '" + id_bangGia+ "' AND mahang like '%" + txtMa.Text + "%' ", con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtMa.AutoCompleteCustomSource.Add(dr["mahang"].ToString());
                }
                dr.Close();
                SqlCommand cmd2 = new SqlCommand("SELECT name FROM customer WHERE name like '%" + txtCustomer.Text + "%' ", con);
                SqlDataReader dr2;
                dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    txtCustomer.AutoCompleteCustomSource.Add(dr2["name"].ToString());
                }
                dr2.Close();
                SqlCommand cmd3 = new SqlCommand("SELECT email,password FROM account", con);
                SqlDataReader dr3;
                dr3 = cmd3.ExecuteReader();
                while (dr3.Read())
                {
                    emailNhan = dr3["email"].ToString();
                    //passEmail = dr2["password"].ToString();
                }
                dr2.Close();
               
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void txtMa_TextChanged(object sender, EventArgs e)
        {
            clearText();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            int soBao = 0;
            string firstColum = txtMa.Text;
            //string secondColum = txtName.Text;
            string threeColum = "";
            string fiveColum = "";
            string fourColum = "";
            string sixColum = "";
            if (!string.IsNullOrEmpty(txtSoLuong.Text))
            {
                threeColum = txtSoLuong.Text;
                fourColum = donviTinh;
                sixColum = txtGiaBan.Text;
                double lai = Int32.Parse(txtSoLuong.Text) * (giaBanRa - giaNet);
                LoiNhuan.Add(lai);
                soBao = Int32.Parse(txtSoLuong.Text);
                //khuyenMai = (gia)
            }
           

            fiveColum = "Khuyến mãi";
            string sevenColum = txtTotal.Text;
            Sum += double.Parse(txtTotal.Text);
            txtSum.Text = string.Format("{0:n0}", Sum);
            string[] row = { firstColum, threeColum, fourColum, fiveColum, sixColum, sevenColum };
            dataGridView1.Rows.Add(row);
            int kmBao = 0;// Int32.Parse(txtKhuyenMai.Text);
            if (!string.IsNullOrEmpty(txtKhuyenMai.Text))
            {
                kmBao = Int32.Parse(txtKhuyenMai.Text);
                int tangbao = (soBao / kmBao);
                if (tangbao >= 1)
                {
                    firstColum = txtMa.Text;
                    //secondColum = txtName.Text;
                    threeColum = tangbao.ToString();
                    fourColum = donviTinh;
                    fiveColum = "Tặng Bao";
                    sixColum = "0";
                    sevenColum = "0";
                    //string[] rowAdd = { firstColum, secondColum, threeColum, fourColum, fiveColum, sixColum, sevenColum };
                    string[] rowAdd = { firstColum, threeColum, fourColum, fiveColum, sixColum, sevenColum };
                    LoiNhuan.Add(0);
                    dataGridView1.Rows.Add(rowAdd);
                }
            }
            
        }

        private void txtMa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM sanpham WHERE id_banggia = '" + id_bangGia + "' AND mahang = '" + txtMa.Text + "' ", con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cbxGia.SelectedIndex = cbxGia.FindStringExact("Giá Loại 1");
                    txtName.Text = dr["name"].ToString();
                    donviTinh = dr["donvi"].ToString();
                    txtDonVi.Text = dr["donvi"].ToString();
                    giaNet = double.Parse(dr["gianet"].ToString());
                    quyCach = Int32.Parse(dr["khoiluong"].ToString());
                    txtQuyCach.Text = quyCach.ToString();
                    if (dr["giaban1"].ToString() != "")
                    {
                        giaban1 = double.Parse(dr["giaban1"].ToString());
                    }
                    else
                    {
                        giaban1 = giaNet + 5000;
                    }
                    if (dr["giaban2"].ToString() != "")
                    {
                        giaban1 = double.Parse(dr["giaban2"].ToString());
                    }
                    else
                    {
                        giaban2 = giaNet + 10000;
                    }
                    if (dr["giaban3"].ToString() != "")
                    {
                        giaban3 = double.Parse(dr["giaban3"].ToString());
                    }
                    else
                    {
                        giaban3 = giaNet + 15000;
                    }
                    if (dr["giaban4"].ToString() != "")
                    {
                        giaban4 = double.Parse(dr["giaban4"].ToString());
                    }
                    else
                    {
                        giaban4 = giaNet + 20000;
                    }                                     

                }
                txtGiaBan.Text = string.Format("{0:n0}", giaban1);
                giaLuaChon = giaban1;
                check = true;
                dr.Close();
                con.Close();

            }
        }
        void ExportExcel(int banhang_id, string customer, double payment, double no)
        {
            string khachhang = "";
            if (customer != "")
            {
                khachhang = customer;
            }
            else
            {
                khachhang = "KHÁCH LẺ";
            }
            string date = DateTime.Now.ToString("dd-MM-yyy");
            Microsoft.Office.Interop.Excel.Application objexcelapp = new Microsoft.Office.Interop.Excel.Application();
            objexcelapp.Application.Workbooks.Add(Type.Missing);
            objexcelapp.Columns.ColumnWidth = 14;
            objexcelapp.get_Range("A1", "F1").Merge(false);
            var chartRange = objexcelapp.get_Range("A1", "F1");
            string subjectHeader = "HÓA ĐƠN BÁN HÀNG NGÀY " + date + " MÃ ĐƠN " + banhang_id.ToString() + " KHÁCH HÀNG " + khachhang;
            chartRange.FormulaR1C1 = subjectHeader;
            chartRange.HorizontalAlignment = 3;
            chartRange.VerticalAlignment = 3;
            chartRange.Font.Size = 12;
            chartRange.EntireRow.Font.Bold = true;

            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                objexcelapp.Cells[2, i] = dataGridView1.Columns[i - 1].HeaderText;
                objexcelapp.Cells[2, i].HorizontalAlignment = XlHAlign.xlHAlignCenter;
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
                        objexcelapp.Cells[i + 3, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        //objexcelapp.Cells[i + 3, j + 1].HorizontalAlignment = 3;

                        objexcelapp.Cells[i + 3, j + 1].HorizontalAlignment = XlHAlign.xlHAlignCenter;


                        objexcelapp.Cells[i + 3, j + 1].Font.Size = 12;
                    }
                }
            }
            DateTime d1 = DateTime.Now;
            DateTime d2 = DateTime.Now.AddDays(60);
            //string date = (d1 - d2).TotalDays.ToString();

            //objexcelapp.Range["A1", "G1"].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkBlue;
            Microsoft.Office.Interop.Excel.Range formatRange;
            formatRange = objexcelapp.get_Range("A2", "F2");
            formatRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
            formatRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            formatRange.Font.Size = 12;
            // objexcelapp.Range["A1", "G1"].Interior.Color = Excel.XlRgbColor.rgbDarkBlue;
            objexcelapp.Cells[maxRow + 3, maxColum - 1] = "Tổng Tiền Hàng: ";
            objexcelapp.Cells[maxRow + 3, maxColum - 1].Font.Size = 10;
            objexcelapp.Cells[maxRow + 3, maxColum - 1].HorizontalAlignment = XlHAlign.xlHAlignLeft;
            objexcelapp.Cells[maxRow + 3, maxColum] = string.Format("{0:n0}", Sum);
            objexcelapp.Cells[maxRow + 3, maxColum].Font.Size = 10;
            objexcelapp.Cells[maxRow + 3, maxColum].HorizontalAlignment = XlHAlign.xlHAlignRight;
            objexcelapp.Cells[maxRow + 4, maxColum - 1] = "Đã Thanh Toán: ";
            objexcelapp.Cells[maxRow + 4, maxColum - 1].Font.Size = 10;
            objexcelapp.Cells[maxRow + 4, maxColum - 1].HorizontalAlignment = XlHAlign.xlHAlignLeft;
            objexcelapp.Cells[maxRow + 4, maxColum] = string.Format("{0:n0}", payment);
            objexcelapp.Cells[maxRow + 4, maxColum].Font.Size = 10;
            objexcelapp.Cells[maxRow + 4, maxColum].HorizontalAlignment = XlHAlign.xlHAlignRight;
            objexcelapp.Cells[maxRow + 5, maxColum - 1] = "Còn Nợ: ";
            objexcelapp.Cells[maxRow + 5, maxColum - 1].Font.Size = 10;
            objexcelapp.Cells[maxRow + 5, maxColum - 1].HorizontalAlignment = XlHAlign.xlHAlignLeft;
            objexcelapp.Cells[maxRow + 5, maxColum] = string.Format("{0:n0}", no);
            objexcelapp.Cells[maxRow + 5, maxColum].Font.Size = 10;
            objexcelapp.Cells[maxRow + 5, maxColum].HorizontalAlignment = XlHAlign.xlHAlignRight;

            string root = @"D:\QuanLyBanHang\BanHang";



            // If directory does not exist, create it.

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            string filename = date + "_" + "MaDon" + banhang_id.ToString() + ".xlsx";
            //MessageBox.Show(root + @"\" + filename);
            objexcelapp.ActiveWorkbook.SaveCopyAs(root + @"\" + filename);

            objexcelapp.ActiveWorkbook.Saved = true;
            MessageBox.Show(root + @"\" + filename);
            
            // SEND MAIL

            //try
            //{
            //    MailMessage mail = new MailMessage();
            //    SmtpClient SmtpServer = new SmtpClient();
            //    SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            //    SmtpServer.UseDefaultCredentials = false;
            //    SmtpServer.Host = "smtp.gmail.com";
            //    SmtpServer.EnableSsl = true;
            //    SmtpServer.Port = 587;
            //    string mailFrom = "qlbancam@gmail.com";
            //    string mailTo = emailNhan;
            //    mail.From = new MailAddress(mailFrom);
            //    mail.To.Add(mailTo);
            //    mail.Subject = subjectHeader;
            //    mail.Body = subjectHeader;

            //    System.Net.Mail.Attachment attachment;
            //    attachment = new System.Net.Mail.Attachment(root + @"\" + filename);
            //    mail.Attachments.Add(attachment);
            //    SmtpServer.Credentials = new System.Net.NetworkCredential("qlbancam@gmail.com", "mmne1212");
            //    SmtpServer.Send(mail);
            //    MessageBox.Show("Hệ thống tự động gửi hóa đơn đến mail " + mailTo);
            //}
            //catch
            //{

            //}
            // PRINT
            //Microsoft.Office.Interop.Excel.Workbook wrk = objexcelapp.Workbooks.Open(root + @"\" + filename, 0, true, 5, string.Empty, string.Empty, true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
            //wrk.PrintOut(1, 1, 1, false, null, false, false, null);
            //wrk.Close(false, string.Empty, false);
            //objexcelapp.Quit();

        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
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

        private void cbxGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxGia.Text)
            {
                case "Giá Loại 1": txtGiaBan.Text = string.Format("{0:n0}", giaban1);
                    giaLuaChon = giaban1;
                    break;
                case "Giá Loại 2": txtGiaBan.Text = string.Format("{0:n0}", giaban2);
                    giaLuaChon = giaban2;
                    break;
                case "Giá Loại 3": txtGiaBan.Text = string.Format("{0:n0}", giaban3);
                    giaLuaChon = giaban3;
                    break;
                case "Giá Loại 4": txtGiaBan.Text = string.Format("{0:n0}", giaban4);
                    giaLuaChon = giaban4;
                    break;
                default: break;
            }
            if (check)
            {
                CalculateTotal();
            }
        }

        private void txtPay_TextChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
            double payment = 0;
            if (!string.IsNullOrEmpty(txtPay.Text))
            {
                payment = double.Parse(txtPay.Text);
            }
            else
            {
                button1.Visible = false;
            }

            txtNo.Text = string.Format("{0:n0}", (Sum - payment));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime d1 = DateTime.Now;
            int banhang_id = 0;
            string customer = "";
            if (!string.IsNullOrEmpty(txtCustomer.Text))
            {
                customer = txtCustomer.Text;
            }
            con.Open();
            double payment = double.Parse(txtPay.Text);
            double no = double.Parse(txtNo.Text);
            String querryAdd = "INSERT INTO banhang(sum,pay,no,date,customer) VALUES(@sum,@pay,@no,@date,@customer)";
            var cmdAdd = new SqlCommand(querryAdd, con);

            cmdAdd.Parameters.AddWithValue("@sum", Sum);
            cmdAdd.Parameters.AddWithValue("@pay", payment);
            cmdAdd.Parameters.AddWithValue("@no", no);
            cmdAdd.Parameters.AddWithValue("@date", d1);
            cmdAdd.Parameters.AddWithValue("@customer", customer);
            cmdAdd.ExecuteNonQuery();
            SqlCommand cmd = new SqlCommand();
            String query = "select max(id) from banhang";
            cmd.Connection = con;
            cmd.CommandText = query;
            try
            {
                banhang_id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                banhang_id = 1;
            }

            String addQlyNo = "INSERT quanlyno(id_don,customer,total,payment,debt,date,type,tongno) VALUES(@id_don,@customer,@total,@payment,@debt,@date,@type,@tongno)";
            var cmdqly = new SqlCommand(addQlyNo, con);

            cmdqly.Parameters.AddWithValue("@id_don", banhang_id);
            cmdqly.Parameters.AddWithValue("@customer", customer);
            cmdqly.Parameters.AddWithValue("@total", Sum);
            cmdqly.Parameters.AddWithValue("@payment", payment);
            cmdqly.Parameters.AddWithValue("@debt", no);
            cmdqly.Parameters.AddWithValue("@date", d1);
            cmdqly.Parameters.AddWithValue("@type", 2);
            cmdqly.Parameters.AddWithValue("@tongno", no);
            cmdqly.ExecuteNonQuery();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var stringQr = "INSERT INTO banhang_list (id_don,id_mahang,soluong,donvi,dongia,tienhang,date,customer,loinhuan)" +
               "VALUES(@id_don,@id_mahang,@soluong,@donvi,@dongia,@tienhang,@date,@customer,@loinhuan)";
                var cmdRun = new SqlCommand(stringQr, con);
                cmdRun.Parameters.AddWithValue("@id_don", banhang_id);
                cmdRun.Parameters.AddWithValue("@id_mahang", dataGridView1.Rows[i].Cells["mahang"].Value);
                cmdRun.Parameters.AddWithValue("@soluong", float.Parse(dataGridView1.Rows[i].Cells["soluong"].Value.ToString()));
                cmdRun.Parameters.AddWithValue("@donvi", dataGridView1.Rows[i].Cells["donvi"].Value.ToString());
                cmdRun.Parameters.AddWithValue("@dongia", float.Parse(dataGridView1.Rows[i].Cells["dongia"].Value.ToString()));
                cmdRun.Parameters.AddWithValue("@tienhang", float.Parse(dataGridView1.Rows[i].Cells["total"].Value.ToString()));
                cmdRun.Parameters.AddWithValue("@date", d1);
                cmdRun.Parameters.AddWithValue("@customer", customer);
                cmdRun.Parameters.AddWithValue("@loinhuan", LoiNhuan[i]);
                cmdRun.ExecuteNonQuery();
            }
            con.Close();
            //MessageBox.Show("Thanh toán hoàn tất !");
            ExportExcel(banhang_id, customer, payment, no);
            // ClearTextBox();
            resetVariable();
            clearText();
            txtMa.Clear();
            button1.Visible = false;
        }
    }
}
