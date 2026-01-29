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
using PUP_RMS.Helper;
using PUP_RMS.Model;

namespace PUP_RMS.Forms
{
    public partial class frmProgram : Form
    {
        public frmProgram()
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

        private void frmProgram_Load(object sender, EventArgs e)
        {
            this.SuspendLayout(); // Freeze

            txtSearch.Focus();
            RefreshGrid();

            this.ResumeLayout(); // Unfreeze
        }

        public void Reset()
        {
            // 5. FREEZE LAYOUT DURING UPDATES
            this.SuspendLayout();

            txtProgamCode.Clear();
            txtProgramDesc.Clear();
            txtSearch.Clear();
            panelProginfo.Enabled = false;
            dgvProgram.Enabled = true;
            btnEdit.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnClickState = 0;
            selectedRow = null;
            RefreshGrid();

            this.ResumeLayout();
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
            cbxCurriculum.DisplayMember = "CurriculumYear";
            cbxCurriculum.ValueMember = "CurriculumID";
            cbxCurriculum.DataSource = CourseHelper.GetAllCurriculum();
            cbxCurriculum.SelectedIndex = -1;

            dgvProgram.DataSource = ProgramHelper.GetAllProgram();
            dgvProgram.ClearSelection();
            dgvProgram.CurrentCell = null;

            // Check if column exists before setting properties to avoid errors
            if (dgvProgram.Columns.Contains("ProgramID"))
                dgvProgram.Columns["ProgramID"].Visible = false;

            if (dgvProgram.Columns.Contains("ProgramCode"))
                dgvProgram.Columns["ProgramCode"].Width = 180;
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            // VALIDATION
            if (string.IsNullOrEmpty(txtProgamCode.Text) || string.IsNullOrEmpty(txtProgramDesc.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // GET SELECTED PROGRAM ID IF EDITING
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
                // CALL CREATE METHOD
                ProgramHelper.CreatProgram(program);
                Reset();
            }
            if (btnClickState == 2)
            {
                // ADD ID TO OBJECT
                if (progID != 0) program.ProgramID = progID;

                // CALL EDIT METHOD
                ProgramHelper.UpdateProgram(program);
                Reset();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.SuspendLayout(); // Freeze UI changes

            txtProgamCode.Focus();
            btnClickState = 1; // CREATE
            panelProginfo.Enabled = true;
            dgvProgram.Enabled = false;
            btnEdit.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;

            this.ResumeLayout(); // Resume UI
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.SuspendLayout(); // Freeze UI changes

            txtProgamCode.Focus();
            btnClickState = 2; // EDIT
            panelProginfo.Enabled = true;
            btnSave.Visible = true;
            btnCancel.Visible = true;

            if (selectedRow != null)
            {
                txtProgamCode.Text = selectedRow.Cells["ProgramCode"].Value.ToString();
                txtProgramDesc.Text = selectedRow.Cells["ProgramDescription"].Value.ToString();
            }

            this.ResumeLayout(); // Resume UI
        }

        private void dgvProgram_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow = dgvProgram.Rows[e.RowIndex];
                if (selectedRow != null)
                {
                    btnEdit.Visible = true;
                }
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
            dgvProgram.DataSource = ProgramHelper.SearchProgram(searchTerm, cbxCurriculum.Text);

            if (dgvProgram.Columns.Contains("ProgramCode"))
                dgvProgram.Columns["ProgramCode"].Width = 180;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reset();
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cbxCurriculum_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvProgram.DataSource = ProgramHelper.GetProgramByCurriculum(cbxCurriculum.Text);
            dgvProgram.ClearSelection();
            dgvProgram.CurrentCell = null;
            dgvProgram.Columns["ProgramID"].Visible = false;
            dgvProgram.Columns["ProgramCode"].Width = 180;
        }
    }
}