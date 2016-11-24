using System;
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
            SanPham sp = new SanPham();
            sp.Show();
        }

        private void btnSanLuong_Click(object sender, EventArgs e)
        {
            BaoCao bc = new BaoCao();
            bc.Show();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.Show();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            BanHang bh = new BanHang();
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

    
    }
}
