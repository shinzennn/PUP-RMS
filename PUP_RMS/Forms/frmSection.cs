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
using PUP_RMS.Forms;

namespace PUP_RMS
{
    public partial class frmSection : Form
    {
        public frmSection()
        {
            // Anti-flicker settings
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            InitializeComponent();

            this.dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;


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
            this.SuspendLayout();
            LoadData();
            this.ResumeLayout();
        }

        public void LoadData()
        {
            pnlWorksheet.HeaderLabel = "";
            dataGridView1.Visible = false;
            btnSaveUpdate.Visible = false;
            btnAddFaculty.Visible = false;

            cbxCurriculum.SelectedItem = null;
            cbxProgram.SelectedItem = null;
            cbxYearLevel.SelectedItem = null;
            cbxSemester.SelectedItem = null;
            cbxSchoolYear.SelectedItem = null;
            cbxSection.SelectedItem = null;
        }
        private void cbxCurriculum_Click(object sender, EventArgs e)
        {
            LoadCurriculumYear();
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


        private void cbxSchoolYear_Click(object sender, EventArgs e)
        {
            LoadAcademicYears();
        }

        private void LoadAcademicYears()
        {
            cbxSchoolYear.Items.Clear();

            int startYear = 1970;
            int currentAYStart = GetCurrentAcademicYearStart();

            for (int year = currentAYStart; year >= startYear; year--)
            {
                string academicYear = $"{year}-{year + 1}";
                cbxSchoolYear.Items.Add(academicYear);
            }

            cbxSchoolYear.SelectedItem = $"{currentAYStart}-{currentAYStart + 1}";
        }
      
        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e){}
        private void what(object sender, EventArgs e){}

        private int GetCurrentAcademicYearStart()
        {
            DateTime now = DateTime.Now;

            return now.Month >= 6
                ? now.Year
                : now.Year - 1;
        }

        //private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e){}
        //private void what(object sender, EventArgs e){}

