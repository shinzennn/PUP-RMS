using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; // Needed for Color type

namespace PUP_RMS.CustomControls
{
    public class ChartSegment
    {
        public string Label { get; set; } // e.g., "BSIT"
        public int Value { get; set; }    // e.g., 4500
        public Color Color { get; set; }  // Color for this segment
    }

}
