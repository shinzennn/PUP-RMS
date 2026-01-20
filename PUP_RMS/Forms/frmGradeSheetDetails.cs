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
    public partial class frmGradeSheetDetails : Form
    {
        private readonly string connectionString =
            System.Configuration.ConfigurationManager.ConnectionStrings["RMSDB"].ConnectionString;

        public int GradeSheetID { get; set; } // <-- add this
        private string currentFilePath = "";

        public frmGradeSheetDetails()
        {
            InitializeComponent();

            this.Load += frmGradeSheetDetails_Load;
            btnUpload.Click += btnUpload_Click;
            btnSave.Click += btnSave_Click;
            btnClose.Click += (s, e) => this.Close();
        }

        private void frmGradeSheetDetails_Load(object sender, EventArgs e)
        {
            LoadPrograms();
            LoadCourses();
            LoadProfessors();
            LoadYearLevels();
            LoadSemesters();
            LoadSchoolYears();

            LoadGradeSheetData();
        }
        private void LoadGradeSheetData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM GradeSheet WHERE GradeSheetID=@GradeSheetID", con))
            {
                cmd.Parameters.AddWithValue("@GradeSheetID", GradeSheetID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtFilename.Text = dr["Filename"].ToString();
                    cmbProgram.SelectedValue = dr["ProgramID"];
                    cmbCourse.SelectedValue = dr["CourseID"];
                    cmbProfessor.SelectedValue = dr["FacultyID"];
                    cmbYearLevel.SelectedValue = dr["YearLevel"];
                    cmbSemester.SelectedValue = dr["Semester"];
                    cmbSchoolYear.SelectedValue = dr["SchoolYear"];

                    currentFilePath = dr["Filepath"].ToString() + dr["Filename"].ToString();
                    LoadThumbnail(currentFilePath);
                }
            }

        }

        private void LoadThumbnail(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                pbPreview.Image = null;
                return;
            }
            // Dispose previous image to prevent file lock
            if (pbPreview.Image != null) pbPreview.Image.Dispose();
            pbPreview.Image = Image.FromFile(filePath);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string newFileName = GenerateFileName(); // Re-generate name based on current info
                string targetFolder = "C:/Uploads/2025/"; // Change as needed
                string targetPath = System.IO.Path.Combine(targetFolder, newFileName);

                System.IO.File.Copy(ofd.FileName, targetPath, true);
                currentFilePath = targetPath;
                txtFilename.Text = newFileName;
                LoadThumbnail(currentFilePath);
            }

            btnSave.Visible = true;
            btnCancelImageChange.Visible = true;
        }

        private string GenerateFileName()
        {
            // Example: ProgramCode_CourseCode_Semester_YrLevel.jpg
            string program = ((DataRowView)cmbProgram.SelectedItem)["ProgramCode"].ToString();
            string course = ((DataRowView)cmbCourse.SelectedItem)["CourseCode"].ToString();
            string semester = cmbSemester.SelectedValue.ToString();
            string yearLevel = cmbYearLevel.SelectedValue.ToString();

            return $"{program}_{course}_S{semester}_Y{yearLevel}.jpg";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            enableEdit();
            //txtFilename.ReadOnly = false;   
            //txtPageNumber.ReadOnly = false;
            //cmbSchoolYear.Enabled = true;
            //cmbSemester.Enabled = true;
            //cmbProgram.Enabled = true;
            //cmbYearLevel.Enabled = true;
            //cmbCourse.Enabled = true;
            //cmbProfessor.Enabled = true;
            //cmbAccount.Enabled = true;

            //btnSaveGradeSheetDetails.Visible = true;
            //btnCancelEdit.Visible = true;
            //btnEdit.Enabled = false;
            //btnEdit.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_UpdateGradeSheet", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@GradeSheetID", GradeSheetID);
                cmd.Parameters.AddWithValue("@Filename", txtFilename.Text);
                cmd.Parameters.AddWithValue("@Filepath", "C:/Uploads/2025/");
                cmd.Parameters.AddWithValue("@SchoolYear", cmbSchoolYear.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@Semester", Convert.ToInt32(cmbSemester.SelectedValue));
                cmd.Parameters.AddWithValue("@ProgramID", Convert.ToInt32(cmbProgram.SelectedValue));
                cmd.Parameters.AddWithValue("@YearLevel", Convert.ToInt32(cmbYearLevel.SelectedValue));
                cmd.Parameters.AddWithValue("@CourseID", Convert.ToInt32(cmbCourse.SelectedValue));
                cmd.Parameters.AddWithValue("@FacultyID", Convert.ToInt32(cmbProfessor.SelectedValue));
                cmd.Parameters.AddWithValue("@PageNumber", 1); // For simplicity

                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("GradeSheet updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
        }

        private void btnCancelImageChange_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void LoadPrograms() => LoadComboBox("SELECT ProgramID, ProgramCode FROM Program", cmbProgram, "ProgramCode", "ProgramID");
        private void LoadCourses() => LoadComboBox("SELECT CourseID, CourseCode FROM Course", cmbCourse, "CourseCode", "CourseID");
        private void LoadProfessors() => LoadComboBox("SELECT FacultyID, FirstName + ' ' + LastName AS FullName FROM Faculty", cmbProfessor, "FullName", "FacultyID");
        private void LoadYearLevels()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            for (int i = 1; i <= 5; i++) dt.Rows.Add(i, $"{i} Year");
            cmbYearLevel.DataSource = dt;
            cmbYearLevel.DisplayMember = "Name";
            cmbYearLevel.ValueMember = "ID";
        }
        private void LoadSemesters()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Rows.Add(1, "1st Semester");
            dt.Rows.Add(2, "2nd Semester");
            cmbSemester.DataSource = dt;
            cmbSemester.DisplayMember = "Name";
            cmbSemester.ValueMember = "ID";
        }
        private void LoadSchoolYears() => LoadComboBox("SELECT DISTINCT SchoolYear FROM GradeSheet ORDER BY SchoolYear DESC", cmbSchoolYear, "SchoolYear", "SchoolYear");

        private void LoadComboBox(string query, ComboBox cmb, string display, string value)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                DataTable dt = new DataTable();
                con.Open();
                dt.Load(cmd.ExecuteReader());

                cmb.DataSource = dt;
                cmb.DisplayMember = display;
                cmb.ValueMember = value;
            }
        }

        private void txtPageNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveGradeSheetDetails_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_UpdateGradeSheet", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@GradeSheetID", GradeSheetID);
                cmd.Parameters.AddWithValue("@Filename", txtFilename.Text);
                cmd.Parameters.AddWithValue("@Filepath", "C:/Uploads/2025/");
                cmd.Parameters.AddWithValue("@SchoolYear", cmbSchoolYear.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@Semester", Convert.ToInt32(cmbSemester.SelectedValue));
                cmd.Parameters.AddWithValue("@ProgramID", Convert.ToInt32(cmbProgram.SelectedValue));
                cmd.Parameters.AddWithValue("@YearLevel", Convert.ToInt32(cmbYearLevel.SelectedValue));
                cmd.Parameters.AddWithValue("@CourseID", Convert.ToInt32(cmbCourse.SelectedValue));
                cmd.Parameters.AddWithValue("@FacultyID", Convert.ToInt32(cmbProfessor.SelectedValue));
                cmd.Parameters.AddWithValue("@PageNumber", 1); // For simplicity

                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("GradeSheet updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            disableEdit();
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            LoadGradeSheetData();
            disableEdit();

            //txtFilename.ReadOnly = true;
            //txtPageNumber.ReadOnly = true;

            //cmbSchoolYear.Enabled = false;
            //cmbAccount.Enabled = false;
            //cmbSemester.Enabled = false;
            //cmbProgram.Enabled = false;
            //cmbYearLevel.Enabled = false;
            //cmbCourse.Enabled = false;
            //cmbProfessor.Enabled = false;

            //btnSaveGradeSheetDetails.Visible = false;
            //btnCancelEdit.Visible = false;
            //btnEdit.Enabled = true;
            //btnEdit.Visible = true;
        }

        private void enableEdit()
        {
            txtPageNumber.ReadOnly = false;
            cmbSchoolYear.Enabled = true;
            cmbSemester.Enabled = true;
            cmbProgram.Enabled = true;
            cmbYearLevel.Enabled = true;
            cmbCourse.Enabled = true;
            cmbProfessor.Enabled = true;
            btnSaveGradeSheetDetails.Visible = true;
            btnCancelEdit.Visible = true;
            btnEdit.Enabled = false;
            btnEdit.Visible = false;
        }

        private void disableEdit()
        {
            txtPageNumber.ReadOnly = true;
            cmbSchoolYear.Enabled = false;
            cmbSemester.Enabled = false;
            cmbProgram.Enabled = false;
            cmbYearLevel.Enabled = false;
            cmbCourse.Enabled = false;
            cmbProfessor.Enabled = false;
            btnSaveGradeSheetDetails.Visible = false;
            btnCancelEdit.Visible = false;
            btnEdit.Enabled = true;
            btnEdit.Visible = true;
        }


    }
}
