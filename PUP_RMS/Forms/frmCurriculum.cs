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
        // Add this with your other fields
        private Timer tmrFadeIn;


        int curriculumHeaderID = 0;
        int curriculumID = 0;
        int selectedRow = 0;
        int selectedCurriculumRow = 0;
        bool AddingCurriculumCourse = true;
        bool editing = false;


        bool isLoading = false;


        public frmCurriculum()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            InitializeComponent();

            ApplyDoubleBufferingRecursively(this.Controls);

            // Start hidden
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
        private void InitializeFadeTimer()
        {
            tmrFadeIn = new Timer();
            tmrFadeIn.Interval = 10;
            tmrFadeIn.Tick += TmrFadeIn_Tick;
        }

        private void TmrFadeIn_Tick(object sender, EventArgs e)
        {
            if (this.IsDisposed)
            {
                tmrFadeIn.Stop();
                return;
            }

            if (this.Opacity < 1.0)
            {
                this.Opacity += 0.01; // Adjust this for faster/slower fade (0.05 = smooth, 0.1 = faster)
            }
            else
            {
                tmrFadeIn.Stop();
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (tmrFadeIn != null)
                tmrFadeIn.Stop();

            base.OnFormClosing(e);
        }
        private void HideAllPanelsTemporarily()
        {
            // Find and hide all your main panels during initialization
            pnlCurriculum.Visible = false;
            pnlYearLevelAndSem.Visible = false;
            pnlCurriculumCourse.Visible = false;

            // Hide any other panels or controls that are causing visible build-up
            dgvCurriculum.Visible = false;
            dgvCurriculumCourse.Visible = false;
        }

        //=====================================================
        // Code Logic Starts Here
        //=====================================================
        private void frmCurriculum_Load(object sender, EventArgs e)
        {
            txtCurriculumYear.Text = "";
            LoadSemester();
            LoadYearLevel();
            LoadCourse();
            LoadProgram();
            LoadSearchProgram();
        }


        


        //CURRICULUM
        private void btnCreateCurriculum_Click(object sender, EventArgs e)
        {
            pnlYearLevelAndSem.Enabled = false;
            pnlCurriculumCourse.Enabled = false;

            lblSeachCurriculumYear.Visible = false;
            cbxSeachCurriculumYear.Visible = false;
            lblSearchCurriculumProgram.Visible = false;
            cbxSearchCurriculumProgram.Visible = false;
            btnSearchView.Visible = false;
            btnSearchEdit.Visible = false;
            editing = false;


            pnlCurriculum.Enabled = true;
            txtCurriculumYear.Text = "";

            loadDgvCurriculumCourse();

            dgvCurriculum.DataSource = null;
            dgvCurriculumCourse.Rows.Clear();

            btnSaveCurriculum.Text = "SAVE";
            btnSaveCurriculumCourse.Visible = false;
        }

        private void btnSaveCurriculum_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurriculumYear.Text) || cbxProgram.SelectedItem == null)
            {
                MessageBox.Show("Please Fill all the fields");
                return;
            }
            else
            {
                if (!curriculumHeaderExist())
                {
                    insertCurriculumHeader();
                    pnlCurriculum.Enabled = false;
                    pnlYearLevelAndSem.Enabled = true;

                    selectCurriculumHeaderID();
                    viewAllCurriculum();

                    pnlCurriculumHeader.HeaderLabel = cbxProgram.Text + " - " + txtCurriculumYear.Text;
                }
                else
                {
                    MessageBox.Show("Curriculum Already Exists");
                }
            }

        }

        private void btnCancelCurriculum_Click(object sender, EventArgs e)
        {
            txtCurriculumYear.Text = "";
            cbxProgram.SelectedIndex = -1;
        }

        //YEAR LEVEL AND SEMESTER 
        private void btnAddYearLevelAndSem_Click(object sender, EventArgs e)
        {
            
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
            else
            {
                btnAddCurriculumCourse.Text = "ADD";
                btnSaveCurriculumCourse.Visible = true;
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
            if (cbxCourse.SelectedItem == null)
            {
                MessageBox.Show("Please Fill all the fields");
                return;
            }

            if (dgvCurriculum.Rows[selectedCurriculumRow].Cells["CurriculumID"].Value != DBNull.Value && !AddingCurriculumCourse)
            {
                insertEditedCurriculum();
                selectCurriculumCourse();
                cbxCourse.SelectedIndex = -1;
                
            }
            else
            {
                dgvCurriculumCourse.Rows.Add(cbxCourse.SelectedValue, cbxCourse.Text);
                cbxCourse.SelectedIndex = -1;
                
            }

                



        }

        private void btnCancelCurriculumCourse_Click(object sender, EventArgs e)
        {
            cbxCourse.SelectedIndex = -1;
            
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

            cbxYearLevel.SelectedIndex = -1;
            cbxSemester.SelectedIndex = -1;

        }




        //COMBO BOX DATA ADDING

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            frmNewCourse openCouse = new frmNewCourse();
            openCouse.ShowDialog();

            if (openCouse.DialogResult == DialogResult.OK)
            {
                LoadCourse();
                cbxCourse.SelectedIndex = cbxCourse.Items.Count - 1;
                
            }
        }

        private void btnAddProgram_Click(object sender, EventArgs e)
        {
            frmnewProgram newPrograms = new frmnewProgram();
            newPrograms.ShowDialog();
            if (newPrograms.DialogResult == DialogResult.OK)
            {
                LoadProgram();
                cbxProgram.SelectedIndex = cbxProgram.Items.Count - 1;  
            }
        }

        //DATAGRIDVIEW

        private void dgvCurriculum_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCurriculumCourse.DataSource = null;
            dgvCurriculumCourse.Rows.Clear();
            dgvCurriculumCourse.Columns.Clear();

            if (e.RowIndex <= -1)
            {
                return;
            }
            dgvCurriculum.Rows[e.RowIndex].Selected = true;
            selectedCurriculumRow = e.RowIndex;

            if (dgvCurriculum.Rows[selectedCurriculumRow].Cells["CurriculumID"].Value != DBNull.Value)
            {
                selectCurriculumCourse();


                    pnlYearLevelAndSem.Enabled = true;
                    pnlCurriculumCourse.Enabled = true;


                
            }
            else 
            {
                MessageBox.Show("Select Curriculum Details");
                return;
            }

            AddingCurriculumCourse = false;
            btnAddCurriculumCourse.Text = "EDIT";

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

            pnlOffering.HeaderLabel = "Year Level: " + currentYearLevel + " | " + "Semester: " + currentSemester;


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
            else
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
        private void LoadSearchProgram()
        {
            cbxSearchCurriculumProgram.DataSource = DbControl.GetPrograms();
            cbxSearchCurriculumProgram.DisplayMember = "ProgramCode";
            cbxSearchCurriculumProgram.ValueMember = "ProgramID";
            cbxSearchCurriculumProgram.SelectedIndex = -1;
        }
        private void LoadCourse()
        {
            LoadComboBox(cbxCourse, "CourseCode", "CourseID", "Course");
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
            if (!dgvCurriculumCourse.Columns.Contains("Course"))
            {
                dgvCurriculumCourse.Columns.Add("Course", "Courses"); ;
            }

            AddingCurriculumCourse = true;
        }

        //DATABASE

        void insertCurriculumHeader()
        {
            using (SqlConnection conn = new SqlConnection(DbControl.ConnString("RMSDB")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertCurriculumHeader", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProgramID", Convert.ToInt32(cbxProgram.SelectedValue));
                    cmd.Parameters.AddWithValue("@CurriculumYear", txtCurriculumYear.Text);
                    
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

        void selectCurriculumHeaderID()
        {
            using (SqlConnection conn = new SqlConnection(DbControl.ConnString("RMSDB")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_SelectCurriculumHeaderID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProgramID", Convert.ToInt32(cbxProgram.SelectedValue));
                    cmd.Parameters.AddWithValue("@CurriculumYear", txtCurriculumYear.Text);
                    
                    try
                    {
                        conn.Open();
                        curriculumHeaderID = Convert.ToInt32(cmd.ExecuteScalar());

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to Find the Curriculum ID | Error:" + ex.Message);
                    }
                }

            }
        }


        void insertCurriculum()
        {

            using (SqlConnection conn = new SqlConnection(DbControl.ConnString("RMSDB")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertCurriculum", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CurriculumHeaderID", curriculumHeaderID);
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

                    cmd.Parameters.AddWithValue("@CurriculumHeaderID", curriculumHeaderID);
                    cmd.Parameters.AddWithValue("@YearLevel", Convert.ToInt32(cbxYearLevel.SelectedValue));
                    cmd.Parameters.AddWithValue("@Semester", Convert.ToInt32(cbxSemester.SelectedValue));
                    try
                    {
                        conn.Open();
                        curriculumCount = Convert.ToInt32(cmd.ExecuteScalar());
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

        bool curriculumHeaderExist()
        {
            int curriculumCount = 0;
            using (SqlConnection conn = new SqlConnection(DbControl.ConnString("RMSDB")))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CountCurriculumHeader", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProgramID", Convert.ToInt32(cbxProgram.SelectedValue));
                    cmd.Parameters.AddWithValue("@CurriculumYear", txtCurriculumYear.Text);
                    try
                    {
                        conn.Open();
                        curriculumCount = Convert.ToInt32(cmd.ExecuteScalar());
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

                    cmd.Parameters.AddWithValue("@CurriculumHeaderID", curriculumHeaderID);
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

                    cmd.Parameters.AddWithValue("@CurriculumHeaderID", curriculumHeaderID);
                   
                    try
                    {
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvCurriculum.DataSource = dt;

                        dgvCurriculum.Columns["CurriculumID"].Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to Find the Curriculum ID | Error:" + ex.Message);
                    }

                }

            }
        }

        public void LoadComboBox(ComboBox comboBox, string display, string table)
        {
            

            string query = $"SELECT {display} FROM {table}";


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
                        
                        isLoading = true;

                        
                        comboBox.DisplayMember = display;
                        comboBox.ValueMember = display;

                        comboBox.DataSource = dt;
                        isLoading = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to Find the Curriculum ID | Error:" + ex.Message);
                    }
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

                        isLoading = true;
                        comboBox.DisplayMember = display;
                        comboBox.ValueMember = value;

                        comboBox.DataSource = dt;
                        isLoading = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to Find the Curriculum ID | Error:" + ex.Message);
                    }
                }

            }

        }

        public void LoadComboBox(ComboBox comboBox, string display, string value, string table, string where)
        {
            string query = $"SELECT {display}, {value} FROM {table} JOIN CurriculumHeader CH ON {value} = CH.ProgramID WHERE CH.CurriculumYear = @CurriculumYear";


            using (SqlConnection conn = new SqlConnection(DbControl.ConnString("RMSDB")))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CurriculumYear", where);

                    try
                    {
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        isLoading = true;
                        
                        comboBox.DisplayMember = display;
                        comboBox.ValueMember = value;

                        comboBox.DataSource = dt;
                        isLoading = false;


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
                    

                    using (SqlCommand cmd = new SqlCommand("sp_InsertCurriculumCourse", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CurriculumID", curriculumID);
                        
                        cmd.Parameters.AddWithValue("@CourseID", courseID);

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

                        dgvCurriculumCourse.Columns["OfferingID"].Visible = false;
                        dgvCurriculumCourse.Columns["CurriculumID"].Visible = false;
                        dgvCurriculumCourse.Columns["CourseID"].Visible = false;    
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to Find the Curriculum ID | Error:" + ex.Message);
                    }

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



                    cmd.Parameters.AddWithValue("@OfferingID", Convert.ToInt32(dgvCurriculumCourse.Rows[selectedRow].Cells["OfferingID"].Value));
                   
                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Successfully Deleted");
                            dgvCurriculumCourse.Rows.Remove(dgvCurriculumCourse.Rows[selectedRow]);
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

        private void btnSearchCurriculum_Click(object sender, EventArgs e)
        {
            lblSeachCurriculumYear.Visible = true;
            cbxSeachCurriculumYear.Visible = true;
            lblSearchCurriculumProgram.Visible = true;
            cbxSearchCurriculumProgram.Visible = true;


            txtCurriculumYear.Text = "";
            cbxProgram.SelectedIndex = -1;
            cbxYearLevel.SelectedIndex = -1;
            cbxCourse.SelectedIndex = -1;
            cbxSemester.SelectedIndex = -1;


            pnlCurriculum.Enabled = false;
            pnlCurriculumCourse.Enabled = false;
            pnlYearLevelAndSem.Enabled = false;
            
            LoadComboBox(cbxSeachCurriculumYear, "CurriculumYear", "CurriculumHeader");
        }

        private void cbxSeachCurriculumYear_SelectedValueChanged(object sender, EventArgs e)
        {
            if (isLoading) { return; }

            if (cbxSeachCurriculumYear.SelectedIndex != -1 )
            {
                if (cbxSearchCurriculumProgram.SelectedIndex != -1)
                {
                    btnSearchView.Visible = true;
                    btnSearchEdit.Visible = true;
                }
                LoadComboBox(cbxSearchCurriculumProgram, "P.ProgramCode", "P.ProgramID", "Program P", cbxSeachCurriculumYear.Text.ToString());
                
            }
            
        }

        private void cbxSearchCurriculumProgram_SelectedValueChanged(object sender, EventArgs e)
        {
            if (isLoading) { return; }

            if (cbxSeachCurriculumYear.SelectedIndex != -1)
            {
                if (cbxSearchCurriculumProgram.SelectedIndex != -1)
                {
                    btnSearchView.Visible = true;
                    btnSearchEdit.Visible = true;
                }
            }
        }

        private void btnSearchEdit_Click(object sender, EventArgs e)
        {
            if (cbxSeachCurriculumYear.SelectedItem == null || cbxSearchCurriculumProgram.SelectedItem == null)
            {
                MessageBox.Show("Please Fill all the fields");
                return;
            }

            txtCurriculumYear.Text = cbxSeachCurriculumYear.Text;
            
            int index = cbxProgram.FindStringExact(cbxSearchCurriculumProgram.Text);
            if (index != -1)
            {
                cbxProgram.SelectedIndex = index;
            }

            editing = true;
            pnlCurriculum.Enabled = false;
            pnlYearLevelAndSem.Enabled = true;
            btnSaveCurriculumCourse.Visible = false;

            selectCurriculumHeaderID();
            viewAllCurriculum();

            pnlCurriculumHeader.HeaderLabel = cbxProgram.Text + " - " + txtCurriculumYear.Text;

        }

        private void btnSearchView_Click(object sender, EventArgs e)
        {
            frmSearchView viewSearchCurriculum = new frmSearchView(cbxSeachCurriculumYear.Text, Convert.ToInt32(cbxSearchCurriculumProgram.SelectedValue), cbxSearchCurriculumProgram.Text);
            viewSearchCurriculum.ShowDialog();
        }

    }
    
}
