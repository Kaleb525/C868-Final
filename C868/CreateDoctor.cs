using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace C868
{
    public partial class CreateDoctor : Form
    {
        public CreateDoctor()
        {
            InitializeComponent();
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
        private void createButton_Click(object sender, EventArgs e)
        {
            bool pass = validator();
            if(pass)
            {
                DataHelper.createDoctor(DataHelper.getID("doctor", "doctorId") + 1, nameTextbox.Text, phoneBox.Text, type_ComboBox.SelectedItem.ToString(), yesRadio.Checked ? 1 : 0, DataHelper.getDateTime(), DataHelper.getCurrentUserName());

                this.Owner.Show();
                this.Close();
            }
        }
        private bool validator()
        {
            if(System.Text.RegularExpressions.Regex.IsMatch(nameTextbox.Text, "[^a-zA-Z]+$"))
            {
                showError(nameLabel.Text);
                return false;
            }

            if(emptyCheck() == false)
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
