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
            this.cmbSchoolYear = new System.Windows.Forms.ComboBox();
            this.cmbSemester = new System.Windows.Forms.ComboBox();
            this.cmbProgram = new System.Windows.Forms.ComboBox();
            this.cmbYearLevel = new System.Windows.Forms.ComboBox();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbProfessor = new System.Windows.Forms.ComboBox();
            this.tlpControls = new System.Windows.Forms.TableLayoutPanel();
            this.dgvGradeSheets = new System.Windows.Forms.DataGridView();
            this.rMSDBDataSet = new PUP_RMS.RMSDBDataSet();
            this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.programTableAdapter = new PUP_RMS.RMSDBDataSetTableAdapters.ProgramTableAdapter();
            this.rMSDBDataSet1 = new PUP_RMS.RMSDBDataSet1();
            this.programBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.programTableAdapter1 = new PUP_RMS.RMSDBDataSet1TableAdapters.ProgramTableAdapter();
            this.tlpControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGradeSheets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMSDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMSDBDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSchoolYear
            // 
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
            this.cmbSchoolYear.Location = new System.Drawing.Point(3, 2);
            this.cmbSchoolYear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSchoolYear.Name = "cmbSchoolYear";
            this.cmbSchoolYear.Size = new System.Drawing.Size(121, 24);
            this.cmbSchoolYear.TabIndex = 2;
            this.cmbSchoolYear.Text = "School Year";
            // 
            // cmbSemester
            // 
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.Items.AddRange(new object[] {
            "1st",
            "2nd"});
            this.cmbSemester.Location = new System.Drawing.Point(157, 2);
            this.cmbSemester.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.Size = new System.Drawing.Size(121, 24);
            this.cmbSemester.TabIndex = 3;
            this.cmbSemester.Text = "Semester";
            // 
            // cmbProgram
            // 
            this.cmbProgram.FormattingEnabled = true;
            this.cmbProgram.Location = new System.Drawing.Point(311, 2);
            this.cmbProgram.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(121, 24);
            this.cmbProgram.TabIndex = 4;
            this.cmbProgram.Text = "Program";
            // 
            // cmbYearLevel
            // 
            this.cmbYearLevel.FormattingEnabled = true;
            this.cmbYearLevel.Items.AddRange(new object[] {
            "1st",
            "2nd",
            "3rd",
            "4th",
            "5th"});
            this.cmbYearLevel.Location = new System.Drawing.Point(465, 2);
            this.cmbYearLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbYearLevel.Name = "cmbYearLevel";
            this.cmbYearLevel.Size = new System.Drawing.Size(121, 24);
            this.cmbYearLevel.TabIndex = 5;
            this.cmbYearLevel.Text = "Year Level";
            // 
            // cmbCourse
            // 
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(619, 2);
            this.cmbCourse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(121, 24);
            this.cmbCourse.TabIndex = 6;
            this.cmbCourse.Text = "Course";
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Location = new System.Drawing.Point(927, 2);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(150, 72);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbProfessor
            // 
            this.cmbProfessor.FormattingEnabled = true;
            this.cmbProfessor.Location = new System.Drawing.Point(773, 2);
            this.cmbProfessor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbProfessor.Name = "cmbProfessor";
            this.cmbProfessor.Size = new System.Drawing.Size(121, 24);
            this.cmbProfessor.TabIndex = 8;
            this.cmbProfessor.Text = "Professor";
            // 
            // tlpControls
            // 
            this.tlpControls.ColumnCount = 7;
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpControls.Controls.Add(this.cmbSchoolYear, 0, 0);
            this.tlpControls.Controls.Add(this.btnSearch, 6, 0);
            this.tlpControls.Controls.Add(this.cmbProfessor, 5, 0);
            this.tlpControls.Controls.Add(this.cmbSemester, 1, 0);
            this.tlpControls.Controls.Add(this.cmbProgram, 2, 0);
            this.tlpControls.Controls.Add(this.cmbCourse, 4, 0);
            this.tlpControls.Controls.Add(this.cmbYearLevel, 3, 0);
            this.tlpControls.Location = new System.Drawing.Point(235, 79);
            this.tlpControls.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlpControls.Name = "tlpControls";
            this.tlpControls.RowCount = 1;
            this.tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControls.Size = new System.Drawing.Size(1080, 76);
            this.tlpControls.TabIndex = 9;
            // 
            // dgvGradeSheets
            // 
            this.dgvGradeSheets.AllowUserToAddRows = false;
            this.dgvGradeSheets.AllowUserToDeleteRows = false;
            this.dgvGradeSheets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGradeSheets.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvGradeSheets.Location = new System.Drawing.Point(235, 204);
            this.dgvGradeSheets.Margin = new System.Windows.Forms.Padding(4);
            this.dgvGradeSheets.Name = "dgvGradeSheets";
            this.dgvGradeSheets.ReadOnly = true;
            this.dgvGradeSheets.RowHeadersVisible = false;
            this.dgvGradeSheets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGradeSheets.Size = new System.Drawing.Size(1080, 537);
            this.dgvGradeSheets.TabIndex = 10;
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
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1493, 884);
            this.Controls.Add(this.dgvGradeSheets);
            this.Controls.Add(this.tlpControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSearch";
            this.Text = "frmSearch";
            this.Load += new System.EventHandler(this.frmSearch_Load);
            this.tlpControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGradeSheets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMSDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMSDBDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbSchoolYear;
        private System.Windows.Forms.ComboBox cmbSemester;
        private System.Windows.Forms.ComboBox cmbProgram;
        private System.Windows.Forms.ComboBox cmbYearLevel;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbProfessor;
        private System.Windows.Forms.TableLayoutPanel tlpControls;
        private System.Windows.Forms.DataGridView dgvGradeSheets;
        private RMSDBDataSet rMSDBDataSet;
        private System.Windows.Forms.BindingSource programBindingSource;
        private RMSDBDataSetTableAdapters.ProgramTableAdapter programTableAdapter;
        private RMSDBDataSet1 rMSDBDataSet1;
        private System.Windows.Forms.BindingSource programBindingSource1;
        private RMSDBDataSet1TableAdapters.ProgramTableAdapter programTableAdapter1;
    }
}