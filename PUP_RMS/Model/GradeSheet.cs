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
        public string SchoolYear { get; set; }
        public int Semester { get; set; }
        public int CourseID { get; set; }
        public int ProfessorID { get; set; }
        public int AdminID { get; set; }
    }
}
