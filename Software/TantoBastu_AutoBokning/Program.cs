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
            Application.Run(new MainForm());
        }


        public static void BusyWaitForLoading(IWebDriver web_driver, WebDriverWait wait)
        {

            //Wait for the loading pop up to finish. Its slow and is fetching the booking information from the server.
            IWebElement LoadingWheel = web_driver.FindElement(OpenQA.Selenium.By.ClassName("gwt-Image"));
            IWebElement Calendar = web_driver.FindElement(OpenQA.Selenium.By.ClassName("dayBoxBackPanel"));

            wait.Until(d => LoadingWheel.Displayed); //Wait for it to show.

            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(OpenQA.Selenium.By.XPath("//img[contains(@src,'ajax-loader.gif')]")));

            return;
        }

        public static Program.ErrorCodes BookSaunaTime(DateTime date, string booking_time) //Return error code:
        {

#if !DEBUG

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--start-minimized");
            //chromeOptions.AddArgument("--window-position=-2400,-2400"); //Chrome verison is bugged.

            //Setup the Chrome driver without the terminal window
            ChromeDriverService DriverService = ChromeDriverService.CreateDefaultService();
            DriverService.HideCommandPromptWindow = true;

            IWebDriver WebDriver = new OpenQA.Selenium.Chrome.ChromeDriver(DriverService, chromeOptions);
            
#else
            IWebDriver WebDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
#endif

            WebDriverWait Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(60));

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


            //Check what language is used in the browser. Should be Swedish by default but you never know.
            //This is used for the month selector since it is only searchable by the month name!
            WebDriver.FindElement(OpenQA.Selenium.By.Id("gwt-debug-languageSelection")).Click();
            String BrowserLang = Regex.Replace(WebDriver.FindElement(OpenQA.Selenium.By.ClassName("dialogTopCenterInner")).Text, @"^.*? - ", "");

            //The website is sometimes set to English for some reason. This breaks some elements since they use Swedish text!
            if (BrowserLang != "Svenska")
            {
                //The entire page will reload if the language is changed....
                WebDriver.FindElement(OpenQA.Selenium.By.Id("gwt-debug-languageImage_sv")).Click();

                //A bit of a pain, the waiting time and order of the popups changes every time. FIXME
                System.Threading.Thread.Sleep(500);

                Program.BusyWaitForLoading(WebDriver, Wait); //Wait for the loading pop up to finish.

                IWebElement MessageButton = WebDriver.FindElement(OpenQA.Selenium.By.Id("gwt-debug-closeButton"));
                Wait.Until(d => MessageButton.Displayed);
                MessageButton.Click(); //Close the messages pop up.

            }
            else //Swedish so just close the popup
            {
                WebDriver.FindElement(OpenQA.Selenium.By.Id("gwt-debug-closeButton")).Click();
            }

            System.Globalization.CultureInfo ThreadLang = new System.Globalization.CultureInfo("sv-SV");

            System.Threading.Thread.CurrentThread.CurrentCulture = ThreadLang;
            System.Threading.Thread.CurrentThread.CurrentUICulture = ThreadLang;

            //TODO Fetch the month name from the "date time picker" after the language has been set 
            string SelectedMonth = date.ToString("MMMM").ToLower();
            int SelectedYear = date.Year;
            int MonthNumber = date.Month;

            IWebElement MonthBanner = WebDriver.FindElement(OpenQA.Selenium.By.Id("gwt-debug-dateButton"));
            IWebElement NextMonthButton = WebDriver.FindElement(OpenQA.Selenium.By.Id("gwt-debug-nextButton"));

            //Loop over all possible months. Assumes nobody is crazy enough to book more than 12 months in advance.
            for (int i = 0; i < 12; i++)
            {

                if (MonthBanner.Text.Contains(SelectedMonth) == true)
                {
                    break;
                }

                NextMonthButton.Click();
                Program.BusyWaitForLoading(WebDriver, Wait);

            }


            //Select the day to book.
            WebDriver.FindElement(OpenQA.Selenium.By.Id($"gwt-debug-dayBoxButton{date.ToString("dd")}")).Click(); //Click on the day to book.
            Program.BusyWaitForLoading(WebDriver, Wait);

            //Check if someone is booked as the host.
            IWebElement Host = WebDriver.FindElement(OpenQA.Selenium.By.XPath($"//div[starts-with(@id, 'gwt-debug-passText2_') and text()='{booking_time}']"));

            if (Host.FindElement(OpenQA.Selenium.By.XPath("..")).Text.Contains("Ledig") && Properties.Settings.Default.HostSession == true)
            {
                Host.Click(); //Book the session as the host.

                if (NumberOfExtraBookings > 0) //ie book a spot for your friends.
                {
                    NumberOfExtraBookings--; //This is because the "non hosting" routine books a normal time in addition to the extra bookings.
                    Program.BusyWaitForLoading(WebDriver, Wait);
                }
                else
                {

                    if (Properties.Settings.Default.SendEmailAfterBooking == true)
                    {

                        MimeMessage Email = new MimeMessage();
                        Email.From.Add(new MailboxAddress("BastuBokaren", Properties.Settings.Default.ServerEmail));

                        Email.To.Add(new MailboxAddress("", Properties.Settings.Default.Email));
                        Email.Subject = "Bastun är bokad";
                        Email.Body = new TextPart("plain")
                        {
                            Text = "Du är värd för pass:" + Environment.NewLine + date.ToString("d") + Environment.NewLine + "kl: " + booking_time
                        };

                        using (MailKit.Net.Smtp.SmtpClient SMTP = new MailKit.Net.Smtp.SmtpClient())
                        {
                            SMTP.Connect(Properties.Settings.Default.ServerAddress, Properties.Settings.Default.ServerPort, true);
                            SMTP.Authenticate(Properties.Settings.Default.ServerEmail, Properties.Settings.Default.ServerEmailPassword);
                            SMTP.Send(Email);
                            SMTP.Disconnect(true);
                        }



                    }


                    WebDriver.Quit();
                    return Program.ErrorCodes.BookingSucceeded;

                }


            }

            if (Host.FindElement(OpenQA.Selenium.By.XPath("..")).Text.Contains("Otillgänglig") || Host.FindElement(OpenQA.Selenium.By.XPath("..")).Text.Contains("Bokad av mig"))
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

                    //Read the text from the pop up to check if the booking was successful!
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

                        try //FIXME Not finding the button some times
                        {
                            ConfirmationPopUp.FindElement(OpenQA.Selenium.By.TagName("button")).Click(); //Close the pop up
                        }
                        catch
                        {
                            ConfirmationPopUp.FindElement(OpenQA.Selenium.By.ClassName("gwt-Button standardButton")).Click();
                        }
                        RegularTime.Click();

                        NumberOfExtraBookings--;

                    }

                    if (Properties.Settings.Default.SendEmailAfterBooking == true)
                    {
                        String EmailBody = "Värd: " + Host.FindElement(OpenQA.Selenium.By.TagName("i")).Text + "\n";

                        var ListOfPeople = WebDriver.FindElements(OpenQA.Selenium.By.Id("gwt-debug-StackForm.headLine"));

                        foreach (var people in ListOfPeople)
                        {
                            System.Diagnostics.Debug.WriteLine(people.Text);
                            EmailBody += people.Text + "\n";
                        }

                        //Send an email when the booking is complete with information of the booking.
                        MimeMessage Email = new MimeMessage();
                        Email.From.Add(new MailboxAddress("BastuBokaren", Properties.Settings.Default.ServerEmail));

                        String[] UserNameSplit = Properties.Settings.Default.Username.Split('.');
                        String Name = char.ToUpper(UserNameSplit[0][0]) + UserNameSplit[0].Substring(1) + char.ToUpper(UserNameSplit[1][0]) + UserNameSplit[1].Substring(1);

                        Email.To.Add(new MailboxAddress(Name, Properties.Settings.Default.Email));
                        Email.Subject = "Bastun är bokad";
                        Email.Body = new TextPart("plain")
                        {
                            Text = EmailBody
                        };

                        using (MailKit.Net.Smtp.SmtpClient SMTP = new MailKit.Net.Smtp.SmtpClient())
                        {
                            SMTP.Connect(Properties.Settings.Default.ServerAddress, Properties.Settings.Default.ServerPort, true);
                            SMTP.Authenticate(Properties.Settings.Default.ServerEmail, Properties.Settings.Default.ServerEmailPassword);
                            SMTP.Send(Email);
                            SMTP.Disconnect(true);
                        }
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