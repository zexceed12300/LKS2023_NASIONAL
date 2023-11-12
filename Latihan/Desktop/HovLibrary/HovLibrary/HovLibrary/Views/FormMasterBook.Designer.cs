namespace HovLibrary.Views
{
    partial class FormMasterBook
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvBook = new System.Windows.Forms.DataGridView();
            this.cbSearchBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbKeyword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFilterPublishDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFilterPublishDateTo = new System.Windows.Forms.DateTimePicker();
            this.cbFilterLanguage = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbIsbn = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbIsbn13 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbAuthors = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tbPageCount = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbRatingCount = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.dtpPublishDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.language = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isbn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isbn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.publishers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.publish_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.page_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratings = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.show = new System.Windows.Forms.DataGridViewButtonColumn();
            this.edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.bookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hovLibraryDataSet1 = new HovLibrary.HovLibraryDataSet1();
            this.bookTableAdapter = new HovLibrary.HovLibraryDataSet1TableAdapters.BookTableAdapter();
            this.tbPageCountFrom = new System.Windows.Forms.TextBox();
            this.tbPageCountTo = new System.Windows.Forms.TextBox();
            this.tbRatingsFrom = new System.Windows.Forms.TextBox();
            this.tbRatingsTo = new System.Windows.Forms.TextBox();
            this.panelInput = new System.Windows.Forms.Panel();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.cbPublisher = new System.Windows.Forms.ComboBox();
            this.tbRatingAverage = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hovLibraryDataSet1)).BeginInit();
            this.panelInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(439, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Master Book";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.tbKeyword);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbSearchBy);
            this.groupBox1.Location = new System.Drawing.Point(44, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 144);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbRatingsTo);
            this.groupBox2.Controls.Add(this.tbRatingsFrom);
            this.groupBox2.Controls.Add(this.tbPageCountTo);
            this.groupBox2.Controls.Add(this.tbPageCountFrom);
            this.groupBox2.Controls.Add(this.btnFilter);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbFilterLanguage);
            this.groupBox2.Controls.Add(this.dtpFilterPublishDateTo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dtpFilterPublishDateFrom);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(385, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(610, 194);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter";
            // 
            // dgvBook
            // 
            this.dgvBook.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBook.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.language,
            this.title,
            this.isbn,
            this.isbn13,
            this.authors,
            this.publishers,
            this.publish_date,
            this.page_count,
            this.ratings,
            this.show,
            this.edit,
            this.delete});
            this.dgvBook.Location = new System.Drawing.Point(44, 286);
            this.dgvBook.Name = "dgvBook";
            this.dgvBook.Size = new System.Drawing.Size(951, 150);
            this.dgvBook.TabIndex = 5;
            this.dgvBook.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBook_CellContentClick);
            // 
            // cbSearchBy
            // 
            this.cbSearchBy.FormattingEnabled = true;
            this.cbSearchBy.Items.AddRange(new object[] {
            "title",
            "author",
            "publisher"});
            this.cbSearchBy.Location = new System.Drawing.Point(101, 23);
            this.cbSearchBy.Name = "cbSearchBy";
            this.cbSearchBy.Size = new System.Drawing.Size(180, 21);
            this.cbSearchBy.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Search by";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Keyword";
            // 
            // tbKeyword
            // 
            this.tbKeyword.Location = new System.Drawing.Point(101, 60);
            this.tbKeyword.Name = "tbKeyword";
            this.tbKeyword.Size = new System.Drawing.Size(180, 20);
            this.tbKeyword.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Language";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Publish date (between)";
            // 
            // dtpFilterPublishDateFrom
            // 
            this.dtpFilterPublishDateFrom.Location = new System.Drawing.Point(150, 57);
            this.dtpFilterPublishDateFrom.Name = "dtpFilterPublishDateFrom";
            this.dtpFilterPublishDateFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpFilterPublishDateFrom.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(356, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "and";
            // 
            // dtpFilterPublishDateTo
            // 
            this.dtpFilterPublishDateTo.Location = new System.Drawing.Point(387, 57);
            this.dtpFilterPublishDateTo.Name = "dtpFilterPublishDateTo";
            this.dtpFilterPublishDateTo.Size = new System.Drawing.Size(200, 20);
            this.dtpFilterPublishDateTo.TabIndex = 9;
            // 
            // cbFilterLanguage
            // 
            this.cbFilterLanguage.FormattingEnabled = true;
            this.cbFilterLanguage.Location = new System.Drawing.Point(150, 20);
            this.cbFilterLanguage.Name = "cbFilterLanguage";
            this.cbFilterLanguage.Size = new System.Drawing.Size(437, 21);
            this.cbFilterLanguage.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Page count (between)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Ratings (between)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(356, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "and";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(356, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "and";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(12, 157);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(575, 23);
            this.btnFilter.TabIndex = 19;
            this.btnFilter.Text = "Apply";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(24, 97);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(257, 23);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Language";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(92, 56);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(354, 20);
            this.tbTitle.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Title";
            // 
            // tbIsbn
            // 
            this.tbIsbn.Location = new System.Drawing.Point(92, 92);
            this.tbIsbn.Name = "tbIsbn";
            this.tbIsbn.Size = new System.Drawing.Size(354, 20);
            this.tbIsbn.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 95);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "ISBN";
            // 
            // tbIsbn13
            // 
            this.tbIsbn13.HideSelection = false;
            this.tbIsbn13.Location = new System.Drawing.Point(92, 128);
            this.tbIsbn13.Name = "tbIsbn13";
            this.tbIsbn13.Size = new System.Drawing.Size(354, 20);
            this.tbIsbn13.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 131);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "ISBN13";
            // 
            // tbAuthors
            // 
            this.tbAuthors.Location = new System.Drawing.Point(92, 164);
            this.tbAuthors.Name = "tbAuthors";
            this.tbAuthors.Size = new System.Drawing.Size(354, 20);
            this.tbAuthors.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 167);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "Authors";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(487, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 13);
            this.label16.TabIndex = 16;
            this.label16.Text = "Publisher";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(487, 59);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 13);
            this.label17.TabIndex = 18;
            this.label17.Text = "Publish date";
            // 
            // tbPageCount
            // 
            this.tbPageCount.Location = new System.Drawing.Point(578, 95);
            this.tbPageCount.Name = "tbPageCount";
            this.tbPageCount.Size = new System.Drawing.Size(342, 20);
            this.tbPageCount.TabIndex = 21;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(487, 98);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(62, 13);
            this.label18.TabIndex = 20;
            this.label18.Text = "Page count";
            // 
            // tbRatingCount
            // 
            this.tbRatingCount.Location = new System.Drawing.Point(578, 131);
            this.tbRatingCount.Name = "tbRatingCount";
            this.tbRatingCount.Size = new System.Drawing.Size(342, 20);
            this.tbRatingCount.TabIndex = 23;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(487, 134);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(73, 13);
            this.label19.TabIndex = 22;
            this.label19.Text = "Ratings count";
            // 
            // dtpPublishDate
            // 
            this.dtpPublishDate.Location = new System.Drawing.Point(578, 56);
            this.dtpPublishDate.Name = "dtpPublishDate";
            this.dtpPublishDate.Size = new System.Drawing.Size(342, 20);
            this.dtpPublishDate.TabIndex = 24;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(44, 651);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(951, 35);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            // 
            // language
            // 
            this.language.DataPropertyName = "language";
            this.language.HeaderText = "language";
            this.language.Name = "language";
            // 
            // title
            // 
            this.title.HeaderText = "title";
            this.title.Name = "title";
            // 
            // isbn
            // 
            this.isbn.HeaderText = "isbn";
            this.isbn.Name = "isbn";
            // 
            // isbn13
            // 
            this.isbn13.HeaderText = "isbn13";
            this.isbn13.Name = "isbn13";
            // 
            // authors
            // 
            this.authors.HeaderText = "authors";
            this.authors.Name = "authors";
            // 
            // publishers
            // 
            this.publishers.HeaderText = "publishers";
            this.publishers.Name = "publishers";
            // 
            // publish_date
            // 
            this.publish_date.HeaderText = "publish date";
            this.publish_date.Name = "publish_date";
            // 
            // page_count
            // 
            this.page_count.HeaderText = "page count";
            this.page_count.Name = "page_count";
            // 
            // ratings
            // 
            this.ratings.DataPropertyName = "ratings";
            this.ratings.HeaderText = "ratings";
            this.ratings.Name = "ratings";
            // 
            // show
            // 
            this.show.DataPropertyName = "show";
            this.show.FillWeight = 50F;
            this.show.HeaderText = "show";
            this.show.Name = "show";
            this.show.Text = "show";
            // 
            // edit
            // 
            this.edit.DataPropertyName = "edit";
            this.edit.FillWeight = 50F;
            this.edit.HeaderText = "edit";
            this.edit.Name = "edit";
            // 
            // delete
            // 
            this.delete.DataPropertyName = "delete";
            this.delete.FillWeight = 50F;
            this.delete.HeaderText = "delete";
            this.delete.Name = "delete";
            // 
            // bookBindingSource
            // 
            this.bookBindingSource.DataMember = "Book";
            this.bookBindingSource.DataSource = this.hovLibraryDataSet1;
            // 
            // hovLibraryDataSet1
            // 
            this.hovLibraryDataSet1.DataSetName = "HovLibraryDataSet1";
            this.hovLibraryDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bookTableAdapter
            // 
            this.bookTableAdapter.ClearBeforeFill = true;
            // 
            // tbPageCountFrom
            // 
            this.tbPageCountFrom.Location = new System.Drawing.Point(150, 90);
            this.tbPageCountFrom.Name = "tbPageCountFrom";
            this.tbPageCountFrom.Size = new System.Drawing.Size(200, 20);
            this.tbPageCountFrom.TabIndex = 21;
            // 
            // tbPageCountTo
            // 
            this.tbPageCountTo.Location = new System.Drawing.Point(387, 90);
            this.tbPageCountTo.Name = "tbPageCountTo";
            this.tbPageCountTo.Size = new System.Drawing.Size(200, 20);
            this.tbPageCountTo.TabIndex = 22;
            // 
            // tbRatingsFrom
            // 
            this.tbRatingsFrom.Location = new System.Drawing.Point(150, 123);
            this.tbRatingsFrom.Name = "tbRatingsFrom";
            this.tbRatingsFrom.Size = new System.Drawing.Size(200, 20);
            this.tbRatingsFrom.TabIndex = 23;
            // 
            // tbRatingsTo
            // 
            this.tbRatingsTo.Location = new System.Drawing.Point(387, 123);
            this.tbRatingsTo.Name = "tbRatingsTo";
            this.tbRatingsTo.Size = new System.Drawing.Size(200, 20);
            this.tbRatingsTo.TabIndex = 24;
            // 
            // panelInput
            // 
            this.panelInput.Controls.Add(this.tbRatingAverage);
            this.panelInput.Controls.Add(this.label20);
            this.panelInput.Controls.Add(this.cbPublisher);
            this.panelInput.Controls.Add(this.cbLanguage);
            this.panelInput.Controls.Add(this.label11);
            this.panelInput.Controls.Add(this.dtpPublishDate);
            this.panelInput.Controls.Add(this.label12);
            this.panelInput.Controls.Add(this.tbRatingCount);
            this.panelInput.Controls.Add(this.tbTitle);
            this.panelInput.Controls.Add(this.label19);
            this.panelInput.Controls.Add(this.label13);
            this.panelInput.Controls.Add(this.tbPageCount);
            this.panelInput.Controls.Add(this.tbIsbn);
            this.panelInput.Controls.Add(this.label18);
            this.panelInput.Controls.Add(this.label14);
            this.panelInput.Controls.Add(this.label17);
            this.panelInput.Controls.Add(this.tbIsbn13);
            this.panelInput.Controls.Add(this.label16);
            this.panelInput.Controls.Add(this.label15);
            this.panelInput.Controls.Add(this.tbAuthors);
            this.panelInput.Enabled = false;
            this.panelInput.Location = new System.Drawing.Point(44, 449);
            this.panelInput.Name = "panelInput";
            this.panelInput.Padding = new System.Windows.Forms.Padding(0, 0, 0, 100);
            this.panelInput.Size = new System.Drawing.Size(947, 196);
            this.panelInput.TabIndex = 26;
            // 
            // cbLanguage
            // 
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Location = new System.Drawing.Point(92, 19);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(354, 21);
            this.cbLanguage.TabIndex = 25;
            // 
            // cbPublisher
            // 
            this.cbPublisher.FormattingEnabled = true;
            this.cbPublisher.Location = new System.Drawing.Point(578, 19);
            this.cbPublisher.Name = "cbPublisher";
            this.cbPublisher.Size = new System.Drawing.Size(342, 21);
            this.cbPublisher.TabIndex = 26;
            // 
            // tbRatingAverage
            // 
            this.tbRatingAverage.Location = new System.Drawing.Point(578, 164);
            this.tbRatingAverage.Name = "tbRatingAverage";
            this.tbRatingAverage.Size = new System.Drawing.Size(342, 20);
            this.tbRatingAverage.TabIndex = 28;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(487, 167);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(85, 13);
            this.label20.TabIndex = 27;
            this.label20.Text = "Ratings average";
            // 
            // FormMasterBook
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(0, 60);
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1039, 541);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvBook);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "FormMasterBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMasterBook";
            this.Load += new System.EventHandler(this.FormMasterBook_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hovLibraryDataSet1)).EndInit();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvBook;
        private HovLibraryDataSet1 hovLibraryDataSet1;
        private System.Windows.Forms.BindingSource bookBindingSource;
        private HovLibraryDataSet1TableAdapters.BookTableAdapter bookTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratingscountDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox tbKeyword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSearchBy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFilterPublishDateFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFilterPublishDateTo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbFilterLanguage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbIsbn;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbIsbn13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbAuthors;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbPageCount;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbRatingCount;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DateTimePicker dtpPublishDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn language;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn isbn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isbn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn authors;
        private System.Windows.Forms.DataGridViewTextBoxColumn publishers;
        private System.Windows.Forms.DataGridViewTextBoxColumn publish_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn page_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratings;
        private System.Windows.Forms.DataGridViewButtonColumn show;
        private System.Windows.Forms.DataGridViewButtonColumn edit;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
        private System.Windows.Forms.TextBox tbRatingsTo;
        private System.Windows.Forms.TextBox tbRatingsFrom;
        private System.Windows.Forms.TextBox tbPageCountTo;
        private System.Windows.Forms.TextBox tbPageCountFrom;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.TextBox tbRatingAverage;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cbPublisher;
        private System.Windows.Forms.ComboBox cbLanguage;
    }
}