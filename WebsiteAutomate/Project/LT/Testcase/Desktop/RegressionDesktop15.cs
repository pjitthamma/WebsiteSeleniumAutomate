using NUnit.Framework;
using RelevantCodes.ExtentReports;
using WebsiteAutomate.Project.LT.Pagebase;
using WebsiteAutomate.Utility;

namespace WebsiteAutomate.Project.LT
{
    [TestFixture]
    [Parallelizable]
    [Category("DesktopRegression")]
    public  class RegressionDesktop15 : BaseTest
    {
        private LTPageBase lt;
        private string current_url;
        private const string LT_URL = "https://www.littlethings.com";
        private const string ABOUT_US_URL = "https://www.littlethings.com/about.html";
        private const string ADVERTISING_URL = "https://www.littlethings.com/advertising.html";
        private const string PARTNER_URL = "https://www.littlethings.com/partnerships.html";
        private const string PRESS_URL = "https://www.littlethings.com/press.html";
        private const string CARRER_URL = "https://www.littlethings.com/careers.html";
        private const string CONTACT_US_URL = "https://www.littlethings.com/contact.html";
        private const string PRIVACY_URL = "https://wildskymedia.com/privacy-policy";
        private const string TERMS_URL = "https://wildskymedia.com/terms-of-service";
        private const string DMCA_URL = "https://www.littlethings.com/dmca-removal/";

        public override void InitFixtureSetup()
        {
            lt = new LTPageBase(Driver);
        }

        [Test]
        public void VerifyAllCompanyLinksHamberger()
        {
            //Start Report
            test = GlobalSetup.bt.extent.StartTest("Verify All company links on Hamberger.");

            ReportLog("###1. Landing to website homepage.");
            Driver.NavigateTo(LT_URL);
            ReportLog("###2. Hover Hamberger menu and check all company links.");

            ReportLog("###3. Click About us and check redirect page.");
            lt.ClickAboutusLink("Hamberger");
            Assert.IsTrue(lt.IsUrlMatchAsExpected(ABOUT_US_URL), ErrorMessage.LT.WRONG_COMPANY_PAGE_LANDING);
            current_url = Utility.Utility.GetCurrentUrl(Driver);
            Assert.IsTrue(Utility.Utility.CheckHttpWebResponse(current_url), ErrorMessage.LT.NO_RESPONSE_FROM_HTTP);

            ReportLog("###4. Click Advertising and check redirect page.");
            lt.ClickAdvertisingLink("Hamberger");
            Assert.IsTrue(lt.IsUrlMatchAsExpected(ADVERTISING_URL), ErrorMessage.LT.WRONG_COMPANY_PAGE_LANDING);
            current_url = Utility.Utility.GetCurrentUrl(Driver);
            Assert.IsTrue(Utility.Utility.CheckHttpWebResponse(current_url), ErrorMessage.LT.NO_RESPONSE_FROM_HTTP);

            ReportLog("###5. Click Partner and check redirect page.");
            lt.ClickPartnerLink("Hamberger");
            Assert.IsTrue(lt.IsUrlMatchAsExpected(PARTNER_URL), ErrorMessage.LT.WRONG_COMPANY_PAGE_LANDING);
            current_url = Utility.Utility.GetCurrentUrl(Driver);
            Assert.IsTrue(Utility.Utility.CheckHttpWebResponse(current_url), ErrorMessage.LT.NO_RESPONSE_FROM_HTTP);

            ReportLog("###6. Click Press and check redirect page.");
            lt.ClickPressLink("Hamberger");
            Assert.IsTrue(lt.IsUrlMatchAsExpected(PRESS_URL), ErrorMessage.LT.WRONG_COMPANY_PAGE_LANDING);
            current_url = Utility.Utility.GetCurrentUrl(Driver);
            Assert.IsTrue(Utility.Utility.CheckHttpWebResponse(current_url), ErrorMessage.LT.NO_RESPONSE_FROM_HTTP);

            ReportLog("###7. Click Carrer and check redirect page.");
            lt.ClickCareerLink("Hamberger");
            Assert.IsTrue(lt.IsUrlMatchAsExpected(CARRER_URL), ErrorMessage.LT.WRONG_COMPANY_PAGE_LANDING);
            current_url = Utility.Utility.GetCurrentUrl(Driver);
            Assert.IsTrue(Utility.Utility.CheckHttpWebResponse(current_url), ErrorMessage.LT.NO_RESPONSE_FROM_HTTP);

            ReportLog("###8. Click Contact us and check redirect page.");
            lt.ClickContactusLink("Hamberger");
            Assert.IsTrue(lt.IsUrlMatchAsExpected(CONTACT_US_URL), ErrorMessage.LT.WRONG_COMPANY_PAGE_LANDING);
            current_url = Utility.Utility.GetCurrentUrl(Driver);
            Assert.IsTrue(Utility.Utility.CheckHttpWebResponse(current_url), ErrorMessage.LT.NO_RESPONSE_FROM_HTTP);

            ReportLog("###9. Click Privacy and check redirect page.");
            lt.ClickPrivacyLink("Hamberger");
            Assert.IsTrue(lt.IsUrlMatchAsExpected(PRIVACY_URL), ErrorMessage.LT.WRONG_COMPANY_PAGE_LANDING);
            current_url = Utility.Utility.GetCurrentUrl(Driver);
            Assert.IsTrue(Utility.Utility.CheckHttpWebResponse(current_url), ErrorMessage.LT.NO_RESPONSE_FROM_HTTP);

            ReportLog("###10. Click Terms and check redirect page.");
            lt.ClickTermsLink("Hamberger");
            Assert.IsTrue(lt.IsUrlMatchAsExpected(TERMS_URL), ErrorMessage.LT.WRONG_COMPANY_PAGE_LANDING);
            current_url = Utility.Utility.GetCurrentUrl(Driver);
            Assert.IsTrue(Utility.Utility.CheckHttpWebResponse(current_url), ErrorMessage.LT.NO_RESPONSE_FROM_HTTP);

            ReportLog("###11. Click DMCA and check redirect page.");
            lt.ClickDmcaLink("Hamberger");
            Assert.IsTrue(lt.IsUrlMatchAsExpected(DMCA_URL), ErrorMessage.LT.WRONG_COMPANY_PAGE_LANDING);
            current_url = Utility.Utility.GetCurrentUrl(Driver);
            Assert.IsTrue(Utility.Utility.CheckHttpWebResponse(current_url), ErrorMessage.LT.NO_RESPONSE_FROM_HTTP);

            //Log Report as PASSED
            test.Log(LogStatus.Pass, "Test Passed.");
        }
    }
}
