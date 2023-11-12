namespace FoodXYZ.Views
{
    partial class FormKelolaLaporan
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
            this.dgvTransaksi = new System.Windows.Forms.DataGridView();
            this.idtransaksiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tgltransaksiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalbayarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iduserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbltransaksiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.foodxyzDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.foodxyzDataSet = new FoodXYZ.foodxyzDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.tbl_transaksiTableAdapter = new FoodXYZ.foodxyzDataSetTableAdapters.tbl_transaksiTableAdapter();
            this.dtpFilterFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpFilterTo = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaksi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbltransaksiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foodxyzDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foodxyzDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTransaksi
            // 
            this.dgvTransaksi.AutoGenerateColumns = false;
            this.dgvTransaksi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransaksi.ColumnHeadersHeight = 35;
            this.dgvTransaksi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTransaksi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtransaksiDataGridViewTextBoxColumn,
            this.tgltransaksiDataGridViewTextBoxColumn,
            this.totalbayarDataGridViewTextBoxColumn,
            this.iduserDataGridViewTextBoxColumn});
            this.dgvTransaksi.DataSource = this.tbltransaksiBindingSource;
            this.dgvTransaksi.Location = new System.Drawing.Point(52, 186);
            this.dgvTransaksi.Name = "dgvTransaksi";
            this.dgvTransaksi.Size = new System.Drawing.Size(722, 173);
            this.dgvTransaksi.TabIndex = 38;
            // 
            // idtransaksiDataGridViewTextBoxColumn
            // 
            this.idtransaksiDataGridViewTextBoxColumn.DataPropertyName = "id_transaksi";
            this.idtransaksiDataGridViewTextBoxColumn.HeaderText = "ID transaksi";
            this.idtransaksiDataGridViewTextBoxColumn.Name = "idtransaksiDataGridViewTextBoxColumn";
            this.idtransaksiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tgltransaksiDataGridViewTextBoxColumn
            // 
            this.tgltransaksiDataGridViewTextBoxColumn.DataPropertyName = "tgl_transaksi";
            this.tgltransaksiDataGridViewTextBoxColumn.HeaderText = "Tanggal transaksi";
            this.tgltransaksiDataGridViewTextBoxColumn.Name = "tgltransaksiDataGridViewTextBoxColumn";
            // 
            // totalbayarDataGridViewTextBoxColumn
            // 
            this.totalbayarDataGridViewTextBoxColumn.DataPropertyName = "total_bayar";
            this.totalbayarDataGridViewTextBoxColumn.HeaderText = "Total pembayaran";
            this.totalbayarDataGridViewTextBoxColumn.Name = "totalbayarDataGridViewTextBoxColumn";
            // 
            // iduserDataGridViewTextBoxColumn
            // 
            this.iduserDataGridViewTextBoxColumn.DataPropertyName = "id_user";
            this.iduserDataGridViewTextBoxColumn.HeaderText = "Nama kasir";
            this.iduserDataGridViewTextBoxColumn.Name = "iduserDataGridViewTextBoxColumn";
            // 
            // tbltransaksiBindingSource
            // 
            this.tbltransaksiBindingSource.DataMember = "tbl_transaksi";
            this.tbltransaksiBindingSource.DataSource = this.foodxyzDataSetBindingSource;
            // 
            // foodxyzDataSetBindingSource
            // 
            this.foodxyzDataSetBindingSource.DataSource = this.foodxyzDataSet;
            this.foodxyzDataSetBindingSource.Position = 0;
            // 
            // foodxyzDataSet
            // 
            this.foodxyzDataSet.DataSetName = "foodxyzDataSet";
            this.foodxyzDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(301, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 45);
            this.label1.TabIndex = 25;
            this.label1.Text = "Kelola Laporan";
            // 
            // tbl_transaksiTableAdapter
            // 
            this.tbl_transaksiTableAdapter.ClearBeforeFill = true;
            // 
            // dtpFilterFrom
            // 
            this.dtpFilterFrom.CalendarFont = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFilterFrom.Location = new System.Drawing.Point(52, 141);
            this.dtpFilterFrom.MinimumSize = new System.Drawing.Size(4, 30);
            this.dtpFilterFrom.Name = "dtpFilterFrom";
            this.dtpFilterFrom.Size = new System.Drawing.Size(266, 30);
            this.dtpFilterFrom.TabIndex = 39;
            // 
            // dtpFilterTo
            // 
            this.dtpFilterTo.CalendarFont = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFilterTo.Location = new System.Drawing.Point(336, 141);
            this.dtpFilterTo.MinimumSize = new System.Drawing.Size(4, 30);
            this.dtpFilterTo.Name = "dtpFilterTo";
            this.dtpFilterTo.Size = new System.Drawing.Size(266, 30);
            this.dtpFilterTo.TabIndex = 40;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFilter.Location = new System.Drawing.Point(638, 141);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(136, 30);
            this.btnFilter.TabIndex = 41;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 21);
            this.label2.TabIndex = 42;
            this.label2.Text = "Tanggal awal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(332, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 21);
            this.label3.TabIndex = 43;
            this.label3.Text = "Tanggal akhir";
            // 
            // FormKelolaLaporan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 642);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.dtpFilterTo);
            this.Controls.Add(this.dtpFilterFrom);
            this.Controls.Add(this.dgvTransaksi);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormKelolaLaporan";
            this.Text = "FormKelolaLaporan";
            this.Load += new System.EventHandler(this.FormKelolaLaporan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaksi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbltransaksiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foodxyzDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foodxyzDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvTransaksi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource foodxyzDataSetBindingSource;
        private foodxyzDataSet foodxyzDataSet;
        private System.Windows.Forms.BindingSource tbltransaksiBindingSource;
        private foodxyzDataSetTableAdapters.tbl_transaksiTableAdapter tbl_transaksiTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtransaksiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tgltransaksiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalbayarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iduserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DateTimePicker dtpFilterFrom;
        private System.Windows.Forms.DateTimePicker dtpFilterTo;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}