using System;
using System.Drawing;
using System.Windows.Forms;
using PUP_RMS.Controls; // Assuming your iconButton is here
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
        private bool isAdminExpanded = false; // Tracks if Admin menu is open

        // Caching Variables (To keep forms alive)
        private Form activeForm = null;
        private frmDashPlaceHolder _dashboardInstance = null;
        private frmProgram _programForm = null;
        private frmCourse _courseForm = null;
        private frmFaculty _facultyForm = null;
        // private frmCurriculum _curriculumForm = null; 

        // UI Tracking
        private iconButton currentActiveButton = null;

        // Visuals
        private Timer tmrFadeIn;
        private readonly Color ButtonMaroon = Color.FromArgb(128, 0, 0);
        private readonly Color ButtonGold = Color.Goldenrod;
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

            this.Load += MainDashboard_Load;

            // 2. Initial Setup
            pnlContent.BackColor = ChildFormBackgroundColor;

            // 3. Pre-load Dashboard
            _dashboardInstance = new frmDashPlaceHolder();
            PrepareChildForm(_dashboardInstance);

            // 4. Initial Layout Calculation
            ArrangeSidebar();

            // 5. Load Default
            ActivateButton(btnDashboard);
            ShowForm(_dashboardInstance);
        }

        // ======================================================
        // SECTION: LAYOUT LOGIC (THE FIX)
        // ======================================================
        private void ArrangeSidebar()
        {
            // 1. Stack the Top Buttons
            // (Assumes btnDashboard is fixed at the top in Designer)
            btnSearch.Top = btnDashboard.Bottom + BUTTON_GAP;
            btnBatchUpload.Top = btnSearch.Bottom + BUTTON_GAP;
            btnAdminTool.Top = btnBatchUpload.Bottom + BUTTON_GAP;

            // 2. Position the Sub-Menu Panel
            // It must always sit directly under the Admin Tool button
            pnlAdminSubMenu.Top = btnAdminTool.Bottom;
            pnlAdminSubMenu.Left = btnAdminTool.Left;
            pnlAdminSubMenu.Width = btnAdminTool.Width;

            // 3. Expand / Collapse Logic
            if (isAdminExpanded)
            {
                // SHOW the panel
                pnlAdminSubMenu.Visible = true;

                // Position subsequent buttons (Accounts, Logout) BELOW the panel
                // We use pnlAdminSubMenu.Bottom to push them down
                btnAccounts.Top = pnlAdminSubMenu.Bottom + BUTTON_GAP;
            }
            else
            {
                // HIDE the panel
                pnlAdminSubMenu.Visible = false;

                // Position subsequent buttons directly BELOW the Admin Tool button
                btnAccounts.Top = btnAdminTool.Bottom + BUTTON_GAP;
            }

            // 4. Logout always sits below Accounts
            btnLogout.Top = btnAccounts.Bottom + BUTTON_GAP + 20;
        }

        // ======================================================
        // SECTION: BUTTON CLICK EVENTS
        // ======================================================

        // --- MAIN ADMIN TOGGLE ---
        private void btnAdminTool_Click(object sender, EventArgs e)
        {
            // 1. Toggle the state
            isAdminExpanded = !isAdminExpanded;

            // 2. Update the sidebar layout
            ArrangeSidebar();

            // 3. Optional: Highlight the button
            ActivateButton(sender);
        }

        // --- SUB MENUS (Open specific forms) ---
        private void btnProgram_Click_1(object sender, EventArgs e)
        {
            frmProgram programForm = new frmProgram();
            ShowForm(programForm);
        }

        private void btnCourse_Click_1(object sender, EventArgs e)
        {
            frmCourse courseForm = new frmCourse();
            ShowForm(courseForm);
        }

        private void btnFaculty_Click_1(object sender, EventArgs e)
        {
            frmFaculty facultyForm = new frmFaculty();
            ShowForm(facultyForm);
        }

        private void btnCurriculum_Click_1(object sender, EventArgs e)
        {
            frmCurriculum curriculumForm = new frmCurriculum();
            ShowForm(curriculumForm);
        }

        // --- STANDARD BUTTONS ---

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (currentActiveButton == sender) return;
            if (CanChangeWindow())
            {
                ActivateButton(sender);
                ShowForm(_dashboardInstance);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (currentActiveButton == sender) return;
            if (CanChangeWindow())
            {
                ActivateButton(sender);
                ShowForm(new frmSearch()); // Search usually resets, so new instance is fine
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
        // SECTION: HELPERS (ShowForm & ActivateButton)
        // ======================================================

        private void ShowForm(Form childForm)
        {
            pnlContent.SuspendLayout();

            if (activeForm != null)
            {
                // HIDE these forms to keep their state/data
                if (activeForm == _dashboardInstance ||
                    activeForm == _programForm ||
                    activeForm == _courseForm ||
                    activeForm == _facultyForm)
                {
                    activeForm.Hide();
                }
                else
                {
                    // CLOSE other forms (like Search/Upload) to reset them
                    activeForm.Close();
                }
            }

            activeForm = childForm;

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

            // Safely cast to Control first
            Control newBtn = (Control)btnSender;
            iconButton newIconBtn = btnSender as iconButton;

            // 1. Reset Old Button
            if (currentActiveButton != null && currentActiveButton != newIconBtn)
            {
                currentActiveButton.IsActive = false;

                // Force Reset Logic (Fixes stuck colors)
                currentActiveButton.Enabled = false;
                currentActiveButton.Enabled = true;
                currentActiveButton.BackColor = ButtonMaroon;
            }

            // 2. Activate New Button (Only if it is an iconButton)
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

        private void MainDashboard_Load(object sender, EventArgs e) => tmrFadeIn.Start();

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


    }
}