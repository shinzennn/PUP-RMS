using PUP_RMS.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PUP_RMS.Forms
{
    public partial class frmSearchView : Form
    {
        string curriculumYear = "";
        int programID = 0;
        string programCode = "";
        public frmSearchView(string receivedCurriculumYear, int receivedProgramID, string receivedProgramCode)
        {
            curriculumYear = receivedCurriculumYear;
            programID = receivedProgramID;
            programCode = receivedProgramCode;
            InitializeComponent();
        }

        private void frmSearchView_Load(object sender, EventArgs e)
        {
            lblHeader.Text = programCode + " - " + curriculumYear;

            dgvCurriculum.DataSource = null;
            dgvCurriculum.Rows.Clear();

            using (SqlConnection conn = new SqlConnection(DbControl.ConnString("RMSDB")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_SearchViewCurriculum", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProgramID", programID);
                    cmd.Parameters.AddWithValue("@CurriculumYear", curriculumYear);

                    try
                    {
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvCurriculum.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to Find the Curriculum | Error:" + ex.Message);
                    }

                }

            }


        }
    }
}
