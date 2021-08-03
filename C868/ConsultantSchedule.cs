using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace C868
{
    public struct UserReport
    {
        public int userId;
        public string userName;
        public string type;
        public string startTime;
        public string endTime;
        public string customerName;
    }

    public partial class ConsultantSchedule : Form
    {
        public static List<KeyValuePair<string, object>> docList;
        public ConsultantSchedule()
        {
            InitializeComponent();
            fillConsol();
        }

        public void setDocList(List<KeyValuePair<string, object>> list)
        {

            docList = list;

        }

        public static List<KeyValuePair<string, object>> getDocList()
        {

            return docList;
        }


        public void fillConsol()
        {
            MySqlConnection conn = new MySqlConnection(DataHelper.getConString());

            try
            {
                string query = "SELECT doctorId, doctorName AS 'Display' FROM doctor";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                conn.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Doc");
                consultantComboBox.DisplayMember = "Display";
                consultantComboBox.ValueMember = "doctorId";
                consultantComboBox.DataSource = ds.Tables["Doc"];
            }
            catch (Exception ex)
            {
                // write exception info to log or anything else
                Console.WriteLine("Error occured! " + ex);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            DataRowView drv = consultantComboBox.SelectedItem as DataRowView;
            int id = Convert.ToInt32(consultantComboBox.SelectedValue);

            DataTable dtRecord = DataHelper.schedule(id.ToString());
            Schedules_DGV.DataSource = dtRecord;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Owner.Show();
        }
    }
}

