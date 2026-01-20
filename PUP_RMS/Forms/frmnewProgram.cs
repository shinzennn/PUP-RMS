using PUP_RMS.Helper;
using PUP_RMS.Model;
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
    public partial class frmnewProgram : Form
    {
        public frmnewProgram()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            dgvProgram.DataSource = ProgramHelper.GetAllProgram();
            dgvProgram.ClearSelection();
            dgvProgram.CurrentCell = null;
            dgvProgram.Columns["ProgramID"].Visible = false;
            dgvProgram.Columns["ProgramCode"].Width = 180;
            // VALIDATION
            if (string.IsNullOrEmpty(txtProgamCode.Text) || string.IsNullOrEmpty(txtProgramDesc.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // CREATE PROGRAM OBJECT
            Programs program = new Programs
            {
                ProgramID = dgvProgram.CurrentRow != null ? Convert.ToInt32(dgvProgram.CurrentRow.Cells["ProgramID"].Value) : 0,
                ProgramCode = txtProgamCode.Text.Trim(),
                ProgramDescription = txtProgramDesc.Text.Trim()

            };


                // CALL CREATE FACULTY METHOD
                ProgramHelper.CreatProgram(program);

            this.DialogResult = DialogResult.OK;



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
