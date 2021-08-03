using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace C868
{
    public partial class Dashboard : Form
    {
        bool isCustomerMenuPanelopen = false;
        bool isReportMenuPanelopen = false;
        bool isAppointmentMenuPanelopen = false;
        bool isDoctorsMenuPanelopen = false;
        public Login loginForm;
        public static string dataString = DataHelper.getConString();
        public Dashboard()
        {
            InitializeComponent();
            this.Activated += new System.EventHandler(this.Dashboard_Activated);

        }
        private void Dashboard_Load(bool week)
        {
            DateTime filter = week ? calcDateFilter("week") : calcDateFilter("month");
            DataTable dtRecord = DataHelper.dashboard(DataHelper.dateSQLFormat(filter), week);
            Calender_DGV.DataSource = dtRecord;
            DataHelper.expired_record_delete();
        }
        public DateTime calcDateFilter(string type)
        {
            if (type == "week")
            {
                DateTime week = DateTime.Now.AddDays(7);
                return week;
            }
            else
            {
                DateTime month = DateTime.Now.AddMonths(1);
                return month;
            }
        }

        private void Dashboard_Activated(object sender, EventArgs e)
        {
            Dashboard_Load(Week_rad_bttn.Checked);


        }
        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logger.signOut(DataHelper.getCurrentUserName());
        }




        public DataTable ConvertToDataTable(string filePath, int numberOfColumns)
        {
            DataTable tbl = new DataTable();

            for (int col = 0; col < numberOfColumns; col++)
                tbl.Columns.Add(new DataColumn("Column" + (col + 1).ToString()));


            string[] lines = System.IO.File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                var cols = line.Split(':');

                DataRow dr = tbl.NewRow();
                for (int cIndex = 0; cIndex < 3; cIndex++)
                {
                    dr[cIndex] = cols[cIndex];
                }

                tbl.Rows.Add(dr);
            }

            return tbl;
        }


        private void Create_customer_bttn_Click(object sender, EventArgs e)
        {
            Form createCustomer = new CreateCustomer();
            createCustomer.Owner = this;
            createCustomer.Show();
            this.Hide();
        }

        private void Customer_Update_bttn_Click(object sender, EventArgs e)
        {
            Form updateCustomer = new UpdateCustomer();
            updateCustomer.Owner = this;
            updateCustomer.Show();
            this.Hide();
        }

        private void Customer_Delete_bttn_Click(object sender, EventArgs e)
        {
            Form deleteCustomer = new DeleteCustomer();
            deleteCustomer.Owner = this;
            deleteCustomer.Show();
            this.Hide();
        }

        private void Number_of_Apps_bttn_Click(object sender, EventArgs e)
        {
            Form numberOfAppointmentsReport = new NumberOfAppointmentsReport();
            numberOfAppointmentsReport.Owner = this;
            numberOfAppointmentsReport.Show();
            this.Hide();
        }

        private void Consult_sched_bttn_Click(object sender, EventArgs e)
        {
            Form consultantSchedule = new ConsultantSchedule();
            consultantSchedule.Owner = this;
            consultantSchedule.Show();
            this.Hide();
        }

        private void Customer_Report_bttn_Click(object sender, EventArgs e)
        {
            Form customerReport = new CustomerReport();
            customerReport.Owner = this;
            customerReport.Show();
            this.Hide();
        }

        private void Add_Appointment_bttn_Click(object sender, EventArgs e)
        {
            AddAppointment addAppointment = new AddAppointment();
            addAppointment.Owner = this;
            addAppointment.Show();
            this.Hide();
        }

        private void Update_Appointment_bttn_Click(object sender, EventArgs e)
        {
            Form updateAppointment = new UpdateAppointment();
            updateAppointment.Owner = this;
            updateAppointment.Show();
            this.Hide();
        }

        private void Delete_Appointment_bttn_Click(object sender, EventArgs e)
        {
            Form deleteAppointment = new DeleteAppointment();
            deleteAppointment.Owner = this;
            deleteAppointment.Show();
            this.Hide();
        }

        private void Create_doctor_Button_Click(object sender, EventArgs e)
        {
            Form createDoctor = new CreateDoctor();
            createDoctor.Owner = this;
            createDoctor.Show();
            this.Hide();
        }

        private void Delete_doctor_Button_Click(object sender, EventArgs e)
        {
            Form deleteDoctor = new DeleteDoctor();
            deleteDoctor.Owner = this;
            deleteDoctor.Show();
            this.Hide();
        }

        private void LogOut_bttn_Click(object sender, EventArgs e)
        {
            Close();
            Login login = new Login();
            login.Show();
        }



        private void Customer_Access_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCustomerMenuPanelopen)
            {
                CustomerMenuPanel.Height -= 20;
                if (CustomerMenuPanel.Height == 0)
                {
                    timer1.Stop();
                    isCustomerMenuPanelopen = false;
                }
            }
            else if (!isCustomerMenuPanelopen)
            {
                CustomerMenuPanel.Height += 20;
                if (CustomerMenuPanel.Height == 160)
                {
                    timer1.Stop();
                    isCustomerMenuPanelopen = true;
                }

                if (isReportMenuPanelopen)
                {
                    ReportsMenuPanel.Height -= 20;
                    if (ReportsMenuPanel.Height == 0)
                    {
                        timer2.Stop();
                        isReportMenuPanelopen = false;
                    }
                }

                if (isAppointmentMenuPanelopen)
                {
                    AppointmentMenuPanel.Height -= 6;
                    if (AppointmentMenuPanel.Height == 0)
                    {
                        timer3.Stop();
                        isAppointmentMenuPanelopen = false;
                    }
                }

                if(isDoctorsMenuPanelopen)
                {
                    DoctorMenuPanel.Height -= 20;
                    if(DoctorMenuPanel.Height == 0)
                    {
                        timer4.Stop();
                        isDoctorsMenuPanelopen = false;
                    }
                }
            }
        }



        private void Reports_label_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isReportMenuPanelopen)
            {
                ReportsMenuPanel.Height -= 20;
                if (ReportsMenuPanel.Height == 0)
                {
                    timer2.Stop();
                    isReportMenuPanelopen = false;
                }
            }
            else if (!isReportMenuPanelopen)
            {
                ReportsMenuPanel.Height += 20;
                if (ReportsMenuPanel.Height == 160)
                {
                    timer2.Stop();
                    isReportMenuPanelopen = true;
                }

                if (isCustomerMenuPanelopen)
                {
                    CustomerMenuPanel.Height -= 20;
                    if (CustomerMenuPanel.Height == 0)
                    {
                        timer1.Stop();
                        isCustomerMenuPanelopen = false;
                    }
                }

                if (isAppointmentMenuPanelopen)
                {
                    AppointmentMenuPanel.Height -= 6;
                    if (AppointmentMenuPanel.Height == 0)
                    {
                        timer3.Stop();
                        isAppointmentMenuPanelopen = false;
                    }
                }

                if (isDoctorsMenuPanelopen)
                {
                    DoctorMenuPanel.Height -= 20;
                    if (DoctorMenuPanel.Height == 0)
                    {
                        timer4.Stop();
                        isDoctorsMenuPanelopen = false;
                    }
                }
            }
        }


        private void Appointment_control_label_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (isAppointmentMenuPanelopen)
            {
                AppointmentMenuPanel.Height -= 5;
                if (AppointmentMenuPanel.Height == 0)
                {
                    timer3.Stop();
                    isAppointmentMenuPanelopen = false;
                }
            }
            else if (!isAppointmentMenuPanelopen)
            {
                AppointmentMenuPanel.Height += 5;
                if (AppointmentMenuPanel.Height == 40)
                {
                    timer3.Stop();
                    isAppointmentMenuPanelopen = true;
                }

                if (isCustomerMenuPanelopen)
                {
                    CustomerMenuPanel.Height -= 20;
                    if (CustomerMenuPanel.Height == 0)
                    {
                        timer1.Stop();
                        isCustomerMenuPanelopen = false;
                    }
                }

                if (isReportMenuPanelopen)
                {
                    ReportsMenuPanel.Height -= 20;
                    if (ReportsMenuPanel.Height == 0)
                    {
                        timer2.Stop();
                        isReportMenuPanelopen = false;
                    }
                }
               
                if (isDoctorsMenuPanelopen)
                {
                    DoctorMenuPanel.Height -= 20;
                    if (DoctorMenuPanel.Height == 0)
                    {
                        timer4.Stop();
                        isDoctorsMenuPanelopen = false;
                    }
                }
            }
        }

        private void DoctorAccess_Label_Click(object sender, EventArgs e)
        {
            timer4.Start();
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (isDoctorsMenuPanelopen)
            {
                DoctorMenuPanel.Height -= 20;
                if (DoctorMenuPanel.Height == 0)
                {
                    timer4.Stop();
                    isDoctorsMenuPanelopen = false;
                }
            }
            else if(!isDoctorsMenuPanelopen)
            {
                DoctorMenuPanel.Height += 15;
                if(DoctorMenuPanel.Height == 120)
                {
                    timer4.Stop();
                    isDoctorsMenuPanelopen = true;
                }

                if (isCustomerMenuPanelopen)
                {
                    CustomerMenuPanel.Height -= 20;
                    if (CustomerMenuPanel.Height == 0)
                    {
                        timer1.Stop();
                        isCustomerMenuPanelopen = false;
                    }
                }

                if (isReportMenuPanelopen)
                {
                    ReportsMenuPanel.Height -= 20;
                    if (ReportsMenuPanel.Height == 0)
                    {
                        timer2.Stop();
                        isReportMenuPanelopen = false;
                    }
                }

                if (isAppointmentMenuPanelopen)
                {
                    AppointmentMenuPanel.Height -= 6;
                    if (AppointmentMenuPanel.Height == 0)
                    {
                        timer3.Stop();
                        isAppointmentMenuPanelopen = false;
                    }
                }
            }
        }

        private void Week_rad_bttn_CheckedChanged(object sender, EventArgs e)
        {
            Dashboard_Load(Week_rad_bttn.Checked);
        }

        
    }
}
