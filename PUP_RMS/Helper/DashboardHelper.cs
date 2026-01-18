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


        public static DataTable GetProgramDistribution()
        {
            return DbControl.ExecuteQuery("sp_GetDistributionByProgram");
        }

        public static DataTable GetFacultyDistribution()
        {
            return DbControl.ExecuteQuery("sp_GetDistributionByFaculty");
        }

        public static DataTable GetSubjectDistribution()
        {
            return DbControl.ExecuteQuery("sp_GetDistributionBySubject");
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


    }
}