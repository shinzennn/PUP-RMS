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
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(111, 70);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.ReadOnly = true;
            this.txtFilename.Size = new System.Drawing.Size(309, 20);
            this.txtFilename.TabIndex = 0;
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(108, 54);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(49, 13);
            this.lblFilename.TabIndex = 1;
            this.lblFilename.Text = "Filename";
            // 
            // txtPageNumber
            // 
            this.txtPageNumber.Location = new System.Drawing.Point(426, 70);
            this.txtPageNumber.Name = "txtPageNumber";
            this.txtPageNumber.Size = new System.Drawing.Size(100, 20);
            this.txtPageNumber.TabIndex = 2;
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.AutoSize = true;
            this.lblPageNumber.Location = new System.Drawing.Point(423, 54);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(52, 13);
            this.lblPageNumber.TabIndex = 3;
            this.lblPageNumber.Text = "Page No.";
            // 
            // lblSchoolYear
            // 
            this.lblSchoolYear.AutoSize = true;
            this.lblSchoolYear.Location = new System.Drawing.Point(108, 93);
            this.lblSchoolYear.Name = "lblSchoolYear";
            this.lblSchoolYear.Size = new System.Drawing.Size(65, 13);
            this.lblSchoolYear.TabIndex = 4;
            this.lblSchoolYear.Text = "School Year";
            // 
            // cmbSchoolYear
            // 
            this.cmbSchoolYear.FormattingEnabled = true;
            this.cmbSchoolYear.Location = new System.Drawing.Point(111, 109);
            this.cmbSchoolYear.Name = "cmbSchoolYear";
            this.cmbSchoolYear.Size = new System.Drawing.Size(121, 21);
            this.cmbSchoolYear.TabIndex = 5;
            // 
            // cmbProgram
            // 
            this.cmbProgram.FormattingEnabled = true;
            this.cmbProgram.Location = new System.Drawing.Point(238, 109);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(89, 21);
            this.cmbProgram.TabIndex = 6;
            // 
            // lblProgramYearLevel
            // 
            this.lblProgramYearLevel.AutoSize = true;
            this.lblProgramYearLevel.Location = new System.Drawing.Point(238, 93);
            this.lblProgramYearLevel.Name = "lblProgramYearLevel";
            this.lblProgramYearLevel.Size = new System.Drawing.Size(121, 13);
            this.lblProgramYearLevel.TabIndex = 7;
            this.lblProgramYearLevel.Text = "Program and Year Level";
            // 
            // cmbYearLevel
            // 
            this.cmbYearLevel.FormattingEnabled = true;
            this.cmbYearLevel.Location = new System.Drawing.Point(333, 109);
            this.cmbYearLevel.Name = "cmbYearLevel";
            this.cmbYearLevel.Size = new System.Drawing.Size(87, 21);
            this.cmbYearLevel.TabIndex = 8;
            // 
            // cmbCourse
            // 
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(426, 109);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(100, 21);
            this.cmbCourse.TabIndex = 9;
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(423, 93);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(68, 13);
            this.lblCourse.TabIndex = 10;
            this.lblCourse.Text = "Course Code";
            // 
            // cmbSemester
            // 
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.Location = new System.Drawing.Point(111, 149);
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.Size = new System.Drawing.Size(121, 21);
            this.cmbSemester.TabIndex = 11;
            // 
            // cmbProfessor
            // 
            this.cmbProfessor.FormattingEnabled = true;
            this.cmbProfessor.Location = new System.Drawing.Point(238, 149);
            this.cmbProfessor.Name = "cmbProfessor";
            this.cmbProfessor.Size = new System.Drawing.Size(182, 21);
            this.cmbProfessor.TabIndex = 12;
            // 
            // lblSemester
            // 
            this.lblSemester.AutoSize = true;
            this.lblSemester.Location = new System.Drawing.Point(108, 133);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(51, 13);
            this.lblSemester.TabIndex = 13;
            this.lblSemester.Text = "Semester";
            // 
            // lblProfessor
            // 
            this.lblProfessor.AutoSize = true;
            this.lblProfessor.Location = new System.Drawing.Point(238, 133);
            this.lblProfessor.Name = "lblProfessor";
            this.lblProfessor.Size = new System.Drawing.Size(51, 13);
            this.lblProfessor.TabIndex = 14;
            this.lblProfessor.Text = "Professor";
            // 
            // lblUploadedBy
            // 
            this.lblUploadedBy.AutoSize = true;
            this.lblUploadedBy.Location = new System.Drawing.Point(108, 179);
            this.lblUploadedBy.Name = "lblUploadedBy";
            this.lblUploadedBy.Size = new System.Drawing.Size(70, 13);
            this.lblUploadedBy.TabIndex = 15;
            this.lblUploadedBy.Text = "Uploaded by:";
            // 
            // cmbAccount
            // 
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(184, 176);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(199, 21);
            this.cmbAccount.TabIndex = 16;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(451, 174);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 17;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // pbPreview
            // 
            this.pbPreview.Location = new System.Drawing.Point(111, 222);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(414, 373);
            this.pbPreview.TabIndex = 18;
            this.pbPreview.TabStop = false;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(111, 601);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 19;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(466, 646);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(547, 646);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmGradeSheetDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 681);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.pbPreview);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.cmbAccount);
            this.Controls.Add(this.lblUploadedBy);
            this.Controls.Add(this.lblProfessor);
            this.Controls.Add(this.lblSemester);
            this.Controls.Add(this.cmbProfessor);
            this.Controls.Add(this.cmbSemester);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.cmbCourse);
            this.Controls.Add(this.cmbYearLevel);
            this.Controls.Add(this.lblProgramYearLevel);
            this.Controls.Add(this.cmbProgram);
            this.Controls.Add(this.cmbSchoolYear);
            this.Controls.Add(this.lblSchoolYear);
            this.Controls.Add(this.lblPageNumber);
            this.Controls.Add(this.txtPageNumber);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.txtFilename);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmGradeSheetDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grade Sheet Details";
            this.Load += new System.EventHandler(this.frmGradeSheetDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
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
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}