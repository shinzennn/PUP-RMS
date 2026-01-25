using PUP_RMS.Core;
using PUP_RMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PUP_RMS.Helper
{
    public static class AccountHelper
    {
        // GET ALL ACCOUNT
        public static DataTable GetAllAccount()
        {
            DataTable dt = new DataTable();
            dt = DbControl.ExecuteQuery("sp_GetAllAccount");
            return dt;
        }

        // CREATE ACCOUNT
        public static void CreateAccount(Account account) 
        {
            // STORE PROCEDURE NAME
            string procedureName = "sp_CreateAccount";

            // ADD PARAMETERS
            DbControl.AddParameter("@FirstName", account.FirstName, SqlDbType.VarChar);
            DbControl.AddParameter("@LastName", account.LastName, SqlDbType.VarChar);
            DbControl.AddParameter("@Username", account.Username, SqlDbType.VarChar);
            DbControl.AddParameter("@Password", account.Password, SqlDbType.VarChar);
            DbControl.AddParameter("@AccountType", account.AccountType, SqlDbType.VarChar);

            // EXECUTE QUERY AND CLEAR PARAMETERS
            if (DbControl.ExecuteNonQuery(procedureName) >= 1)
            {
                MessageBox.Show("Account created successfully.", "Record Created Successfully.", MessageBoxButton.OK, MessageBoxImage.Information);

                // LOG ACTIVITY
                ActivityLogger.LogAccountRegistration(account.Username);
            }
            else
            {
                MessageBox.Show("Failed to create faculty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // UPDATE ACCOUNT
        public static void UpdateAccount(Account account) 
        {
            // STORE PROCEDURE NAME
            string procedureName = "sp_UpdateAccount";

            // ADD PARAMETERS
            DbControl.AddParameter("@AccountID", account.AccountID, SqlDbType.Int);
            DbControl.AddParameter("@FirstName", account.FirstName, SqlDbType.VarChar);
            DbControl.AddParameter("@LastName", account.LastName, SqlDbType.VarChar);
            DbControl.AddParameter("@Username", account.Username, SqlDbType.VarChar);
            DbControl.AddParameter("@Password", account.Password, SqlDbType.VarChar);
            DbControl.AddParameter("@AccountType", account.AccountType, SqlDbType.VarChar);

            // EXECUTE QUERY AND CLEAR PARAMETERS
            if (DbControl.ExecuteNonQuery(procedureName) >= 1)
            {
                MessageBox.Show("Account updated successfully.", "Record Updated Successfully.", MessageBoxButton.OK, MessageBoxImage.Information);

                // LOG ACTIVITY
                ActivityLogger.AccountModification(account.AccountID,account.FirstName +" "+ account.LastName);
            }
            else
            {
                MessageBox.Show("Failed to update faculty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
