using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C868
{
    class DataHelper
    {
        private static Dictionary<int, Hashtable> _appointments = new Dictionary<int, Hashtable>();
        private static int _currentUserId;
        private static string _currentUserName;
        public static string conString = "server=c868.clbnm6qazoes.us-east-2.rds.amazonaws.com; port=3306; user id=admin; database=c868; password=Kaleb525; convert zero datetime=True ";

        public static string dateSQLFormat(DateTime dateValue)
        {
            string formatForMySql = dateValue.ToString("yyyy-MM-dd HH:mm");

            return formatForMySql;
        }
        public static int getCurrentUserId()
        {
            return _currentUserId;
        }

        public static void setCurrentUserId(int currentUserId)
        {
            _currentUserId = currentUserId;
        }

        public static string getCurrentUserName()
        {
            return _currentUserName;
        }

        public static void setCurrentUserName(string currentUserName)
        {
            _currentUserName = currentUserName;
        }

        public static Dictionary<int, Hashtable> getAppointments()
        {
            return _appointments;
        }

        public static void setAppointments(Dictionary<int, Hashtable> appointments)
        {
            _appointments = appointments;
        }
        public static string getConString()
        {
            return conString;
        }

        public static DataTable dashboard(string filter, bool week)
        {

            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();
            //Week filter where end date and start date are less than a week away
            //Month filter where end date and start date are less than a month away
            string query = week ? $"SELECT (select customerName from customer where customerId = appointment.customerId) as 'Patient', (select doctorName from doctor where doctorId = appointment.doctorId) as 'Doctor',  start as 'Start Time', end as 'End Time', location as 'Location', type as 'Type' FROM appointment where start < '{filter}' and end < '{filter}' and createdBy = '{DataHelper.getCurrentUserId()}' and end > now() order by start;"
                : $"SELECT  (select customerName from customer where customerId = appointment.customerId) as 'Patient', (select doctorName from doctor where doctorId = appointment.doctorId) as 'Doctor', start as 'Start Time', end as 'End Time', location as 'Location', type as 'Type' FROM appointment where start < '{filter}' and end < '{filter}' and createdBy = '{DataHelper.getCurrentUserId()}' and end > now() order by start;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            //Converts the time to localtime from utc in DB
            foreach (DataRow row in dt.Rows)
            {
                DateTime utcStart = Convert.ToDateTime(row["Start Time"]);
                DateTime utcEnd = Convert.ToDateTime(row["End Time"]);
                row["Start Time"] = TimeZone.CurrentTimeZone.ToLocalTime(utcStart);
                row["End Time"] = TimeZone.CurrentTimeZone.ToLocalTime(utcEnd);
            }

            conn.Close();
            return dt;

        }

        public static DataTable getReport()
        {
            MySqlConnection c = new MySqlConnection(DataHelper.conString);
            c.Open();
            string query = $" SELECT (select  customerName from customer where customerId = appointment.customerId) as 'Customer', COUNT(appointmentId) as 'Appointments' FROM appointment GROUP BY customerId";
            MySqlCommand cmd = new MySqlCommand(query, c);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            c.Close();
            return dt;
        }
        public static DateTime getDateTime()
        {
            return DateTime.Now.ToUniversalTime();

        }
        public static int newID(List<int> idList)
        {
            int highestID = 0;
            foreach (int id in idList)
            {
                if (id > highestID)
                    highestID = id;
            }
            return highestID + 1;
        }

        public static string createTimestamp()
        {
            return DateTime.Now.ToString("u");
        }

        public static int createID(string table)
        {
            MySqlConnection c = new MySqlConnection(conString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT {table + "Id"} FROM {table}", c);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<int> idList = new List<int>();
            while (rdr.Read())
            {
                idList.Add(Convert.ToInt32(rdr[0]));
            }
            rdr.Close();
            c.Close();
            return newID(idList);
        }


        public static void createCustomer(int id, string name, int addressId, int active, DateTime dateTime, string user)
        {

            string sqlDate = dateSQLFormat(dateTime);

            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();

            MySqlTransaction transaction = conn.BeginTransaction();


            var query = "INSERT into customer (customerId, customerName, addressId,active, createDate, createdBy, lastUpdateBy) " +
                        $"VALUES ('{id}', '{name}',  '{addressId}', '{active}', '{dateSQLFormat(dateTime)}', '{user}', '{user}')";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
            transaction.Commit();
            conn.Close();
        }

        public static void createDoctor(int id, string name, string phone, string type, int active, DateTime dateTime, string user)
        {
            string sqlDate = dateSQLFormat(dateTime);
            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();

            MySqlTransaction transaction = conn.BeginTransaction();

            var query = "INSERT into doctor (doctorId, doctorName, phone, type, active, createDate, createdBy, lastUpdateBy)" +
                $"VALUES('{id}','{name}','{phone}','{type}','{active}','{dateSQLFormat(dateTime)}', '{user}', '{user}')";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
            transaction.Commit();
            conn.Close();
        }

        public static int createCountry(string country)
        {

            int countryID = getID("country", "countryID") + 1;
            string user = getCurrentUserName();
            DateTime utc = getDateTime();


            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();

            MySqlTransaction transaction = conn.BeginTransaction();

            var query = "INSERT into country (countryID, country, createDate, createdBy, lastUpdateBy) " +
                        $"VALUES ('{countryID}', '{country}', '{dateSQLFormat(utc)}','{user}', '{user}')";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
            transaction.Commit();
            conn.Close();

            return countryID;
        }

        public static int getID(string table, string id)
        {

            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();
            var query = $"SELECT max({id}) FROM {table}";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                if (rdr[0] == DBNull.Value)
                {

                    return 0;
                }


                return Convert.ToInt32(rdr[0]); ;


            }

            return 0;
        }
        public static int createCity(int countryID, string city)
        {
            int cityID = getID("city", "cityId") + 1;
            string user = getCurrentUserName();
            DateTime utc = getDateTime();

            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();

            MySqlTransaction transaction = conn.BeginTransaction();

            var query = "INSERT into city (cityId, city, countryId, createDate, createdBy, lastUpdateBy) " +
                        $"VALUES ('{cityID}', '{city}', '{countryID}', '{dateSQLFormat(utc)}','{user}', '{user}')";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
            transaction.Commit();
            conn.Close();

            return cityID;

        }

        public static int createAddress(int cityID, string address, string postalCode, string phone)
        {

            int addressID = getID("address", "addressId") + 1;
            string user = getCurrentUserName();
            DateTime utc = getDateTime();

            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();

            MySqlTransaction transaction = conn.BeginTransaction();

            var query = "INSERT into address (addressId, address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdateBy) " +
                        $"VALUES ('{addressID}', '{address}', 0, '{cityID}', '{postalCode}', '{phone}', '{dateSQLFormat(utc)}','{user}', '{user}')";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
            transaction.Commit();
            conn.Close();

            return addressID;
        }
        public static List<KeyValuePair<string, object>> searchDoctor(int doctorID)
        {
            var list = new List<KeyValuePair<string, object>>();
            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();
            var query = $"SELECT * FROM doctor WHERE doctorId = {doctorID}";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            MySqlDataReader rdr = cmd.ExecuteReader();
            try
            {
                if(rdr.HasRows)
                {
                    rdr.Read();
                    list.Add(new KeyValuePair<string, object>("doctorId", rdr[0]));
                    list.Add(new KeyValuePair<string, object>("doctorName", rdr[1]));
                    list.Add(new KeyValuePair<string, object>("phone", rdr[2]));
                    list.Add(new KeyValuePair<string, object>("type", rdr[3]));
                    list.Add(new KeyValuePair<string, object>("active", rdr[4]));
                    rdr.Close();
                }
                else
                {
                    MessageBox.Show("No Doctor forund with the ID:" + doctorID, "Please try again");
                    return null;
                }

                return list;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public static List<KeyValuePair<string, object>> searchCustomer(int customerID)
        {
            var list = new List<KeyValuePair<string, object>>();
            //Get customer Table info
            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();
            var query = $"SELECT * FROM customer WHERE customerId = {customerID}";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            MySqlDataReader rdr = cmd.ExecuteReader();
            try
            {
                if (rdr.HasRows)
                {
                    rdr.Read();
                    list.Add(new KeyValuePair<string, object>("customerId", rdr[0]));
                    list.Add(new KeyValuePair<string, object>("customerName", rdr[1]));
                    list.Add(new KeyValuePair<string, object>("addressId", rdr[2]));
                    list.Add(new KeyValuePair<string, object>("active", rdr[3]));
                    rdr.Close();
                }
                else
                {
                    MessageBox.Show("No Customer found with the ID: " + customerID, "Please try again");
                    return null;
                }
                var addressID = list.First(kvp => kvp.Key == "addressId").Value;

                var query2 = $"SELECT * FROM address WHERE addressId = {addressID}";
                cmd.CommandText = query2;
                cmd.Connection = conn;
                MySqlDataReader rdr2 = cmd.ExecuteReader();
                if (rdr2.HasRows)
                {
                    rdr2.Read();
                    list.Add(new KeyValuePair<string, object>("address", rdr2[1]));
                    list.Add(new KeyValuePair<string, object>("cityId", rdr2[3]));
                    list.Add(new KeyValuePair<string, object>("postalCode", rdr2[4]));
                    list.Add(new KeyValuePair<string, object>("phone", rdr2[5]));
                    rdr2.Close();
                }

                //Get city info now that we have cityID
                var cityID = list.First(kvp => kvp.Key == "cityId").Value;

                var query3 = $"SELECT * FROM city WHERE cityId = {cityID}";
                cmd.CommandText = query3;
                cmd.Connection = conn;
                MySqlDataReader rdr3 = cmd.ExecuteReader();
                if (rdr3.HasRows)
                {
                    rdr3.Read();
                    list.Add(new KeyValuePair<string, object>("city", rdr3[1]));
                    list.Add(new KeyValuePair<string, object>("countryId", rdr3[2]));
                    rdr3.Close();
                }

                //Get country info now that we have countryId
                var countryID = list.First(kvp => kvp.Key == "countryId").Value;

                var query4 = $"SELECT * FROM country WHERE countryId = {countryID}";
                cmd.CommandText = query4;
                cmd.Connection = conn;
                MySqlDataReader rdr4 = cmd.ExecuteReader();
                if (rdr4.HasRows)
                {
                    rdr4.Read();
                    list.Add(new KeyValuePair<string, object>("country", rdr4[1]));
                    rdr4.Close();
                }

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public static List<KeyValuePair<string, object>> searchAppointment(int appointmentID)
        {
            var list = new List<KeyValuePair<string, object>>();
            //Get customer Table info
            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();
            var query = $"SELECT * FROM appointment WHERE appointmentId = {appointmentID}";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            MySqlDataReader rdr = cmd.ExecuteReader();
            try
            {
                if (rdr.HasRows)
                {
                    rdr.Read();
                    list.Add(new KeyValuePair<string, object>("appointmentId", rdr[0]));
                    list.Add(new KeyValuePair<string, object>("customerId", rdr[1]));
                    list.Add(new KeyValuePair<string, object>("doctorId", rdr[2]));
                    list.Add(new KeyValuePair<string, object>("title", rdr[4]));
                    list.Add(new KeyValuePair<string, object>("description", rdr[5]));
                    list.Add(new KeyValuePair<string, object>("location", rdr[6]));
                    list.Add(new KeyValuePair<string, object>("contact", rdr[7]));
                    list.Add(new KeyValuePair<string, object>("type", rdr[8]));
                    list.Add(new KeyValuePair<string, object>("start", rdr[9]));
                    list.Add(new KeyValuePair<string, object>("end", rdr[10]));
                    rdr.Close();
                }
                else
                {
                    MessageBox.Show("No Appointment found with the ID: " + appointmentID, "Please try again");
                    return null;
                }

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public static void updateCustomer(IDictionary<string, object> dictionary)
        {
            string user = getCurrentUserName();
            DateTime utc = getDateTime();

            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();
            MySqlTransaction transaction = conn.BeginTransaction();
            var query = $"UPDATE country" +
                $" SET country = '{dictionary["country"]}', lastUpdateBy = '{user}'" +
                $" WHERE countryId = '{dictionary["countryId"]}'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
            transaction.Commit();

            // Start a city transaction.
            transaction = conn.BeginTransaction();
            var query2 = $"UPDATE city" +
                $" SET city = '{dictionary["city"]}', lastUpdateBy = '{user}'" +
                $" WHERE cityId = '{dictionary["cityId"]}'";
            cmd.CommandText = query2;
            cmd.Connection = conn;
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
            transaction.Commit();

            // Start a address transaction.
            transaction = conn.BeginTransaction();
            var query3 = $"UPDATE address" +
                $" SET address = '{dictionary["address"]}', lastUpdateBy = '{user}', postalCode = '{dictionary["postalCode"]}', phone = '{dictionary["phone"]}'" +
                $" WHERE addressId = '{dictionary["addressId"]}'";
            cmd.CommandText = query3;
            cmd.Connection = conn;
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
            transaction.Commit();

            // Start a customer transaction.
            transaction = conn.BeginTransaction();
            var query4 = $"UPDATE customer" +
                $" SET customerName = '{dictionary["customerName"]}', lastUpdateBy = '{user}', active = '{dictionary["active"]}'" +
                $" WHERE customerId = '{dictionary["customerId"]}'";
            cmd.CommandText = query4;
            cmd.Connection = conn;
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
            transaction.Commit();
            conn.Close();
        }

        //Deletes customer 
        public static void deleteCustomer(IDictionary<string, object> dictionary)
        {
            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();
            var query4 = $"DELETE FROM customer" +
               $" WHERE customerId = '{dictionary["customerId"]}'";
            MySqlCommand cmd = new MySqlCommand(query4, conn);
            MySqlTransaction transaction = conn.BeginTransaction();

            cmd.CommandText = query4;
            cmd.Connection = conn;
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
            transaction.Commit();


            // Start a address transaction.
            transaction = conn.BeginTransaction();
            var query3 = $"DELETE FROM address" +
                $" WHERE addressId = '{dictionary["addressId"]}'";
            cmd.CommandText = query3;
            cmd.Connection = conn;
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
            transaction.Commit();

            // Start a city transaction.
            transaction = conn.BeginTransaction();
            var query2 = $"DELETE FROM city" +
                $" WHERE cityId = '{dictionary["cityId"]}'";
            cmd.CommandText = query2;
            cmd.Connection = conn;
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
            transaction.Commit();

            // Start a country transaction.
            transaction = conn.BeginTransaction();
            var query = $"DELETE FROM country" +
                $" WHERE countryId = '{dictionary["countryId"]}'";
            cmd.CommandText = query;
            cmd.Connection = conn;
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
            transaction.Commit();
            conn.Close();

        }

        public static void deleteDoctor(IDictionary<string, object> dictionary)
        {
            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();
            var query = $"DELETE FROM doctor" +
                $" WHERE doctorId = '{dictionary["doctorId"]}'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlTransaction transaction = conn.BeginTransaction();

            cmd.CommandText = query;
            cmd.Connection = conn;
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
            transaction.Commit();
            conn.Close();
        }

        public static void createAppointment(int custID, int docID, string title, string description, string location, string contact, string type, DateTime start, DateTime endTime)
        {
            int appointID = getID("appointment", "appointmentId") + 1;
            int userID = 1;

            DateTime utc = getDateTime();

            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();
            MySqlTransaction transaction = conn.BeginTransaction(); ;
            // Start a local transaction.
            var query = "INSERT into appointment (appointmentId, customerId, userId, doctorId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdateBy) " +
                        $"VALUES ('{appointID}', '{custID}','{userID}', '{docID}', '{title}', '{description}', '{location}', '{contact}', '{type}', '{custID}', '{dateSQLFormat(start)}','{dateSQLFormat(endTime)}','{dateSQLFormat(utc)}','{userID}','{userID}')";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
            transaction.Commit();
            conn.Close();

        }
        //Updates appointment
        public static void updateAppointment(IDictionary<string, object> dictionary)
        {
            string user = getCurrentUserName();
            DateTime utc = getDateTime();
            DateTime start = Convert.ToDateTime(dictionary["start"]);
            DateTime end = Convert.ToDateTime(dictionary["end"]);

            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();
            var query = $"UPDATE appointment" +
                $" SET customerId = '{dictionary["customerId"]}', " +
                $"  doctorId = '{dictionary["doctorId"]}'," +
                $" type = '{dictionary["type"]}' , location = '{dictionary["location"]}',  start = '{dateSQLFormat(start.ToUniversalTime())}' , end = '{dateSQLFormat(end.ToUniversalTime())}' , url = '{dictionary["url"]}' , lastUpdate = '{dateSQLFormat(utc)}',  lastUpdateBy = '{user}'" +
                $" WHERE appointmentId = '{dictionary["appointmentId"]}'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlTransaction transaction = conn.BeginTransaction();
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
            transaction.Commit();
            conn.Close();
        }

        //Deletes appointment
        public static void deleteAppointment(IDictionary<string, object> dictionary)
        {
            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();
            var query = $"DELETE FROM appointment" +
               $" WHERE appointmentId = '{dictionary["appointmentId"]}'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlTransaction transaction = conn.BeginTransaction();
            cmd.CommandText = query;
            cmd.Connection = conn;
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
            transaction.Commit();
            conn.Close();
        }

        //Returns dictionary of next appointment
        public static Dictionary<string, object> getNextAppointInfo()
        {
            Dictionary<string, object> appointINFO = new Dictionary<string, object>();

            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();
            var query = " Select start, (select customerName from customer where customerId = appointment.customerId ) as 'Name' from appointment  where start > now() order by  start limit 1;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Read();
                appointINFO.Add("start", Convert.ToDateTime(rdr[0]).ToLocalTime());
                appointINFO.Add("name", rdr[1]);
            }


            return appointINFO;
        }

        public static int overlap(DateTime start, DateTime end)
        {
            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();
            var query = $"SELECT count(*) FROM `appointment` WHERE (('{dateSQLFormat(start.ToUniversalTime())}' > start and '{dateSQLFormat(start.ToUniversalTime())}' < end) or ('{dateSQLFormat(end.ToUniversalTime())}'> start and '{dateSQLFormat(end.ToUniversalTime())}' < end)) and end > now() order by  start limit 1;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Read();
                string count = rdr[0].ToString();
                int result = count == "0" ? 0 : 1;
                return result;
            }
            return 0;
        }

        //Returns datatable for schedule
        public static DataTable schedule(string id)
        {

            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();

            string query = $"SELECT (select doctorName from doctor where doctorId = appointment.doctorId) as 'Doctor', (select customerName from customer where customerId = appointment.customerId) as 'Customer',  start as 'Start Time', end as 'End Time', location as 'Location', title as 'Title' FROM appointment where doctorId = '{id}' order by start;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            //Converts the time to localtime from utc in DB
            foreach (DataRow row in dt.Rows)
            {
                DateTime utcStart = Convert.ToDateTime(row["Start Time"]);
                DateTime utcEnd = Convert.ToDateTime(row["End Time"]);
                row["Start Time"] = TimeZone.CurrentTimeZone.ToLocalTime(utcStart);
                row["End Time"] = TimeZone.CurrentTimeZone.ToLocalTime(utcEnd);
            }

            conn.Close();
            return dt;
        }
        //Returns dictionary for report on appointments
        public static Dictionary<string, object> reportAppoint(string item)
        {
            Dictionary<string, object> reportINFO = new Dictionary<string, object>();

            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();
            var query = $"select distinct" +
                $"              (select count(type) from appointment where type = '{item}' and MONTH(appointment.start) = 1) as 'Jan'," +
                $"                (select count(type) from appointment where type = '{item}' and MONTH(appointment.start) = 2) as 'Feb'," +
                $"                (select count(type) from appointment where type = '{item}' and MONTH(appointment.start) = 3) as 'Mar'," +
                $"                (select count(type) from appointment where type = '{item}' and MONTH(appointment.start) = 4) as 'Apr'," +
                $"                (select count(type) from appointment where type = '{item}' and MONTH(appointment.start) = 5) as 'May'," +
                $"            (select count(type) from appointment where type = '{item}' and MONTH(appointment.start) = 6) as 'Jun'," +
                $"                (select count(type) from appointment where type = '{item}' and MONTH(appointment.start) = 7) as 'Jul'," +
                $"                (select count(type) from appointment where type = '{item}' and MONTH(appointment.start) = 8) as 'Aug'," +
                $"                (select count(type) from appointment where type = '{item}' and MONTH(appointment.start) = 9) as 'Sep'," +
                $"            (select count(type) from appointment where type = '{item}' and MONTH(appointment.start) = 10) as 'Oct'," +
                $"                (select count(type) from appointment where type = '{item}' and MONTH(appointment.start) = 11) as 'Nov'," +
                $"                (select count(type) from appointment where type = '{item}' and MONTH(appointment.start) = 12) as 'Dec'" +
                $"            from appointment;";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Read();
                reportINFO.Add("Jan", rdr[0]);
                reportINFO.Add("Feb", rdr[1]);
                reportINFO.Add("Mar", rdr[2]);
                reportINFO.Add("Apr", rdr[3]);
                reportINFO.Add("May", rdr[4]);
                reportINFO.Add("Jun", rdr[5]);
                reportINFO.Add("Jul", rdr[6]);
                reportINFO.Add("Aug", rdr[7]);
                reportINFO.Add("Sep", rdr[8]);
                reportINFO.Add("Oct", rdr[9]);
                reportINFO.Add("Nov", rdr[10]);
                reportINFO.Add("Dec", rdr[11]);
            }

            return reportINFO;
        }
        //Returns true if customerId is assoicated with appointment
        public static bool appointExist(string custID)
        {
            Console.WriteLine(custID);

            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();
            var query = $"select* from appointment where customerId = '{custID}'";


            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Read();
                return true;
            }
            return false;
        }
        //removes all appointments with customerId
        public static void noCustAppointments(string custID)
        {
            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();
            var query = $"DELETE FROM appointment" +
               $" WHERE customerId = '{custID}'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlTransaction transaction = conn.BeginTransaction();
            cmd.CommandText = query;
            cmd.Connection = conn;
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
            transaction.Commit();
            conn.Close();
        }

        public static void noDocAppointments(string docID)
        {
            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();
            var query = $"DELETE FROM appointment" +
               $" WHERE doctorId = '{docID}'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlTransaction transaction = conn.BeginTransaction();
            cmd.CommandText = query;
            cmd.Connection = conn;
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
            transaction.Commit();
            conn.Close();
        }

        static public int findCustomer(string search)
        {
            int customerId;
            string query;
            if (int.TryParse(search, out customerId))
            {
                query = $"SELECT customerId FROM customer WHERE customerId = '{search.ToString()}'";
            }
            else
            {
                query = $"SELECT customerId FROM customer WHERE customerName LIKE '{search}'";
            }
            MySqlConnection c = new MySqlConnection(conString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand(query, c);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                customerId = Convert.ToInt32(rdr[0]);
                rdr.Close(); c.Close();
                return customerId;
            }
            return 0;
        }

        static public Dictionary<string, string> getCustomerDetails(int customerId)
        {
            string query = $"SELECT * FROM customer WHERE customerId = '{customerId.ToString()}'";
            MySqlConnection c = new MySqlConnection(conString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand(query, c);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();

            Dictionary<string, string> customerDict = new Dictionary<string, string>();
            customerDict.Add("customerName", rdr[1].ToString());
            customerDict.Add("addressId", rdr[2].ToString());
            customerDict.Add("active", rdr[3].ToString());
            rdr.Close();

            query = $"SELECT * FROM address WHERE addressId = '{customerDict["addressId"]}'";
            cmd = new MySqlCommand(query, c);
            rdr = cmd.ExecuteReader();
            rdr.Read();

            customerDict.Add("address", rdr[1].ToString());
            customerDict.Add("cityId", rdr[3].ToString());
            customerDict.Add("zip", rdr[4].ToString());
            customerDict.Add("phone", rdr[5].ToString());
            rdr.Close();

            query = $"SELECT * FROM city WHERE cityId = '{customerDict["cityId"]}'";
            cmd = new MySqlCommand(query, c);
            rdr = cmd.ExecuteReader();
            rdr.Read();

            customerDict.Add("city", rdr[1].ToString());
            customerDict.Add("countryId", rdr[2].ToString());
            rdr.Close();

            query = $"SELECT * FROM country WHERE countryId = '{customerDict["countryId"]}'";
            cmd = new MySqlCommand(query, c);
            rdr = cmd.ExecuteReader();
            rdr.Read();

            customerDict.Add("country", rdr[1].ToString());
            rdr.Close();
            c.Close();
            return customerDict;
        }

        static public int findAppointment(string search)
        {
            int appointmentId;
            string query;
            if (int.TryParse(search, out appointmentId))
            {
                query = $"SELECT appointmentId FROM appointment WHERE appointmentId = '{search.ToString()}'";
            }
            else
            {
                query = $"SELECT appointmentId FROM appointment WHERE appointmentId = '{search}'";
            }
            MySqlConnection c = new MySqlConnection(conString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand(query, c);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                appointmentId = Convert.ToInt32(rdr[0]);
                rdr.Close(); c.Close();
                return appointmentId;
            }
            return 0;
        }

        static public Dictionary<string, string> getAppointmentDetails(int appointmentId)
        {
            string query = $"SELECT * FROM appointment WHERE appointmentId = '{appointmentId.ToString()}'";
            MySqlConnection c = new MySqlConnection(conString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand(query, c);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();

            Dictionary<string, string> appointmentDict = new Dictionary<string, string>();
            appointmentDict.Add("customerId", rdr[1].ToString());
            appointmentDict.Add("type", rdr[7].ToString());
            appointmentDict.Add("start", rdr[9].ToString());
            appointmentDict.Add("end", rdr[10].ToString());
            rdr.Close();

            return appointmentDict;
        }

        static public string convertToTimezone(string dateTime)
        {
            DateTime utcDateTime = DateTime.Parse(dateTime.ToString());
            DateTime localDateTime = utcDateTime.ToLocalTime();

            return localDateTime.ToString("MM/dd/yyyy hh:mm tt");
        }

        public static void expired_record_delete ()
        {
            MySqlConnection c = new MySqlConnection(conString);
            c.Open();
            var query = $"DELETE FROM appointment WHERE end < DATE_SUB(NOW(), INTERVAL 7 DAY)";
            MySqlCommand cmd = new MySqlCommand(query, c);
            MySqlTransaction transaction = c.BeginTransaction();
            cmd.CommandText = query;
            cmd.Connection = c;
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
            transaction.Commit();
            c.Close();
        }
    }
}
