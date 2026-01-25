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
            // UI LAYOUT SETUP
            // ================================================================

            // 1. Position Buttons Manually (Since we aren't using the flow layout animation anymore)
            // Assuming btnDashboard is at the top.
            btnSearch.Top = btnDashboard.Bottom + BUTTON_GAP;
            btnBatchUpload.Top = btnSearch.Bottom + BUTTON_GAP;     // Upload is now a normal button
            btnCourse.Top = btnBatchUpload.Bottom + BUTTON_GAP;     // Course moves under Upload
            btnProfessor.Top = btnCourse.Bottom + BUTTON_GAP;

            // If you added the Settings/Accounts button:
            // btnAccounts.Top = btnProfessor.Bottom + BUTTON_GAP; 

            // Logout usually sticks to bottom, or under the last button
            btnLogout.Top = btnProfessor.Bottom + BUTTON_GAP + 20;

            pnlContent.BackColor = ChildFormBackgroundColor;

            // ================================================================
            // PRE-LOAD THE DASHBOARD
            // ================================================================
            _dashboardInstance = new frmDashboard();
            PrepareChildForm(_dashboardInstance);

            // Load Default
            ActivateButton(btnDashboard);
            ShowForm(_dashboardInstance);
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
        // SECTION: FORM MANAGEMENT LOGIC
        // ======================================================
        private void PrepareChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            SetDoubleBuffered(childForm);
            ApplyDoubleBufferingRecursively(childForm.Controls);
            pnlContent.Controls.Add(childForm);
        }

        private void ShowForm(Form childForm)
        {
            pnlContent.SuspendLayout();

            if (activeForm != null)
            {
                if (activeForm == _dashboardInstance)
                    activeForm.Hide();
                else
                    activeForm.Close();
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
                ShowForm(new frmSearch());
            }

        }

        // --- UPDATED UPLOAD BUTTON ---
        // Directly opens the Batch Upload form now
        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (currentActiveButton == sender) return;
            if (CanChangeWindow())
            {
                ActivateButton(sender);
                ShowForm(new frmBatchUpload());
            }


        }

        // --------------- HELPER FOR UPLOAD BUTTON ------------------


        private bool CanChangeWindow()
        {
            // Check if the current active form is the Batch Upload form
            if (activeForm != null && activeForm is frmBatchUpload)
            {
                DialogResult result = MessageBox.Show(
                    "Leaving this window will reset your uploaded data. Do you want to continue?",
                    "Confirm Navigation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                return result == DialogResult.Yes;
            }

            return true; // Safe to change if not on the upload form
        }


        //------------------------------------------------------------
        private void btnProgram_Click(object sender, EventArgs e)
        {
            if (currentActiveButton == sender) return;
            if (CanChangeWindow())
            {
                ActivateButton(sender);
                ShowForm(new frmProgram());
            }
        }

        private void btnCourse_Click(object sender, EventArgs e)
        {
            if (currentActiveButton == sender) return;
            if (CanChangeWindow())
            {
                ActivateButton(sender);
                ShowForm(new frmCourse());
            }
        }

        private void btnProfessor_Click(object sender, EventArgs e)
        {
            if (currentActiveButton == sender) return;
            if (CanChangeWindow())
            {
                ActivateButton(sender);
                ShowForm(new frmFaculty());
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
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e) { }



        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanelMain_Paint(object sender, PaintEventArgs e)
        {

        }



    }
}