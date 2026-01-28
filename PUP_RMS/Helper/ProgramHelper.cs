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
    public static class ProgramHelper
    {
        public static DataTable GetAllProgram()
        {

            DataTable dt = new DataTable();
            dt = DbControl.ExecuteQuery("sp_GetAllProgram");
            return dt;
        }

        public static DataTable GetProgramByCurriculum(string curriculumYear = null)
        {
            DataTable dt = new DataTable();
            DbControl.AddParameter("@CurriculumYear", curriculumYear, SqlDbType.VarChar);
            dt = DbControl.ExecuteQuery("sp_GetProgramsByCurriculumYear");

            return dt;
        }

        // CREATE Program
        public static void CreatProgram(Programs program)
        {
            // STORED PROCEDURE NAME
            string procedureName = "sp_CreateProgram";

            // ADD PARAMETERS
            DbControl.AddParameter("@ProgramCode", program.ProgramCode, SqlDbType.VarChar);
            DbControl.AddParameter("@ProgramDescription", program.ProgramDescription, SqlDbType.VarChar);



            // EXECUTE NON QUERY AND CLEAR PARAMETERS
            if (DbControl.ExecuteNonQuery(procedureName) >= 1)
            {
                MessageBox.Show("Program created successfully.", "Record Created Successfully.", MessageBoxButton.OK, MessageBoxImage.Information);

                // LOG ACTIVITY wala pang activity logger
                /*ActivityLogger.LogFacultyAddition(faculty.FirstName + " " + faculty.LastName);*/
            }
            else
            {
                MessageBox.Show("Failed to create faculty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static void UpdateProgram(Programs program)
        {
            // STORED PROCEDURE NAME
            string procedureName = "sp_UpdateProgram";

            // ADD PARAMETERS
            DbControl.AddParameter("@ProgramID", program.ProgramID, SqlDbType.Int);
            DbControl.AddParameter("@ProgramCode", program.ProgramCode, SqlDbType.VarChar);
            DbControl.AddParameter("@ProgramDescription", program.ProgramDescription, SqlDbType.VarChar);


            // EXECUTE NON QUERY AND CLEAR PARAMETERS
            if (DbControl.ExecuteNonQuery(procedureName) >= 1)
            {
                MessageBox.Show("Program updated successfully.", "Record Created Successfully.", MessageBoxButton.OK, MessageBoxImage.Information);

                // LOG ACTIVITY wala pang activity logger
                // ActivityLogger.LogFacultyAddition(faculty.FirstName + " " + faculty.LastName);
            }
            else
            {
                MessageBox.Show("Failed to update faculty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public static DataTable SearchProgram(string searchTerm, string curriculumYear)
        {
            // CREATE DATATABLE TO HOLD RESULTS
            DataTable dt = new DataTable();

            //STORED PROCEDURE NAME
            string procedureName = "sp_SearchProgram";

            // ADD PARAMETERS
            DbControl.AddParameter("@SearchTerm", searchTerm, SqlDbType.VarChar);
            DbControl.AddParameter("@CurriculumYear", curriculumYear, SqlDbType.VarChar);


            // EXECUTE QUERY AND CLEAR PARAMETERS
            dt = DbControl.ExecuteQuery(procedureName);

            return dt;
        }
    }
}
