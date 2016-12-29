namespace PhanMem
{
    partial class BangGia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BangGia));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mahang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.donvi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.khoiluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ck1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ck2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ck3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gianet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaban1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaban2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaban3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaban4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblBangGia = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImportDB = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(935, 595);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 241);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(929, 351);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mahang,
            this.name,
            this.donvi,
            this.khoiluong,
            this.giado,
            this.ck1,
            this.ck2,
            this.ck3,
            this.gianet,
            this.giaban1,
            this.giaban2,
            this.giaban3,
            this.giaban4});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(929, 351);
            this.dataGridView1.TabIndex = 0;
            // 
            // mahang
            // 
            this.mahang.HeaderText = "Mã Hàng";
            this.mahang.Name = "mahang";
            this.mahang.Width = 76;
            // 
            // name
            // 
            this.name.HeaderText = "Tên Sản Phẩm";
            this.name.Name = "name";
            this.name.Width = 103;
            // 
            // donvi
            // 
            this.donvi.HeaderText = "Đơn Vị";
            this.donvi.Name = "donvi";
            this.donvi.Width = 64;
            // 
            // khoiluong
            // 
            this.khoiluong.HeaderText = "Khối Lượng";
            this.khoiluong.Name = "khoiluong";
            this.khoiluong.Width = 86;
            // 
            // giado
            // 
            this.giado.HeaderText = "Giá Hóa Đơn";
            this.giado.Name = "giado";
            this.giado.Width = 94;
            // 
            // ck1
            // 
            this.ck1.HeaderText = "CK %";
            this.ck1.Name = "ck1";
            this.ck1.Width = 57;
            // 
            // ck2
            // 
            this.ck2.HeaderText = "CK VNĐ/KG";
            this.ck2.Name = "ck2";
            this.ck2.Width = 92;
            // 
            // ck3
            // 
            this.ck3.HeaderText = "KM VNĐ/KG";
            this.ck3.Name = "ck3";
            this.ck3.Width = 94;
            // 
            // gianet
            // 
            this.gianet.HeaderText = "Giá Net Nhập";
            this.gianet.Name = "gianet";
            this.gianet.Width = 97;
            // 
            // giaban1
            // 
            this.giaban1.HeaderText = "Giá Bán 1";
            this.giaban1.Name = "giaban1";
            this.giaban1.Width = 79;
            // 
            // giaban2
            // 
            this.giaban2.HeaderText = "Giá Bán 2";
            this.giaban2.Name = "giaban2";
            this.giaban2.Width = 79;
            // 
            // giaban3
            // 
            this.giaban3.HeaderText = "Giá Bán 3";
            this.giaban3.Name = "giaban3";
            this.giaban3.Width = 79;
            // 
            // giaban4
            // 
            this.giaban4.HeaderText = "Giá Bán 4";
            this.giaban4.Name = "giaban4";
            this.giaban4.Width = 79;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.lblBangGia);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.btnAccept);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnImportDB);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(929, 232);
            this.panel1.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(291, 126);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(111, 31);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Xóa Bảng";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblBangGia
            // 
            this.lblBangGia.AutoSize = true;
            this.lblBangGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblBangGia.ForeColor = System.Drawing.Color.Coral;
            this.lblBangGia.Location = new System.Drawing.Point(197, 27);
            this.lblBangGia.Name = "lblBangGia";
            this.lblBangGia.Size = new System.Drawing.Size(165, 18);
            this.lblBangGia.TabIndex = 8;
            this.lblBangGia.Text = "Bảng giá đang sử dụng :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Coral;
            this.label2.Location = new System.Drawing.Point(14, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Bảng giá đang sử dụng :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblName.Location = new System.Drawing.Point(14, 193);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(106, 18);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Tên Bảng Giá :";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtName.Location = new System.Drawing.Point(138, 191);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(264, 24);
            this.txtName.TabIndex = 5;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(138, 126);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(111, 31);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Sử Dụng";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(138, 80);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(264, 26);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(14, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn Bảng Giá :";
            // 
            // btnImportDB
            // 
            this.btnImportDB.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnImportDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnImportDB.ForeColor = System.Drawing.Color.White;
            this.btnImportDB.Location = new System.Drawing.Point(795, 173);
            this.btnImportDB.Name = "btnImportDB";
            this.btnImportDB.Size = new System.Drawing.Size(114, 38);
            this.btnImportDB.TabIndex = 1;
            this.btnImportDB.Text = "Thêm Mới";
            this.btnImportDB.UseVisualStyleBackColor = false;
            this.btnImportDB.Click += new System.EventHandler(this.btnImportDB_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(795, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Nhập từ Exel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BangGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 595);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BangGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BangGia";
            this.Load += new System.EventHandler(this.BangGia_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnImportDB;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mahang;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn donvi;
        private System.Windows.Forms.DataGridViewTextBoxColumn khoiluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn giado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ck1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ck2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ck3;
        private System.Windows.Forms.DataGridViewTextBoxColumn gianet;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaban1;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaban2;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaban3;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaban4;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblBangGia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDelete;
    }
}