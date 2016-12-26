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

namespace PhanMem
{
    public partial class DetailTraNo : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");
        private int id_No = 0;
        private int id_maDon = 0;
        private double totalPayment = 0;
        private int numberOfItemPerPage = 0;
        private int numberOfItemsPrintedSoFar = 0;
        public class ListItem
        {
            public string date { get; set; }
            public string payment { get; set; }
            public string debt { get; set; }

        }
        List<ListItem> gridView = new List<ListItem>();
        public DetailTraNo(string id_maNo,string id_maHang)
        {
            InitializeComponent();
            id_No = Int32.Parse(id_maNo);
            id_maDon = Int32.Parse(id_maHang);
        }
        public void showData()
        {
            dataGridView1.Rows.Clear();
            gridView.Clear();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            string firstColumn = "";
            string secondColumn = "";
            string threeColumn = "";
            SqlCommand cmdFirst = new SqlCommand("SELECT *  FROM quanlyno WHERE id_No = '" + id_No + "'", con);
            SqlDataReader readFirst = cmdFirst.ExecuteReader();

            while (readFirst.Read())
            {
                firstColumn = readFirst["date"].ToString();
                secondColumn = string.Format("{0:n0}", readFirst["payment"]);
                threeColumn = string.Format("{0:n0}", readFirst["debt"]);
                lblDebt.Text = string.Format("{0:n0}", readFirst["tongno"]);
                lblTotal.Text = string.Format("{0:n0}", readFirst["total"]);
                totalPayment = float.Parse(readFirst["payment"].ToString());
                string[] row = { firstColumn, secondColumn, threeColumn };
                gridView.Add(new ListItem()
                {
                    date = firstColumn,
                    payment = secondColumn,
                    debt = threeColumn,
                });

                dataGridView1.Rows.Add(row);
            }
            readFirst.Close();
            // Tinh tong no
            SqlCommand cmdTo = new SqlCommand("SELECT *  FROM detailNo WHERE id_No = '" + id_No + "' ", con);
            SqlDataReader readTo = cmdTo.ExecuteReader();

            while (readTo.Read())
            {
                firstColumn = readTo["date"].ToString();
                secondColumn = string.Format("{0:n0}", readTo["payment"]);
                threeColumn = string.Format("{0:n0}", readTo["debt"]);

                string[] row = { firstColumn, secondColumn, threeColumn };
                gridView.Add(new ListItem()
                {
                    date = firstColumn,
                    payment = secondColumn,
                    debt = threeColumn,
                });
                dataGridView1.Rows.Add(row);
            }
            readTo.Close();
            if (con.State != ConnectionState.Open)
            {
                con.Close();
            }
        }

        private void DetailTraNo_Load(object sender, EventArgs e)
        {
            showData();
        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            btnPayment.Visible = true;
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            float total = float.Parse(decimal.Parse(lblDebt.Text, NumberStyles.Currency).ToString());
            float pay = float.Parse(txtPayment.Text);
            totalPayment += pay;
            float debt = total - pay;
            DateTime date = DateTime.Now;
            String querryAdd = "INSERT INTO detailNo(id_No,id_don,total,payment,debt,date) VALUES(@id_No,@id_don,@total,@payment,@debt,@date)";
            var cmdAdd = new SqlCommand(querryAdd, con);

            cmdAdd.Parameters.AddWithValue("@id_No", id_No);
            cmdAdd.Parameters.AddWithValue("@id_don", id_maDon);
            cmdAdd.Parameters.AddWithValue("@total", total);
            cmdAdd.Parameters.AddWithValue("@payment", pay);
            cmdAdd.Parameters.AddWithValue("@debt", debt);
            cmdAdd.Parameters.AddWithValue("@date", date);

            cmdAdd.ExecuteNonQuery();

            String querryUpdate = "UPDATE quanlyno SET tongno=@tongno,tongtra = @tongtra WHERE id_No = '" + id_No + "'";
            var cmdUpdate = new SqlCommand(querryUpdate, con);
            cmdUpdate.Parameters.AddWithValue("@tongno", debt);
            cmdUpdate.Parameters.AddWithValue("@tongtra", totalPayment);
            cmdUpdate.ExecuteNonQuery();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            btnPayment.Visible = false;
            txtPayment.Text = "";
            showData();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("PHIẾU THANH TOÁN NHẬP HÀNG", new System.Drawing.Font("Arial", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(330, 10));
            e.Graphics.DrawString("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy"), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(600, 30));
            e.Graphics.DrawString("Tổng tiền hàng: " + totalPayment, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, 60));
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------------",
                new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(0, 80));
            e.Graphics.DrawString("Thời gian ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, 110));
            e.Graphics.DrawString("Thanh toán", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(400, 110));
            e.Graphics.DrawString("Còn nợ ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(650, 110));

            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------------",
               new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(0, 130));
            int yPos = 160;
            for (int i = numberOfItemsPrintedSoFar; i < gridView.Count; i++)
            {
                numberOfItemPerPage++;
                if (numberOfItemPerPage <= 20)
                {
                    numberOfItemsPrintedSoFar++;
                    if (numberOfItemsPrintedSoFar <= gridView.Count)
                    {
                        e.Graphics.DrawString(gridView[i].date, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, yPos));
                        e.Graphics.DrawString(gridView[i].payment, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(400, yPos));
                        e.Graphics.DrawString(gridView[i].debt, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(650, yPos));

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
              new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(0, yPos + 20));

            numberOfItemPerPage = 0;
            numberOfItemsPrintedSoFar = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
