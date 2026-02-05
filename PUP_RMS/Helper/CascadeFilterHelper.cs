using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PUP_RMS.Core;

namespace PUP_RMS.Helper
{
    public class CascadeFilterHelper
    {

        // Note: Use DbControl.GetData to retrieve data from the database and return it as a DataTable.

        // 1. 
        public DataTable GetPrograms()
        {
            DataTable dt = new DataTable();
            string query = "SELECT ProgramID, ProgramCode FROM Program";
            dt = DbControl.GetData(query);

            return dt;
        }

        public DataTable GetCurriculumYears(int _progID)
        {
            DataTable dt = new DataTable();
            string query = "SELECT DISTINCT CurriculumHeaderID, CurriculumYear FROM CurriculumHeader WHERE ProgramID = @ProgramID ORDER BY CurriculumYear DESC;";

            DbControl.AddParameter("@ProgramID", _progID, SqlDbType.Int);
            dt = DbControl.GetData(query);

            return dt;
        }

        public DataTable GetYearLevels(int _currHeadID)
        {
            DataTable dt = new DataTable();
            string query = "SELECT DISTINCT YearLevel FROM Curriculum WHERE CurriculumHeaderID = @CurriculumHeaderID";

            DbControl.AddParameter("@CurriculumHeaderID", _currHeadID, SqlDbType.Int);
            dt = DbControl.GetData(query);

            return dt;
        }

        public DataTable GetSemesters(int _currHeadID, int _yearLevel)
        {
            DataTable dt = new DataTable();
            string query = "SELECT DISTINCT CurriculumID, Semester FROM Curriculum WHERE CurriculumHeaderID = @CurriculumHeaderID AND YearLevel = @YearLevel";
            
            DbControl.AddParameter("@CurriculumHeaderID", _currHeadID, SqlDbType.Int);
            DbControl.AddParameter("@YearLevel", _yearLevel, SqlDbType.Int);
            dt = DbControl.GetData(query);

            return dt;
        }

        public DataTable GetCourses(int _currID)
        {
            DataTable dt = new DataTable();
            string query = "SELECT o.OfferingID, c.CourseCode " +
                           "FROM Offering o JOIN Course c ON o.CourseID = c.CourseID " +
                           "WHERE o.CurriculumID = @CurriculumID " +
                           "ORDER BY c.CourseCode ASC";

            DbControl.AddParameter("@CurriculumID", _currID, SqlDbType.Int);
            dt = DbControl.GetData(query);

            return dt;
        }

        public DataTable GetSchoolYears(int _offID)
        {
            DataTable dt = new DataTable();
            string query = "SELECT DISTINCT SchoolYear FROM ClassSection WHERE OfferingID = @OfferingID";

            DbControl.AddParameter("@OfferingID", _offID, SqlDbType.Int);
            dt = DbControl.GetData(query);

            return dt;
        }

        public DataTable GetSections(int _offID, string _schoolYear)
        {
            // Added spaces and used verbatim string for clarity
            string query = @"SELECT cs.SectionID, cs.Section, CONCAT(f.FirstName, ' ', f.LastName) AS FullName 
                     FROM ClassSection cs 
                     JOIN Faculty f ON cs.FacultyID = f.FacultyID 
                     WHERE cs.OfferingID = @OfferingID AND cs.SchoolYear = @SchoolYear 
                     ORDER BY cs.Section ASC;";

            DbControl.ClearParameters(); // Always a good habit to clear before adding
            DbControl.AddParameter("@OfferingID", _offID, SqlDbType.Int);
            DbControl.AddParameter("@SchoolYear", _schoolYear, SqlDbType.VarChar);
            return DbControl.GetData(query);
        }

        public DataTable GetFaculty(int _sectionID)
        {
            // Fixed the missing space before WHERE
            string query = @"SELECT f.FacultyID, CONCAT(f.FirstName, ' ', f.LastName) AS FullName 
                     FROM ClassSection cs 
                     JOIN Faculty f ON cs.FacultyID = f.FacultyID 
                     WHERE cs.SectionID = @SectionID";

            DbControl.ClearParameters();
            DbControl.AddParameter("@SectionID", _sectionID, SqlDbType.Int);
            return DbControl.GetData(query);
        }

        // --- Helper Methods for UI 
        public void BindCombo(ComboBox cb, DataTable dt, string display, string value)
        {
            cb.DataSource = null; // Clear old data first
            if (dt == null || dt.Rows.Count == 0) return;
            cb.DisplayMember = display;
            cb.ValueMember = value;
            cb.DataSource = dt;
            cb.SelectedIndex = -1;
        }

        public void ClearCombos(params ComboBox[] combos)
        {
            foreach (var cb in combos)
            {
                cb.DataSource = null;
                cb.Items.Clear();
                cb.Text = "";
            }
        }
    }
}
