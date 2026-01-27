using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUP_RMS.Model
{
    public class Curriculum
    {
        public int CurriculumID { get; set; }
        public string CurriculumYear { get; set; }
        public int ProgramID { get; set; }
        public int YearLevel { get; set; }
        public int Semester { get; set; }

        // Optional: convenience property for display
        public string DisplayName
        {
            get
            {
                return $"{CurriculumYear} - Year {YearLevel}, Sem {Semester}";
            }
        }
    }
}
