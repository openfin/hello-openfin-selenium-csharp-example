using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Structura.GuiTests.Utilities;

namespace Structura.GuiTests.SeleniumHelpers
{
    public enum DriverToUse
    {
        Chrome
    }

    public class DriverFactory
    {

        /// <summary>
        ///     Create and configure an instance of ChromeDriver based on App.config.
        /// </summary>
        public IWebDriver Create()
        {
            IWebDriver driver = CreateWebDriver();

            //driver.Manage().Window.Maximize();
            var timeouts = driver.Manage().Timeouts();
            timeouts.ImplicitWait = TimeSpan.FromSeconds(ConfigurationHelper.Get<int>("ImplicitlyWait"));
            timeouts.PageLoad     = TimeSpan.FromSeconds(ConfigurationHelper.Get<int>("PageLoadTimeout"));
            timeouts.AsynchronousJavaScript = TimeSpan.FromSeconds(ConfigurationHelper.Get<int>("ScriptTimeout"));
            return driver;
        }

        /// <summary>
        ///     Create an instance of ChromeDriver based on App.config.
        /// </summary>
        public static IWebDriver CreateWebDriver()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.DebuggerAddress = ConfigurationManager.AppSettings["DebuggerAddress"];
            var driverFileName = ConfigurationManager.AppSettings["ChromeDriverFileName"];
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string exeDir = System.IO.Path.GetDirectoryName(exePath);
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(exeDir, driverFileName);
            service.EnableVerboseLogging = true;
            string logfile = ConfigurationManager.AppSettings["ChromeDriverLogFile"];
            if (logfile != null)
            {
                service.LogPath = ConfigurationManager.AppSettings["ChromeDriverLogFile"];
            }
            var chromeDriver = new ChromeDriver(service, chromeOptions);
            return chromeDriver;
        }
    }
}