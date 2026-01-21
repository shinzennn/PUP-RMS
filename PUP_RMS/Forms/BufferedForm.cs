using System;
using System.Runtime.InteropServices; 
using System.Reflection;
using System.Windows.Forms;

namespace PUP_RMS.Forms
{
    /// <summary>
    /// The Ultimate Anti-Flicker Base Form.
    /// Fixes: Form flicker, Panel/Grid tearing, and TreeView/ListView native glitching.
    /// </summary>
    public class BufferedForm : Form
    {
        public BufferedForm()
        {
            // 1. GLOBAL FORM BUFFERING
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        // 2. PREVENT BACKGROUND ERASURE (The "White Flash" Fix)
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x02000000; // WS_CLIPCHILDREN
                return cp;
            }
        }

        // 3. RECURSIVE FIXER
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ApplyFlickerFixRecursively(this.Controls);
        }

        private void ApplyFlickerFixRecursively(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                // A. Fix Standard Controls (Panels, DataGridViews)
                SetDoubleBuffered(c);

                // B. Fix Native Controls (TreeView, ListView)
                if (c is TreeView || c is ListView)
                {
                    SetNativeDoubleBuffered(c.Handle);
                }

                // C. Go Deeper (Tabs, GroupBoxes, SplitContainers)
                if (c.HasChildren)
                {
                    ApplyFlickerFixRecursively(c.Controls);
                }
            }
        }

        // --- HELPER 1: Standard .NET Fix ---
        public static void SetDoubleBuffered(Control c)
        {
            if (SystemInformation.TerminalServerSession) return;
            PropertyInfo aProp = typeof(Control).GetProperty("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance);
            if (aProp != null) aProp.SetValue(c, true, null);
        }

        // --- HELPER 2: Native Windows Fix (For TreeView/ListView) ---
        // These controls ignore the .NET property, so we send a Windows Message directly.
        private const int TVM_SETEXTENDEDSTYLE = 0x1100 + 44;
        private const int TVS_EX_DOUBLEBUFFER = 0x0004;
        private const int LVM_SETEXTENDEDLISTVIEWSTYLE = 0x1000 + 54;
        private const int LVS_EX_DOUBLEBUFFER = 0x00010000;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        public static void SetNativeDoubleBuffered(IntPtr handle)
        {
            // Try setting both TreeView and ListView styles (harmless if sent to wrong one)
            SendMessage(handle, TVM_SETEXTENDEDSTYLE, (IntPtr)TVS_EX_DOUBLEBUFFER, (IntPtr)TVS_EX_DOUBLEBUFFER);
            SendMessage(handle, LVM_SETEXTENDEDLISTVIEWSTYLE, (IntPtr)LVS_EX_DOUBLEBUFFER, (IntPtr)LVS_EX_DOUBLEBUFFER);
        }
    }
}