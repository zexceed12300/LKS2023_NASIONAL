namespace HovLibrary.Views
{
    partial class FormAllBorrowing
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cbBorrowStatus = new System.Windows.Forms.ComboBox();
            this.dtpBorrowDateTo = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpBorrowDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvBorrow = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.member = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.book_title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.book_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrow_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.return_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_return = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrow)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFilter);
            this.groupBox2.Controls.Add(this.cbBorrowStatus);
            this.groupBox2.Controls.Add(this.dtpBorrowDateTo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dtpBorrowDateFrom);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(37, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(727, 144);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(12, 98);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(693, 29);
            this.btnFilter.TabIndex = 19;
            this.btnFilter.Text = "Apply";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // cbBorrowStatus
            // 
            this.cbBorrowStatus.FormattingEnabled = true;
            this.cbBorrowStatus.Items.AddRange(new object[] {
            "Ongoing",
            "Late",
            "Returned"});
            this.cbBorrowStatus.Location = new System.Drawing.Point(150, 23);
            this.cbBorrowStatus.Name = "cbBorrowStatus";
            this.cbBorrowStatus.Size = new System.Drawing.Size(555, 21);
            this.cbBorrowStatus.TabIndex = 10;
            // 
            // dtpBorrowDateTo
            // 
            this.dtpBorrowDateTo.Location = new System.Drawing.Point(453, 57);
            this.dtpBorrowDateTo.Name = "dtpBorrowDateTo";
            this.dtpBorrowDateTo.Size = new System.Drawing.Size(252, 20);
            this.dtpBorrowDateTo.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(406, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "and";
            // 
            // dtpBorrowDateFrom
            // 
            this.dtpBorrowDateFrom.Location = new System.Drawing.Point(150, 57);
            this.dtpBorrowDateFrom.Name = "dtpBorrowDateFrom";
            this.dtpBorrowDateFrom.Size = new System.Drawing.Size(241, 20);
            this.dtpBorrowDateFrom.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Borrow date (between)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Borrow status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(322, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "All Borrowing";
            // 
            // dgvBorrow
            // 
            this.dgvBorrow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBorrow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBorrow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.member,
            this.book_title,
            this.book_code,
            this.borrow_date,
            this.return_date,
            this.fine,
            this.btn_return});
            this.dgvBorrow.Location = new System.Drawing.Point(37, 248);
            this.dgvBorrow.Name = "dgvBorrow";
            this.dgvBorrow.ReadOnly = true;
            this.dgvBorrow.Size = new System.Drawing.Size(727, 173);
            this.dgvBorrow.TabIndex = 7;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // member
            // 
            this.member.HeaderText = "member name";
            this.member.Name = "member";
            this.member.ReadOnly = true;
            // 
            // book_title
            // 
            this.book_title.HeaderText = "book title";
            this.book_title.Name = "book_title";
            this.book_title.ReadOnly = true;
            // 
            // book_code
            // 
            this.book_code.HeaderText = "book code";
            this.book_code.Name = "book_code";
            this.book_code.ReadOnly = true;
            // 
            // borrow_date
            // 
            this.borrow_date.HeaderText = "borrow date";
            this.borrow_date.Name = "borrow_date";
            this.borrow_date.ReadOnly = true;
            // 
            // return_date
            // 
            this.return_date.HeaderText = "return date";
            this.return_date.Name = "return_date";
            this.return_date.ReadOnly = true;
            // 
            // fine
            // 
            this.fine.HeaderText = "fine";
            this.fine.Name = "fine";
            this.fine.ReadOnly = true;
            // 
            // btn_return
            // 
            this.btn_return.HeaderText = "";
            this.btn_return.Name = "btn_return";
            this.btn_return.ReadOnly = true;
            // 
            // FormAllBorrowing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvBorrow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FormAllBorrowing";
            this.Text = "FormAllBorrowing";
            this.Load += new System.EventHandler(this.FormAllBorrowing_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ComboBox cbBorrowStatus;
        private System.Windows.Forms.DateTimePicker dtpBorrowDateTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpBorrowDateFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvBorrow;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn member;
        private System.Windows.Forms.DataGridViewTextBoxColumn book_title;
        private System.Windows.Forms.DataGridViewTextBoxColumn book_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn borrow_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn return_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn fine;
        private System.Windows.Forms.DataGridViewTextBoxColumn btn_return;
    }
}