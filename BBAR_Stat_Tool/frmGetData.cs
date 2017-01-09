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
    public partial class frmGetData : Form
    {
        public frmGetData()
        {
            InitializeComponent();
            //Personalized
            for(int i = ConfigFile.SEASON_FIRST; i <= ConfigFile.SEASON_LAST; i++)
            {
                cmbSeasonNumber.Items.Add(i.ToString());
            }
        }

        /// <summary>
        /// Const equivalent of the "close" button
        /// </summary>
        private const int CP_NOCLOSE_BUTTON = 0x200;
        /// <summary>
        /// Override the parameters of the form, hiding the "close" button
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void frmGetData_Load(object sender, EventArgs e)
        {
            Logger.PrintC("test: " + e.ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chbGeneral_CheckedChanged(object sender, EventArgs e)
        {
            if (chbGeneral.Checked == true)
                ConfigFile.ADDRESS = "£";

        }
    }
}
