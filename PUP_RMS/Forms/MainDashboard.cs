using System;
using System.Drawing;
using System.Windows.Forms;
using PUP_RMS.Controls;
using PUP_RMS.Forms;

namespace PUP_RMS.Forms
{
    public partial class MainDashboard : Form
    {
        // CURRENT ACCOUNT LOGGED IN
        public static Model.Account CurrentAccount;

        // --- VARIABLES ---
        bool uploadExpand = false;
        private const int UPLOAD_MIN_HEIGHT = 60;
        private const int UPLOAD_MAX_HEIGHT = 190;
        private const int BUTTON_GAP = 5;

        // --- CACHING LOGIC VARIABLES ---
        private Form activeForm = null;
        private frmDashboard _dashboardInstance = null; // Store the Dashboard here

        private iconButton currentActiveButton = null;

        // --- FADE IN TIMER ---
        private Timer tmrFadeIn;

        // COLORS
        private readonly Color DarkerMaroonBackground = Color.FromArgb(93, 16, 10);
        private readonly Color ButtonMaroon = Color.FromArgb(128, 0, 0);
        private readonly Color ChildFormBackgroundColor = Color.FromArgb(240, 240, 240);

        public MainDashboard()
        {
            this.Opacity = 0;

            // GLOBAL BUFFERING
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            InitializeComponent();

            ApplyDoubleBufferingRecursively(this.Controls);
            InitializeFadeTimer();

            this.Load += MainDashboard_Load;

            // ================================================================
            // UI LAYOUT & COLOR SETUP
            // ================================================================

            flowLayoutPanelUpload.BackColor = DarkerMaroonBackground;
            flowLayoutPanelUpload.Padding = new Padding(0);

            btnUpload.Margin = new Padding(0);
            btnUpload.Width = flowLayoutPanelUpload.Width;

            btnBatchUpload.Margin = new Padding(0, BUTTON_GAP, 0, 0);
            btnBatchUpload.Width = flowLayoutPanelUpload.Width;
            btnBatchUpload.BackColor = ButtonMaroon;

            btnIndividUpload.Margin = new Padding(0, BUTTON_GAP, 0, 0);
            btnIndividUpload.Width = flowLayoutPanelUpload.Width;
            btnIndividUpload.BackColor = ButtonMaroon;

            btnSearch.Top = btnDashboard.Bottom + BUTTON_GAP;
            flowLayoutPanelUpload.Top = btnSearch.Bottom + BUTTON_GAP;
            AdjustSidebarLayout();

            pnlContent.BackColor = ChildFormBackgroundColor;

            // ================================================================
            // 1. PRE-LOAD THE DASHBOARD (The "Static" Fix)
            // ================================================================
            // We create it immediately so the "Square-to-Round" calculation 
            // happens right now, while the app is still fading in.
            _dashboardInstance = new frmDashboard();
            PrepareChildForm(_dashboardInstance); // Setup settings without showing yet

            // Load Default
            ActivateButton(btnDashboard);
            ShowForm(_dashboardInstance); // Use ShowForm instead of OpenChildForm
        }

        // ======================================================
        // SECTION: FADE IN LOGIC
        // ======================================================
        private void InitializeFadeTimer()
        {
            tmrFadeIn = new Timer();
            tmrFadeIn.Interval = 10;
            tmrFadeIn.Tick += TmrFadeIn_Tick;
        }

