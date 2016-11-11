﻿using System;
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
    public partial class NhapHang : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=TUAN-PC\SQLEXPRESS;Initial Catalog=banhang;Integrated Security=True");
        Boolean check = false;
        public NhapHang()
        {
            InitializeComponent();
        }
        void ClearTextBox()
        {
            txtCK1.Clear();
            txtCK2.Clear();
            txtCK3.Clear();
            txtCount.Clear();
            txtGiaBao.Clear();
            txtGiaKg.Clear();
            txtGiaNetBao.Clear();
            txtGiaNetKg.Clear();
            txtName.Clear();
            txtTotal.Clear();
            check = false;
        }
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
            if (!string.IsNullOrEmpty(txtCount.Text))
            {
                soLuong = Int32.Parse(txtCount.Text);
            }
            int weight = Int32.Parse(txtKhoiLuong.Text);
            double giaNetKg = 0;
            double giaNetBao = 0;
            double giaKg = double.Parse(decimal.Parse(txtGiaKg.Text, NumberStyles.Currency).ToString());
            double giaBao = double.Parse(decimal.Parse(txtGiaBao.Text, NumberStyles.Currency).ToString());

            giaNetKg = giaKg * (100 - ck1) / 100 - ck2 - ck3;
            giaNetBao = giaNetKg * weight;
            txtGiaNetKg.Text = string.Format("{0:n0}", giaNetKg);
            txtGiaNetBao.Text = string.Format("{0:n0}", giaNetBao);
            double price = double.Parse(decimal.Parse(txtGiaNetBao.Text, NumberStyles.Currency).ToString());
            txtTotal.Text = string.Format("{0:n0}", price * soLuong);
        }

        private void NhapHang_Load(object sender, EventArgs e)
        {
            try
            {
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

        private void txtMa_TextChanged(object sender, EventArgs e)
        {
            ClearTextBox();

        }

        private void txtCount_TextChanged(object sender, EventArgs e)
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
        private void txtCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumber(e);

        }

        private void txtCK1_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumber(e);
        }

        private void txtCK2_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumber(e);

        }

        private void txtCK3_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumber(e);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
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
                if (!string.IsNullOrEmpty(txtCount.Text))
                {
                    soLuong = Int32.Parse(txtCount.Text);
                }
                int weight = Int32.Parse(txtKhoiLuong.Text);
                double total = double.Parse(decimal.Parse(txtTotal.Text, NumberStyles.Currency).ToString());
                double price = double.Parse(decimal.Parse(txtGiaBao.Text, NumberStyles.Currency).ToString());
                double khuyenmai = price * soLuong - total;
                string firstColum = txtMa.Text;
                string secondColum = txtName.Text;
                string threeColum = txtCount.Text;
                string fourColum = txtGiaBao.Text;
                string fiveColum = khuyenmai.ToString();
                string sixColum = txtGiaNetBao.Text;
                string sevenColum = txtTotal.Text;
                string[] row = { firstColum, secondColum, threeColum, fourColum, fiveColum, sixColum, sevenColum };
                dataGridView1.Rows.Add(row);
                int tangbao = (soLuong / 10);
                if (tangbao >= 1)
                {
                    firstColum = txtMa.Text;
                    secondColum = txtName.Text;
                    threeColum = tangbao.ToString();
                    fourColum = txtGiaBao.Text;
                    fiveColum = "Tặng Bao";
                    sixColum = txtGiaNetBao.Text;
                    sevenColum = "0";
                    string[] rowAdd = { firstColum, secondColum, threeColum, fourColum, fiveColum, sixColum, sevenColum };
                    dataGridView1.Rows.Add(rowAdd);
                }

            }
            catch
            {

            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

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
                    txtCK1.Text = dr["ck1"].ToString();
                    txtCK2.Text = dr["ck2"].ToString();
                    txtCK3.Text = dr["ck3"].ToString();
                    txtKhoiLuong.Text = dr["khoiluong"].ToString();
                    txtGiaKg.Text = string.Format("{0:n0}", dr["giadokg"]);
                    txtGiaBao.Text = string.Format("{0:n0}", dr["giadobao"]);
                    txtGiaNetKg.Text = string.Format("{0:n0}", dr["gianetkg"]);
                    txtGiaNetBao.Text = string.Format("{0:n0}", dr["gianetbao"]);
                }
                check = true;
                dr.Close();
                con.Close();

            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
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
            objexcelapp.Cells[maxRow + 1, maxColum] = d2.ToString();


            string root = @"D:\QuanLyBanHang\NhapHang";



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


    }
}