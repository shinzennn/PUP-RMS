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
    public partial class frmAccountList : Form
    {
        public frmAccountList()
        {
            InitializeComponent();
        }

        private void frmAccountList_Load(object sender, EventArgs e)
        {
            dgvAccount.DataSource = AccountHelper.GetAllAccount();
        }
    }
}
