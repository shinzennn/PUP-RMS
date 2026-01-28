using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PUP_RMS.Core;
using PUP_RMS.Model;

namespace PUP_RMS.Helper
{
    public static class CourseHelper
    {
        public static DataTable GetAllCourse()
        {

            DataTable dt = new DataTable();
            dt = DbControl.ExecuteQuery("sp_GetAllCourseDescription");
            return dt;
        }

        public static DataTable GetAllCoursePerDescription(string courseDesc)
        {
            DataTable dt = new DataTable();

            DbControl.AddParameter("@CourseDescription", courseDesc, SqlDbType.VarChar);
            dt = DbControl.ExecuteQuery("sp_GetAllCourseCodePerDescription");

            return dt;
        }

        // CREATE COURSE
        public static void CreateCourse(Course course)
        {
            string procedureName = "sp_CreateCourse";

            try
            {
                // Clear previous parameters
                DbControl.ClearParameters();

                // Add parameters
                DbControl.AddParameter("@CourseCode", course.CourseCode, SqlDbType.VarChar);
                DbControl.AddParameter("@CourseDescription", course.CourseDescription, SqlDbType.VarChar);
                


                // Success message
                int rowsAffected = DbControl.ExecuteNonQuery(procedureName);

                if (rowsAffected > 0)
                {
                    MessageBox.Show(
                        "Course created successfully.",
                        "Record Created Successfully",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                    );
                    //Log Activity
                    ActivityLogger.LogCourseAddition(course.CourseCode, course.CourseDescription);
                }
            }
            catch (SqlException ex)
            {
                // Show the message returned by the database
                MessageBox.Show(
                    ex.Message,
                    "Database Message",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unexpected error occurred.\n" + ex.Message,
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }


        // UPDATE COURSE
        public static void UpdateCourse(Course course)
        {
            string procedureName = "sp_UpdateCourse";

            try
            {
                // Clear previous parameters
                DbControl.ClearParameters();

                // Add parameters
                DbControl.AddParameter("@CourseID", course.CourseID, SqlDbType.Int);
                DbControl.AddParameter("@CourseCode", course.CourseCode, SqlDbType.VarChar);
                DbControl.AddParameter("@CourseDescription", course.CourseDescription, SqlDbType.VarChar);
                

                // Execute stored procedure
                int rowsAffected = DbControl.ExecuteNonQuery(procedureName);

                if (rowsAffected > 0)
                {
                    MessageBox.Show(
                        "Course updated successfully.",
                        "Record Updated Successfully",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                    );

                    // Log activity only if update succeeded
                    ActivityLogger.LogCourseModification(course.CourseID, course.CourseCode, course.CourseDescription);
                }
                else
                {
                    MessageBox.Show(
                        "No changes were made to the course.",
                        "Update Info",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                    );
                }
            }
            catch (SqlException ex)
            {
                // Display the database message from RAISERROR
                MessageBox.Show(
                    ex.Message,
                    "Database Message",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unexpected error occurred.\n" + ex.Message,
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        // SEARCH COURSE
        public static DataTable SearchCourse(string searchTerm)
        {
            // CREATE DATATABLE TO HOLD RESULTS
            DataTable dt = new DataTable();

            //STORED PROCEDURE NAME
            string procedureName = "sp_SearchCourse";

            // ADD PARAMETERS
            DbControl.AddParameter("@SearchTerm", searchTerm, SqlDbType.VarChar);


            // EXECUTE QUERY AND CLEAR PARAMETERS
            dt = DbControl.ExecuteQuery(procedureName);

            return dt;
        }
    }


}