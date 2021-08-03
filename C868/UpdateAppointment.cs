using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C868
{
    public partial class UpdateAppointment : Form
    {

        private bool allowUpdate()
        {
            return (!string.IsNullOrWhiteSpace(Title_Box.Text)) && (!string.IsNullOrWhiteSpace(Desc_Box.Text)) && (!string.IsNullOrWhiteSpace(Loc_Box.Text)) && (!string.IsNullOrWhiteSpace(Contact_Box.Text));
        }

        private void textValidation()
        {
            if(string.IsNullOrWhiteSpace(Title_Box.Text))
            {
                Title_Box.BackColor = Color.Salmon;
            }
            else
            {
                Title_Box.BackColor = Color.White;
            }

            if(string.IsNullOrWhiteSpace(Desc_Box.Text))
            {
                Desc_Box.BackColor = Color.Salmon;
            }
            else
            {
                Desc_Box.BackColor = Color.White;
            }

            if (string.IsNullOrWhiteSpace(Loc_Box.Text))
            {
                Loc_Box.BackColor = Color.Salmon;
            }
            else
            {
                Loc_Box.BackColor = Color.White;
            }

            if (string.IsNullOrWhiteSpace(Contact_Box.Text))
            {
                Contact_Box.BackColor = Color.Salmon;
            }
            else
            {
                Contact_Box.BackColor = Color.White;
            }
            updateButton.Enabled = allowUpdate();
        }

        public static List<KeyValuePair<string, object>> AppointList;
        public UpdateAppointment()
        {
            InitializeComponent();
            fillAppoint();
            textValidation();
        }

        private void UpdateAppointment_TextChanged(object sender, EventArgs e)
        {
            textValidation();
        }

        public void setAppointList(List<KeyValuePair<string, object>> list)
        {

            AppointList = list;

        }

        public static List<KeyValuePair<string, object>> getAppointList()
        {

            return AppointList;
        }


        private void SearchButton_Click(object sender, EventArgs e)
        {
            //Grabs ID
            DataRowView drv = appointComboBox.SelectedItem as DataRowView;
            int id = Convert.ToInt32(appointComboBox.SelectedValue);

            var appointList = DataHelper.searchAppointment(id);
            setAppointList(appointList);


            if (appointList != null)
            {
                //Enable fields
                enabling(true);
                //Input data into text fields
                fillFields(appointList);
                //Grabs customer assoicated with appointment
                fillCust(Convert.ToInt32(appointList.First(kvp => kvp.Key == "customerId").Value.ToString()));
                //Grabs doctor associated with appointment
                fillDoc(Convert.ToInt32 (appointList.First(kvp => kvp.Key == "doctorId").Value.ToString()));
            }

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            //Locks fields
            enabling(false);
            //Lamba used for function to clear fields
            Action<Control.ControlCollection> clearIT = null;

            clearIT = (controls) =>
            {
                foreach (Control option in controls)
                    if (option is TextBox)
                        (option as TextBox).Clear();
                    else if (option is RadioButton)
                        (option as RadioButton).Checked = false;
                    else if (option is DateTimePicker)
                        (option as DateTimePicker).Value = DateTime.Now;
                    else if (option is ComboBox)
                        (option as ComboBox).SelectedIndex = -1;
                    else
                        clearIT(option.Controls);
            };

            clearIT(Controls);
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

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            
                DialogResult youSure = MessageBox.Show("Are you sure you want to update this Appointment?", "", MessageBoxButtons.YesNo);
                if (youSure == DialogResult.Yes)
                {
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
                    
                }
                try
                    {
                        //Grab List & convert
                        var list = getAppointList();
                        IDictionary<string, object> dictionary = list.ToDictionary(pair => pair.Key, pair => pair.Value);
                        //replace values for the keys in the form         
                       // dictionary["appointmentId"] = AppointList.First(kvp => kvp.Key == "appointmentId").Value;
                        //dictionary["customerId"] = customerComboBox.SelectedValue;
                        //dictionary["doctorId"] = doctorComboBox.SelectedValue;
                        dictionary["title"] = Title_Box.Text;
                        dictionary["description"] = Desc_Box.Text;
                        dictionary["location"] = Loc_Box.Text;
                        dictionary["contact"] = Contact_Box.Text;
                        dictionary["type"] = typeCombobox.SelectedItem.ToString();
                        dictionary["start"] = startDTP.Value;
                        dictionary["end"] = endDTP.Value;
                        dictionary["url"] = customerComboBox.SelectedValue;

                        //Pass the updated IDictionary to DataHelper to update the database
                        DataHelper.updateAppointment(dictionary);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error occured! " + ex);
                    }
                    finally
                    {
                        ClearButton_Click(null, new EventArgs());
                        MessageBox.Show("Customer Record Updated");
                        this.Owner.Show();
                        this.Close();
                    }
                }
            
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        public void fillAppoint()
        {
            MySqlConnection conn = new MySqlConnection(DataHelper.getConString());

            try
            {
                string query = "select appointmentId, concat(appointmentId, (select  concat(' -- Customer: ', customerName) from customer where appointment.customerId = customer.customerId))  as Display from appointment where end > now();";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                conn.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Appoint");
                appointComboBox.DisplayMember = "Display";
                appointComboBox.ValueMember = "appointmentId";
                appointComboBox.DataSource = ds.Tables["Appoint"];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured! " + ex);
            }
        }

        public void fillCust(int custID)
        {
            MySqlConnection conn = new MySqlConnection(DataHelper.getConString());

            try
            {
                string query = $"SELECT customerId, concat(customerName, ' -- ID: ', customerId) as Display FROM customer;";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                conn.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Cust");
                customerComboBox.DisplayMember = "Display";
                customerComboBox.ValueMember = "customerID";
                customerComboBox.DataSource = ds.Tables["Cust"];
                DataRowView drv = customerComboBox.SelectedItem as DataRowView;
                customerComboBox.SelectedValue = custID;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured! " + ex);
            }
        }
        public void fillDoc(int docID)
        {
            MySqlConnection conn = new MySqlConnection(DataHelper.getConString());
            try
            {
                string query = "SELECT doctorId, concat(doctorName, ' -- ID:', doctorId) as Display FROM doctor;";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                conn.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Doc");
                doctorComboBox.DisplayMember = "Display";
                doctorComboBox.ValueMember = "doctorId";
                doctorComboBox.DataSource = ds.Tables["Doc"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured!" + ex);
            }
        }

        private void enabling(bool status)
        {
            customerComboBox.Enabled = status;
            doctorComboBox.Enabled = status;
            Title_Box.Enabled = status;
            Desc_Box.Enabled = status;
            Loc_Box.Enabled = status;
            Contact_Box.Enabled = status;
            typeCombobox.Enabled = status;
            startDTP.Enabled = status;
            endDTP.Enabled = status;
            updateButton.Enabled = status;
        }

        private void fillFields(List<KeyValuePair<string, object>> AppointList)
        {
            // Lambda used to set text values from kvp
            Title_Box.Text = AppointList.First(kvp => kvp.Key == "title").Value.ToString();
            Desc_Box.Text = AppointList.First(kvp => kvp.Key == "description").Value.ToString();
            Loc_Box.Text = AppointList.First(kvp => kvp.Key == "location").Value.ToString();
            Contact_Box.Text = AppointList.First(kvp => kvp.Key == "contact").Value.ToString();
            typeCombobox.SelectedIndex = typeCombobox.FindStringExact(AppointList.First(kvp => kvp.Key == "type").Value.ToString());
            string start = AppointList.First(kvp => kvp.Key == "start").Value.ToString();
            string end = AppointList.First(kvp => kvp.Key == "end").Value.ToString();
            //startDTP.Value = Convert.ToDateTime(start).ToLocalTime();
            //endDTP.Value = Convert.ToDateTime(end).ToLocalTime();

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
            if (System.Text.RegularExpressions.Regex.IsMatch(Contact_Box.Text, "[^a-zA-Z]+$"))
            {
                showError(contactLabel.Text);
                return false;
            }
            if (typeCombobox.SelectedIndex == -1)
            {
                showError(typeLabel.Text);
                return false;
            }
            if (customerComboBox.SelectedIndex == -1)
            {
                showError(customerLabel.Text);
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
            }
            return true;
        }
    }
}
