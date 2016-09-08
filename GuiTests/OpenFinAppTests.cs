using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using Structura.GuiTests.PageObjects;
using Structura.GuiTests.SeleniumHelpers;
using Tests.PageObjects;
using Tests.SeleniumHelpers;

namespace Structura.GuiTests
{
    [TestFixture]
    public class OpenFinAppTests
    {
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void SetupTest()
        {
            SeleniumHelper.LaunchOpenFin();
            _driver = new DriverFactory().Create();
        }

        [OneTimeTearDown]
        public void TeardownTest()
        {
            try
            {
                _driver.executeJavascript("fin.desktop.System.exit();");  // ask OpenFin Runtime to exit
                Thread.Sleep(3000);  // gives Runtime time to exit
                _driver.Quit();
                _driver.Close();
            }
            catch (Exception ex)
            {
                // Ignore errors if we are unable to close the browser
                Debug.WriteLine(ex.ToString());
            }
        }

        [Test, Order(1)]
        public void CheckRuntimeVersion()
        {
            if (_driver.SwitchWindow("Hello OpenFin"))
            {
                object response = _driver.executeAsyncJavascript(
                        "var callback = arguments[arguments.length - 1];" +
                                "fin.desktop.System.getVersion(function(v) { callback(v); } );");
                Debug.WriteLine("OpenFin Runtime version " + response);
                response.Should().NotBeNull(); 
            }
        }

        [Test, Order(2)]
        public void ShowCPUInfoWindow()
        {
            var mainPage = new MainPage(_driver);
            mainPage.ShowNotification();
            mainPage.ShowCPUInfo();
            // Assert
            _driver.SwitchWindow("Hello OpenFin CPU Info").Should().BeTrue();
        }

        [Test, Order(3)]
        public void CloseCPUInfoWindow()
        {
            var cpuInfoPage = new CPUInfoPage(_driver);
            cpuInfoPage.ClosePage();
            Thread.Sleep(1000);
            // Assert
            object response = _driver.executeAsyncJavascript(
                    "var callback = arguments[arguments.length - 1];" +
                            "fin.desktop.Window.getCurrent().isShowing(function(data) { callback(data); } );");
            Assert.IsFalse((bool)response);
            _driver.SwitchWindow("Hello OpenFin").Should().BeTrue();
        }

        [Test, Order(5)]
        [Ignore("")]
        public void SVGComponent()
        {
            var ellipse = _driver.FindElement(By.Id("ellipse3"));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])", ellipse, "style", "fill:red");
            Thread.Sleep(5000);
            var value = ellipse.GetAttribute("style");
            Debug.WriteLine(value);
            value.Should().Equals("fill:red");
        }
    }
}


