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
    public partial class ThanhToanNo : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");
        string customerName = "";
        int idCustomer = 0;
        private int numberOfItemPerPage = 0;
        private int numberOfItemsPrintedSoFar = 0;
        double sumNo = 0;
        double paymented = 0;
        double conLai = 0;
        public ThanhToanNo(string name,int customerId)
        {
            InitializeComponent();
            customerName = name;
            idCustomer = customerId;
        }
        public class ListItem
        {
            public string maDon { get; set; }
            public string date { get; set; }
            public string totalHang { get; set; }
            public string payment { get; set; }
            public string debt { get; set; }

        }
        List<ListItem> gridView = new List<ListItem>();
        private void ThanhToanNo_Load(object sender, EventArgs e)
        {
            lblKhachHang.Text = customerName;
            ShowData();
        }
        void ShowData()
        {
            gridView.Clear();
            dataGridView1.Rows.Clear();
            sumNo = 0;
            paymented = 0;
            conLai = 0;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            
            string firstColumn = "";
            string secondColumn = "";
            string threeColumn = "";
            string fourColumn = "";
            string fiveColum = "";
            string sixColum = "";
            // Tinh tong no
            SqlCommand cmdTo = new SqlCommand("SELECT *  FROM quanlyno WHERE type = 2 AND customerId= '" + idCustomer + "' and tongno > 0 ", con);
            SqlDataReader readTo = cmdTo.ExecuteReader();

            while (readTo.Read())
            {
                firstColumn = readTo["id_No"].ToString();
                secondColumn = readTo["id_don"].ToString();
                DateTime dday = DateTime.Parse(readTo["date"].ToString());
                threeColumn = dday.ToString("dd/MM/yyyy");
                fourColumn = string.Format("{0:n0}", readTo["total"]);
                fiveColum = string.Format("{0:n0}", readTo["tongtra"]);
                sixColum = string.Format("{0:n0}", readTo["tongno"]);
                sumNo += double.Parse(readTo["total"].ToString());
                paymented += double.Parse(readTo["tongtra"].ToString());
                conLai += double.Parse(readTo["tongno"].ToString());

                string[] row = { firstColumn, secondColumn, threeColumn, fourColumn, fiveColum,sixColum };
                gridView.Add(new ListItem()
                {
                    maDon = "MH"+secondColumn,
                    date = threeColumn,
                    totalHang = fourColumn,
                    payment = fiveColum,
                    debt = sixColum
                });
                dataGridView1.Rows.Add(row);
            }
            readTo.Close();
            lblSumNo.Text = string.Format("{0:n0}", sumNo);
            lblDaTra.Text = string.Format("{0:n0}", paymented);
            lblConNo.Text = string.Format("{0:n0}", conLai);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                
                string id_maNo = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string id_donHang = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string total = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string debt = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
               
                this.Hide();
                Payment frm = new Payment(id_maNo, id_donHang, customerName, total, debt);
                frm.ShowDialog();

                //WHEN SHOWDIALOG() END
                frm.Dispose();
                this.Show();

                dataGridView1.Rows.Clear();
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                ShowData();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch
            {

            }
        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
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
            e.Graphics.DrawString("DANH SÁCH ĐƠN HÀNG NỢ", new System.Drawing.Font("Arial", 15, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(330,40));
            e.Graphics.DrawString("Khách hàng: " + customerName, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, 80));
            e.Graphics.DrawString("Tính đến ngày: " + DateTime.Now.ToString("dd/MM/yyyy"), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(600, 80));
            
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------------",
                new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(0, 120));
            e.Graphics.DrawString("Mã đơn ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, 140));
            e.Graphics.DrawString("Ngày mua ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(110, 140));
            e.Graphics.DrawString("Tiền hàng ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(250, 140));
            e.Graphics.DrawString("Thanh toán", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(480, 140));
            e.Graphics.DrawString("Còn nợ ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(700, 140));

            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------------",
               new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(0, 160));
            int yPos = 190;
            for (int i = numberOfItemsPrintedSoFar; i < gridView.Count; i++)
            {
                numberOfItemPerPage++;
                if (numberOfItemPerPage <= 20)
                {
                    numberOfItemsPrintedSoFar++;
                    if (numberOfItemsPrintedSoFar <= gridView.Count)
                    {
                        e.Graphics.DrawString(gridView[i].maDon, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(20, yPos));
                        e.Graphics.DrawString(gridView[i].date, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(110, yPos));
                        e.Graphics.DrawString(gridView[i].totalHang, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(250, yPos));
                        e.Graphics.DrawString(gridView[i].payment, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(480, yPos));
                        e.Graphics.DrawString(gridView[i].debt, new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(700, yPos));
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
            yPos = yPos + 50;
            e.Graphics.DrawString("Tổng tiền hàng: ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(550, yPos));
            e.Graphics.DrawString("Đã thanh toán: ", new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(550, yPos+30));
            e.Graphics.DrawString("Tổng nợ: " , new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(550, yPos+60));

            e.Graphics.DrawString(string.Format("{0:n0}", sumNo), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(700, yPos));
            e.Graphics.DrawString(string.Format("{0:n0}", paymented), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(700, yPos + 30));
            e.Graphics.DrawString( string.Format("{0:n0}", conLai), new System.Drawing.Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(700, yPos + 60));
            
            numberOfItemPerPage = 0;
            numberOfItemsPrintedSoFar = 0;
        }
       
    }
}
