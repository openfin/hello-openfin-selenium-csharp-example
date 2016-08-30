hello-openfin-selenium-csharp-example
====================================

Example of C#.NET test code with Chrome Driver on OpenFin Runtime

## Source Code

OpenFinAppTest.cs has sample code for testing HTML5 components and OpenFin javascript adapter in Hello OpenFin demo application.

## Guidelines

Since all HTML5 applications in the OpenFin environment need to be started with OpenFin API, chromeDriver.get(URL) is not supported. Test code needs to start HTML5 app before connecting to Chromedriver.

Given there can be multiple applications/windows active in OpenFin Runtime, tests must begin by selecting the targeted window. Each test script has a function that selects the window by matching it's title.

Since the OpenFin Runtime is started by OpenFinRVM, Chromedriver does not have direct control of the OpenFin Runtime. OpenFin app needs to be started by the test code with SeleniumHelper.LaunchOpenFin(). Once a test is complete, it needs to shut down OpenFin Runtime by running javascript code "fin.desktop.System.exit();". driver.quit() does not shut down OpenFin Runtime since it does not have access.

In Summary
* Tests must target specific windows
* OpenFin RunTime must be shut down after a test is completed

## Run the example

1. Install Hello OpenFin app from https://openfin.co/demos/

2. Clone this project and load and build it in VisualStudio 2015

3. Run all tests in TEST->RUN->All Tests in VisualStudio 2015

## Getting help

Please contact support@openfin.co






































This solution demonstrates automated testing web pages with Selenium and C#.NET. It can also be used as a template for new Selenium test projects.

Three tests are included that run tests on the publically available demo website Altoro Mutual available at http://demo.testfire.net/. The tests test logging onto the website and transferring an amount between two accounts.

The tests can be executed on three browsers: Firefox, Chrome and Internet Explorer. The driver can be selected using 
the appsetting *DriverToUse* in the app.config file. To run the tests on Internet Explorer 11, the registry must be updated first so that the driver can maintain a connection to the browser. Import the registry file [configure_ie_11_for_selenium_iedriverserver.reg](https://github.com/atosorigin/SeleniumExample/blob/master/configure_ie_11_for_selenium_iedriverserver.reg) to achieve this. 

To run the Selenium tests, download the solution and run the NUnit tests. All selenium dependencies are included in the solution. Run the NUnit tests using Resharper ( http://www.jetbrains.com/resharper ), NUnit ( http://www.nunit.org ) or ContinuousTests ( http://continuoustests.com ).

The tests are structured according to the [Page Object Pattern](https://code.google.com/p/selenium/wiki/PageObjects).

Out of the box Selenium supports locating elements using the element id or an xpath selector. The extension method *FindElementByJQuery* has been added to SeleniumExample with which elements can be located using a more versatile JQuery selector. Example:

    _driver.FindElementByJQuery("input[name='btnSubmit']")

Alexander van Trijffel
