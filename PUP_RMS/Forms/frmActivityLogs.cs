using PUP_RMS.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PUP_RMS.Forms
{
    public partial class frmActivityLogs : Form
    {
        public frmActivityLogs()
        {
            InitializeComponent();
        }

        private void frmActivityLogs_Load(object sender, EventArgs e)
        {
            dgvActivityLog.DataSource = ActivityLogger.GetAllActivityLog();
        }
    }
}
