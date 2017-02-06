using System;
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
        }
    }
}
