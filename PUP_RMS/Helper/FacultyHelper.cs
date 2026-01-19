using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PUP_RMS.Core;
using PUP_RMS.Model;

namespace PUP_RMS.Helper
{
    public static class FacultyHelper
    {
        // FETCH ALL FACULTY
        public static DataTable GetAllFaculty()
        {
            DataTable dt = new DataTable();

            dt = DbControl.ExecuteQuery("sp_GetAllFaculty");

            return dt;
        }

        // PRACTICE LANG TO WHAHAHAHA PERO DAPAT NASA PROGRAMHELPER TO
        public static DataTable GetAllProgram()
        {
            DataTable dt = new DataTable();

            dt = DbControl.ExecuteQuery("sp_GetAllProgram");

            return dt;
        }

        // SEARCH FACULTY
        public static DataTable SearchFaculty(string searchTerm, int programID)
        {
            // CREATE DATATABLE TO HOLD RESULTS
            DataTable dt = new DataTable();

            //STORED PROCEDURE NAME
            string procedureName = "sp_SearchFaculty";

            // ADD PARAMETERS
            DbControl.AddParameter("@SearchTerm", searchTerm, SqlDbType.VarChar);
            DbControl.AddParameter("@ProgramID", programID, SqlDbType.Int);

            // EXECUTE QUERY AND CLEAR PARAMETERS
            dt = DbControl.ExecuteQuery(procedureName);

            return dt;
        }
        public static DataTable SearchFaculty(string searchTerm)
        {
            // CREATE DATATABLE TO HOLD RESULTS
            DataTable dt = new DataTable();

            //STORED PROCEDURE NAME
            string procedureName = "sp_SearchFaculty";

            // ADD PARAMETERS
            DbControl.AddParameter("@SearchTerm", searchTerm, SqlDbType.VarChar);

            // EXECUTE QUERY AND CLEAR PARAMETERS
            dt = DbControl.ExecuteQuery(procedureName);

            return dt;
        }

        // CREATE FACULTY
        public static void CreateFaculty(Faculty faculty)
        {
            // STORED PROCEDURE NAME
            string procedureName = "sp_CreateFaculty";

            // ADD PARAMETERS
            DbControl.AddParameter("@FirstName", faculty.FirstName, SqlDbType.VarChar);
            DbControl.AddParameter("@MiddleName", faculty.MiddleName, SqlDbType.VarChar);
            DbControl.AddParameter("@LastName", faculty.LastName, SqlDbType.VarChar);
            DbControl.AddParameter("@Initials", faculty.Initials, SqlDbType.VarChar);

            // EXECUTE NON QUERY AND CLEAR PARAMETERS
            if(DbControl.ExecuteNonQuery(procedureName) >= 1)
            {
                MessageBox.Show("Faculty created successfully.", "Record Created Successfully.", MessageBoxButton.OK, MessageBoxImage.Information);

                // LOG ACTIVITY
                ActivityLogger.LogFacultyAddition(faculty.FirstName + " " + faculty.LastName);
            }
            else
            {
                MessageBox.Show("Failed to create faculty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void UpdateFaculty(Faculty faculty)
        {
            // STORED PROCEDURE NAME
            string procedureName = "sp_UpdateFaculty";

            // ADD PARAMETERS
            DbControl.AddParameter("@FacultyID", faculty.FacultyID, SqlDbType.Int);
            DbControl.AddParameter("@FirstName", faculty.FirstName, SqlDbType.VarChar);
            DbControl.AddParameter("@MiddleName", faculty.MiddleName, SqlDbType.VarChar);
            DbControl.AddParameter("@LastName", faculty.LastName, SqlDbType.VarChar);
            DbControl.AddParameter("@Initials", faculty.Initials, SqlDbType.VarChar);

            // EXECUTE NON QUERY AND CLEAR PARAMETERS
            if (DbControl.ExecuteNonQuery(procedureName) >= 1)
            {
                MessageBox.Show("Faculty updated successfully.", "Record Created Successfully.", MessageBoxButton.OK, MessageBoxImage.Information);

                // LOG ACTIVITY
                ActivityLogger.LogFacultyAddition(faculty.FirstName + " " + faculty.LastName);
            }
            else
            {
                MessageBox.Show("Failed to update faculty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static string ConstructInitials(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return string.Empty;

            // 1. Separate Last Name from the rest using the comma
            string[] parts = fullName.Split(',');

            if (parts.Length < 2)
            {
                // Fallback if no comma: Remove all spaces and make uppercase
                return fullName.Replace(" ", "").ToUpper();
            }

            // 2. Process Last Name: Remove internal spaces (e.g., "De Asis" -> "DEASIS")
            string lastName = parts[0].Trim().Replace(" ", "").ToUpper();

            // 3. Process Other Names: Get the first letter of each word
            string otherNames = parts[1].Trim().Replace(".", "");
            StringBuilder initials = new StringBuilder();

            string[] words = otherNames.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                initials.Append(char.ToUpper(word[0]));
            }

            // 4. Combine (Result: DEASISPA)
            return lastName + initials.ToString();
        }

        public static string ConstructFullname(string first, string middle, string last)
        {
            // 1. Clean and Uppercase the Last Name
            string formattedLast = last.Trim().ToUpper();

            // 2. Clean and Uppercase the First Name
            string formattedFirst = first.Trim().ToUpper();

            // 3. Handle Middle Name / Initial logic
            string formattedMiddle = "";
            if (!string.IsNullOrWhiteSpace(middle))
            {
                formattedMiddle = middle.Trim().ToUpper();

                // If middle is a single letter and doesn't have a period, add one
                if (formattedMiddle.Length == 1)
                {
                    formattedMiddle += ".";
                }
                // If it ends with a letter (not a period), ensure a period is at the very end
                else if (!formattedMiddle.EndsWith("."))
                {
                    formattedMiddle += ".";
                }
            }

            // 4. Combine into: LAST, FIRST MIDDLE
            // We use Trim() at the end in case the middle name was empty
            return $"{formattedLast}, {formattedFirst} {formattedMiddle}".Trim();
        }
    }
}
