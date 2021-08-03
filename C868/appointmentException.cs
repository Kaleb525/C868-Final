using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C868
{
    class appointmentException
    {
        public void businessHours()
        {
            MessageBox.Show("Exception occured, appointments need to be within nowmal business hours");

        }

        public void appOverlap()
        {
            MessageBox.Show("exception occured, your appointment time is conflicting with an already present appointment");
        }
    }
}