        // BUTTON CLICK EVENTS
        private void btnView_Click(object sender, EventArgs e)
        {
            if (cbxCurriculum.SelectedItem == null ||
                cbxProgram.SelectedItem == null ||
                cbxYearLevel.SelectedItem == null ||
                cbxSemester.SelectedItem == null ||
                cbxSchoolYear.SelectedItem == null ||
                cbxSection.SelectedItem == null)
            {
                MessageBox.Show("Please select all required fields before loading the worksheet.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmViewSection frm = new frmViewSection(
                cbxCurriculum.Text,
                cbxProgram.Text,
                cbxSchoolYear.Text,
                int.Parse(cbxSection.Text)
            );

            frm.ShowDialog();
        }

        private void btnLoadCourse_Click(object sender, EventArgs e)
        {
            if(cbxCurriculum.SelectedItem == null ||
                cbxProgram.SelectedItem == null ||
                cbxYearLevel.SelectedItem == null ||
                cbxSemester.SelectedItem == null ||
                cbxSchoolYear.SelectedItem == null ||
                cbxSection.SelectedItem == null)
            {
                MessageBox.Show("Please select all required fields before loading the worksheet.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            pnlWorksheet.HeaderLabel = "CY: " + cbxCurriculum.Text + " -> Program: " + cbxProgram.Text + " -> YL: " + cbxYearLevel.Text + " -> Sem: " + cbxSemester.Text + " -> SY: " + cbxSchoolYear.Text + " -> Section: " + cbxSection.Text;
            LoadWorksheet();
            dataGridView1.Visible = true;
            btnSaveUpdate.Visible = true;
            btnAddFaculty.Visible = true;
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            SaveAndUpdateWorksheet();
        }

        private void LoadWorksheet()
        {
            string sql = @"
            SELECT 
                o.OfferingID,
                c.CourseCode,
                c.CourseDescription,
                cs.SectionID,        -- If NULL, it hasn't been saved yet
                f.FacultyID,         -- Current assigned faculty
                CONCAT(f.LastName, ', ', f.FirstName) AS FacultyName,
                -- Check if a GradeSheet exists to lock the row in the UI
                CASE WHEN gs.GradeSheetID IS NOT NULL THEN 1 ELSE 0 END AS IsLocked
            FROM Offering o
            INNER JOIN Course c ON o.CourseID = c.CourseID
            INNER JOIN Curriculum cur ON o.CurriculumID = cur.CurriculumID
            INNER JOIN CurriculumHeader ch ON cur.CurriculumHeaderID = ch.CurriculumHeaderID
            INNER JOIN Program p ON ch.ProgramID = p.ProgramID
            -- LEFT JOIN is critical: show the course even if no section is created yet
            LEFT JOIN ClassSection cs ON o.OfferingID = cs.OfferingID 
                AND cs.Section = @Section 
                AND cs.SchoolYear = @SchoolYear
            LEFT JOIN Faculty f ON cs.FacultyID = f.FacultyID
            LEFT JOIN GradeSheet gs ON cs.SectionID = gs.SectionID
            WHERE p.ProgramCode = @ProgramCode
              AND ch.CurriculumYear = @CurriculumYear
              AND cur.YearLevel = @YearLevel
              AND cur.Semester = @Semester
            ORDER BY c.CourseCode;";

            using (var con = GetConnection())
            {
                var data = con.Query(sql, new
                {
                    CurriculumYear = cbxCurriculum.Text,
                    ProgramCode = cbxProgram.Text,
                    YearLevel = int.Parse(cbxYearLevel.Text),
                    Semester = int.Parse(cbxSemester.Text),
                    Section = int.Parse(cbxSection.Text),
                    SchoolYear = cbxSchoolYear.Text
                }).ToList();

                // 2. Setup the Grid Structure
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "OfferingID",
                    DataPropertyName = "OfferingID",
                    HeaderText = "Offering ID",
                    ReadOnly = true,
                    Width = 90
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "CourseCode",
                    DataPropertyName = "CourseCode",
                    HeaderText = "Course Code",
                    ReadOnly = true,
                    Width = 130
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Description",
                    DataPropertyName = "CourseDescription",
                    HeaderText = "Description",
                    ReadOnly = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

                // 3. Add the Faculty ComboBox Column BEFORE binding data
                AddFacultyComboBoxColumn();
                deleteFacultyButton();

                // 4. Finally bind the data
                dataGridView1.DataSource = data;

                dataGridView1.Columns["OfferingID"].Visible = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Maroon;
            }


        }

        private void SaveAndUpdateWorksheet()
        {

            try
            {
                using (var con = GetConnection())
                {
                    con.Open();
                    using (var transaction = con.BeginTransaction())
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            string procedureName = "sp_SyncClassSectionAssignment";

                            int offeringId = (int)row.Cells["OfferingID"].Value;


                            var cellValue = row.Cells["Faculty"].Value;
                            int? facultyId = (cellValue == null || cellValue == DBNull.Value)
                                             ? (int?)null
                                             : Convert.ToInt32(cellValue);


                            int section = int.Parse(cbxSection.Text);
                            string schoolYear = cbxSchoolYear.Text;

                            var parameters = new
                            {
                                OfferingID = offeringId,
                                FacultyID = facultyId,
                                Section = section,
                                SchoolYear = schoolYear
                            };

                            con.Execute(procedureName, parameters,
                            transaction: transaction,
                            commandType: CommandType.StoredProcedure);
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

        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["Faculty"].Index)
            {
                if (e.Control is ComboBox combo)
                {
                    // Set the style to DropDown so the user can actually type new text
                    combo.DropDownStyle = ComboBoxStyle.DropDown;

                    // Set the search/suggest behavior
                    combo.AutoCompleteMode = AutoCompleteMode.Suggest;
                    combo.AutoCompleteSource = AutoCompleteSource.ListItems;


                }
            }
            else
            {
                // Important: Reset it for other columns so they don't inherit the behavior
                if (e.Control is ComboBox combo)
                {
                    combo.AutoCompleteMode = AutoCompleteMode.None;
                }
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void deleteFacultyButton() {
            DataGridViewButtonColumn clearBtnCol = new DataGridViewButtonColumn
            {
                Name = "ClearAction",
                HeaderText = "",
                Text = "Clear",
                UseColumnTextForButtonValue = true, // Shows "Clear" on every button
                Width = 80,
                FlatStyle = FlatStyle.Flat
            };
            // Optional: Make the button look distinct
            clearBtnCol.DefaultCellStyle.ForeColor = Color.Red;

            dataGridView1.Columns.Add(clearBtnCol);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Check if the clicked cell is in our Button Column
            if (dataGridView1.Columns[e.ColumnIndex].Name == "ClearAction" && e.RowIndex >= 0)
            {
                if(MessageBox.Show("Are you sure you want to clear the faculty assignment for this course?", "Confirm Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {return;}

                // 2. Set the Faculty cell in this specific row to DBNull
                dataGridView1.Rows[e.RowIndex].Cells["Faculty"].Value = DBNull.Value;

                // 3. (Optional) Force the grid to end edit mode so the change is "seen"
                dataGridView1.EndEdit();
            }
        }

        private void btnAddFaculty_Click(object sender, EventArgs e)
        {
            newFaculty frm = new newFaculty();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                RefreshFacultyComboBoxColumn();
            }
        }

        private void AddFacultyComboBoxColumn()
        {
            string sql = "SELECT FacultyID, CONCAT(LastName, ', ', FirstName) AS FacultyName FROM Faculty ORDER BY LastName";

            using (var con = GetConnection())
            {
                var facultyList = con.Query<Faculty>(sql).ToList();

                DataGridViewComboBoxColumn facultyCol = new DataGridViewComboBoxColumn
                {
                    Name = "Faculty",
                    HeaderText = "Faculty",
                    DataSource = facultyList,
                    ValueMember = "FacultyID",
                    DisplayMember = "FacultyName",
                    DataPropertyName = "FacultyID",
                    FlatStyle = FlatStyle.Flat,
                    Width = 220,

                    // This ensures it looks like a label when ReadOnly is true
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                };

                dataGridView1.Columns.Add(facultyCol);
            }
        }

        private void RefreshFacultyComboBoxColumn()
        {
            var facultyCol = dataGridView1.Columns["Faculty"] as DataGridViewComboBoxColumn;
            if (facultyCol != null)
            {
                string sql = "SELECT FacultyID, CONCAT(LastName, ', ', FirstName) AS FacultyName FROM Faculty ORDER BY LastName";
                using (var con = GetConnection())
                {
                    try
                    {
                        var facultyList = con.Query<Faculty>(sql).ToList();
                        facultyCol.DataSource = facultyList;

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Query Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        
    }
}
