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
    public partial class frmCourse : Form
    {
        public frmCourse()
        {
            InitializeComponent();
        }

        private void frmCourse_Load(object sender, EventArgs e)
        {
            dgvCourse.DataSource = Core.DbControl.GetData("SELECT * FROM Course");

            dgvCourse.Columns["CourseID"].Width = 50;
            dgvCourse.Columns["CourseCode"].Width = 100;
            
        }

        private void frmCourse_Shown(object sender, EventArgs e)
        {
            dgvCourse.ClearSelection();
            dgvCourse.CurrentCell = null;
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
    }
}
