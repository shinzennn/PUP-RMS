namespace PUP_RMS.Forms
{
    partial class frmBatchUpload
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
            this.label1 = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.gradientLabel1 = new GradientLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlGradesheetForm = new PUP_RMS.RoundedShadowPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnProgram = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.undoBtn = new System.Windows.Forms.Button();
            this.btnProf = new System.Windows.Forms.Button();
            this.btnCourse = new System.Windows.Forms.Button();
            this.viewBtn = new System.Windows.Forms.Button();
            this.currentImage = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.yearCmbox = new System.Windows.Forms.ComboBox();
            this.semesterCmbox = new System.Windows.Forms.ComboBox();
            this.programCmbox = new System.Windows.Forms.ComboBox();
            this.pageCmbox = new System.Windows.Forms.ComboBox();
            this.yearLevelCmbox = new System.Windows.Forms.ComboBox();
            this.courseCmbox = new System.Windows.Forms.ComboBox();
            this.professorCmbox = new System.Windows.Forms.ComboBox();
            this.KeepCheckbox = new System.Windows.Forms.CheckBox();
            this.filenameTxtbox = new System.Windows.Forms.TextBox();
            this.panelFacultyList = new PUP_RMS.RoundedPanel();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.toUpload = new System.Windows.Forms.ListView();
            this.btnOpenCouse = new System.Windows.Forms.Button();
            this.createNewFaculty = new System.Windows.Forms.Button();
            this.cbxKeep = new System.Windows.Forms.CheckBox();
            this.panelHeader.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.pnlGradesheetForm.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentImage)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelFacultyList.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 37);
            this.label1.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.panelHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelHeader.Controls.Add(this.gradientLabel1);
            this.panelHeader.Controls.Add(this.label10);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1120, 90);
            this.panelHeader.TabIndex = 21;
            // 
            // gradientLabel1
            // 
            this.gradientLabel1.AutoSize = true;
            this.gradientLabel1.BackColor = System.Drawing.Color.Transparent;
            this.gradientLabel1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel1.Location = new System.Drawing.Point(24, 14);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Size = new System.Drawing.Size(264, 37);
            this.gradientLabel1.TabIndex = 9;
            this.gradientLabel1.Text = "Upload Gradesheet";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(27, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(265, 21);
            this.label10.TabIndex = 8;
            this.label10.Text = "Upload gradesheet in the database";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.Controls.Add(this.pnlGradesheetForm, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panelFacultyList, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(33, 165);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(50);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1002, 547);
            this.tableLayoutPanel3.TabIndex = 25;
            this.tableLayoutPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel3_Paint);
            // 
            // pnlGradesheetForm
            // 
            this.pnlGradesheetForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGradesheetForm.BackColor = System.Drawing.Color.Transparent;
            this.pnlGradesheetForm.BorderColor = System.Drawing.Color.Transparent;
            this.pnlGradesheetForm.BorderRadius = 20;
            this.pnlGradesheetForm.BorderSize = 0;
            this.pnlGradesheetForm.Controls.Add(this.label2);
            this.pnlGradesheetForm.Controls.Add(this.tableLayoutPanel2);
            this.pnlGradesheetForm.Controls.Add(this.currentImage);
            this.pnlGradesheetForm.Controls.Add(this.tableLayoutPanel1);
            this.pnlGradesheetForm.Controls.Add(this.filenameTxtbox);
            this.pnlGradesheetForm.Location = new System.Drawing.Point(0, 0);
            this.pnlGradesheetForm.Margin = new System.Windows.Forms.Padding(0, 0, 25, 0);
            this.pnlGradesheetForm.Name = "pnlGradesheetForm";
            this.pnlGradesheetForm.PanelColor = System.Drawing.Color.White;
            this.pnlGradesheetForm.PanelImage = null;
            this.pnlGradesheetForm.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.pnlGradesheetForm.ShadowDepth = 10;
            this.pnlGradesheetForm.ShadowEnabled = true;
            this.pnlGradesheetForm.ShadowShift = 5;
            this.pnlGradesheetForm.Size = new System.Drawing.Size(676, 547);
            this.pnlGradesheetForm.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(18, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 25);
            this.label2.TabIndex = 25;
            this.label2.Text = "Enter Required Fields:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.btnProgram, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.saveBtn, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.undoBtn, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnProf, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnCourse, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.viewBtn, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(23, 449);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(631, 82);
            this.tableLayoutPanel2.TabIndex = 24;
            // 
            // btnProgram
            // 
            this.btnProgram.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnProgram.BackColor = System.Drawing.Color.Maroon;
            this.btnProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProgram.Location = new System.Drawing.Point(474, 48);
            this.btnProgram.Name = "btnProgram";
            this.btnProgram.Size = new System.Drawing.Size(103, 31);
            this.btnProgram.TabIndex = 28;
            this.btnProgram.Text = "Program";
            this.btnProgram.UseVisualStyleBackColor = false;
            this.btnProgram.Click += new System.EventHandler(this.btnProgram_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveBtn.BackColor = System.Drawing.Color.Maroon;
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(263, 3);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(103, 39);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            // 
            // undoBtn
            // 
            this.undoBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.undoBtn.BackColor = System.Drawing.Color.Maroon;
            this.undoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.undoBtn.Location = new System.Drawing.Point(53, 3);
            this.undoBtn.Name = "undoBtn";
            this.undoBtn.Size = new System.Drawing.Size(103, 39);
            this.undoBtn.TabIndex = 7;
            this.undoBtn.Text = "Undo";
            this.undoBtn.UseVisualStyleBackColor = false;
            // 
            // btnProf
            // 
            this.btnProf.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnProf.BackColor = System.Drawing.Color.Maroon;
            this.btnProf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProf.Location = new System.Drawing.Point(263, 48);
            this.btnProf.Name = "btnProf";
            this.btnProf.Size = new System.Drawing.Size(103, 31);
            this.btnProf.TabIndex = 27;
            this.btnProf.Text = "Professor";
            this.btnProf.UseVisualStyleBackColor = false;
            this.btnProf.Click += new System.EventHandler(this.btnProf_Click);
            // 
            // btnCourse
            // 
            this.btnCourse.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCourse.BackColor = System.Drawing.Color.Maroon;
            this.btnCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCourse.Location = new System.Drawing.Point(53, 48);
            this.btnCourse.Name = "btnCourse";
            this.btnCourse.Size = new System.Drawing.Size(103, 31);
            this.btnCourse.TabIndex = 26;
            this.btnCourse.Text = "Course";
            this.btnCourse.UseVisualStyleBackColor = false;
            this.btnCourse.Click += new System.EventHandler(this.btnCourse_Click);
            // 
            // viewBtn
            // 
            this.viewBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.viewBtn.BackColor = System.Drawing.Color.Maroon;
            this.viewBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewBtn.Location = new System.Drawing.Point(474, 3);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(103, 39);
            this.viewBtn.TabIndex = 9;
            this.viewBtn.Text = "View";
            this.viewBtn.UseVisualStyleBackColor = false;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // currentImage
            // 
            this.currentImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentImage.BackColor = System.Drawing.Color.MistyRose;
            this.currentImage.Location = new System.Drawing.Point(20, 144);
            this.currentImage.Margin = new System.Windows.Forms.Padding(20);
            this.currentImage.Name = "currentImage";
            this.currentImage.Size = new System.Drawing.Size(636, 299);
            this.currentImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.currentImage.TabIndex = 8;
            this.currentImage.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel1.Controls.Add(this.yearCmbox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.semesterCmbox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.programCmbox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pageCmbox, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.yearLevelCmbox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.courseCmbox, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.professorCmbox, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.KeepCheckbox, 7, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 57);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(636, 34);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // yearCmbox
            // 
            this.yearCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.yearCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearCmbox.FormattingEnabled = true;
            this.yearCmbox.Items.AddRange(new object[] {
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
            "2039-2040"});
            this.yearCmbox.Location = new System.Drawing.Point(3, 3);
            this.yearCmbox.Name = "yearCmbox";
            this.yearCmbox.Size = new System.Drawing.Size(73, 28);
            this.yearCmbox.TabIndex = 4;
            this.yearCmbox.Text = "Year";
            // 
            // semesterCmbox
            // 
            this.semesterCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.semesterCmbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.semesterCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.semesterCmbox.FormattingEnabled = true;
            this.semesterCmbox.Location = new System.Drawing.Point(82, 3);
            this.semesterCmbox.Name = "semesterCmbox";
            this.semesterCmbox.Size = new System.Drawing.Size(73, 28);
            this.semesterCmbox.TabIndex = 3;
            // 
            // programCmbox
            // 
            this.programCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.programCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programCmbox.FormattingEnabled = true;
            this.programCmbox.Location = new System.Drawing.Point(160, 3);
            this.programCmbox.Margin = new System.Windows.Forms.Padding(2);
            this.programCmbox.Name = "programCmbox";
            this.programCmbox.Size = new System.Drawing.Size(75, 28);
            this.programCmbox.TabIndex = 11;
            this.programCmbox.Text = "Program ";
            // 
            // pageCmbox
            // 
            this.pageCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pageCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageCmbox.FormattingEnabled = true;
            this.pageCmbox.Location = new System.Drawing.Point(476, 3);
            this.pageCmbox.Margin = new System.Windows.Forms.Padding(2);
            this.pageCmbox.Name = "pageCmbox";
            this.pageCmbox.Size = new System.Drawing.Size(75, 28);
            this.pageCmbox.TabIndex = 12;
            this.pageCmbox.Text = "Page";
            // 
            // yearLevelCmbox
            // 
            this.yearLevelCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.yearLevelCmbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearLevelCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearLevelCmbox.FormattingEnabled = true;
            this.yearLevelCmbox.Location = new System.Drawing.Point(239, 3);
            this.yearLevelCmbox.Margin = new System.Windows.Forms.Padding(2);
            this.yearLevelCmbox.Name = "yearLevelCmbox";
            this.yearLevelCmbox.Size = new System.Drawing.Size(75, 28);
            this.yearLevelCmbox.TabIndex = 10;
            // 
            // courseCmbox
            // 
            this.courseCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.courseCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseCmbox.FormattingEnabled = true;
            this.courseCmbox.Location = new System.Drawing.Point(319, 3);
            this.courseCmbox.Name = "courseCmbox";
            this.courseCmbox.Size = new System.Drawing.Size(73, 28);
            this.courseCmbox.TabIndex = 2;
            this.courseCmbox.Text = "Course";
            // 
            // professorCmbox
            // 
            this.professorCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.professorCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.professorCmbox.FormattingEnabled = true;
            this.professorCmbox.Location = new System.Drawing.Point(398, 3);
            this.professorCmbox.Name = "professorCmbox";
            this.professorCmbox.Size = new System.Drawing.Size(73, 28);
            this.professorCmbox.TabIndex = 1;
            this.professorCmbox.Text = "Professor";
            // 
            // KeepCheckbox
            // 
            this.KeepCheckbox.AutoSize = true;
            this.KeepCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeepCheckbox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.KeepCheckbox.Location = new System.Drawing.Point(556, 3);
            this.KeepCheckbox.Name = "KeepCheckbox";
            this.KeepCheckbox.Size = new System.Drawing.Size(65, 24);
            this.KeepCheckbox.TabIndex = 13;
            this.KeepCheckbox.Text = "Keep";
            this.KeepCheckbox.UseVisualStyleBackColor = true;
            // 
            // filenameTxtbox
            // 
            this.filenameTxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filenameTxtbox.BackColor = System.Drawing.Color.White;
            this.filenameTxtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.filenameTxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filenameTxtbox.Location = new System.Drawing.Point(20, 103);
            this.filenameTxtbox.Margin = new System.Windows.Forms.Padding(5);
            this.filenameTxtbox.Name = "filenameTxtbox";
            this.filenameTxtbox.ReadOnly = true;
            this.filenameTxtbox.Size = new System.Drawing.Size(636, 28);
            this.filenameTxtbox.TabIndex = 5;
            this.filenameTxtbox.Text = "File Name";
            // 
            // panelFacultyList
            // 
            this.panelFacultyList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFacultyList.BackColor = System.Drawing.Color.White;
            this.panelFacultyList.BorderColor = System.Drawing.Color.Black;
            this.panelFacultyList.BorderRadius = 20;
            this.panelFacultyList.BorderSize = 2;
            this.panelFacultyList.Controls.Add(this.uploadBtn);
            this.panelFacultyList.Controls.Add(this.toUpload);
            this.panelFacultyList.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panelFacultyList.HoverBorderColor = System.Drawing.Color.Maroon;
            this.panelFacultyList.Location = new System.Drawing.Point(726, 0);
            this.panelFacultyList.Margin = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.panelFacultyList.Name = "panelFacultyList";
            this.panelFacultyList.ShadowBlur = 15;
            this.panelFacultyList.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelFacultyList.ShadowEnabled = true;
            this.panelFacultyList.ShadowOffset = 5;
            this.panelFacultyList.Size = new System.Drawing.Size(276, 547);
            this.panelFacultyList.TabIndex = 22;
            // 
            // uploadBtn
            // 
            this.uploadBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.uploadBtn.BackColor = System.Drawing.Color.Maroon;
            this.uploadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadBtn.Location = new System.Drawing.Point(87, 480);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(103, 51);
            this.uploadBtn.TabIndex = 7;
            this.uploadBtn.Text = "Upload";
            this.uploadBtn.UseVisualStyleBackColor = false;
            // 
            // toUpload
            // 
            this.toUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toUpload.HideSelection = false;
            this.toUpload.Location = new System.Drawing.Point(25, 25);
            this.toUpload.Margin = new System.Windows.Forms.Padding(25);
            this.toUpload.Name = "toUpload";
            this.toUpload.Size = new System.Drawing.Size(226, 444);
            this.toUpload.TabIndex = 6;
            this.toUpload.UseCompatibleStateImageBehavior = false;
            // 
            // btnOpenCouse
            // 
            this.btnOpenCouse.Location = new System.Drawing.Point(12, 12);
            this.btnOpenCouse.Name = "btnOpenCouse";
            this.btnOpenCouse.Size = new System.Drawing.Size(75, 23);
            this.btnOpenCouse.TabIndex = 13;
            this.btnOpenCouse.Text = "Create Course";
            this.btnOpenCouse.UseVisualStyleBackColor = true;
            // 
            // createNewFaculty
            // 
            this.createNewFaculty.Location = new System.Drawing.Point(12, 41);
            this.createNewFaculty.Name = "createNewFaculty";
            this.createNewFaculty.Size = new System.Drawing.Size(75, 23);
            this.createNewFaculty.TabIndex = 14;
            this.createNewFaculty.Text = "Create Faculty";
            this.createNewFaculty.UseVisualStyleBackColor = true;
            // 
            // cbxKeep
            // 
            this.cbxKeep.AutoSize = true;
            this.cbxKeep.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbxKeep.Location = new System.Drawing.Point(562, 128);
            this.cbxKeep.Name = "cbxKeep";
            this.cbxKeep.Size = new System.Drawing.Size(51, 17);
            this.cbxKeep.TabIndex = 15;
            this.cbxKeep.Text = "Keep";
            this.cbxKeep.UseVisualStyleBackColor = true;
            // 
            // frmBatchUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(1120, 749);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel3);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBatchUpload";
            this.Text = "Batch GradeSheet Upload";
            this.Load += new System.EventHandler(this.frmBatchUpload_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.pnlGradesheetForm.ResumeLayout(false);
            this.pnlGradesheetForm.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.currentImage)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelFacultyList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox professorCmbox;
        private System.Windows.Forms.ComboBox courseCmbox;
        private System.Windows.Forms.ComboBox semesterCmbox;
        private System.Windows.Forms.ComboBox yearCmbox;
        private System.Windows.Forms.TextBox filenameTxtbox;
        private System.Windows.Forms.ListView toUpload;
        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.PictureBox currentImage;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button undoBtn;
        private System.Windows.Forms.Button viewBtn;
        private System.Windows.Forms.ComboBox yearLevelCmbox;
        private System.Windows.Forms.ComboBox programCmbox;
        private System.Windows.Forms.ComboBox pageCmbox;
        private System.Windows.Forms.Panel panelHeader;
        private GradientLabel gradientLabel1;
        private System.Windows.Forms.Label label10;
        private RoundedPanel panelFacultyList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RoundedShadowPanel pnlGradesheetForm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOpenCouse;
        private System.Windows.Forms.Button createNewFaculty;
        private System.Windows.Forms.CheckBox cbxKeep;
        private System.Windows.Forms.CheckBox KeepCheckbox;
        private System.Windows.Forms.Button btnCourse;
        private System.Windows.Forms.Button btnProf;
        private System.Windows.Forms.Button btnProgram;
    }
}