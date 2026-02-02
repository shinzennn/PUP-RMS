using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUP_RMS.Model
{
    public class Faculty
    {
        public int FacultyID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Initials { get; set; }

        public string FacultyCode { get; set; }
        public string DisplayName { get; set; }
        public string FacultyName { get; set; }
    }
}
