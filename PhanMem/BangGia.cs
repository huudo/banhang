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

namespace PhanMem
{
    public partial class BangGia : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");
        public BangGia()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() {Filter="Exel WorkBook|*.xls || *.xlsx", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);
                    Excel.IExcelDataReader reader = Excel.ExcelReaderFactory.CreateBinaryReader(fs);
                    reader.IsFirstRowAsColumnNames = true;
                    DataSet result = reader.AsDataSet();
                    //result.Fill(test);
                    dataGridView1.DataSource = result.Tables[0];
                    reader.Close();
                }
            }
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
            String querryAdd = "INSERT INTO banggia(date,status) VALUES(@date,@status)";
            var cmdAdd = new SqlCommand(querryAdd, con);

            cmdAdd.Parameters.AddWithValue("@date", dateNow);
            cmdAdd.Parameters.AddWithValue("@status", 0);
            cmdAdd.ExecuteNonQuery();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                var stringQr = "INSERT INTO sanpham (mahang,name,donvi,khoiluong,giado,ck1,ck2,ck3,gianet,id_banggia)" +
               "VALUES(@mahang,@name,@donvi,@khoiluong,@giado,@ck1,@ck2,@ck3,@gianet,@id_banggia)";
                var cmdRun = new SqlCommand(stringQr, con);
                cmdRun.Parameters.AddWithValue("@mahang", dataGridView1.Rows[i].Cells[1].Value.ToString());
                cmdRun.Parameters.AddWithValue("@name",dataGridView1.Rows[i].Cells[2].Value.ToString());
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
            MessageBox.Show("ad");
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public class Gia
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Gia obj = comboBox1.SelectedItem as Gia;
            if (obj != null)
            {
                MessageBox.Show(obj.id.ToString());
            }
        }

        private void BangGia_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            List<Gia> list = new List<Gia>();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT id,date FROM banggia", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(new Gia() { id = Int32.Parse(dr["id"].ToString()), name = dr["date"].ToString() });
            }
            dr.Close();
            comboBox1.DataSource = list;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "name";
        }
    }
}
