using PUP_RMS.Core;
using PUP_RMS.Forms;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PUP_RMS.Helper
{
    public static class ActivityLogger
    {
        public static void LogActivity(int account_id, string activityDescription)
        {
            DateTime date = DateTime.Now;
            string query = $"INSERT INTO ActivityLog (AccountID, ActivityDescription, ActivityDate) " +
                           $"VALUES ({account_id}, '{activityDescription}', '{date}')";
            bool success = DbControl.SetData(query);
            if (!success)
            {
                MessageBox.Show("Failed to log activity.");
            }
        }
        
        public static void LogUserLogin()
        {
            int account_id = MainDashboard.CurrentAccount.AccountID;
            string username = MainDashboard.CurrentAccount.Username;
            string description = $"User {username} - ID:{account_id} logged in.";
            
            LogActivity(account_id, description);
        }

        // GRADESHEET ACTIVITY LOGGING
        public static void LogGradesheetUpload(string schoolYear, string semester, string courseCode, string professor)
        {
            int account_id = MainDashboard.CurrentAccount.AccountID;
            string username = MainDashboard.CurrentAccount.Username;
            string description = $"User {username} uploaded gradesheet for {schoolYear} - {semester}, {courseCode}, {professor}.";
            
            LogActivity(account_id, description);
        }

        public static void LogGradesheetModification(int gradesheetID, string schoolYear, string semester, string courseCode, string professor)
        {
            int account_id = MainDashboard.CurrentAccount.AccountID;
            string username = MainDashboard.CurrentAccount.Username;
            string description = $"User {username} modified gradesheet id: {gradesheetID} to {schoolYear} - {semester}, {courseCode}, {professor}.";
            
            LogActivity(account_id, description);
        }

        public static void LogGradesheetDeletion(string schoolYear, string semester, string courseCode, string professor)
        {
            int account_id = MainDashboard.CurrentAccount.AccountID;
            string username = MainDashboard.CurrentAccount.Username;
            string description = $"User {username} deleted gradesheet for {schoolYear} - {semester}, {courseCode}, {professor}.";
            
            LogActivity(account_id, description);
        }

        // COURSE ACTIVITY LOGGING
        public static void LogCourseAddition(string courseCode, string courseDescription)
        {
            int account_id = MainDashboard.CurrentAccount.AccountID;
            string username = MainDashboard.CurrentAccount.Username;
            string description = $"User {username} added course {courseCode} - {courseDescription}.";
            
            LogActivity(account_id, description);
        }

        public static void LogCourseModification(string courseID, string courseCode, string courseDescription)
        {
            int account_id = MainDashboard.CurrentAccount.AccountID;
            string username = MainDashboard.CurrentAccount.Username;
            string description = $"User {username} modified course id: {courseID} to {courseCode} - {courseDescription}.";
            
            LogActivity(account_id, description);
        }

        public static void LogCourseDeletion(string courseCode, string courseDescription)
        {
            int account_id = MainDashboard.CurrentAccount.AccountID;
            string username = MainDashboard.CurrentAccount.Username;
            string description = $"User {username} deleted course {courseCode} - {courseDescription}.";
            
            LogActivity(account_id, description);
        }

        // PROFESSOR ACTIVITY LOGGING
        public static void LogProfessorAddition(string professorName)
        {
            int account_id = MainDashboard.CurrentAccount.AccountID;
            string username = MainDashboard.CurrentAccount.Username;
            string description = $"User {username} added professor {professorName}.";
            
            LogActivity(account_id, description);
        }
        public static void LogProfessorModification(string professorID, string professorName)
        {
            int account_id = MainDashboard.CurrentAccount.AccountID;
            string username = MainDashboard.CurrentAccount.Username;
            string description = $"User {username} modified professor id: {professorID} to {professorName}.";
            
            LogActivity(account_id, description);
        }
        public static void LogProfessorDeletion(string professorName)
        {
            int account_id = MainDashboard.CurrentAccount.AccountID;
            string username = MainDashboard.CurrentAccount.Username;
            string description = $"User {username} deleted professor {professorName}.";
            
            LogActivity(account_id, description);
        }

    }
}
