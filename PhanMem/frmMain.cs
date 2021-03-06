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
    public partial class frmMain : MetroFramework.Forms.MetroForm
    {
        static frmMain _instance;
        public static frmMain Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmMain();
                return _instance;
            }
        }
        public MetroFramework.Controls.MetroPanel MetroContainer
        {
            get { return mPanel; }
            set { mPanel = value; }

        }
        public MetroFramework.Controls.MetroLink MetroBack
        {
            get { return mlBack; }
            set { mlBack = value; }
        }

        public frmMain()
        {
            InitializeComponent();
            UseWaitCursor = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(Login.MyStaticValues.account_id.ToString());
            mlBack.Visible = false;
            _instance = this;
            ucDasboard uc = new ucDasboard();
            uc.Dock = DockStyle.Fill;
            mPanel.Controls.Add(uc);
        }

        private void mlBack_Click(object sender, EventArgs e)
        {
            frmMain.Instance.Text = "";
            frmMain.Instance.Text = "PHẦN MỀM QUẢN LÝ BÁN HÀNG";
            mPanel.Controls["ucDasboard"].BringToFront();
            mlBack.Visible = false;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }


    }
}
