using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUP_RMS.Model
{
    public  class GradeSheet
    {
        public int GradeSheetID { get; set; }
        public string Filename { get; set; }
        public string Filepath { get; set; }
        public string SchoolYear { get; set; }
        public string Semester { get; set; }
        public int ProgramID { get; set; }
        public int YearLevel { get; set; }
        public int CourseID { get; set; }
        public int FacultyID { get; set; }
        public int PageNumber { get; set; }
        public int AccountID { get; set; }
    }
}
