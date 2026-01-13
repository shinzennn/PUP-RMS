using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUP_RMS.Model
{
    public class ActivityLog
    {
        public int LogID { get; set; }
        public int AccountID { get; set; }
        public string ActivityDescription { get; set; }
        public DateTime ActivityDate { get; set; }
    }
}
