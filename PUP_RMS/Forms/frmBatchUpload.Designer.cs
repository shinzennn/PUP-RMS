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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.gradientLabel1 = new GradientLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlGradesheetForm = new PUP_RMS.RoundedShadowPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.saveBtn = new System.Windows.Forms.Button();
            this.undoBtn = new System.Windows.Forms.Button();
            this.viewBtn = new System.Windows.Forms.Button();
            this.currentImage = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.yearCmbox = new System.Windows.Forms.ComboBox();
            this.pageCmbox = new System.Windows.Forms.ComboBox();
            this.courseCmbox = new System.Windows.Forms.ComboBox();
            this.professorCmbox = new System.Windows.Forms.ComboBox();
            this.KeepCheckbox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sectionCmbox = new System.Windows.Forms.ComboBox();
            this.programCmbox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.yearLevelCmbox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.semesterCmbox = new System.Windows.Forms.ComboBox();
            this.curriculumCmbox = new System.Windows.Forms.ComboBox();
            this.filenameTxtbox = new System.Windows.Forms.TextBox();
            this.panelFacultyList = new PUP_RMS.RoundedPanel();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.toUpload = new System.Windows.Forms.ListView();
            this.toUploadMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeItemMenu = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toUploadMenu.SuspendLayout();
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
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
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
            this.tableLayoutPanel2.Controls.Add(this.saveBtn, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.undoBtn, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.viewBtn, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(23, 480);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(631, 51);
            this.tableLayoutPanel2.TabIndex = 24;
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveBtn.BackColor = System.Drawing.Color.Maroon;
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(263, 9);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(103, 39);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click_1);
            // 
            // undoBtn
            // 
            this.undoBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.undoBtn.BackColor = System.Drawing.Color.Maroon;
            this.undoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.undoBtn.Location = new System.Drawing.Point(53, 9);
            this.undoBtn.Name = "undoBtn";
            this.undoBtn.Size = new System.Drawing.Size(103, 39);
            this.undoBtn.TabIndex = 7;
            this.undoBtn.Text = "Undo";
            this.undoBtn.UseVisualStyleBackColor = false;
            // 
            // viewBtn
            // 
            this.viewBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.viewBtn.BackColor = System.Drawing.Color.Maroon;
            this.viewBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewBtn.Location = new System.Drawing.Point(474, 9);
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
            this.currentImage.Location = new System.Drawing.Point(20, 208);
            this.currentImage.Margin = new System.Windows.Forms.Padding(20);
            this.currentImage.Name = "currentImage";
            this.currentImage.Size = new System.Drawing.Size(636, 261);
            this.currentImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.currentImage.TabIndex = 8;
            this.currentImage.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.80637F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.80637F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.80637F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.264463F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.57733F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.80637F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.34829F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.05354F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.872193F));
            this.tableLayoutPanel1.Controls.Add(this.label12, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.yearCmbox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pageCmbox, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.courseCmbox, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.professorCmbox, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.KeepCheckbox, 9, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.sectionCmbox, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.programCmbox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.yearLevelCmbox, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.semesterCmbox, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.curriculumCmbox, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 58);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(636, 110);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(328, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 33);
            this.label12.TabIndex = 38;
            this.label12.Text = "Section";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(539, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 20);
            this.label9.TabIndex = 35;
            this.label9.Text = "Page";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(452, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 20);
            this.label8.TabIndex = 34;
            this.label8.Text = "Professor";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(385, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 20);
            this.label7.TabIndex = 33;
            this.label7.Text = "Course";
            // 
            // yearCmbox
            // 
            this.yearCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.yearCmbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.yearCmbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.yearCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearCmbox.FormattingEnabled = true;
            this.yearCmbox.Location = new System.Drawing.Point(3, 36);
            this.yearCmbox.Name = "yearCmbox";
            this.yearCmbox.Size = new System.Drawing.Size(61, 28);
            this.yearCmbox.TabIndex = 4;
            this.yearCmbox.Text = "Year";
            // 
            // pageCmbox
            // 
            this.pageCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pageCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageCmbox.FormattingEnabled = true;
            this.pageCmbox.Location = new System.Drawing.Point(538, 35);
            this.pageCmbox.Margin = new System.Windows.Forms.Padding(2);
            this.pageCmbox.Name = "pageCmbox";
            this.pageCmbox.Size = new System.Drawing.Size(59, 28);
            this.pageCmbox.TabIndex = 12;
            this.pageCmbox.Text = "Page";
            // 
            // courseCmbox
            // 
            this.courseCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.courseCmbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.courseCmbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.courseCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseCmbox.FormattingEnabled = true;
            this.courseCmbox.Location = new System.Drawing.Point(385, 36);
            this.courseCmbox.Name = "courseCmbox";
            this.courseCmbox.Size = new System.Drawing.Size(61, 28);
            this.courseCmbox.TabIndex = 2;
            this.courseCmbox.Text = "Course";
            this.courseCmbox.Click += new System.EventHandler(this.courseCmbox_Click);
            // 
            // professorCmbox
            // 
            this.professorCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.professorCmbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.professorCmbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.professorCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.professorCmbox.FormattingEnabled = true;
            this.professorCmbox.Location = new System.Drawing.Point(452, 36);
            this.professorCmbox.Name = "professorCmbox";
            this.professorCmbox.Size = new System.Drawing.Size(81, 28);
            this.professorCmbox.TabIndex = 1;
            this.professorCmbox.Text = "Professor";
            // 
            // KeepCheckbox
            // 
            this.KeepCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.KeepCheckbox.AutoSize = true;
            this.KeepCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeepCheckbox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.KeepCheckbox.Location = new System.Drawing.Point(602, 37);
            this.KeepCheckbox.Name = "KeepCheckbox";
            this.KeepCheckbox.Size = new System.Drawing.Size(31, 24);
            this.KeepCheckbox.TabIndex = 13;
            this.KeepCheckbox.Text = "Keep";
            this.KeepCheckbox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 33);
            this.label3.TabIndex = 29;
            this.label3.Text = "School Year";
            // 
            // sectionCmbox
            // 
            this.sectionCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.sectionCmbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.sectionCmbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.sectionCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sectionCmbox.FormattingEnabled = true;
            this.sectionCmbox.Location = new System.Drawing.Point(327, 35);
            this.sectionCmbox.Margin = new System.Windows.Forms.Padding(2);
            this.sectionCmbox.Name = "sectionCmbox";
            this.sectionCmbox.Size = new System.Drawing.Size(53, 28);
            this.sectionCmbox.TabIndex = 39;
            this.sectionCmbox.Text = "Section";
            // 
            // programCmbox
            // 
            this.programCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.programCmbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.programCmbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.programCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programCmbox.FormattingEnabled = true;
            this.programCmbox.Location = new System.Drawing.Point(69, 35);
            this.programCmbox.Margin = new System.Windows.Forms.Padding(2);
            this.programCmbox.Name = "programCmbox";
            this.programCmbox.Size = new System.Drawing.Size(63, 28);
            this.programCmbox.TabIndex = 11;
            this.programCmbox.Text = "Program ";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(251, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 33);
            this.label5.TabIndex = 31;
            this.label5.Text = "Year Level";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(137, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 33);
            this.label11.TabIndex = 36;
            this.label11.Text = "Curriculum Year";
            // 
            // yearLevelCmbox
            // 
            this.yearLevelCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.yearLevelCmbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearLevelCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearLevelCmbox.FormattingEnabled = true;
            this.yearLevelCmbox.Location = new System.Drawing.Point(250, 35);
            this.yearLevelCmbox.Margin = new System.Windows.Forms.Padding(2);
            this.yearLevelCmbox.Name = "yearLevelCmbox";
            this.yearLevelCmbox.Size = new System.Drawing.Size(73, 28);
            this.yearLevelCmbox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(204, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 33);
            this.label4.TabIndex = 30;
            this.label4.Text = "Semester";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(70, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 33);
            this.label6.TabIndex = 32;
            this.label6.Text = "Program";
            // 
            // semesterCmbox
            // 
            this.semesterCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.semesterCmbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.semesterCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.semesterCmbox.FormattingEnabled = true;
            this.semesterCmbox.Location = new System.Drawing.Point(204, 36);
            this.semesterCmbox.Name = "semesterCmbox";
            this.semesterCmbox.Size = new System.Drawing.Size(41, 28);
            this.semesterCmbox.TabIndex = 3;
            // 
            // curriculumCmbox
            // 
            this.curriculumCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.curriculumCmbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.curriculumCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curriculumCmbox.FormattingEnabled = true;
            this.curriculumCmbox.Location = new System.Drawing.Point(136, 35);
            this.curriculumCmbox.Margin = new System.Windows.Forms.Padding(2);
            this.curriculumCmbox.Name = "curriculumCmbox";
            this.curriculumCmbox.Size = new System.Drawing.Size(63, 28);
            this.curriculumCmbox.TabIndex = 37;
            this.curriculumCmbox.Click += new System.EventHandler(this.curriculumCmbox_Click);
            // 
            // filenameTxtbox
            // 
            this.filenameTxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filenameTxtbox.BackColor = System.Drawing.Color.White;
            this.filenameTxtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.filenameTxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filenameTxtbox.Location = new System.Drawing.Point(23, 173);
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
            this.toUpload.ContextMenuStrip = this.toUploadMenu;
            this.toUpload.HideSelection = false;
            this.toUpload.Location = new System.Drawing.Point(25, 25);
            this.toUpload.Margin = new System.Windows.Forms.Padding(25);
            this.toUpload.Name = "toUpload";
            this.toUpload.Size = new System.Drawing.Size(226, 444);
            this.toUpload.TabIndex = 6;
            this.toUpload.UseCompatibleStateImageBehavior = false;
            // 
            // toUploadMenu
            // 
            this.toUploadMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeItemMenu});
            this.toUploadMenu.Name = "contextMenuStrip1";
            this.toUploadMenu.Size = new System.Drawing.Size(118, 26);
            // 
            // removeItemMenu
            // 
            this.removeItemMenu.Name = "removeItemMenu";
            this.removeItemMenu.Size = new System.Drawing.Size(117, 22);
            this.removeItemMenu.Text = "Remove";
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
            this.BackgroundImage = global::PUP_RMS.Properties.Resources._619384472_920609864259422_4656079368386240362_n;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
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
            this.toUploadMenu.ResumeLayout(false);
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
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox curriculumCmbox;
        private System.Windows.Forms.ComboBox sectionCmbox;
        private System.Windows.Forms.ContextMenuStrip toUploadMenu;
        private System.Windows.Forms.ToolStripMenuItem removeItemMenu;
    }
}