using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUP_RMS.Model
{
    public class Course
    {
        public int CourseID { get; set; }
        public int CourseCode { get; set; }
        public string CourseDescription { get; set; }
        public string SchoolYear { get; set; }
        public int Semester{ get; set; }
    }
}
