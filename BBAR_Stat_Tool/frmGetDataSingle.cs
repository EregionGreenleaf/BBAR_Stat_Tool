﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBAR_Stat_Tool
{
    public partial class frmGetDataSingle : Form
    {
        public frmGetDataSingle()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
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


        private void frmGetDataSingle_Show(object sender, EventArgs e)
        {
            //List<PlayerStatT> newPlayer = new List<PlayerStatT>();
            //WebOps.SearchPlayer("Eregion", new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 }, new List<int> { 0, 1, 2, 3, 4 }, "eregiongreenleafthegray@yahoo.it", "chupa33");
            //newPlayer = ConfigFile.GLOBAL_PLAYER;

            //tlpDataTable.new
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfigFile.ACTUAL_MAIN.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmGetDataSingle_Load(object sender, EventArgs e)
        {
            FileInfo localCredentials = new FileInfo(ConfigFile.FULL_LIST_NAMES);
            string[] listNames = File.ReadAllLines(localCredentials.FullName);
            listNames.ToList().ForEach(x => x = x.Trim());

            var source = new AutoCompleteStringCollection();
            source.AddRange(listNames);

            textBox1.AutoCompleteCustomSource = source;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void tlpDataTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> list = textBox1.Lines.ToList();
            list.ForEach(x => x = x.Trim());
            if (list.Count > 0)
            {
                ConfigFile.ACTUAL_PLAYER_LIST = list;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                ConfigFile.ACTUAL_PLAYER_LIST = new List<string>();
                this.DialogResult = DialogResult.Cancel;
            }
            this.Close();
        }
    }
}
