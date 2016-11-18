namespace PhanMem
{
    partial class NhapHang
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mahang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.donvi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.khuyenmai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gianetnhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtGiaNetBao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGiaNetKg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCK3 = new System.Windows.Forms.TextBox();
            this.txtCK2 = new System.Windows.Forms.TextBox();
            this.txtCK1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtGiaBao = new System.Windows.Forms.TextBox();
            this.txtGiaKg = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKhoiLuong = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.txtPay = new System.Windows.Forms.TextBox();
            this.txtSum = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nhậpHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bánHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoCuốiNgàyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoDoanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoSảnLượngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoLợiNhuậnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quànLýTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNợToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mahang,
            this.name,
            this.soluong,
            this.donvi,
            this.khuyenmai,
            this.gianetnhap,
            this.total});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(50, 5, 5, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1154, 282);
            this.dataGridView1.TabIndex = 86;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // mahang
            // 
            this.mahang.HeaderText = "Mã SP";
            this.mahang.Name = "mahang";
            // 
            // name
            // 
            this.name.HeaderText = "Tên SP";
            this.name.Name = "name";
            this.name.Width = 400;
            // 
            // soluong
            // 
            this.soluong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.soluong.HeaderText = "Số Lượng";
            this.soluong.Name = "soluong";
            // 
            // donvi
            // 
            this.donvi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.donvi.HeaderText = "Đơn Vị";
            this.donvi.Name = "donvi";
            // 
            // khuyenmai
            // 
            this.khuyenmai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.khuyenmai.HeaderText = "Khuyến mãi";
            this.khuyenmai.Name = "khuyenmai";
            // 
            // gianetnhap
            // 
            this.gianetnhap.HeaderText = "Giá Net Nhập";
            this.gianetnhap.Name = "gianetnhap";
            this.gianetnhap.Width = 150;
            // 
            // total
            // 
            this.total.HeaderText = "Tiền Hàng ";
            this.total.Name = "total";
            this.total.Width = 140;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 291);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1154, 282);
            this.panel3.TabIndex = 1;
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(941, 67);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(106, 36);
            this.btnOrder.TabIndex = 151;
            this.btnOrder.Text = "NHẬP HÀNG";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(366, 181);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(106, 36);
            this.btnAdd.TabIndex = 150;
            this.btnAdd.Text = "THÊM HÀNG";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(165, 117);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(302, 26);
            this.txtTotal.TabIndex = 149;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.txtTotal);
            this.panel2.Controls.Add(this.txtGiaNetBao);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtGiaNetKg);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtCK3);
            this.panel2.Controls.Add(this.txtCK2);
            this.panel2.Controls.Add(this.txtCK1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(580, 3);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel2.Size = new System.Drawing.Size(571, 240);
            this.panel2.TabIndex = 1;
            // 
            // txtGiaNetBao
            // 
            this.txtGiaNetBao.Enabled = false;
            this.txtGiaNetBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaNetBao.Location = new System.Drawing.Point(333, 71);
            this.txtGiaNetBao.Name = "txtGiaNetBao";
            this.txtGiaNetBao.Size = new System.Drawing.Size(132, 26);
            this.txtGiaNetBao.TabIndex = 148;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(45, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 20);
            this.label7.TabIndex = 147;
            this.label7.Text = "Tiền Hàng :";
            // 
            // txtGiaNetKg
            // 
            this.txtGiaNetKg.Enabled = false;
            this.txtGiaNetKg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaNetKg.Location = new System.Drawing.Point(165, 73);
            this.txtGiaNetKg.Name = "txtGiaNetKg";
            this.txtGiaNetKg.Size = new System.Drawing.Size(128, 26);
            this.txtGiaNetKg.TabIndex = 146;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(45, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 20);
            this.label5.TabIndex = 145;
            this.label5.Text = "Giá Net Nhập :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(373, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 16);
            this.label13.TabIndex = 144;
            this.label13.Text = "Khuyến mãi/KG";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(268, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 16);
            this.label12.TabIndex = 143;
            this.label12.Text = "VNĐ/KG";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(159, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 20);
            this.label11.TabIndex = 142;
            this.label11.Text = "%";
            // 
            // txtCK3
            // 
            this.txtCK3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCK3.Location = new System.Drawing.Point(376, 32);
            this.txtCK3.Name = "txtCK3";
            this.txtCK3.Size = new System.Drawing.Size(89, 26);
            this.txtCK3.TabIndex = 141;
            this.txtCK3.TextChanged += new System.EventHandler(this.txtCK3_TextChanged);
            this.txtCK3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCK3_KeyPress);
            // 
            // txtCK2
            // 
            this.txtCK2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCK2.Location = new System.Drawing.Point(269, 32);
            this.txtCK2.Name = "txtCK2";
            this.txtCK2.Size = new System.Drawing.Size(89, 26);
            this.txtCK2.TabIndex = 140;
            this.txtCK2.TextChanged += new System.EventHandler(this.txtCK2_TextChanged);
            this.txtCK2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCK2_KeyPress);
            // 
            // txtCK1
            // 
            this.txtCK1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCK1.Location = new System.Drawing.Point(161, 32);
            this.txtCK1.Name = "txtCK1";
            this.txtCK1.Size = new System.Drawing.Size(89, 26);
            this.txtCK1.TabIndex = 139;
            this.txtCK1.TextChanged += new System.EventHandler(this.txtCK1_TextChanged);
            this.txtCK1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCK1_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(45, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 20);
            this.label6.TabIndex = 138;
            this.label6.Text = "Chiết Khấu :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtGiaBao);
            this.panel1.Controls.Add(this.txtGiaKg);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtKhoiLuong);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtCount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtMa);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(571, 240);
            this.panel1.TabIndex = 0;
            // 
            // txtGiaBao
            // 
            this.txtGiaBao.Enabled = false;
            this.txtGiaBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaBao.Location = new System.Drawing.Point(357, 192);
            this.txtGiaBao.Name = "txtGiaBao";
            this.txtGiaBao.Size = new System.Drawing.Size(134, 26);
            this.txtGiaBao.TabIndex = 116;
            // 
            // txtGiaKg
            // 
            this.txtGiaKg.Enabled = false;
            this.txtGiaKg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaKg.Location = new System.Drawing.Point(183, 192);
            this.txtGiaKg.Name = "txtGiaKg";
            this.txtGiaKg.Size = new System.Drawing.Size(132, 26);
            this.txtGiaKg.TabIndex = 115;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 20);
            this.label4.TabIndex = 114;
            this.label4.Text = "Giá HĐĐ KG-BAO :";
            // 
            // txtKhoiLuong
            // 
            this.txtKhoiLuong.Enabled = false;
            this.txtKhoiLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhoiLuong.Location = new System.Drawing.Point(183, 149);
            this.txtKhoiLuong.Name = "txtKhoiLuong";
            this.txtKhoiLuong.Size = new System.Drawing.Size(308, 26);
            this.txtKhoiLuong.TabIndex = 113;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 20);
            this.label8.TabIndex = 112;
            this.label8.Text = "Khối lượng bao :";
            // 
            // txtCount
            // 
            this.txtCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCount.Location = new System.Drawing.Point(184, 116);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(308, 26);
            this.txtCount.TabIndex = 9;
            this.txtCount.TextChanged += new System.EventHandler(this.txtCount_TextChanged);
            this.txtCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCount_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Số Lượng :";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(184, 76);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(308, 26);
            this.txtName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tên Hàng :";
            // 
            // txtMa
            // 
            this.txtMa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtMa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa.Location = new System.Drawing.Point(184, 38);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(308, 26);
            this.txtMa.TabIndex = 3;
            this.txtMa.TextChanged += new System.EventHandler(this.txtMa_TextChanged);
            this.txtMa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMa_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã Hàng :";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1160, 721);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 39);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 282F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1154, 246);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtNo);
            this.panel4.Controls.Add(this.txtPay);
            this.panel4.Controls.Add(this.txtSum);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.btnOrder);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 579);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1154, 139);
            this.panel4.TabIndex = 2;
            // 
            // txtNo
            // 
            this.txtNo.Enabled = false;
            this.txtNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNo.Location = new System.Drawing.Point(785, 79);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(132, 26);
            this.txtNo.TabIndex = 168;
            // 
            // txtPay
            // 
            this.txtPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPay.Location = new System.Drawing.Point(785, 42);
            this.txtPay.Name = "txtPay";
            this.txtPay.Size = new System.Drawing.Size(132, 26);
            this.txtPay.TabIndex = 167;
            this.txtPay.TextChanged += new System.EventHandler(this.txtPay_TextChanged);
            // 
            // txtSum
            // 
            this.txtSum.Enabled = false;
            this.txtSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSum.Location = new System.Drawing.Point(785, 8);
            this.txtSum.Name = "txtSum";
            this.txtSum.Size = new System.Drawing.Size(132, 26);
            this.txtSum.TabIndex = 163;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(618, 80);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 20);
            this.label17.TabIndex = 166;
            this.label17.Text = "Tiền Nợ :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(618, 45);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(102, 20);
            this.label16.TabIndex = 165;
            this.label16.Text = "Thanh Toán :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(618, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(134, 20);
            this.label15.TabIndex = 164;
            this.label15.Text = "Tổng Tiền Hàng : ";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.menuStrip1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1154, 30);
            this.panel5.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhậpHàngToolStripMenuItem,
            this.bánHàngToolStripMenuItem,
            this.báoCáoToolStripMenuItem,
            this.quảnLýKháchHàngToolStripMenuItem,
            this.quànLýTàiKhoảnToolStripMenuItem,
            this.quảnLýNợToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1154, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nhậpHàngToolStripMenuItem
            // 
            this.nhậpHàngToolStripMenuItem.Name = "nhậpHàngToolStripMenuItem";
            this.nhậpHàngToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.nhậpHàngToolStripMenuItem.Text = "Nhập hàng";
            // 
            // bánHàngToolStripMenuItem
            // 
            this.bánHàngToolStripMenuItem.Name = "bánHàngToolStripMenuItem";
            this.bánHàngToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.bánHàngToolStripMenuItem.Text = "Bán Hàng";
            // 
            // báoCáoToolStripMenuItem
            // 
            this.báoCáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.báoCáoCuốiNgàyToolStripMenuItem,
            this.báoCáoDoanhThuToolStripMenuItem,
            this.báoCáoSảnLượngToolStripMenuItem,
            this.báoCáoLợiNhuậnToolStripMenuItem});
            this.báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            this.báoCáoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.báoCáoToolStripMenuItem.Text = "Báo cáo";
            // 
            // báoCáoCuốiNgàyToolStripMenuItem
            // 
            this.báoCáoCuốiNgàyToolStripMenuItem.Name = "báoCáoCuốiNgàyToolStripMenuItem";
            this.báoCáoCuốiNgàyToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.báoCáoCuốiNgàyToolStripMenuItem.Text = "Báo cáo cuối ngày";
            // 
            // báoCáoDoanhThuToolStripMenuItem
            // 
            this.báoCáoDoanhThuToolStripMenuItem.Name = "báoCáoDoanhThuToolStripMenuItem";
            this.báoCáoDoanhThuToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.báoCáoDoanhThuToolStripMenuItem.Text = "Báo cáo doanh thu";
            // 
            // báoCáoSảnLượngToolStripMenuItem
            // 
            this.báoCáoSảnLượngToolStripMenuItem.Name = "báoCáoSảnLượngToolStripMenuItem";
            this.báoCáoSảnLượngToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.báoCáoSảnLượngToolStripMenuItem.Text = "Báo cáo sản lượng";
            // 
            // báoCáoLợiNhuậnToolStripMenuItem
            // 
            this.báoCáoLợiNhuậnToolStripMenuItem.Name = "báoCáoLợiNhuậnToolStripMenuItem";
            this.báoCáoLợiNhuậnToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.báoCáoLợiNhuậnToolStripMenuItem.Text = "Báo cáo lợi nhuận";
            // 
            // quảnLýKháchHàngToolStripMenuItem
            // 
            this.quảnLýKháchHàngToolStripMenuItem.Name = "quảnLýKháchHàngToolStripMenuItem";
            this.quảnLýKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.quảnLýKháchHàngToolStripMenuItem.Text = "Quản lý khách hàng";
            // 
            // quànLýTàiKhoảnToolStripMenuItem
            // 
            this.quànLýTàiKhoảnToolStripMenuItem.Name = "quànLýTàiKhoảnToolStripMenuItem";
            this.quànLýTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.quànLýTàiKhoảnToolStripMenuItem.Text = "Quàn lý tài khoản";
            // 
            // quảnLýNợToolStripMenuItem
            // 
            this.quảnLýNợToolStripMenuItem.Name = "quảnLýNợToolStripMenuItem";
            this.quảnLýNợToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.quảnLýNợToolStripMenuItem.Text = "Quản Lý Nợ";
            // 
            // NhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 721);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NhapHang";
            this.Text = "NHẬP HÀNG";
            this.Load += new System.EventHandler(this.NhapHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtGiaNetBao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGiaNetKg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCK3;
        private System.Windows.Forms.TextBox txtCK2;
        private System.Windows.Forms.TextBox txtCK1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtGiaBao;
        private System.Windows.Forms.TextBox txtGiaKg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKhoiLuong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.TextBox txtPay;
        private System.Windows.Forms.TextBox txtSum;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridViewTextBoxColumn mahang;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn soluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn donvi;
        private System.Windows.Forms.DataGridViewTextBoxColumn khuyenmai;
        private System.Windows.Forms.DataGridViewTextBoxColumn gianetnhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nhậpHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bánHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoCuốiNgàyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoDoanhThuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoSảnLượngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoLợiNhuậnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýKháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quànLýTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNợToolStripMenuItem;
    }
}

