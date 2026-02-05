using System;
using System.Drawing;
using System.Windows.Forms;
using PUP_RMS.Controls;
using PUP_RMS.Forms;

namespace PUP_RMS.Forms
{
    public partial class MainDashboard : Form
    {
        // ==========================================
        // VARIABLES
        // ==========================================
        public static Model.Account CurrentAccount;

        // Layout Constants
        private const int BUTTON_GAP = 5;
        private bool isAdminExpanded = false;

        // Caching Variables
        private Form activeForm = null;
        private frmDashboard _dashboardInstance = null; // We will use this instance
        private frmSearch _searchForm = null;
        private frmBatchUpload _batchUploadForm = null;
        private frmCurriculum _curriculumForm = null;
        private frmProgram _programForm = null;
        private frmCourse _courseForm = null;
        private frmFaculty _facultyForm = null;
        private frmSection _sectionForm = null;
        private frmAccount _accountForm = null;


        // UI Tracking
        private iconButton currentActiveButton = null;
        private iconButton currentAdminSubButton = null;

        // Visuals
        private Timer tmrFadeIn;
        private readonly Color ButtonMaroon = Color.FromArgb(128, 0, 0);
        private readonly Color ButtonGold = Color.Goldenrod;

        //ADMIN SUB BUTTONS COLOR WHEN CLICKED OR UNCLICKED
        private readonly Color ButtonRed = ColorTranslator.FromHtml("#8C1007");
        private readonly Color ButtonBrightRed = ColorTranslator.FromHtml("#FF0000");


        private readonly Color ChildFormBackgroundColor = Color.FromArgb(240, 240, 240);

        public static LoadingScreen CurrentLoadingScreen { get; set; }


        // ==========================================
        // CONSTRUCTOR
        // ==========================================
        public MainDashboard()
        {
            this.Opacity = 0;

            // 1. Anti-Flicker Settings
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            InitializeComponent();
            ApplyDoubleBufferingRecursively(this.Controls);
            InitializeFadeTimer();

            // Hook up the Load event
            this.Load += MainDashboard_Load;

            // 2. Initial Setup
            pnlContent.BackColor = ChildFormBackgroundColor;

            // REMOVED: Do not call ShowForm() or ArrangeSidebar() here.
            // We moved that logic to MainDashboard_Load below.
        }

