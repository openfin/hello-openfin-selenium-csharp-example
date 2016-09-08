﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;

namespace Tests.SeleniumHelpers
{
    public static class WebDriverExtensions
    {
        /// <summary>
        ///     Target a window by title.
        /// </summary>
        /// <param name="windowTitle">title of the window.</param>
        public static bool SwitchWindow(this IWebDriver webDriver, string windowTitle)
        {
            Debug.WriteLine("calling SwitchWindow for " + windowTitle);
            bool found = false;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            while (!found) {
                foreach (string name in webDriver.WindowHandles) {
                    try {
                        webDriver.SwitchTo().Window(name);
                        if (webDriver.Title.Equals(windowTitle)) {
                            found = true;
                            break;
                        }
                    } catch (NoSuchWindowException wexp) {
                            // some windows may get closed during Runtime startup
                            // so may get this exception depending on timing
                            Debug.WriteLine("Ignoring NoSuchWindowException " + name);
                    }
                }
                Thread.Sleep(1000);
                if (stopWatch.ElapsedMilliseconds > 20*1000) {
                    break;
                }
            }

            if (!found) {
                    Debug.WriteLine(windowTitle + " not found");
            }
            return found;
        }

        /// <summary>
        ///     Run some javascript code and expect a response.
        /// </summary>
        /// <param name="driver">instance of Web Driver.</param>
        /// <param name="script">javascript code.</param>
        public static object executeAsyncJavascript(this IWebDriver driver, String script)
        {
            Debug.WriteLine("Executing Async javascript: " + script);
            return ((IJavaScriptExecutor)driver).ExecuteAsyncScript(script);
        }

        /// <summary>
        ///     Run some javascript code.
        /// </summary>
        /// <param name="driver">instance of Web Driver.</param>
        /// <param name="script">javascript code.</param>
        public static void executeJavascript(this IWebDriver driver, String script)
        {
            Debug.WriteLine("Executing Async javascript: " + script);
            ((IJavaScriptExecutor)driver).ExecuteScript(script);
        }

    }

}