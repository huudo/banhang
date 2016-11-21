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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            //label1.BackColor = System.Drawing.Color.Transparent;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Default form = new Default();
            form.Show();
            
        }


        
    }
}
