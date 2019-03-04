using NUnit.Framework;
using RelevantCodes.ExtentReports;
using WebsiteAutomate.Project.LT.Pagebase;
using WebsiteAutomate.Utility;

namespace WebsiteAutomate.Project.LT
{
    [TestFixture]
    [Parallelizable]
    [Category("MobileRegression")]
    public  class RegressionMobile8 : BaseTest
    {
        private LTPageBase lt;
        private const string VIDEO_ARTICLE_URL = "https://www.littlethings.com/susan-boyle-returns-americas-got-talent";

        public override void InitFixtureSetup()
        {
            lt = new LTPageBase(Driver);
        }

        [Test]
        public void VerifyVideoArticleMobile()
        {
            //Start Report
            test = GlobalSetup.bt.extent.StartTest("Verify All maain components on Video Article page Mobile version.");

            ReportLog("###1. Landing to Video article.");
            Driver.NavigateTo(VIDEO_ARTICLE_URL);

            ReportLog("###2. Check all components on article page.");
            //Check Image
            Assert.IsTrue(lt.IsMainImageArticleDisplayMobile(), ErrorMessage.LT.NOT_FOUND_MAIN_ARTICLE_IMAGE);
            //Check Title
            Assert.IsTrue(lt.CheckArticleTitleDisplayMobile(), ErrorMessage.LT.NOT_FOUND_ARTICLE_TITLE);
            //Check Author
            Assert.IsTrue(lt.IsAuthorArticleDisplay(), ErrorMessage.LT.NOT_FOUND_ARTICLE_AUTHOR);
            //Check main content
            Assert.IsTrue(lt.IsMainContentArticleDisplay(), ErrorMessage.LT.NOT_FOUND_ARTICLE_CONTENT_BODY);
            //Check FB share button
            Assert.IsTrue(lt.IsFacebookShareButtonEnableMobile(), ErrorMessage.LT.NOT_FOUND_FB_SHARE_BUTTON);

            ReportLog("###3. Check video is working properly.");
            Assert.IsTrue(lt.IsFeatureVideoDisplay(), ErrorMessage.LT.NOT_FOUND_VIDEO_PLAYING);

            //Log Report as PASSED
            test.Log(LogStatus.Pass, "Test Passed.");
        }
    }
}
