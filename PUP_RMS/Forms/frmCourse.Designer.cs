namespace PUP_RMS.Forms
{
    partial class frmCourse
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gradientLabel1 = new GradientLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.roundedShadowPanel3 = new PUP_RMS.RoundedShadowPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxCurriculum = new System.Windows.Forms.ComboBox();
            this.roundedShadowPanel1 = new PUP_RMS.RoundedShadowPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxProgram = new System.Windows.Forms.ComboBox();
            this.panelSearch = new PUP_RMS.RoundedShadowPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new PUP_RMS.RoundedButton();
            this.btnRefresh = new PUP_RMS.RoundedButton();
            this.headerPanelCard1 = new PUP_RMS.CustomControls.HeaderPanelCard();
            this.dgvCourse = new System.Windows.Forms.DataGridView();
            this.btnEdit = new PUP_RMS.RoundedButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panelSubInfo = new PUP_RMS.CustomControls.HeaderPanelCard();
            this.roundedShadowPanel4 = new PUP_RMS.RoundedShadowPanel();
            this.txtCrsCode = new System.Windows.Forms.TextBox();
            this.btnCancel = new PUP_RMS.RoundedButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new PUP_RMS.RoundedButton();
            this.label5 = new System.Windows.Forms.Label();
            this.roundedShadowPanel5 = new PUP_RMS.RoundedShadowPanel();
            this.txtSubDesc = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.roundedShadowPanel3.SuspendLayout();
            this.roundedShadowPanel1.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.headerPanelCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourse)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.panelSubInfo.SuspendLayout();
            this.roundedShadowPanel4.SuspendLayout();
            this.roundedShadowPanel5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(27, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(264, 21);
            this.label10.TabIndex = 8;
            this.label10.Text = "Create and manage course records";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.panel1.Controls.Add(this.gradientLabel1);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1120, 90);
            this.panel1.TabIndex = 20;
            // 
            // gradientLabel1
            // 
            this.gradientLabel1.AutoSize = true;
            this.gradientLabel1.BackColor = System.Drawing.Color.Transparent;
            this.gradientLabel1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel1.Location = new System.Drawing.Point(24, 14);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Size = new System.Drawing.Size(290, 37);
            this.gradientLabel1.TabIndex = 9;
            this.gradientLabel1.Text = "Course Management ";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.roundedShadowPanel3, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.roundedShadowPanel1, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.panelSearch, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSearch, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnRefresh, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(59, 106);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(25, 25, 25, 25);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1002, 64);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // roundedShadowPanel3
            // 
            this.roundedShadowPanel3.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel3.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel3.BorderRadius = 20;
            this.roundedShadowPanel3.BorderSize = 0;
            this.roundedShadowPanel3.Controls.Add(this.label4);
            this.roundedShadowPanel3.Controls.Add(this.cbxCurriculum);
            this.roundedShadowPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roundedShadowPanel3.Location = new System.Drawing.Point(5, 0);
            this.roundedShadowPanel3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.roundedShadowPanel3.Name = "roundedShadowPanel3";
            this.roundedShadowPanel3.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel3.PanelImage = null;
            this.roundedShadowPanel3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel3.ShadowDepth = 10;
            this.roundedShadowPanel3.ShadowEnabled = true;
            this.roundedShadowPanel3.ShadowShift = 5;
            this.roundedShadowPanel3.Size = new System.Drawing.Size(151, 64);
            this.roundedShadowPanel3.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 20);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Curriculum:";
            // 
            // cbxCurriculum
            // 
            this.cbxCurriculum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxCurriculum.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxCurriculum.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxCurriculum.BackColor = System.Drawing.Color.LightGray;
            this.cbxCurriculum.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbxCurriculum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCurriculum.FormattingEnabled = true;
            this.cbxCurriculum.Location = new System.Drawing.Point(100, 17);
            this.cbxCurriculum.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.cbxCurriculum.Name = "cbxCurriculum";
            this.cbxCurriculum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbxCurriculum.Size = new System.Drawing.Size(29, 28);
            this.cbxCurriculum.TabIndex = 16;
            this.cbxCurriculum.SelectedIndexChanged += new System.EventHandler(this.cbxCurriculum_SelectedIndexChanged_1);
            // 
            // roundedShadowPanel1
            // 
            this.roundedShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel1.BorderRadius = 20;
            this.roundedShadowPanel1.BorderSize = 0;
            this.roundedShadowPanel1.Controls.Add(this.label6);
            this.roundedShadowPanel1.Controls.Add(this.cbxProgram);
            this.roundedShadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roundedShadowPanel1.Location = new System.Drawing.Point(166, 0);
            this.roundedShadowPanel1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.roundedShadowPanel1.Name = "roundedShadowPanel1";
            this.roundedShadowPanel1.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel1.PanelImage = null;
            this.roundedShadowPanel1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel1.ShadowDepth = 10;
            this.roundedShadowPanel1.ShadowEnabled = true;
            this.roundedShadowPanel1.ShadowShift = 5;
            this.roundedShadowPanel1.Size = new System.Drawing.Size(150, 64);
            this.roundedShadowPanel1.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 20);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Program:";
            // 
            // cbxProgram
            // 
            this.cbxProgram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxProgram.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxProgram.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxProgram.BackColor = System.Drawing.Color.LightGray;
            this.cbxProgram.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbxProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxProgram.FormattingEnabled = true;
            this.cbxProgram.Location = new System.Drawing.Point(90, 17);
            this.cbxProgram.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.cbxProgram.Name = "cbxProgram";
            this.cbxProgram.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbxProgram.Size = new System.Drawing.Size(30, 28);
            this.cbxProgram.TabIndex = 16;
            this.cbxProgram.SelectedIndexChanged += new System.EventHandler(this.cbxProgram_SelectedIndexChanged);
            this.cbxProgram.SelectionChangeCommitted += new System.EventHandler(this.cbxProgram_SelectionChangeCommitted);
            // 
            // panelSearch
            // 
            this.panelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSearch.BackColor = System.Drawing.Color.Transparent;
            this.panelSearch.BorderColor = System.Drawing.Color.Transparent;
            this.panelSearch.BorderRadius = 20;
            this.panelSearch.BorderSize = 0;
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Location = new System.Drawing.Point(331, 0);
            this.panelSearch.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.PanelColor = System.Drawing.Color.LightGray;
            this.panelSearch.PanelImage = null;
            this.panelSearch.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelSearch.ShadowDepth = 10;
            this.panelSearch.ShadowEnabled = true;
            this.panelSearch.ShadowShift = 5;
            this.panelSearch.Size = new System.Drawing.Size(461, 64);
            this.panelSearch.TabIndex = 17;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.LightGray;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(22, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSearch.Size = new System.Drawing.Size(417, 19);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.Maroon;
            this.btnSearch.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSearch.BorderRadius = 20;
            this.btnSearch.BorderSize = 0;
            this.btnSearch.ButtonColor = System.Drawing.Color.Maroon;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.HoverColor = System.Drawing.Color.DarkRed;
            this.btnSearch.Location = new System.Drawing.Point(810, 8);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 48);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextColor = System.Drawing.Color.White;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.Maroon;
            this.btnRefresh.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnRefresh.BorderRadius = 20;
            this.btnRefresh.BorderSize = 0;
            this.btnRefresh.ButtonColor = System.Drawing.Color.Maroon;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.HoverColor = System.Drawing.Color.DarkRed;
            this.btnRefresh.Location = new System.Drawing.Point(910, 8);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(84, 48);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextColor = System.Drawing.Color.White;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // headerPanelCard1
            // 
            this.headerPanelCard1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerPanelCard1.BackColor = System.Drawing.Color.Transparent;
            this.headerPanelCard1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.headerPanelCard1.BorderRadius = 10;
            this.headerPanelCard1.BorderThickness = 1;
            this.headerPanelCard1.ContentBackColor = System.Drawing.Color.White;
            this.headerPanelCard1.Controls.Add(this.dgvCourse);
            this.headerPanelCard1.EnableHoverEffect = false;
            this.headerPanelCard1.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.headerPanelCard1.HeaderFontSize = 16F;
            this.headerPanelCard1.HeaderForeColor = System.Drawing.Color.Maroon;
            this.headerPanelCard1.HeaderHeight = 45;
            this.headerPanelCard1.HeaderLabel = "Course List";
            this.headerPanelCard1.IconHeader = null;
            this.headerPanelCard1.IconSize = 22;
            this.headerPanelCard1.Location = new System.Drawing.Point(504, 3);
            this.headerPanelCard1.Name = "headerPanelCard1";
            this.headerPanelCard1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.headerPanelCard1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.headerPanelCard1.ShadowDepth = 6;
            this.headerPanelCard1.ShadowPadding = 12;
            this.headerPanelCard1.ShowHeaderDivider = true;
            this.headerPanelCard1.ShowShadow = true;
            this.headerPanelCard1.Size = new System.Drawing.Size(495, 709);
            this.headerPanelCard1.TabIndex = 27;
            // 
            // dgvCourse
            // 
            this.dgvCourse.AllowUserToAddRows = false;
            this.dgvCourse.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dgvCourse.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCourse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCourse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCourse.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCourse.BackgroundColor = System.Drawing.Color.White;
            this.dgvCourse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCourse.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCourse.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCourse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourse.ColumnHeadersVisible = false;
            this.dgvCourse.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCourse.Location = new System.Drawing.Point(26, 76);
            this.dgvCourse.Margin = new System.Windows.Forms.Padding(40, 40, 40, 40);
            this.dgvCourse.MultiSelect = false;
            this.dgvCourse.Name = "dgvCourse";
            this.dgvCourse.ReadOnly = true;
            this.dgvCourse.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCourse.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCourse.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(10, 20, 10, 20);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCourse.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCourse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCourse.Size = new System.Drawing.Size(442, 606);
            this.dgvCourse.TabIndex = 2;
            this.dgvCourse.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCourse_CellClick);
            this.dgvCourse.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCourse_CellDoubleClick);
            this.dgvCourse.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCourse_CellMouseEnter);
            this.dgvCourse.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCourse_CellMouseLeave);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnEdit.BackColor = System.Drawing.Color.Maroon;
            this.btnEdit.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnEdit.BorderRadius = 20;
            this.btnEdit.BorderSize = 0;
            this.btnEdit.ButtonColor = System.Drawing.Color.Maroon;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.HoverColor = System.Drawing.Color.DarkRed;
            this.btnEdit.Location = new System.Drawing.Point(837, 720);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(150, 40);
            this.btnEdit.TabIndex = 24;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextColor = System.Drawing.Color.White;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panelSubInfo, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(495, 709);
            this.tableLayoutPanel3.TabIndex = 26;
            // 
            // panelSubInfo
            // 
            this.panelSubInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSubInfo.BackColor = System.Drawing.Color.Transparent;
            this.panelSubInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.panelSubInfo.BorderRadius = 10;
            this.panelSubInfo.BorderThickness = 1;
            this.panelSubInfo.ContentBackColor = System.Drawing.Color.White;
            this.panelSubInfo.Controls.Add(this.roundedShadowPanel4);
            this.panelSubInfo.Controls.Add(this.btnCancel);
            this.panelSubInfo.Controls.Add(this.label3);
            this.panelSubInfo.Controls.Add(this.btnSave);
            this.panelSubInfo.Controls.Add(this.label5);
            this.panelSubInfo.Controls.Add(this.roundedShadowPanel5);
            this.panelSubInfo.EnableHoverEffect = false;
            this.panelSubInfo.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.panelSubInfo.HeaderFontSize = 16F;
            this.panelSubInfo.HeaderForeColor = System.Drawing.Color.Maroon;
            this.panelSubInfo.HeaderHeight = 45;
            this.panelSubInfo.HeaderLabel = "Course Information";
            this.panelSubInfo.IconHeader = null;
            this.panelSubInfo.IconSize = 22;
            this.panelSubInfo.Location = new System.Drawing.Point(3, 3);
            this.panelSubInfo.Name = "panelSubInfo";
            this.panelSubInfo.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelSubInfo.ShadowDepth = 6;
            this.panelSubInfo.ShadowPadding = 12;
            this.panelSubInfo.ShowHeaderDivider = true;
            this.panelSubInfo.ShowShadow = true;
            this.panelSubInfo.Size = new System.Drawing.Size(489, 348);
            this.panelSubInfo.TabIndex = 0;
            // 
            // roundedShadowPanel4
            // 
            this.roundedShadowPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedShadowPanel4.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel4.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel4.BorderRadius = 20;
            this.roundedShadowPanel4.BorderSize = 0;
            this.roundedShadowPanel4.Controls.Add(this.txtCrsCode);
            this.roundedShadowPanel4.Location = new System.Drawing.Point(33, 94);
            this.roundedShadowPanel4.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.roundedShadowPanel4.Name = "roundedShadowPanel4";
            this.roundedShadowPanel4.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel4.PanelImage = null;
            this.roundedShadowPanel4.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel4.ShadowDepth = 10;
            this.roundedShadowPanel4.ShadowEnabled = true;
            this.roundedShadowPanel4.ShadowShift = 5;
            this.roundedShadowPanel4.Size = new System.Drawing.Size(423, 64);
            this.roundedShadowPanel4.TabIndex = 23;
            // 
            // txtCrsCode
            // 
            this.txtCrsCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCrsCode.BackColor = System.Drawing.Color.LightGray;
            this.txtCrsCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCrsCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCrsCode.Location = new System.Drawing.Point(24, 21);
            this.txtCrsCode.Margin = new System.Windows.Forms.Padding(50, 30, 50, 30);
            this.txtCrsCode.Name = "txtCrsCode";
            this.txtCrsCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCrsCode.Size = new System.Drawing.Size(382, 19);
            this.txtCrsCode.TabIndex = 20;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.BackColor = System.Drawing.Color.Goldenrod;
            this.btnCancel.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancel.BorderRadius = 20;
            this.btnCancel.BorderSize = 0;
            this.btnCancel.ButtonColor = System.Drawing.Color.Goldenrod;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.HoverColor = System.Drawing.Color.DarkRed;
            this.btnCancel.Location = new System.Drawing.Point(254, 283);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(152, 40);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(53, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Code:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.BackColor = System.Drawing.Color.Goldenrod;
            this.btnSave.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSave.BorderRadius = 20;
            this.btnSave.BorderSize = 0;
            this.btnSave.ButtonColor = System.Drawing.Color.Goldenrod;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverColor = System.Drawing.Color.DarkRed;
            this.btnSave.Location = new System.Drawing.Point(82, 283);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(152, 40);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(53, 168);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Description:";
            // 
            // roundedShadowPanel5
            // 
            this.roundedShadowPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedShadowPanel5.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel5.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel5.BorderRadius = 20;
            this.roundedShadowPanel5.BorderSize = 0;
            this.roundedShadowPanel5.Controls.Add(this.txtSubDesc);
            this.roundedShadowPanel5.Location = new System.Drawing.Point(33, 197);
            this.roundedShadowPanel5.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.roundedShadowPanel5.Name = "roundedShadowPanel5";
            this.roundedShadowPanel5.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel5.PanelImage = null;
            this.roundedShadowPanel5.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel5.ShadowDepth = 10;
            this.roundedShadowPanel5.ShadowEnabled = true;
            this.roundedShadowPanel5.ShadowShift = 5;
            this.roundedShadowPanel5.Size = new System.Drawing.Size(423, 64);
            this.roundedShadowPanel5.TabIndex = 27;
            // 
            // txtSubDesc
            // 
            this.txtSubDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubDesc.BackColor = System.Drawing.Color.LightGray;
            this.txtSubDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubDesc.Location = new System.Drawing.Point(24, 21);
            this.txtSubDesc.Margin = new System.Windows.Forms.Padding(50, 30, 50, 30);
            this.txtSubDesc.Name = "txtSubDesc";
            this.txtSubDesc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSubDesc.Size = new System.Drawing.Size(377, 19);
            this.txtSubDesc.TabIndex = 20;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEdit, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.headerPanelCard1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(59, 191);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(50, 50, 50, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1002, 765);
            this.tableLayoutPanel1.TabIndex = 25;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // frmCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PUP_RMS.Properties.Resources._619384472_920609864259422_4656079368386240362_n;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1120, 1000);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCourse";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmCourse_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.roundedShadowPanel3.ResumeLayout(false);
            this.roundedShadowPanel3.PerformLayout();
            this.roundedShadowPanel1.ResumeLayout(false);
            this.roundedShadowPanel1.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.headerPanelCard1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourse)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panelSubInfo.ResumeLayout(false);
            this.panelSubInfo.PerformLayout();
            this.roundedShadowPanel4.ResumeLayout(false);
            this.roundedShadowPanel4.PerformLayout();
            this.roundedShadowPanel5.ResumeLayout(false);
            this.roundedShadowPanel5.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private RoundedButton btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private RoundedButton btnRefresh;
        private GradientLabel gradientLabel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private RoundedShadowPanel panelSearch;
        private RoundedShadowPanel roundedShadowPanel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxCurriculum;
        private RoundedShadowPanel roundedShadowPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxProgram;
        private CustomControls.HeaderPanelCard headerPanelCard1;
        private System.Windows.Forms.DataGridView dgvCourse;
        private RoundedButton btnEdit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private CustomControls.HeaderPanelCard panelSubInfo;
        private RoundedShadowPanel roundedShadowPanel4;
        private System.Windows.Forms.TextBox txtCrsCode;
        private RoundedButton btnCancel;
        private System.Windows.Forms.Label label3;
        private RoundedButton btnSave;
        private System.Windows.Forms.Label label5;
        private RoundedShadowPanel roundedShadowPanel5;
        private System.Windows.Forms.TextBox txtSubDesc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}