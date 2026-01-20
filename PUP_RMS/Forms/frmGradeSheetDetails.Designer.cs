namespace PUP_RMS.Forms
{
    partial class frmGradeSheetDetails
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
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.lblFilename = new System.Windows.Forms.Label();
            this.txtPageNumber = new System.Windows.Forms.TextBox();
            this.lblPageNumber = new System.Windows.Forms.Label();
            this.lblSchoolYear = new System.Windows.Forms.Label();
            this.cmbSchoolYear = new System.Windows.Forms.ComboBox();
            this.cmbProgram = new System.Windows.Forms.ComboBox();
            this.lblProgramYearLevel = new System.Windows.Forms.Label();
            this.cmbYearLevel = new System.Windows.Forms.ComboBox();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.lblCourse = new System.Windows.Forms.Label();
            this.cmbSemester = new System.Windows.Forms.ComboBox();
            this.cmbProfessor = new System.Windows.Forms.ComboBox();
            this.lblSemester = new System.Windows.Forms.Label();
            this.lblProfessor = new System.Windows.Forms.Label();
            this.lblUploadedBy = new System.Windows.Forms.Label();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.txtUploader = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.roundedShadowPanel1 = new PUP_RMS.RoundedShadowPanel();
            this.btnEdit = new PUP_RMS.RoundedButton();
            this.roundedShadowPanel2 = new PUP_RMS.RoundedShadowPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancels = new PUP_RMS.RoundedButton();
            this.btnSaves = new PUP_RMS.RoundedButton();
            this.btnClose = new PUP_RMS.RoundedButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnUpload = new PUP_RMS.RoundedButton();
            this.btnSave = new PUP_RMS.RoundedButton();
            this.btnCancel = new PUP_RMS.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.roundedShadowPanel1.SuspendLayout();
            this.roundedShadowPanel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilename.BackColor = System.Drawing.Color.LightGray;
            this.txtFilename.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtFilename.Location = new System.Drawing.Point(27, 12);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.ReadOnly = true;
            this.txtFilename.Size = new System.Drawing.Size(273, 19);
            this.txtFilename.TabIndex = 0;
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(32, 8);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(49, 13);
            this.lblFilename.TabIndex = 1;
            this.lblFilename.Text = "Filename";
            // 
            // txtPageNumber
            // 
            this.txtPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPageNumber.BackColor = System.Drawing.Color.LightGray;
            this.txtPageNumber.Location = new System.Drawing.Point(430, 56);
            this.txtPageNumber.Name = "txtPageNumber";
            this.txtPageNumber.ReadOnly = true;
            this.txtPageNumber.Size = new System.Drawing.Size(100, 20);
            this.txtPageNumber.TabIndex = 2;
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.AutoSize = true;
            this.lblPageNumber.Location = new System.Drawing.Point(429, 35);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(52, 13);
            this.lblPageNumber.TabIndex = 3;
            this.lblPageNumber.Text = "Page No.";
            // 
            // lblSchoolYear
            // 
            this.lblSchoolYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSchoolYear.AutoSize = true;
            this.lblSchoolYear.Location = new System.Drawing.Point(101, 95);
            this.lblSchoolYear.Name = "lblSchoolYear";
            this.lblSchoolYear.Size = new System.Drawing.Size(65, 13);
            this.lblSchoolYear.TabIndex = 4;
            this.lblSchoolYear.Text = "School Year";
            // 
            // cmbSchoolYear
            // 
            this.cmbSchoolYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSchoolYear.BackColor = System.Drawing.Color.LightGray;
            this.cmbSchoolYear.Enabled = false;
            this.cmbSchoolYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSchoolYear.FormattingEnabled = true;
            this.cmbSchoolYear.Location = new System.Drawing.Point(31, 88);
            this.cmbSchoolYear.Name = "cmbSchoolYear";
            this.cmbSchoolYear.Size = new System.Drawing.Size(121, 21);
            this.cmbSchoolYear.TabIndex = 5;
            // 
            // cmbProgram
            // 
            this.cmbProgram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProgram.BackColor = System.Drawing.Color.LightGray;
            this.cmbProgram.Enabled = false;
            this.cmbProgram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProgram.FormattingEnabled = true;
            this.cmbProgram.Location = new System.Drawing.Point(236, 112);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(89, 21);
            this.cmbProgram.TabIndex = 6;
            // 
            // lblProgramYearLevel
            // 
            this.lblProgramYearLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgramYearLevel.AutoSize = true;
            this.lblProgramYearLevel.Location = new System.Drawing.Point(236, 96);
            this.lblProgramYearLevel.Name = "lblProgramYearLevel";
            this.lblProgramYearLevel.Size = new System.Drawing.Size(121, 13);
            this.lblProgramYearLevel.TabIndex = 7;
            this.lblProgramYearLevel.Text = "Program and Year Level";
            // 
            // cmbYearLevel
            // 
            this.cmbYearLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbYearLevel.BackColor = System.Drawing.Color.LightGray;
            this.cmbYearLevel.Enabled = false;
            this.cmbYearLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbYearLevel.FormattingEnabled = true;
            this.cmbYearLevel.Location = new System.Drawing.Point(333, 112);
            this.cmbYearLevel.Name = "cmbYearLevel";
            this.cmbYearLevel.Size = new System.Drawing.Size(87, 21);
            this.cmbYearLevel.TabIndex = 8;
            // 
            // cmbCourse
            // 
            this.cmbCourse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCourse.BackColor = System.Drawing.Color.LightGray;
            this.cmbCourse.Enabled = false;
            this.cmbCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(431, 112);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(100, 21);
            this.cmbCourse.TabIndex = 9;
            // 
            // lblCourse
            // 
            this.lblCourse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(363, 70);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(68, 13);
            this.lblCourse.TabIndex = 10;
            this.lblCourse.Text = "Course Code";
            // 
            // cmbSemester
            // 
            this.cmbSemester.BackColor = System.Drawing.Color.LightGray;
            this.cmbSemester.Enabled = false;
            this.cmbSemester.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.Location = new System.Drawing.Point(101, 158);
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.Size = new System.Drawing.Size(121, 21);
            this.cmbSemester.TabIndex = 11;
            // 
            // cmbProfessor
            // 
            this.cmbProfessor.BackColor = System.Drawing.Color.LightGray;
            this.cmbProfessor.Enabled = false;
            this.cmbProfessor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProfessor.FormattingEnabled = true;
            this.cmbProfessor.Location = new System.Drawing.Point(236, 160);
            this.cmbProfessor.Name = "cmbProfessor";
            this.cmbProfessor.Size = new System.Drawing.Size(182, 21);
            this.cmbProfessor.TabIndex = 12;
            // 
            // lblSemester
            // 
            this.lblSemester.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSemester.AutoSize = true;
            this.lblSemester.Location = new System.Drawing.Point(102, 141);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(51, 13);
            this.lblSemester.TabIndex = 13;
            this.lblSemester.Text = "Semester";
            // 
            // lblProfessor
            // 
            this.lblProfessor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProfessor.AutoSize = true;
            this.lblProfessor.Location = new System.Drawing.Point(238, 144);
            this.lblProfessor.Name = "lblProfessor";
            this.lblProfessor.Size = new System.Drawing.Size(51, 13);
            this.lblProfessor.TabIndex = 14;
            this.lblProfessor.Text = "Professor";
            // 
            // lblUploadedBy
            // 
            this.lblUploadedBy.AutoSize = true;
            this.lblUploadedBy.Location = new System.Drawing.Point(102, 192);
            this.lblUploadedBy.Name = "lblUploadedBy";
            this.lblUploadedBy.Size = new System.Drawing.Size(70, 13);
            this.lblUploadedBy.TabIndex = 15;
            this.lblUploadedBy.Text = "Uploaded by:";
            // 
            // pbPreview
            // 
            this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPreview.Location = new System.Drawing.Point(76, 3);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(386, 349);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPreview.TabIndex = 18;
            this.pbPreview.TabStop = false;
            // 
            // txtUploader
            // 
            this.txtUploader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUploader.Location = new System.Drawing.Point(184, 189);
            this.txtUploader.Name = "txtUploader";
            this.txtUploader.ReadOnly = true;
            this.txtUploader.Size = new System.Drawing.Size(175, 20);
            this.txtUploader.TabIndex = 25;
            this.txtUploader.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.roundedShadowPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(66, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.02929F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.97071F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 249);
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // roundedShadowPanel1
            // 
            this.roundedShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel1.BorderRadius = 20;
            this.roundedShadowPanel1.BorderSize = 0;
            this.roundedShadowPanel1.Controls.Add(this.btnEdit);
            this.roundedShadowPanel1.Controls.Add(this.cmbSchoolYear);
            this.roundedShadowPanel1.Controls.Add(this.roundedShadowPanel2);
            this.roundedShadowPanel1.Controls.Add(this.lblFilename);
            this.roundedShadowPanel1.Controls.Add(this.lblCourse);
            this.roundedShadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roundedShadowPanel1.Location = new System.Drawing.Point(3, 3);
            this.roundedShadowPanel1.Name = "roundedShadowPanel1";
            this.roundedShadowPanel1.PanelColor = System.Drawing.Color.White;
            this.roundedShadowPanel1.PanelImage = null;
            this.roundedShadowPanel1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel1.ShadowDepth = 10;
            this.roundedShadowPanel1.ShadowEnabled = true;
            this.roundedShadowPanel1.ShadowShift = 5;
            this.roundedShadowPanel1.Size = new System.Drawing.Size(494, 210);
            this.roundedShadowPanel1.TabIndex = 27;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.Goldenrod;
            this.btnEdit.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnEdit.BorderRadius = 20;
            this.btnEdit.BorderSize = 0;
            this.btnEdit.ButtonColor = System.Drawing.Color.Goldenrod;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.HoverColor = System.Drawing.Color.DarkRed;
            this.btnEdit.Location = new System.Drawing.Point(382, 158);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(81, 31);
            this.btnEdit.TabIndex = 30;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextColor = System.Drawing.Color.White;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.roundedButton1_Click);
            // 
            // roundedShadowPanel2
            // 
            this.roundedShadowPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedShadowPanel2.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel2.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel2.BorderRadius = 20;
            this.roundedShadowPanel2.BorderSize = 0;
            this.roundedShadowPanel2.Controls.Add(this.txtFilename);
            this.roundedShadowPanel2.Location = new System.Drawing.Point(25, 24);
            this.roundedShadowPanel2.Name = "roundedShadowPanel2";
            this.roundedShadowPanel2.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel2.PanelImage = null;
            this.roundedShadowPanel2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel2.ShadowDepth = 10;
            this.roundedShadowPanel2.ShadowEnabled = true;
            this.roundedShadowPanel2.ShadowShift = 5;
            this.roundedShadowPanel2.Size = new System.Drawing.Size(324, 44);
            this.roundedShadowPanel2.TabIndex = 27;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 247F));
            this.tableLayoutPanel2.Controls.Add(this.btnCancels, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSaves, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 219);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(494, 27);
            this.tableLayoutPanel2.TabIndex = 28;
            // 
            // btnCancels
            // 
            this.btnCancels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancels.BackColor = System.Drawing.Color.Goldenrod;
            this.btnCancels.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancels.BorderRadius = 20;
            this.btnCancels.BorderSize = 0;
            this.btnCancels.ButtonColor = System.Drawing.Color.Goldenrod;
            this.btnCancels.FlatAppearance.BorderSize = 0;
            this.btnCancels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancels.ForeColor = System.Drawing.Color.White;
            this.btnCancels.HoverColor = System.Drawing.Color.DarkRed;
            this.btnCancels.Location = new System.Drawing.Point(250, 3);
            this.btnCancels.Name = "btnCancels";
            this.btnCancels.Size = new System.Drawing.Size(81, 21);
            this.btnCancels.TabIndex = 32;
            this.btnCancels.Text = "Cancel";
            this.btnCancels.TextColor = System.Drawing.Color.White;
            this.btnCancels.UseVisualStyleBackColor = false;
            this.btnCancels.Click += new System.EventHandler(this.btnCancels_Click);
            // 
            // btnSaves
            // 
            this.btnSaves.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaves.BackColor = System.Drawing.Color.Goldenrod;
            this.btnSaves.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSaves.BorderRadius = 20;
            this.btnSaves.BorderSize = 0;
            this.btnSaves.ButtonColor = System.Drawing.Color.Goldenrod;
            this.btnSaves.FlatAppearance.BorderSize = 0;
            this.btnSaves.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaves.ForeColor = System.Drawing.Color.White;
            this.btnSaves.HoverColor = System.Drawing.Color.DarkRed;
            this.btnSaves.Location = new System.Drawing.Point(163, 3);
            this.btnSaves.Name = "btnSaves";
            this.btnSaves.Size = new System.Drawing.Size(81, 21);
            this.btnSaves.TabIndex = 31;
            this.btnSaves.Text = "Save";
            this.btnSaves.TextColor = System.Drawing.Color.White;
            this.btnSaves.UseVisualStyleBackColor = false;
            this.btnSaves.Click += new System.EventHandler(this.btnSaves_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.BackColor = System.Drawing.Color.Goldenrod;
            this.btnClose.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnClose.BorderRadius = 20;
            this.btnClose.BorderSize = 0;
            this.btnClose.ButtonColor = System.Drawing.Color.Goldenrod;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverColor = System.Drawing.Color.DarkRed;
            this.btnClose.Location = new System.Drawing.Point(472, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 18);
            this.btnClose.TabIndex = 33;
            this.btnClose.Text = "Close";
            this.btnClose.TextColor = System.Drawing.Color.White;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.63883F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(44, 278);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.38845F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.611548F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(553, 391);
            this.tableLayoutPanel3.TabIndex = 34;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.69893F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.30108F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel4.Controls.Add(this.pbPreview, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(547, 355);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 5;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.44828F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.55173F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 262F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel5.Controls.Add(this.btnClose, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnUpload, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnSave, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnCancel, 2, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 364);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(547, 24);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpload.BackColor = System.Drawing.Color.Goldenrod;
            this.btnUpload.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnUpload.BorderRadius = 20;
            this.btnUpload.BorderSize = 0;
            this.btnUpload.ButtonColor = System.Drawing.Color.Goldenrod;
            this.btnUpload.FlatAppearance.BorderSize = 0;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.ForeColor = System.Drawing.Color.White;
            this.btnUpload.HoverColor = System.Drawing.Color.DarkRed;
            this.btnUpload.Location = new System.Drawing.Point(33, 3);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(91, 18);
            this.btnUpload.TabIndex = 35;
            this.btnUpload.Text = "Upload";
            this.btnUpload.TextColor = System.Drawing.Color.White;
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.BackColor = System.Drawing.Color.Goldenrod;
            this.btnSave.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSave.BorderRadius = 20;
            this.btnSave.BorderSize = 0;
            this.btnSave.ButtonColor = System.Drawing.Color.Goldenrod;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverColor = System.Drawing.Color.DarkRed;
            this.btnSave.Location = new System.Drawing.Point(392, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 18);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Goldenrod;
            this.btnCancel.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancel.BorderRadius = 20;
            this.btnCancel.BorderSize = 0;
            this.btnCancel.ButtonColor = System.Drawing.Color.Goldenrod;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.HoverColor = System.Drawing.Color.DarkRed;
            this.btnCancel.Location = new System.Drawing.Point(305, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 18);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmGradeSheetDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 681);
            this.Controls.Add(this.txtUploader);
            this.Controls.Add(this.lblUploadedBy);
            this.Controls.Add(this.lblProfessor);
            this.Controls.Add(this.lblSemester);
            this.Controls.Add(this.cmbProfessor);
            this.Controls.Add(this.cmbSemester);
            this.Controls.Add(this.cmbCourse);
            this.Controls.Add(this.cmbYearLevel);
            this.Controls.Add(this.lblProgramYearLevel);
            this.Controls.Add(this.cmbProgram);
            this.Controls.Add(this.lblSchoolYear);
            this.Controls.Add(this.lblPageNumber);
            this.Controls.Add(this.txtPageNumber);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmGradeSheetDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grade Sheet Details";
            this.Load += new System.EventHandler(this.frmGradeSheetDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.roundedShadowPanel1.ResumeLayout(false);
            this.roundedShadowPanel1.PerformLayout();
            this.roundedShadowPanel2.ResumeLayout(false);
            this.roundedShadowPanel2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.TextBox txtPageNumber;
        private System.Windows.Forms.Label lblPageNumber;
        private System.Windows.Forms.Label lblSchoolYear;
        private System.Windows.Forms.ComboBox cmbSchoolYear;
        private System.Windows.Forms.ComboBox cmbProgram;
        private System.Windows.Forms.Label lblProgramYearLevel;
        private System.Windows.Forms.ComboBox cmbYearLevel;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.ComboBox cmbSemester;
        private System.Windows.Forms.ComboBox cmbProfessor;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.Label lblProfessor;
        private System.Windows.Forms.Label lblUploadedBy;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.TextBox txtUploader;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RoundedShadowPanel roundedShadowPanel1;
        private RoundedShadowPanel roundedShadowPanel2;
        private RoundedButton btnEdit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private RoundedButton btnSaves;
        private RoundedButton btnCancels;
        private RoundedButton btnClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private RoundedButton btnUpload;
        private RoundedButton btnSave;
        private RoundedButton btnCancel;
    }
}