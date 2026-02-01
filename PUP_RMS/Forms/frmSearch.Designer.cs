namespace PUP_RMS.Forms
{
    partial class frmSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rMSDBDataSet = new PUP_RMS.RMSDBDataSet();
            this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.programTableAdapter = new PUP_RMS.RMSDBDataSetTableAdapters.ProgramTableAdapter();
            this.rMSDBDataSet1 = new PUP_RMS.RMSDBDataSet1();
            this.programBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.programTableAdapter1 = new PUP_RMS.RMSDBDataSet1TableAdapters.ProgramTableAdapter();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.gradientLabel1 = new GradientLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.tlpSearch = new System.Windows.Forms.TableLayoutPanel();
            this.tlpControls = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSchoolYear = new System.Windows.Forms.Label();
            this.btnSearch = new PUP_RMS.RoundedButton();
            this.cmbSchoolYear = new System.Windows.Forms.ComboBox();
            this.btnClear = new PUP_RMS.RoundedButton();
            this.cmbProfessor = new System.Windows.Forms.ComboBox();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.cmbYearLevel = new System.Windows.Forms.ComboBox();
            this.cmbProgram = new System.Windows.Forms.ComboBox();
            this.cmbSemester = new System.Windows.Forms.ComboBox();
            this.cmbCurriculum = new System.Windows.Forms.ComboBox();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.btnView = new PUP_RMS.RoundedButton();
            this.dgvGradeSheets = new System.Windows.Forms.DataGridView();
            this.rspSearch = new PUP_RMS.CustomControls.HeaderPanelCard();
            ((System.ComponentModel.ISupportInitialize)(this.rMSDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMSDBDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource1)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.tlpSearch.SuspendLayout();
            this.tlpControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGradeSheets)).BeginInit();
            this.rspSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // rMSDBDataSet
            // 
            this.rMSDBDataSet.DataSetName = "RMSDBDataSet";
            this.rMSDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // programBindingSource
            // 
            this.programBindingSource.DataMember = "Program";
            this.programBindingSource.DataSource = this.rMSDBDataSet;
            // 
            // programTableAdapter
            // 
            this.programTableAdapter.ClearBeforeFill = true;
            // 
            // rMSDBDataSet1
            // 
            this.rMSDBDataSet1.DataSetName = "RMSDBDataSet1";
            this.rMSDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // programBindingSource1
            // 
            this.programBindingSource1.DataMember = "Program";
            this.programBindingSource1.DataSource = this.rMSDBDataSet1;
            // 
            // programTableAdapter1
            // 
            this.programTableAdapter1.ClearBeforeFill = true;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.panelHeader.Controls.Add(this.gradientLabel1);
            this.panelHeader.Controls.Add(this.label10);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1120, 90);
            this.panelHeader.TabIndex = 22;
            // 
            // gradientLabel1
            // 
            this.gradientLabel1.AutoSize = true;
            this.gradientLabel1.BackColor = System.Drawing.Color.Transparent;
            this.gradientLabel1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel1.Location = new System.Drawing.Point(24, 14);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Size = new System.Drawing.Size(255, 37);
            this.gradientLabel1.TabIndex = 9;
            this.gradientLabel1.Text = "Search Gradesheet";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(27, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(261, 21);
            this.label10.TabIndex = 8;
            this.label10.Text = "Search gradesheet in the database";
            // 
            // tlpSearch
            // 
            this.tlpSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpSearch.ColumnCount = 1;
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch.Controls.Add(this.tlpControls, 0, 0);
            this.tlpSearch.Controls.Add(this.btnView, 0, 2);
            this.tlpSearch.Controls.Add(this.dgvGradeSheets, 0, 1);
            this.tlpSearch.Location = new System.Drawing.Point(33, 63);
            this.tlpSearch.Margin = new System.Windows.Forms.Padding(10);
            this.tlpSearch.Name = "tlpSearch";
            this.tlpSearch.RowCount = 3;
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.01976F));
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.27273F));
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.707511F));
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSearch.Size = new System.Drawing.Size(986, 470);
            this.tlpSearch.TabIndex = 0;
            // 
            // tlpControls
            // 
            this.tlpControls.ColumnCount = 10;
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.55899F));
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.55899F));
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.722359F));
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.845209F));
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.84767F));
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.60197F));
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.07371F));
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.75377F));
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tlpControls.Controls.Add(this.label8, 7, 0);
            this.tlpControls.Controls.Add(this.label4, 3, 0);
            this.tlpControls.Controls.Add(this.btnSearch, 8, 1);
            this.tlpControls.Controls.Add(this.btnClear, 9, 1);
            this.tlpControls.Controls.Add(this.cmbProfessor, 7, 1);
            this.tlpControls.Controls.Add(this.cmbSemester, 3, 1);
            this.tlpControls.Controls.Add(this.label1, 0, 0);
            this.tlpControls.Controls.Add(this.cmbProgram, 0, 1);
            this.tlpControls.Controls.Add(this.label3, 1, 0);
            this.tlpControls.Controls.Add(this.cmbCurriculum, 1, 1);
            this.tlpControls.Controls.Add(this.label5, 2, 0);
            this.tlpControls.Controls.Add(this.cmbYearLevel, 2, 1);
            this.tlpControls.Controls.Add(this.label7, 4, 0);
            this.tlpControls.Controls.Add(this.cmbCourse, 4, 1);
            this.tlpControls.Controls.Add(this.label6, 6, 0);
            this.tlpControls.Controls.Add(this.lblSchoolYear, 5, 0);
            this.tlpControls.Controls.Add(this.cmbSection, 6, 1);
            this.tlpControls.Controls.Add(this.cmbSchoolYear, 5, 1);
            this.tlpControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpControls.Location = new System.Drawing.Point(5, 5);
            this.tlpControls.Margin = new System.Windows.Forms.Padding(5);
            this.tlpControls.Name = "tlpControls";
            this.tlpControls.RowCount = 2;
            this.tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.17722F));
            this.tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.82278F));
            this.tlpControls.Size = new System.Drawing.Size(976, 60);
            this.tlpControls.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(688, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 20);
            this.label8.TabIndex = 37;
            this.label8.Text = "Professor:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(350, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 36;
            this.label7.Text = "Course:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(606, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.TabIndex = 35;
            this.label6.Text = "Section:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(207, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 34;
            this.label5.Text = "Year Level:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(278, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 33;
            this.label4.Text = "Semester:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(105, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 32;
            this.label3.Text = "Curriculum:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Program:";
            // 
            // lblSchoolYear
            // 
            this.lblSchoolYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSchoolYear.AutoSize = true;
            this.lblSchoolYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchoolYear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSchoolYear.Location = new System.Drawing.Point(479, 0);
            this.lblSchoolYear.Name = "lblSchoolYear";
            this.lblSchoolYear.Size = new System.Drawing.Size(100, 20);
            this.lblSchoolYear.TabIndex = 30;
            this.lblSchoolYear.Text = "School Year:";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.Goldenrod;
            this.btnSearch.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSearch.BorderRadius = 10;
            this.btnSearch.BorderSize = 0;
            this.btnSearch.ButtonColor = System.Drawing.Color.Goldenrod;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.HoverColor = System.Drawing.Color.DarkRed;
            this.btnSearch.Location = new System.Drawing.Point(817, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(69, 33);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextColor = System.Drawing.Color.White;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbSchoolYear
            // 
            this.cmbSchoolYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSchoolYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSchoolYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSchoolYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSchoolYear.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbSchoolYear.FormattingEnabled = true;
            this.cmbSchoolYear.Items.AddRange(new object[] {
            "1940-1941",
            "1941-1942",
            "1942-1943",
            "1943-1944",
            "1944-1945",
            "1945-1946",
            "1946-1947",
            "1947-1948",
            "1948-1949",
            "1949-1950",
            "1950-1951",
            "1951-1952",
            "1952-1953",
            "1953-1954",
            "1954-1955",
            "1955-1956",
            "1956-1957",
            "1957-1958",
            "1958-1959",
            "1959-1960",
            "1960-1961",
            "1961-1962",
            "1962-1963",
            "1963-1964",
            "1964-1965",
            "1965-1966",
            "1966-1967",
            "1967-1968",
            "1968-1969",
            "1969-1970",
            "1970-1971",
            "1971-1972",
            "1972-1973",
            "1973-1974",
            "1974-1975",
            "1975-1976",
            "1976-1977",
            "1977-1978",
            "1978-1979",
            "1979-1980",
            "1980-1981",
            "1981-1982",
            "1982-1983",
            "1983-1984",
            "1984-1985",
            "1985-1986",
            "1986-1987",
            "1987-1988",
            "1988-1989",
            "1989-1990",
            "1990-1991",
            "1991-1992",
            "1992-1993",
            "1993-1994",
            "1994-1995",
            "1995-1996",
            "1996-1997",
            "1997-1998",
            "1998-1999",
            "1999-2000",
            "2000-2001",
            "2001-2002",
            "2002-2003",
            "2003-2004",
            "2004-2005",
            "2005-2006",
            "2006-2007",
            "2007-2008",
            "2008-2009",
            "2009-2010",
            "2010-2011",
            "2011-2012",
            "2012-2013",
            "2013-2014",
            "2014-2015",
            "2015-2016",
            "2016-2017",
            "2017-2018",
            "2018-2019",
            "2019-2020",
            "2020-2021",
            "2021-2022",
            "2022-2023",
            "2023-2024",
            "2024-2025",
            "2025-2026",
            "2026-2027",
            "2027-2028",
            "2028-2029",
            "2029-2030",
            "2030-2031",
            "2031-2032",
            "2032-2033",
            "2033-2034",
            "2034-2035",
            "2035-2036",
            "2036-2037",
            "2037-2038",
            "2038-2039",
            "2039-2040",
            "2040-2041",
            "2041-2042",
            "2042-2043",
            "2043-2044",
            "2044-2045",
            "2045-2046",
            "2046-2047",
            "2047-2048",
            "2048-2049",
            "2049-2050",
            "2050-2051",
            "2051-2052",
            "2052-2053",
            "2053-2054",
            "2054-2055",
            "2055-2056",
            "2056-2057",
            "2057-2058",
            "2058-2059",
            "2059-2060",
            "2060-2061",
            "2061-2062",
            "2062-2063",
            "2063-2064",
            "2064-2065",
            "2065-2066",
            "2066-2067",
            "2067-2068",
            "2068-2069",
            "2069-2070",
            "2070-2071",
            "2071-2072",
            "2072-2073",
            "2073-2074",
            "2074-2075",
            "2075-2076",
            "2076-2077",
            "2077-2078",
            "2078-2079",
            "2079-2080",
            "2080-2081",
            "2081-2082",
            "2082-2083",
            "2083-2084",
            "2084-2085",
            "2085-2086",
            "2086-2087",
            "2087-2088",
            "2088-2089",
            "2089-2090",
            "2090-2091",
            "2091-2092",
            "2092-2093",
            "2093-2094",
            "2094-2095",
            "2095-2096",
            "2096-2097",
            "2097-2098",
            "2098-2099",
            "2099-2100"});
            this.cmbSchoolYear.Location = new System.Drawing.Point(478, 22);
            this.cmbSchoolYear.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSchoolYear.Name = "cmbSchoolYear";
            this.cmbSchoolYear.Size = new System.Drawing.Size(123, 28);
            this.cmbSchoolYear.TabIndex = 0;
            this.cmbSchoolYear.SelectedIndexChanged += new System.EventHandler(this.cmbSchoolYear_SelectedIndexChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.Goldenrod;
            this.btnClear.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnClear.BorderRadius = 10;
            this.btnClear.BorderSize = 0;
            this.btnClear.ButtonColor = System.Drawing.Color.Goldenrod;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.HoverColor = System.Drawing.Color.DarkRed;
            this.btnClear.Location = new System.Drawing.Point(892, 23);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(81, 33);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.TextColor = System.Drawing.Color.White;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cmbProfessor
            // 
            this.cmbProfessor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProfessor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProfessor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProfessor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProfessor.FormattingEnabled = true;
            this.cmbProfessor.Location = new System.Drawing.Point(687, 22);
            this.cmbProfessor.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProfessor.Name = "cmbProfessor";
            this.cmbProfessor.Size = new System.Drawing.Size(125, 28);
            this.cmbProfessor.TabIndex = 5;
            this.cmbProfessor.SelectedIndexChanged += new System.EventHandler(this.cmbProfessor_SelectedIndexChanged);
            // 
            // cmbCourse
            // 
            this.cmbCourse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCourse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCourse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(349, 22);
            this.cmbCourse.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(125, 28);
            this.cmbCourse.TabIndex = 4;
            this.cmbCourse.SelectedIndexChanged += new System.EventHandler(this.cmbCourse_SelectedIndexChanged);
            // 
            // cmbYearLevel
            // 
            this.cmbYearLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbYearLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYearLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbYearLevel.FormattingEnabled = true;
            this.cmbYearLevel.Items.AddRange(new object[] {
            "1st",
            "2nd",
            "3rd",
            "4th",
            "5th"});
            this.cmbYearLevel.Location = new System.Drawing.Point(206, 22);
            this.cmbYearLevel.Margin = new System.Windows.Forms.Padding(2);
            this.cmbYearLevel.Name = "cmbYearLevel";
            this.cmbYearLevel.Size = new System.Drawing.Size(67, 28);
            this.cmbYearLevel.TabIndex = 3;
            this.cmbYearLevel.SelectedIndexChanged += new System.EventHandler(this.cmbYearLevel_SelectedIndexChanged);
            // 
            // cmbProgram
            // 
            this.cmbProgram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProgram.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProgram.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProgram.FormattingEnabled = true;
            this.cmbProgram.Location = new System.Drawing.Point(2, 22);
            this.cmbProgram.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(98, 28);
            this.cmbProgram.TabIndex = 2;
            this.cmbProgram.SelectedIndexChanged += new System.EventHandler(this.cmbProgram_SelectedIndexChanged);
            // 
            // cmbSemester
            // 
            this.cmbSemester.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.Items.AddRange(new object[] {
            "1st",
            "2nd"});
            this.cmbSemester.Location = new System.Drawing.Point(277, 22);
            this.cmbSemester.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.Size = new System.Drawing.Size(68, 28);
            this.cmbSemester.TabIndex = 1;
            this.cmbSemester.SelectedIndexChanged += new System.EventHandler(this.cmbSemester_SelectedIndexChanged);
            // 
            // cmbCurriculum
            // 
            this.cmbCurriculum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCurriculum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurriculum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbCurriculum.FormattingEnabled = true;
            this.cmbCurriculum.Location = new System.Drawing.Point(105, 23);
            this.cmbCurriculum.Name = "cmbCurriculum";
            this.cmbCurriculum.Size = new System.Drawing.Size(96, 28);
            this.cmbCurriculum.TabIndex = 38;
            this.cmbCurriculum.SelectedIndexChanged += new System.EventHandler(this.cmbCurriculum_SelectedIndexChanged);
            // 
            // cmbSection
            // 
            this.cmbSection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(606, 23);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(76, 28);
            this.cmbSection.TabIndex = 39;
            this.cmbSection.SelectedIndexChanged += new System.EventHandler(this.cmbSection_SelectedIndexChanged);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.BackColor = System.Drawing.Color.Goldenrod;
            this.btnView.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnView.BorderRadius = 10;
            this.btnView.BorderSize = 0;
            this.btnView.ButtonColor = System.Drawing.Color.Goldenrod;
            this.btnView.FlatAppearance.BorderSize = 0;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.HoverColor = System.Drawing.Color.DarkRed;
            this.btnView.Location = new System.Drawing.Point(834, 436);
            this.btnView.Margin = new System.Windows.Forms.Padding(2);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(150, 32);
            this.btnView.TabIndex = 8;
            this.btnView.Text = "View";
            this.btnView.TextColor = System.Drawing.Color.White;
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // dgvGradeSheets
            // 
            this.dgvGradeSheets.AllowUserToAddRows = false;
            this.dgvGradeSheets.AllowUserToDeleteRows = false;
            this.dgvGradeSheets.AllowUserToResizeColumns = false;
            this.dgvGradeSheets.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dgvGradeSheets.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGradeSheets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGradeSheets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGradeSheets.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvGradeSheets.BackgroundColor = System.Drawing.Color.White;
            this.dgvGradeSheets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGradeSheets.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvGradeSheets.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGradeSheets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGradeSheets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGradeSheets.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGradeSheets.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvGradeSheets.EnableHeadersVisualStyles = false;
            this.dgvGradeSheets.GridColor = System.Drawing.Color.White;
            this.dgvGradeSheets.Location = new System.Drawing.Point(3, 73);
            this.dgvGradeSheets.Name = "dgvGradeSheets";
            this.dgvGradeSheets.ReadOnly = true;
            this.dgvGradeSheets.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(10, 20, 10, 20);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGradeSheets.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvGradeSheets.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(10, 20, 10, 20);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Maroon;
            this.dgvGradeSheets.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvGradeSheets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGradeSheets.Size = new System.Drawing.Size(980, 357);
            this.dgvGradeSheets.TabIndex = 10;
            this.dgvGradeSheets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGradeSheets_CellContentClick);
            this.dgvGradeSheets.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGradeSheets_CellDoubleClick);
            this.dgvGradeSheets.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGradeSheets_CellMouseEnter);
            this.dgvGradeSheets.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGradeSheets_CellMouseLeave);
            // 
            // rspSearch
            // 
            this.rspSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rspSearch.BackColor = System.Drawing.Color.Transparent;
            this.rspSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.rspSearch.BorderRadius = 10;
            this.rspSearch.BorderThickness = 1;
            this.rspSearch.ContentBackColor = System.Drawing.Color.White;
            this.rspSearch.Controls.Add(this.tlpSearch);
            this.rspSearch.EnableHoverEffect = false;
            this.rspSearch.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.rspSearch.HeaderFontSize = 16F;
            this.rspSearch.HeaderForeColor = System.Drawing.Color.Maroon;
            this.rspSearch.HeaderHeight = 45;
            this.rspSearch.HeaderLabel = "Enter Search Field:";
            this.rspSearch.IconHeader = null;
            this.rspSearch.IconSize = 22;
            this.rspSearch.Location = new System.Drawing.Point(34, 118);
            this.rspSearch.Margin = new System.Windows.Forms.Padding(25);
            this.rspSearch.Name = "rspSearch";
            this.rspSearch.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rspSearch.ShadowDepth = 6;
            this.rspSearch.ShadowPadding = 12;
            this.rspSearch.ShowHeaderDivider = true;
            this.rspSearch.ShowShadow = true;
            this.rspSearch.Size = new System.Drawing.Size(1052, 566);
            this.rspSearch.TabIndex = 23;
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::PUP_RMS.Properties.Resources._619384472_920609864259422_4656079368386240362_n;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1120, 718);
            this.Controls.Add(this.rspSearch);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSearch";
            this.Text = "frmSearch";
            this.Load += new System.EventHandler(this.frmSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rMSDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMSDBDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource1)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tlpSearch.ResumeLayout(false);
            this.tlpControls.ResumeLayout(false);
            this.tlpControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGradeSheets)).EndInit();
            this.rspSearch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private RMSDBDataSet rMSDBDataSet;
        private System.Windows.Forms.BindingSource programBindingSource;
        private RMSDBDataSetTableAdapters.ProgramTableAdapter programTableAdapter;
        private RMSDBDataSet1 rMSDBDataSet1;
        private System.Windows.Forms.BindingSource programBindingSource1;
        private RMSDBDataSet1TableAdapters.ProgramTableAdapter programTableAdapter1;
        private System.Windows.Forms.Panel panelHeader;
        private GradientLabel gradientLabel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TableLayoutPanel tlpSearch;
        private System.Windows.Forms.TableLayoutPanel tlpControls;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSchoolYear;
        private RoundedButton btnSearch;
        private System.Windows.Forms.ComboBox cmbSchoolYear;
        private RoundedButton btnClear;
        private System.Windows.Forms.ComboBox cmbProfessor;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.ComboBox cmbYearLevel;
        private System.Windows.Forms.ComboBox cmbProgram;
        private System.Windows.Forms.ComboBox cmbSemester;
        private System.Windows.Forms.ComboBox cmbCurriculum;
        private System.Windows.Forms.ComboBox cmbSection;
        private RoundedButton btnView;
        private System.Windows.Forms.DataGridView dgvGradeSheets;
        private CustomControls.HeaderPanelCard rspSearch;
    }
}