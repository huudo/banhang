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

namespace PhanMem
{
    public partial class QuanLyNo : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(Localdb)\v11.0;Integrated Security=True;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "quanly.mdf");
        double SumNo = 0;
         public class kHang
        {
            public string name { get; set; }
            public string phone { get; set; }
            public string address { get; set; }
        }
        List<kHang> saveList = new List<kHang>();
        public QuanLyNo()
        {
            InitializeComponent();
        }

        void showData(List<kHang> spList)
        {
            
            SumNo = 0;
            for (int i = 0; i < spList.Count; i++)
            {
                string firstColumn = "";
                string secondColumn = "";
                string threeColumn = "";
                string fourColumn = "";

                string name = spList[i].name;
                firstColumn = spList[i].name;
                secondColumn = spList[i].phone;
                threeColumn = spList[i].address;


                // Tinh tong no
                SqlCommand cmdTo = new SqlCommand("SELECT SUM(no) as tongno FROM banhang WHERE customer= N'" + name + "' ", con);
                SqlDataReader readTo = cmdTo.ExecuteReader();

                while (readTo.Read())
                {
                    if (readTo["tongno"].ToString() != "")
                    {
                        fourColumn = string.Format("{0:n0}", readTo["tongno"]);
                        SumNo += double.Parse(readTo["tongno"].ToString());
                    }
                    else
                    {
                        fourColumn = "0";
                        SumNo += 0;
                    }

                }
                readTo.Close();
                string[] row = { firstColumn, secondColumn, threeColumn, fourColumn };
                dataGridView1.Rows.Add(row);
                lblTongNo.Text = string.Format("{0:n0}", SumNo);
            }
        }
       
        private void QuanLyNo_Load(object sender, EventArgs e)
        {
            saveList.Clear();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            dataGridView1.Rows.Clear();
            var spList = new List<kHang>();

            SqlCommand cmd = new SqlCommand("SELECT name,address,phone FROM customer", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                spList.Add(new kHang
                {
                    name = dr["name"].ToString(),
                    address = dr["address"].ToString(),
                    phone = dr["phone"].ToString()
                });
            }
            dr.Close();
            saveList = spList;
            showData(spList);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string name = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                ThanhToanNo frm = new ThanhToanNo(name);
                frm.ShowDialog();

                //WHEN SHOWDIALOG() END
                frm.Dispose();
                dataGridView1.Rows.Clear();
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                showData(saveList);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch
            {

            }
            
        }

    }
}