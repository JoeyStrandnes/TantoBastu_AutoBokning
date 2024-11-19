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

        }

        private void BT_Book_Click(object sender, EventArgs e)
        {

            //Load the user input and store it to the NVM.
            Program.UserName = TB_UserName.Text;
            Program.Password = TB_Password.Text;

            Properties.Settings.Default.Username = Program.UserName;
            Properties.Settings.Default.Password = Program.Password;
            Properties.Settings.Default.SelectedTimeIndex = CB_BookingTimes.SelectedIndex;

            Properties.Settings.Default.Save();

            Program.ErrorCodes BookingStatus = Program.BookSaunaTime(DT_BookingDatePicker.Value.ToString("dd"), CB_BookingTimes.SelectedItem.ToString());

            switch (BookingStatus)
            {
                case (Program.ErrorCodes.WrongCredentials):
                    Timer_PollingIntervall.Stop();
                    break;
                case (Program.ErrorCodes.BookingFull):
                    Timer_PollingIntervall.Start();
                    break;
                case (Program.ErrorCodes.BookingSucceeded):
                    Timer_PollingIntervall.Stop();
                    break;


            }

            return;

        }

        private void Timer_PollingIntervall_Tick(object sender, EventArgs e)
        {

            Program.ErrorCodes BookingStatus = Program.BookSaunaTime(DT_BookingDatePicker.Value.ToString("dd"), CB_BookingTimes.SelectedItem.ToString());

            switch (BookingStatus)
            {
                case (Program.ErrorCodes.WrongCredentials):
                    Timer_PollingIntervall.Stop();
                    break;
                case (Program.ErrorCodes.BookingFull):
                    Timer_PollingIntervall.Start();
                    break;
                case (Program.ErrorCodes.BookingSucceeded):
                    Timer_PollingIntervall.Stop();
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
