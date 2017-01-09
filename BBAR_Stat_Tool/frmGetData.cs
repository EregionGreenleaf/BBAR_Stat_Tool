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
            ConfigFile.GENERAL = chbGeneral.Checked;
            RefreshTimerCount(ConfigFile.GENERAL);
        }

        private void chbLight_CheckedChanged(object sender, EventArgs e)
        {
            ConfigFile.LIGHT = chbLight.Checked;
            RefreshTimerCount(ConfigFile.LIGHT);
        }

        private void chbMedium_CheckedChanged(object sender, EventArgs e)
        {
            ConfigFile.MEDIUM = chbMedium.Checked;
            RefreshTimerCount(ConfigFile.MEDIUM);
        }

        private void chkHeavy_CheckedChanged(object sender, EventArgs e)
        {
            ConfigFile.HEAVY = chkHeavy.Checked;
            RefreshTimerCount(ConfigFile.HEAVY);
        }

        private void chkAssault_CheckedChanged(object sender, EventArgs e)
        {
            ConfigFile.ASSAULT = chkAssault.Checked;
            RefreshTimerCount(ConfigFile.ASSAULT);
        }

        public void RefreshTimerCount(bool stat)
        {
            double tempDouble = 0;
            double expected = 0.0;
            string[] valueStr = lblTimer.Text.Split(' ');
            double valueDouble = double.TryParse(valueStr[0], out tempDouble) ? tempDouble : 0.0;
            double time;

            if (ConfigFile.TOTAL_PAGES > 0)
            {
                ConfigFile.ACTUAL_TIME = ConfigFile.TOTAL_PAGES * ConfigFile.EXPECTED_TIME;
            }
            else
            {
                time = 0.0;
            }

            if (stat)
                expected = valueDouble + ConfigFile.EXPECTED_TIME;
            else
                expected = valueDouble - ConfigFile.EXPECTED_TIME;
            lblTimer.Text = expected.ToString() + " h";
        }

        private void txtEndPage_TextChanged(object sender, EventArgs e)
        {
            int tempInt = 0;
            int start = int.TryParse(txtStartPage.Text, out tempInt) ? tempInt : -666;
            int end = int.TryParse(txtEndPage.Text, out tempInt) ? tempInt : -666;
            if (start == -666)
            {
                MessageBox.Show("Start Page Not Correct.", "Input pages Error", MessageBoxButtons.OK);
                ConfigFile.TOTAL_PAGES = 0;
                return;
            }
            if (end == -666)
            {
                MessageBox.Show("End Page Not Correct.", "Input pages Error", MessageBoxButtons.OK);
                ConfigFile.TOTAL_PAGES = 0;
                return;
            }
            ConfigFile.TOTAL_PAGES = end - start;
            if (ConfigFile.TOTAL_PAGES > ConfigFile.MAX_PAGES)
            {
                ConfigFile.TOTAL_PAGES = 0;
                MessageBox.Show("Page limit exedeed.", "Input pages Error", MessageBoxButtons.OK);
                return;
            }
            if (ConfigFile.TOTAL_PAGES < 1)
            {
                ConfigFile.TOTAL_PAGES = 0;
                MessageBox.Show("You cannot download less then 1 page", "Input pages Error", MessageBoxButtons.OK);
                return;
            }
        }

        private void txtStartPage_TextChanged(object sender, EventArgs e)
        {
            int tempInt = 0;
            int start = int.TryParse(txtStartPage.Text, out tempInt) ? tempInt : -666;
            int end = int.TryParse(txtEndPage.Text, out tempInt) ? tempInt : -666;
            if (start == -666)
            {
                MessageBox.Show("Start Page Not Correct.", "Input pages Error", MessageBoxButtons.OK);
                ConfigFile.TOTAL_PAGES = 0;
                return;
            }
            if (end == -666)
            {
                MessageBox.Show("End Page Not Correct.", "Input pages Error", MessageBoxButtons.OK);
                ConfigFile.TOTAL_PAGES = 0;
                return;
            }
            ConfigFile.TOTAL_PAGES = end - start;
            if (ConfigFile.TOTAL_PAGES > ConfigFile.MAX_PAGES)
            {
                ConfigFile.TOTAL_PAGES = 0;
                MessageBox.Show("Page limit exedeed.", "Input pages Error", MessageBoxButtons.OK);
                return;
            }
            if (ConfigFile.TOTAL_PAGES < 1)
            {
                ConfigFile.TOTAL_PAGES = 0;
                MessageBox.Show("You cannot download less then 1 page", "Input pages Error", MessageBoxButtons.OK);
                return;
            }
        }
    }
}
