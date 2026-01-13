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
            this.panel2 = new System.Windows.Forms.Panel();
            this.undoBtn = new System.Windows.Forms.Button();
            this.uploadedImgs = new System.Windows.Forms.ListView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.roundedPanel3 = new PUP_RMS.RoundedPanel();
            this.gradientLabel1 = new GradientLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentImage)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.roundedPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.professorCmbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.professorCmbox.FormattingEnabled = true;
            this.professorCmbox.Location = new System.Drawing.Point(880, 3);
            this.professorCmbox.Name = "professorCmbox";
            this.professorCmbox.Size = new System.Drawing.Size(125, 21);
            this.professorCmbox.TabIndex = 1;
            this.professorCmbox.Text = "Professor";
            // 
            // courseCmbox
            // 
            this.courseCmbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.courseCmbox.FormattingEnabled = true;
            this.courseCmbox.Location = new System.Drawing.Point(708, 3);
            this.courseCmbox.Name = "courseCmbox";
            this.courseCmbox.Size = new System.Drawing.Size(166, 21);
            this.courseCmbox.TabIndex = 2;
            this.courseCmbox.Text = "Course";
            // 
            // semesterCmbox
            // 
            this.semesterCmbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.semesterCmbox.FormattingEnabled = true;
            this.semesterCmbox.Location = new System.Drawing.Point(230, 3);
            this.semesterCmbox.Name = "semesterCmbox";
            this.semesterCmbox.Size = new System.Drawing.Size(472, 21);
            this.semesterCmbox.TabIndex = 3;
            this.semesterCmbox.Text = "Semester";
            // 
            // yearCmbox
            // 
            this.yearCmbox.Dock = System.Windows.Forms.DockStyle.Fill;
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
            "2039-2040"});
            this.yearCmbox.Location = new System.Drawing.Point(3, 3);
            this.yearCmbox.Name = "yearCmbox";
            this.yearCmbox.Size = new System.Drawing.Size(221, 21);
            this.yearCmbox.TabIndex = 4;
            this.yearCmbox.Text = "Year";
            // 
            // filenameTxtbox
            // 
            this.filenameTxtbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filenameTxtbox.Location = new System.Drawing.Point(1011, 3);
            this.filenameTxtbox.Name = "filenameTxtbox";
            this.filenameTxtbox.Size = new System.Drawing.Size(100, 20);
            this.filenameTxtbox.TabIndex = 5;
            this.filenameTxtbox.Text = "File Name";
            // 
            // toUpload
            // 
            this.toUpload.HideSelection = false;
            this.toUpload.Location = new System.Drawing.Point(37, 23);
            this.toUpload.Name = "toUpload";
            this.toUpload.Size = new System.Drawing.Size(276, 269);
            this.toUpload.TabIndex = 6;
            this.toUpload.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RosyBrown;
            this.panel1.Controls.Add(this.uploadBtn);
            this.panel1.Controls.Add(this.toUpload);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(351, 360);
            this.panel1.TabIndex = 7;
            // 
            // uploadBtn
            // 
            this.uploadBtn.BackColor = System.Drawing.Color.Maroon;
            this.uploadBtn.Font = new System.Drawing.Font("Sans Serif Collection", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadBtn.Location = new System.Drawing.Point(110, 298);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(134, 51);
            this.uploadBtn.TabIndex = 7;
            this.uploadBtn.Text = "Upload";
            this.uploadBtn.UseVisualStyleBackColor = false;
            // 
            // currentImage
            // 
            this.currentImage.BackColor = System.Drawing.Color.MistyRose;
            this.currentImage.Location = new System.Drawing.Point(17, 3);
            this.currentImage.Name = "currentImage";
            this.currentImage.Size = new System.Drawing.Size(301, 372);
            this.currentImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.currentImage.TabIndex = 8;
            this.currentImage.TabStop = false;
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.Maroon;
            this.saveBtn.Font = new System.Drawing.Font("Sans Serif Collection", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(109, 381);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(103, 51);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RosyBrown;
            this.panel2.Controls.Add(this.undoBtn);
            this.panel2.Controls.Add(this.uploadedImgs);
            this.panel2.Location = new System.Drawing.Point(745, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(366, 416);
            this.panel2.TabIndex = 9;
            // 
            // undoBtn
            // 
            this.undoBtn.BackColor = System.Drawing.Color.Maroon;
            this.undoBtn.Font = new System.Drawing.Font("Sans Serif Collection", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.undoBtn.Location = new System.Drawing.Point(145, 349);
            this.undoBtn.Name = "undoBtn";
            this.undoBtn.Size = new System.Drawing.Size(103, 51);
            this.undoBtn.TabIndex = 7;
            this.undoBtn.Text = "Undo";
            this.undoBtn.UseVisualStyleBackColor = false;
            // 
            // uploadedImgs
            // 
            this.uploadedImgs.HideSelection = false;
            this.uploadedImgs.Location = new System.Drawing.Point(41, 23);
            this.uploadedImgs.Name = "uploadedImgs";
            this.uploadedImgs.Size = new System.Drawing.Size(314, 310);
            this.uploadedImgs.TabIndex = 6;
            this.uploadedImgs.UseCompatibleStateImageBehavior = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.roundedPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.66376F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.33625F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1120, 788);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // roundedPanel3
            // 
            this.roundedPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.roundedPanel3.BorderColor = System.Drawing.Color.Transparent;
            this.roundedPanel3.BorderRadius = 10;
            this.roundedPanel3.BorderSize = 0;
            this.roundedPanel3.Controls.Add(this.gradientLabel1);
            this.roundedPanel3.Controls.Add(this.label10);
            this.roundedPanel3.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.roundedPanel3.HoverBorderColor = System.Drawing.Color.Maroon;
            this.roundedPanel3.Location = new System.Drawing.Point(3, 3);
            this.roundedPanel3.Name = "roundedPanel3";
            this.roundedPanel3.ShadowBlur = 15;
            this.roundedPanel3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.roundedPanel3.ShadowEnabled = true;
            this.roundedPanel3.ShadowOffset = 5;
            this.roundedPanel3.Size = new System.Drawing.Size(1114, 70);
            this.roundedPanel3.TabIndex = 17;
            // 
            // gradientLabel1
            // 
            this.gradientLabel1.AutoSize = true;
            this.gradientLabel1.BackColor = System.Drawing.Color.Transparent;
            this.gradientLabel1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.gradientLabel1.Location = new System.Drawing.Point(14, 9);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Size = new System.Drawing.Size(166, 32);
            this.gradientLabel1.TabIndex = 7;
            this.gradientLabel1.Text = "Batch Upload";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(16, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(240, 21);
            this.label10.TabIndex = 6;
            this.label10.Text = "Upload and review gradesheets";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.26381F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.73618F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel2.Controls.Add(this.yearCmbox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.semesterCmbox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.courseCmbox, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.professorCmbox, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.filenameTxtbox, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 147);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1114, 75);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 228);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1114, 557);
            this.tableLayoutPanel3.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.currentImage);
            this.panel3.Controls.Add(this.saveBtn);
            this.panel3.Location = new System.Drawing.Point(374, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(337, 441);
            this.panel3.TabIndex = 21;
            // 
            // frmBatchUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1120, 788);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBatchUpload";
            this.Text = "Batch GradeSheet Upload";
            this.Load += new System.EventHandler(this.frmBatchUpload_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.currentImage)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.roundedPanel3.ResumeLayout(false);
            this.roundedPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button undoBtn;
        private System.Windows.Forms.ListView uploadedImgs;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RoundedPanel roundedPanel3;
        private GradientLabel gradientLabel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel3;
    }
}