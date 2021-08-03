using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace C868
{
    public partial class CreateCustomer : Form
    {

        public CreateCustomer()
        {
            InitializeComponent();
        }

        public int AddCustomer(string Name, string phoneNumber, string address, string city, string zip, string country )
        {
            if (Name != null  && phoneNumber != null && address != null && city != null && zip != null && country != null)
            {
                nameTextbox.Text = Name;
                phoneTextbox.Text = phoneNumber;
                addressTextbox.Text = address;
                cityTextbox.Text = city;
                zipTextbox.Text = zip;
                countryTextbox.Text = country;
                return 1;
            }
            return 0;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void createButton_Click(object sender, EventArgs e)
        {

            bool pass = validator();
            if (pass)
            {
                //Need to create country record
                int countryID = DataHelper.createCountry(countryTextbox.Text);
                //Need to create city record
                int cityID = DataHelper.createCity(countryID, cityTextbox.Text);
                //Need to create address record
                int addressID = DataHelper.createAddress(cityID, addressTextbox.Text, zipTextbox.Text, phoneTextbox.Text);
                //Need to create customer record  -- customerID, name, adressID, active, create date, createdby, lastUpdate, updatedby
                DataHelper.createCustomer(DataHelper.getID("customer", "customerId") + 1, nameTextbox.Text, addressID, yesRadio.Checked ? 1 : 0, DataHelper.getDateTime(), DataHelper.getCurrentUserName());

                this.Owner.Show();
                this.Close();
            }

        }

        private bool validator()
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(nameTextbox.Text, "[^a-zA-Z]+$"))
            {
                showError(nameLabel.Text);
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(phoneTextbox.Text, "[^0-9-()]+$"))
            {
                showError(phoneLabel.Text);
                return false;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(zipTextbox.Text, "[^0-9]"))
            {
                showError(zipLabel.Text);
                return false;
            }

            if (emptyCheck() == false)
            {
                MessageBox.Show("Please complete all Customer Information fields.");
            }

            return true;
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

        private void showError(string item)
        {
            MessageBox.Show("Please enter a valid information for " + item);

        }
    }
}
