using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Enum
{
    public class Driver : Log
    {
        public IWebDriver SelectBrowser()
        {
            IWebDriver driver = null;
            string browserType = ConfigurationSettings.AppSettings["Platforms"];

            if (browserType == "WEBCHROME")
            {
                IWebDriver driverBrowser = new ChromeDriver();
                driverBrowser.Manage().Window.Maximize();
                return driverBrowser;
            }

            else if (browserType == "WEBFIREFOX")
            {
                IWebDriver driverBrowser = new FirefoxDriver();
                return driverBrowser;
            }

            else if (browserType == "IE")
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                if (path.Contains("bin"))
                {
                    path = path.Substring(0, path.Length - 11);
                }
                var fileName = Path.Combine(path, Path.Combine("Driver", "IE.exe"));
                var iEOption = new InternetExplorerOptions();
                iEOption.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                IWebDriver driverBrowser = new InternetExplorerDriver(fileName, iEOption);
                return driverBrowser;
            }
            else
            {
                return driver;
            }

        }
    }
}