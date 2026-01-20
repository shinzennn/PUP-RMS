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
            this.professorCmbox = new System.Windows.Forms.ComboBox();
            this.courseCmbox = new System.Windows.Forms.ComboBox();
            this.semesterCmbox = new System.Windows.Forms.ComboBox();
            this.yearCmbox = new System.Windows.Forms.ComboBox();
            this.filenameTxtbox = new System.Windows.Forms.TextBox();
            this.toUpload = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.currentImage = new System.Windows.Forms.PictureBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.undoBtn = new System.Windows.Forms.Button();
            this.viewBtn = new System.Windows.Forms.Button();
            this.yearLevelCmbox = new System.Windows.Forms.ComboBox();
            this.programCmbox = new System.Windows.Forms.ComboBox();
            this.pageCmbox = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentImage)).BeginInit();
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
            // professorCmbox
            // 
            this.professorCmbox.FormattingEnabled = true;
            this.professorCmbox.Location = new System.Drawing.Point(562, 93);
            this.professorCmbox.Name = "professorCmbox";
            this.professorCmbox.Size = new System.Drawing.Size(121, 21);
            this.professorCmbox.TabIndex = 1;
            this.professorCmbox.Text = "Professor";
            // 
            // courseCmbox
            // 
            this.courseCmbox.FormattingEnabled = true;
            this.courseCmbox.Location = new System.Drawing.Point(422, 92);
            this.courseCmbox.Name = "courseCmbox";
            this.courseCmbox.Size = new System.Drawing.Size(121, 21);
            this.courseCmbox.TabIndex = 2;
            this.courseCmbox.Text = "Course";
            // 
            // semesterCmbox
            // 
            this.semesterCmbox.FormattingEnabled = true;
            this.semesterCmbox.Location = new System.Drawing.Point(281, 92);
            this.semesterCmbox.Name = "semesterCmbox";
            this.semesterCmbox.Size = new System.Drawing.Size(121, 21);
            this.semesterCmbox.TabIndex = 3;
            this.semesterCmbox.Text = "Semester";
            // 
            // yearCmbox
            // 
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
            this.yearCmbox.Location = new System.Drawing.Point(142, 92);
            this.yearCmbox.Name = "yearCmbox";
            this.yearCmbox.Size = new System.Drawing.Size(121, 21);
            this.yearCmbox.TabIndex = 4;
            this.yearCmbox.Text = "Year";
            // 
            // filenameTxtbox
            // 
            this.filenameTxtbox.Location = new System.Drawing.Point(704, 94);
            this.filenameTxtbox.Name = "filenameTxtbox";
            this.filenameTxtbox.Size = new System.Drawing.Size(272, 20);
            this.filenameTxtbox.TabIndex = 5;
            this.filenameTxtbox.Text = "File Name";
            // 
            // toUpload
            // 
            this.toUpload.HideSelection = false;
            this.toUpload.Location = new System.Drawing.Point(37, 23);
            this.toUpload.Name = "toUpload";
            this.toUpload.Size = new System.Drawing.Size(265, 262);
            this.toUpload.TabIndex = 6;
            this.toUpload.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RosyBrown;
            this.panel1.Controls.Add(this.uploadBtn);
            this.panel1.Controls.Add(this.toUpload);
            this.panel1.Location = new System.Drawing.Point(614, 174);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 372);
            this.panel1.TabIndex = 7;
            // 
            // uploadBtn
            // 
            this.uploadBtn.BackColor = System.Drawing.Color.Maroon;
            this.uploadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadBtn.Location = new System.Drawing.Point(118, 290);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(103, 51);
            this.uploadBtn.TabIndex = 7;
            this.uploadBtn.Text = "Upload";
            this.uploadBtn.UseVisualStyleBackColor = false;
            // 
            // currentImage
            // 
            this.currentImage.BackColor = System.Drawing.Color.MistyRose;
            this.currentImage.Location = new System.Drawing.Point(142, 174);
            this.currentImage.Name = "currentImage";
            this.currentImage.Size = new System.Drawing.Size(416, 372);
            this.currentImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.currentImage.TabIndex = 8;
            this.currentImage.TabStop = false;
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.Maroon;
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(250, 552);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(103, 51);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            // 
            // undoBtn
            // 
            this.undoBtn.BackColor = System.Drawing.Color.Maroon;
            this.undoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.undoBtn.Location = new System.Drawing.Point(142, 552);
            this.undoBtn.Name = "undoBtn";
            this.undoBtn.Size = new System.Drawing.Size(103, 51);
            this.undoBtn.TabIndex = 7;
            this.undoBtn.Text = "Undo";
            this.undoBtn.UseVisualStyleBackColor = false;
            // 
            // viewBtn
            // 
            this.viewBtn.BackColor = System.Drawing.Color.Maroon;
            this.viewBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewBtn.Location = new System.Drawing.Point(454, 552);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(103, 51);
            this.viewBtn.TabIndex = 9;
            this.viewBtn.Text = "View";
            this.viewBtn.UseVisualStyleBackColor = false;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // yearLevelCmbox
            // 
            this.yearLevelCmbox.FormattingEnabled = true;
            this.yearLevelCmbox.Location = new System.Drawing.Point(142, 124);
            this.yearLevelCmbox.Margin = new System.Windows.Forms.Padding(2);
            this.yearLevelCmbox.Name = "yearLevelCmbox";
            this.yearLevelCmbox.Size = new System.Drawing.Size(121, 21);
            this.yearLevelCmbox.TabIndex = 10;
            this.yearLevelCmbox.Text = "Year Level";
            // 
            // programCmbox
            // 
            this.programCmbox.FormattingEnabled = true;
            this.programCmbox.Location = new System.Drawing.Point(281, 124);
            this.programCmbox.Margin = new System.Windows.Forms.Padding(2);
            this.programCmbox.Name = "programCmbox";
            this.programCmbox.Size = new System.Drawing.Size(121, 21);
            this.programCmbox.TabIndex = 11;
            this.programCmbox.Text = "Program ";
            // 
            // pageCmbox
            // 
            this.pageCmbox.FormattingEnabled = true;
            this.pageCmbox.Location = new System.Drawing.Point(422, 124);
            this.pageCmbox.Margin = new System.Windows.Forms.Padding(2);
            this.pageCmbox.Name = "pageCmbox";
            this.pageCmbox.Size = new System.Drawing.Size(121, 21);
            this.pageCmbox.TabIndex = 12;
            this.pageCmbox.Text = "Page";
            // 
            // frmBatchUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(867, 574);
            this.Controls.Add(this.pageCmbox);
            this.Controls.Add(this.programCmbox);
            this.Controls.Add(this.yearLevelCmbox);
            this.Controls.Add(this.viewBtn);
            this.Controls.Add(this.undoBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.currentImage);
            this.Controls.Add(this.filenameTxtbox);
            this.Controls.Add(this.yearCmbox);
            this.Controls.Add(this.semesterCmbox);
            this.Controls.Add(this.courseCmbox);
            this.Controls.Add(this.professorCmbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBatchUpload";
            this.Text = "Batch GradeSheet Upload";
            this.Load += new System.EventHandler(this.frmBatchUpload_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.currentImage)).EndInit();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.PictureBox currentImage;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button undoBtn;
        private System.Windows.Forms.Button viewBtn;
        private System.Windows.Forms.ComboBox yearLevelCmbox;
        private System.Windows.Forms.ComboBox programCmbox;
        private System.Windows.Forms.ComboBox pageCmbox;
    }
}