using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using Excel;
using System.Data.OleDb;

namespace PhanMem
{
    public partial class BangGia : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");
        int id_bangGiaChon = 0;
        public BangGia()
        {
            InitializeComponent();
            lblName.Visible = false;
            txtName.Visible = false;
            btnImportDB.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Exel WorkBook|*", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);
                    Excel.IExcelDataReader reader = Excel.ExcelReaderFactory.CreateOpenXmlReader(fs);
                    reader.IsFirstRowAsColumnNames = true;
                    DataSet result = reader.AsDataSet();
                    //result.Fill(test);

                    dataGridView1.DataSource = result.Tables[0];
                    reader.Close();
                }

            }
            //using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Exel WorkBook|*xlsx", ValidateNames = true })
            //{
            //    if (ofd.ShowDialog() == DialogResult.OK)
            //    {
            //        FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);
            //        IExcelDataReader excelReader2007 = ExcelReaderFactory.CreateOpenXmlReader(fs);
            //        excelReader2007.IsFirstRowAsColumnNames = true;
            //        //DataSet - The result of each spreadsheet will be created in the result.Tables
            //        DataSet result = excelReader2007.AsDataSet();
            //        dataGridView1.DataSource = result.Tables[0];

            //    }

            //}
            lblName.Visible = true;
            txtName.Visible = true;
            btnImportDB.Visible = true;
        }

        private void btnImportDB_Click(object sender, EventArgs e)
        {
            int id_bangGia = 0;
            DateTime dateNow = DateTime.Now;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand();
            String query = "select max(id) from banggia";
            cmd.Connection = con;
            cmd.CommandText = query;
            try
            {
                id_bangGia = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            catch (Exception ex)
            {
                id_bangGia = 1;
            }
            String querryAdd = "INSERT INTO banggia(name,date,status) VALUES(@name,@date,@status)";
            var cmdAdd = new SqlCommand(querryAdd, con);
            string nameBangGia = txtName.Text;
            cmdAdd.Parameters.AddWithValue("@name", nameBangGia);
            cmdAdd.Parameters.AddWithValue("@date", dateNow);
            cmdAdd.Parameters.AddWithValue("@status", 0);
            cmdAdd.ExecuteNonQuery();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                var stringQr = "INSERT INTO sanpham (mahang,name,donvi,khoiluong,giado,ck1,ck2,ck3,gianet,id_banggia)" +
               "VALUES(@mahang,@name,@donvi,@khoiluong,@giado,@ck1,@ck2,@ck3,@gianet,@id_banggia)";
                var cmdRun = new SqlCommand(stringQr, con);
                cmdRun.Parameters.AddWithValue("@mahang", dataGridView1.Rows[i].Cells[1].Value.ToString());
                cmdRun.Parameters.AddWithValue("@name", dataGridView1.Rows[i].Cells[2].Value.ToString());
                cmdRun.Parameters.AddWithValue("@donvi", dataGridView1.Rows[i].Cells[3].Value.ToString());
                cmdRun.Parameters.AddWithValue("@khoiluong", Int32.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()));
                cmdRun.Parameters.AddWithValue("@giado", float.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()));
                if (dataGridView1.Rows[i].Cells[6].Value.ToString() != "")
                {
                    cmdRun.Parameters.AddWithValue("@ck1", Int32.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString()));
                }
                else
                {
                    cmdRun.Parameters.AddWithValue("@ck1", 0);
                }
                if (dataGridView1.Rows[i].Cells[7].Value.ToString() != "")
                {
                    cmdRun.Parameters.AddWithValue("@ck2", Int32.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString()));
                }
                else
                {
                    cmdRun.Parameters.AddWithValue("@ck2", 0);
                }
                if (dataGridView1.Rows[i].Cells[8].Value.ToString() != "")
                {
                    cmdRun.Parameters.AddWithValue("@ck3", Int32.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString()));
                }
                else
                {
                    cmdRun.Parameters.AddWithValue("@ck3", 0);
                }
                cmdRun.Parameters.AddWithValue("@gianet", float.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString()));
                cmdRun.Parameters.AddWithValue("@id_banggia", id_bangGia);

                cmdRun.ExecuteNonQuery();
            }
            MessageBox.Show("Thêm thành công!")
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            lblName.Visible = false;
            txtName.Visible = false;
            btnImportDB.Visible = false;
        }
        public class Gia
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnAccept.Visible = true;
            Gia obj = comboBox1.SelectedItem as Gia;
            if (obj != null)
            {
                id_bangGiaChon = obj.id;
                showData(obj.id);

            }
        }

        private void BangGia_Load(object sender, EventArgs e)
        {
            btnAccept.Visible = false;
            comboBox1.Items.Clear();
            List<Gia> list = new List<Gia>();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT id,name FROM banggia", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(new Gia() { id = Int32.Parse(dr["id"].ToString()), name = dr["name"].ToString() });
            }
            dr.Close();
            comboBox1.DataSource = list;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "name";
        }
        public class dataGrid
        {
            public string d1 { get; set; }
            public string d2 { get; set; }
            public string d3 { get; set; }
            public string d4 { get; set; }
            public string d5 { get; set; }
            public string d6 { get; set; }
            public string d7 { get; set; }
            public string d8 { get; set; }
            public string d9 { get; set; }
            public string d10 { get; set; }
            public string d11 { get; set; }
            public string d12 { get; set; }
            public string d13 { get; set; }
        }
        void showData(int id_banggia)
        {
            dataGridView1.Columns.Clear();
            List<dataGrid> gridView = new List<dataGrid>();
            string firstColumn = "";
            string secondColumn = "";
            string threeColumn = "";
            string fourColumn = "";
            string fiveColumn = "";
            string sixColumn = "";
            string sevenColumn = "";
            string eightColumn = "";
            string nineColumn = "";
            string tenColumn = "";
            string elevenColumn = "";
            string twelveColumn = "";
            string thirteenColumn = "";
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmdQr = new SqlCommand("SELECT * FROM sanpham WHERE id_banggia= '" + id_banggia + "'  ", con);
            SqlDataReader read = cmdQr.ExecuteReader();

            while (read.Read())
            {
                firstColumn = read["mahang"].ToString();
                secondColumn = read["name"].ToString();
                threeColumn = read["donvi"].ToString();
                fourColumn = read["khoiluong"].ToString();
                fiveColumn = read["giado"].ToString();
                sixColumn = read["ck1"].ToString();
                sevenColumn = read["ck2"].ToString();
                eightColumn = read["ck3"].ToString();
                nineColumn = read["gianet"].ToString();
                tenColumn = read["giaban1"].ToString();
                elevenColumn = read["giaban2"].ToString();
                twelveColumn = read["giaban3"].ToString();
                thirteenColumn = read["giaban4"].ToString();
                
                // Add new Column for DataGridView
                gridView.Add(new dataGrid()
                {
                    d1 = firstColumn,
                    d2 = secondColumn,
                    d3 = threeColumn,
                    d4 = fourColumn,
                    d5 = fiveColumn,
                    d6 = sixColumn,
                    d7 = sevenColumn,
                    d8 = eightColumn,
                    d9 = nineColumn,
                    d10 = tenColumn,
                    d11 = elevenColumn,
                    d12 = twelveColumn,
                    d13 = thirteenColumn,
                });                                
            }
            dataGridView1.DataSource = gridView;
            // Change Header Text of DataGridView
            dataGridView1.Columns[0].HeaderText = "Mã SP";
            dataGridView1.Columns[1].HeaderText = "Tên Sản Phẩm";
            dataGridView1.Columns[2].HeaderText = "Đơn Vị";
            dataGridView1.Columns[3].HeaderText = "Khối Lượng";
            dataGridView1.Columns[4].HeaderText = "Giá Hóa Đơn";
            dataGridView1.Columns[5].HeaderText = "CK %";
            dataGridView1.Columns[6].HeaderText = "CK VNĐ/KG";
            dataGridView1.Columns[7].HeaderText = "KM VNĐ/Kg";
            dataGridView1.Columns[8].HeaderText = "Giá Net Nhập";
            dataGridView1.Columns[9].HeaderText = "Giá Bán 1";
            dataGridView1.Columns[10].HeaderText = "Giá Bán 2";
            dataGridView1.Columns[11].HeaderText = "Giá Bán 3";
            dataGridView1.Columns[12].HeaderText = "Giá Bán 4";

            read.Close();

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            btnAccept.Visible = false;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            MessageBox.Show(id_bangGiaChon.ToString(), "ID GIA");
            var query = "UPDATE banggia SET status= 0 WHERE id <> '" + id_bangGiaChon + "' ";
            var cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            var query2 = "UPDATE banggia SET status= 1 WHERE id = '" + id_bangGiaChon + "' ";
            var cmd2 = new SqlCommand(query2, con);
            cmd2.ExecuteNonQuery();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public DataTable dsSource { get; set; }
    }
}
