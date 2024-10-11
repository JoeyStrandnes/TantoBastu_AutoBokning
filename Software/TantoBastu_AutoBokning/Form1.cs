using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Net.Mail;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TantoBastu_AutoBokning.Properties;
using System.Net;

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

            //Temporary variables for testing.
            String UserName = TB_UserName.Text;
            String Password = TB_Password.Text;

            Properties.Settings.Default.Username = UserName;
            Properties.Settings.Default.Password = Password;
            Properties.Settings.Default.SelectedTimeIndex = CB_BookingTimes.SelectedIndex;

            Properties.Settings.Default.Save();

            String Day = DT_BookingDatePicker.Value.ToString("dd");
            String BookedTime = CB_BookingTimes.SelectedItem.ToString();

            int NumberOfExtraBookings = 0;

            IWebDriver WebDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            WebDriverWait Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(20));

            WebDriver.Navigate().GoToUrl("http://tbas.lasborgen.se:8000/");

            System.Threading.Thread.Sleep(500);

            //Login on the page
            (WebDriver.FindElement(OpenQA.Selenium.By.Id("username"))).SendKeys(Properties.Settings.Default.Username);
            (WebDriver.FindElement(OpenQA.Selenium.By.Id("passwd"))).SendKeys(Properties.Settings.Default.Password);

            (WebDriver.FindElement(OpenQA.Selenium.By.Id("loginButton"))).Click();

            //Wait for the new page to load.
            System.Threading.Thread.Sleep(500);


            try //Wait for the login, will timeout or through an exception if the credentials were incorrect.
            {
                IWebElement MessageButton = WebDriver.FindElement(OpenQA.Selenium.By.Id("gwt-debug-closeButton"));
                Wait.Until(d => MessageButton.Displayed);
                MessageButton.Click(); //Close the messages pop up.
            }
            catch
            {
                MessageBox.Show("Wrong username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine("Wrong username or password. Try again.");
                WebDriver.Quit();

                return;
            }


            Program.BusyWaitForLoading(WebDriver, Wait); //Wait for the loading pop up to finish.

            //Select the day to book.
            WebDriver.FindElement(OpenQA.Selenium.By.Id($"gwt-debug-dayBoxButton{Day}")).Click(); //Click on the day to book.
            Program.BusyWaitForLoading(WebDriver, Wait);

            //Check if someone is booked as the host.
            IWebElement Host = WebDriver.FindElement(OpenQA.Selenium.By.XPath($"//div[starts-with(@id, 'gwt-debug-passText2_') and text()='{BookedTime}']"));

            if (Host.FindElement(OpenQA.Selenium.By.XPath("..")).Text.Contains("Otillgänglig"))
            {
                System.Diagnostics.Debug.WriteLine("Booked by: " + Host.FindElement(OpenQA.Selenium.By.TagName("i")).Text);

                //Check if a regular time is available.
                IWebElement RegularTime = WebDriver.FindElement(OpenQA.Selenium.By.XPath($"//div[starts-with(@id, 'gwt-debug-passText1_') and text()='{BookedTime}']"));

                //TODO check if the box is orange to prevent booking the same time multiple times.

                //Could also check the color of the box to see if its available or not.
                int NumberOfBookings = 0;
                try
                {
                    NumberOfBookings = Int32.Parse(Regex.Match(RegularTime.FindElement(OpenQA.Selenium.By.TagName("i")).Text, @"\d+").Value); //Get the number of bookings.
                }
                catch (NoSuchElementException)
                {
                    NumberOfBookings = 0; //TEST
                }

                System.Diagnostics.Debug.WriteLine(NumberOfBookings + " Bookings");


                if (NumberOfBookings < 11/* && RegularTime.Background*/) //TBD what the max number of bookings is.
                {

                    //Book the time.
                    RegularTime.Click();

                    Program.BusyWaitForLoading(WebDriver, Wait);

                    //Read the text from the pop up to check if the booking was successfull!
                    IWebElement ConfirmationPopUp = WebDriver.FindElement(OpenQA.Selenium.By.ClassName("gwt-DialogBox"));
                    Wait.Until(d => ConfirmationPopUp.Displayed); //Wait for it to show.

                    System.Diagnostics.Debug.WriteLine(ConfirmationPopUp.FindElement(OpenQA.Selenium.By.ClassName("Caption")).Text);

                    ConfirmationPopUp.FindElement(OpenQA.Selenium.By.TagName("button")).Click(); //Close the pop up

                    //Open the pop up again to see a list of the other people who booked the same time.
                    RegularTime.Click();
                    System.Threading.Thread.Sleep(500); //Temporary

                    //If you want to book multiple people
                    while (NumberOfExtraBookings > 0)
                    {
                        WebDriver.FindElement(OpenQA.Selenium.By.Id("gwt-debug-bookAnotherResourceButton")).Click();
                        Program.BusyWaitForLoading(WebDriver, Wait);
                        
                        ConfirmationPopUp.FindElement(OpenQA.Selenium.By.TagName("button")).Click(); //Close the pop up
                        RegularTime.Click();

                        NumberOfExtraBookings--;

                    }

                    String EmailBody = "Värd: " + Host.FindElement(OpenQA.Selenium.By.TagName("i")).Text + "\n";

                    var ListOfPeople = WebDriver.FindElements(OpenQA.Selenium.By.Id("gwt-debug-StackForm.headLine"));

                    foreach (var people in ListOfPeople)
                    {
                        System.Diagnostics.Debug.WriteLine(people.Text);
                        EmailBody += people.Text + "\n";
                    }

                    //Todo send an email when the booking is complete with information of the booking.

                }



            }
            else //Keep polling the server to wait if someone will host. 
            {
                System.Diagnostics.Debug.WriteLine(Host.Text);

                Timer_PollingIntervall.Start();

            }


            WebDriver.Quit();


            return;


        }

        private void Timer_PollingIntervall_Tick(object sender, EventArgs e)
        {

        }
    }
}
