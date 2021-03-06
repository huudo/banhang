﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMem
{
    public partial class ucDasboard : MetroFramework.Controls.MetroUserControl
    {
        public ucDasboard()
        {
            InitializeComponent();
        }
        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (!frmMain.Instance.MetroContainer.Controls.ContainsKey("ucNhapHang"))
            {
                ucNhapHang uc = new ucNhapHang();
                uc.Dock = DockStyle.Fill;
                frmMain.Instance.MetroContainer.Controls.Add(uc);
            }
            frmMain.Instance.MetroContainer.Controls["ucNhapHang"].BringToFront();
            frmMain.Instance.MetroBack.Visible = true;
            frmMain.Instance.Text = "";
            frmMain.Instance.Text = "      NHẬP HÀNG";
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            if (!frmMain.Instance.MetroContainer.Controls.ContainsKey("ucBanHang"))
            {
                ucBanHang uc = new ucBanHang();
                uc.Dock = DockStyle.Fill;
                frmMain.Instance.MetroContainer.Controls.Add(uc);
            }
            frmMain.Instance.MetroContainer.Controls["ucBanHang"].BringToFront();
            frmMain.Instance.MetroBack.Visible = true;
            frmMain.Instance.Text = "";
            frmMain.Instance.Text = "      BÁN HÀNG";
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            if (!frmMain.Instance.MetroContainer.Controls.ContainsKey("ucBaoCao"))
            {
                ucBaoCao uc = new ucBaoCao();
                uc.Dock = DockStyle.Fill;
                frmMain.Instance.MetroContainer.Controls.Add(uc);
            }
            frmMain.Instance.MetroContainer.Controls["ucBaoCao"].BringToFront();
            frmMain.Instance.MetroBack.Visible = true;
            frmMain.Instance.Text = "";
            frmMain.Instance.Text = "      BÁO CÁO";
        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            if (!frmMain.Instance.MetroContainer.Controls.ContainsKey("ucQuanLyNo"))
            {
                ucQuanLyNo uc = new ucQuanLyNo();
                uc.Dock = DockStyle.Fill;
                frmMain.Instance.MetroContainer.Controls.Add(uc);
            }
            frmMain.Instance.MetroContainer.Controls["ucQuanLyNo"].BringToFront();
            frmMain.Instance.MetroBack.Visible = true;
            frmMain.Instance.Text = "";
            frmMain.Instance.Text = "      QUẢN LÝ CÔNG NỢ";
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            if (!frmMain.Instance.MetroContainer.Controls.ContainsKey("ucBangGia"))
            {
                ucBangGia uc = new ucBangGia();
                uc.Dock = DockStyle.Fill;
                frmMain.Instance.MetroContainer.Controls.Add(uc);
            }
            frmMain.Instance.MetroContainer.Controls["ucBangGia"].BringToFront();
            frmMain.Instance.MetroBack.Visible = true;
            frmMain.Instance.Text = ""; 
            frmMain.Instance.Text = "      BẢNG GIÁ";
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            if (!frmMain.Instance.MetroContainer.Controls.ContainsKey("ucSanPham"))
            {
                ucSanPham uc = new ucSanPham();
                uc.Dock = DockStyle.Fill;
                frmMain.Instance.MetroContainer.Controls.Add(uc);
            }
            frmMain.Instance.MetroContainer.Controls["ucSanPham"].BringToFront();
            frmMain.Instance.MetroBack.Visible = true;
            frmMain.Instance.Text = "";
            frmMain.Instance.Text = "      SẢN PHẨM";
        }

    }
}
