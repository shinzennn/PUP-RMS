using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;
using PUP_RMS.Helper;
using System.Windows.Controls;
using PUP_RMS.Model;

namespace PUP_RMS.Forms
{
    public partial class frmProgram : Form
    {
        public frmProgram()
        {
            InitializeComponent();
        }

        DataGridViewRow selectedRow = null;
        int btnClickState = 0; // 0 - None, 1 - Create, 2 - Edit

       
        public void Reset()
        {
            txtProgamCode.Clear();
            txtProgramDesc.Clear();
            txtSearch.Clear();
            panelProginfo.Enabled = false;
            dgvProgram.Enabled = true;
            btnEdit.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnClickState = 0;
            selectedRow = null;
            RefreshGrid();
        }


        // DATA GRID VIEW ROW HOVER COLOR CHANGE
        private void dgvProgram_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvProgram.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Goldenrod;
            }
        }
        private void dgvProgram_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvProgram.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty;
            }
        }


        // CONTROL METHODS
        private void RefreshGrid()
        {
            dgvProgram.DataSource = ProgramHelper.GetAllProgram();
            dgvProgram.ClearSelection();
            dgvProgram.CurrentCell = null;
            dgvProgram.Columns["ProgramID"].Visible = false;
        }

        private void frmProgram_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
            RefreshGrid();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // VALIDATION
            if (string.IsNullOrEmpty(txtProgamCode.Text) || string.IsNullOrEmpty(txtProgramDesc.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // GET SELECTED FACULTY ID IF EDITING
            int progID = 0;
            if (selectedRow != null && btnClickState == 2)
            {
                progID = Convert.ToInt32(selectedRow.Cells["ProgramID"].Value);
            }
            // CREATE PROGRAM OBJECT
            Programs program = new Programs
            {
                ProgramID = progID,
                ProgramCode = txtProgamCode.Text.Trim(),
                ProgramDescription = txtProgramDesc.Text.Trim()

            };

            // CHECK BUTTON CLICK STATE
            if (btnClickState == 1)
            {
                // CALL CREATE FACULTY METHOD
                ProgramHelper.CreatProgram(program);
                Reset();
            }
            if (btnClickState == 2)
            {
                // ADD FACULTY ID TO OBJECT
                if (progID != 0) program.ProgramID = progID;

                // CALL EDIT FACULTY METHOD
               ProgramHelper.UpdateProgram(program);
                Reset();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            txtProgamCode.Focus();
            btnClickState = 1; // CREATE
            panelProginfo.Enabled = true;
            dgvProgram.Enabled = false;
            btnEdit.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtProgamCode.Focus();
            btnClickState = 2; // EDIT
            panelProginfo.Enabled = true;
            btnCreate.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;

            txtProgamCode.Text = selectedRow.Cells["ProgramCode"].Value.ToString();
            txtProgramDesc.Text = selectedRow.Cells["ProgramDescription"].Value.ToString();
        }

        private void dgvProgram_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = dgvProgram.Rows[e.RowIndex];

            if (selectedRow != null)
            {
                btnEdit.Visible = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // VALIDATION
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                return;
            }

            string searchTerm = txtSearch.Text.Trim();

            // EXECUTE QUERY
            dgvProgram.DataSource = ProgramHelper.SearchProgram(searchTerm);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
