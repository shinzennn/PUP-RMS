using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PUP_RMS.Core; // Import your Database Control

namespace PUP_RMS.Helper
{
    public static class DashboardHelper
    {
        // 1. Get Grade Sheets Count
        public static string GetGradeSheetCount()
        {
            try
            {
                int count = DbControl.ExecuteScalar("sp_GetGradeSheetCount");
                return count.ToString();
            }
            catch
            {
                return "0"; // Return 0 if there is an error
            }
        }

        // 2. Get Subjects Count
        public static string GetSubjectCount()
        {
            try
            {
                int count = DbControl.ExecuteScalar("sp_GetSubjectCount");
                return count.ToString();
            }
            catch
            {
                return "0";
            }
        }

        // 3. Get Professors Count
        public static string GetProfessorCount()
        {
            try
            {
                int count = DbControl.ExecuteScalar("sp_GetFacultyCount");
                return count.ToString();
            }
            catch
            {
                return "0";
            }
        }
        // 3. Get Program Count
        public static string GetProgramCount()
        {
            try
            {
                int count = DbControl.ExecuteScalar("countTotalProgram");
                return count.ToString();
            }
            catch
            {
                return "0";
            }
        }


        public static DataTable GetProgramDistribution()
        {
            return DbControl.ExecuteQuery("sp_GetDistributionByProgram");
        }

        public static DataTable GetProgramDistribution(string schoolYear = null)
        {
            DbControl.sqlParameters.Clear();

            // If a specific year is selected (not null, not empty, and not "All")
            if (!string.IsNullOrEmpty(schoolYear) && schoolYear != "All")
            {
                DbControl.AddParameter("@SchoolYear", schoolYear, SqlDbType.VarChar);
            }
            else
            {
                // Pass NULL to get all records
                DbControl.AddParameter("@SchoolYear", DBNull.Value, SqlDbType.VarChar);
            }

            // Make sure you have created this Stored Procedure in SQL (sp_GetDistributionByProgram_Filtered)
            return DbControl.ExecuteQuery("sp_GetDistributionByProgram_Filtered");
        }


        public static DataTable GetFacultyDistribution()
        {
            return DbControl.ExecuteQuery("sp_GetDistributionByFaculty");
        }

        //Filter grasheet per School Year in By Faculty
        public static DataTable GetFacultyDistribution(string schoolYear = null)
        {
            DbControl.sqlParameters.Clear();

            if (!string.IsNullOrEmpty(schoolYear) && schoolYear != "All")
            {
                DbControl.AddParameter("@SchoolYear", schoolYear, SqlDbType.VarChar);
            }
            else
            {
                DbControl.AddParameter("@SchoolYear", DBNull.Value, SqlDbType.VarChar);
            }

            return DbControl.ExecuteQuery("sp_GetDistributionByFaculty_Filtered");
        }


        public static DataTable GetSubjectDistribution()
        {
            return DbControl.ExecuteQuery("sp_GetDistributionBySubject");
        }

        public static DataTable GetSubjectDetails(string courseDescription)
        {
            // Clear any previous parameters to avoid conflicts
            DbControl.sqlParameters.Clear();

            // Add the parameter expected by the Stored Procedure
            DbControl.AddParameter("@CourseDescription", courseDescription, SqlDbType.VarChar);

            // Execute the stored procedure
            return DbControl.ExecuteQuery("sp_GetSubjectDetailsByName");
        }

        public static DataTable GetYearSemDistribution(string prog = null, string prof = null, string subj = null, string year = null)
        {
            DbControl.sqlParameters.Clear();

            // Only add parameters if they have a value
            if (!string.IsNullOrEmpty(prog)) DbControl.AddParameter("@Program", prog, System.Data.SqlDbType.VarChar);
            else DbControl.AddParameter("@Program", DBNull.Value, System.Data.SqlDbType.VarChar);

            if (!string.IsNullOrEmpty(prof)) DbControl.AddParameter("@Faculty", prof, System.Data.SqlDbType.VarChar);
            else DbControl.AddParameter("@Faculty", DBNull.Value, System.Data.SqlDbType.VarChar);


            if (!string.IsNullOrEmpty(subj)) DbControl.AddParameter("@Subject", subj, System.Data.SqlDbType.VarChar);
            else DbControl.AddParameter("@Subject", DBNull.Value, System.Data.SqlDbType.VarChar);

            if (!string.IsNullOrEmpty(year)) DbControl.AddParameter("@SchoolYear", year, System.Data.SqlDbType.VarChar);
            else DbControl.AddParameter("@SchoolYear", DBNull.Value, System.Data.SqlDbType.VarChar);

            return DbControl.ExecuteQuery("sp_GetDistributionByYearSem");
        }

        //Filter grasheet per School Year in By program
        public static DataTable GetSchoolYears()
        {
            return DbControl.ExecuteQuery("sp_GetAllSchoolYears");
        }

        public static DataTable GetRecentActivities()
        {
            return DbControl.ExecuteQuery("sp_GetActivityLogWithUserDesc");
        }

        public static DataTable recentlyUploads()
        {
            return DbControl.ExecuteQuery("RecentUploadedGradeSheets");
        }

        //filter by schoolyear in subject distribution 
        public static DataTable GetSubjectDistribution(string schoolYear = null)
        {
            DbControl.sqlParameters.Clear();

            // If a specific year is selected (not null, empty, or "All Years")
            if (!string.IsNullOrEmpty(schoolYear) && schoolYear != "All Years")
            {
                DbControl.AddParameter("@SchoolYear", schoolYear, System.Data.SqlDbType.VarChar);
            }
            else
            {
                // Pass NULL to get all records
                DbControl.AddParameter("@SchoolYear", DBNull.Value, System.Data.SqlDbType.VarChar);
            }

            return DbControl.ExecuteQuery("sp_GetDistributionBySubject_FilteredSchoolYears");
        }

    }
}

