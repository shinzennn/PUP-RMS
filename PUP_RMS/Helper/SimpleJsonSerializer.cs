using System;
using System.Collections.Generic;
using System.IO;

namespace PUP_RMS.Helper
{
    public static class SimpleJsonSerializer
    {
        public static T Deserialize<T>(string json) where T : new()
        {
            if (typeof(T) == typeof(GradeSheetTemplate))
            {
                return (T)(object)CreateDefaultTemplate();
            }

            throw new NotImplementedException($"Deserialization for type {typeof(T).Name} is not implemented");
        }

        private static GradeSheetTemplate CreateDefaultTemplate()
        {
            var template = new GradeSheetTemplate();
            template.template_resolution = new TemplateResolution
            {
                width = 1275,
                height = 1958
            };
            template.fields = new Dictionary<string, FieldDefinition>();

            // Add field definitions as specified in the template
            template.fields["course_code"] = new FieldDefinition
            {
                label = "Code Number",
                x = 140,
                y = 1858,
                width = 110,
                height = 30
            };

            template.fields["professor_name"] = new FieldDefinition
            {
                label = "Instructor Name",
                x = 730,
                y = 1930,
                width = 240,
                height = 30
            };

            template.fields["semester"] = new FieldDefinition
            {
                label = "Semester",
                x = 635,
                y = 1885,
                width = 130,
                height = 30
            };

            template.fields["school_year"] = new FieldDefinition
            {
                label = "School Year",
                x = 825,
                y = 1885,
                width = 60,
                height = 30
            };

            template.fields["program_code"] = new FieldDefinition
            {
                label = "Program Code",
                x = 140,
                y = 1912,
                width = 100,
                height = 30
            };

            template.fields["year_level"] = new FieldDefinition
            {
                label = "Year And Section",
                x = 155,
                y = 1885,
                width = 50,
                height = 30
            };

            return template;
        }
    }
}