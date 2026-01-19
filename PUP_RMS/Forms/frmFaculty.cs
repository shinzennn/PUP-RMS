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
            InitializeComponent();
        }

        DataGridViewRow selectedRow = null;
        int btnClickState = 0; // 0 - None, 1 - Create, 2 - Edit

        private void frmFaculty_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
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


            cbxProgram.DisplayMember = "ProgramCode";
            cbxProgram.ValueMember = "ProgramID";
            cbxProgram.DataSource = FacultyHelper.GetAllProgram();
            cbxProgram.SelectedIndex = -1;

        }
        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            RefreshGrid();
            txtSearch.Text = "";
            cbxProgram.SelectedIndex = -1;
        }
        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            int selectedID = Convert.ToInt32(cbxProgram.SelectedValue);
            string searchTerm = txtSearch.Text.Trim();

            // VALIDATION
            if (!string.IsNullOrEmpty(searchTerm) && cbxProgram.Text == "")
            {
                dgvFaculty.DataSource = FacultyHelper.SearchFaculty(searchTerm);
                return;
            }

            // EXECUTE QUERY
            dgvFaculty.DataSource = FacultyHelper.SearchFaculty(searchTerm, selectedID);

        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            txtFirstName.Focus();
            btnClickState = 1; // CREATE
            panelFacultyForm.Enabled = true;
            dgvFaculty.Enabled = false;
            btnEdit.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtFirstName.Focus();
            btnClickState = 2; // EDIT
            panelFacultyForm.Enabled = true;
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
            panelFacultyForm.Enabled = false;
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
            panelFacultyForm.Enabled = false;
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


        private void dgvFaculty_CellMouseEnter(object sender, DataGridViewCellEventArgs e) { }
        private void dgvFaculty_CellMouseLeave(object sender, DataGridViewCellEventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }


    }
}

