using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using PUP_RMS.Model;

namespace PUP_RMS.Core
{
    public static class DbControl
    {
        // THIS IS A HELPER METHOD TO FETCH THE CONNECTION STRING FROM App.config
        public static string ConnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        // DITO NIYO LAGAY LAHAT NG QUERIES NYO PARA ICALL NA LANG SA IBANG PARTS NG PROGRAM

        public static List<Course> GetCourses()
        {
            using (IDbConnection conn = new SqlConnection(ConnString("RMSDB")))
            {
                return conn.Query<Course>(
                    "SELECT CourseID, CourseCode, CourseDecription FROM Course"
                ).ToList();
            }
        }

        public static List<Professor> GetProfessors()
        {
            using (IDbConnection conn = new SqlConnection(ConnString("RMSDB")))
            {
                return conn.Query<Professor>(
                    @"SELECT ProfessorID,
              FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName AS FullName
              FROM Professor"
                ).ToList();
            }
        }

        public static bool InsertGradeSheet(
                    string filename,
                    string schoolYear,
                    int semester,
                    int courseId,
                    int professorId,
                    int adminId
                )
        {
            using (IDbConnection conn = new SqlConnection(ConnString("RMSDB")))
            {
                string sql = @"INSERT INTO GradeSheet
                       (Filename, SchoolYear, Semester, CourseID, ProfessorID, AdminID)
                       VALUES
                       (@Filename, @SchoolYear, @Semester, @CourseID, @ProfessorID, @AdminID)";

                int rows = conn.Execute(sql, new
                {
                    Filename = filename,
                    SchoolYear = schoolYear,
                    Semester = semester,
                    CourseID = courseId,
                    ProfessorID = professorId,
                    AdminID = adminId
                });

                return rows > 0;
            }
        }


        public static bool DeleteGradeSheetByFilename(string filename)
        {
            using (IDbConnection conn = new SqlConnection(ConnString("RMSDB")))
            {
                string sql = @"DELETE FROM GradeSheet
                       WHERE Filename = @Filename";

                int rows = conn.Execute(sql, new
                {
                    Filename = filename
                });

                return rows > 0;
            }
        }


        // THIS IS DAPPER METHOD
        public static Admin GetAdmin(string username, string password)
        {
            using (IDbConnection conn = new SqlConnection(ConnString("RMSDB")))
            {
                var result = conn.QueryFirstOrDefault<Admin>("SELECT * FROM Admin WHERE Username = @Username AND Password = @Password", new { Username = username, Password = password });
                return result;
            }
        }

        // THIS IS ADO.NET METHOD
        // Method to GET data (for Login and Search)
        public static DataTable GetData(string query)
        {
            using (SqlConnection con = new SqlConnection(ConnString("RMSDB")))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        // If connection fails, this will tell you why
                        System.Windows.Forms.MessageBox.Show("DB Error: " + ex.Message);
                    }
                    return dt;
                }
            }
        }

        // Method to SAVE/MODIFY data (INSERT, UPDATE, DELETE)
        public static bool SetData(string query)
        {
            using (SqlConnection con = new SqlConnection(ConnString("RMSDB")))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        // ExecuteNonQuery returns the number of rows affected.
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // If at least 1 row was affected, the command was successful.
                        return rowsAffected >= 1;
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("DB Error (SetData): " + ex.Message);
                        return false; // Return false on error
                    }
                }
            }
        }

    }
}
