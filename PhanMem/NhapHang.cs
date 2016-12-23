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
using System.Drawing.Printing;
using Excel;
using Microsoft.Office.Interop.Excel;


namespace PhanMem
{
    public partial class NhapHang : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");
        public NhapHang()
        {
            InitializeComponent();
        }
       
        Boolean check = false;
        double giaDo = 0;
        double Sum = 0;
        double NoConLai = 0;
        double daThanhToan = 0;
        string type = "";
        string emailNhan = "";
        string passEmail = "";
        int id_bangGia = 0;
        void ClearTextBox()
        {
            txtGiaDo.Clear();
            txtDonVi.Clear();
            txtSoLuong.Clear();
            txtCK1.Clear();
            txtCK2.Clear();
            txtCK3.Clear();
            txtGiaNetNhap.Clear();
            txtName.Clear();
            txtTotal.Clear();
            txtPay.Clear();
            txtNo.Clear();
            txtKhoiLuong.Clear();
            txtKhuyenMai.Clear();
            check = false;
        }
        void ResetData()
        {
            
            dataGridView1.Rows.Clear();
            giaDo = 0;
            Sum = 0;
            NoConLai = 0;
            daThanhToan = 0;
            type = "";
            panel4.Visible = false;

        }
        public class ListItem
        {
            public string idHang { get; set; }
            public string soLuong {get;set;}
            public string kMai { get; set; }
            public string giaNet{get;set;}
            public string tienHang{get;set;}
        }
        List<ListItem> gridView = new List<ListItem>();
        private int numberOfItemPerPage = 0;
        private int numberOfItemsPrintedSoFar = 0;

