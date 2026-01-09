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
using System.Windows.Shapes;

namespace PUP_RMS.Forms
{
    public partial class frmCourse : Form
    {
        public frmCourse()
        {
            InitializeComponent();
        }

        private void frmCourse_Load(object sender, EventArgs e)
        {
            RefreshGrid();

            dgvCourse.Columns["CourseID"].Width = 50;
            dgvCourse.Columns["CourseCode"].Width = 100;
            
        }

        // DATA GRID VIEW ROW HOVER COLOR CHANGE
        private void dgvCourse_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                dgvCourse.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Goldenrod;
            }
        }
        private void dgvCourse_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvCourse.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty;
            }
        }

        // CONTROL METHODS
        private void RefreshGrid()
        {
            dgvCourse.DataSource = Core.DbControl.GetData("SELECT * FROM Course");
            dgvCourse.ClearSelection();
            dgvCourse.CurrentCell = null;
        }

        private void SearchCourse() 
        {
            if(txtSearch.Text != null) 
            {
                dgvCourse.DataSource = Core.DbControl.GetData($"SELECT * FROM Course WHERE CourseCode LIKE '%{txtSearch.Text}%' OR CourseDecription LIKE '%{txtSearch.Text}%';");
                dgvCourse.ClearSelection();
                dgvCourse.CurrentCell = null;
            }
            
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Forms.frmNewCourse newCourseForm = new Forms.frmNewCourse();

            if (newCourseForm.ShowDialog() == DialogResult.OK) 
            { 
                RefreshGrid();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchCourse();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void dgvCourse_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dgvCourse.Rows[e.RowIndex];
            frmEditCourse editCourseForm = new frmEditCourse();

            if(selectedRow != null) 
            {
                editCourseForm.courseID = Convert.ToInt32(selectedRow.Cells["CourseID"].Value);
            }

            if (editCourseForm.ShowDialog() == DialogResult.OK) 
            {
                RefreshGrid();
            }
            
        }

        
    }
}
