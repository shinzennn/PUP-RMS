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

        // SEARCH FACULTY
        public static DataTable SearchFaculty(string searchTerm)
        {
            // CREATE DATATABLE TO HOLD RESULTS
            DataTable dt = new DataTable();

            //STORED PROCEDURE NAME
            string procedureName = "sp_SearchFaculty";

            // ADD PARAMETERS
            DbControl.AddParameter("@SearchTerm", searchTerm, SqlDbType.VarChar);
            //DbControl.AddParameter("@ProgramID", programID, SqlDbType.Int);

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

    }
}
