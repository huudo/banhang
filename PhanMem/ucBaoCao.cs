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
    public partial class ucBaoCao : UserControl
    {
        Image closeImage, closeImageAct;

        public ucBaoCao()
        {
            InitializeComponent();
        }

        private void ucBaoCao_Load(object sender, EventArgs e)
        {

        }
        public void themPage(Form frm)
        {
            
            //BaoCaoSanLuong frm = new BaoCaoSanLuong();
            int index = kiemtratontai(tabcontrol1, frm);
            if (index >= 0)
            {
                tabcontrol1.TabIndex = index;
            }
            else
            {
                TabPage tabPage = new TabPage();
                tabPage.BorderStyle = BorderStyle.Fixed3D;
                tabcontrol1.TabPages.Add(tabPage);
                frm.TopLevel = false;
                frm.Parent = tabPage;
                frm.Show();
                frm.Dock = DockStyle.Fill;
            }           
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            BaoCaoSanLuong frm = new BaoCaoSanLuong();
            themPage(frm);
        }
        public int kiemtratontai(TabControl tabform, Form frm)
        {
            for (int i = 0; i < tabform.TabCount; i++)
            {
                if (tabform.TabPages[i].Text.Trim() == frm.Text.Trim())
                {
                    return i;
                }              
            }
            return -1;
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            BCLoiNhuan frm = new BCLoiNhuan();
            themPage(frm);
        }
    }
}
