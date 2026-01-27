using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Tesseract;

namespace PUP_RMS.Helper
{
    public class GradeSheetTemplate
    {
        public TemplateResolution template_resolution { get; set; }
        public Dictionary<string, FieldDefinition> fields { get; set; }
    }

    public class TemplateResolution
    {
        public int width { get; set; }
        public int height { get; set; }
    }

    public class FieldDefinition
    {
        public string label { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class OCRResult
    {
        public string course_code { get; set; }
        public string professor_name { get; set; }
        public string semester { get; set; }
        public string school_year { get; set; }
        public string program_code { get; set; }
        public string year_level { get; set; }
    }

    public static class OCRHelper
    {
        private static readonly string tessdataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tessdata");

        public static OCRResult ExtractGradeSheetMetadata(string imagePath, GradeSheetTemplate template)
        {
            var result = new OCRResult();
            
            try
            {
                // Check if tessdata directory exists
                if (!Directory.Exists(tessdataPath))
                {
                    Directory.CreateDirectory(tessdataPath);
                }

                // Check if eng.traineddata exists
                string trainedDataPath = Path.Combine(tessdataPath, "eng.traineddata");
                if (!File.Exists(trainedDataPath))
                {
                    throw new FileNotFoundException(
                        $"Tesseract English language data not found at: {trainedDataPath}\n\n" +
                        "Please download 'eng.traineddata' from: https://github.com/tesseract-ocr/tessdata/raw/main/eng.traineddata\n" +
                        $"And copy it to: {tessdataPath}");
                }

                using (var engine = new TesseractEngine(tessdataPath, "eng", EngineMode.Default))
                using (var img = Pix.LoadFromFile(imagePath))
                {
                    using (var page = engine.Process(img))
                    {
                        // For simplicity, process the entire image and extract all text
                        string fullText = page.GetText().Trim();
                        
                        // Extract specific fields from the full text based on template
                        result = ExtractFieldsFromFullText(fullText, template);
                    }
                }
            }
            catch (FileNotFoundException fnfEx)
            {
                // Specific handling for missing tessdata
                throw new Exception($"OCR cannot initialize: {fnfEx.Message}", fnfEx);
            }
            catch (Exception ex)
            {
                // General OCR processing failure
                throw new Exception($"OCR processing failed: {ex.Message}", ex);
            }

            return result;
        }

        private static OCRResult ExtractFieldsFromFullText(string fullText, GradeSheetTemplate template)
        {
            var result = new OCRResult();
            
            if (string.IsNullOrWhiteSpace(fullText))
                return result;
            
            // Split text into lines for processing
            var lines = fullText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var line in lines)
            {
                var cleanedLine = CleanExtractedText(line.Trim());
                
                // Try to match fields based on known patterns and positions
                if (string.IsNullOrWhiteSpace(cleanedLine))
                    continue;
                
                // Simple heuristic matching - can be improved with regex
                // School year pattern (e.g., "2024-2025")
                if (Regex.IsMatch(cleanedLine, @"\d{4}-\d{4}"))
                {
                    result.school_year = cleanedLine;
                }
                // Course code pattern (e.g., "COMP 001")
                else if (Regex.IsMatch(cleanedLine, @"[A-Z]{3,4}\s*\d{3,4}"))
                {
                    result.course_code = cleanedLine;
                }
                // Program code pattern (e.g., "BSIT-LQ")
                else if (Regex.IsMatch(cleanedLine, @"[A-Z]{3,5}-[A-Z]{1,2}"))
                {
                    result.program_code = cleanedLine;
                }
                // Semester pattern
                else if (cleanedLine.ToLower().Contains("semester") || cleanedLine.ToLower().Contains("1st") || 
                         cleanedLine.ToLower().Contains("2nd") || cleanedLine.ToLower().Contains("summer"))
                {
                    result.semester = cleanedLine;
                }
                // Year level pattern
                else if (cleanedLine.ToLower().Contains("year") || cleanedLine.Contains("1st") || 
                         cleanedLine.Contains("2nd") || cleanedLine.Contains("3rd") || cleanedLine.Contains("4th"))
                {
                    result.year_level = cleanedLine;
                }
                // Professor name (assume it contains alphabetic characters and might have commas)
                else if (Regex.IsMatch(cleanedLine, @"[A-Za-z\s,]+") && cleanedLine.Length > 5)
                {
                    result.professor_name = cleanedLine;
                }
            }
            
            return result;
        }

        private static string CleanExtractedText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            // Remove extra spaces and special characters
            text = System.Text.RegularExpressions.Regex.Replace(text, @"\s+", " ");
            text = text.Trim();
            
            // Remove common OCR artifacts
            text = text.Replace("|", "I").Replace("0", "O").Replace("1", "I").Replace("5", "S");
            
            return text;
        }

        public static GradeSheetTemplate LoadTemplateFromJson(string jsonPath)
        {
            try
            {
                string json = File.ReadAllText(jsonPath);
                return SimpleJsonSerializer.Deserialize<GradeSheetTemplate>(json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to load template from {jsonPath}: {ex.Message}", ex);
            }
        }

        public static int? ParseSemester(string semesterText)
        {
            if (string.IsNullOrWhiteSpace(semesterText))
                return null;

            semesterText = semesterText.ToLower().Trim();
            
            if (semesterText.Contains("1st") || semesterText.Contains("first") || semesterText.Contains("a"))
                return 1;
            if (semesterText.Contains("2nd") || semesterText.Contains("second") || semesterText.Contains("b"))
                return 2;
            if (semesterText.Contains("summer") || semesterText.Contains("c"))
                return 3;
            
            return null;
        }

        public static int? ParseYearLevel(string yearLevelText)
        {
            if (string.IsNullOrWhiteSpace(yearLevelText))
                return null;

            yearLevelText = yearLevelText.ToLower().Trim();
            
            if (yearLevelText.Contains("1st") || yearLevelText.Contains("first") || yearLevelText.Contains("1"))
                return 1;
            if (yearLevelText.Contains("2nd") || yearLevelText.Contains("second") || yearLevelText.Contains("2"))
                return 2;
            if (yearLevelText.Contains("3rd") || yearLevelText.Contains("third") || yearLevelText.Contains("3"))
                return 3;
            if (yearLevelText.Contains("4th") || yearLevelText.Contains("fourth") || yearLevelText.Contains("4"))
                return 4;
            
            return null;
        }

        public static bool IsTesseractDataAvailable()
        {
            string trainedDataPath = Path.Combine(tessdataPath, "eng.traineddata");
            return File.Exists(trainedDataPath);
        }


    }
}