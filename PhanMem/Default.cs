﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMem
{
    public partial class Default : Form
    {
        
        public Default()
        {
            InitializeComponent();
        }
        NhapHang fm = null;
        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            if (fm == null || fm.Text == "")
            {
                fm = new NhapHang();
               
                fm.Show();
            }
            else if (CheckOpened(fm.Text))
            {                
                fm.Show();
                fm.Focus();
            } 
        }
        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;
        }

        private void quànLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BangGia bg = new BangGia();
            bg.Show();
        }

        private void btnSanLuong_Click(object sender, EventArgs e)
        {
            BaoCaoSanLuong bc = new BaoCaoSanLuong();
            bc.Show();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.Show();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {

            BanHang bh = new BanHang ();
            bh.Show();
        }

        private void btnLoiNhuan_Click(object sender, EventArgs e)
        {
            BCLoiNhuan ln = new BCLoiNhuan();
            ln.Show();
        }

        private void Default_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnQuanLyNo_Click(object sender, EventArgs e)
        {
            QuanLyNo qln = new QuanLyNo();
            qln.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhapHang frm = new NhapHang();
            frm.ShowDialog();

            //WHEN SHOWDIALOG() END
            frm.Dispose();
            this.Show();
           
        }
        private void panel1_MouseHover(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Aqua;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.SteelBlue;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.Hide();
            BanHang frm = new BanHang();
            frm.ShowDialog();

            //WHEN SHOWDIALOG() END
            frm.Dispose();
            this.Show();
           
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            this.Hide();
            BangGia frm = new BangGia();
            frm.ShowDialog();

            //WHEN SHOWDIALOG() END
            frm.Dispose();
            this.Show();
          
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLyCongNo frm = new QuanLyCongNo();
            frm.ShowDialog();

            //WHEN SHOWDIALOG() END
            frm.Dispose();
            this.Show();
           
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            this.Hide();
            KhachHang frm = new KhachHang();
            frm.ShowDialog();

            //WHEN SHOWDIALOG() END
            frm.Dispose();
            this.Show();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            this.Hide();
            BaoCao frm = new BaoCao();
            frm.ShowDialog();

            //WHEN SHOWDIALOG() END
            frm.Dispose();
            this.Show();

        }

        private void panel9_Click(object sender, EventArgs e)
        {
            this.Hide();
            SanPham frm = new SanPham();
            frm.ShowDialog();

            //WHEN SHOWDIALOG() END
            frm.Dispose();
            this.Show();
           
        }
    }
}
