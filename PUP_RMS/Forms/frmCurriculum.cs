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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace PUP_RMS.Forms
{
    public partial class frmCurriculum : Form
    {

        int curriculumID = 0;
        int selectedRow = 0;
        int selectedCurriculumRow = 0;
        bool AddingCurriculumCourse = true;
        bool view = false;
        public frmCurriculum()
        {
            InitializeComponent();


        }

        private void frmCurriculum_Load(object sender, EventArgs e)
        {
            txtCurriculumYear.Text = "";
            LoadSemester();
            LoadYearLevel();
            LoadCourse();
            LoadFaculty();
            LoadProgram();
            
        }


        private void btnViewCurriculum_Click(object sender, EventArgs e)
        {
            pnlCurriculum.Enabled = true;
            pnlYearLevelAndSem.Enabled = false;
            pnlCurriculumCourse.Enabled = false;

            view = true;
            deleteRow.Enabled = false;

            txtCurriculumYear.DropDownStyle = ComboBoxStyle.DropDown;

            LoadComboBox(txtCurriculumYear, "CurriculumYear", "CurriculumID", "Curriculum", "CurriculumYear");
            loadDgvCurriculumCourse();

            dgvCurriculum.DataSource = null;
            dgvCurriculumCourse.Rows.Clear();
            lblHeader.Text = "";
            lblYearAndSem.Text = "";
            btnSaveCurriculum.Text = "SEARCH";
            btnSaveCurriculumCourse.Visible = false;

        }


        //CURRICULUM
        private void btnCreateCurriculum_Click(object sender, EventArgs e)
        {

            pnlCurriculum.Enabled = true;
            txtCurriculumYear.Text = "";
            
            view = false;
            deleteRow.Enabled = true;

            txtCurriculumYear.DataSource = null;
            txtCurriculumYear.Items.Clear();
            txtCurriculumYear.DropDownStyle = ComboBoxStyle.Simple;
            loadDgvCurriculumCourse();

            dgvCurriculum.DataSource = null;
            dgvCurriculumCourse.Rows.Clear();

            lblHeader.Text = "";
            lblYearAndSem.Text = "";
            btnSaveCurriculum.Text = "SAVE";
            btnSaveCurriculumCourse.Visible = true;
        }

        private void btnSaveCurriculum_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurriculumYear.Text) || cbxProgram.SelectedItem == null)
            {
                MessageBox.Show("Please Fill all the fields");
                return;
            }

            if (!view)
            {
                pnlCurriculum.Enabled = false;
                pnlYearLevelAndSem.Enabled = true;
            }
            

            viewAllCurriculum();

            lblHeader.Text = cbxProgram.Text + " - " + txtCurriculumYear.Text;

        }

        private void btnCancelCurriculum_Click(object sender, EventArgs e)
        {
            txtCurriculumYear.Text = "";
            cbxProgram.SelectedIndex = -1;
        }

        //YEAR LEVEL AND SEMESTER 
        private void btnAddYearLevelAndSem_Click(object sender, EventArgs e)
        {
            btnAddCurriculumCourse.Text = "ADD";
            btnSaveCurriculumCourse.Visible = true;
            if (cbxSemester.SelectedItem == null || cbxYearLevel.SelectedItem == null)
            {
                MessageBox.Show("Please Fill all the fields");
                return;
            }

            if (curriculumExist())
            {
                MessageBox.Show("This Curriculum Data Already Exist");
                return;
            }

            pnlYearLevelAndSem.Enabled = false;
            pnlCurriculumCourse.Enabled = true;

            insertCurriculum();
            viewAllCurriculum();

            loadDgvCurriculumCourse();

        }

        private void btnCancelYearLevelAndSem_Click(object sender, EventArgs e)
        {
            cbxYearLevel.SelectedIndex = -1;
            cbxSemester.SelectedIndex = -1;
        }


        //CURRICULUM COURSE
        private void btnAddCurriculumCourse_Click(object sender, EventArgs e)
        {
            if (cbxCourse.SelectedItem == null || cbxFaculty.SelectedItem == null)
            {
                MessageBox.Show("Please Fill all the fields");
                return;
            }

            if (dgvCurriculum.Rows[selectedCurriculumRow].Cells["CurriculumID"].Value != DBNull.Value && !AddingCurriculumCourse)
            {
                insertEditedCurriculum();
                selectCurriculumCourse();
            }
            else
            {
                dgvCurriculumCourse.Rows.Add(cbxCourse.SelectedValue, cbxFaculty.SelectedValue, cbxCourse.Text, cbxFaculty.Text);
            }

                



        }

        private void btnCancelCurriculumCourse_Click(object sender, EventArgs e)
        {
            cbxCourse.SelectedIndex = -1;
            cbxFaculty.SelectedIndex = -1;
        }

        private void btnSaveCurriculumCourse_Click(object sender, EventArgs e)
        {
            selectCurriculumID();

            if (dgvCurriculumCourse.Rows.Count <= 0)
            {
                MessageBox.Show("Please Add Data");
                return;
            }

            insertCurriculumCourse();

            dgvCurriculumCourse.DataSource = null;
            dgvCurriculumCourse.Rows.Clear();

            pnlYearLevelAndSem.Enabled = true;
            pnlCurriculumCourse.Enabled = false;

        }




        //COMBO BOX DATA ADDING
        private void btnAddFaculty_Click(object sender, EventArgs e)
        {
            newFaculty facultyForm = new newFaculty();
            facultyForm.ShowDialog();

            if (facultyForm.DialogResult == DialogResult.OK)
            {
                LoadFaculty();
            }

        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            frmNewCourse openCouse = new frmNewCourse();
            openCouse.ShowDialog();

            if (openCouse.DialogResult == DialogResult.OK)
            {
                LoadCourse();
            }
        }

        private void btnAddProgram_Click(object sender, EventArgs e)
        {
            frmnewProgram newPrograms = new frmnewProgram();
            newPrograms.ShowDialog();
            if (newPrograms.DialogResult == DialogResult.OK)
            {
                LoadProgram();
            }
        }

        //DATAGRIDVIEW

        private void dgvCurriculum_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCurriculumCourse.DataSource = null;
            dgvCurriculumCourse.Rows.Clear();
            dgvCurriculumCourse.Columns.Clear();

            //dgvCurriculumCourse.Columns["Course"].Visible = false;
            //dgvCurriculumCourse.Columns["Faculty"].Visible = false;
            dgvCurriculum.Rows[e.RowIndex].Selected = true;
            selectedCurriculumRow = e.RowIndex;

            if (dgvCurriculum.Rows[selectedCurriculumRow].Cells["CurriculumID"].Value != DBNull.Value)
            {
                selectCurriculumCourse();

                if (!view)
                {
                    pnlYearLevelAndSem.Enabled = true;
                    pnlCurriculumCourse.Enabled = true;
                    btnAddCurriculumCourse.Text = "EDIT";
                    btnSaveCurriculumCourse.Visible = false;
                }

                
            }
            else 
            {
                MessageBox.Show("Select Curriculum Details");
            }

            AddingCurriculumCourse = false;

            string currentSemester = "";
            if (Convert.ToInt32(dgvCurriculum.Rows[selectedCurriculumRow].Cells["Semester"].Value) == 1)
            {currentSemester = "1st Semester"; }
            else if (Convert.ToInt32(dgvCurriculum.Rows[selectedCurriculumRow].Cells["Semester"].Value) == 2)
            {currentSemester = "2nd Semester";}
            else if (Convert.ToInt32(dgvCurriculum.Rows[selectedCurriculumRow].Cells["Semester"].Value) == 3)
            {currentSemester = "Summer Semester";}

            string currentYearLevel = "";
            if (Convert.ToInt32(dgvCurriculum.Rows[selectedCurriculumRow].Cells["YearLevel"].Value) == 1)
            {currentYearLevel = "1st Year";}
            else if (Convert.ToInt32(dgvCurriculum.Rows[selectedCurriculumRow].Cells["YearLevel"].Value) == 2)
            {currentYearLevel = "2nd Year";}
            else if (Convert.ToInt32(dgvCurriculum.Rows[selectedCurriculumRow].Cells["YearLevel"].Value) == 3)
            { currentYearLevel = "3rd Year";}
            else if (Convert.ToInt32(dgvCurriculum.Rows[selectedCurriculumRow].Cells["YearLevel"].Value) == 4)
            { currentYearLevel = "4th Year"; }

            lblYearAndSem.Text = currentYearLevel + " | " + currentSemester;


        }

        private void dgvCurriculum_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            

            


        }

        private void deleteRow_Click(object sender, EventArgs e)
        {
            
            if (dgvCurriculumCourse.Columns["CurriculumID"] != null)
            {
                if (dgvCurriculumCourse.Rows.Count > 1)
                {
                    deleteCurriculumCourse();
                }
            }
            
            if (dgvCurriculumCourse.Rows.Count > 1)    
            {
                dgvCurriculumCourse.Rows.Remove(dgvCurriculumCourse.Rows[selectedRow]);
            }
            

        }

        private void dgvCurriculumCourse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCurriculum.ClearSelection();
            
            if (e.RowIndex > -1)
            {
                dgvCurriculumCourse.Rows[e.RowIndex].Selected = true;
                selectedRow = e.RowIndex;
            }
        }



        //LOADING COMBO BOXES
        private void LoadSemester()
        {
            cbxSemester.DataSource = new List<ComboItem> {
                new ComboItem { Text = "1st Semester", Value = 1, Code = "A" },
                new ComboItem { Text = "2nd Semester", Value = 2, Code = "B" },
                new ComboItem { Text = "Summer", Value = 3, Code = "C" }
            };
            cbxSemester.DisplayMember = "Text";
            cbxSemester.ValueMember = "Value";
            cbxSemester.SelectedIndex = -1;
        }

        private void LoadYearLevel()
        {
            cbxYearLevel.DataSource = new List<ComboItem> {
                new ComboItem { Text = "1st Year", Value = 1 },
                new ComboItem { Text = "2nd Year", Value = 2 },
                new ComboItem { Text = "3rd Year", Value = 3 },
                new ComboItem { Text = "4th Year", Value = 4 }
            };
            cbxYearLevel.DisplayMember = "Text";
            cbxYearLevel.ValueMember = "Value";
            cbxYearLevel.SelectedIndex = -1;
        }

        private void LoadProgram()
        {
            cbxProgram.DataSource = DbControl.GetPrograms();
            cbxProgram.DisplayMember = "ProgramCode";
            cbxProgram.ValueMember = "ProgramID";
            cbxProgram.SelectedIndex = -1;
        }

        private void LoadCourse()
        {
            LoadComboBox(cbxCourse, "CourseCode", "CourseID", "Course");
        }

        private void LoadFaculty()
        {
            cbxFaculty.DataSource = DbControl.GetProfessors();
            cbxFaculty.DisplayMember = "DisplayName";
            cbxFaculty.ValueMember = "FacultyID";
            cbxFaculty.SelectedIndex = -1;
        }

        

        //LOADING CURRICULUM COURSE DATAGRIDVIEW
        private void loadDgvCurriculumCourse()
        {
            dgvCurriculumCourse.DataSource = null;
            dgvCurriculumCourse.Rows.Clear();
            dgvCurriculumCourse.Columns.Clear();

            if (!dgvCurriculumCourse.Columns.Contains("CourseID"))
            {
                dgvCurriculumCourse.Columns.Add("CourseID", "Courses");
                dgvCurriculumCourse.Columns["CourseID"].Visible = false;
            }
            if (!dgvCurriculumCourse.Columns.Contains("FacultyID"))
            {
                dgvCurriculumCourse.Columns.Add("FacultyID", "Faculty");
                dgvCurriculumCourse.Columns["FacultyID"].Visible = false;
            }
            if (!dgvCurriculumCourse.Columns.Contains("Course"))
            {
                dgvCurriculumCourse.Columns.Add("Course", "Courses"); ;
            }
            if (!dgvCurriculumCourse.Columns.Contains("Faculty"))
            {
                dgvCurriculumCourse.Columns.Add("Faculty", "Faculty");
            }
            AddingCurriculumCourse = true;
        }

        //DATABASE

        void insertCurriculum()
        {

            using (SqlConnection conn = new SqlConnection(DbControl.ConnString("RMSDB")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertCurriculum", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CurriculumYear", txtCurriculumYear.Text);
                    cmd.Parameters.AddWithValue("@ProgramID", Convert.ToInt32(cbxProgram.SelectedValue));
                    cmd.Parameters.AddWithValue("@YearLevel", Convert.ToInt32(cbxYearLevel.SelectedValue));
                    cmd.Parameters.AddWithValue("@Semester", Convert.ToInt32(cbxSemester.SelectedValue));
                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0) {
                            MessageBox.Show("Successfully Added");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to Add data | Error:" + ex.Message);
                    }

                }
            }
        }

        bool curriculumExist()
        {
            int curriculumCount = 0;
            using (SqlConnection conn = new SqlConnection(DbControl.ConnString("RMSDB")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CountCurriculum", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CurriculumYear", txtCurriculumYear.Text);
                    cmd.Parameters.AddWithValue("@ProgramID", Convert.ToInt32(cbxProgram.SelectedValue));
                    cmd.Parameters.AddWithValue("@YearLevel", Convert.ToInt32(cbxYearLevel.SelectedValue));
                    cmd.Parameters.AddWithValue("@Semester", Convert.ToInt32(cbxSemester.SelectedValue));
                    try
                    {
                        conn.Open();
                        curriculumCount = Convert.ToInt32(cmd.ExecuteScalar());
                        MessageBox.Show(curriculumCount.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to count curriculum | Error:" + ex.Message);
                    }
                }

            }
            
            if (curriculumCount >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void selectCurriculumID()
        {
            
            using (SqlConnection conn = new SqlConnection(DbControl.ConnString("RMSDB")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_SelectCurriculumID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CurriculumYear", txtCurriculumYear.Text);
                    cmd.Parameters.AddWithValue("@ProgramID", Convert.ToInt32(cbxProgram.SelectedValue));
                    cmd.Parameters.AddWithValue("@YearLevel", Convert.ToInt32(cbxYearLevel.SelectedValue));
                    cmd.Parameters.AddWithValue("@Semester", Convert.ToInt32(cbxSemester.SelectedValue));
                    try
                    {
                        conn.Open();
                        curriculumID = Convert.ToInt32(cmd.ExecuteScalar());
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to Find the Curriculum ID | Error:" + ex.Message);
                    }
                }

            }
        }

        void viewAllCurriculum()
        {
            dgvCurriculum.DataSource = null;
            dgvCurriculum.Rows.Clear();

            using (SqlConnection conn = new SqlConnection(DbControl.ConnString("RMSDB")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ViewAllCurriculum", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CurriculumYear", txtCurriculumYear.Text);
                    cmd.Parameters.AddWithValue("@ProgramID", Convert.ToInt32(cbxProgram.SelectedValue));
                   
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
                        MessageBox.Show("Failed to Find the Curriculum ID | Error:" + ex.Message);
                    }

                    dgvCurriculum.Columns["CurriculumID"].Visible = false;
                    dgvCurriculum.Columns["CurriculumYear"].Visible = false;
                    dgvCurriculum.Columns["ProgramCode"].Visible = false;
                }

            }
        }

        public void LoadComboBox(ComboBox comboBox, string display, string value, string table)
        {
            string query = $"SELECT {display}, {value} FROM {table}";


            using (SqlConnection conn = new SqlConnection(DbControl.ConnString("RMSDB")))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    
                    try
                    {
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        comboBox.DataSource = dt;
                        comboBox.DisplayMember = display;
                        comboBox.ValueMember = value;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to Find the Curriculum ID | Error:" + ex.Message);
                    }
                }

            }

        }

        public void LoadComboBox(ComboBox comboBox, string display, string value, string table, string groupBy)
        {
            string query = $"SELECT {display} FROM {table} GROUP BY {groupBy}";


            using (SqlConnection conn = new SqlConnection(DbControl.ConnString("RMSDB")))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    try
                    {
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        comboBox.DataSource = dt;
                        comboBox.DisplayMember = display;
                        comboBox.ValueMember = display;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to Find the Curriculum ID | Error:" + ex.Message);
                    }
                }

            }

        }


        void insertCurriculumCourse()
        {

            

            using (SqlConnection conn = new SqlConnection(DbControl.ConnString("RMSDB")))
            {
                conn.Open();

                foreach (DataGridViewRow row in dgvCurriculumCourse.Rows)
                {
                    if (row.IsNewRow) continue;


                    int courseID = Convert.ToInt32(row.Cells["CourseID"].Value);
                    int FacultyID = Convert.ToInt32(row.Cells["FacultyID"].Value);

                    using (SqlCommand cmd = new SqlCommand("sp_InsertCurriculumCourse", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CurriculumID", curriculumID);
                        
                        cmd.Parameters.AddWithValue("@CourseID", courseID);
                        cmd.Parameters.AddWithValue("@FacultyID", FacultyID);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

        }

        
        void selectCurriculumCourse()
        {
            using (SqlConnection conn = new SqlConnection(DbControl.ConnString("RMSDB")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_SelectCurriculumCourse", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CurriculumID", Convert.ToInt32(dgvCurriculum.Rows[selectedCurriculumRow].Cells["CurriculumID"].Value));

                    try
                    {
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvCurriculumCourse.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to Find the Curriculum ID | Error:" + ex.Message);
                    }

                    dgvCurriculumCourse.Columns["CurriculumID"].Visible = false;
                    dgvCurriculumCourse.Columns["CourseID"].Visible = false;
                    dgvCurriculumCourse.Columns["FacultyID"].Visible = false;
                }

            }
        }

        void deleteCurriculumCourse()
        {
            using (SqlConnection conn = new SqlConnection(DbControl.ConnString("RMSDB")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeleteCurriculumCourse", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CurriculumID", Convert.ToInt32(dgvCurriculumCourse.Rows[selectedRow].Cells["CurriculumID"].Value));
                    cmd.Parameters.AddWithValue("@CourseID", Convert.ToInt32(dgvCurriculumCourse.Rows[selectedRow].Cells["CourseID"].Value));
                    cmd.Parameters.AddWithValue("@FacultyID", Convert.ToInt32(dgvCurriculumCourse.Rows[selectedRow].Cells["FacultyID"].Value));
                   
                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Successfully Deleted");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to Delete data | Error:" + ex.Message);
                    }

                }
            }
        }


        void insertEditedCurriculum()
        {
            using (SqlConnection conn = new SqlConnection(DbControl.ConnString("RMSDB")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertCurriculumCourse", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CurriculumID", Convert.ToInt32(dgvCurriculum.Rows[selectedCurriculumRow].Cells["CurriculumID"].Value));
                    cmd.Parameters.AddWithValue("@CourseID", Convert.ToInt32(cbxCourse.SelectedValue));
                    cmd.Parameters.AddWithValue("@FacultyID", Convert.ToInt32(cbxFaculty.SelectedValue));
                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Successfully Added");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to Add data | Error:" + ex.Message);
                    }

                }
            }
        }

        
    }

}
