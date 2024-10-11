using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace TantoBastu_AutoBokning
{
    internal static class Program
    {
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



    }
}