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
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gradientLabel1 = new GradientLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRefresh = new PUP_RMS.RoundedButton();
            this.panelSearch = new PUP_RMS.RoundedShadowPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new PUP_RMS.RoundedButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCreate = new PUP_RMS.RoundedButton();
            this.panelProginfo = new PUP_RMS.RoundedShadowPanel();
            this.btnCancel = new PUP_RMS.RoundedButton();
            this.btnSave = new PUP_RMS.RoundedButton();
            this.roundedShadowPanel5 = new PUP_RMS.RoundedShadowPanel();
            this.txtProgramDesc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.roundedShadowPanel4 = new PUP_RMS.RoundedShadowPanel();
            this.txtProgamCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.roundedShadowPanel6 = new PUP_RMS.RoundedShadowPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvProgram = new System.Windows.Forms.DataGridView();
            this.btnEdit = new PUP_RMS.RoundedButton();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panelProginfo.SuspendLayout();
            this.roundedShadowPanel5.SuspendLayout();
            this.roundedShadowPanel4.SuspendLayout();
            this.roundedShadowPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgram)).BeginInit();
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
            this.label10.Size = new System.Drawing.Size(279, 21);
            this.label10.TabIndex = 8;
            this.label10.Text = "Create and manage program records";
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.20462F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 138F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tableLayoutPanel1.Controls.Add(this.btnRefresh, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelSearch, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(59, 106);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1002, 64);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Maroon;
            this.btnRefresh.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnRefresh.BorderRadius = 20;
            this.btnRefresh.BorderSize = 0;
            this.btnRefresh.ButtonColor = System.Drawing.Color.Maroon;
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.HoverColor = System.Drawing.Color.DarkRed;
            this.btnRefresh.Location = new System.Drawing.Point(883, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(116, 58);
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
            this.panelSearch.Location = new System.Drawing.Point(10, 0);
            this.panelSearch.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.PanelColor = System.Drawing.Color.LightGray;
            this.panelSearch.PanelImage = null;
            this.panelSearch.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelSearch.ShadowDepth = 10;
            this.panelSearch.ShadowEnabled = true;
            this.panelSearch.ShadowShift = 5;
            this.panelSearch.Size = new System.Drawing.Size(722, 64);
            this.panelSearch.TabIndex = 23;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.LightGray;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(22, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSearch.Size = new System.Drawing.Size(675, 19);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Maroon;
            this.btnSearch.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSearch.BorderRadius = 20;
            this.btnSearch.BorderSize = 0;
            this.btnSearch.ButtonColor = System.Drawing.Color.Maroon;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.HoverColor = System.Drawing.Color.DarkRed;
            this.btnSearch.Location = new System.Drawing.Point(745, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(132, 57);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextColor = System.Drawing.Color.White;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.roundedShadowPanel6, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnEdit, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(59, 194);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(50, 25, 50, 50);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.82726F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.17274F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1002, 508);
            this.tableLayoutPanel2.TabIndex = 26;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnCreate, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panelProginfo, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.91304F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.08696F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(495, 450);
            this.tableLayoutPanel3.TabIndex = 26;
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCreate.BackColor = System.Drawing.Color.Maroon;
            this.btnCreate.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCreate.BorderRadius = 20;
            this.btnCreate.BorderSize = 0;
            this.btnCreate.ButtonColor = System.Drawing.Color.Maroon;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.HoverColor = System.Drawing.Color.DarkRed;
            this.btnCreate.Location = new System.Drawing.Point(133, 403);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCreate.Size = new System.Drawing.Size(228, 44);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Create Program";
            this.btnCreate.TextColor = System.Drawing.Color.White;
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // panelProginfo
            // 
            this.panelProginfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelProginfo.BackColor = System.Drawing.Color.Transparent;
            this.panelProginfo.BorderColor = System.Drawing.Color.Transparent;
            this.panelProginfo.BorderRadius = 20;
            this.panelProginfo.BorderSize = 0;
            this.panelProginfo.Controls.Add(this.btnCancel);
            this.panelProginfo.Controls.Add(this.btnSave);
            this.panelProginfo.Controls.Add(this.roundedShadowPanel5);
            this.panelProginfo.Controls.Add(this.label5);
            this.panelProginfo.Controls.Add(this.roundedShadowPanel4);
            this.panelProginfo.Controls.Add(this.label3);
            this.panelProginfo.Controls.Add(this.label2);
            this.panelProginfo.Enabled = false;
            this.panelProginfo.Location = new System.Drawing.Point(3, 3);
            this.panelProginfo.Margin = new System.Windows.Forms.Padding(3, 3, 25, 3);
            this.panelProginfo.Name = "panelProginfo";
            this.panelProginfo.PanelColor = System.Drawing.Color.White;
            this.panelProginfo.PanelImage = null;
            this.panelProginfo.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelProginfo.ShadowDepth = 10;
            this.panelProginfo.ShadowEnabled = true;
            this.panelProginfo.ShadowShift = 5;
            this.panelProginfo.Size = new System.Drawing.Size(467, 394);
            this.panelProginfo.TabIndex = 21;
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
            this.btnCancel.Location = new System.Drawing.Point(248, 324);
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
            this.btnSave.Location = new System.Drawing.Point(74, 324);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(152, 40);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // roundedShadowPanel5
            // 
            this.roundedShadowPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedShadowPanel5.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel5.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel5.BorderRadius = 20;
            this.roundedShadowPanel5.BorderSize = 0;
            this.roundedShadowPanel5.Controls.Add(this.txtProgramDesc);
            this.roundedShadowPanel5.Location = new System.Drawing.Point(31, 244);
            this.roundedShadowPanel5.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.roundedShadowPanel5.Name = "roundedShadowPanel5";
            this.roundedShadowPanel5.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel5.PanelImage = null;
            this.roundedShadowPanel5.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel5.ShadowDepth = 10;
            this.roundedShadowPanel5.ShadowEnabled = true;
            this.roundedShadowPanel5.ShadowShift = 5;
            this.roundedShadowPanel5.Size = new System.Drawing.Size(409, 64);
            this.roundedShadowPanel5.TabIndex = 27;
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
            this.txtProgramDesc.Size = new System.Drawing.Size(363, 19);
            this.txtProgramDesc.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(31, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Program Description:";
            // 
            // roundedShadowPanel4
            // 
            this.roundedShadowPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedShadowPanel4.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel4.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel4.BorderRadius = 20;
            this.roundedShadowPanel4.BorderSize = 0;
            this.roundedShadowPanel4.Controls.Add(this.txtProgamCode);
            this.roundedShadowPanel4.Location = new System.Drawing.Point(31, 121);
            this.roundedShadowPanel4.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.roundedShadowPanel4.Name = "roundedShadowPanel4";
            this.roundedShadowPanel4.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel4.PanelImage = null;
            this.roundedShadowPanel4.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel4.ShadowDepth = 10;
            this.roundedShadowPanel4.ShadowEnabled = true;
            this.roundedShadowPanel4.ShadowShift = 5;
            this.roundedShadowPanel4.Size = new System.Drawing.Size(409, 64);
            this.roundedShadowPanel4.TabIndex = 23;
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
            this.txtProgamCode.Size = new System.Drawing.Size(368, 19);
            this.txtProgamCode.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(31, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Program Code:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(19, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(279, 31);
            this.label2.TabIndex = 15;
            this.label2.Text = "Program Information";
            // 
            // roundedShadowPanel6
            // 
            this.roundedShadowPanel6.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel6.BorderColor = System.Drawing.Color.Black;
            this.roundedShadowPanel6.BorderRadius = 20;
            this.roundedShadowPanel6.BorderSize = 1;
            this.roundedShadowPanel6.Controls.Add(this.label7);
            this.roundedShadowPanel6.Controls.Add(this.dgvProgram);
            this.roundedShadowPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roundedShadowPanel6.Location = new System.Drawing.Point(526, 3);
            this.roundedShadowPanel6.Margin = new System.Windows.Forms.Padding(25, 3, 3, 3);
            this.roundedShadowPanel6.Name = "roundedShadowPanel6";
            this.roundedShadowPanel6.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel6.PanelImage = null;
            this.roundedShadowPanel6.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel6.ShadowDepth = 10;
            this.roundedShadowPanel6.ShadowEnabled = true;
            this.roundedShadowPanel6.ShadowShift = 5;
            this.roundedShadowPanel6.Size = new System.Drawing.Size(473, 450);
            this.roundedShadowPanel6.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(34, 18);
            this.label7.Margin = new System.Windows.Forms.Padding(20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 31);
            this.label7.TabIndex = 23;
            this.label7.Text = "Program List";
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
            this.dgvProgram.BackgroundColor = System.Drawing.SystemColors.Control;
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
            this.dgvProgram.Location = new System.Drawing.Point(40, 61);
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
            this.dgvProgram.Size = new System.Drawing.Size(393, 352);
            this.dgvProgram.TabIndex = 2;
            this.dgvProgram.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProgram_CellClick);
            this.dgvProgram.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProgram_CellMouseEnter);
            this.dgvProgram.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProgram_CellMouseLeave);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnEdit.Location = new System.Drawing.Point(812, 459);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(187, 46);
            this.btnEdit.TabIndex = 24;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextColor = System.Drawing.Color.White;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PUP_RMS.Properties.Resources._619384472_920609864259422_4656079368386240362_n;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1120, 749);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProgram";
            this.Text = "frmProgram";
            this.Load += new System.EventHandler(this.frmProgram_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panelProginfo.ResumeLayout(false);
            this.panelProginfo.PerformLayout();
            this.roundedShadowPanel5.ResumeLayout(false);
            this.roundedShadowPanel5.PerformLayout();
            this.roundedShadowPanel4.ResumeLayout(false);
            this.roundedShadowPanel4.PerformLayout();
            this.roundedShadowPanel6.ResumeLayout(false);
            this.roundedShadowPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GradientLabel gradientLabel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RoundedButton btnSearch;
        private RoundedShadowPanel panelSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private RoundedButton btnCreate;
        private RoundedShadowPanel panelProginfo;
        private RoundedButton btnCancel;
        private RoundedButton btnSave;
        private RoundedShadowPanel roundedShadowPanel5;
        private System.Windows.Forms.TextBox txtProgramDesc;
        private System.Windows.Forms.Label label5;
        private RoundedShadowPanel roundedShadowPanel4;
        private System.Windows.Forms.TextBox txtProgamCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private RoundedShadowPanel roundedShadowPanel6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvProgram;
        private RoundedButton btnEdit;
        private RoundedButton btnRefresh;
    }
}