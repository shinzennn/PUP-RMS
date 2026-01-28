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
            // 1. ENABLE FORM-LEVEL DOUBLE BUFFERING
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.DoubleBuffer |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();

            InitializeComponent();

            // 2. FORCE CONTROLS TO BE DOUBLE BUFFERED
            SetDoubleBuffered(panelProginfo);
            SetDoubleBuffered(dgvProgram);
        }

        // 3. PREVENT BACKGROUND PAINTING FLICKER (WS_EX_COMPOSITED)
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on Composited Painting
                return cp;
            }
        }

        // 4. HELPER METHOD FOR DOUBLE BUFFERING CONTROLS
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession) return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (aProp != null) aProp.SetValue(c, true, null);
        }

        DataGridViewRow selectedRow = null;
        int btnClickState = 0; // 0 - None, 1 - Create, 2 - Edit

        public void Reset()
        {
            // 5. FREEZE LAYOUT DURING UPDATES
            this.SuspendLayout();

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
            dgvProgram.DataSource = ProgramHelper.GetAllProgram();
            dgvProgram.ClearSelection();
            dgvProgram.CurrentCell = null;

            // Check if column exists before setting properties to avoid errors
            if (dgvProgram.Columns.Contains("ProgramID"))
                dgvProgram.Columns["ProgramID"].Visible = false;

            if (dgvProgram.Columns.Contains("ProgramCode"))
                dgvProgram.Columns["ProgramCode"].Width = 180;
        }

        private void frmProgram_Load(object sender, EventArgs e)
        {
            this.SuspendLayout(); // Freeze

            txtSearch.Focus();
            RefreshGrid();

            this.ResumeLayout(); // Unfreeze
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
            btnCreate.Visible = false;
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
            dgvProgram.DataSource = ProgramHelper.SearchProgram(searchTerm);

            if (dgvProgram.Columns.Contains("ProgramCode"))
                dgvProgram.Columns["ProgramCode"].Width = 180;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}