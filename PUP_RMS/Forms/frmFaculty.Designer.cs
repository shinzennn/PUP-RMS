namespace PUP_RMS.Forms
{
    partial class frmFaculty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFaculty));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.gradientLabel1 = new GradientLabel();
            this.roundedShadowPanel1 = new PUP_RMS.RoundedShadowPanel();
            this.cbxProgram = new System.Windows.Forms.ComboBox();
            this.btnSearch = new PUP_RMS.RoundedButton();
            this.btnRefresh = new PUP_RMS.RoundedButton();
            this.panelSearch = new PUP_RMS.RoundedShadowPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnEdit = new PUP_RMS.RoundedButton();
            this.panelFacultyList = new PUP_RMS.RoundedPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvFaculty = new System.Windows.Forms.DataGridView();
            this.panelFacultyForm = new PUP_RMS.RoundedShadowPanel();
            this.btnCancel = new PUP_RMS.RoundedButton();
            this.btnSave = new PUP_RMS.RoundedButton();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreate = new PUP_RMS.RoundedButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.roundedShadowPanel1.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelFacultyList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaculty)).BeginInit();
            this.panelFacultyForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnEdit, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelFacultyList, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelFacultyForm, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCreate, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(59, 190);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1002, 569);
            this.tableLayoutPanel1.TabIndex = 17;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.Controls.Add(this.roundedShadowPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSearch, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnRefresh, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.panelSearch, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(59, 106);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(50);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1002, 64);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.gradientLabel1);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1120, 90);
            this.panel1.TabIndex = 19;
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
            this.label10.Text = "Create and manage faculty records";
            // 
            // gradientLabel1
            // 
            this.gradientLabel1.AutoSize = true;
            this.gradientLabel1.BackColor = System.Drawing.Color.Transparent;
            this.gradientLabel1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel1.Location = new System.Drawing.Point(24, 14);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Size = new System.Drawing.Size(293, 37);
            this.gradientLabel1.TabIndex = 9;
            this.gradientLabel1.Text = "Faculty Management ";
            // 
            // roundedShadowPanel1
            // 
            this.roundedShadowPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel1.BorderRadius = 20;
            this.roundedShadowPanel1.BorderSize = 0;
            this.roundedShadowPanel1.Controls.Add(this.cbxProgram);
            this.roundedShadowPanel1.Location = new System.Drawing.Point(10, 0);
            this.roundedShadowPanel1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.roundedShadowPanel1.Name = "roundedShadowPanel1";
            this.roundedShadowPanel1.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel1.PanelImage = null;
            this.roundedShadowPanel1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel1.ShadowDepth = 10;
            this.roundedShadowPanel1.ShadowEnabled = true;
            this.roundedShadowPanel1.ShadowShift = 5;
            this.roundedShadowPanel1.Size = new System.Drawing.Size(230, 64);
            this.roundedShadowPanel1.TabIndex = 18;
            // 
            // cbxProgram
            // 
            this.cbxProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxProgram.BackColor = System.Drawing.Color.LightGray;
            this.cbxProgram.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxProgram.FormattingEnabled = true;
            this.cbxProgram.Location = new System.Drawing.Point(19, 17);
            this.cbxProgram.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.cbxProgram.Name = "cbxProgram";
            this.cbxProgram.Size = new System.Drawing.Size(185, 28);
            this.cbxProgram.TabIndex = 16;
            this.cbxProgram.Text = "Program";
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
            this.btnSearch.Location = new System.Drawing.Point(759, 8);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(154, 48);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextColor = System.Drawing.Color.White;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
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
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(929, 8);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(65, 48);
            this.btnRefresh.TabIndex = 15;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextColor = System.Drawing.Color.White;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
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
            this.panelSearch.Location = new System.Drawing.Point(260, 0);
            this.panelSearch.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.PanelColor = System.Drawing.Color.LightGray;
            this.panelSearch.PanelImage = null;
            this.panelSearch.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelSearch.ShadowDepth = 10;
            this.panelSearch.ShadowEnabled = true;
            this.panelSearch.ShadowShift = 5;
            this.panelSearch.Size = new System.Drawing.Size(481, 64);
            this.panelSearch.TabIndex = 17;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.LightGray;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(30, 20);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSearch.Size = new System.Drawing.Size(421, 19);
            this.txtSearch.TabIndex = 14;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Right;
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
            this.btnEdit.Location = new System.Drawing.Point(795, 524);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(204, 40);
            this.btnEdit.TabIndex = 18;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextColor = System.Drawing.Color.White;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
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
            this.panelFacultyList.Controls.Add(this.label1);
            this.panelFacultyList.Controls.Add(this.dgvFaculty);
            this.panelFacultyList.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panelFacultyList.HoverBorderColor = System.Drawing.Color.Maroon;
            this.panelFacultyList.Location = new System.Drawing.Point(526, 3);
            this.panelFacultyList.Margin = new System.Windows.Forms.Padding(25, 3, 3, 3);
            this.panelFacultyList.Name = "panelFacultyList";
            this.panelFacultyList.ShadowBlur = 15;
            this.panelFacultyList.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelFacultyList.ShadowEnabled = true;
            this.panelFacultyList.ShadowOffset = 5;
            this.panelFacultyList.Size = new System.Drawing.Size(473, 513);
            this.panelFacultyList.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(34, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 31);
            this.label1.TabIndex = 13;
            this.label1.Text = "Faculty List";
            // 
            // dgvFaculty
            // 
            this.dgvFaculty.AllowUserToAddRows = false;
            this.dgvFaculty.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dgvFaculty.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFaculty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFaculty.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFaculty.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFaculty.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvFaculty.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFaculty.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFaculty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFaculty.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvFaculty.Location = new System.Drawing.Point(40, 67);
            this.dgvFaculty.Margin = new System.Windows.Forms.Padding(40);
            this.dgvFaculty.Name = "dgvFaculty";
            this.dgvFaculty.ReadOnly = true;
            this.dgvFaculty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFaculty.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFaculty.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(10, 20, 10, 20);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFaculty.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFaculty.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFaculty.Size = new System.Drawing.Size(393, 406);
            this.dgvFaculty.TabIndex = 12;
            this.dgvFaculty.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFaculty_CellClick);
            this.dgvFaculty.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFaculty_CellMouseEnter);
            this.dgvFaculty.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFaculty_CellMouseLeave);
            // 
            // panelFacultyForm
            // 
            this.panelFacultyForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFacultyForm.BackColor = System.Drawing.Color.Transparent;
            this.panelFacultyForm.BorderColor = System.Drawing.Color.Transparent;
            this.panelFacultyForm.BorderRadius = 20;
            this.panelFacultyForm.BorderSize = 0;
            this.panelFacultyForm.Controls.Add(this.btnCancel);
            this.panelFacultyForm.Controls.Add(this.btnSave);
            this.panelFacultyForm.Controls.Add(this.txtLastName);
            this.panelFacultyForm.Controls.Add(this.txtMiddleName);
            this.panelFacultyForm.Controls.Add(this.txtFirstName);
            this.panelFacultyForm.Controls.Add(this.label5);
            this.panelFacultyForm.Controls.Add(this.label4);
            this.panelFacultyForm.Controls.Add(this.label3);
            this.panelFacultyForm.Controls.Add(this.label2);
            this.panelFacultyForm.Enabled = false;
            this.panelFacultyForm.Location = new System.Drawing.Point(3, 3);
            this.panelFacultyForm.Margin = new System.Windows.Forms.Padding(3, 3, 25, 3);
            this.panelFacultyForm.Name = "panelFacultyForm";
            this.panelFacultyForm.PanelColor = System.Drawing.Color.White;
            this.panelFacultyForm.PanelImage = null;
            this.panelFacultyForm.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelFacultyForm.ShadowDepth = 10;
            this.panelFacultyForm.ShadowEnabled = true;
            this.panelFacultyForm.ShadowShift = 5;
            this.panelFacultyForm.Size = new System.Drawing.Size(473, 513);
            this.panelFacultyForm.TabIndex = 17;
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
            this.btnCancel.Location = new System.Drawing.Point(248, 442);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(152, 40);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.btnSave.Location = new System.Drawing.Point(74, 442);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(152, 40);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(50, 307);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(50, 30, 50, 30);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLastName.Size = new System.Drawing.Size(373, 26);
            this.txtLastName.TabIndex = 20;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMiddleName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiddleName.Location = new System.Drawing.Point(50, 221);
            this.txtMiddleName.Margin = new System.Windows.Forms.Padding(50, 30, 50, 30);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMiddleName.Size = new System.Drawing.Size(373, 26);
            this.txtMiddleName.TabIndex = 19;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(50, 135);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(50, 30, 50, 30);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFirstName.Size = new System.Drawing.Size(373, 26);
            this.txtFirstName.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(46, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Last Name:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Middle Name:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(25, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 31);
            this.label2.TabIndex = 14;
            this.label2.Text = "Faculty Information";
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreate.BackColor = System.Drawing.Color.Maroon;
            this.btnCreate.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCreate.BorderRadius = 20;
            this.btnCreate.BorderSize = 0;
            this.btnCreate.ButtonColor = System.Drawing.Color.Maroon;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.HoverColor = System.Drawing.Color.DarkRed;
            this.btnCreate.Location = new System.Drawing.Point(148, 524);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(204, 40);
            this.btnCreate.TabIndex = 13;
            this.btnCreate.Text = "Create";
            this.btnCreate.TextColor = System.Drawing.Color.White;
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // frmFaculty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 818);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFaculty";
            this.Text = "frmFaculty";
            this.Load += new System.EventHandler(this.frmFaculty_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.roundedShadowPanel1.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelFacultyList.ResumeLayout(false);
            this.panelFacultyList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaculty)).EndInit();
            this.panelFacultyForm.ResumeLayout(false);
            this.panelFacultyForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedButton btnRefresh;
        private RoundedButton btnCreate;
        private System.Windows.Forms.DataGridView dgvFaculty;
        private RoundedButton btnSearch;
        private RoundedPanel panelFacultyList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox cbxProgram;
        private RoundedShadowPanel panelFacultyForm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private RoundedButton btnSave;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.TextBox txtFirstName;
        private RoundedButton btnEdit;
        private System.Windows.Forms.Panel panel1;
        private GradientLabel gradientLabel1;
        private System.Windows.Forms.Label label10;
        private RoundedButton btnCancel;
        private RoundedShadowPanel panelSearch;
        private RoundedShadowPanel roundedShadowPanel1;
    }
}