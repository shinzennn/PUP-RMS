using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PUP_RMS.Forms
{
    public partial class frmAdminTool : Form
    {
        public frmAdminTool()
        {
            InitializeComponent();
            // Set initial state - Manage Curriculums selected, others white
            SetInitialButtonState();
        }

        private void SetInitialButtonState()
        {
            Color whiteColor = Color.FromArgb(253, 243, 230);
            Color goldColor = Color.Goldenrod;

            // Set all buttons to white background initially
            btnManageCurriculums.BackColor = whiteColor;
            btnManageCurriculums.ForeColor = goldColor;
            btnManagePrograms.BackColor = whiteColor;
            btnManagePrograms.ForeColor = goldColor;
            btnManageCourses.BackColor = whiteColor;
            btnManageCourses.ForeColor = goldColor;
            btnManageFaculties.BackColor = whiteColor;
            btnManageFaculties.ForeColor = goldColor;

            // Set Manage Curriculums as initially selected (maroon background)
            btnManageCurriculums.BackColor = Color.FromArgb(93, 16, 10);
        }

        private void adminToolCardButton2_Click(object sender, EventArgs e)
        {

        }

        private void btnManageCurriculums_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnManageCurriculums.BackColor = Color.FromArgb(93, 16, 10);
            btnManageCurriculums.ForeColor = Color.Goldenrod;
            
            // Clear existing content and load curriculum management
            ClearMainContent();
            LoadCurriculumManagement();
        }

        private void btnManagePrograms_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnManagePrograms.BackColor = Color.FromArgb(93, 16, 10);
            btnManagePrograms.ForeColor = Color.Goldenrod;
            
            // Clear existing content and load frmProgram
            ClearMainContent();
            LoadProgramManagement();
        }

        private void btnManageCourses_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnManageCourses.BackColor = Color.FromArgb(93, 16, 10);
            btnManageCourses.ForeColor = Color.Goldenrod;
            
            // Clear existing content and load course management
            ClearMainContent();
            LoadCourseManagement();
        }

        private void btnManageFaculties_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnManageFaculties.BackColor = Color.FromArgb(93, 16, 10);
            btnManageFaculties.ForeColor = Color.Goldenrod;
            
            // Clear existing content and load faculty management
            ClearMainContent();
            LoadFacultyManagement();
        }

        private void ResetButtonColors()
        {
            Color whiteColor = Color.FromArgb(253, 243, 230);
            Color goldColor = Color.Goldenrod;

            // Reset all buttons to white background with gold text
            btnManageCurriculums.BackColor = whiteColor;
            btnManageCurriculums.ForeColor = goldColor;
            btnManagePrograms.BackColor = whiteColor;
            btnManagePrograms.ForeColor = goldColor;
            btnManageCourses.BackColor = whiteColor;
            btnManageCourses.ForeColor = goldColor;
            btnManageFaculties.BackColor = whiteColor;
            btnManageFaculties.ForeColor = goldColor;
        }

        private void ClearMainContent()
        {
            // Clear any existing controls from the main content panel
            panelMainContent.Controls.Clear();
        }

        private void LoadProgramManagement()
        {
            // Create and show frmProgram within the main content panel
            frmProgram programForm = new frmProgram();
            programForm.TopLevel = false; // Make it a child control
            programForm.FormBorderStyle = FormBorderStyle.None;
            programForm.Dock = DockStyle.Fill;

            panelMainContent.Controls.Add(programForm);
            programForm.Show();
        }

        private void LoadCurriculumManagement()
        {
            // TODO: Load curriculum management form/UserControl here
            // For now, show placeholder
            Label placeholder = new Label();
            placeholder.Text = "Curriculum Management Module";
            placeholder.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            placeholder.ForeColor = Color.FromArgb(93, 16, 10);
            placeholder.TextAlign = ContentAlignment.MiddleCenter;
            placeholder.Dock = DockStyle.Fill;
            panelMainContent.Controls.Add(placeholder);
        }

        private void LoadCourseManagement()
        {
            // TODO: Load course management form/UserControl here
            Label placeholder = new Label();
            placeholder.Text = "Course Management Module";
            placeholder.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            placeholder.ForeColor = Color.FromArgb(93, 16, 10);
            placeholder.TextAlign = ContentAlignment.MiddleCenter;
            placeholder.Dock = DockStyle.Fill;
            panelMainContent.Controls.Add(placeholder);
        }

        private void LoadFacultyManagement()
        {
            // TODO: Load faculty management form/UserControl here
            Label placeholder = new Label();
            placeholder.Text = "Faculty Management Module";
            placeholder.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            placeholder.ForeColor = Color.FromArgb(93, 16, 10);
            placeholder.TextAlign = ContentAlignment.MiddleCenter;
            placeholder.Dock = DockStyle.Fill;
            panelMainContent.Controls.Add(placeholder);
        }
    }
}
