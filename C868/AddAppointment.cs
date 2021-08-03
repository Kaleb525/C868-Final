using System;
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
    public partial class AddAppointment : Form
    {
        public string dataString = DataHelper.getConString();
        public AddAppointment()
        {
            InitializeComponent();
            fillCust();
            fillDoct();
            endDTP.Value = endDTP.Value.AddMinutes(30);
        }

        public Dashboard dashboardObject;
        public void fillCust()
        {
            MySqlConnection conn = new MySqlConnection(dataString);

            try
            {
                string query = "SELECT customerId, concat(customerName, ' -- ID: ', customerId) as Display FROM customer;";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                conn.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Cust");
                custComboBox.DisplayMember = "Display";
                custComboBox.ValueMember = "customerId";
                custComboBox.DataSource = ds.Tables["Cust"];
            }
            catch (Exception ex)
            {
                // write exception info to log or anything else
                MessageBox.Show("Error occured! " + ex);
            }
        }

        public void fillDoct()
        {
            MySqlConnection conn = new MySqlConnection(dataString);
            try
            {
                string query = "SELECT doctorId, concat(doctorName, ' -- ID:', doctorId) as Display FROM doctor;";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                conn.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Doc");
                docComboBox.DisplayMember = "Display";
                docComboBox.ValueMember = "doctorId";
                docComboBox.DataSource = ds.Tables["Doc"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured!" + ex);
            }
        }




        private void createCusButton_Click(object sender, EventArgs e)
        {
            bool pass = validator();
            if (pass)
            {
                if (custComboBox.SelectedItem != null)
                {
                    //Have a customer selected so lets add the appointment
                    //customerID
                    DataRowView drv = custComboBox.SelectedItem as DataRowView;
                    int custID = Convert.ToInt32(custComboBox.SelectedValue);
                    //grab data fields from form

                    DataRowView dRv = docComboBox.SelectedItem as DataRowView;
                    int docID = Convert.ToInt32(docComboBox.SelectedValue);

                    DateTime start = startDTP.Value.ToUniversalTime();
                    DateTime end = endDTP.Value.ToUniversalTime();
                    //Validations
                    //appointment is not being set outside business hours
                    //appointment is not being set overlapping another appointment
                    int validated = appointmentValid(start, end);

                    switch (validated)
                    {
                        case 1:
                            MessageBox.Show("This appointment does not fall within business hours.");
                            break;
                        case 2:
                            MessageBox.Show("This appointment Overlaps with another appointment.");
                            break;
                        case 3:
                            MessageBox.Show("The appointments starts after the end time.");
                            break;
                        case 4:
                            MessageBox.Show("This appointment start and end date are not on the same date.");
                            break;
                        default:
                            DataHelper.createAppointment(custID, docID, Title_Box.Text, Desc_Box.Text, Loc_Box.Text, Con_Box.Text, typeCombobox.SelectedItem.ToString(), start, end);
                            this.Owner.Show();
                            this.Close();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("A Customer must be selected!");
                }
            }
        }
        public int appointmentValid(DateTime start, DateTime end)
        {
            DateTime localStart = start.ToLocalTime();
            DateTime localEnd = end.ToLocalTime();

            DateTime businessStart = DateTime.Today.AddHours(8);
            DateTime businessEnd = DateTime.Today.AddHours(17);

            //return 1 for outside business hours (8am - 5pm local)
            if (localStart.TimeOfDay < businessStart.TimeOfDay || localEnd.TimeOfDay > businessEnd.TimeOfDay)
            {
                return 1;
            }
            if (DataHelper.overlap(start, end) != 0)
            {
                return 2;
            }
            //return 2 for failed overlapp
            //DB? Or can we look at Dashboard table
            //return 3 for end before start
            if (localStart.TimeOfDay > localEnd.TimeOfDay)
            {
                return 3;
            }
            //return 4 for appoinment not same day
            if (localStart.ToShortDateString() != localEnd.ToShortDateString())
            {
                return 4;
            }
            //return 0 pass 
            return 0;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
        private bool validator()
        {

            if (emptyCheck() == false)
            {
                MessageBox.Show("Please complete all Appointment Information fields.");
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(Title_Box.Text, "[^a-zA-Z]+$"))
            {
                showError(titleLabel.Text);
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(Desc_Box.Text, "[^a-zA-Z]+$"))
            {
                showError(descriptionLabel.Text);
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(Loc_Box.Text, "[^a-zA-Z]+$"))
            {
                showError(locationLabel.Text);
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(Con_Box.Text, "[^a-zA-Z]+$"))
            {
                showError(contactLabel.Text);
                return false;
            }
            if (typeCombobox.SelectedIndex == -1)
            {
                showError(typeLabel.Text);
                return false;
            }

            return true;
        }

        private void showError(string item)
        {
            MessageBox.Show("Please enter a valid information for " + item);

        }
        private bool emptyCheck()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    if (textBox.Text == string.Empty)
                    {
                        return false;
                    }
                }
                if (c is ComboBox)
                {
                    ComboBox combo = c as ComboBox;
                    if (combo.SelectedIndex == -1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void AddAppoint_Load(object sender, EventArgs e)
        {

        }
    }
}