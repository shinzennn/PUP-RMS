using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection; // Required for Double Buffer logic
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PUP_RMS.Forms
{
    public partial class frmAdminTool : Form
    {
        // Forms to be loaded into the panel
        private frmProgram _programForm;
        private frmCourse _courseForm;    // Changed from Label to Form
        private frmFaculty _facultyForm;  // Changed from Label to Form

        // Keep curriculum as placeholder for now (unless you have a frmCurriculum)
        private Label _curriculumPlaceholder;

        public frmAdminTool()
        {
            // 1. ENABLE GLOBAL DOUBLE BUFFERING FOR THIS FORM
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.DoubleBuffer |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();

            InitializeComponent();

            // 2. FORCE PANEL TO BE DOUBLE BUFFERED
            SetDoubleBuffered(panelMainContent);

            SetInitialButtonState();
        }

        // 3. PREVENT BACKGROUND PAINTING FLICKER (WS_EX_COMPOSITED)
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // WS_EX_COMPOSITED (Paint all descendants at once)
                return cp;
            }
        }

        // 4. HELPER TO FORCE DOUBLE BUFFERING ON PANELS
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession) return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (aProp != null) aProp.SetValue(c, true, null);
        }

        private void FrmAdminToolLoad(object sender, EventArgs e)
        {
            // Suspend layout during initial load to prevent visual stutter
            this.SuspendLayout();
            panelMainContent.SuspendLayout();

            InitializeContentControls();

            // Resume layout after controls are created
            panelMainContent.ResumeLayout();
            this.ResumeLayout();
        }

        private void SetInitialButtonState()
        {
            Color whiteColor = Color.FromArgb(253, 243, 230);
            Color goldColor = Color.Goldenrod;

            btnManageCurriculums.BackColor = whiteColor;
            btnManageCurriculums.ForeColor = goldColor;
            btnManagePrograms.BackColor = whiteColor;
            btnManagePrograms.ForeColor = goldColor;
            btnManageCourses.BackColor = whiteColor;
            btnManageCourses.ForeColor = goldColor;
            btnManageFaculties.BackColor = whiteColor;
            btnManageFaculties.ForeColor = goldColor;

            // Default selection
            btnManageCurriculums.BackColor = Color.FromArgb(93, 16, 10);
        }

        private void BtnManageCurriculumsClick(object sender, EventArgs e)
        {
            // 5. FREEZE UI WHILE SWITCHING
            panelMainContent.SuspendLayout();

            ResetButtonColors();
            btnManageCurriculums.BackColor = Color.FromArgb(93, 16, 10);
            btnManageCurriculums.ForeColor = Color.Goldenrod;

            HideAllContent();
            ShowOnly(_curriculumPlaceholder);

            // 6. UNFREEZE UI
            panelMainContent.ResumeLayout();
        }

        private void BtnManageProgramsClick(object sender, EventArgs e)
        {
            panelMainContent.SuspendLayout();

            ResetButtonColors();
            btnManagePrograms.BackColor = Color.FromArgb(93, 16, 10);
            btnManagePrograms.ForeColor = Color.Goldenrod;

            HideAllContent();
            ShowOnly(_programForm);

            panelMainContent.ResumeLayout();
        }

        private void BtnManageCoursesClick(object sender, EventArgs e)
        {
            panelMainContent.SuspendLayout();

            ResetButtonColors();
            btnManageCourses.BackColor = Color.FromArgb(93, 16, 10);
            btnManageCourses.ForeColor = Color.Goldenrod;

            HideAllContent();
            ShowOnly(_courseForm); // Show the Course Form

            panelMainContent.ResumeLayout();
        }

        private void BtnManageFacultiesClick(object sender, EventArgs e)
        {
            panelMainContent.SuspendLayout();

            ResetButtonColors();
            btnManageFaculties.BackColor = Color.FromArgb(93, 16, 10);
            btnManageFaculties.ForeColor = Color.Goldenrod;

            HideAllContent();
            ShowOnly(_facultyForm); // Show the Faculty Form

            panelMainContent.ResumeLayout();
        }

        private void ResetButtonColors()
        {
            Color whiteColor = Color.FromArgb(253, 243, 230);
            Color goldColor = Color.Goldenrod;

            btnManageCurriculums.BackColor = whiteColor;
            btnManageCurriculums.ForeColor = goldColor;
            btnManagePrograms.BackColor = whiteColor;
            btnManagePrograms.ForeColor = goldColor;
            btnManageCourses.BackColor = whiteColor;
            btnManageCourses.ForeColor = goldColor;
            btnManageFaculties.BackColor = whiteColor;
            btnManageFaculties.ForeColor = goldColor;
        }

        private void InitializeContentControls()
        {
            var maroonColor = Color.FromArgb(93, 16, 10);
            var boldFont = new Font("Segoe UI", 16, FontStyle.Bold);

            // -- 1. Initialize Program Form --
            _programForm = new frmProgram
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                Visible = false
            };
            SetDoubleBuffered(_programForm);

            // -- 2. Initialize Course Form (New) --
            _courseForm = new frmCourse
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                Visible = false
            };
            SetDoubleBuffered(_courseForm);

            // -- 3. Initialize Faculty Form (New) --
            _facultyForm = new frmFaculty
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                Visible = false
            };
            SetDoubleBuffered(_facultyForm);

            // -- 4. Initialize Placeholder (Only for Curriculum now) --
            _curriculumPlaceholder = CreatePlaceholder("Curriculum Management Module", boldFont, maroonColor);

            // -- 5. Add ALL to panel immediately (Pre-loading) --
            panelMainContent.Controls.Add(_programForm);
            panelMainContent.Controls.Add(_courseForm);
            panelMainContent.Controls.Add(_facultyForm);
            panelMainContent.Controls.Add(_curriculumPlaceholder);

            // Show default
            _curriculumPlaceholder.Visible = true;
        }

        private Label CreatePlaceholder(string text, Font font, Color color)
        {
            return new Label
            {
                Text = text,
                Font = font,
                ForeColor = color,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Visible = false // Start hidden
            };
        }

        private void HideAllContent()
        {
            if (_programForm != null) _programForm.Visible = false;
            if (_courseForm != null) _courseForm.Visible = false;
            if (_facultyForm != null) _facultyForm.Visible = false;
            if (_curriculumPlaceholder != null) _curriculumPlaceholder.Visible = false;
        }

        private void ShowOnly(Control controlToShow)
        {
            if (controlToShow != null)
            {
                controlToShow.Visible = true;
                controlToShow.BringToFront();
            }
        }
    }
}