        void calculatePrice()
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
            int weight = Int32.Parse(txtKhoiLuong.Text);
            double giaNetNhap = 0;            
            //double giaDo = double.Parse(decimal.Parse(txtGiaDo.Text, NumberStyles.Currency).ToString());
            giaNetNhap = giaDo * (100 - ck1) / 100 - (ck2 + ck3) * weight;
            txtGiaNetNhap.Text = string.Format("{0:n0}", giaNetNhap);
            //double price = double.Parse(decimal.Parse(txtGiaNetNhap.Text, NumberStyles.Currency).ToString());
            txtTotal.Text = string.Format("{0:n0}", giaNetNhap * soLuong);
        }

        private void NhapHang_Load(object sender, EventArgs e)
        {
            try
            {
                btnOrder.Visible = false;
                dataGridView1.AllowUserToAddRows = false;
                //panel4.Visible = false;
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd4 = new SqlCommand("SELECT id,name FROM banggia WHERE status = 1", con);
                SqlDataReader dr4;
                dr4 = cmd4.ExecuteReader();
                while (dr4.Read())
                {
                    id_bangGia = Int32.Parse(dr4["id"].ToString());
                    lblBangGia.Text = dr4["name"].ToString();
                    //passEmail = dr2["password"].ToString();
                }
                dr4.Close();
                SqlCommand cmd = new SqlCommand("SELECT mahang FROM sanpham WHERE id_banggia = '" + id_bangGia + "' AND  mahang like '%" + txtMa.Text + "%' ", con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtMa.AutoCompleteCustomSource.Add(dr["mahang"].ToString());
                }
                dr.Close();
                SqlCommand cmd2 = new SqlCommand("SELECT email,password FROM account", con);
                SqlDataReader dr2;
                dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    emailNhan = dr2["email"].ToString();
                    passEmail = dr2["password"].ToString();
                }
                dr2.Close();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                txtPay.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            calculatePrice();
        }

        private void txtCK1_TextChanged(object sender, EventArgs e)
        {
            if (check)
            {
                calculatePrice();
            }
        }

        private void txtCK2_TextChanged(object sender, EventArgs e)
        {
            if (check)
            {
                calculatePrice();
            }
        }

        private void txtCK3_TextChanged(object sender, EventArgs e)
        {
            if (check)
            {
                calculatePrice();
            }
        }
        void checkNumber(KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumber(e);
        }
        void ExportExcel(int nhaphang_id, double payment, double no)
        {
            string date = DateTime.Now.ToString("dd-MM-yyy");
            Microsoft.Office.Interop.Excel.Application objexcelapp = new Microsoft.Office.Interop.Excel.Application();
            objexcelapp.Application.Workbooks.Add(Type.Missing);
            objexcelapp.Columns.ColumnWidth = 14;
            objexcelapp.get_Range("A1", "F1").Merge(false);
            var chartRange = objexcelapp.get_Range("A1", "F1");
            string subjectHeader = "HÓA ĐƠN NHẬP HÀNG NGÀY " + date + " MÃ ĐƠN " + nhaphang_id.ToString();
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
            formatRange.Font.Size = 14;
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

            string root = @"D:\QuanLyBanHang\NhapHang";



            // If directory does not exist, create it.

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            string filename = date + "_" + "MaDon" + nhaphang_id.ToString() + ".xlsx";
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

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                panel4.Visible = true;
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
                Sum += double.Parse(txtTotal.Text);
                NoConLai = Sum;
                int weight = Int32.Parse(txtKhoiLuong.Text);
                double total = double.Parse(decimal.Parse(txtTotal.Text, NumberStyles.Currency).ToString());
                double price = double.Parse(decimal.Parse(txtGiaDo.Text, NumberStyles.Currency).ToString());
                double khuyenmai = price * soLuong - total;
                string firstColum = txtMa.Text;
                //string secondColum = txtName.Text;
                string threeColum = txtSoLuong.Text;
                string fourColum = type;
                string fiveColum = khuyenmai.ToString();
                string sixColum = txtGiaNetNhap.Text;
                string sevenColum = txtTotal.Text;
                //string[] row = { firstColum, secondColum, threeColum, fourColum, fiveColum, sixColum, sevenColum };
                string[] row = { firstColum, threeColum, fourColum, fiveColum, sixColum, sevenColum };
                gridView.Add(new ListItem()
                {
                    idHang = firstColum,
                    soLuong = threeColum,
                    kMai = fiveColum,
                    giaNet = sixColum,
                    tienHang = sevenColum

                });
                dataGridView1.Rows.Add(row);
                
                int kmBao = 0;// Int32.Parse(txtKhuyenMai.Text);
                if (!string.IsNullOrEmpty(txtKhuyenMai.Text))
                {
                    kmBao = Int32.Parse(txtKhuyenMai.Text);
                    int tangbao = (soLuong / kmBao);
                    if (tangbao >= 1)
                    {
                        firstColum = txtMa.Text;
                        //secondColum = txtName.Text;
                        threeColum = tangbao.ToString();
                        fourColum = type;
                        fiveColum = "Tặng Bao";
                        sixColum = txtGiaNetNhap.Text;
                        sevenColum = "0";
                        //string[] rowAdd = { firstColum, secondColum, threeColum, fourColum, fiveColum, sixColum, sevenColum };
                        string[] rowAdd = { firstColum, threeColum, fourColum, fiveColum, sixColum, sevenColum };
                        gridView.Add(new ListItem()
                        {
                            idHang = firstColum,
                            soLuong = threeColum,
                            kMai = fiveColum,
                            giaNet = sixColum,
                            tienHang = sevenColum

                        });
                        dataGridView1.Rows.Add(rowAdd);
                    }
                    
                }
                txtSum.Text = string.Format("{0:n0}", Sum);

            }
            catch
            {

            }
        }

        private void txtMa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM sanpham WHERE id_banggia = '"+id_bangGia+"' AND mahang = '" + txtMa.Text + "' ", con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    giaDo = double.Parse(dr["giado"].ToString());
                    txtName.Text = dr["name"].ToString();
                    txtCK1.Text = dr["ck1"].ToString();
                    txtCK2.Text = dr["ck2"].ToString();
                    txtCK3.Text = dr["ck3"].ToString();
                    txtKhoiLuong.Text = dr["khoiluong"].ToString();
                    txtGiaDo.Text = string.Format("{0:n0}", dr["giado"]);                   
                    txtGiaNetNhap.Text = string.Format("{0:n0}", dr["gianet"]);                    
                    type = dr["donvi"].ToString();
                    txtDonVi.Text = type;
                }
                check = true;
                dr.Close();
                con.Close();
            }
        }

        private void txtPay_TextChanged(object sender, EventArgs e)
        {
            btnOrder.Visible = true;
            double payment = 0;
            if (!string.IsNullOrEmpty(txtPay.Text))
            {
                payment = double.Parse(txtPay.Text);
                daThanhToan = payment;
            }
            NoConLai = Sum - payment;
            txtNo.Text = string.Format("{0:n0}", NoConLai); 
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            DateTime d1 = DateTime.Now;

            // MessageBox.Show(d1.ToString());
            int nhaphang_id = 0;
           
            double payment = double.Parse(txtPay.Text);
            double no = double.Parse(txtNo.Text);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            
            String querryAdd = "INSERT INTO nhaphang(sum,pay,no,date) VALUES(@sum,@pay,@no,@date)";
            var cmdAdd = new SqlCommand(querryAdd, con);

            cmdAdd.Parameters.AddWithValue("@sum", Sum);
            cmdAdd.Parameters.AddWithValue("@pay", payment);
            cmdAdd.Parameters.AddWithValue("@no", no);
            cmdAdd.Parameters.AddWithValue("@date", d1);
            cmdAdd.ExecuteNonQuery();
            
            SqlCommand cmd = new SqlCommand();
            String query = "select max(id) from nhaphang";
            cmd.Connection = con;
            cmd.CommandText = query;
            try
            {
                nhaphang_id = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                nhaphang_id = 1;
            }
            String addQlyNo = "INSERT quanlyno(id_don,total,payment,debt,date,type,tongno) VALUES(@id_don,@total,@payment,@debt,@date,@type,@tongno)";
            var cmdqly = new SqlCommand(addQlyNo, con);

            cmdqly.Parameters.AddWithValue("@id_don", nhaphang_id);
            cmdqly.Parameters.AddWithValue("@total", Sum);
            cmdqly.Parameters.AddWithValue("@payment", payment);
            cmdqly.Parameters.AddWithValue("@debt", no);
            cmdqly.Parameters.AddWithValue("@date", d1);
            cmdqly.Parameters.AddWithValue("@type", 1);
            cmdqly.Parameters.AddWithValue("@tongno", no);
            cmdqly.ExecuteNonQuery();

            for (int i = 0; i < dataGridView1.Rows.Count ; i++)
            {
                var stringQr = "INSERT INTO nhaphang_list (id_don,id_mahang,soluong,donvi,gianetnhap,tienhang,date)" +
               "VALUES(@id_don,@id_mahang,@soluong,@donvi,@gianetnhap,@tienhang,@date)";
                var cmdRun = new SqlCommand(stringQr, con);
                cmdRun.Parameters.AddWithValue("@id_don", nhaphang_id);
                cmdRun.Parameters.AddWithValue("@id_mahang", dataGridView1.Rows[i].Cells["mahang"].Value);
                cmdRun.Parameters.AddWithValue("@soluong", float.Parse(dataGridView1.Rows[i].Cells["soluong"].Value.ToString()));
                cmdRun.Parameters.AddWithValue("@donvi", dataGridView1.Rows[i].Cells["donvi"].Value.ToString());
                cmdRun.Parameters.AddWithValue("@gianetnhap", float.Parse(dataGridView1.Rows[i].Cells["gianetnhap"].Value.ToString()));
                cmdRun.Parameters.AddWithValue("@tienhang", float.Parse(dataGridView1.Rows[i].Cells["total"].Value.ToString()));
                cmdRun.Parameters.AddWithValue("@date", d1);
                cmdRun.ExecuteNonQuery();
            }
            con.Close();
            ExportExcel(nhaphang_id, payment, no);
            ClearTextBox();
            ResetData();
            btnOrder.Visible = false;
            txtMa.Clear();
        }
        void addDataGridView()
        {
            
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Exel WorkBook|*", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    dataGridView1.Rows.Clear();
                    gridView.Clear();
                    if(con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    Sum = 0;
                    FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);
                    Excel.IExcelDataReader reader = Excel.ExcelReaderFactory.CreateOpenXmlReader(fs);
                    reader.IsFirstRowAsColumnNames = true;
                    DataSet result = reader.AsDataSet();
                    //result.Fill(test);

                    foreach (DataRow myDataRow in result.Tables[0].Rows)
                    {                       
                        string mHang = myDataRow[1].ToString();
                        double giaDoLoad = 0;
                        int khoiLuongLoad = 0;
                        int soLuongLoad = 0;
                        double ck1Load = 0;
                        double ck2Load = 0;
                        double ck3Load = 0;
                        double giaNetNhapLoad = 0;
                        double tienHangLoad = 0;
                        double tienKMLoad = 0;
                        int TangBaoLoad = 0;
                        if (myDataRow[2].ToString() == "")
                        {
                            MessageBox.Show("Dữ liệu nhập vào không chính xác!");
                            break;                           
                        }
                        else
                        {
                            soLuongLoad = Int32.Parse(myDataRow[2].ToString());
                        }
                        if(myDataRow[3].ToString() != "" )
                        {
                            ck1Load = double.Parse(myDataRow[3].ToString());
                        }
                        if (myDataRow[4].ToString() != "")
                        {
                            ck2Load = double.Parse(myDataRow[4].ToString());
                        }
                        if (myDataRow[5].ToString() != "")
                        {
                            ck3Load = double.Parse(myDataRow[5].ToString());
                        }
                        if (myDataRow[6].ToString() != "")
                        {
                            TangBaoLoad = Int32.Parse(myDataRow[6].ToString());
                        }
                        string donviLoad = "";
                        string firstColum = mHang;
                        string secondColum = soLuongLoad.ToString();
                        string threeColum = "";
                        string fourColum = "";
                        string fiveColum = "";
                        string sixColum = "";

                        SqlCommand cmd = new SqlCommand("SELECT * FROM sanpham WHERE id_banggia = '" + id_bangGia + "' AND mahang = '" + mHang + "' ", con);
                        SqlDataReader dr;
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            giaDoLoad = double.Parse(dr["giado"].ToString());
                            khoiLuongLoad = Int32.Parse(dr["khoiluong"].ToString());
                            donviLoad = dr["donvi"].ToString();
                        }
                        dr.Close();
                        giaNetNhapLoad = giaDoLoad * (100 - ck1Load) / 100 -(ck2Load + ck3Load)*khoiLuongLoad;
                        tienKMLoad = (giaDoLoad - giaNetNhapLoad) * soLuongLoad;
                        tienHangLoad = giaNetNhapLoad * soLuongLoad;
                        Sum += tienHangLoad;
                        NoConLai = Sum;
                        threeColum = donviLoad.ToString();
                        fourColum = string.Format("{0:n0}", tienKMLoad);
                        fiveColum =  string.Format("{0:n0}", giaNetNhapLoad);
                        sixColum = string.Format("{0:n0}", tienHangLoad);
                        string[] rowAdd = { firstColum,secondColum, threeColum, fourColum, fiveColum, sixColum };
                        gridView.Add(new ListItem()
                        {
                            idHang = firstColum,
                            soLuong = secondColum,
                            kMai = fourColum,
                            giaNet = fiveColum,
                            tienHang = sixColum

                        });
                        dataGridView1.Rows.Add(rowAdd);
                        if (TangBaoLoad != 0)
                        {
                           
                            int tangbao = (soLuongLoad/TangBaoLoad);
                            if (tangbao >= 1)
                            {
                                firstColum = mHang;
                                secondColum = tangbao.ToString();
                                threeColum = donviLoad.ToString();
                                fourColum = "Tặng Bao";
                                fiveColum = string.Format("{0:n0}", giaNetNhapLoad);
                                sixColum = "0";
                               
                                //string[] rowAdd = { firstColum, secondColum, threeColum, fourColum, fiveColum, sixColum, sevenColum };
                                string[] rowAdd2 = { firstColum, secondColum, threeColum, fourColum, fiveColum, sixColum };
                                gridView.Add(new ListItem()
                                {
                                    idHang = firstColum,
                                    soLuong = secondColum,
                                    kMai = fourColum,
                                    giaNet = fiveColum,
                                    tienHang = sixColum

                                });
                                dataGridView1.Rows.Add(rowAdd2);
                            }

                        }
                        
                    }
                    txtSum.Text = string.Format("{0:n0}", Sum);
                    reader.Close();
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }

            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("HÓA ĐƠN NHẬP HÀNG", new System.Drawing.Font("Arial", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(330,10));
            e.Graphics.DrawString("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy"), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(600, 30));
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------------",
                new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(0, 50));
            e.Graphics.DrawString("Mã Hàng ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, 80));
            e.Graphics.DrawString("Số Lượng ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(150, 80));
            e.Graphics.DrawString("Khuyễn mãi ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(350, 80));
            e.Graphics.DrawString("Giá Nét Nhập ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(500, 80));
            e.Graphics.DrawString("Tiền Hàng ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(650, 80));
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------------",
               new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(0, 100));
            int yPos = 130;
            for (int i = numberOfItemsPrintedSoFar; i < gridView.Count; i++)
            {
                numberOfItemPerPage++;
                if (numberOfItemPerPage <= 20)
                {
                    numberOfItemsPrintedSoFar++;
                    if (numberOfItemsPrintedSoFar <= gridView.Count)
                    {
                        e.Graphics.DrawString(gridView[i].idHang, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, yPos));
                        e.Graphics.DrawString(gridView[i].soLuong, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(150, yPos));
                        e.Graphics.DrawString(gridView[i].kMai, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(350, yPos));
                        e.Graphics.DrawString(gridView[i].giaNet, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(500, yPos));
                        e.Graphics.DrawString(gridView[i].tienHang, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(650, yPos));
                        yPos += 30;
                    }
                    else
                    {
                        e.HasMorePages = false;
                    }
                    
                }
                else
                {
                    numberOfItemPerPage = 0;
                    e.HasMorePages = true;
                    return;
                }
            }
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------------",
              new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(0, yPos+20));
            e.Graphics.DrawString("Tổng tiền hàng :",
             new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(500, yPos + 50));
            e.Graphics.DrawString(string.Format("{0:n0}", Sum),
             new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(650, yPos + 50));

            e.Graphics.DrawString("Đã thanh toán :",
             new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(500, yPos + 80));
            e.Graphics.DrawString(string.Format("{0:n0}", daThanhToan),
             new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(650, yPos + 80));

            e.Graphics.DrawString("Còn nợ :",
             new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(500, yPos + 110));
            e.Graphics.DrawString(string.Format("{0:n0}", NoConLai),
             new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(650, yPos + 110));
            numberOfItemPerPage = 0;
            numberOfItemsPrintedSoFar = 0;
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }


    }
}
