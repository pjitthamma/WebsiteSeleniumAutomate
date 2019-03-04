using NUnit.Framework;
using RelevantCodes.ExtentReports;
using WebsiteAutomate.Project.LT.Pagebase;
using WebsiteAutomate.Utility;

namespace WebsiteAutomate.Project.LT
{
    [TestFixture]
    [Parallelizable]
    [Category("DesktopRegression")]
    public  class RegressionDesktop11 : BaseTest
    {
        private LTPageBase lt;
        private const string VERTICAL_GALLERIES_URL = "https://www.littlethings.com/fake-stained-glass";
        private const string NATIVE_SPONSOR_ARTICLE_URL = "https://www.littlethings.com/holiday-peppermint-bark-smores";
        private const string PAGINATED_GALLERIES_URL = "https://www.littlethings.com/unique-wedding-rings";
        private const string SLIDESHOW_GALLERIES_URL = "https://www.littlethings.com/fastest-accelerating-cars-in-the-world";
        private const string VIDEO_ARTICLE_URL = "https://www.littlethings.com/susan-boyle-returns-americas-got-talent";

        public override void InitFixtureSetup()
        {
            lt = new LTPageBase(Driver);
        }

        [Test]
        public void VerifyFacebookShareOnEachArticles()
        {
            //Start Report
            test = GlobalSetup.bt.extent.StartTest("Verify Facebook share feature on each article type.");

            //Vertical gallery
            ReportLog("###1. Landing to Vertical gallery article.");
            Driver.NavigateTo(VERTICAL_GALLERIES_URL);
            ReportLog("###2. Check Facebook share on Menu bar and under article.");
            //Check FB share button
            Assert.IsTrue(lt.IsFacebookShareButtonEnable(), ErrorMessage.LT.NOT_FOUND_FB_SHARE_BUTTON);
            ReportLog("###3. Click Facebook Share button and check window popup.");
            lt.ClickFacebookShareButton();
            //Check url correct
            Assert.IsTrue(lt.IsFacebookWindowPopupDisplayed("fake-stained-glass"), ErrorMessage.LT.WRONG_FACEBOOK_SHARED_URL);
            //close facebook popup
            lt.ClosePopupFacebook();

            //Sponsor article
            ReportLog("###4. Landing to Vertical gallery article.");
            Driver.NavigateTo(NATIVE_SPONSOR_ARTICLE_URL);
            ReportLog("###5. Check Facebook share on Menu bar and under article.");
            //Check FB share button
            Assert.IsTrue(lt.IsFacebookShareButtonEnable(), ErrorMessage.LT.NOT_FOUND_FB_SHARE_BUTTON);
            ReportLog("###6. Click Facebook Share button and check window popup.");
            lt.ClickFacebookShareButton();
            //Check url correct
            Assert.IsTrue(lt.IsFacebookWindowPopupDisplayed("holiday-peppermint-bark-smores"), ErrorMessage.LT.WRONG_FACEBOOK_SHARED_URL);
            //close facebook popup
            lt.ClosePopupFacebook();

            //pagination article
            ReportLog("###7. Landing to Pagination gallery article.");
            Driver.NavigateTo(PAGINATED_GALLERIES_URL);
            ReportLog("###8. Check Facebook share on Menu bar and under article.");
            //Check FB share button
            Assert.IsTrue(lt.IsFacebookShareButtonEnable(), ErrorMessage.LT.NOT_FOUND_FB_SHARE_BUTTON);
            ReportLog("###9. Click Facebook Share button and check window popup.");
            lt.ClickFacebookShareButton();
            //Check url correct
            Assert.IsTrue(lt.IsFacebookWindowPopupDisplayed("unique-wedding-rings"), ErrorMessage.LT.WRONG_FACEBOOK_SHARED_URL);
            //close facebook popup
            lt.ClosePopupFacebook();

            //Slideshow article
            ReportLog("###10. Landing to Slideshow gallery article.");
            Driver.NavigateTo(SLIDESHOW_GALLERIES_URL);
            ReportLog("###11. Check Facebook share on Menu bar and under article.");
            //Check FB share button
            Assert.IsTrue(lt.IsFacebookShareButtonEnable(), ErrorMessage.LT.NOT_FOUND_FB_SHARE_BUTTON);
            ReportLog("###12. Click Facebook Share button and check window popup.");
            lt.ClickFacebookShareButton();
            //Check url correct
            Assert.IsTrue(lt.IsFacebookWindowPopupDisplayed("fastest-accelerating-cars-in-the-world"), ErrorMessage.LT.WRONG_FACEBOOK_SHARED_URL);
            //close facebook popup
            lt.ClosePopupFacebook();

            //Video article
            ReportLog("###13. Landing to Video gallery article.");
            Driver.NavigateTo(VIDEO_ARTICLE_URL);
            ReportLog("###14. Check Facebook share on Menu bar and under article.");
            //Check FB share button
            Assert.IsTrue(lt.IsFacebookShareButtonEnable(), ErrorMessage.LT.NOT_FOUND_FB_SHARE_BUTTON);
            ReportLog("###15. Click Facebook Share button and check window popup.");
            lt.ClickFacebookShareButton();
            //Check url correct
            Assert.IsTrue(lt.IsFacebookWindowPopupDisplayed("susan-boyle-returns-americas-got-talent"), ErrorMessage.LT.WRONG_FACEBOOK_SHARED_URL);
            //close facebook popup
            lt.ClosePopupFacebook();

            //Log Report as PASSED
            test.Log(LogStatus.Pass, "Test Passed.");
        }
    }
}