        private void TmrFadeIn_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1.0)
            {
                this.Opacity += 0.05;
            }
            else
            {
                tmrFadeIn.Stop();
            }
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            tmrFadeIn.Start();
        }

        // ======================================================
        // SECTION: ANTI-FLICKER HELPERS
        // ======================================================
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x02000000;  // WS_CLIPCHILDREN
                return cp;
            }
        }

        private void ApplyDoubleBufferingRecursively(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                SetDoubleBuffered(c);
                if (c.HasChildren)
                {
                    ApplyDoubleBufferingRecursively(c.Controls);
                }
            }
        }

        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession) return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (aProp != null) aProp.SetValue(c, true, null);
        }

        // ======================================================
        // SECTION: UI LOGIC
        // ======================================================
        private void AdjustSidebarLayout()
        {
            btnProfessor.Top = flowLayoutPanelUpload.Bottom + BUTTON_GAP;
            btnLogout.Top = btnProfessor.Bottom + BUTTON_GAP;
        }

        // --------------------------------------------------------
        // NEW LOGIC: PREPARE FORM SETTINGS (Used for Caching)
        // --------------------------------------------------------
        private void PrepareChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Double Buffer the child immediately
            SetDoubleBuffered(childForm);
            ApplyDoubleBufferingRecursively(childForm.Controls);

            pnlContent.Controls.Add(childForm);
        }

        // --------------------------------------------------------
        // NEW LOGIC: SHOW FORM (Handles Caching)
        // --------------------------------------------------------
        private void ShowForm(Form childForm)
        {
            // 1. Suspend Layout to prevent "Square-to-Round" glitch
            pnlContent.SuspendLayout();

            // 2. Hide the current form (Don't Close/Dispose if it's the dashboard)
            if (activeForm != null)
            {
                if (activeForm == _dashboardInstance)
                {
                    activeForm.Hide(); // Keep Dashboard alive in memory
                }
                else
                {
                    activeForm.Close(); // Close other forms (Search, etc) to save RAM
                    // activeForm.Dispose(); // Optional: Close usually handles dispose
                }
            }

            // 3. Set the new active form
            activeForm = childForm;

            // 4. Setup if not already added (For non-cached forms like Search/Upload)
            if (!pnlContent.Controls.Contains(childForm))
            {
                PrepareChildForm(childForm);
            }

            // 5. Show the new form
            childForm.BringToFront();
            childForm.Show();

            // 6. Resume Layout (Renders everything at once)
            pnlContent.ResumeLayout();
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender == null) return;

            iconButton newActiveButton = (iconButton)btnSender;

            if (currentActiveButton != null && currentActiveButton != newActiveButton)
            {
                currentActiveButton.IsActive = false;
            }

            newActiveButton.IsActive = true;
            currentActiveButton = newActiveButton;
        }

        // ======================================================
        // SECTION: CLICK EVENTS
        // ======================================================

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (currentActiveButton == sender) return;
            if (uploadExpand) CollapseUploadMenu();
            ActivateButton(sender);

            // USE THE CACHED INSTANCE
            // Because we don't use 'new frmDashboard()', it keeps its shape.
            ShowForm(_dashboardInstance);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (currentActiveButton == sender) return;
            if (uploadExpand) CollapseUploadMenu();
            ActivateButton(sender);

            // Create new instance for Search (or cache it if you want)
            ShowForm(new frmSearch());
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            tmrUploadTransition.Stop();

            if (!uploadExpand)
            {
                ActivateButton(sender);
                btnBatchUpload.Visible = true;
                btnIndividUpload.Visible = true;
            }
            else
            {
                if (currentActiveButton == btnUpload)
                {
                    currentActiveButton.IsActive = false;
                    currentActiveButton = null;
                }
            }
            tmrUploadTransition.Start();
        }

        private void btnBatchUpload_Click(object sender, EventArgs e)
        {
            if (currentActiveButton == sender) return;
            if (currentActiveButton == btnUpload) btnUpload.IsActive = false;
            ActivateButton(sender);
            ShowForm(new frmBatchUpload());
        }

        private void btnIndividUpload_Click(object sender, EventArgs e)
        {
            if (currentActiveButton == sender) return;
            if (currentActiveButton == btnUpload) btnUpload.IsActive = false;
            ActivateButton(sender);
            ShowForm(new frmIndividualUpload());
        }

        private void btnCourse_Click(object sender, EventArgs e)
        {
            if (currentActiveButton == sender) return;
            if (uploadExpand) CollapseUploadMenu();
            ActivateButton(sender);
            ShowForm(new frmCourse());
        }

        private void btnProfessor_Click(object sender, EventArgs e)
        {
            if (currentActiveButton == sender) return;
            if (uploadExpand) CollapseUploadMenu();
            ActivateButton(sender);
            ShowForm(new frmProfessor());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void CollapseUploadMenu()
        {
            tmrUploadTransition.Start();
            if (currentActiveButton == btnUpload || currentActiveButton == btnBatchUpload || currentActiveButton == btnIndividUpload)
            {
                currentActiveButton.IsActive = false;
                currentActiveButton = null;
            }
        }

        private void tmrUploadTransition_Tick(object sender, EventArgs e)
        {
            int step = 10;

            if (!uploadExpand)
            {
                flowLayoutPanelUpload.Height += step;
                if (flowLayoutPanelUpload.Height >= UPLOAD_MAX_HEIGHT)
                {
                    flowLayoutPanelUpload.Height = UPLOAD_MAX_HEIGHT;
                    tmrUploadTransition.Stop();
                    uploadExpand = true;
                }
            }
            else
            {
                flowLayoutPanelUpload.Height -= step;
                if (flowLayoutPanelUpload.Height <= UPLOAD_MIN_HEIGHT)
                {
                    flowLayoutPanelUpload.Height = UPLOAD_MIN_HEIGHT;
                    tmrUploadTransition.Stop();
                    uploadExpand = false;
                }
            }
            AdjustSidebarLayout();
            flowLayoutPanelUpload.Refresh();
        }

        private void label1_Click(object sender, EventArgs e) { }

        
    }
}