using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using MySql.Data.MySqlClient;

namespace C868
{
    public partial class UpdateCustomer : Form
    {
        private bool allowUpdate()
        {
            int number;
            return (!string.IsNullOrWhiteSpace(Name_Box.Text)) && (!string.IsNullOrWhiteSpace(Address_Box.Text)) && (!string.IsNullOrWhiteSpace(City_Box.Text)) && (!string.IsNullOrWhiteSpace(Country_Box.Text)) &&
                (!(string.IsNullOrWhiteSpace(Phone_Box.Text) || (!Int32.TryParse(Phone_Box.Text, out number)))) && (!(string.IsNullOrWhiteSpace(Zip_Box.Text) || (!Int32.TryParse(Zip_Box.Text, out number))));
        }
        private void textvalidation()
        {
            int number;
            if (string.IsNullOrWhiteSpace(Name_Box.Text))
            {
                Name_Box.BackColor = System.Drawing.Color.Salmon;
            }
            else
            {
                Name_Box.BackColor = System.Drawing.Color.White;
            }
            if (string.IsNullOrWhiteSpace(Address_Box.Text))
            {
                Address_Box.BackColor = System.Drawing.Color.Salmon;
            }
            else
            {
                Address_Box.BackColor = System.Drawing.Color.White;
            }
            if (string.IsNullOrWhiteSpace(City_Box.Text))
            {
                City_Box.BackColor = System.Drawing.Color.Salmon;
            }
            else
            {
                City_Box.BackColor = System.Drawing.Color.White;
            }
            if (string.IsNullOrWhiteSpace(Country_Box.Text))
            {
                Country_Box.BackColor = System.Drawing.Color.Salmon;
            }
            else
            {
                Country_Box.BackColor = System.Drawing.Color.White;
            }
            if (string.IsNullOrWhiteSpace(Phone_Box.Text) || (!Int32.TryParse(Phone_Box.Text, out number)))
            {
                Phone_Box.BackColor = System.Drawing.Color.Salmon;
            }
            else
            {
                Phone_Box.BackColor = System.Drawing.Color.White;
            }
            if (string.IsNullOrWhiteSpace(Zip_Box.Text) || (!Int32.TryParse(Zip_Box.Text, out number)))
            {
                Zip_Box.BackColor = System.Drawing.Color.Salmon;
            }
            else
            {
                Zip_Box.BackColor = System.Drawing.Color.White;
            }

            update_Bttn.Enabled = allowUpdate();
        }
        public static List<KeyValuePair<string, object>> CustList;

        public UpdateCustomer()
        {
            InitializeComponent();
            fillCust();
            textvalidation();
        }
        public int Updatecustomer(string Name, string phoneNumber, string address, string city, string zip, string country)
        {
            if (Name != null && phoneNumber != null && address != null && city != null && zip != null && country != null)
            {
                Name_Box.Text = Name;
                Phone_Box.Text = phoneNumber;
                Address_Box.Text = address;
                City_Box.Text = city;
                Zip_Box.Text = zip;
                Country_Box.Text = country;
                return 1;
            }
            return 0;
        }
        private void UpdateCustomer_TextChanged(object sender, EventArgs e)
        {
            textvalidation();
        }

        public void setCustList(List<KeyValuePair<string, object>> list)
        {

            CustList = list;

        }

        public static List<KeyValuePair<string, object>> getCustList()
        {

            return CustList;
        }



        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }

        public void fillCust()
        {
            MySqlConnection conn = new MySqlConnection(DataHelper.getConString());

            try
            {
                string query = "SELECT customerId, concat(customerName, ' -- ID: ', customerId) as Display FROM customer;";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                conn.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Cust");
                custComboBox.DisplayMember = "Display";
                custComboBox.ValueMember = "customerID";
                custComboBox.DataSource = ds.Tables["Cust"];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured! " + ex);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
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
                    else
                        clearIT(option.Controls);
            };

            clearIT(Controls);
        }


        private void SearchButton_Click(object sender, EventArgs e)
        {

            //Grabs ID
            DataRowView drv = custComboBox.SelectedItem as DataRowView;
            int id = Convert.ToInt32(custComboBox.SelectedValue);
            var custList = DataHelper.searchCustomer(id);
            setCustList(custList);

            if (custList != null)
            {
                //Enable fields
                enabling(true);
                //Input data into text fields
                fillFields(custList);
            }

        }


        private void enabling(bool status)
        {
            Name_Box.Enabled = status;
            Phone_Box.Enabled = status;
            Address_Box.Enabled = status;
            City_Box.Enabled = status;
            Zip_Box.Enabled = status;
            Country_Box.Enabled = status;
            Yes_Rad_Bttn.Enabled = status;
            No_Rad_Bttn.Enabled = status;
            update_Bttn.Enabled = status;
        }

        private void fillFields(List<KeyValuePair<string, object>> custList)
        {
            // Lambda used to set text values from kvp
            Name_Box.Text = custList.First(kvp => kvp.Key == "customerName").Value.ToString();
            Phone_Box.Text = custList.First(kvp => kvp.Key == "phone").Value.ToString();
            Address_Box.Text = custList.First(kvp => kvp.Key == "address").Value.ToString();
            City_Box.Text = custList.First(kvp => kvp.Key == "city").Value.ToString();
            Zip_Box.Text = custList.First(kvp => kvp.Key == "postalCode").Value.ToString();
            Country_Box.Text = custList.First(kvp => kvp.Key == "country").Value.ToString();
            if (Convert.ToInt32(custList.First(kvp => kvp.Key == "active").Value) == 1)
            {
                Yes_Rad_Bttn.Checked = true;
            }
            else
            {
                No_Rad_Bttn.Checked = true;
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            DialogResult youSure = MessageBox.Show("Are you sure you want to update this customer?", "", MessageBoxButtons.YesNo);
            if (youSure == DialogResult.Yes)
            {

                try
                {
                    //Grab List & convert
                    var list = getCustList();
                    IDictionary<string, object> dictionary = list.ToDictionary(pair => pair.Key, pair => pair.Value);
                    //replace values for the keys in the form         
                    dictionary["customerName"] = Name_Box.Text;
                    dictionary["phone"] = Phone_Box.Text;
                    dictionary["address"] = Address_Box.Text;
                    dictionary["city"] = City_Box.Text;
                    dictionary["postalCode"] = Zip_Box.Text;
                    dictionary["country"] = Country_Box.Text;
                    dictionary["active"] = Yes_Rad_Bttn.Checked ? 1 : 0;

                    //Pass the updated IDictionary to DataHelper to update the database
                    DataHelper.updateCustomer(dictionary);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    clearButton_Click(null, new EventArgs());
                    MessageBox.Show("Customer Record Updated");

                    this.Owner.Show();
                    this.Close();
                }


            }
        }

    }
}
