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
        private frmProgram _programForm = null;
        private frmCourse _courseForm = null;
        private frmFaculty _facultyForm = null;

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
            SetupAdminSubButtons();
            // 1. Layout Calculation
            ArrangeSidebar();

            // 2. Initialize Dashboard Instance if null
            if (_dashboardInstance == null)
            {
                _dashboardInstance = new frmDashboard();
                PrepareChildForm(_dashboardInstance);
            }

            // 3. Load Default View
            ActivateButton(btnDashboard);
            ShowForm(_dashboardInstance);

            // 4. Start Animation
            tmrFadeIn.Start();
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
        // SECTION: BUTTON CLICK EVENTS
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

        private void btnProgram_Click_1(object sender, EventArgs e)
        {
            if (_programForm == null || _programForm.IsDisposed)
            {
                _programForm = new frmProgram();
                PrepareChildForm(_programForm);
            }
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
            ShowForm(_facultyForm);
            ActivateAdminSubButton(sender);
        }

        private void btnCurriculum_Click_1(object sender, EventArgs e)
        {
            frmCurriculum curriculumForm = new frmCurriculum();
            ShowForm(curriculumForm);
            ActivateAdminSubButton(sender);
        }

        // --- STANDARD BUTTONS ---

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (currentActiveButton == sender) return;
            if (CanChangeWindow())
            {
                ActivateButton(sender);

                // FIXED: Use the cached instance instead of 'new frmDashboard()'
                // This ensures you don't lose state and it matches the Load event logic
                if (_dashboardInstance == null || _dashboardInstance.IsDisposed)
                {
                    _dashboardInstance = new frmDashboard();
                    PrepareChildForm(_dashboardInstance);
                }

                ShowForm(_dashboardInstance);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (currentActiveButton == sender) return;
            if (CanChangeWindow())
            {
                ActivateButton(sender);
                ShowForm(new frmSearch());
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (currentActiveButton == sender) return;
            if (CanChangeWindow())
            {
                ActivateButton(sender);
                ShowForm(new frmBatchUpload());
            }
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            if (currentActiveButton == sender) return;
            if (CanChangeWindow())
            {
                ActivateButton(sender);
                ShowForm(new frmAccount());
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (!CanChangeWindow()) return;
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
                // If the active form is one of our "Cached" main forms, just Hide it.
                if (activeForm == _dashboardInstance ||
                    activeForm == _programForm ||
                    activeForm == _courseForm ||
                    activeForm == _facultyForm)
                {
                    activeForm.Hide();
                }
                else
                {
                    // Otherwise (like Search or Upload), Close it to reset.
                    activeForm.Close();
                }
            }

            activeForm = childForm;

            // Ensure the form is added to the panel if it wasn't already
            if (!pnlContent.Controls.Contains(childForm))
            {
                PrepareChildForm(childForm);
            }

            childForm.BringToFront();
            childForm.Show();
            pnlContent.ResumeLayout();
        }

        private void PrepareChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            SetDoubleBuffered(childForm);
            pnlContent.Controls.Add(childForm);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender == null) return;

            Control newBtn = (Control)btnSender;
            iconButton newIconBtn = btnSender as iconButton;

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

            iconButton[] adminButtons = { btnProgram, btnCourse, btnFaculty, btnCurriculum };

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
    }
}