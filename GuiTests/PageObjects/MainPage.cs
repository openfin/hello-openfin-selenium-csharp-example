using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.PageObjects;

namespace Structura.GuiTests.PageObjects
{
    /// <summary>
    ///     Main window of Hello OpenFin demo app.
    /// </summary>
    public class MainPage
    {
        private readonly IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = "desktop-notification")]
        public IWebElement NotificationUpElement { get; set; }

        [FindsBy(How = How.Id, Using = "cpu-info")]
        public IWebElement CpuInfoElement { get; set; }

        /// <summary>
        ///     Click notifiction button.
        /// </summary>
        public void ShowNotification()
        {
            NotificationUpElement.Click();
        }

        /// <summary>
        ///     Click "CPU Info" button.
        /// </summary>
        public void ShowCPUInfo()
        {
            this.CpuInfoElement.Click();
        }

    }
}
