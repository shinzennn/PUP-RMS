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
    public partial class frmProfessor : Form
    {
        public frmProfessor()
        {
            InitializeComponent();
        }

        private void RefreshGrid()
        {
            dgvProfessor.DataSource = Core.DbControl.GetData("SELECT * FROM Faculty");
            dgvProfessor.ClearSelection();
            dgvProfessor.CurrentCell = null;
        }

        private void SearchProfessor()
        {
            if (txtSearch.Text != null)
            {
                dgvProfessor.DataSource = Core.DbControl.GetData($"SELECT * FROM Faculty WHERE FirstName LIKE '%{txtSearch.Text}%' OR LastName LIKE '%{txtSearch.Text}%';");
                dgvProfessor.ClearSelection();
                dgvProfessor.CurrentCell = null;
            }
        }
        private void dgvProfessor_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvProfessor_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvProfessor.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty;
            }
        }

        private void frmProfessor_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                SearchProfessor();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmNewProfessor newProfessor = new frmNewProfessor();
            if (newProfessor.ShowDialog() == DialogResult.OK)
            {
                RefreshGrid();
            }
        }

        private void dgvProfessor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dgvProfessor.Rows[e.RowIndex];
            frmEditProfessor editProfessorForm = new frmEditProfessor();

            if(selectedRow != null)
            {
                editProfessorForm.professorID = Convert.ToInt32(selectedRow.Cells["FacultyID"].Value);
            }
            
            if(editProfessorForm.ShowDialog() == DialogResult.OK) 
            {
                RefreshGrid();
            }
        }
    }
}
