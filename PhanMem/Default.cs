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
    }
}
