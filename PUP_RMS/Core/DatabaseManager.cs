using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PUP_RMS.Core
{
    /// <summary>
    /// DatabaseManager - Handles RMSDB initialization with progress reporting
    /// 
    /// Usage:
    ///   In Program.cs Main():
    ///   var setupForm = new DatabaseSetupForm();
    ///   setupForm.ShowDialog();
    /// </summary>
    public static class DatabaseManager
    {
        // Connection to master database (for creating RMSDB)
        private static string MasterConnection =>
            "Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=True;";

        // Connection to application database (read from config)
        public static string AppConnection => GetConnectionString();

        // Logging
        private static string LogFilePath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "RMSDB_App", "DatabaseSetup.log");

        /// <summary>
        /// Initialize database on application startup
        /// Call this in App.xaml.cs before showing main window
        /// </summary>
        public static void InitializeDatabase()
        {
            try
            {
                Log("=== Database Initialization Started ===");
                Log($"Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

                // Step 1: Validate SQL Server connectivity
                Log("Step 1: Checking SQL Server connectivity...");
                if (!CanConnectToSqlServer())
                {
                    throw new Exception(
                        "Cannot connect to SQL Server.\n\n" +
                        "Please ensure SQL Server (localdb)\\MSSQLLocalDB is installed and running.");
                }
                Log("✓ SQL Server is accessible");

                // Step 2: Check if database exists
                Log("Step 2: Checking if RMSDB exists...");
                if (!CheckDatabaseExists())
                {
                    Log("Database not found. Creating...");
                    ExecuteScript(message => Log($"  {message}"));
                    Log("✓ Database created successfully");
                }
                else
                {
                    Log("✓ Database already exists");
                }

                // Step 3: Verify database is healthy
                Log("Step 3: Verifying database health...");
                if (!VerifyDatabaseHealth())
                {
                    throw new Exception("Database exists but is not responding correctly");
                }
                Log("✓ Database is healthy");

                Log("=== Database Initialization Completed Successfully ===\n");
                MessageBox.Show(
                    "Database setup completed successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log($"❌ ERROR: {ex.Message}");
                Log($"Stack Trace: {ex.StackTrace}");

                MessageBox.Show(
                    $"Database Setup Failed:\n\n{ex.Message}\n\n" +
                    $"Check log file: {LogFilePath}",
                    "Critical Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Environment.Exit(1);
            }
        }

        /// <summary>
        /// Check if SQL Server (localdb) is running and accessible
        /// </summary>
        private static bool CanConnectToSqlServer()
        {
            try
            {
                using (var conn = new SqlConnection(MasterConnection))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("SELECT 1", conn))
                    {
                        cmd.CommandTimeout = 5;
                        cmd.ExecuteScalar();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log($"SQL Server connection failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Check if RMSDB database exists
        /// </summary>
        private static bool CheckDatabaseExists()
        {
            try
            {
                using (var conn = new SqlConnection(MasterConnection))
                {
                    conn.Open();
                    string query = "SELECT database_id FROM sys.databases WHERE Name = 'RMSDB'";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = 5;
                        return (cmd.ExecuteScalar() != null);
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"Error checking database existence: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verify database is healthy and accessible
        /// </summary>
        private static bool VerifyDatabaseHealth()
        {
            try
            {
                using (var conn = new SqlConnection(AppConnection))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM sys.tables", conn))
                    {
                        cmd.CommandTimeout = 5;
                        cmd.ExecuteScalar();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log($"Database health check failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Execute SQL script file, splitting by GO batches
        /// </summary>
        private static void ExecuteScript(Action<string> progressCallback = null)
        {
            // Get script path
            string scriptPath = GetScriptPath();
            Log($"Script Path: {scriptPath}");

            if (!File.Exists(scriptPath))
            {
                throw new FileNotFoundException($"Database script not found: {scriptPath}");
            }

            // Read script
            progressCallback?.Invoke("Reading database script...");
            string scriptContent = File.ReadAllText(scriptPath);

            if (string.IsNullOrWhiteSpace(scriptContent))
            {
                throw new InvalidOperationException("Database script is empty");
            }

            // Validate script content
            if (!scriptContent.Contains("CREATE DATABASE") &&
                !scriptContent.Contains("CREATE TABLE") &&
                !scriptContent.Contains("CREATE PROCEDURE"))
            {
                throw new InvalidOperationException(
                    "Script doesn't appear to be a valid database script");
            }

            // Split by GO batches
            string[] commands = Regex.Split(
                scriptContent,
                @"^\s*GO\s*$",
                RegexOptions.Multiline | RegexOptions.IgnoreCase);

            Log($"Script contains {commands.Length} batches");
            progressCallback?.Invoke($"Found {commands.Length} SQL commands");

            // Execute each batch
            using (var conn = new SqlConnection(MasterConnection))
            {
                conn.Open();
                int completed = 0;
                int total = 0;

                // Count non-empty commands
                foreach (var cmd in commands)
                {
                    if (!string.IsNullOrWhiteSpace(cmd))
                        total++;
                }

                foreach (var commandText in commands)
                {
                    if (string.IsNullOrWhiteSpace(commandText))
                        continue;

                    try
                    {
                        completed++;
                        progressCallback?.Invoke(
                            $"Executing command {completed}/{total}...");
                        Log($"Executing batch {completed}/{total}");

                        using (var cmd = new SqlCommand(commandText, conn))
                        {
                            cmd.CommandTimeout = 300;  // 5 minutes per command
                            cmd.ExecuteNonQuery();
                        }

                        Log($"✓ Batch {completed} completed");
                    }
                    catch (SqlException sqlEx)
                    {
                        throw new Exception(
                            $"SQL Error in batch {completed}: {sqlEx.Message}\n\n" +
                            $"Script snippet:\n{commandText.Substring(0, Math.Min(500, commandText.Length))}...",
                            sqlEx);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(
                            $"Error in batch {completed}: {ex.Message}",
                            ex);
                    }
                }
            }

            Log("✓ All batches executed successfully");
        }

        /// <summary>
        /// Find SQL script in application directory
        /// Tries multiple locations for flexibility
        /// </summary>
        private static string GetScriptPath()
        {
            // Try multiple possible locations
            string[] possiblePaths = new[]
            {
            // Look in DatabaseScripts folder first (organized approach)
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatabaseScripts", "001_CreateDatabase.sql"),
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatabaseScripts", "RMSDB.sql"),
            
            // Look in root directory (simple approach)
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RMSDB_SQLQuery.sql"),
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RMSDB.sql"),
            
            // Look in AppData (if installed)
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "RMSDB_App", "RMSDB_SQLQuery.sql")
        };

            foreach (var path in possiblePaths)
            {
                if (File.Exists(path))
                {
                    Log($"Found script at: {path}");
                    return path;
                }
            }

            throw new FileNotFoundException(
                $"Database script not found.\n\n" +
                $"Searched locations:\n" +
                string.Join("\n", possiblePaths));
        }

        /// <summary>
        /// Get application connection string from config
        /// Falls back to hardcoded default if not found in config
        /// </summary>
        private static string GetConnectionString()
        {
            try
            {
                // Try to read from app.config
                var config = ConfigurationManager.ConnectionStrings["RMSDB"];

                if (config != null && !string.IsNullOrEmpty(config.ConnectionString))
                {
                    Log($"Using connection string from config");
                    return config.ConnectionString;
                }

                // Fall back to default
                Log("Warning: Connection string not found in config, using default");
                return "Server=(localdb)\\MSSQLLocalDB;Database=RMSDB;Integrated Security=True;";
            }
            catch (Exception ex)
            {
                Log($"Error reading connection string: {ex.Message}");
                return "Server=(localdb)\\MSSQLLocalDB;Database=RMSDB;Integrated Security=True;";
            }
        }

        /// <summary>
        /// Log message to file
        /// Creates AppData\RMSDB_App\DatabaseSetup.log
        /// </summary>
        private static void Log(string message)
        {
            try
            {
                string dir = Path.GetDirectoryName(LogFilePath);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
                File.AppendAllText(LogFilePath, logMessage + Environment.NewLine);

                // Also write to debug output
                System.Diagnostics.Debug.WriteLine(logMessage);
            }
            catch
            {
                // Silently fail if logging fails
            }
        }

        /// <summary>
        /// Get the path to the log file
        /// Useful for showing to user after errors
        /// </summary>
        public static string GetLogPath() => LogFilePath;
    }
}