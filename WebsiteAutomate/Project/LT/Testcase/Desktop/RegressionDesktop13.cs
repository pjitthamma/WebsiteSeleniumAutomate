using NUnit.Framework;
using RelevantCodes.ExtentReports;
using WebsiteAutomate.Project.LT.Pagebase;
using WebsiteAutomate.Utility;

namespace WebsiteAutomate.Project.LT
{
    [TestFixture]
    [Parallelizable]
    [Category("DesktopRegression")]
    public  class RegressionDesktop13 : BaseTest
    {
        private LTPageBase lt;
        private const string LT_URL = "https://www.littlethings.com/";

        public override void InitFixtureSetup()
        {
            lt = new LTPageBase(Driver);
        }

        [Test]
        public void VerifyNewsLetter()
        {
            //Start Report
            test = GlobalSetup.bt.extent.StartTest("Verify Newsletter feature.");

            ReportLog("###1. Landing to website homepage.");
            Driver.NavigateTo(LT_URL);
            ReportLog("###2. Expand Social icon bar and check is display properly.");
            lt.ClickMoreSocialButton();
            Assert.IsTrue(lt.IsAllSocialMenuDisplay(), ErrorMessage.LT.NOT_FOUND_SOCIAL_MEDIA_ICON);

            ReportLog("###3. Click on email icon and check email popup.");
            lt.ClickEmailSocialButton();
            Assert.IsTrue(lt.IsEmailSubscriptBoxDisplay(), ErrorMessage.LT.NOT_FOUND_EMAIL_SUB_BOX);

            ReportLog("###4. Signup with valid email.");
            lt.SubscriptToEmail("test@wildskymedia.com");
            Assert.IsTrue(lt.IsThankyouMessageDisplay(), ErrorMessage.LT.NOT_FOUND_THANKYOU_MSG);
            ReportLog("###5. Click back to story.");
            lt.ClickBackToStory();

            ReportLog("###6. Signup again with invalid email.");
            lt.ClickEmailSocialButton();
            lt.SubscriptToEmail("wngrikhwrpk");
            Assert.IsTrue(lt.IsErrorMessageDisplay(), ErrorMessage.LT.NOT_FOUND_ERROR_MSG);
            ReportLog("###7. Click No,Thank you.");
            lt.ClickNoThankyou();

            //Log Report as PASSED
            test.Log(LogStatus.Pass, "Test Passed.");
        }
    }
}
