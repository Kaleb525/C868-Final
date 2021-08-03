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
    public partial class DeleteDoctor : Form
    {
        public static List<KeyValuePair<string, object>> DocList;
        public DeleteDoctor()
        {
            InitializeComponent();
            fillDoc();
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }

        public void setDocList(List<KeyValuePair<string, object>> list)
        {
            DocList = list;
        }

        public static List<KeyValuePair<string, object>> getDocList()
        {
            return DocList;
        }

        public void fillDoc()
        {
            MySqlConnection conn = new MySqlConnection(DataHelper.getConString());
            try
            {
                string query = "SELECT doctorId, concat(doctorName, ' -- ID: ', doctorId) as Display FROM doctor;";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                conn.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Doc");
                docComboBox.DisplayMember = "Display";
                docComboBox.ValueMember = "doctorID";
                docComboBox.DataSource = ds.Tables["Doc"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured! " + ex);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
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
                    else
                        clearIT(option.Controls);
            };

            clearIT(Controls);
        }

        private void enabling(bool status)
        {
            deleteButton.Enabled = status;
        }

        private void fillFields(List<KeyValuePair<string, object>> docList)
        {
            Name_Box.Text = docList.First(kvp => kvp.Key == "doctorName").Value.ToString();
            phoneBox.Text = docList.First(kvp => kvp.Key == "phone").Value.ToString();
            type_ComboBox.SelectedIndex = type_ComboBox.FindStringExact(docList.First(kvp => kvp.Key == "type").Value.ToString());
            if (Convert.ToInt32(docList.First(kvp => kvp.Key == "active").Value) == 1)
            {
                Yes_Rad_Bttn.Checked = true;
            }
            else
            {
                No_Rad_Box.Checked = true;
            }
        }


            private void searchButton_Click(object sender, EventArgs e)
        {
            //Grabs ID
            DataRowView drv = docComboBox.SelectedItem as DataRowView;
            int id = Convert.ToInt32(docComboBox.SelectedValue);
            var docList = DataHelper.searchDoctor(id);
            setDocList(docList);
            //Calls db helper to get all customer results as object array
            //If we got a null array, don't continue
            if (docList != null)
            {
                //Enable fields
                enabling(true);
                //Input data into text fields
                fillFields(docList);
            }
        }

       

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult youSure = MessageBox.Show("Are you sure you want to delete this Doctor?", "", MessageBoxButtons.YesNo);
            if (youSure == DialogResult.Yes)
            {
                try
                {
                    //Grab List & convert
                    var list = getDocList();
                    IDictionary<string, object> dictionary = list.ToDictionary(pair => pair.Key, pair => pair.Value);
                    //First we need to check if appointments exist
                    bool appoint = DataHelper.appointExist(dictionary["doctorId"].ToString());
                    if (appoint == false)
                    {
                        DataHelper.deleteCustomer(dictionary);

                    }
                    else
                    {
                        DialogResult youSure2 = MessageBox.Show("Deleting this doctor will remove all of there associated appointments, contiune?", "", MessageBoxButtons.YesNo);
                        if (youSure2 == DialogResult.Yes)
                        {
                            DataHelper.noDocAppointments(dictionary["doctorId"].ToString());
                            DataHelper.deleteDoctor(dictionary);
                        }
                        else
                        {
                            return;
                        }
                    }
                    clearButton_Click(null, new EventArgs());
                    MessageBox.Show("Doctor Record Deleted");

                    this.Owner.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }
        }
    }
}
