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
using System.Globalization;
using System.Data.Entity.Infrastructure.Interception;
using System.Threading;

namespace C868
{
    public partial class Login : Form
    {
        public string errorMessage = "The username and password did not match.";

        public Login()
        {
            InitializeComponent();
            // Supports English or German
            if (CultureInfo.CurrentUICulture.LCID == 1031)
            {

                Title.Text = "Bitte melden Sie sich unten an";
                UserName_Label.Text = "Nutzername";
                Password_Label.Text = "Passwort";
                Login_Button.Text = "Anmeldung";
                Cancel_bttn.Text = "Stornieren";
                errorMessage = "Der Benutzername und das Passwort stimmten nicht überein.";


            }

            else if (CultureInfo.CurrentUICulture.LCID == 3079)
            {

                Title.Text = "Bitte melden Sie sich unten an";
                UserName_Label.Text = "Nutzername";
                Password_Label.Text = "Passwort";
                Login_Button.Text = "Anmeldung";
                Cancel_bttn.Text = "Stornieren";
                errorMessage = "Der Benutzername und das Passwort stimmten nicht überein.";


            }

            else if (CultureInfo.CurrentUICulture.LCID == 5127)
            {

                Title.Text = "Bitte melden Sie sich unten an";
                UserName_Label.Text = "Nutzername";
                Password_Label.Text = "Passwort";
                Login_Button.Text = "Anmeldung";
                Cancel_bttn.Text = "Stornieren";
                errorMessage = "Der Benutzername und das Passwort stimmten nicht überein.";


            }

            else if (CultureInfo.CurrentUICulture.LCID == 4103)
            {

                Title.Text = "Bitte melden Sie sich unten an";
                UserName_Label.Text = "Nutzername";
                Password_Label.Text = "Passwort";
                Login_Button.Text = "Anmeldung";
                Cancel_bttn.Text = "Stornieren";
                errorMessage = "Der Benutzername und das Passwort stimmten nicht überein.";


            }

            else if (CultureInfo.CurrentUICulture.LCID == 2055)
            {

                Title.Text = "Bitte melden Sie sich unten an";
                UserName_Label.Text = "Nutzername";
                Password_Label.Text = "Passwort";
                Login_Button.Text = "Anmeldung";
                Cancel_bttn.Text = "Stornieren";
                errorMessage = "Der Benutzername und das Passwort stimmten nicht überein.";


            }



        }

        static public int UserSearch(string userName, string password)
        {
            MySqlConnection c = new MySqlConnection(DataHelper.conString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT userId FROM user WHERE userName = '{userName}'AND password = '{password}'", c);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                DataHelper.setCurrentUserId(Convert.ToInt32(rdr[0]));
                DataHelper.setCurrentUserName(userName);
                rdr.Close(); c.Close();
                return DataHelper.getCurrentUserId();
            }
            return 0;
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            if (UserSearch(UserName_Box.Text, Password_Box.Text) != 0)
            {
                Logger.signIn(DataHelper.getCurrentUserName());
                Logger.reminder();
                this.Hide();
                Dashboard dashboard = new Dashboard();


                dashboard.Show();
            }
            else
            {
                MessageBox.Show(errorMessage);
                Password_Box.Text = "";
            }

        }

        private void Cancel_bttn_Click(object sender, EventArgs e)
        {
            UserName_Box.Text = "";
            Password_Box.Text = "";

        }
    }
}
