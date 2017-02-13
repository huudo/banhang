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

        

        private void tabcontrol1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Rectangle rect = tabcontrol1.GetTabRect(e.Index);
            Rectangle imageRec = new Rectangle(rect.Right - closeImage.Width, rect.Top + (closeImage.Height - closeImage.Width / 2),
                closeImage.Width, closeImage.Height);
            rect.Size = new Size(rect.Width + 24, 38);
            Font f;
            Brush br = Brushes.Black;
            StringFormat strF = new StringFormat(StringFormat.GenericDefault);
            if (tabcontrol1.SelectedTab == tabcontrol1.TabPages[e.Index])
            {
                e.Graphics.DrawImage(closeImageAct, imageRec);
                f = new Font("Arial", 10, FontStyle.Bold);
                e.Graphics.DrawString(tabcontrol1.TabPages[e.Index].Text, f, br, rect, strF);
            }
            else
            {
                e.Graphics.DrawImage(closeImage, imageRec);
                f = new Font("Arial", 10, FontStyle.Strikeout);
                e.Graphics.DrawString(tabcontrol1.TabPages[e.Index].Text, f, br, rect, strF);
            }
        }
        private void tabcontrol1_MouseClick(object sender, MouseEventArgs e)
        {
            //SU kien click dong tab
            for (int i = 0; i < tabcontrol1.TabCount; i++)
            {
                Rectangle rect = tabcontrol1.GetTabRect(i);
                Rectangle imageRec = new Rectangle(rect.Right - closeImage.Width, rect.Top + (closeImage.Height - closeImage.Width / 2),
                closeImage.Width, closeImage.Height);
                if (imageRec.Contains(e.Location))
                    tabcontrol1.TabPages.Remove(tabcontrol1.SelectedTab);
            }
        }

        
    }
}
