using MimeKit;

namespace TantoBastu_AutoBokning
{
    public partial class EmailForm : Form
    {
        public EmailForm()
        {
            InitializeComponent();
        }

        private void EmailForm_Load(object sender, EventArgs e)
        {

            //Populate all the fields if there is any info.

            TB_ServerEmailAddress.Text = Properties.Settings.Default.ServerEmail;
            TB_ServerEmailPassword.Text = Properties.Settings.Default.ServerEmailPassword;

            TB_SMTP_Server.Text = Properties.Settings.Default.ServerAddress;
            TB_SMTP_Port.Text = Properties.Settings.Default.ServerPort.ToString();

            TB_ClientAddress.Text = Properties.Settings.Default.Email;
            CB_SendEmail.Checked = Properties.Settings.Default.SendEmailAfterBooking;


            return;

        }

        private void EmailForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            //Save all the data before closing the form.

            Properties.Settings.Default.ServerEmail = TB_ServerEmailAddress.Text;
            Properties.Settings.Default.ServerEmailPassword = TB_ServerEmailPassword.Text;

            Properties.Settings.Default.ServerAddress = TB_SMTP_Server.Text;
            Properties.Settings.Default.ServerPort = Int32.Parse(TB_SMTP_Port.Text);

            Properties.Settings.Default.Email = TB_ClientAddress.Text;
            Properties.Settings.Default.SendEmailAfterBooking = CB_SendEmail.Checked;

            Properties.Settings.Default.Save();

            return;

        }

        private void BT_TestEmail_Click(object sender, EventArgs e)
        {


            MimeMessage Email = new MimeMessage();
            Email.From.Add(new MailboxAddress("BastuBokaren", TB_ServerEmailAddress.Text));


            Email.To.Add(new MailboxAddress("BastuBokare", TB_ClientAddress.Text));
            Email.Subject = "Bastubokare - Testmail.";
            Email.Body = new TextPart("plain")
            {
                Text = "Bastubokare - Testmail."
            };

            using (MailKit.Net.Smtp.SmtpClient SMTP = new MailKit.Net.Smtp.SmtpClient())
            {
                SMTP.Connect(TB_SMTP_Server.Text, Int32.Parse(TB_SMTP_Port.Text), true);
                SMTP.Authenticate(TB_ServerEmailAddress.Text, TB_ServerEmailPassword.Text);
                SMTP.Send(Email);
                SMTP.Disconnect(true);
            }




        }
    }
}
