namespace PhanMem
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mPanel = new MetroFramework.Controls.MetroPanel();
            this.mlBack = new MetroFramework.Controls.MetroLink();
            this.SuspendLayout();
            // 
            // mPanel
            // 
            this.mPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mPanel.HorizontalScrollbarBarColor = true;
            this.mPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.mPanel.HorizontalScrollbarSize = 10;
            this.mPanel.Location = new System.Drawing.Point(20, 60);
            this.mPanel.Name = "mPanel";
            this.mPanel.Size = new System.Drawing.Size(1169, 635);
            this.mPanel.TabIndex = 0;
            this.mPanel.VerticalScrollbarBarColor = true;
            this.mPanel.VerticalScrollbarHighlightOnWheel = false;
            this.mPanel.VerticalScrollbarSize = 10;
            // 
            // mlBack
            // 
            this.mlBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mlBack.BackgroundImage")));
            this.mlBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mlBack.Location = new System.Drawing.Point(21, 20);
            this.mlBack.Name = "mlBack";
            this.mlBack.Size = new System.Drawing.Size(40, 34);
            this.mlBack.TabIndex = 1;
            this.mlBack.UseSelectable = true;
            this.mlBack.Click += new System.EventHandler(this.mlBack_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 715);
            this.Controls.Add(this.mlBack);
            this.Controls.Add(this.mPanel);
            this.Name = "frmMain";
            this.Text = "      PHẦN MỀM QUẢN LÝ BÁN HÀNG";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel mPanel;
        private MetroFramework.Controls.MetroLink mlBack;


    }
}