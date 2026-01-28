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
        // ============================================================
        // SECTION 1: DASHBOARD CARD COUNTS (TOTALS)
        // ============================================================

        // 1. Get Total Grade Sheets Count
        public static string GetGradeSheetCount()
        {
            try
            {
                int count = DbControl.ExecuteScalar("sp_GetGradeSheetCount");
                return count.ToString();
            }
            catch { return "0"; }
        }

        // 2. Get Total Subjects Count
        public static string GetSubjectCount()
        {
            try
            {
                int count = DbControl.ExecuteScalar("sp_GetSubjectCount");
                return count.ToString();
            }
            catch { return "0"; }
        }

        // 3. Get Total Professors Count
        public static string GetProfessorCount()
        {
            try
            {
                int count = DbControl.ExecuteScalar("sp_GetFacultyCount");
                return count.ToString();
            }
            catch { return "0"; }
        }

        // 4. Get Total Program Count
        public static string GetProgramCount()
        {
            try
            {
                int count = DbControl.ExecuteScalar("sp_GetProgramCount");
                return count.ToString();
            }
            catch { return "0"; }
        }

        // ============================================================
        // SECTION 2: DROPDOWN & COMBOBOX DATA LOADERS
        // ============================================================

        // Load all available Curriculums
        public static DataTable GetCurriculums()
        {
            return DbControl.ExecuteQuery("sp_GetAllCurriculums");
        }

        // Load School Years (Optionally filtered by Curriculum)
        public static DataTable GetSchoolYears(string curriculumYear = null)
        {
            DbControl.sqlParameters.Clear();
            if (!string.IsNullOrEmpty(curriculumYear) && curriculumYear != "All")
                DbControl.AddParameter("@CurriculumYear", curriculumYear, SqlDbType.VarChar);
            else
                DbControl.AddParameter("@CurriculumYear", DBNull.Value, SqlDbType.VarChar);

            return DbControl.ExecuteQuery("sp_GetSchoolYearsByCurriculum");
        }

        // OVERLOAD: Get School Years filtered by Curriculum AND Program
        // (Used specifically for the Program Distribution Drill-down view)
        public static DataTable GetSchoolYears(string curriculumYear, string programCode)
        {
            DbControl.sqlParameters.Clear();

            // 1. Curriculum Parameter
            if (!string.IsNullOrEmpty(curriculumYear) && curriculumYear != "All")
                DbControl.AddParameter("@CurriculumYear", curriculumYear, SqlDbType.VarChar);
            else
                DbControl.AddParameter("@CurriculumYear", DBNull.Value, SqlDbType.VarChar);

            // 2. Program Parameter
            if (!string.IsNullOrEmpty(programCode) && programCode != "All")
                DbControl.AddParameter("@ProgramCode", programCode, SqlDbType.VarChar);
            else
                DbControl.AddParameter("@ProgramCode", DBNull.Value, SqlDbType.VarChar);

            return DbControl.ExecuteQuery("sp_GetSchoolYearsByCurriculumAndProgram");
        }

        // Load Semesters (Filtered by Curriculum and School Year)
        public static DataTable GetSemesters(string curriculumYear = null, string schoolYear = null)
        {
            DbControl.sqlParameters.Clear();

            DbControl.AddParameter("@CurriculumYear", (string.IsNullOrEmpty(curriculumYear) || curriculumYear == "All") ? DBNull.Value : (object)curriculumYear, SqlDbType.VarChar);
            DbControl.AddParameter("@SchoolYear", (string.IsNullOrEmpty(schoolYear) || schoolYear == "All") ? DBNull.Value : (object)schoolYear, SqlDbType.VarChar);

            return DbControl.ExecuteQuery("sp_GetSemestersByFilters");
        }

        // ============================================================
        // SECTION 3: PROGRAM DISTRIBUTION (PIE/BAR CHARTS)
        // ============================================================

        public static DataTable GetProgramDistribution(string schoolYear = null, string curriculumYear = null)
        {
            DbControl.sqlParameters.Clear();

            DbControl.AddParameter("@SchoolYear", (string.IsNullOrEmpty(schoolYear) || schoolYear == "All") ? DBNull.Value : (object)schoolYear, SqlDbType.VarChar);
            DbControl.AddParameter("@CurriculumYear", (string.IsNullOrEmpty(curriculumYear) || curriculumYear == "All") ? DBNull.Value : (object)curriculumYear, SqlDbType.VarChar);

            return DbControl.ExecuteQuery("sp_GetDistributionByProgram_Filtered");
        }

        public static DataTable GetYearLevelDistribution(string programCode, string schoolYear = null, string curriculumYear = null)
        {
            DbControl.sqlParameters.Clear();
            DbControl.AddParameter("@ProgramCode", programCode, SqlDbType.VarChar);

            if (!string.IsNullOrEmpty(schoolYear) && schoolYear != "All")
                DbControl.AddParameter("@SchoolYear", schoolYear, SqlDbType.VarChar);
            else
                DbControl.AddParameter("@SchoolYear", DBNull.Value, SqlDbType.VarChar);

            if (!string.IsNullOrEmpty(curriculumYear) && curriculumYear != "All")
                DbControl.AddParameter("@CurriculumYear", curriculumYear, SqlDbType.VarChar);
            else
                DbControl.AddParameter("@CurriculumYear", DBNull.Value, SqlDbType.VarChar);
            return DbControl.ExecuteQuery("sp_GetYearLevelDistributionByProgram");
        }

        // ============================================================
        // SECTION 4: FACULTY/PROFESSOR DISTRIBUTION
        // ============================================================

        // Get Standard Faculty Distribution
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

        // ============================================================
        // SECTION 5: SUBJECT DISTRIBUTION (THE ERROR FIX)
        // ============================================================

        // FIXED: Calls the 3-way filter: Curriculum, School Year, and Semester
        // SECTION 5: SUBJECT DISTRIBUTION
        public static DataTable GetSubjectDistribution(string curriculumYear = null, string schoolYear = null, string semester = null)
        {
            DbControl.sqlParameters.Clear();

            // 1. Curriculum Parameter
            DbControl.AddParameter("@CurriculumYear", (string.IsNullOrEmpty(curriculumYear) || curriculumYear == "All") ? DBNull.Value : (object)curriculumYear, SqlDbType.VarChar);

            // 2. School Year Parameter
            DbControl.AddParameter("@SchoolYear", (string.IsNullOrEmpty(schoolYear) || schoolYear == "All") ? DBNull.Value : (object)schoolYear, SqlDbType.VarChar);

            // 3. Semester Parameter (FIXED PARSING LOGIC)
            object semesterValue = DBNull.Value;

            if (!string.IsNullOrEmpty(semester) && semester != "All")
            {
                if (semester.Contains("1st")) semesterValue = 1;
                else if (semester.Contains("2nd")) semesterValue = 2;
                else if (semester.Contains("Summer")) semesterValue = 3;
                // Fallback if you have simple numbers in string format
                else if (int.TryParse(semester, out int parsedSem)) semesterValue = parsedSem;
            }

            DbControl.AddParameter("@Semester", semesterValue, SqlDbType.Int);

            return DbControl.ExecuteQuery("sp_GetDistributionBySubject_FilteredFull");
        }

        // Get specific details for a subject click
        public static DataTable GetSubjectDetails(string courseDescription)
        {
            DbControl.sqlParameters.Clear();
            DbControl.AddParameter("@CourseDescription", courseDescription, SqlDbType.VarChar);
            return DbControl.ExecuteQuery("sp_GetSubjectDetailsByName");
        }

        // ============================================================
        // SECTION 6: YEAR & SEMESTER MATRIX
        // ============================================================

        // Add these to SECTION 6: YEAR & SEMESTER MATRIX in DashboardHelper.cs

        public static DataTable GetProgramsByFilter(string curriculum)
        {
            DbControl.sqlParameters.Clear();
            DbControl.AddParameter("@Curriculum", (string.IsNullOrEmpty(curriculum) || curriculum == "All") ? DBNull.Value : (object)curriculum, SqlDbType.VarChar);
            return DbControl.ExecuteQuery("sp_GetProgramsByFilter");
        }

        public static DataTable GetFacultyByFilter(string curriculum, string program)
        {
            DbControl.sqlParameters.Clear();
            DbControl.AddParameter("@Curriculum", (string.IsNullOrEmpty(curriculum) || curriculum == "All") ? DBNull.Value : (object)curriculum, SqlDbType.VarChar);
            DbControl.AddParameter("@Program", (string.IsNullOrEmpty(program) || program == "All") ? DBNull.Value : (object)program, SqlDbType.VarChar);
            return DbControl.ExecuteQuery("sp_GetFacultyByFilter");
        }

        public static DataTable GetSubjectsByFilter(string curriculum, string program, string faculty)
        {
            DbControl.sqlParameters.Clear();
            DbControl.AddParameter("@Curriculum", (string.IsNullOrEmpty(curriculum) || curriculum == "All") ? DBNull.Value : (object)curriculum, SqlDbType.VarChar);
            DbControl.AddParameter("@Program", (string.IsNullOrEmpty(program) || program == "All") ? DBNull.Value : (object)program, SqlDbType.VarChar);
            DbControl.AddParameter("@Faculty", (string.IsNullOrEmpty(faculty) || faculty == "All") ? DBNull.Value : (object)faculty, SqlDbType.VarChar);
            return DbControl.ExecuteQuery("sp_GetSubjectsByFilter");
        }

        public static DataTable GetSchoolYearsByFilter(string curriculum, string program, string faculty, string subject)
        {
            DbControl.sqlParameters.Clear();
            DbControl.AddParameter("@Curriculum", (string.IsNullOrEmpty(curriculum) || curriculum == "All") ? DBNull.Value : (object)curriculum, SqlDbType.VarChar);
            DbControl.AddParameter("@Program", (string.IsNullOrEmpty(program) || program == "All") ? DBNull.Value : (object)program, SqlDbType.VarChar);
            DbControl.AddParameter("@Faculty", (string.IsNullOrEmpty(faculty) || faculty == "All") ? DBNull.Value : (object)faculty, SqlDbType.VarChar);
            DbControl.AddParameter("@Subject", (string.IsNullOrEmpty(subject) || subject == "All") ? DBNull.Value : (object)subject, SqlDbType.VarChar);
            return DbControl.ExecuteQuery("sp_GetSchoolYearsByFilter");
        }

        public static DataTable GetYearSemDistribution(string curr, string prog, string prof, string subj, string year)
        {
            DbControl.sqlParameters.Clear();

            // Maps the C# variables to the SQL Procedure parameters
            DbControl.AddParameter("@Curriculum", (string.IsNullOrEmpty(curr) || curr == "All") ? DBNull.Value : (object)curr, SqlDbType.VarChar);
            DbControl.AddParameter("@Program", (string.IsNullOrEmpty(prog) || prog == "All") ? DBNull.Value : (object)prog, SqlDbType.VarChar);
            DbControl.AddParameter("@Faculty", (string.IsNullOrEmpty(prof) || prof == "All") ? DBNull.Value : (object)prof, SqlDbType.VarChar);
            DbControl.AddParameter("@Subject", (string.IsNullOrEmpty(subj) || subj == "All") ? DBNull.Value : (object)subj, SqlDbType.VarChar);
            DbControl.AddParameter("@SchoolYear", (string.IsNullOrEmpty(year) || year == "All") ? DBNull.Value : (object)year, SqlDbType.VarChar);

            return DbControl.ExecuteQuery("sp_GetDistributionByYearSem");
        }

        // ============================================================
        // SECTION 7: ACTIVITY LOGS & RECENT UPLOADS
        // ============================================================

        // Activity log from dashboard
        public static DataTable GetRecentActivities()
        {
            return DbControl.ExecuteQuery("sp_GetActivityLogWithUserDesc");
        }

        // Top 10 recently uploaded grade sheets
        public static DataTable recentlyUploads()
        {
            return DbControl.ExecuteQuery("RecentUploadedGradeSheets");
        }
    }
}