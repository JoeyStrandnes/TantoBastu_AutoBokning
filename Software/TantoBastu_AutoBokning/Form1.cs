using System;
using System.Text.RegularExpressions;
using System.Threading;

using TantoBastu_AutoBokning.Properties;

namespace TantoBastu_AutoBokning
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TB_UserName.Text = Properties.Settings.Default.Username;
            TB_Password.Text = Properties.Settings.Default.Password;
            CB_BookingTimes.SelectedIndex = Properties.Settings.Default.SelectedTimeIndex;

            CB_RetryBooking.Checked = Properties.Settings.Default.RetryBooking;
            CB_HostSession.Checked = Properties.Settings.Default.HostSession;

        }

        private void BT_Book_Click(object sender, EventArgs e)
        {

            GB_Settings.Enabled = false;

            //Load the user input and store it to the NVM.
            Properties.Settings.Default.Username = TB_UserName.Text;
            Properties.Settings.Default.Password = TB_Password.Text;
            Properties.Settings.Default.SelectedTimeIndex = CB_BookingTimes.SelectedIndex;

            Properties.Settings.Default.RetryBooking = CB_RetryBooking.Checked;
            Properties.Settings.Default.HostSession = CB_HostSession.Checked;

            Properties.Settings.Default.Save();

            Program.NumberOfExtraBookings = (Int32)NUM_AdditionalBooking.Value; //Limited to 3.

            Program.ErrorCodes BookingStatus = Program.BookSaunaTime(DT_BookingDatePicker.Value, CB_BookingTimes.SelectedItem.ToString());

            switch (BookingStatus)
            {
                
                case (Program.ErrorCodes.BookingFull):
                    if (Properties.Settings.Default.RetryBooking == true)
                    {
                        Timer_PollingIntervall.Start();
                    }
                    break;
            case (Program.ErrorCodes.WrongCredentials):
            case (Program.ErrorCodes.BookingSucceeded):
                    Timer_PollingIntervall.Stop();
                    GB_Settings.Enabled = true;
                    break;


            }

            return;

        }

        private void Timer_PollingIntervall_Tick(object sender, EventArgs e)
        {

            Program.ErrorCodes BookingStatus = Program.BookSaunaTime(DT_BookingDatePicker.Value, CB_BookingTimes.SelectedItem.ToString());

            switch (BookingStatus)
            {
                case (Program.ErrorCodes.BookingFull):
                    if (Properties.Settings.Default.RetryBooking == true)
                    {
                        Timer_PollingIntervall.Start();
                    }
                    break;
                case (Program.ErrorCodes.WrongCredentials):
                case (Program.ErrorCodes.BookingSucceeded):
                    Timer_PollingIntervall.Stop();
                    GB_Settings.Enabled = true;
                    break;


            }


            return;

        }

        private void BT_EmailSettings_Click(object sender, EventArgs e)
        {
            EmailForm Form = new EmailForm();
            Form.ShowDialog();

            return;
        }
    }
}
