using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;
using System.Configuration;
using WebsiteAutomate.Project.LT.Pagebase;
using WebsiteAutomate.Utility;

namespace WebsiteAutomate.Project.LT
{
    [TestFixture]
    [Parallelizable]
    [Category("DesktopRegression")]
    public  class RegressionDesktop12 : BaseTest
    {
        private LTPageBase lt;
        private const string LT_URL = "https://www.littlethings.com/";
        private const string LT_FACEBOOK_URL = "https://www.facebook.com/littlethingscom";
        private const string LT_PINTEREST_URL = "https://www.pinterest.com/littlethingscom/";
        private const string LT_TWITTER_URL = "https://twitter.com/littlethingsusa";

        public override void InitFixtureSetup()
        {
            lt = new LTPageBase(Driver);
        }

        [Test]
        public void VerifySocialIconLanding()
        {
            //Start Report
            test = GlobalSetup.bt.extent.StartTest("Verify All social icon landing to correct page.");

            ReportLog("###1. Landing to website homepage.");
            Driver.NavigateTo(LT_URL);
            ReportLog("###2. Expand Social icon bar and check is display properly.");
            lt.ClickMoreSocialButton();
            Assert.IsTrue(lt.IsAllSocialMenuDisplay(), ErrorMessage.LT.NOT_FOUND_SOCIAL_MEDIA_ICON);

            ReportLog("###3. Click on Facebook icon and check landing.");
            lt.ClickFacebookSocialButton();
            Driver.SwitchToLastWindow();
            Assert.IsTrue(lt.IsUrlMatchAsExpected(LT_FACEBOOK_URL), ErrorMessage.LT.WRONG_SOCIAL_PAGE_LANDING);

            ReportLog("###3. Click on Pinterest icon and check landing.");
            lt.ClickPinterestSocialButton();
            Driver.SwitchToLastWindow();
            Assert.IsTrue(lt.IsUrlMatchAsExpected(LT_PINTEREST_URL), ErrorMessage.LT.WRONG_SOCIAL_PAGE_LANDING);

            ReportLog("###3. Click on Twitter icon and check landing.");
            lt.ClickTwitterSocialButton();
            Driver.SwitchToLastWindow();
            Assert.IsTrue(lt.IsUrlMatchAsExpected(LT_TWITTER_URL), ErrorMessage.LT.WRONG_SOCIAL_PAGE_LANDING);

            ReportLog("###3. Click on Email icon and check email popup.");
            lt.ClickEmailSocialButton();
            Assert.IsTrue(lt.IsEmailSubscriptBoxDisplay(), ErrorMessage.LT.NOT_FOUND_EMAIL_SUB_BOX);

            //Log Report as PASSED
            test.Log(LogStatus.Pass, "Test Passed.");
        }
    }
}
