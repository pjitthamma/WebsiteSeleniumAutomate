using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace WebsiteAutomate.Utility
{
    public static class Utility
    {
        public static bool AjaxDoneResult { get; set; }
        public static int MODERATE_COMPONENT_TIMEOUT = 25;
        public static int SMALL_COMPONENT_TIMEOUT = 10;
        public static int TINY_COMPONENT_TIMEOUT = 5;
        public static bool ImagePresent;
        public static IWebElement ImageFile;
        public static IJavaScriptExecutor js;

        public static string TakeWholePageScreenshot(IWebDriver driver, string screenShotName)
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string screenshotDirectory = pth.Substring(0, pth.LastIndexOf("bin")) + @"ErrorScreenshots/";

            string uniqueName = DateTime.Now.ToString("yyyyMMdd_HHmmss_") + screenShotName;
            StringBuilder filepath = new StringBuilder();
            filepath.Append(screenshotDirectory);
            filepath.Append(uniqueName);
            filepath.Append(".jpg");

            string fileFullPath = filepath.ToString();
            string fileFinalPath = new Uri(fileFullPath).LocalPath;
            driver.JsScrollToTop();
            TakeWholePageScreenShot(driver, fileFinalPath);

            return fileFinalPath;
        }

        private static void TakeWholePageScreenShot(IWebDriver driver, string path)
        {
            string DeviceType = ConfigurationManager.AppSettings["device_type"];

            var totalWidth = (int)(long)((IJavaScriptExecutor)driver).ExecuteScript("return Math.max(document.body.scrollWidth, document.body.offsetWidth, document.documentElement.clientWidth, document.documentElement.scrollWidth, document.documentElement.offsetWidth);");
            var totalHeight = (int)(long)((IJavaScriptExecutor)driver).ExecuteScript("return Math.max(document.body.scrollHeight, document.body.offsetHeight, document.documentElement.clientHeight, document.documentElement.scrollHeight, document.documentElement.offsetHeight);");

            Size d = driver.Manage().Window.Size;
            if (totalHeight > d.Height && totalHeight > 0)
            {
                driver.Manage().Window.Size = new Size(driver.Manage().Window.Size.Width, totalHeight);
            }

            // Get the size of the viewport
            bool isJQuery = (bool)((IJavaScriptExecutor)driver).ExecuteScript("return window.jQuery != undefined");
            int viewportWidth = 0;
            int viewportHeight = 0;
            if (isJQuery)
            {
                try
                {
                    viewportWidth = (int)(long)((IJavaScriptExecutor)driver).ExecuteScript("return $(window).width();");
                    viewportHeight = (int)(long)((IJavaScriptExecutor)driver).ExecuteScript("return $(window).height();");
                }
                catch
                {
                    viewportWidth = (int)(long)((IJavaScriptExecutor)driver).ExecuteScript("return document.body.clientWidth");
                    viewportHeight = (int)(long)((IJavaScriptExecutor)driver).ExecuteScript("return window.innerHeight");
                }
            }
            else
            {
                viewportWidth = (int)(long)((IJavaScriptExecutor)driver).ExecuteScript("return document.body.clientWidth");
                viewportHeight = (int)(long)((IJavaScriptExecutor)driver).ExecuteScript("return window.innerHeight");
            }

            // Split the screen in multiple Rectangles
            var rectangles = new List<Rectangle>();
            // Loop until the totalHeight is reached
            for (var y = 0; y < totalHeight; y += viewportHeight)
            {
                var newHeight = viewportHeight;
                // Fix if the height of the element is too big
                if (y + viewportHeight > totalHeight)
                {
                    newHeight = totalHeight - y;
                }
                // Loop until the totalWidth is reached
                for (var x = 0; x < totalWidth; x += viewportWidth)
                {
                    var newWidth = viewportWidth;
                    // Fix if the Width of the Element is too big
                    if (x + viewportWidth > totalWidth)
                    {
                        newWidth = totalWidth - x;
                    }
                    // Create and add the Rectangle
                    var currRect = new Rectangle(x, y, newWidth, newHeight);
                    rectangles.Add(currRect);
                }
            }

            var stitchedImage = new Bitmap(totalWidth, totalHeight);

            // Get all Screenshots and stitch them together
            var previous = Rectangle.Empty;
            foreach (var rectangle in rectangles)
            {
                // Calculate the scrolling (if needed)
                if (previous != Rectangle.Empty)
                {
                    var xDiff = rectangle.Right - previous.Right;
                    var yDiff = rectangle.Bottom - previous.Bottom;
                    // Scroll
                    ((IJavaScriptExecutor)driver).ExecuteScript($"window.scrollBy({xDiff}, {yDiff})");
                }
                // Take Screenshot
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

                // Build an Image out of the Screenshot
                var screenshotImage = ScreenshotToImage(screenshot);
                // Calculate the source Rectangle
                var sourceRectangle = new Rectangle(viewportWidth - rectangle.Width, viewportHeight - rectangle.Height, rectangle.Width, rectangle.Height);
                // Copy the Image
                using (var graphics = Graphics.FromImage(stitchedImage))
                {
                    graphics.DrawImage(screenshotImage, rectangle, sourceRectangle, GraphicsUnit.Pixel);
                }
                // Set the Previous Rectangle
                previous = rectangle;
            }

            stitchedImage.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private static Image ScreenshotToImage(Screenshot screenshot)
        {
            Image screenshotImage;
            using (var memStream = new MemoryStream(screenshot.AsByteArray))
            {
                screenshotImage = Image.FromStream(memStream);
            }
            return screenshotImage;
        }


        public static void NavigateTo(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.WaitAjax(SMALL_COMPONENT_TIMEOUT);
        }

        public static TResult WaitUntil<TResult>(this IWebDriver driver, Func<IWebDriver, TResult> condition, int second)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(second));
            return wait.UntilCondition(condition, second);
        }

        public static TResult UntilCondition<TResult>(this WebDriverWait driverWait, Func<IWebDriver, TResult> condition, int waitingTime)
        {
            driverWait.Timeout = TimeSpan.FromSeconds(waitingTime);

            try { return driverWait.Until(condition); }
            catch (WebDriverTimeoutException) { return default(TResult); }
        }

        public static bool IsAjaxDone(this IWebDriver driver)
        {
            try
            {
                return (driver.IsAjaxDefined()) ? driver.CheckInjectJavascript("return window.jQuery != undefined && jQuery.active === 0 && document.readyState == 'complete'") : true;
            }
            catch { return false; }
        }

        public static bool IsAjaxDefined(this IWebDriver driver)
        {
            var javaScriptExecutor = driver as IJavaScriptExecutor;
            return javaScriptExecutor != null && (bool)javaScriptExecutor.ExecuteScript("return window.jQuery != undefined");
        }

        public static bool CheckInjectJavascript(this IWebDriver driver, string script)
        {
            var js = driver as IJavaScriptExecutor;
            return js != null && (bool)js.ExecuteScript(script);
        }

        public static void WaitAjax(this IWebDriver driver, int second)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(second));

                AjaxDoneResult = wait.Until(d => d.IsAjaxDone());

                Console.WriteLine("- Is AJAX done : " + AjaxDoneResult);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                Console.WriteLine(ex);
            }
        }
        public static bool IsBodyOrHtmlHasClass(this IWebDriver driver, string className)
        {
            try
            {
                return driver.FindElement(By.CssSelector("html body")).GetAttribute("class").Split(' ').Any(exp => exp.Equals(className));
            }
            catch { return false; }
        }

        public static void InitialPageObject(this IWebDriver driver, Object page)
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    PageFactory.InitElements(driver, page);
                    break;
                }
                catch
                {
                    Thread.Sleep(3000);
                }
            }
        }

        public static void JsScrollToElement(this IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript($"window.scrollTo({element.Location.X},{element.Location.Y}); return 0;");
        }

        public static void JsScrollToTop(this IWebDriver driver)
        {
            driver.InjectJavascript("window.scrollTo(0,0);");
        }

        public static void InjectJavascript(this IWebDriver driver, string script)
        {
            try
            {
                var javaScriptExecutor = driver as IJavaScriptExecutor;
                if (javaScriptExecutor == null)
                    return;
                javaScriptExecutor.ExecuteScript(script);
            }
            catch
            {
                return;
            }
        }

        public static bool CheckImageDisplay(this IWebDriver driver, string element)
        {
            try
            {
                Thread.Sleep(5000);
                ImageFile = driver.FindElement(By.XPath(element));
                js = driver as IJavaScriptExecutor;

                return ImagePresent = (Boolean)(js.ExecuteScript("return arguments[0].complete && typeof arguments[0].naturalWidth != \"undefined\" && arguments[0].naturalWidth > 0", ImageFile));

            }
            catch { return false; }
        }

        public static bool CheckCSSImageDisplay(this IWebDriver driver, string element)
        {
            try
            {
                IWebElement temp = driver.FindElement(By.XPath(element));
                string image = temp.GetCssValue("background-image");
                string imageUrl = image.Split('"')[1].Split('"')[0];

                return CheckHttpWebResponse(imageUrl);

            }
            catch { return false; }
        }

        public static bool CheckHttpWebResponse(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response == null || response.StatusCode != HttpStatusCode.OK) { return false; }
                else { return true; }
            }
            catch (Exception) { return false; }
        }

        public static void SwitchToLastWindow(this IWebDriver driver)
        {
            if (driver.WindowHandles.Count == 0)
            {
                throw new ArgumentException("There is no window in this driver.");
            }
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public static void SwitchToFirstWindow(this IWebDriver driver)
        {
            if (driver.WindowHandles.Count == 0)
            {
                throw new ArgumentException("There is no window in this driver.");
            }

            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }
        public static void CloseLastWindow(this IWebDriver driver)
        {
            SwitchToLastWindow(driver);
            driver.Close();

            if (driver.WindowHandles.Count > 0)
            {
                SwitchToLastWindow(driver);
            }
        }

        public static string GetCurrentUrl(this IWebDriver driver)
        {
            try
            {
                string url;
                return url = driver.Url;
            }
            catch (Exception) { return "Cannot get current url."; }
        }
    }
}
