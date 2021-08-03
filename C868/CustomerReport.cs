using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace C868
{
    public struct Customer
    {
        public string customerName;
        public int numberOfApps;
    }
    public partial class CustomerReport : Form
    {
        public CustomerReport()
        {
            InitializeComponent();

        }



        private void Close_bttn_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }

        private void CustomerReport_Load(object sender, EventArgs e)
        {
            DataTable dtRecord = DataHelper.getReport();
            CWA_DGV.DataSource = dtRecord;
        }
    }
}
