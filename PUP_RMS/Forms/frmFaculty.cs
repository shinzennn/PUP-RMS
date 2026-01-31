using PUP_RMS.Helper;
using PUP_RMS.Model;
using System;
using System.Windows.Forms;

namespace PUP_RMS.Forms
{
    public partial class frmFaculty : Form
    {
        public frmFaculty()
        {
            // Anti-flicker settings
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            InitializeComponent();

            ApplyDoubleBufferingRecursively(this.Controls);

            // Start hidden (important for child forms)
            this.Visible = false;

        }
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
                    ApplyDoubleBufferingRecursively(c.Controls);
            }
        }

        private static void SetDoubleBuffered(Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession) return;

            System.Reflection.PropertyInfo prop = typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            prop?.SetValue(c, true, null);
        }

        DataGridViewRow selectedRow = null;
        int btnClickState = 0; // 0 - None, 1 - Create, 2 - Edit

        private void frmFaculty_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
            RefreshGrid();
            FacultyTextboxEnable(false);
            panelFacultyForm.ShadowDepth = 6;
        }
        public void loadData()
        {
            RefreshGrid();
        } 
        private void dgvFacultyColumnDesign()
        {
            dgvFaculty.Columns["FacultyID"].Visible = false;
            dgvFaculty.Columns["FirstName"].Visible = false;
            dgvFaculty.Columns["LastName"].Visible = false;
            dgvFaculty.Columns["MiddleName"].Visible = false;

        }
        private void RefreshGrid()
        {
            dgvFaculty.DataSource = FacultyHelper.GetAllFaculty();
            dgvFaculty.ClearSelection();
            dgvFaculty.CurrentCell = null;
            dgvFacultyColumnDesign();

        }
        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            RefreshGrid();
            txtSearch.Text = "";
        }
        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            dgvFaculty.DataSource = FacultyHelper.SearchFaculty(searchTerm);

            // EXECUTE QUERY
            dgvFaculty.DataSource = FacultyHelper.SearchFaculty(searchTerm);

        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            txtFirstName.Focus();
            btnClickState = 1; // CREATE
            FacultyTextboxEnable(true);
            panelFacultyForm.ShadowDepth = 10;
            dgvFaculty.Enabled = false;
            btnEdit.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;

            btnCreate.Visible = false;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtFirstName.Focus();
            btnClickState = 2; // EDIT
            FacultyTextboxEnable(true); 
            panelFacultyForm.ShadowDepth = 10;
            btnCreate.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;

            txtFirstName.Text = selectedRow.Cells["FirstName"].Value.ToString();
            txtMiddleName.Text = selectedRow.Cells["MiddleName"].Value.ToString();
            txtLastName.Text = selectedRow.Cells["LastName"].Value.ToString();

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // VALIDATION
            if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // GET SELECTED FACULTY ID IF EDITING
            int facultyID = 0;
            if (selectedRow != null && btnClickState == 2)
            {
                facultyID = Convert.ToInt32(selectedRow.Cells["FacultyID"].Value);
            }

            string fullName = FacultyHelper.ConstructFullname(txtFirstName.Text.Trim(), txtMiddleName.Text.Trim(), txtLastName.Text.Trim());
            string initials = FacultyHelper.ConstructInitials(fullName);
            // CREATE FACULTY OBJECT
            Faculty faculty = new Faculty
            {
                FirstName = txtFirstName.Text.Trim(),
                MiddleName = txtMiddleName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Initials = initials
            };

            // CHECK BUTTON CLICK STATE
            if (btnClickState == 1)
            {
                // CALL CREATE FACULTY METHOD
                FacultyHelper.CreateFaculty(faculty);
            }
            if (btnClickState == 2)
            {
                // ADD FACULTY ID TO OBJECT
                if (facultyID != 0) faculty.FacultyID = facultyID;

                // CALL EDIT FACULTY METHOD
                FacultyHelper.UpdateFaculty(faculty);
            }

            // REFRESH GRID
            RefreshGrid();

            // REFRESH FORM AND BUTTON
            btnClickState = 0;
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            FacultyTextboxEnable(false);
            panelFacultyForm.ShadowDepth = 6;
            dgvFaculty.Enabled = true;
            btnCreate.Visible = true;
            btnEdit.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // REFRESH FORM AND BUTTON
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            FacultyTextboxEnable(false);
            panelFacultyForm.ShadowDepth = 6;
            dgvFaculty.Enabled = true;
            btnCreate.Visible = true;
            btnEdit.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
        }

        private void dgvFaculty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = dgvFaculty.Rows[e.RowIndex];

            if (selectedRow != null)
            {
                btnEdit.Visible = true;
            }
        }
        
        private void FacultyTextboxEnable(bool state)
        {
            label3.Enabled = state;
            label4.Enabled = state;
            label5.Enabled = state;
            txtFirstName.Enabled = state;
            txtMiddleName.Enabled = state;
            txtLastName.Enabled = state;
        }


        private void dgvFaculty_CellMouseEnter(object sender, DataGridViewCellEventArgs e) { }
        private void dgvFaculty_CellMouseLeave(object sender, DataGridViewCellEventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }

        private void cbxProgram_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMiddleName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

