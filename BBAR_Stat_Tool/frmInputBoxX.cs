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
    public partial class frmInputBoxX : Form
    {
        public frmInputBoxX()
        {
            InitializeComponent();
            var source = new AutoCompleteStringCollection();
            source.AddRange(ConfigFile.ACTUAL_LIST_NAME);
            txtName.AutoCompleteCustomSource = source;
        }

        private void frmInputBoxX_Load(object sender, EventArgs e)
        {
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ConfigFile.ACTUAL_PLAYER = string.IsNullOrWhiteSpace(txtName.Text.Trim()) ? null : txtName.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
