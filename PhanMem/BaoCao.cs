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
    public partial class BaoCao : Form
    {
        public BaoCao()
        {
            InitializeComponent();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            BaoCaoSanLuong fr = new BaoCaoSanLuong();
            fr.Show();
        }

        private void panel13_Click(object sender, EventArgs e)
        {
            BCLoiNhuan fr = new BCLoiNhuan();
            fr.Show();
        }

        private void panel14_Click(object sender, EventArgs e)
        {
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            BCTaiChinh fr = new BCTaiChinh();
            fr.Show();
        }



    }
}
