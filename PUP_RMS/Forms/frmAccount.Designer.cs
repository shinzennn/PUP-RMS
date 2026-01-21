namespace PUP_RMS.Forms
{
    partial class frmAccount
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.gradientLabel1 = new GradientLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelAccountInfo = new PUP_RMS.RoundedShadowPanel();
            this.btnCancelAccount = new PUP_RMS.RoundedButton();
            this.btnSaveAccountInfo = new PUP_RMS.RoundedButton();
            this.roundedShadowPanel6 = new PUP_RMS.RoundedShadowPanel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.roundedShadowPanel5 = new PUP_RMS.RoundedShadowPanel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.roundedShadowPanel2 = new PUP_RMS.RoundedShadowPanel();
            this.btnEditAccountInfo = new PUP_RMS.RoundedButton();
            this.gradientLabel3 = new GradientLabel();
            this.panelProfileInfo = new PUP_RMS.RoundedShadowPanel();
            this.btnCancelProfile = new PUP_RMS.RoundedButton();
            this.btnSaveProfileInfo = new PUP_RMS.RoundedButton();
            this.roundedShadowPanel4 = new PUP_RMS.RoundedShadowPanel();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.roundedShadowPanel3 = new PUP_RMS.RoundedShadowPanel();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.roundedShadowPanel1 = new PUP_RMS.RoundedShadowPanel();
            this.btnEditProfileInfo = new PUP_RMS.RoundedButton();
            this.gradientLabel2 = new GradientLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCreateAccount = new PUP_RMS.RoundedButton();
            this.btnAccountList = new PUP_RMS.RoundedButton();
            this.btnActivityLog = new PUP_RMS.RoundedButton();
            this.panelHeader.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelAccountInfo.SuspendLayout();
            this.roundedShadowPanel6.SuspendLayout();
            this.roundedShadowPanel5.SuspendLayout();
            this.roundedShadowPanel2.SuspendLayout();
            this.panelProfileInfo.SuspendLayout();
            this.roundedShadowPanel4.SuspendLayout();
            this.roundedShadowPanel3.SuspendLayout();
            this.roundedShadowPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
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
            this.panelHeader.TabIndex = 20;
            // 
            // gradientLabel1
            // 
            this.gradientLabel1.AutoSize = true;
            this.gradientLabel1.BackColor = System.Drawing.Color.Transparent;
            this.gradientLabel1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel1.Location = new System.Drawing.Point(24, 14);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Size = new System.Drawing.Size(307, 37);
            this.gradientLabel1.TabIndex = 9;
            this.gradientLabel1.Text = "Account Management ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(27, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(273, 21);
            this.label10.TabIndex = 8;
            this.label10.Text = "Create and manage account records";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelAccountInfo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelProfileInfo, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(59, 181);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 776);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // panelAccountInfo
            // 
            this.panelAccountInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAccountInfo.BackColor = System.Drawing.Color.Transparent;
            this.panelAccountInfo.BorderColor = System.Drawing.Color.Transparent;
            this.panelAccountInfo.BorderRadius = 20;
            this.panelAccountInfo.BorderSize = 0;
            this.panelAccountInfo.Controls.Add(this.btnCancelAccount);
            this.panelAccountInfo.Controls.Add(this.btnSaveAccountInfo);
            this.panelAccountInfo.Controls.Add(this.roundedShadowPanel6);
            this.panelAccountInfo.Controls.Add(this.roundedShadowPanel5);
            this.panelAccountInfo.Controls.Add(this.label4);
            this.panelAccountInfo.Controls.Add(this.label3);
            this.panelAccountInfo.Controls.Add(this.roundedShadowPanel2);
            this.panelAccountInfo.Location = new System.Drawing.Point(3, 391);
            this.panelAccountInfo.Name = "panelAccountInfo";
            this.panelAccountInfo.PanelColor = System.Drawing.Color.White;
            this.panelAccountInfo.PanelImage = null;
            this.panelAccountInfo.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelAccountInfo.ShadowDepth = 10;
            this.panelAccountInfo.ShadowEnabled = true;
            this.panelAccountInfo.ShadowShift = 5;
            this.panelAccountInfo.Size = new System.Drawing.Size(994, 332);
            this.panelAccountInfo.TabIndex = 1;
            // 
            // btnCancelAccount
            // 
            this.btnCancelAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelAccount.BackColor = System.Drawing.Color.Goldenrod;
            this.btnCancelAccount.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancelAccount.BorderRadius = 20;
            this.btnCancelAccount.BorderSize = 0;
            this.btnCancelAccount.ButtonColor = System.Drawing.Color.Maroon;
            this.btnCancelAccount.FlatAppearance.BorderSize = 0;
            this.btnCancelAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelAccount.ForeColor = System.Drawing.Color.White;
            this.btnCancelAccount.HoverColor = System.Drawing.Color.DarkRed;
            this.btnCancelAccount.Location = new System.Drawing.Point(815, 273);
            this.btnCancelAccount.Name = "btnCancelAccount";
            this.btnCancelAccount.Size = new System.Drawing.Size(70, 35);
            this.btnCancelAccount.TabIndex = 13;
            this.btnCancelAccount.Text = "Cancel";
            this.btnCancelAccount.TextColor = System.Drawing.Color.White;
            this.btnCancelAccount.UseVisualStyleBackColor = false;
            this.btnCancelAccount.Visible = false;
            this.btnCancelAccount.Click += new System.EventHandler(this.btnCancelAccount_Click);
            // 
            // btnSaveAccountInfo
            // 
            this.btnSaveAccountInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAccountInfo.BackColor = System.Drawing.Color.Goldenrod;
            this.btnSaveAccountInfo.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSaveAccountInfo.BorderRadius = 20;
            this.btnSaveAccountInfo.BorderSize = 0;
            this.btnSaveAccountInfo.ButtonColor = System.Drawing.Color.Maroon;
            this.btnSaveAccountInfo.FlatAppearance.BorderSize = 0;
            this.btnSaveAccountInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAccountInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAccountInfo.ForeColor = System.Drawing.Color.White;
            this.btnSaveAccountInfo.HoverColor = System.Drawing.Color.DarkRed;
            this.btnSaveAccountInfo.Location = new System.Drawing.Point(900, 273);
            this.btnSaveAccountInfo.Name = "btnSaveAccountInfo";
            this.btnSaveAccountInfo.Size = new System.Drawing.Size(70, 35);
            this.btnSaveAccountInfo.TabIndex = 12;
            this.btnSaveAccountInfo.Text = "Save";
            this.btnSaveAccountInfo.TextColor = System.Drawing.Color.White;
            this.btnSaveAccountInfo.UseVisualStyleBackColor = false;
            this.btnSaveAccountInfo.Visible = false;
            this.btnSaveAccountInfo.Click += new System.EventHandler(this.btnSaveAccountInfo_Click);
            // 
            // roundedShadowPanel6
            // 
            this.roundedShadowPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedShadowPanel6.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel6.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel6.BorderRadius = 20;
            this.roundedShadowPanel6.BorderSize = 0;
            this.roundedShadowPanel6.Controls.Add(this.txtPassword);
            this.roundedShadowPanel6.Location = new System.Drawing.Point(585, 112);
            this.roundedShadowPanel6.Name = "roundedShadowPanel6";
            this.roundedShadowPanel6.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel6.PanelImage = null;
            this.roundedShadowPanel6.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel6.ShadowDepth = 10;
            this.roundedShadowPanel6.ShadowEnabled = true;
            this.roundedShadowPanel6.ShadowShift = 5;
            this.roundedShadowPanel6.Size = new System.Drawing.Size(300, 70);
            this.roundedShadowPanel6.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.LightGray;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Enabled = false;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(20, 24);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(20);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(260, 19);
            this.txtPassword.TabIndex = 0;
            // 
            // roundedShadowPanel5
            // 
            this.roundedShadowPanel5.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel5.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel5.BorderRadius = 20;
            this.roundedShadowPanel5.BorderSize = 0;
            this.roundedShadowPanel5.Controls.Add(this.txtUsername);
            this.roundedShadowPanel5.Location = new System.Drawing.Point(95, 112);
            this.roundedShadowPanel5.Name = "roundedShadowPanel5";
            this.roundedShadowPanel5.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel5.PanelImage = null;
            this.roundedShadowPanel5.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel5.ShadowDepth = 10;
            this.roundedShadowPanel5.ShadowEnabled = true;
            this.roundedShadowPanel5.ShadowShift = 5;
            this.roundedShadowPanel5.Size = new System.Drawing.Size(300, 70);
            this.roundedShadowPanel5.TabIndex = 4;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.LightGray;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Enabled = false;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(20, 24);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(20);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(260, 19);
            this.txtUsername.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(602, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(112, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Username:";
            // 
            // roundedShadowPanel2
            // 
            this.roundedShadowPanel2.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel2.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel2.BorderRadius = 20;
            this.roundedShadowPanel2.BorderSize = 0;
            this.roundedShadowPanel2.Controls.Add(this.btnEditAccountInfo);
            this.roundedShadowPanel2.Controls.Add(this.gradientLabel3);
            this.roundedShadowPanel2.Location = new System.Drawing.Point(0, 0);
            this.roundedShadowPanel2.Name = "roundedShadowPanel2";
            this.roundedShadowPanel2.PanelColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.roundedShadowPanel2.PanelImage = null;
            this.roundedShadowPanel2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel2.ShadowDepth = 10;
            this.roundedShadowPanel2.ShadowEnabled = true;
            this.roundedShadowPanel2.ShadowShift = 5;
            this.roundedShadowPanel2.Size = new System.Drawing.Size(994, 80);
            this.roundedShadowPanel2.TabIndex = 1;
            // 
            // btnEditAccountInfo
            // 
            this.btnEditAccountInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditAccountInfo.BackColor = System.Drawing.Color.Goldenrod;
            this.btnEditAccountInfo.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnEditAccountInfo.BorderRadius = 20;
            this.btnEditAccountInfo.BorderSize = 0;
            this.btnEditAccountInfo.ButtonColor = System.Drawing.Color.Goldenrod;
            this.btnEditAccountInfo.FlatAppearance.BorderSize = 0;
            this.btnEditAccountInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditAccountInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditAccountInfo.ForeColor = System.Drawing.Color.White;
            this.btnEditAccountInfo.HoverColor = System.Drawing.Color.DarkRed;
            this.btnEditAccountInfo.Location = new System.Drawing.Point(890, 19);
            this.btnEditAccountInfo.Name = "btnEditAccountInfo";
            this.btnEditAccountInfo.Size = new System.Drawing.Size(80, 40);
            this.btnEditAccountInfo.TabIndex = 11;
            this.btnEditAccountInfo.Text = "Edit";
            this.btnEditAccountInfo.TextColor = System.Drawing.Color.White;
            this.btnEditAccountInfo.UseVisualStyleBackColor = false;
            this.btnEditAccountInfo.Click += new System.EventHandler(this.btnEditAccountInfo_Click);
            // 
            // gradientLabel3
            // 
            this.gradientLabel3.AutoSize = true;
            this.gradientLabel3.BackColor = System.Drawing.Color.Transparent;
            this.gradientLabel3.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel3.Location = new System.Drawing.Point(26, 19);
            this.gradientLabel3.Name = "gradientLabel3";
            this.gradientLabel3.Size = new System.Drawing.Size(291, 37);
            this.gradientLabel3.TabIndex = 10;
            this.gradientLabel3.Text = "Account Information ";
            // 
            // panelProfileInfo
            // 
            this.panelProfileInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelProfileInfo.BackColor = System.Drawing.Color.Transparent;
            this.panelProfileInfo.BorderColor = System.Drawing.Color.Transparent;
            this.panelProfileInfo.BorderRadius = 20;
            this.panelProfileInfo.BorderSize = 0;
            this.panelProfileInfo.Controls.Add(this.btnCancelProfile);
            this.panelProfileInfo.Controls.Add(this.btnSaveProfileInfo);
            this.panelProfileInfo.Controls.Add(this.roundedShadowPanel4);
            this.panelProfileInfo.Controls.Add(this.roundedShadowPanel3);
            this.panelProfileInfo.Controls.Add(this.label2);
            this.panelProfileInfo.Controls.Add(this.label1);
            this.panelProfileInfo.Controls.Add(this.roundedShadowPanel1);
            this.panelProfileInfo.Location = new System.Drawing.Point(3, 3);
            this.panelProfileInfo.Name = "panelProfileInfo";
            this.panelProfileInfo.PanelColor = System.Drawing.Color.White;
            this.panelProfileInfo.PanelImage = null;
            this.panelProfileInfo.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelProfileInfo.ShadowDepth = 10;
            this.panelProfileInfo.ShadowEnabled = true;
            this.panelProfileInfo.ShadowShift = 5;
            this.panelProfileInfo.Size = new System.Drawing.Size(994, 332);
            this.panelProfileInfo.TabIndex = 0;
            // 
            // btnCancelProfile
            // 
            this.btnCancelProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelProfile.BackColor = System.Drawing.Color.Goldenrod;
            this.btnCancelProfile.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancelProfile.BorderRadius = 20;
            this.btnCancelProfile.BorderSize = 0;
            this.btnCancelProfile.ButtonColor = System.Drawing.Color.Maroon;
            this.btnCancelProfile.FlatAppearance.BorderSize = 0;
            this.btnCancelProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelProfile.ForeColor = System.Drawing.Color.White;
            this.btnCancelProfile.HoverColor = System.Drawing.Color.DarkRed;
            this.btnCancelProfile.Location = new System.Drawing.Point(815, 274);
            this.btnCancelProfile.Name = "btnCancelProfile";
            this.btnCancelProfile.Size = new System.Drawing.Size(70, 35);
            this.btnCancelProfile.TabIndex = 15;
            this.btnCancelProfile.Text = "Cancel";
            this.btnCancelProfile.TextColor = System.Drawing.Color.White;
            this.btnCancelProfile.UseVisualStyleBackColor = false;
            this.btnCancelProfile.Visible = false;
            this.btnCancelProfile.Click += new System.EventHandler(this.btnCancelProfile_Click);
            // 
            // btnSaveProfileInfo
            // 
            this.btnSaveProfileInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveProfileInfo.BackColor = System.Drawing.Color.Goldenrod;
            this.btnSaveProfileInfo.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSaveProfileInfo.BorderRadius = 20;
            this.btnSaveProfileInfo.BorderSize = 0;
            this.btnSaveProfileInfo.ButtonColor = System.Drawing.Color.Maroon;
            this.btnSaveProfileInfo.FlatAppearance.BorderSize = 0;
            this.btnSaveProfileInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveProfileInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveProfileInfo.ForeColor = System.Drawing.Color.White;
            this.btnSaveProfileInfo.HoverColor = System.Drawing.Color.DarkRed;
            this.btnSaveProfileInfo.Location = new System.Drawing.Point(900, 274);
            this.btnSaveProfileInfo.Name = "btnSaveProfileInfo";
            this.btnSaveProfileInfo.Size = new System.Drawing.Size(70, 35);
            this.btnSaveProfileInfo.TabIndex = 14;
            this.btnSaveProfileInfo.Text = "Save";
            this.btnSaveProfileInfo.TextColor = System.Drawing.Color.White;
            this.btnSaveProfileInfo.UseVisualStyleBackColor = false;
            this.btnSaveProfileInfo.Visible = false;
            this.btnSaveProfileInfo.Click += new System.EventHandler(this.btnSaveProfileInfo_Click);
            // 
            // roundedShadowPanel4
            // 
            this.roundedShadowPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedShadowPanel4.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel4.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel4.BorderRadius = 20;
            this.roundedShadowPanel4.BorderSize = 0;
            this.roundedShadowPanel4.Controls.Add(this.txtLastName);
            this.roundedShadowPanel4.Location = new System.Drawing.Point(585, 111);
            this.roundedShadowPanel4.Name = "roundedShadowPanel4";
            this.roundedShadowPanel4.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel4.PanelImage = null;
            this.roundedShadowPanel4.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel4.ShadowDepth = 10;
            this.roundedShadowPanel4.ShadowEnabled = true;
            this.roundedShadowPanel4.ShadowShift = 5;
            this.roundedShadowPanel4.Size = new System.Drawing.Size(300, 70);
            this.roundedShadowPanel4.TabIndex = 4;
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.BackColor = System.Drawing.Color.LightGray;
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLastName.Enabled = false;
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(20, 24);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(20);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(260, 19);
            this.txtLastName.TabIndex = 0;
            // 
            // roundedShadowPanel3
            // 
            this.roundedShadowPanel3.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel3.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel3.BorderRadius = 20;
            this.roundedShadowPanel3.BorderSize = 0;
            this.roundedShadowPanel3.Controls.Add(this.txtFirstName);
            this.roundedShadowPanel3.Location = new System.Drawing.Point(95, 111);
            this.roundedShadowPanel3.Name = "roundedShadowPanel3";
            this.roundedShadowPanel3.PanelColor = System.Drawing.Color.LightGray;
            this.roundedShadowPanel3.PanelImage = null;
            this.roundedShadowPanel3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel3.ShadowDepth = 10;
            this.roundedShadowPanel3.ShadowEnabled = true;
            this.roundedShadowPanel3.ShadowShift = 5;
            this.roundedShadowPanel3.Size = new System.Drawing.Size(300, 70);
            this.roundedShadowPanel3.TabIndex = 3;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.LightGray;
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFirstName.Enabled = false;
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(20, 24);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(20);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(260, 19);
            this.txtFirstName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(602, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(112, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "First Name:";
            // 
            // roundedShadowPanel1
            // 
            this.roundedShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.roundedShadowPanel1.BorderRadius = 20;
            this.roundedShadowPanel1.BorderSize = 0;
            this.roundedShadowPanel1.Controls.Add(this.btnEditProfileInfo);
            this.roundedShadowPanel1.Controls.Add(this.gradientLabel2);
            this.roundedShadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.roundedShadowPanel1.Name = "roundedShadowPanel1";
            this.roundedShadowPanel1.PanelColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(16)))), ((int)(((byte)(10)))));
            this.roundedShadowPanel1.PanelImage = null;
            this.roundedShadowPanel1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.roundedShadowPanel1.ShadowDepth = 10;
            this.roundedShadowPanel1.ShadowEnabled = true;
            this.roundedShadowPanel1.ShadowShift = 5;
            this.roundedShadowPanel1.Size = new System.Drawing.Size(994, 80);
            this.roundedShadowPanel1.TabIndex = 0;
            // 
            // btnEditProfileInfo
            // 
            this.btnEditProfileInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditProfileInfo.BackColor = System.Drawing.Color.Goldenrod;
            this.btnEditProfileInfo.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnEditProfileInfo.BorderRadius = 20;
            this.btnEditProfileInfo.BorderSize = 0;
            this.btnEditProfileInfo.ButtonColor = System.Drawing.Color.Goldenrod;
            this.btnEditProfileInfo.FlatAppearance.BorderSize = 0;
            this.btnEditProfileInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditProfileInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditProfileInfo.ForeColor = System.Drawing.Color.White;
            this.btnEditProfileInfo.HoverColor = System.Drawing.Color.DarkRed;
            this.btnEditProfileInfo.Location = new System.Drawing.Point(890, 19);
            this.btnEditProfileInfo.Name = "btnEditProfileInfo";
            this.btnEditProfileInfo.Size = new System.Drawing.Size(80, 40);
            this.btnEditProfileInfo.TabIndex = 12;
            this.btnEditProfileInfo.Text = "Edit";
            this.btnEditProfileInfo.TextColor = System.Drawing.Color.White;
            this.btnEditProfileInfo.UseVisualStyleBackColor = false;
            this.btnEditProfileInfo.Click += new System.EventHandler(this.btnEditProfileInfo_Click);
            // 
            // gradientLabel2
            // 
            this.gradientLabel2.AutoSize = true;
            this.gradientLabel2.BackColor = System.Drawing.Color.Transparent;
            this.gradientLabel2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradientLabel2.Location = new System.Drawing.Point(26, 19);
            this.gradientLabel2.Name = "gradientLabel2";
            this.gradientLabel2.Size = new System.Drawing.Size(272, 37);
            this.gradientLabel2.TabIndex = 10;
            this.gradientLabel2.Text = "Profile Information ";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel2.Controls.Add(this.btnCreateAccount, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAccountList, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnActivityLog, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(59, 112);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(50);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1000, 50);
            this.tableLayoutPanel2.TabIndex = 22;
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateAccount.BackColor = System.Drawing.Color.Maroon;
            this.btnCreateAccount.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCreateAccount.BorderRadius = 20;
            this.btnCreateAccount.BorderSize = 0;
            this.btnCreateAccount.ButtonColor = System.Drawing.Color.Maroon;
            this.btnCreateAccount.FlatAppearance.BorderSize = 0;
            this.btnCreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateAccount.ForeColor = System.Drawing.Color.White;
            this.btnCreateAccount.HoverColor = System.Drawing.Color.DarkRed;
            this.btnCreateAccount.Location = new System.Drawing.Point(7, 7);
            this.btnCreateAccount.Margin = new System.Windows.Forms.Padding(7);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(86, 36);
            this.btnCreateAccount.TabIndex = 0;
            this.btnCreateAccount.Text = "Create Account";
            this.btnCreateAccount.TextColor = System.Drawing.Color.White;
            this.btnCreateAccount.UseVisualStyleBackColor = false;
            this.btnCreateAccount.Visible = false;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // btnAccountList
            // 
            this.btnAccountList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccountList.BackColor = System.Drawing.Color.Maroon;
            this.btnAccountList.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAccountList.BorderRadius = 20;
            this.btnAccountList.BorderSize = 0;
            this.btnAccountList.ButtonColor = System.Drawing.Color.Maroon;
            this.btnAccountList.FlatAppearance.BorderSize = 0;
            this.btnAccountList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccountList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccountList.ForeColor = System.Drawing.Color.White;
            this.btnAccountList.HoverColor = System.Drawing.Color.DarkRed;
            this.btnAccountList.Location = new System.Drawing.Point(107, 7);
            this.btnAccountList.Margin = new System.Windows.Forms.Padding(7);
            this.btnAccountList.Name = "btnAccountList";
            this.btnAccountList.Size = new System.Drawing.Size(86, 36);
            this.btnAccountList.TabIndex = 1;
            this.btnAccountList.Text = "View Account List";
            this.btnAccountList.TextColor = System.Drawing.Color.White;
            this.btnAccountList.UseVisualStyleBackColor = false;
            this.btnAccountList.Visible = false;
            this.btnAccountList.Click += new System.EventHandler(this.btnAccountList_Click);
            // 
            // btnActivityLog
            // 
            this.btnActivityLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActivityLog.BackColor = System.Drawing.Color.Maroon;
            this.btnActivityLog.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnActivityLog.BorderRadius = 20;
            this.btnActivityLog.BorderSize = 0;
            this.btnActivityLog.ButtonColor = System.Drawing.Color.Maroon;
            this.btnActivityLog.FlatAppearance.BorderSize = 0;
            this.btnActivityLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivityLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivityLog.ForeColor = System.Drawing.Color.White;
            this.btnActivityLog.HoverColor = System.Drawing.Color.DarkRed;
            this.btnActivityLog.Location = new System.Drawing.Point(207, 7);
            this.btnActivityLog.Margin = new System.Windows.Forms.Padding(7);
            this.btnActivityLog.Name = "btnActivityLog";
            this.btnActivityLog.Size = new System.Drawing.Size(86, 36);
            this.btnActivityLog.TabIndex = 2;
            this.btnActivityLog.Text = "View Activity Logs";
            this.btnActivityLog.TextColor = System.Drawing.Color.White;
            this.btnActivityLog.UseVisualStyleBackColor = false;
            this.btnActivityLog.Visible = false;
            this.btnActivityLog.Click += new System.EventHandler(this.btnActivityLog_Click);
            // 
            // frmAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PUP_RMS.Properties.Resources._619384472_920609864259422_4656079368386240362_n;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1120, 1000);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAccount";
            this.Text = "frmAccount";
            this.Load += new System.EventHandler(this.frmAccount_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelAccountInfo.ResumeLayout(false);
            this.panelAccountInfo.PerformLayout();
            this.roundedShadowPanel6.ResumeLayout(false);
            this.roundedShadowPanel6.PerformLayout();
            this.roundedShadowPanel5.ResumeLayout(false);
            this.roundedShadowPanel5.PerformLayout();
            this.roundedShadowPanel2.ResumeLayout(false);
            this.roundedShadowPanel2.PerformLayout();
            this.panelProfileInfo.ResumeLayout(false);
            this.panelProfileInfo.PerformLayout();
            this.roundedShadowPanel4.ResumeLayout(false);
            this.roundedShadowPanel4.PerformLayout();
            this.roundedShadowPanel3.ResumeLayout(false);
            this.roundedShadowPanel3.PerformLayout();
            this.roundedShadowPanel1.ResumeLayout(false);
            this.roundedShadowPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private GradientLabel gradientLabel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private RoundedButton btnCreateAccount;
        private RoundedShadowPanel panelProfileInfo;
        private RoundedButton btnAccountList;
        private RoundedButton btnActivityLog;
        private RoundedShadowPanel panelAccountInfo;
        private RoundedShadowPanel roundedShadowPanel1;
        private GradientLabel gradientLabel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private RoundedShadowPanel roundedShadowPanel2;
        private GradientLabel gradientLabel3;
        private RoundedShadowPanel roundedShadowPanel3;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private RoundedShadowPanel roundedShadowPanel4;
        private System.Windows.Forms.TextBox txtLastName;
        private RoundedShadowPanel roundedShadowPanel6;
        private System.Windows.Forms.TextBox txtPassword;
        private RoundedShadowPanel roundedShadowPanel5;
        private System.Windows.Forms.TextBox txtUsername;
        private RoundedButton btnEditAccountInfo;
        private RoundedButton btnEditProfileInfo;
        private RoundedButton btnCancelAccount;
        private RoundedButton btnSaveAccountInfo;
        private RoundedButton btnCancelProfile;
        private RoundedButton btnSaveProfileInfo;
    }
}