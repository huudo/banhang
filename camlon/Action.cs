using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace camlon
{
    public partial class Action : Form
    {
        public Action(string status)
        {
            InitializeComponent();
            label2.Text = status;
        }

        private void Action_Load(object sender, EventArgs e)
        {

        }

    }
}
