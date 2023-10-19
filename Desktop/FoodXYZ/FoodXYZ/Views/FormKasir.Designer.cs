namespace FoodXYZ.Views
{
    partial class FormKasir
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbTotalHarga = new System.Windows.Forms.TextBox();
            this.tbKuantitas = new System.Windows.Forms.TextBox();
            this.tbHargaSatuan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPilihMenu = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvKeranjang = new System.Windows.Forms.DataGridView();
            this.idtransaksiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kode_barang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama_barang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.harga_satuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kuantitas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbltransaksiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.foodxyzDataSet = new FoodXYZ.foodxyzDataSet();
            this.label4 = new System.Windows.Forms.Label();
            this.tbl_transaksiTableAdapter = new FoodXYZ.foodxyzDataSetTableAdapters.tbl_transaksiTableAdapter();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeranjang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbltransaksiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foodxyzDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 681);
            this.panel1.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 314);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(260, 45);
            this.label9.TabIndex = 5;
            this.label9.Text = "Kelola Transaksi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 45);
            this.label1.TabIndex = 4;
            this.label1.Text = "KASIR";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLogout.Location = new System.Drawing.Point(35, 600);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(194, 46);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FoodXYZ.Properties.Resources.warehouse;
            this.pictureBox1.Location = new System.Drawing.Point(73, 113);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tbTotalHarga
            // 
            this.tbTotalHarga.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTotalHarga.Enabled = false;
            this.tbTotalHarga.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotalHarga.Location = new System.Drawing.Point(791, 193);
            this.tbTotalHarga.Name = "tbTotalHarga";
            this.tbTotalHarga.Size = new System.Drawing.Size(265, 28);
            this.tbTotalHarga.TabIndex = 69;
            // 
            // tbKuantitas
            // 
            this.tbKuantitas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbKuantitas.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbKuantitas.Location = new System.Drawing.Point(791, 125);
            this.tbKuantitas.Name = "tbKuantitas";
            this.tbKuantitas.Size = new System.Drawing.Size(265, 28);
            this.tbKuantitas.TabIndex = 68;
            this.tbKuantitas.TextChanged += new System.EventHandler(this.tbKuantitas_TextChanged);
            // 
            // tbHargaSatuan
            // 
            this.tbHargaSatuan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbHargaSatuan.Enabled = false;
            this.tbHargaSatuan.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHargaSatuan.Location = new System.Drawing.Point(334, 193);
            this.tbHargaSatuan.Name = "tbHargaSatuan";
            this.tbHargaSatuan.Size = new System.Drawing.Size(265, 28);
            this.tbHargaSatuan.TabIndex = 67;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(787, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 66;
            this.label6.Text = "Total harga";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(787, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 65;
            this.label5.Text = "Kuantitas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(330, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 64;
            this.label3.Text = "Harga satuan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(330, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 21);
            this.label2.TabIndex = 63;
            this.label2.Text = "Pilih menu";
            // 
            // cbPilihMenu
            // 
            this.cbPilihMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPilihMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPilihMenu.FormattingEnabled = true;
            this.cbPilihMenu.Location = new System.Drawing.Point(334, 124);
            this.cbPilihMenu.Name = "cbPilihMenu";
            this.cbPilihMenu.Size = new System.Drawing.Size(265, 29);
            this.cbPilihMenu.TabIndex = 62;
            this.cbPilihMenu.TextChanged += new System.EventHandler(this.cbPilihMenu_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(327, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(185, 32);
            this.label8.TabIndex = 70;
            this.label8.Text = "Form Transaksi";
            // 
            // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnTambah.FlatAppearance.BorderSize = 0;
            this.btnTambah.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTambah.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambah.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTambah.Location = new System.Drawing.Point(791, 261);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(121, 38);
            this.btnTambah.TabIndex = 72;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = false;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.LightBlue;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnReset.Location = new System.Drawing.Point(935, 261);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(121, 38);
            this.btnReset.TabIndex = 73;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dgvKeranjang
            // 
            this.dgvKeranjang.AutoGenerateColumns = false;
            this.dgvKeranjang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKeranjang.ColumnHeadersHeight = 35;
            this.dgvKeranjang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvKeranjang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtransaksiDataGridViewTextBoxColumn,
            this.kode_barang,
            this.nama_barang,
            this.harga_satuan,
            this.kuantitas,
            this.subtotal});
            this.dgvKeranjang.DataSource = this.tbltransaksiBindingSource;
            this.dgvKeranjang.Location = new System.Drawing.Point(339, 337);
            this.dgvKeranjang.Name = "dgvKeranjang";
            this.dgvKeranjang.Size = new System.Drawing.Size(722, 173);
            this.dgvKeranjang.TabIndex = 74;
            // 
            // idtransaksiDataGridViewTextBoxColumn
            // 
            this.idtransaksiDataGridViewTextBoxColumn.DataPropertyName = "id_transaksi";
            this.idtransaksiDataGridViewTextBoxColumn.HeaderText = "ID Transaksi";
            this.idtransaksiDataGridViewTextBoxColumn.Name = "idtransaksiDataGridViewTextBoxColumn";
            this.idtransaksiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kode_barang
            // 
            this.kode_barang.DataPropertyName = "kode_barang";
            this.kode_barang.HeaderText = "Kode barang";
            this.kode_barang.Name = "kode_barang";
            // 
            // nama_barang
            // 
            this.nama_barang.DataPropertyName = "nama_barang";
            this.nama_barang.HeaderText = "Nama barang";
            this.nama_barang.Name = "nama_barang";
            // 
            // harga_satuan
            // 
            this.harga_satuan.DataPropertyName = "harga_satuan";
            this.harga_satuan.HeaderText = "Harga satuan";
            this.harga_satuan.Name = "harga_satuan";
            // 
            // kuantitas
            // 
            this.kuantitas.DataPropertyName = "kuantitas";
            this.kuantitas.HeaderText = "Kuantitas";
            this.kuantitas.Name = "kuantitas";
            // 
            // subtotal
            // 
            this.subtotal.DataPropertyName = "subtotal";
            this.subtotal.HeaderText = "Subtotal";
            this.subtotal.Name = "subtotal";
            // 
            // tbltransaksiBindingSource
            // 
            this.tbltransaksiBindingSource.DataMember = "tbl_transaksi";
            this.tbltransaksiBindingSource.DataSource = this.foodxyzDataSet;
            // 
            // foodxyzDataSet
            // 
            this.foodxyzDataSet.DataSetName = "foodxyzDataSet";
            this.foodxyzDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(335, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 75;
            this.label4.Text = "Keranjang";
            // 
            // tbl_transaksiTableAdapter
            // 
            this.tbl_transaksiTableAdapter.ClearBeforeFill = true;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(339, 572);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(265, 28);
            this.textBox1.TabIndex = 76;
            this.textBox1.Text = "Rp. 200000";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(339, 613);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(265, 38);
            this.button2.TabIndex = 77;
            this.button2.Text = "Tambah";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(334, 537);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 25);
            this.label7.TabIndex = 78;
            this.label7.Text = "Total harga";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(495, 537);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label10.Size = new System.Drawing.Size(109, 25);
            this.label10.TabIndex = 79;
            this.label10.Text = "Rp. 200000";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // FormKasir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 681);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvKeranjang);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbTotalHarga);
            this.Controls.Add(this.tbKuantitas);
            this.Controls.Add(this.tbHargaSatuan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbPilihMenu);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormKasir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormKasir";
            this.Load += new System.EventHandler(this.FormKasir_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeranjang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbltransaksiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foodxyzDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbTotalHarga;
        private System.Windows.Forms.TextBox tbKuantitas;
        private System.Windows.Forms.TextBox tbHargaSatuan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPilihMenu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvKeranjang;
        private System.Windows.Forms.Label label4;
        private foodxyzDataSet foodxyzDataSet;
        private System.Windows.Forms.BindingSource tbltransaksiBindingSource;
        private foodxyzDataSetTableAdapters.tbl_transaksiTableAdapter tbl_transaksiTableAdapter;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn notransaksiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tgltransaksiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalbayarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iduserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idbarangDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtransaksiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kode_barang;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama_barang;
        private System.Windows.Forms.DataGridViewTextBoxColumn harga_satuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn kuantitas;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
    }
}