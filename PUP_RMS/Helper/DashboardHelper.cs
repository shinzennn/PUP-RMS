using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PUP_RMS.Core;

namespace PUP_RMS.Helper
{
    public static class DashboardHelper
    {
        
        // SECTION 1: COUNTS (DASHBOARD CARDS)
        public static string GetGradeSheetCount()
        {
            try{
                int count = DbControl.ExecuteScalar("sp_GetGradeSheetCount");
                return count.ToString();
            }catch { return "0"; }
        }

        public static string GetSubjectCount()
        {
            try{
                int count = DbControl.ExecuteScalar("sp_GetSubjectCount");
                return count.ToString();
            }catch { return "0"; }
        }

        public static string GetProfessorCount()
        {
            try{
                int count = DbControl.ExecuteScalar("sp_GetFacultyCount");
                return count.ToString();
            }catch { return "0"; }
        }

        public static string GetProgramCount()
        {
            try{
                int count = DbControl.ExecuteScalar("countTotalProgram");
                return count.ToString();
            }catch { return "0"; }
        }

        // SECTION 2: CHARTS & DISTRIBUTIONS
        // 1. PROGRAM DISTRIBUTION (Merged Logic)
        public static DataTable GetProgramDistribution(string schoolYear = null)
        {
            DbControl.sqlParameters.Clear();
            // If a specific year is provided
            if (!string.IsNullOrEmpty(schoolYear) && schoolYear != "All")
            {
                DbControl.AddParameter("@SchoolYear", schoolYear, SqlDbType.VarChar);
                return DbControl.ExecuteQuery("sp_GetDistributionByProgram_Filtered");
            }
            else
            {
                // If "All" or null, use the standard non-filtered SP
                return DbControl.ExecuteQuery("sp_GetDistributionByProgram");
            }
        }

        // 2. FACULTY DISTRIBUTION (Merged Logic - Fixes your error)
        public static DataTable GetFacultyDistribution(string schoolYear = null, string curriculumYear = null)
        {
            DbControl.sqlParameters.Clear();
            // Parameter 1: School Year
            if (!string.IsNullOrEmpty(schoolYear) && schoolYear != "All")
                DbControl.AddParameter("@SchoolYear", schoolYear, SqlDbType.VarChar);
            else
                DbControl.AddParameter("@SchoolYear", DBNull.Value, SqlDbType.VarChar);

            // Parameter 2: Curriculum Year
            if (!string.IsNullOrEmpty(curriculumYear) && curriculumYear != "All")
                DbControl.AddParameter("@CurriculumYear", curriculumYear, SqlDbType.VarChar);
            else
                DbControl.AddParameter("@CurriculumYear", DBNull.Value, SqlDbType.VarChar);

            // Calls the SP that handles both parameters
            return DbControl.ExecuteQuery("sp_GetDistributionByFaculty_Filtered");
        }

        // 3. SUBJECT DISTRIBUTION (Merged Logic)
        public static DataTable GetSubjectDistribution(string schoolYear = null)
        {
            DbControl.sqlParameters.Clear();
            if (!string.IsNullOrEmpty(schoolYear) && schoolYear != "All" && schoolYear != "All Years")
            {
                DbControl.AddParameter("@SchoolYear", schoolYear, SqlDbType.VarChar);
                return DbControl.ExecuteQuery("sp_GetDistributionBySubject_FilteredSchoolYears");
            }
            else
            {
                // Use the basic one if no filter
                return DbControl.ExecuteQuery("sp_GetDistributionBySubject");
            }
        }

        // 4. YEAR/SEM DISTRIBUTION
        public static DataTable GetYearSemDistribution(string prog = null, string prof = null, string subj = null, string year = null)
        {
            DbControl.sqlParameters.Clear();

            if (!string.IsNullOrEmpty(prog)) DbControl.AddParameter("@Program", prog, SqlDbType.VarChar);
            else DbControl.AddParameter("@Program", DBNull.Value, SqlDbType.VarChar);

            if (!string.IsNullOrEmpty(prof)) DbControl.AddParameter("@Faculty", prof, SqlDbType.VarChar);
            else DbControl.AddParameter("@Faculty", DBNull.Value, SqlDbType.VarChar);

            if (!string.IsNullOrEmpty(subj)) DbControl.AddParameter("@Subject", subj, SqlDbType.VarChar);
            else DbControl.AddParameter("@Subject", DBNull.Value, SqlDbType.VarChar);

            if (!string.IsNullOrEmpty(year)) DbControl.AddParameter("@SchoolYear", year, SqlDbType.VarChar);
            else DbControl.AddParameter("@SchoolYear", DBNull.Value, SqlDbType.VarChar);

            return DbControl.ExecuteQuery("sp_GetDistributionByYearSem");
        }

        // =============================================================
        // SECTION 3: DROPDOWN HELPERS
        // =============================================================

        public static DataTable GetSchoolYears()
        {
            return DbControl.ExecuteQuery("sp_GetAllSchoolYears");
        }

        // Removed the duplicate definition of this method
        public static DataTable GetCurriculumYears()
        {
            return DbControl.ExecuteQuery("sp_GetAllCurriculumYears");
        }

        // SECTION 4: MISC & DETAILS
      
        public static DataTable GetSubjectDetails(string courseDescription)
        {
            DbControl.sqlParameters.Clear();
            DbControl.AddParameter("@CourseDescription", courseDescription, SqlDbType.VarChar);
            return DbControl.ExecuteQuery("sp_GetSubjectDetailsByName");
        }

        public static DataTable GetRecentActivities()
        {
            return DbControl.ExecuteQuery("sp_GetActivityLogWithUserDesc");
        }

        public static DataTable recentlyUploads()
        {
            return DbControl.ExecuteQuery("RecentUploadedGradeSheets");
        }

        // Add this inside the DashboardHelper class in PUP_RMS.Helper namespace
        public static DataTable GetGradeSheetsByFaculty(string facultyName, string schoolYear, string curriculumYear)
        {
            DbControl.sqlParameters.Clear();

            // Parameter 1: Name
            DbControl.AddParameter("@FacultyName", facultyName, SqlDbType.VarChar);

            // Parameter 2: School Year
            if (!string.IsNullOrEmpty(schoolYear) && schoolYear != "All")
                DbControl.AddParameter("@SchoolYear", schoolYear, SqlDbType.VarChar);
            else
                DbControl.AddParameter("@SchoolYear", DBNull.Value, SqlDbType.VarChar);

            // Parameter 3: Curriculum Year
            if (!string.IsNullOrEmpty(curriculumYear) && curriculumYear != "All")
                DbControl.AddParameter("@CurriculumYear", curriculumYear, SqlDbType.VarChar);
            else
                DbControl.AddParameter("@CurriculumYear", DBNull.Value, SqlDbType.VarChar);

            return DbControl.ExecuteQuery("sp_GetGradeSheetsByFacultyDetails");
        }
    }
}