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
using System.IO;


namespace PhanMem
{
    public partial class Payment : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");
        private string customer_name = "";
        private string id_MaDon = "";
        private int id_maNo = 0;
        private string total = "";
        private string debt = "";
        private float totalPayment = 0;
        private int numberOfItemPerPage = 0;
        private int numberOfItemsPrintedSoFar = 0;
        public class ListItem
        {
            public string stt { get; set; }
            public string date { get; set; }
            public string payment { get; set; }
            public string debt { get; set; }
           
        }
        List<ListItem> gridView = new List<ListItem>();
        public Payment(string maNo,string id_donHang,string customer,string totalSend,string debtSend)
        {

            InitializeComponent();
            customer_name = customer;
            id_MaDon = id_donHang;
            id_maNo = Int32.Parse(maNo);
            total = totalSend;
            debt = debtSend;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        public void showData()
        {
            dataGridView1.Rows.Clear();
            gridView.Clear();
            if(con.State != ConnectionState.Open)
            {
                con.Open();
            }
            string firstColumn = "";
            string secondColumn = "";
            string threeColumn = "";
            string fourColumn = "";
            SqlCommand cmdFirst = new SqlCommand("SELECT *  FROM quanlyno WHERE id_No = '" + id_maNo + "'", con);
            SqlDataReader readFirst = cmdFirst.ExecuteReader();
            
            while (readFirst.Read())
            {
                firstColumn = "1";
                secondColumn = readFirst["date"].ToString();
                threeColumn = string.Format("{0:n0}", readFirst["payment"]);
                fourColumn = string.Format("{0:n0}", readFirst["debt"]);
                lblDebt.Text = string.Format("{0:n0}", readFirst["tongno"]);
                totalPayment = float.Parse(readFirst["payment"].ToString());
                string[] row = { firstColumn, secondColumn, threeColumn, fourColumn };
                gridView.Add(new ListItem()
                {
                    stt = firstColumn,
                    date = secondColumn,
                    payment = threeColumn,
                    debt = fourColumn,
                });
                
                dataGridView1.Rows.Add(row);
             
            }
            readFirst.Close();
            // Tinh tong no
            SqlCommand cmdTo = new SqlCommand("SELECT *  FROM detailNo WHERE id_No = '"+ id_maNo +"' ", con);
            SqlDataReader readTo = cmdTo.ExecuteReader();
            int i = 2;
            while (readTo.Read())
            {
                firstColumn = i.ToString();
                secondColumn = readTo["date"].ToString();
                threeColumn = string.Format("{0:n0}", readTo["payment"]);
                fourColumn = string.Format("{0:n0}", readTo["debt"]);

                string[] row = { firstColumn, secondColumn, threeColumn, fourColumn };
                gridView.Add(new ListItem()
                {
                    stt = firstColumn,
                    date = secondColumn,
                    payment = threeColumn,
                    debt = fourColumn,
                });
                dataGridView1.Rows.Add(row);
                i++;
            }
            readTo.Close();
            if (con.State != ConnectionState.Open)
            {
                con.Close();
            }
           
        }
        private void Payment_Load(object sender, EventArgs e)
        {
            btnPayment.Visible = false;
            lblCustomer.Text = customer_name;
            lbldonHang.Text = id_MaDon;
            lblTotal.Text = total;
            lblDebt.Text = debt;
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

            cmdAdd.Parameters.AddWithValue("@id_No", id_maNo);
            cmdAdd.Parameters.AddWithValue("@id_don", id_MaDon);
            cmdAdd.Parameters.AddWithValue("@total", total);
            cmdAdd.Parameters.AddWithValue("@payment", pay);
            cmdAdd.Parameters.AddWithValue("@debt",debt );
            cmdAdd.Parameters.AddWithValue("@date", date);
            
            cmdAdd.ExecuteNonQuery();

            String querryUpdate = "UPDATE quanlyno SET tongno=@tongno,tongtra = @tongtra WHERE id_No = '" + id_maNo + "'";
            var cmdUpdate = new SqlCommand(querryUpdate, con);
            cmdUpdate.Parameters.AddWithValue("@tongno", debt);
            cmdUpdate.Parameters.AddWithValue("@tongtra", totalPayment);
            cmdUpdate.ExecuteNonQuery();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            showData();
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string nameCompany = "";
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT name FROM account", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nameCompany = dr["name"].ToString();
            }
            dr.Close();

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            e.Graphics.DrawString("CỬA HÀNG " + nameCompany.ToUpper(), new System.Drawing.Font("Arial", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(20, 10));
            e.Graphics.DrawString("PHIẾU GHI CÔNG NỢ", new System.Drawing.Font("Arial", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(330, 40));
            e.Graphics.DrawString("Khách hàng: " + customer_name, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, 80));
            e.Graphics.DrawString("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy"), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(600, 80));
            e.Graphics.DrawString("Tổng tiền hàng: " + total, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, 110));
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------------",
                new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(0, 140));
            e.Graphics.DrawString("Lần ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, 160));
            e.Graphics.DrawString("Thời gian ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(80, 160));
            e.Graphics.DrawString("Thanh toán", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(400, 160));
            e.Graphics.DrawString("Còn nợ ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(650, 160));
           
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------------",
               new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(0, 180));
            int yPos = 200;
            for (int i = numberOfItemsPrintedSoFar; i < gridView.Count; i++)
            {
                numberOfItemPerPage++;
                if (numberOfItemPerPage <= 20)
                {
                    numberOfItemsPrintedSoFar++;
                    if (numberOfItemsPrintedSoFar <= gridView.Count)
                    {
                        e.Graphics.DrawString(gridView[i].stt, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, yPos));
                        e.Graphics.DrawString(gridView[i].date, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(80, yPos));
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
