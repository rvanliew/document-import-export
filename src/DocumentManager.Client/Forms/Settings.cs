using DocumentExportUtility_API.Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentExportUtility_API.Forms
{
    public partial class Settings : Form
    {
        private Logger _log { get; set; }

        public Settings()
        {
            InitializeComponent();
        }


        public void FormLoad(Logger log)
        {
            _log = log;
        }

        private void btnOpenLog_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo
                {
                    Arguments = _log.path,
                    FileName = "explorer.exe"
                };

                System.Diagnostics.Process.Start(startInfo);
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show("Could not find Log file.", "Directory Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
