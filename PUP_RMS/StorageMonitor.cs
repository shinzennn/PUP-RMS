using System;
using System.IO;

public class StorageMonitor
{
    // Configure the drive letter where your application or data is stored.
    private const string TargetDrive = "C:\\";

    /// <summary>
    /// Queries the hard drive capacity and calculates usage metrics.
    /// </summary>
    public (double UsagePercent, long UsedBytes, long TotalBytes) GetDriveUsage()
    {
        try
        {
            DriveInfo drive = new DriveInfo(TargetDrive);

            if (drive.IsReady)
            {
                long totalBytes = drive.TotalSize;
                long freeBytes = drive.AvailableFreeSpace;
                long usedBytes = totalBytes - freeBytes;

                double usageRatio = (double)usedBytes / totalBytes;
                double usagePercent = usageRatio * 100.0;

                return (usagePercent, usedBytes, totalBytes);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting drive info for {TargetDrive}: {ex.Message}");
        }

        // Return a zero state if the drive is not ready or an error occurred
        return (0.0, 0, 0);
    }

    /// <summary>
    /// Converts a byte count into a readable string (e.g., 5.12 GB).
    /// </summary>
    public static string FormatBytes(long bytes)
    {
        string[] suffix = { "B", "KB", "MB", "GB", "TB" };
        int i = 0;
        double dblBytes = bytes;

        while (dblBytes >= 1024 && i < suffix.Length - 1)
        {
            dblBytes /= 1024;
            i++;
        }

        return $"{dblBytes:0.##} {suffix[i]}";
    }
}