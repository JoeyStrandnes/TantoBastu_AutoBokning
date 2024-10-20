using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

using MailKit;
using MimeKit;
using System.Net.Mail;


namespace TantoBastu_AutoBokning
{
    internal static class Program
    {


        public static String UserName = string.Empty;
        public static String Password = string.Empty;
        public static int NumberOfExtraBookings = 0;

        public enum ErrorCodes
        {
            WrongCredentials,
            BookingFull,
            BookingSucceeded

        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }


        public static void BusyWaitForLoading(IWebDriver web_driver, WebDriverWait wait)
        {

            //Wait for the loading pop up to finish. Its slow and is fetchig the bookign information from the server.
            IWebElement LoadingWheel = web_driver.FindElement(OpenQA.Selenium.By.ClassName("gwt-Image"));
            IWebElement Calendar = web_driver.FindElement(OpenQA.Selenium.By.ClassName("dayBoxBackPanel"));

            wait.Until(d => LoadingWheel.Displayed); //Wait for it to show.

            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(OpenQA.Selenium.By.XPath("//img[contains(@src,'ajax-loader.gif')]")));

            return;
        }

        public static Program.ErrorCodes BookSaunaTime(string day, string booking_time) //Return error code:
        {

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

                return Program.ErrorCodes.WrongCredentials;
            }


            Program.BusyWaitForLoading(WebDriver, Wait); //Wait for the loading pop up to finish.

            //Select the day to book.
            WebDriver.FindElement(OpenQA.Selenium.By.Id($"gwt-debug-dayBoxButton{day}")).Click(); //Click on the day to book.
            Program.BusyWaitForLoading(WebDriver, Wait);

            //Check if someone is booked as the host.
            IWebElement Host = WebDriver.FindElement(OpenQA.Selenium.By.XPath($"//div[starts-with(@id, 'gwt-debug-passText2_') and text()='{booking_time}']"));

            if (Host.FindElement(OpenQA.Selenium.By.XPath("..")).Text.Contains("Otillgänglig"))
            {
                System.Diagnostics.Debug.WriteLine("Booked by: " + Host.FindElement(OpenQA.Selenium.By.TagName("i")).Text);

                //Check if a regular time is available.
                IWebElement RegularTime = WebDriver.FindElement(OpenQA.Selenium.By.XPath($"//div[starts-with(@id, 'gwt-debug-passText1_') and text()='{booking_time}']"));

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
                    MimeMessage Email = new MimeMessage();
                    Email.From.Add(new MailboxAddress("BastuBokaren", "bastu@bastu.se"));

                    String[] UserNameSplit = Program.UserName.Split('.');
                    String Name = char.ToUpper(UserNameSplit[0][0]) + UserNameSplit[0].Substring(1) + char.ToUpper(UserNameSplit[1][0]) + UserNameSplit[1].Substring(1);

                    Email.To.Add(new MailboxAddress(Name, "bastu@bastu.se"));
                    Email.Subject = "Bastun är bokad";
                    Email.Body = new TextPart("plain")
                    {
                        Text = EmailBody
                    };

                    using (MailKit.Net.Smtp.SmtpClient SMTP = new MailKit.Net.Smtp.SmtpClient())
                    {
                        SMTP.Connect("send.one.com", 465, true);
                        SMTP.Authenticate("bastu@bastu.se", "Bastu1234");
                        SMTP.Send(Email);
                        SMTP.Disconnect(true);
                    }

                }
                else //No empty spots
                {
                    WebDriver.Quit();
                    return Program.ErrorCodes.BookingFull;
                }



            }
            else //Keep polling the server to wait if someone will host. 
            {
                System.Diagnostics.Debug.WriteLine(Host.Text);
                WebDriver.Quit();
                return Program.ErrorCodes.BookingFull;

            }


            WebDriver.Quit();
            return Program.ErrorCodes.BookingSucceeded;

        }

    }
}