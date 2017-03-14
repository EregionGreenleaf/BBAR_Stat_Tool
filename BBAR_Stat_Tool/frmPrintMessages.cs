using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBAR_Stat_Tool
{
    public partial class frmPrintMessages : Form
    {
        public frmPrintMessages(string message)
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.lblMessage.Text = message;
        }

        private void frmPrintMessages_Load(object sender, EventArgs e)
        {

        }
    }
}
