using PUP_RMS.Core;
using PUP_RMS.Model;
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
    public partial class frmViewSection : Form
    {
        string curriculumYear = "";
        string programCode = "";
        string schoolYear = "";
        int section = 0;

        public frmViewSection(string _curriculumYear, string _programCode, string _schoolYear, int _section)
        {
            curriculumYear = _curriculumYear;
            programCode = _programCode;
            schoolYear = _schoolYear;
            section = _section;

            InitializeComponent();
        }

        private void frmViewSection_Load(object sender, EventArgs e)
        {
            lblHeader.Text = programCode + " | " + schoolYear + " | Section: " + section.ToString();

            flowCourseFaculty.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(DbControl.ConnString("RMSDB")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetSubjectFacultyAssignment", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProgramCode", programCode);
                    cmd.Parameters.AddWithValue("@CurriculumYear", curriculumYear);
                    cmd.Parameters.AddWithValue("@SchoolYear", schoolYear);
                    cmd.Parameters.AddWithValue("@Section", section);

                    try
                    {
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // 2. Get unique combinations of YearLevel and Semester from the data
                        var groupings = dt.AsEnumerable()
                            .Select(row => new
                            {
                                Year = row.Field<int>("YearLevel"),
                                Sem = row.Field<int>("Semester")
                            })
                            .Distinct()
                            .OrderBy(x => x.Year).ThenBy(x => x.Sem);

                        foreach (var group in groupings)
                        {
                            // 3. Create a Title for each section
                            Label lblTitle = new Label
                            {
                                Text = $"Year: {group.Year} - {group.Sem} Semester",
                                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                                AutoSize = true,
                                Margin = new Padding(0, 10, 0, 5)
                            };
                            flowCourseFaculty.Controls.Add(lblTitle);

                            // 4. Create and Setup the Grid
                            DataGridView dgv = new DataGridView();
                            SetupGridProperties(dgv); // Helper method for styling

                            // 5. Filter the DataTable for just this Year/Sem
                            DataView dv = new DataView(dt);
                            dv.RowFilter = $"YearLevel = '{group.Year}' AND Semester = '{group.Sem}'";
                            dgv.DataSource = dv;

                            // Adjust height based on number of rows
                            int rowHeight = dgv.RowTemplate.Height;
                            int headerHeight = dgv.ColumnHeadersHeight;
                            dgv.Height = (dv.Count * rowHeight) + headerHeight + 5;


                            flowCourseFaculty.Controls.Add(dgv);

                            dgv.Columns["YearLevel"].Visible = false;
                            dgv.Columns["Semester"].Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to Find the Curriculum | Error:" + ex.Message);
                    }

                }
            }
        }

        private void SetupGridProperties(DataGridView dgv)
        {


            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.ScrollBars = ScrollBars.None;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Explicitly set heights so the math works
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 40;
            dgv.RowTemplate.Height = 35;

            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10f);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12f, FontStyle.Bold);

            dgv.Width = flowCourseFaculty.Width - 25; // Account for scrollbar



        }
    }
}
