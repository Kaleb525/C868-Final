using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace C868
{
    public struct AppReport
    {
        public string month;
        public string appType;
        public int quantinty;
    }
    public partial class NumberOfAppointmentsReport : Form
    {
        public NumberOfAppointmentsReport()
        {
            InitializeComponent();

        }

        private void Title_label_Click(object sender, EventArgs e)
        {

        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            DataRowView drv = typeComboBox.SelectedItem as DataRowView;
            try
            {
                string item = typeComboBox.SelectedItem.ToString();

                IDictionary<string, object> dictionary = DataHelper.reportAppoint(item);
                janResult.Text = dictionary["Jan"].ToString();
                febResult.Text = dictionary["Feb"].ToString();
                marResult.Text = dictionary["Mar"].ToString();
                aprResult.Text = dictionary["Apr"].ToString();
                mayResult.Text = dictionary["May"].ToString();
                junResult.Text = dictionary["Jun"].ToString();
                julResult.Text = dictionary["Jul"].ToString();
                augResult.Text = dictionary["Aug"].ToString();
                septResult.Text = dictionary["Sep"].ToString();
                octResult.Text = dictionary["Oct"].ToString();
                novResult.Text = dictionary["Nov"].ToString();
                decResult.Text = dictionary["Dec"].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Owner.Show();
        }
    }
}
