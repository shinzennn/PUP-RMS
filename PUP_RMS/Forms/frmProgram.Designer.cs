namespace PUP_RMS.Forms
{
    partial class frmProgram
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
            this.btnEdit = new PUP_RMS.RoundedButton();
            this.dgvProgram = new System.Windows.Forms.DataGridView();
            this.btnCancel = new PUP_RMS.RoundedButton();
            this.btnSave = new PUP_RMS.RoundedButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.roundedShadowPanel3 = new PUP_RMS.RoundedShadowPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxCurriculum = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new PUP_RMS.RoundedButton();
            this.panelSearch = new PUP_RMS.RoundedShadowPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new PUP_RMS.RoundedButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gradientLabel1 = new GradientLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutForm = new System.Windows.Forms.TableLayoutPanel();
            this.panelProginfo = new PUP_RMS.CustomControls.HeaderPanelCard();
            this.roundedShadowPanel1 = new PUP_RMS.RoundedShadowPanel();
            this.txtProgamCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.roundedShadowPanel2 = new PUP_RMS.RoundedShadowPanel();
            this.txtProgramDesc = new System.Windows.Forms.TextBox();
            this.headerPanelCard1 = new PUP_RMS.CustomControls.HeaderPanelCard();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgram)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.roundedShadowPanel3.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutMain.SuspendLayout();
            this.tableLayoutForm.SuspendLayout();
            this.panelProginfo.SuspendLayout();
            this.roundedShadowPanel1.SuspendLayout();
            this.roundedShadowPanel2.SuspendLayout();
            this.headerPanelCard1.SuspendLayout();
            this.SuspendLayout();
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
            this.btnEdit.Location = new System.Drawing.Point(837, 720);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(150, 40);
            this.btnEdit.TabIndex = 24;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextColor = System.Drawing.Color.White;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dgvProgram
            // 
            this.dgvProgram.AllowUserToAddRows = false;
            this.dgvProgram.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dgvProgram.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProgram.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProgram.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProgram.BackgroundColor = System.Drawing.Color.White;
            this.dgvProgram.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProgram.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvProgram.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProgram.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProgram.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProgram.ColumnHeadersVisible = false;
            this.dgvProgram.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvProgram.Location = new System.Drawing.Point(26, 76);
            this.dgvProgram.Margin = new System.Windows.Forms.Padding(40);
            this.dgvProgram.MultiSelect = false;
            this.dgvProgram.Name = "dgvProgram";
            this.dgvProgram.ReadOnly = true;
            this.dgvProgram.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProgram.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProgram.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(10, 20, 10, 20);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProgram.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProgram.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProgram.Size = new System.Drawing.Size(442, 604);
            this.dgvProgram.TabIndex = 2;
            this.dgvProgram.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProgram_CellClick);
            this.dgvProgram.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProgram_CellMouseEnter);
            this.dgvProgram.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProgram_CellMouseLeave);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
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
            this.btnCancel.Location = new System.Drawing.Point(254, 282);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(152, 40);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
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
            this.btnSave.Location = new System.Drawing.Point(82, 282);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(152, 40);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.54499F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.45501F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.roundedShadowPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRefresh, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelSearch, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(59, 106);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(25, 15, 25, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1002, 64);
            this.tableLayoutPanel1.TabIndex = 22;
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
            this.roundedShadowPanel3.Size = new System.Drawing.Size(234, 64);
            this.roundedShadowPanel3.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 20);
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
            this.cbxCurriculum.Location = new System.Drawing.Point(109, 17);
            this.cbxCurriculum.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.cbxCurriculum.Name = "cbxCurriculum";
            this.cbxCurriculum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbxCurriculum.Size = new System.Drawing.Size(103, 28);
            this.cbxCurriculum.TabIndex = 16;
            this.cbxCurriculum.SelectedIndexChanged += new System.EventHandler(this.cbxCurriculum_SelectedIndexChanged);
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
            this.btnRefresh.Location = new System.Drawing.Point(909, 8);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(85, 48);
            this.btnRefresh.TabIndex = 27;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextColor = System.Drawing.Color.White;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.Transparent;
            this.panelSearch.BorderColor = System.Drawing.Color.Transparent;
            this.panelSearch.BorderRadius = 20;
            this.panelSearch.BorderSize = 0;
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSearch.Location = new System.Drawing.Point(254, 0);
            this.panelSearch.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.PanelColor = System.Drawing.Color.LightGray;
            this.panelSearch.PanelImage = null;
            this.panelSearch.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelSearch.ShadowDepth = 10;
            this.panelSearch.ShadowEnabled = true;
            this.panelSearch.ShadowShift = 5;
            this.panelSearch.Size = new System.Drawing.Size(537, 64);
            this.panelSearch.TabIndex = 23;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.LightGray;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(22, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSearch.Size = new System.Drawing.Size(510, 19);
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
            this.btnSearch.Location = new System.Drawing.Point(809, 8);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 48);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextColor = System.Drawing.Color.White;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.panel1.Controls.Add(this.gradientLabel1);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1120, 90);
            this.panel1.TabIndex = 21;
            // 
            // gradientLabel1
            // 
            this.gradientLabel1.AutoSize = true;
            this.gradientLabel1.BackColor = System.Drawing.Color.Transparent;
            this.gradientLabel1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel1.Location = new System.Drawing.Point(24, 14);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Size = new System.Drawing.Size(315, 37);
            this.gradientLabel1.TabIndex = 9;
            this.gradientLabel1.Text = "Program Management ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(27, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(279, 21);
            this.label10.TabIndex = 8;
            this.label10.Text = "Create and manage program records";
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutMain.AutoSize = true;
            this.tableLayoutMain.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutMain.ColumnCount = 2;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutMain.Controls.Add(this.tableLayoutForm, 0, 0);
            this.tableLayoutMain.Controls.Add(this.btnEdit, 1, 1);
            this.tableLayoutMain.Controls.Add(this.headerPanelCard1, 1, 0);
            this.tableLayoutMain.Location = new System.Drawing.Point(59, 191);
            this.tableLayoutMain.Margin = new System.Windows.Forms.Padding(50);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 2;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutMain.Size = new System.Drawing.Size(1002, 765);
            this.tableLayoutMain.TabIndex = 25;
            // 
            // tableLayoutForm
            // 
            this.tableLayoutForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutForm.ColumnCount = 1;
            this.tableLayoutForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutForm.Controls.Add(this.panelProginfo, 0, 0);
            this.tableLayoutForm.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutForm.Name = "tableLayoutForm";
            this.tableLayoutForm.RowCount = 2;
            this.tableLayoutForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutForm.Size = new System.Drawing.Size(495, 709);
            this.tableLayoutForm.TabIndex = 19;
            // 
            // panelProginfo
            // 
            this.panelProginfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelProginfo.BackColor = System.Drawing.Color.Transparent;
            this.panelProginfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.panelProginfo.BorderRadius = 10;
            this.panelProginfo.BorderThickness = 1;
            this.panelProginfo.ContentBackColor = System.Drawing.Color.White;
            this.panelProginfo.Controls.Add(this.btnSave);
            this.panelProginfo.Controls.Add(this.btnCancel);
            this.panelProginfo.Controls.Add(this.roundedShadowPanel1);
            this.panelProginfo.Controls.Add(this.label1);
            this.panelProginfo.Controls.Add(this.label2);
            this.panelProginfo.Controls.Add(this.roundedShadowPanel2);
            this.panelProginfo.EnableHoverEffect = false;
            this.panelProginfo.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.panelProginfo.HeaderFontSize = 16F;
            this.panelProginfo.HeaderForeColor = System.Drawing.Color.Maroon;
            this.panelProginfo.HeaderHeight = 45;
            this.panelProginfo.HeaderLabel = "Program Information";
            this.panelProginfo.IconHeader = null;
            this.panelProginfo.IconSize = 22;
            this.panelProginfo.Location = new System.Drawing.Point(3, 3);
            this.panelProginfo.Name = "panelProginfo";
            this.panelProginfo.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelProginfo.ShadowDepth = 6;
            this.panelProginfo.ShadowPadding = 12;
            this.panelProginfo.ShowHeaderDivider = true;
            this.panelProginfo.ShowShadow = true;
            this.panelProginfo.Size = new System.Drawing.Size(489, 348);
            this.panelProginfo.TabIndex = 0;
            // 
            // roundedShadowPanel1
            // 
            this.roundedShadowPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel1.BorderRadius = 20;
            this.roundedShadowPanel1.BorderSize = 0;
            this.roundedShadowPanel1.Controls.Add(this.txtProgamCode);
            this.roundedShadowPanel1.Location = new System.Drawing.Point(33, 94);
            this.roundedShadowPanel1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.roundedShadowPanel1.Name = "roundedShadowPanel1";
            this.roundedShadowPanel1.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel1.PanelImage = null;
            this.roundedShadowPanel1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel1.ShadowDepth = 10;
            this.roundedShadowPanel1.ShadowEnabled = true;
            this.roundedShadowPanel1.ShadowShift = 5;
            this.roundedShadowPanel1.Size = new System.Drawing.Size(423, 64);
            this.roundedShadowPanel1.TabIndex = 29;
            // 
            // txtProgamCode
            // 
            this.txtProgamCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProgamCode.BackColor = System.Drawing.Color.LightGray;
            this.txtProgamCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProgamCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProgamCode.Location = new System.Drawing.Point(24, 21);
            this.txtProgamCode.Margin = new System.Windows.Forms.Padding(50, 30, 50, 30);
            this.txtProgamCode.Name = "txtProgamCode";
            this.txtProgamCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtProgamCode.Size = new System.Drawing.Size(382, 19);
            this.txtProgamCode.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(53, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Code:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(53, 168);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "Description:";
            // 
            // roundedShadowPanel2
            // 
            this.roundedShadowPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedShadowPanel2.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel2.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel2.BorderRadius = 20;
            this.roundedShadowPanel2.BorderSize = 0;
            this.roundedShadowPanel2.Controls.Add(this.txtProgramDesc);
            this.roundedShadowPanel2.Location = new System.Drawing.Point(33, 197);
            this.roundedShadowPanel2.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.roundedShadowPanel2.Name = "roundedShadowPanel2";
            this.roundedShadowPanel2.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel2.PanelImage = null;
            this.roundedShadowPanel2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel2.ShadowDepth = 10;
            this.roundedShadowPanel2.ShadowEnabled = true;
            this.roundedShadowPanel2.ShadowShift = 5;
            this.roundedShadowPanel2.Size = new System.Drawing.Size(423, 64);
            this.roundedShadowPanel2.TabIndex = 31;
            // 
            // txtProgramDesc
            // 
            this.txtProgramDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProgramDesc.BackColor = System.Drawing.Color.LightGray;
            this.txtProgramDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProgramDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProgramDesc.Location = new System.Drawing.Point(24, 21);
            this.txtProgramDesc.Margin = new System.Windows.Forms.Padding(50, 30, 50, 30);
            this.txtProgramDesc.Name = "txtProgramDesc";
            this.txtProgramDesc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtProgramDesc.Size = new System.Drawing.Size(377, 19);
            this.txtProgramDesc.TabIndex = 20;
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
            this.headerPanelCard1.Controls.Add(this.dgvProgram);
            this.headerPanelCard1.EnableHoverEffect = false;
            this.headerPanelCard1.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.headerPanelCard1.HeaderFontSize = 16F;
            this.headerPanelCard1.HeaderForeColor = System.Drawing.Color.Maroon;
            this.headerPanelCard1.HeaderHeight = 45;
            this.headerPanelCard1.HeaderLabel = "Program List";
            this.headerPanelCard1.IconHeader = null;
            this.headerPanelCard1.IconSize = 22;
            this.headerPanelCard1.Location = new System.Drawing.Point(504, 3);
            this.headerPanelCard1.Name = "headerPanelCard1";
            this.headerPanelCard1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.headerPanelCard1.ShadowDepth = 6;
            this.headerPanelCard1.ShadowPadding = 12;
            this.headerPanelCard1.ShowHeaderDivider = true;
            this.headerPanelCard1.ShowShadow = true;
            this.headerPanelCard1.Size = new System.Drawing.Size(495, 709);
            this.headerPanelCard1.TabIndex = 25;
            // 
            // frmProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PUP_RMS.Properties.Resources._619384472_920609864259422_4656079368386240362_n;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1120, 1000);
            this.Controls.Add(this.tableLayoutMain);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProgram";
            this.Text = "frmProgram";
            this.Load += new System.EventHandler(this.frmProgram_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgram)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.roundedShadowPanel3.ResumeLayout(false);
            this.roundedShadowPanel3.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutMain.ResumeLayout(false);
            this.tableLayoutForm.ResumeLayout(false);
            this.panelProginfo.ResumeLayout(false);
            this.panelProginfo.PerformLayout();
            this.roundedShadowPanel1.ResumeLayout(false);
            this.roundedShadowPanel1.PerformLayout();
            this.roundedShadowPanel2.ResumeLayout(false);
            this.roundedShadowPanel2.PerformLayout();
            this.headerPanelCard1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private RoundedButton btnSave;
        private RoundedButton btnCancel;
        private System.Windows.Forms.DataGridView dgvProgram;
        private RoundedButton btnEdit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RoundedShadowPanel roundedShadowPanel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxCurriculum;
        private RoundedButton btnRefresh;
        private RoundedShadowPanel panelSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private RoundedButton btnSearch;
        private System.Windows.Forms.Panel panel1;
        private GradientLabel gradientLabel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutForm;
        private CustomControls.HeaderPanelCard panelProginfo;
        private RoundedShadowPanel roundedShadowPanel1;
        private System.Windows.Forms.TextBox txtProgamCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private RoundedShadowPanel roundedShadowPanel2;
        private System.Windows.Forms.TextBox txtProgramDesc;
        private CustomControls.HeaderPanelCard headerPanelCard1;
    }
}