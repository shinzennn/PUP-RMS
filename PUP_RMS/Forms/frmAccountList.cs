using PUP_RMS.Helper;
using PUP_RMS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
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
            DataTable dt = AccountHelper.GetAllAccount();
            PopulateTablePanel(tblpnlAccount, dt);
        }

        private void PopulateTablePanel(TableLayoutPanel tblpnlAccount, DataTable dt)
        {
            tblpnlAccount.SuspendLayout();

            // RESET THE TABLE PANEL
            tblpnlAccount.Controls.Clear();
            tblpnlAccount.RowStyles.Clear();
            tblpnlAccount.RowCount = 0;
            tblpnlAccount.ColumnCount = 1;
            tblpnlAccount.ColumnStyles.Clear();
            tblpnlAccount.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            tblpnlAccount.BackColor = Color.Transparent;

            // DEFINE ROW HIEGHT
            int rowHeight = 110; // Adjust based on your design

            // ADD ROWS BASED ON DATATABLE
            foreach(DataRow row in dt.Rows)
            {
                tblpnlAccount.RowCount++;
                tblpnlAccount.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));

                // CREATE ROW PANEL
                Panel rowPanel = CreateRowPanel(row, tblpnlAccount.Width);

                // ADD ROW PANEL TO TABLE PANEL
                tblpnlAccount.Controls.Add(rowPanel, 0, tblpnlAccount.RowCount - 1);
            }

            tblpnlAccount.ResumeLayout();
        }

        private Panel CreateRowPanel(DataRow row, int parentWidth)
        {
            int panelHeight = 100;

            RoundedShadowPanel rowPanel = new RoundedShadowPanel
            {
                Size = new Size(parentWidth, panelHeight),
                Padding = new Padding(5),
                BackColor = Color.Transparent
            };

            // EXTRACT DATA FROM THE DataRow
            string accountID = row["AccountID"].ToString();
            string fullName = row["FullName"].ToString();
            string username = row["Username"].ToString();
            string accountType = row["AccountType"].ToString();

            // DESIGN THE PICTURE BOX FOR ICON IMAGE
            int iconSize = 48;
            int iconLeftMargin = 20;


            PictureBox picIcon = new PictureBox
            {
                Size = new Size(iconSize, iconSize),
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(iconLeftMargin, (rowPanel.Height - iconSize) / 2),
                BackColor = Color.Transparent,
                Image = Properties.Resources.Account_2
            };

            // DESIGN THE LABELS
            int labelLeftStart = iconLeftMargin + iconSize + 15;
            int labelRightStart = parentWidth - 50;

            Label lblFullname = new Label
            {
                Text = fullName,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(labelLeftStart, 25),
                BackColor = Color.Transparent,
                AutoSize = true
            };

            Label lblUsername = new Label
            {
                Text = username,
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                Location = new Point(labelLeftStart, 50),
                BackColor = Color.Transparent,
                AutoSize = true
            };

            Label lblAccountType = new Label
            {
                Text = accountType,
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                BackColor = Color.Transparent,
                AutoSize = true
            };
            int xPos = rowPanel.Width - lblAccountType.Width - 10;
            lblAccountType.Location = new Point(xPos, 25);

            // ADD CONTROLS TO THE ROW PANEL
            rowPanel.Controls.Add(picIcon);
            rowPanel.Controls.Add(lblFullname);
            rowPanel.Controls.Add(lblUsername);
            rowPanel.Controls.Add(lblAccountType);

            return rowPanel;
        }
    }
}
