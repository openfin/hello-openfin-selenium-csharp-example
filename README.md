# Hello OpenFin Selenium Csharp Example

## Overview
Example of C#.NET test code with Chrome Driver on OpenFin Runtime

## Source Code
OpenFinAppTest.cs has sample code for testing HTML5 components and OpenFin javascript adapter in Hello OpenFin demo application.

### Guidelines
Since all HTML5 applications in the OpenFin environment need to be started with OpenFin API, chromeDriver.get(URL) is not supported. Test code needs to start HTML5 app before connecting to Chromedriver.

Given there can be multiple applications/windows active in OpenFin Runtime, tests must begin by selecting the targeted window. Each test script has a function that selects the window by matching it's title.

Since the OpenFin Runtime is started by OpenFinRVM, Chromedriver does not have direct control of the OpenFin Runtime. OpenFin app needs to be started by the test code with SeleniumHelper.LaunchOpenFin(). Once a test is complete, it needs to shut down OpenFin Runtime by running javascript code "fin.desktop.System.exit();". driver.quit() does not shut down OpenFin Runtime since it does not have access.

If tests are run with OpenFin Runtime version 5.x.x.x, a patched version of ChromeDriver is needed.  Execuable of the patched version is included in this repo as chromedriverOF.exe.  It can be selected to run this example by changing ChromeDriverFileName in App.config to chromedriverOF.exe.

In Summary
* Tests must target specific windows
* OpenFin RunTime must be shut down after a test is completed

## Run
1. Install [Hello OpenFin](https://install.openfin.co/download/?config=https%3A%2F%2Fcdn.openfin.co%2Fdemos%2Fhello%2Fapp.json&fileName=HelloOpenFin&supportEmail=support%40openfin.co) app
2. Clone this project and load and build it in VisualStudio 2015
3. Run all tests in TEST->RUN->All Tests in VisualStudio 2015

## License 
MIT

The code in this repository is covered by the included license.  If you run this code, it may call on the OpenFin RVM or OpenFin Runtime, which are subject to OpenFin’s [Developer License](https://openfin.co/developer-agreement/). If you have questions, please contact support@openfin.co

## Support
Please enter an issue in the repo for any questions or problems. 
<br> Alternatively, please contact us at support@openfin.co

