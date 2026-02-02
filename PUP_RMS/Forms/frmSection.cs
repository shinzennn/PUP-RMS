using Dapper;
using FontAwesome.Sharp;
using PUP_RMS.Core;
using PUP_RMS.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace PUP_RMS
{
    public partial class frmSection : Form
    {
        bool Editable = false;

        public frmSection()
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

        private SqlConnection GetConnection()
        {
            return new SqlConnection(
                ConfigurationManager.ConnectionStrings["RMSDB"].ConnectionString
            );
        }

        private void frmSection_Load(object sender, EventArgs e)
        {
            LoadCurriculumYear();
            LoadAcademicYears();
            EditButton();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(!Editable)
            {
                LoadCourses();
            }
            else
            {
                EditCourses();
            }
            
        }

        private void EditButton()
        {
            if(Editable == true)
            {
                label6.Show();
                label7.Show();
                cbxSectionFilter.Show();
                cbxSchoolYearFilter.Show();
            }
            else
            {
                label6.Hide();
                label7.Hide();
                cbxSectionFilter.Hide();
                cbxSectionFilter.Hide();
                cbxSchoolYearFilter.Hide();
            }
        }

        private void LoadCurriculumYear()
        {
            string sql = @"
        SELECT DISTINCT CurriculumYear
        FROM CurriculumHeader
        ORDER BY CurriculumYear";

            using (var con = GetConnection())
            {
                cbxCurriculum.DataSource =
                    con.Query<string>(sql).ToList();
            }
        }

        private void LoadProgram(string year)
        {
            string sql = @"
        SELECT DISTINCT P.ProgramCode
        FROM Program P
        INNER JOIN CurriculumHeader CR
            ON P.ProgramID = CR.ProgramID
        WHERE CR.CurriculumYear = @Year
        ORDER BY P.ProgramCode";

            using (var con = GetConnection())
            {
                cbxProgram.DataSource =
                    con.Query<string>(sql, new { Year = year }).ToList();
            }
        }

        private void curriculumYearCmbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCurriculum.SelectedItem == null) return;

            LoadProgram(cbxCurriculum.SelectedItem.ToString());
        }

        private void LoadYearLevel(string year, string program)
        {
            string sql = @"
        SELECT DISTINCT C.YearLevel
        FROM Curriculum C
        INNER JOIN CurriculumHeader CH
            ON C.CurriculumHeaderID = CH.CurriculumHeaderID
        INNER JOIN Program P
            ON CH.ProgramID = P.ProgramID
        WHERE CH.CurriculumYear = @Year
          AND P.ProgramCode = @Program
        ORDER BY C.YearLevel";

            using (var con = GetConnection())
            {
                cbxYearLevel.DataSource =
                    con.Query<int>(sql, new { Year = year, Program = program }).ToList();
            }
        }

        private void programCmbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxProgram.SelectedItem == null) return;

            LoadYearLevel(
                cbxCurriculum.Text,
                cbxProgram.Text
            );
        }

        private void LoadSemester(string year, string program, int yearLevel)
        {
            string sql = @"
        SELECT DISTINCT C.Semester
        FROM Curriculum C
        INNER JOIN CurriculumHeader CH
            ON C.CurriculumHeaderID = CH.CurriculumHeaderID
        INNER JOIN Program P
            ON CH.ProgramID = P.ProgramID
        WHERE CH.CurriculumYear = @Year
          AND P.ProgramCode = @Program
          AND C.YearLevel = @YearLevel
        ORDER BY C.Semester";

            using (var con = GetConnection())
            {
                cbxSemester.DataSource =
                    con.Query<int>(sql, new
                    {
                        Year = year,
                        Program = program,
                        YearLevel = yearLevel
                    }).ToList();
            }
        }

        private void yearLevelCmbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxYearLevel.SelectedItem == null) return;

            LoadSemester(
                cbxCurriculum.Text,
                cbxProgram.Text,
                Convert.ToInt32(cbxYearLevel.SelectedItem)
            );
        }

        private void LoadCourses()
        {
            string sql = @"
            SELECT 
                C.CourseCode,
                C.CourseDescription,
                CS.Section,
                CS.FacultyID 
            FROM Offering O
            INNER JOIN Course C ON O.CourseID = C.CourseID
            INNER JOIN Curriculum CU ON O.CurriculumID = CU.CurriculumID
            INNER JOIN CurriculumHeader CH ON CU.CurriculumHeaderID = CH.CurriculumHeaderID
            INNER JOIN Program P ON CH.ProgramID = P.ProgramID
            LEFT JOIN ClassSection CS ON O.OfferingID = CS.OfferingID 
                                      AND CS.SchoolYear = @SchoolYear
            WHERE CH.CurriculumYear = @CurriculumYear
              AND P.ProgramCode = @ProgramCode
              AND CU.YearLevel = @YearLevel
              AND CU.Semester = @Semester
            ORDER BY C.CourseCode, CS.Section;";

            using (var con = GetConnection())
            {
                // 1. Fetch data once
                var data = con.Query(sql, new
                {
                    CurriculumYear = cbxCurriculum.Text,
                    ProgramCode = cbxProgram.Text,
                    YearLevel = int.Parse(cbxYearLevel.Text),
                    Semester = int.Parse(cbxSemester.Text),
                    SchoolYear = cbxSchoolYear.Text
                }).ToList();

                // 2. Setup the Grid Structure
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "CourseCode",
                    DataPropertyName = "CourseCode",
                    HeaderText = "Course Code",
                    ReadOnly = true,
                    Width = 90
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Description",
                    DataPropertyName = "CourseDescription",
                    HeaderText = "Description",
                    ReadOnly = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Section",
                    DataPropertyName = "Section",
                    HeaderText = "Section",
                    Width = 60
                });

                // 3. Add the Faculty ComboBox Column BEFORE binding data
                AddFacultyComboBoxColumn();

                // 4. Finally bind the data
                dataGridView1.DataSource = data;

                // 5. Apply "Disable" logic for already assigned faculty
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.DataBoundItem == null) continue;

                    var item = (dynamic)row.DataBoundItem;

                    if (item.FacultyID != null)
                    {
                        DataGridViewCell facultyCell = row.Cells["Faculty"];
                        facultyCell.ReadOnly = true;

                        // Visual feedback to show it's "locked"
                        facultyCell.Style.BackColor = Color.LightGray;
                        facultyCell.Style.ForeColor = Color.DarkSlateGray;
                    }
                }
            }
        }

        private void EditCourses()
        {
            string sql = @"
            SELECT 
                C.CourseCode,
                C.CourseDescription,
                CS.Section,
                CS.FacultyID 
            FROM Offering O
            INNER JOIN Course C ON O.CourseID = C.CourseID
            INNER JOIN Curriculum CU ON O.CurriculumID = CU.CurriculumID
            INNER JOIN CurriculumHeader CH ON CU.CurriculumHeaderID = CH.CurriculumHeaderID
            INNER JOIN Program P ON CH.ProgramID = P.ProgramID
            LEFT JOIN ClassSection CS ON O.OfferingID = CS.OfferingID 
                                      AND CS.SchoolYear = @SchoolYear
            WHERE CH.CurriculumYear = @CurriculumYear
              AND P.ProgramCode = @ProgramCode
              AND CU.YearLevel = @YearLevel
              AND CU.Semester = @Semester
              AND CS.Section = @Section
            ORDER BY C.CourseCode, CS.Section;";

            using (var con = GetConnection())
            {
                // 1. Fetch data once
                var data = con.Query(sql, new
                {
                    CurriculumYear = cbxCurriculum.Text,
                    ProgramCode = cbxProgram.Text,
                    YearLevel = int.Parse(cbxYearLevel.Text),
                    Semester = int.Parse(cbxSemester.Text),
                    SchoolYear = cbxSchoolYear.Text,
                    Section = Convert.ToInt32(cbxSectionFilter.Text)
                }).ToList();

                // 2. Setup the Grid Structure
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "CourseCode",
                    DataPropertyName = "CourseCode",
                    HeaderText = "Course Code",
                    ReadOnly = true,
                    Width = 90
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Description",
                    DataPropertyName = "CourseDescription",
                    HeaderText = "Description",
                    ReadOnly = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Section",
                    DataPropertyName = "Section",
                    HeaderText = "Section",
                    Width = 60
                });

                // 3. Add the Faculty ComboBox Column BEFORE binding data
                AddFacultyComboBoxColumn();

                // 4. Finally bind the data
                dataGridView1.DataSource = data;
            }
        }

        private void AddFacultyComboBoxColumn()
        {
            string sql = "SELECT FacultyID, CONCAT(LastName, ', ', FirstName) AS FacultyName FROM Faculty ORDER BY LastName";

            using (var con = GetConnection())
            {
                var facultyList = con.Query(sql).ToList();

                DataGridViewComboBoxColumn facultyCol = new DataGridViewComboBoxColumn
                {
                    Name = "Faculty",
                    HeaderText = "Faculty",
                    DataSource = facultyList,
                    ValueMember = "FacultyID",
                    DisplayMember = "FacultyName",
                    DataPropertyName = "FacultyID",
                    FlatStyle = FlatStyle.Flat,
                    Width = 180,
                    // This ensures it looks like a label when ReadOnly is true
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                };

                dataGridView1.Columns.Add(facultyCol);
            }
        }

        private void LoadAcademicYears()
        {
            cbxSchoolYear.Items.Clear();
            cbxSchoolYearFilter.Items.Clear();

            int startYear = 1970;
            int currentAYStart = GetCurrentAcademicYearStart();

            for (int year = currentAYStart; year >= startYear; year--)
            {
                string academicYear = $"{year}-{year + 1}";
                cbxSchoolYear.Items.Add(academicYear);
                cbxSchoolYearFilter.Items.Add(academicYear);
            }

            cbxSchoolYear.SelectedItem = $"{currentAYStart}-{currentAYStart + 1}";
            cbxSchoolYearFilter.SelectedItem = $"{currentAYStart}-{currentAYStart + 1}";

        }
        private int GetCurrentAcademicYearStart()
        {
            DateTime now = DateTime.Now;

            return now.Month >= 6
                ? now.Year
                : now.Year - 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (cbxSection.SelectedItem == null || cbxSchoolYear.SelectedItem == null)
            {
                MessageBox.Show("Please select Section and School Year.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var con = GetConnection())
                {
                    con.Open();
                    using (var transaction = con.BeginTransaction())
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.IsNewRow) continue;

                            // Get FacultyID from the ComboBox column
                            var facultyIdValue = row.Cells["Faculty"].Value;
                    
                            // Skip if no faculty is assigned to this specific course
                            if (facultyIdValue == null || facultyIdValue == DBNull.Value) continue;

                           

                            if(!Editable)
                            {
                                var parameters = new
                                {
                                    CurriculumYear = cbxCurriculum.Text,
                                    ProgramCode = cbxProgram.Text,
                                    YearLevel = int.Parse(cbxYearLevel.Text),
                                    Semester = int.Parse(cbxSemester.Text),
                                    CourseCode = row.Cells["CourseCode"].Value.ToString(),
                                    FacultyID = Convert.ToInt32(facultyIdValue),
                                    Section = int.Parse(cbxSection.Text),
                                    SchoolYear = cbxSchoolYear.Text
                                };

                                con.Execute("sp_InsertClassSection", parameters,
                                transaction: transaction,
                                commandType: CommandType.StoredProcedure);
                            }
                            else
                            {
                                var parameters = new
                                {
                                    CurriculumYear = cbxCurriculum.Text,
                                    ProgramCode = cbxProgram.Text,
                                    YearLevel = int.Parse(cbxYearLevel.Text),
                                    Semester = int.Parse(cbxSemester.Text),
                                    CourseCode = row.Cells["CourseCode"].Value.ToString(),

                                    OldSection = Convert.ToInt32(cbxSectionFilter.Text),
                                    OldSchoolYear = cbxSchoolYearFilter.Text,

                                    NewFacultyID = Convert.ToInt32(facultyIdValue),
                                    NewSection = int.Parse(cbxSection.Text),
                                    NewSchoolYear = cbxSchoolYear.Text
                                };

                                con.Execute("sp_UpdateClassSection", parameters,
                                transaction: transaction,
                                commandType: CommandType.StoredProcedure);
                            }
                            
                        }
                
                        transaction.Commit();
                        MessageBox.Show("Faculty assignments saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(Editable)
            {
                btnSave.Text = "Save";
                Editable = false;
            }
            else
            {
                btnSave.Text = "Update";
                Editable = true;
            }
            EditButton();
        }
    }
}