        // ==========================================
        // LOAD EVENT (Logic Moved Here)
        // ==========================================
        private void MainDashboard_Load(object sender, EventArgs e)
        {
            LoadingScreen loadingScreen = GetLoadingScreenReference(); // Method below

            try
            {
                SetupAdminSubButtons();
                loadingScreen?.UpdateProgress(10, "Arranging interface...");

                // 1. Layout Calculation
                ArrangeSidebar();
                loadingScreen?.UpdateProgress(25, "Loading modules...");

                // 2. PRE-LOAD ALL FORMS - This is where most of the time is spent
                InitializeAllFormsWithProgress(loadingScreen);
                loadingScreen?.UpdateProgress(85, "Finalizing dashboard...");

                // 3. Load Default View
                if (_dashboardInstance == null || _dashboardInstance.IsDisposed)
                {
                    _dashboardInstance = new frmDashboard();
                    PrepareChildForm(_dashboardInstance);
                }
                ActivateButton(btnDashboard);
                ShowForm(_dashboardInstance);
                loadingScreen?.UpdateProgress(95, "Almost ready...");

                // 4. Start Animation
                tmrFadeIn.Start();

                if (CurrentAccount.AccountType == "User")
                {
                    pnlAdminSubMenu.Visible = false;
                    btnAdminTool.Visible = false;
                }

                loadingScreen?.UpdateProgress(100, "Done!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeAllFormsWithProgress(LoadingScreen loadingScreen)
        {
            int formIndex = 0;
            int totalForms = 8;
            int progressPerForm = 60 / totalForms; // Allocate 60% of progress to form loading

            // Initialize Dashboard
            if (_dashboardInstance == null)
            {
                _dashboardInstance = new frmDashboard();
                PrepareAndLoadChildForm(_dashboardInstance);
                loadingScreen?.UpdateProgress(25 + (++formIndex * progressPerForm), "Loading Dashboard...");
            }

            // Initialize Search
            if (_searchForm == null)
            {
                _searchForm = new frmSearch();
                PrepareAndLoadChildForm(_searchForm);
                loadingScreen?.UpdateProgress(25 + (++formIndex * progressPerForm), "Loading Search...");
            }

            // Initialize Batch Upload
            if (_batchUploadForm == null)
            {
                _batchUploadForm = new frmBatchUpload();
                PrepareAndLoadChildForm(_batchUploadForm);
                loadingScreen?.UpdateProgress(25 + (++formIndex * progressPerForm), "Loading Batch Upload...");
            }

            // Initialize Curriculum
            if (_curriculumForm == null)
            {
                _curriculumForm = new frmCurriculum();
                PrepareAndLoadChildForm(_curriculumForm);
                loadingScreen?.UpdateProgress(25 + (++formIndex * progressPerForm), "Loading Curriculum...");
            }

            // Initialize Program
            if (_programForm == null)
            {
                _programForm = new frmProgram();
                PrepareAndLoadChildForm(_programForm);
                loadingScreen?.UpdateProgress(25 + (++formIndex * progressPerForm), "Loading Programs...");
            }

            // Initialize Course
            if (_courseForm == null)
            {
                _courseForm = new frmCourse();
                PrepareAndLoadChildForm(_courseForm);
                loadingScreen?.UpdateProgress(25 + (++formIndex * progressPerForm), "Loading Courses...");
            }

            // Initialize Faculty
            if (_facultyForm == null)
            {
                _facultyForm = new frmFaculty();
                PrepareAndLoadChildForm(_facultyForm);
                loadingScreen?.UpdateProgress(25 + (++formIndex * progressPerForm), "Loading Faculty...");
            }

            // Initialize Section
            if (_sectionForm == null)
            {
                _sectionForm = new frmSection();
                PrepareAndLoadChildForm(_sectionForm);
                loadingScreen?.UpdateProgress(25 + (++formIndex * progressPerForm), "Loading Sections...");
            }

            // Initialize Account
            if (_accountForm == null)
            {
                _accountForm = new frmAccount();
                PrepareAndLoadChildForm(_accountForm);
                loadingScreen?.UpdateProgress(25 + (++formIndex * progressPerForm), "Loading Accounts...");
            }
        }

        private LoadingScreen GetLoadingScreenReference()
        {
            return CurrentLoadingScreen;
        }

        // ======================================================
        // SECTION: LAYOUT LOGIC
        // ======================================================
        private void ArrangeSidebar()
        {
            btnSearch.Top = btnDashboard.Bottom + BUTTON_GAP;
            btnBatchUpload.Top = btnSearch.Bottom + BUTTON_GAP;
            btnAdminTool.Top = btnBatchUpload.Bottom + BUTTON_GAP;

            pnlAdminSubMenu.Top = btnAdminTool.Bottom;
            pnlAdminSubMenu.Left = btnAdminTool.Left;
            pnlAdminSubMenu.Width = btnAdminTool.Width;

            if (isAdminExpanded)
            {
                pnlAdminSubMenu.Visible = true;
                btnAccounts.Top = pnlAdminSubMenu.Bottom + BUTTON_GAP;
            }
            else
            {
                pnlAdminSubMenu.Visible = false;
                btnAccounts.Top = btnAdminTool.Bottom + BUTTON_GAP;
            }

            btnLogout.Top = btnAccounts.Bottom + BUTTON_GAP + 20;
        }

        // ======================================================
        // SECTION: SUB BUTTON CLICK EVENTS
        // ======================================================

        private void btnAdminTool_Click(object sender, EventArgs e)
        {
            isAdminExpanded = !isAdminExpanded;
            if (!isAdminExpanded && currentAdminSubButton != null)
            {
                currentAdminSubButton.IsActive = false;
                currentAdminSubButton.BackColor = ButtonRed;
                currentAdminSubButton = null;
            }
            ArrangeSidebar();
            ActivateButton(sender);
        }
        private void btnCurriculum_Click_1(object sender, EventArgs e)
        {
            if (_curriculumForm == null || _curriculumForm.IsDisposed)
            {
                _curriculumForm = new frmCurriculum();
                PrepareChildForm(_curriculumForm);
            }
            _curriculumForm.LoadData();
            ShowForm(_curriculumForm);
            ActivateAdminSubButton(sender);

        }
        private void btnSection_Click(object sender, EventArgs e)
        {
            if (_sectionForm == null || _sectionForm.IsDisposed)
            {
                _sectionForm = new frmSection();
                PrepareChildForm(_sectionForm);
            }
            _sectionForm.LoadData();
            ShowForm(_sectionForm);
            ActivateAdminSubButton(sender);
        }

        private void btnProgram_Click_1(object sender, EventArgs e)
        {
            if (_programForm == null || _programForm.IsDisposed)
            {
                _programForm = new frmProgram();
                PrepareChildForm(_programForm);
            }
            _programForm.Reset();
            ShowForm(_programForm);
            ActivateAdminSubButton(sender);
        }

        private void btnCourse_Click_1(object sender, EventArgs e)
        {
            if (_courseForm == null || _courseForm.IsDisposed)
            {
                _courseForm = new frmCourse();
                PrepareChildForm(_courseForm);
            }
            _courseForm.loadData();
            ShowForm(_courseForm);
            ActivateAdminSubButton(sender);
        }

        private void btnFaculty_Click_1(object sender, EventArgs e)
        {
            if (_facultyForm == null || _facultyForm.IsDisposed)
            {
                _facultyForm = new frmFaculty();
                PrepareChildForm(_facultyForm);
            }
            _facultyForm.loadData();
            ShowForm(_facultyForm);
            ActivateAdminSubButton(sender);
        }

       
        // --- STANDARD BUTTONS ---

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (currentActiveButton == sender) return;
            if (true) // VALIDATION FOR CanChangeWindow() CAN BE ADDED HERE
            {
                if (_dashboardInstance == null || _dashboardInstance.IsDisposed)
                {
                    _dashboardInstance = new frmDashboard();
                    PrepareChildForm(_dashboardInstance);
                }
                _dashboardInstance.loadData();
                ActivateButton(sender);
                ShowForm(_dashboardInstance);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (currentActiveButton == sender) return;
            if (true) // VALIDATION FOR CanChangeWindow() CAN BE ADDED HERE
            {
                if(_searchForm == null || _searchForm.IsDisposed)
                {
                    _searchForm = new frmSearch();
                    PrepareChildForm(_searchForm);
                }
                _searchForm.loadData();
                ActivateButton(sender);
                ShowForm(_searchForm);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (currentActiveButton == sender) return;
            if (true) // VALIDATION FOR CanChangeWindow() CAN BE ADDED HERE
            {
                if(_batchUploadForm == null || _batchUploadForm.IsDisposed)
                {
                    _batchUploadForm = new frmBatchUpload();
                    PrepareChildForm(_batchUploadForm);
                }
                _batchUploadForm.loadData();
                ActivateButton(sender);
                ShowForm(_batchUploadForm);
            }
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            if (currentActiveButton == sender) return;
            if (true) // VALIDATION FOR CanChangeWindow() CAN BE ADDED HERE
            {
                if(_accountForm == null || _accountForm.IsDisposed)
                {
                    _accountForm = new frmAccount();
                    PrepareChildForm(_accountForm);
                }
                ActivateButton(sender);
                ShowForm(_accountForm);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //if (!CanChangeWindow()) return; // VALIDATION FOR CanChangeWindow() CAN BE ADDED HERE
            if (MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                new LoginForm().Show();
            }
        }

        // ======================================================
        // SECTION: HELPERS
        // ======================================================

        private void ShowForm(Form childForm)
        {
            pnlContent.SuspendLayout();

            if (activeForm != null)
            {
                if (activeForm == _dashboardInstance ||
                    activeForm == _searchForm ||
                    activeForm == _batchUploadForm ||
                    activeForm == _curriculumForm ||
                    activeForm == _programForm ||
                    activeForm == _courseForm ||
                    activeForm == _facultyForm ||
                    activeForm == _sectionForm ||
                    activeForm == _accountForm) 
                {
                    activeForm.Visible = false;
                }
                else
                {
                    activeForm.Close();
                }
            }

            activeForm = childForm;

            if (!pnlContent.Controls.Contains(childForm))
            {
                PrepareChildForm(childForm);
            }

            pnlContent.ResumeLayout(false); // false = don't layout yet

            // Use BeginInvoke to delay visibility until ALL painting is done
            // Show immediately (no need for BeginInvoke since it's already loaded)
            childForm.Visible = true;
            childForm.BringToFront();
        }
        private void PrepareAndLoadChildForm(Form childForm)
        {
            // 1ST METHOD ==================
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            SetDoubleBuffered(childForm);
            pnlContent.Controls.Add(childForm);

            // Force load by showing then immediately hiding
            childForm.Show();        // This creates handle and triggers Load
            Application.DoEvents();  // Process all messages
            childForm.Hide();        // Hide it again

            // DEBUG: Verify Load event fired
            Console.WriteLine($"{childForm.Name} - Handle Created: {childForm.IsHandleCreated}");
            Console.WriteLine($"{childForm.Name} - Controls Count: {childForm.Controls.Count}");

            // 2ND METHOD ==================
            //childForm.TopLevel = false;
            //childForm.FormBorderStyle = FormBorderStyle.None;
            //childForm.Dock = DockStyle.Fill;

            //SetDoubleBuffered(childForm);
            //pnlContent.Controls.Add(childForm);

            //// Force handle creation (this ALWAYS works)
            //IntPtr handle = childForm.Handle; // Accessing Handle property forces creation

            //// Ensure Load event is fired
            //if (!childForm.Visible)
            //{
            //    childForm.Visible = true;
            //    Application.DoEvents();
            //    childForm.Visible = false;
            //}

            //childForm.PerformLayout();

            //// DEBUG
            //Console.WriteLine($"{childForm.Name} - Handle: {childForm.Handle}");
            //Console.WriteLine($"{childForm.Name} - IsHandleCreated: {childForm.IsHandleCreated}");
        }

        private void PrepareChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.Visible = false;

            SetDoubleBuffered(childForm);
            pnlContent.Controls.Add(childForm);

            if (!childForm.IsHandleCreated)
            {
                childForm.CreateControl();
            }

            childForm.PerformLayout();
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender == null) return;

            Control newBtn = (Control)btnSender;
            iconButton newIconBtn = btnSender as iconButton;
            if (newBtn != btnAdminTool && isAdminExpanded) 
            { 
                isAdminExpanded = false;

                if (currentAdminSubButton != null) 
                {
                    currentAdminSubButton.IsActive = false;
                    currentAdminSubButton.BackColor = ButtonRed;
                    currentAdminSubButton = null;
                }
                ArrangeSidebar();
            }

            if (currentActiveButton != null && currentActiveButton != newIconBtn)
            {
                currentActiveButton.IsActive = false;
                currentActiveButton.Enabled = false;
                currentActiveButton.Enabled = true;
                currentActiveButton.BackColor = ButtonMaroon;
            }

            if (newIconBtn != null)
            {
                newIconBtn.IsActive = true;
                newIconBtn.BackColor = ButtonGold;
                currentActiveButton = newIconBtn;
            }
        }

        private bool CanChangeWindow()
        {
            if (activeForm != null && activeForm is frmBatchUpload)
            {
                return MessageBox.Show(
                    "Leaving this window will reset your uploaded data. Continue?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes;
            }
            return true;
        }

        // ======================================================
        // SECTION: VISUALS
        // ======================================================
        private void InitializeFadeTimer()
        {
            tmrFadeIn = new Timer { Interval = 10 };
            tmrFadeIn.Tick += (s, e) => { if (Opacity < 1) Opacity += 0.05; else tmrFadeIn.Stop(); };
        }

        protected override CreateParams CreateParams
        {
            get { CreateParams cp = base.CreateParams; cp.Style |= 0x02000000; return cp; }
        }

        private void ApplyDoubleBufferingRecursively(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                SetDoubleBuffered(c);
                if (c.HasChildren) ApplyDoubleBufferingRecursively(c.Controls);
            }
        }

        public static void SetDoubleBuffered(Control c)
        {
            if (SystemInformation.TerminalServerSession) return;
            var prop = typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (prop != null) prop.SetValue(c, true, null);
        }

        //ADMIN TOOLS SUB BUTTON HELPER
        private void ActivateAdminSubButton(object sender)
        {
            var clickedBtn = sender as iconButton;
            if (clickedBtn == null) return;

            if (currentAdminSubButton != null && currentAdminSubButton != clickedBtn)
            {
                currentAdminSubButton.IsActive = false;
                currentAdminSubButton.BackColor = ButtonRed; // Reverts to dark red when inactive
            }

            currentAdminSubButton = clickedBtn;

            // FIX: Update the ActiveColor property, not BackColor
            clickedBtn.ActiveColor = ButtonBrightRed;
            clickedBtn.IsActive = true;
        }
        private void SetupAdminSubButtons()
        {

            iconButton[] adminButtons = { btnSection, btnProgram, btnFaculty, btnCurriculum };

            foreach (var btn in adminButtons)
            {
                btn.BackColor = ButtonRed;
                btn.HoverColor = ButtonBrightRed;
                btn.ActiveColor = ButtonBrightRed;
            }
        }
        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}