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
            this.pnlQueue = new PUP_RMS.CustomControls.HeaderPanelCard();
            this.uploadBtn = new PUP_RMS.RoundedButton();
            this.toUpload = new System.Windows.Forms.ListView();
            this.toUploadMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAll = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlGradesheetForm = new PUP_RMS.CustomControls.HeaderPanelCard();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.undoBtn = new PUP_RMS.RoundedButton();
            this.saveBtn = new PUP_RMS.RoundedButton();
            this.viewBtn = new PUP_RMS.RoundedButton();
            this.imagePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.currentImage = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.professorCmbox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pageCmbox = new System.Windows.Forms.ComboBox();
            this.KeepCheckbox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.programCmbox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.curriculumCmbox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.yearLevelCmbox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.semesterCmbox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.yearCmbox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.sectionCmbox = new System.Windows.Forms.ComboBox();
            this.courseCmbox = new System.Windows.Forms.ComboBox();
            this.filenameTxtbox = new System.Windows.Forms.TextBox();
            this.btnOpenCouse = new System.Windows.Forms.Button();
            this.createNewFaculty = new System.Windows.Forms.Button();
            this.cbxKeep = new System.Windows.Forms.CheckBox();
            this.panelHeader.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.pnlQueue.SuspendLayout();
            this.toUploadMenu.SuspendLayout();
            this.pnlGradesheetForm.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.imagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentImage)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tableLayoutPanel3.Controls.Add(this.pnlQueue, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.pnlGradesheetForm, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(31, 118);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(25);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1055, 848);
            this.tableLayoutPanel3.TabIndex = 25;
            this.tableLayoutPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel3_Paint);
            // 
            // pnlQueue
            // 
            this.pnlQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlQueue.BackColor = System.Drawing.Color.Transparent;
            this.pnlQueue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.pnlQueue.BorderRadius = 10;
            this.pnlQueue.BorderThickness = 1;
            this.pnlQueue.ContentBackColor = System.Drawing.Color.White;
            this.pnlQueue.Controls.Add(this.uploadBtn);
            this.pnlQueue.Controls.Add(this.toUpload);
            this.pnlQueue.EnableHoverEffect = false;
            this.pnlQueue.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.pnlQueue.HeaderFontSize = 16F;
            this.pnlQueue.HeaderForeColor = System.Drawing.Color.Maroon;
            this.pnlQueue.HeaderHeight = 45;
            this.pnlQueue.HeaderLabel = "Image Queue";
            this.pnlQueue.IconHeader = null;
            this.pnlQueue.IconSize = 22;
            this.pnlQueue.Location = new System.Drawing.Point(741, 3);
            this.pnlQueue.Name = "pnlQueue";
            this.pnlQueue.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlQueue.ShadowDepth = 6;
            this.pnlQueue.ShadowPadding = 12;
            this.pnlQueue.ShowHeaderDivider = true;
            this.pnlQueue.ShowShadow = true;
            this.pnlQueue.Size = new System.Drawing.Size(311, 842);
            this.pnlQueue.TabIndex = 26;
            // 
            // uploadBtn
            // 
            this.uploadBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.uploadBtn.BackColor = System.Drawing.Color.Maroon;
            this.uploadBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.uploadBtn.BorderRadius = 20;
            this.uploadBtn.BorderSize = 0;
            this.uploadBtn.ButtonColor = System.Drawing.Color.Maroon;
            this.uploadBtn.FlatAppearance.BorderSize = 0;
            this.uploadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uploadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadBtn.ForeColor = System.Drawing.Color.White;
            this.uploadBtn.HoverColor = System.Drawing.Color.DarkRed;
            this.uploadBtn.Location = new System.Drawing.Point(80, 775);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(150, 40);
            this.uploadBtn.TabIndex = 7;
            this.uploadBtn.Text = "Upload";
            this.uploadBtn.TextColor = System.Drawing.Color.White;
            this.uploadBtn.UseVisualStyleBackColor = false;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            // 
            // toUpload
            // 
            this.toUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toUpload.ContextMenuStrip = this.toUploadMenu;
            this.toUpload.HideSelection = false;
            this.toUpload.Location = new System.Drawing.Point(28, 68);
            this.toUpload.Margin = new System.Windows.Forms.Padding(5);
            this.toUpload.Name = "toUpload";
            this.toUpload.Size = new System.Drawing.Size(255, 700);
            this.toUpload.TabIndex = 6;
            this.toUpload.UseCompatibleStateImageBehavior = false;
            // 
            // toUploadMenu
            // 
            this.toUploadMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toUploadMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeItemMenu,
            this.removeAll});
            this.toUploadMenu.Name = "contextMenuStrip1";
            this.toUploadMenu.Size = new System.Drawing.Size(135, 48);
            // 
            // removeItemMenu
            // 
            this.removeItemMenu.Name = "removeItemMenu";
            this.removeItemMenu.Size = new System.Drawing.Size(134, 22);
            this.removeItemMenu.Text = "Remove";
            // 
            // removeAll
            // 
            this.removeAll.Name = "removeAll";
            this.removeAll.Size = new System.Drawing.Size(134, 22);
            this.removeAll.Text = "Remove All";
            this.removeAll.Click += new System.EventHandler(this.removeAll_Click);
            // 
            // pnlGradesheetForm
            // 
            this.pnlGradesheetForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGradesheetForm.BackColor = System.Drawing.Color.Transparent;
            this.pnlGradesheetForm.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.pnlGradesheetForm.BorderRadius = 10;
            this.pnlGradesheetForm.BorderThickness = 1;
            this.pnlGradesheetForm.ContentBackColor = System.Drawing.Color.White;
            this.pnlGradesheetForm.Controls.Add(this.tableLayoutPanel4);
            this.pnlGradesheetForm.Controls.Add(this.imagePanel);
            this.pnlGradesheetForm.Controls.Add(this.tableLayoutPanel1);
            this.pnlGradesheetForm.Controls.Add(this.filenameTxtbox);
            this.pnlGradesheetForm.EnableHoverEffect = false;
            this.pnlGradesheetForm.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.pnlGradesheetForm.HeaderFontSize = 16F;
            this.pnlGradesheetForm.HeaderForeColor = System.Drawing.Color.Maroon;
            this.pnlGradesheetForm.HeaderHeight = 45;
            this.pnlGradesheetForm.HeaderLabel = "Enter Gradesheet Details:";
            this.pnlGradesheetForm.IconHeader = null;
            this.pnlGradesheetForm.IconSize = 22;
            this.pnlGradesheetForm.Location = new System.Drawing.Point(3, 3);
            this.pnlGradesheetForm.Name = "pnlGradesheetForm";
            this.pnlGradesheetForm.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlGradesheetForm.ShadowDepth = 6;
            this.pnlGradesheetForm.ShadowPadding = 12;
            this.pnlGradesheetForm.ShowHeaderDivider = true;
            this.pnlGradesheetForm.ShowShadow = true;
            this.pnlGradesheetForm.Size = new System.Drawing.Size(732, 842);
            this.pnlGradesheetForm.TabIndex = 26;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.undoBtn, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.saveBtn, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.viewBtn, 2, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(28, 775);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(680, 41);
            this.tableLayoutPanel4.TabIndex = 27;
            // 
            // undoBtn
            // 
            this.undoBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.undoBtn.BackColor = System.Drawing.Color.Maroon;
            this.undoBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.undoBtn.BorderRadius = 20;
            this.undoBtn.BorderSize = 0;
            this.undoBtn.ButtonColor = System.Drawing.Color.Maroon;
            this.undoBtn.FlatAppearance.BorderSize = 0;
            this.undoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.undoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.undoBtn.ForeColor = System.Drawing.Color.White;
            this.undoBtn.HoverColor = System.Drawing.Color.DarkRed;
            this.undoBtn.Location = new System.Drawing.Point(73, 3);
            this.undoBtn.Name = "undoBtn";
            this.undoBtn.Size = new System.Drawing.Size(150, 35);
            this.undoBtn.TabIndex = 0;
            this.undoBtn.Text = "Undo";
            this.undoBtn.TextColor = System.Drawing.Color.White;
            this.undoBtn.UseVisualStyleBackColor = false;
            this.undoBtn.Click += new System.EventHandler(this.undoBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.saveBtn.BackColor = System.Drawing.Color.Maroon;
            this.saveBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.saveBtn.BorderRadius = 20;
            this.saveBtn.BorderSize = 0;
            this.saveBtn.ButtonColor = System.Drawing.Color.Maroon;
            this.saveBtn.FlatAppearance.BorderSize = 0;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.ForeColor = System.Drawing.Color.White;
            this.saveBtn.HoverColor = System.Drawing.Color.DarkRed;
            this.saveBtn.Location = new System.Drawing.Point(264, 3);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(150, 35);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "Save";
            this.saveBtn.TextColor = System.Drawing.Color.White;
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click_1);
            // 
            // viewBtn
            // 
            this.viewBtn.BackColor = System.Drawing.Color.Maroon;
            this.viewBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.viewBtn.BorderRadius = 20;
            this.viewBtn.BorderSize = 0;
            this.viewBtn.ButtonColor = System.Drawing.Color.Maroon;
            this.viewBtn.FlatAppearance.BorderSize = 0;
            this.viewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewBtn.ForeColor = System.Drawing.Color.White;
            this.viewBtn.HoverColor = System.Drawing.Color.DarkRed;
            this.viewBtn.Location = new System.Drawing.Point(455, 3);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(150, 35);
            this.viewBtn.TabIndex = 2;
            this.viewBtn.Text = "View";
            this.viewBtn.TextColor = System.Drawing.Color.White;
            this.viewBtn.UseVisualStyleBackColor = false;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // imagePanel
            // 
            this.imagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imagePanel.AutoScroll = true;
            this.imagePanel.Controls.Add(this.currentImage);
            this.imagePanel.Location = new System.Drawing.Point(28, 245);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(680, 519);
            this.imagePanel.TabIndex = 26;
            // 
            // currentImage
            // 
            this.currentImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentImage.BackColor = System.Drawing.Color.MistyRose;
            this.currentImage.Location = new System.Drawing.Point(20, 20);
            this.currentImage.Margin = new System.Windows.Forms.Padding(20);
            this.currentImage.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.currentImage.MinimumSize = new System.Drawing.Size(1000, 1000);
            this.currentImage.Name = "currentImage";
            this.currentImage.Size = new System.Drawing.Size(1000, 1000);
            this.currentImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.currentImage.TabIndex = 8;
            this.currentImage.TabStop = false;
            this.currentImage.Click += new System.EventHandler(this.currentImage_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.60553F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.60553F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.60553F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.52728F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.65614F));
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.professorCmbox, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label9, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.pageCmbox, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.KeepCheckbox, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.programCmbox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label11, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.curriculumCmbox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.yearLevelCmbox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.semesterCmbox, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.yearCmbox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label12, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.sectionCmbox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.courseCmbox, 4, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(28, 68);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.47826F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.52174F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(680, 131);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(283, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 18);
            this.label8.TabIndex = 34;
            this.label8.Text = "Professor:";
            // 
            // professorCmbox
            // 
            this.professorCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.professorCmbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.professorCmbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.professorCmbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.professorCmbox.Enabled = false;
            this.professorCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.professorCmbox.FormattingEnabled = true;
            this.professorCmbox.Location = new System.Drawing.Point(283, 97);
            this.professorCmbox.Name = "professorCmbox";
            this.professorCmbox.Size = new System.Drawing.Size(134, 28);
            this.professorCmbox.TabIndex = 8;
            this.professorCmbox.Text = "Professor";
            this.professorCmbox.Click += new System.EventHandler(this.professorCmbox_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(423, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 18);
            this.label9.TabIndex = 35;
            this.label9.Text = "Page:";
            // 
            // pageCmbox
            // 
            this.pageCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pageCmbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pageCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageCmbox.FormattingEnabled = true;
            this.pageCmbox.Location = new System.Drawing.Point(422, 97);
            this.pageCmbox.Margin = new System.Windows.Forms.Padding(2);
            this.pageCmbox.Name = "pageCmbox";
            this.pageCmbox.Size = new System.Drawing.Size(142, 28);
            this.pageCmbox.TabIndex = 9;
            this.pageCmbox.SelectedIndexChanged += new System.EventHandler(this.pageCmbox_SelectedIndexChanged);
            // 
            // KeepCheckbox
            // 
            this.KeepCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.KeepCheckbox.AutoSize = true;
            this.KeepCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeepCheckbox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.KeepCheckbox.Location = new System.Drawing.Point(569, 100);
            this.KeepCheckbox.Name = "KeepCheckbox";
            this.KeepCheckbox.Size = new System.Drawing.Size(108, 22);
            this.KeepCheckbox.TabIndex = 10;
            this.KeepCheckbox.Text = "Keep";
            this.KeepCheckbox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 18);
            this.label6.TabIndex = 32;
            this.label6.Text = "Program:";
            // 
            // programCmbox
            // 
            this.programCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.programCmbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.programCmbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.programCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programCmbox.FormattingEnabled = true;
            this.programCmbox.Location = new System.Drawing.Point(2, 35);
            this.programCmbox.Margin = new System.Windows.Forms.Padding(2);
            this.programCmbox.Name = "programCmbox";
            this.programCmbox.Size = new System.Drawing.Size(136, 28);
            this.programCmbox.TabIndex = 1;
            this.programCmbox.Text = "Program ";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(143, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 18);
            this.label11.TabIndex = 36;
            this.label11.Text = "Curriculum Year:";
            // 
            // curriculumCmbox
            // 
            this.curriculumCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.curriculumCmbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.curriculumCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curriculumCmbox.FormattingEnabled = true;
            this.curriculumCmbox.Location = new System.Drawing.Point(142, 35);
            this.curriculumCmbox.Margin = new System.Windows.Forms.Padding(2);
            this.curriculumCmbox.Name = "curriculumCmbox";
            this.curriculumCmbox.Size = new System.Drawing.Size(136, 28);
            this.curriculumCmbox.TabIndex = 2;
            this.curriculumCmbox.Click += new System.EventHandler(this.curriculumCmbox_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(283, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 18);
            this.label5.TabIndex = 31;
            this.label5.Text = "Year Level:";
            // 
            // yearLevelCmbox
            // 
            this.yearLevelCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.yearLevelCmbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearLevelCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearLevelCmbox.FormattingEnabled = true;
            this.yearLevelCmbox.Location = new System.Drawing.Point(282, 35);
            this.yearLevelCmbox.Margin = new System.Windows.Forms.Padding(2);
            this.yearLevelCmbox.Name = "yearLevelCmbox";
            this.yearLevelCmbox.Size = new System.Drawing.Size(136, 28);
            this.yearLevelCmbox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(423, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 18);
            this.label4.TabIndex = 30;
            this.label4.Text = "Semester:";
            // 
            // semesterCmbox
            // 
            this.semesterCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.semesterCmbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.semesterCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.semesterCmbox.FormattingEnabled = true;
            this.semesterCmbox.Location = new System.Drawing.Point(423, 35);
            this.semesterCmbox.Name = "semesterCmbox";
            this.semesterCmbox.Size = new System.Drawing.Size(140, 28);
            this.semesterCmbox.TabIndex = 4;
            this.semesterCmbox.SelectedValueChanged += new System.EventHandler(this.semesterCmbox_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(3, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 29;
            this.label3.Text = "School Year:";
            // 
            // yearCmbox
            // 
            this.yearCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.yearCmbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.yearCmbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.yearCmbox.DropDownHeight = 100;
            this.yearCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearCmbox.FormattingEnabled = true;
            this.yearCmbox.IntegralHeight = false;
            this.yearCmbox.Location = new System.Drawing.Point(3, 97);
            this.yearCmbox.MaxDropDownItems = 10;
            this.yearCmbox.Name = "yearCmbox";
            this.yearCmbox.Size = new System.Drawing.Size(134, 28);
            this.yearCmbox.TabIndex = 6;
            this.yearCmbox.Text = "Year";
            this.yearCmbox.SelectedValueChanged += new System.EventHandler(this.yearCmbox_SelectedValueChanged);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(143, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 18);
            this.label12.TabIndex = 38;
            this.label12.Text = "Section:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(569, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 18);
            this.label7.TabIndex = 33;
            this.label7.Text = "Course:";
            // 
            // sectionCmbox
            // 
            this.sectionCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.sectionCmbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.sectionCmbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.sectionCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sectionCmbox.FormattingEnabled = true;
            this.sectionCmbox.Location = new System.Drawing.Point(142, 97);
            this.sectionCmbox.Margin = new System.Windows.Forms.Padding(2);
            this.sectionCmbox.Name = "sectionCmbox";
            this.sectionCmbox.Size = new System.Drawing.Size(136, 28);
            this.sectionCmbox.TabIndex = 7;
            this.sectionCmbox.SelectedIndexChanged += new System.EventHandler(this.sectionCmbox_SelectedIndexChanged);
            this.sectionCmbox.TextUpdate += new System.EventHandler(this.sectionCmbox_TextUpdate);
            this.sectionCmbox.SelectedValueChanged += new System.EventHandler(this.sectionCmbox_SelectedValueChanged);
            this.sectionCmbox.Click += new System.EventHandler(this.sectionCmbox_Click);
            // 
            // courseCmbox
            // 
            this.courseCmbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.courseCmbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.courseCmbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.courseCmbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseCmbox.FormattingEnabled = true;
            this.courseCmbox.Location = new System.Drawing.Point(569, 35);
            this.courseCmbox.Name = "courseCmbox";
            this.courseCmbox.Size = new System.Drawing.Size(108, 28);
            this.courseCmbox.TabIndex = 5;
            this.courseCmbox.SelectedIndexChanged += new System.EventHandler(this.courseCmbox_SelectedIndexChanged);
            this.courseCmbox.TextUpdate += new System.EventHandler(this.courseCmbox_TextUpdate);
            this.courseCmbox.SelectedValueChanged += new System.EventHandler(this.courseCmbox_SelectedValueChanged);
            this.courseCmbox.Click += new System.EventHandler(this.courseCmbox_Click);
            // 
            // filenameTxtbox
            // 
            this.filenameTxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filenameTxtbox.BackColor = System.Drawing.Color.White;
            this.filenameTxtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.filenameTxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filenameTxtbox.Location = new System.Drawing.Point(28, 209);
            this.filenameTxtbox.Margin = new System.Windows.Forms.Padding(5);
            this.filenameTxtbox.Name = "filenameTxtbox";
            this.filenameTxtbox.ReadOnly = true;
            this.filenameTxtbox.Size = new System.Drawing.Size(680, 28);
            this.filenameTxtbox.TabIndex = 5;
            this.filenameTxtbox.Text = "File Name";
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
            this.ClientSize = new System.Drawing.Size(1120, 1000);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel3);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBatchUpload";
            this.Text = "s";
            this.Load += new System.EventHandler(this.frmBatchUpload_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.pnlQueue.ResumeLayout(false);
            this.toUploadMenu.ResumeLayout(false);
            this.pnlGradesheetForm.ResumeLayout(false);
            this.pnlGradesheetForm.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.imagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.currentImage)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.ComboBox yearLevelCmbox;
        private System.Windows.Forms.ComboBox programCmbox;
        private System.Windows.Forms.ComboBox pageCmbox;
        private System.Windows.Forms.Panel panelHeader;
        private GradientLabel gradientLabel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
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
        private System.Windows.Forms.FlowLayoutPanel imagePanel;
        private System.Windows.Forms.PictureBox currentImage;
        private System.Windows.Forms.ToolStripMenuItem removeAll;
        private CustomControls.HeaderPanelCard pnlGradesheetForm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private RoundedButton undoBtn;
        private RoundedButton saveBtn;
        private RoundedButton viewBtn;
        private CustomControls.HeaderPanelCard pnlQueue;
        private RoundedButton uploadBtn;
    }
}