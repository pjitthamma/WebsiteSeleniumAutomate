using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;
using System;
using System.Configuration;
using System.Drawing;

namespace WebsiteAutomate.Utility
{
    public class BaseTest
    {
        public IWebDriver Driver { get; set; }
        public ExtentReports extent;
        public ExtentTest test;        

        public virtual void InitFixtureSetup() { }

        public void OneTimeSetUp()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "Reports\\Report_"+ DateTime.Now.ToString("MM-dd-yyyy HHmmss") +".html";
            extent = new ExtentReports(reportPath, true);
        }

        [SetUp]
        public void SetUp()
        {
            string DeviceType = ConfigurationManager.AppSettings["device_type"];
            string Extension = ConfigurationManager.AppSettings["use_extension"];

            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("WebsiteAutomate"));
            string projectPath = new Uri(actualPath).LocalPath;
            string extensionPath = projectPath + "Extension\\AdBlock_v3.40.1.crx";

            if (DeviceType == "Desktop")
            {
                if (Extension == "true")
                {
                    ChromeOptions chromeCapabilities = new ChromeOptions();
                    chromeCapabilities.AddExtensions(extensionPath);
                    Driver = new ChromeDriver(chromeCapabilities);
                    Driver.Manage().Window.Maximize();
                    Driver.SwitchToFirstWindow();
                    Driver.CloseLastWindow();
                    InitFixtureSetup();
                }
                else
                {
                    Driver = new ChromeDriver();
                    Driver.Manage().Window.Maximize();
                    InitFixtureSetup();
                }
            }
            else
            {
                if (Extension == "true")
                {
                    ChromeOptions chromeCapabilities = new ChromeOptions();
                    string[] arr;
                    arr = new[] { "--user-agent= Mozilla/5.0 (iPhone; CPU iPhone OS 11_0_3 like Mac OS X) AppleWebKit/602.2.8 (KHTML, like Gecko) Version/11.0 Mobile/14B55c Safari/602.1" };
                    chromeCapabilities.AddArguments(arr);
                    chromeCapabilities.AddExtensions(extensionPath);
                    Driver = new ChromeDriver(chromeCapabilities);
                    Driver.SwitchToFirstWindow();
                    Driver.CloseLastWindow();
                    Driver.Manage().Window.Size = new Size(414, 763);
                    InitFixtureSetup();
                }
                else
                {
                    ChromeOptions chromeCapabilities = new ChromeOptions();
                    string[] arr;
                    arr = new[] {"--user-agent= Mozilla/5.0 (iPhone; CPU iPhone OS 11_0_3 like Mac OS X) AppleWebKit/602.2.8 (KHTML, like Gecko) Version/11.0 Mobile/14B55c Safari/602.1" };
                    chromeCapabilities.AddArguments(arr);
                    Driver = new ChromeDriver(chromeCapabilities);
                    Driver.Manage().Window.Size = new Size(414, 763);
                    InitFixtureSetup();
                }
            }
        }

        public void OneTimeTearDown()
        {
            extent.Flush();
            extent.EndTest(test);
            extent.Close();
        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if (status == TestStatus.Failed)
            {
                string screenShotPath = Utility.TakeWholePageScreenshot(Driver, "ScreenShot");
                test.Log(LogStatus.Fail, stackTrace + "<br><pre>" + errorMessage + "</pre>");
                test.Log(LogStatus.Fail, "Error Screenshot: " + test.AddScreenCapture(screenShotPath));
            }

            Driver.Close();
            Driver.Quit();
        }

        public void ReportLog(string message)
        {
            test.Log(LogStatus.Info, message);
        }
    }
}
