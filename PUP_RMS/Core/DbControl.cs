using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
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
                    "SELECT CourseID, CourseCode, CourseDescription FROM Course"
                ).ToList();
            }
        }

        public static List<Faculty> GetProfessors()
        {
            using (IDbConnection conn = new SqlConnection(ConnString("RMSDB")))
            {
                return conn.Query<Faculty>(@"
            SELECT 
                FacultyID, 
                Initials, -- Add this here
                UPPER(LastName) + ', ' + UPPER(FirstName) + ' ' + 
                ISNULL(UPPER(MiddleName), '') AS DisplayName
            FROM Faculty
            ORDER BY LastName, FirstName"
                ).ToList();
            }
        }


        public static List<Programs> GetPrograms()
        {
            using (IDbConnection conn = new SqlConnection(ConnString("RMSDB")))
            {
                return conn.Query<Programs>(
                    "SELECT ProgramID, ProgramCode FROM Program"
                ).ToList();
            }
        }


        public static int InsertGradeSheet(
            string filename,
            string filepath,
            string schoolYear,
            int semester,
            int programId,
            int yearLevel,
            int courseId,
            int facultyId,
            int pageNumber,
            int accountId
)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(ConnString("RMSDB")))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Filename", filename);
                    parameters.Add("@Filepath", filepath);
                    parameters.Add("@SchoolYear", schoolYear);
                    parameters.Add("@Semester", semester);
                    parameters.Add("@ProgramID", programId);
                    parameters.Add("@YearLevel", yearLevel);
                    parameters.Add("@CourseID", courseId);
                    parameters.Add("@FacultyID", facultyId);
                    parameters.Add("@PageNumber", pageNumber);
                    parameters.Add("@AccountID", accountId);

                    // QuerySingle<int> expects the stored procedure to return the ID
                    return conn.QuerySingle<int>(
                        "sp_InsertGradeSheet",
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );
                }
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                // Duplicate key / unique constraint violation
                return -1;
            }
        }

        public static bool DeleteGradeSheet(int gradeSheetId)
        {
            using (IDbConnection conn = new SqlConnection(ConnString("RMSDB")))
            {
                int rowsAffected = conn.Execute(
                    "sp_DeleteGradeSheet",
                    new { GradeSheetID = gradeSheetId },
                    commandType: CommandType.StoredProcedure
                );

                return rowsAffected > 0;
            }
        }




        // THIS IS DAPPER METHOD
        public static Account GetAdmin(string username, string password)
        {
            using (IDbConnection conn = new SqlConnection(ConnString("RMSDB")))
            {
                var result = conn.QueryFirstOrDefault<Account>("SELECT * FROM Account WHERE Username = @Username AND Password = @Password", new { Username = username, Password = password });
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



        // ANOTHER METHOD
        public static List<SqlParameter> sqlParameters = new List<SqlParameter>();

        // USED THIS TO ADD PARAMETERS TO THE LIST
        public static void AddParameter(string name, object value, SqlDbType dbType)
        {
            SqlParameter param = new SqlParameter
            {
                ParameterName = name,
                SqlDbType = dbType,
                Value = value ?? DBNull.Value
            };
            sqlParameters.Add(param);
        }

        // Used for INSERT, UPDATE, DELETE
        public static int ExecuteNonQuery(string procedureName)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = new SqlConnection(ConnString("RMSDB")))
            {
                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (sqlParameters != null)
                    {
                        cmd.Parameters.AddRange(sqlParameters.ToArray());
                    }

                    try
                    {
                        conn.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        // Catch SQL specific errors (like RAISERROR or Constraint violations)
                        MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        // Catch general C# errors
                        MessageBox.Show("General Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            sqlParameters.Clear();
                            conn.Close();
                        }
                    }
                }
            return rowsAffected;
            }
        }

        // Used for SELECT (Get All, Search)
        public static DataTable ExecuteQuery(string procedureName)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnString("RMSDB")))
            {
                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (sqlParameters != null)
                    {
                        cmd.Parameters.AddRange(sqlParameters.ToArray());
                    }

                    try
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Query Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            sqlParameters.Clear();
            return dt;
        }

        public static void ClearParameters()
        {
            sqlParameters.Clear();
        }

        // Method to get a single value (Count, ID, Name, etc.)
        // ADD THIS TO DbControl.cs
        public static int ExecuteScalar(string procedureName)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(ConnString("RMSDB")))
            {
                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // This allows us to reuse your existing parameter logic
                    if (sqlParameters != null)
                    {
                        cmd.Parameters.AddRange(sqlParameters.ToArray());
                    }

                    try
                    {
                        conn.Open();
                        // ExecuteScalar grabs the top-left value (the count) from the result
                        object returnVal = cmd.ExecuteScalar();

                        if (returnVal != null)
                        {
                            result = Convert.ToInt32(returnVal);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            // Always clear parameters after use
            sqlParameters.Clear();
            return result;
        }

    }
}
