using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUP_RMS.Model
{
    public class Professor
    {
        public int ProfessorID { get; set; }

        // MUST match the SQL alias
        public string FullName { get; set; }
    }
}
