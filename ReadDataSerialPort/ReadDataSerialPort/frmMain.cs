using DevExpress.XtraBars;
using DevExpress.XtraBars.FluentDesignSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadDataSerialPort
{
    public partial class frmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        
        public frmMain()
        {
            InitializeComponent();
        }

        private void aBtnNewMachine_Click(object sender, EventArgs e)
        {
            if (!container.Controls.Contains(usNewMachine.Instance))
            {
                container.Controls.Add(usNewMachine.Instance);
                usNewMachine.Instance.Dock = DockStyle.Fill;
                usNewMachine.Instance.BringToFront();
            }
            usNewMachine.Instance.BringToFront();
        }

        private void acBC3000_Click(object sender, EventArgs e)
        {
            if (!container.Controls.Contains(usBC3000.Instance))
            {
                container.Controls.Add(usBC3000.Instance);
                usBC3000.Instance.Dock = DockStyle.Fill;
                usBC3000.Instance.BringToFront();
            }
            usBC3000.Instance.BringToFront();
        }

        private void acAu400_Click(object sender, EventArgs e)
        {

            if (!container.Controls.Contains(usAU400.Instance))
            {
                container.Controls.Add(usAU400.Instance);
                usAU400.Instance.Dock = DockStyle.Fill;
                usAU400.Instance.BringToFront();
            }
            usAU400.Instance.BringToFront();
        }
    }
}
