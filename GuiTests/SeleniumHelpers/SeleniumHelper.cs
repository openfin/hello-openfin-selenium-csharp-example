using System;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Structura.GuiTests.SeleniumHelpers
{
    public class SeleniumHelper
    {

        public static string GetCosasBuildVersion()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            var result = string.Format(CultureInfo.InvariantCulture, "{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.MinorRevision);

            return result;
        }

        /// <summary>
        ///     Launch OpenFin Runtime based on App.config.
        /// </summary>
        public static void LaunchOpenFin()
        {
            try {
                Process process = new Process();
                // Configure the process using the StartInfo properties.
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                process.StartInfo.FileName = path + @"\" + ConfigurationManager.AppSettings["OpenFinLaunchExec"];
                process.StartInfo.Arguments = ConfigurationManager.AppSettings["OpenFinLaunchArgs"];
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.Start();
            } catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
