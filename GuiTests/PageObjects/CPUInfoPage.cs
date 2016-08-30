using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Tests.PageObjects
{
    /// <summary>
    ///     CPU Info window of Hello OpenFin demo app.
    /// </summary>
    public class CPUInfoPage
    {
        private readonly IWebDriver _driver;

        public CPUInfoPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = "close-app")]
        public IWebElement CloseElement { get; set; }

        /// <summary>
        ///     Click close button.
        /// </summary>
        public void ClosePage()
        {
            CloseElement.Click();
        }
    }
}

