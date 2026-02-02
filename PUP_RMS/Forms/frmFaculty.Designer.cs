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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnEdit = new PUP_RMS.RoundedButton();
            this.tableLayoutForm = new System.Windows.Forms.TableLayoutPanel();
            this.panelFacultyForm = new PUP_RMS.CustomControls.HeaderPanelCard();
            this.tableLayoutName = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.roundedShadowPanel3 = new PUP_RMS.RoundedShadowPanel();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.roundedShadowPanel2 = new PUP_RMS.RoundedShadowPanel();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCreate = new PUP_RMS.RoundedButton();
            this.roundedShadowPanel4 = new PUP_RMS.RoundedShadowPanel();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.btnCancel = new PUP_RMS.RoundedButton();
            this.btnSave = new PUP_RMS.RoundedButton();
            this.label3 = new System.Windows.Forms.Label();
            this.headerPanelFacultyList = new PUP_RMS.CustomControls.HeaderPanelCard();
            this.dgvFaculty = new System.Windows.Forms.DataGridView();
            this.tableLayoutSearch = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new PUP_RMS.RoundedButton();
            this.btnRefresh = new PUP_RMS.RoundedButton();
            this.panelSearch = new PUP_RMS.RoundedShadowPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gradientLabel1 = new GradientLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.tableLayoutMain.SuspendLayout();
            this.tableLayoutForm.SuspendLayout();
            this.panelFacultyForm.SuspendLayout();
            this.tableLayoutName.SuspendLayout();
            this.roundedShadowPanel3.SuspendLayout();
            this.roundedShadowPanel2.SuspendLayout();
            this.roundedShadowPanel4.SuspendLayout();
            this.headerPanelFacultyList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaculty)).BeginInit();
            this.tableLayoutSearch.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutMain.Controls.Add(this.btnEdit, 1, 1);
            this.tableLayoutMain.Controls.Add(this.tableLayoutForm, 0, 0);
            this.tableLayoutMain.Controls.Add(this.headerPanelFacultyList, 1, 0);
            this.tableLayoutMain.Location = new System.Drawing.Point(59, 191);
            this.tableLayoutMain.Margin = new System.Windows.Forms.Padding(50);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 2;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutMain.Size = new System.Drawing.Size(1002, 765);
            this.tableLayoutMain.TabIndex = 17;
            this.tableLayoutMain.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
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
            this.btnEdit.TabIndex = 18;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextColor = System.Drawing.Color.White;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // tableLayoutForm
            // 
            this.tableLayoutForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutForm.ColumnCount = 1;
            this.tableLayoutForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutForm.Controls.Add(this.panelFacultyForm, 0, 0);
            this.tableLayoutForm.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutForm.Name = "tableLayoutForm";
            this.tableLayoutForm.RowCount = 2;
            this.tableLayoutForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutForm.Size = new System.Drawing.Size(495, 709);
            this.tableLayoutForm.TabIndex = 19;
            // 
            // panelFacultyForm
            // 
            this.panelFacultyForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFacultyForm.BackColor = System.Drawing.Color.Transparent;
            this.panelFacultyForm.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.panelFacultyForm.BorderRadius = 10;
            this.panelFacultyForm.BorderThickness = 1;
            this.panelFacultyForm.ContentBackColor = System.Drawing.Color.White;
            this.panelFacultyForm.Controls.Add(this.tableLayoutName);
            this.panelFacultyForm.Controls.Add(this.btnCreate);
            this.panelFacultyForm.Controls.Add(this.roundedShadowPanel4);
            this.panelFacultyForm.Controls.Add(this.btnCancel);
            this.panelFacultyForm.Controls.Add(this.btnSave);
            this.panelFacultyForm.Controls.Add(this.label3);
            this.panelFacultyForm.EnableHoverEffect = false;
            this.panelFacultyForm.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.panelFacultyForm.HeaderFontSize = 16F;
            this.panelFacultyForm.HeaderForeColor = System.Drawing.Color.Maroon;
            this.panelFacultyForm.HeaderHeight = 45;
            this.panelFacultyForm.HeaderLabel = "Faculty Information";
            this.panelFacultyForm.IconHeader = null;
            this.panelFacultyForm.IconSize = 22;
            this.panelFacultyForm.Location = new System.Drawing.Point(3, 3);
            this.panelFacultyForm.Name = "panelFacultyForm";
            this.panelFacultyForm.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelFacultyForm.ShadowDepth = 10;
            this.panelFacultyForm.ShadowPadding = 12;
            this.panelFacultyForm.ShowHeaderDivider = true;
            this.panelFacultyForm.ShowShadow = true;
            this.panelFacultyForm.Size = new System.Drawing.Size(489, 348);
            this.panelFacultyForm.TabIndex = 0;
            // 
            // tableLayoutName
            // 
            this.tableLayoutName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutName.ColumnCount = 2;
            this.tableLayoutName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutName.Controls.Add(this.label4, 0, 0);
            this.tableLayoutName.Controls.Add(this.roundedShadowPanel3, 0, 1);
            this.tableLayoutName.Controls.Add(this.roundedShadowPanel2, 1, 1);
            this.tableLayoutName.Controls.Add(this.label5, 1, 0);
            this.tableLayoutName.Location = new System.Drawing.Point(24, 163);
            this.tableLayoutName.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutName.Name = "tableLayoutName";
            this.tableLayoutName.RowCount = 2;
            this.tableLayoutName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutName.Size = new System.Drawing.Size(441, 100);
            this.tableLayoutName.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(30, 10, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "Middle Name:";
            // 
            // roundedShadowPanel3
            // 
            this.roundedShadowPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedShadowPanel3.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel3.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel3.BorderRadius = 20;
            this.roundedShadowPanel3.BorderSize = 0;
            this.roundedShadowPanel3.Controls.Add(this.txtMiddleName);
            this.roundedShadowPanel3.Location = new System.Drawing.Point(10, 35);
            this.roundedShadowPanel3.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.roundedShadowPanel3.Name = "roundedShadowPanel3";
            this.roundedShadowPanel3.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel3.PanelImage = null;
            this.roundedShadowPanel3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel3.ShadowDepth = 10;
            this.roundedShadowPanel3.ShadowEnabled = true;
            this.roundedShadowPanel3.ShadowShift = 5;
            this.roundedShadowPanel3.Size = new System.Drawing.Size(200, 64);
            this.roundedShadowPanel3.TabIndex = 21;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMiddleName.BackColor = System.Drawing.Color.LightGray;
            this.txtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMiddleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiddleName.Location = new System.Drawing.Point(24, 21);
            this.txtMiddleName.Margin = new System.Windows.Forms.Padding(50, 30, 50, 30);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMiddleName.Size = new System.Drawing.Size(154, 19);
            this.txtMiddleName.TabIndex = 20;
            this.txtMiddleName.TextChanged += new System.EventHandler(this.txtMiddleName_TextChanged);
            // 
            // roundedShadowPanel2
            // 
            this.roundedShadowPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedShadowPanel2.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel2.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel2.BorderRadius = 20;
            this.roundedShadowPanel2.BorderSize = 0;
            this.roundedShadowPanel2.Controls.Add(this.txtLastName);
            this.roundedShadowPanel2.Location = new System.Drawing.Point(230, 35);
            this.roundedShadowPanel2.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.roundedShadowPanel2.Name = "roundedShadowPanel2";
            this.roundedShadowPanel2.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel2.PanelImage = null;
            this.roundedShadowPanel2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel2.ShadowDepth = 10;
            this.roundedShadowPanel2.ShadowEnabled = true;
            this.roundedShadowPanel2.ShadowShift = 5;
            this.roundedShadowPanel2.Size = new System.Drawing.Size(201, 64);
            this.roundedShadowPanel2.TabIndex = 18;
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.BackColor = System.Drawing.Color.LightGray;
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(24, 21);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(50, 30, 50, 30);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLastName.Size = new System.Drawing.Size(155, 19);
            this.txtLastName.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(250, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(30, 10, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 18);
            this.label5.TabIndex = 17;
            this.label5.Text = "Last Name:";
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
            this.btnCreate.Location = new System.Drawing.Point(194, 282);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(100, 40);
            this.btnCreate.TabIndex = 13;
            this.btnCreate.Text = "Create";
            this.btnCreate.TextColor = System.Drawing.Color.White;
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // roundedShadowPanel4
            // 
            this.roundedShadowPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedShadowPanel4.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel4.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel4.BorderRadius = 20;
            this.roundedShadowPanel4.BorderSize = 0;
            this.roundedShadowPanel4.Controls.Add(this.txtFirstName);
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
            this.roundedShadowPanel4.TabIndex = 21;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.BackColor = System.Drawing.Color.LightGray;
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(24, 21);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(50, 30, 50, 30);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFirstName.Size = new System.Drawing.Size(377, 19);
            this.txtFirstName.TabIndex = 20;
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
            this.btnCancel.Location = new System.Drawing.Point(253, 282);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
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
            this.btnSave.Location = new System.Drawing.Point(135, 282);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(53, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "First Name:";
            // 
            // headerPanelFacultyList
            // 
            this.headerPanelFacultyList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerPanelFacultyList.BackColor = System.Drawing.Color.Transparent;
            this.headerPanelFacultyList.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.headerPanelFacultyList.BorderRadius = 10;
            this.headerPanelFacultyList.BorderThickness = 1;
            this.headerPanelFacultyList.ContentBackColor = System.Drawing.Color.White;
            this.headerPanelFacultyList.Controls.Add(this.dgvFaculty);
            this.headerPanelFacultyList.EnableHoverEffect = false;
            this.headerPanelFacultyList.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.headerPanelFacultyList.HeaderFontSize = 16F;
            this.headerPanelFacultyList.HeaderForeColor = System.Drawing.Color.Maroon;
            this.headerPanelFacultyList.HeaderHeight = 45;
            this.headerPanelFacultyList.HeaderLabel = "Faculty List";
            this.headerPanelFacultyList.IconHeader = null;
            this.headerPanelFacultyList.IconSize = 22;
            this.headerPanelFacultyList.Location = new System.Drawing.Point(504, 3);
            this.headerPanelFacultyList.Name = "headerPanelFacultyList";
            this.headerPanelFacultyList.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.headerPanelFacultyList.ShadowDepth = 6;
            this.headerPanelFacultyList.ShadowPadding = 12;
            this.headerPanelFacultyList.ShowHeaderDivider = true;
            this.headerPanelFacultyList.ShowShadow = true;
            this.headerPanelFacultyList.Size = new System.Drawing.Size(495, 709);
            this.headerPanelFacultyList.TabIndex = 20;
            // 
            // dgvFaculty
            // 
            this.dgvFaculty.AllowUserToAddRows = false;
            this.dgvFaculty.AllowUserToDeleteRows = false;
            this.dgvFaculty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFaculty.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFaculty.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFaculty.BackgroundColor = System.Drawing.Color.White;
            this.dgvFaculty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFaculty.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvFaculty.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFaculty.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFaculty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFaculty.EnableHeadersVisualStyles = false;
            this.dgvFaculty.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvFaculty.Location = new System.Drawing.Point(26, 76);
            this.dgvFaculty.Margin = new System.Windows.Forms.Padding(40);
            this.dgvFaculty.Name = "dgvFaculty";
            this.dgvFaculty.ReadOnly = true;
            this.dgvFaculty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFaculty.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFaculty.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10, 20, 10, 20);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFaculty.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFaculty.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFaculty.Size = new System.Drawing.Size(442, 608);
            this.dgvFaculty.TabIndex = 12;
            this.dgvFaculty.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFaculty_CellClick);
            this.dgvFaculty.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFaculty_CellMouseEnter);
            this.dgvFaculty.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFaculty_CellMouseLeave);
            // 
            // tableLayoutSearch
            // 
            this.tableLayoutSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutSearch.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutSearch.ColumnCount = 3;
            this.tableLayoutSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutSearch.Controls.Add(this.btnSearch, 1, 0);
            this.tableLayoutSearch.Controls.Add(this.btnRefresh, 2, 0);
            this.tableLayoutSearch.Controls.Add(this.panelSearch, 0, 0);
            this.tableLayoutSearch.Location = new System.Drawing.Point(59, 106);
            this.tableLayoutSearch.Margin = new System.Windows.Forms.Padding(50);
            this.tableLayoutSearch.Name = "tableLayoutSearch";
            this.tableLayoutSearch.RowCount = 1;
            this.tableLayoutSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutSearch.Size = new System.Drawing.Size(1002, 64);
            this.tableLayoutSearch.TabIndex = 18;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.Maroon;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
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
            this.btnSearch.Margin = new System.Windows.Forms.Padding(8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 48);
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
            this.btnRefresh.Location = new System.Drawing.Point(910, 8);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(84, 48);
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
            this.panelSearch.Location = new System.Drawing.Point(10, 0);
            this.panelSearch.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.PanelColor = System.Drawing.Color.White;
            this.panelSearch.PanelImage = null;
            this.panelSearch.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelSearch.ShadowDepth = 10;
            this.panelSearch.ShadowEnabled = true;
            this.panelSearch.ShadowShift = 5;
            this.panelSearch.Size = new System.Drawing.Size(782, 64);
            this.panelSearch.TabIndex = 17;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(30, 20);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSearch.Size = new System.Drawing.Size(722, 19);
            this.txtSearch.TabIndex = 14;
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
            this.panel1.TabIndex = 19;
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
            // frmFaculty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PUP_RMS.Properties.Resources._619384472_920609864259422_4656079368386240362_n;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1120, 1000);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutSearch);
            this.Controls.Add(this.tableLayoutMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFaculty";
            this.Text = "frmFaculty";
            this.Load += new System.EventHandler(this.frmFaculty_Load);
            this.tableLayoutMain.ResumeLayout(false);
            this.tableLayoutForm.ResumeLayout(false);
            this.panelFacultyForm.ResumeLayout(false);
            this.panelFacultyForm.PerformLayout();
            this.tableLayoutName.ResumeLayout(false);
            this.tableLayoutName.PerformLayout();
            this.roundedShadowPanel3.ResumeLayout(false);
            this.roundedShadowPanel3.PerformLayout();
            this.roundedShadowPanel2.ResumeLayout(false);
            this.roundedShadowPanel2.PerformLayout();
            this.roundedShadowPanel4.ResumeLayout(false);
            this.roundedShadowPanel4.PerformLayout();
            this.headerPanelFacultyList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaculty)).EndInit();
            this.tableLayoutSearch.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedButton btnRefresh;
        private RoundedButton btnCreate;
        private System.Windows.Forms.DataGridView dgvFaculty;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearch;
        private RoundedButton btnSave;
        private System.Windows.Forms.TextBox txtLastName;
        private RoundedButton btnEdit;
        private System.Windows.Forms.Panel panel1;
        private GradientLabel gradientLabel1;
        private System.Windows.Forms.Label label10;
        private RoundedButton btnCancel;
        private RoundedShadowPanel panelSearch;
        private RoundedShadowPanel roundedShadowPanel3;
        private System.Windows.Forms.TextBox txtMiddleName;
        private RoundedShadowPanel roundedShadowPanel2;
        private RoundedShadowPanel roundedShadowPanel4;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutForm;
        private CustomControls.HeaderPanelCard panelFacultyForm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutName;
        private CustomControls.HeaderPanelCard headerPanelFacultyList;
        private RoundedButton btnSearch;
    }
}