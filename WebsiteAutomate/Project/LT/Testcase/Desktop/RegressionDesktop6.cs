using NUnit.Framework;
using RelevantCodes.ExtentReports;
using WebsiteAutomate.Project.LT.Pagebase;
using WebsiteAutomate.Utility;

namespace WebsiteAutomate.Project.LT
{
    [TestFixture]
    [Parallelizable]
    [Category("DesktopRegression")]
    public  class RegressionDesktop6 : BaseTest
    {
        private LTPageBase lt;
        private const string VERTICAL_GALLERIES_URL = "https://www.littlethings.com/fake-stained-glass";

        public override void InitFixtureSetup()
        {
            lt = new LTPageBase(Driver);
        }

        [Test]
        public void VerifyVerticalGalleries()
        {
            //Start Report
            test = GlobalSetup.bt.extent.StartTest("Verify All maain components on Vertical Galleries page.");

            ReportLog("###1. Landing to Vertical gallery article.");
            Driver.NavigateTo(VERTICAL_GALLERIES_URL);

            ReportLog("###2. Check all components on article page.");
            //Check Image
            Assert.IsTrue(lt.IsMainImageArticleDisplay(), ErrorMessage.LT.NOT_FOUND_MAIN_ARTICLE_IMAGE);
            //Check Title
            Assert.IsTrue(lt.CheckArticleTitleDisplay(), ErrorMessage.LT.NOT_FOUND_ARTICLE_TITLE);
            //Check Author
            Assert.IsTrue(lt.IsAuthorArticleDisplay(), ErrorMessage.LT.NOT_FOUND_ARTICLE_AUTHOR);
            //Check main content
            Assert.IsTrue(lt.IsMainContentArticleDisplay(), ErrorMessage.LT.NOT_FOUND_ARTICLE_CONTENT_BODY);
            //Check FB share button
            Assert.IsTrue(lt.IsFacebookShareButtonEnable(), ErrorMessage.LT.NOT_FOUND_FB_SHARE_BUTTON);
            //Check Vertical image sets
            Assert.IsTrue(lt.CheckVerticalImageShowProperly(), ErrorMessage.LT.NOT_FOUND_IMAGE_SLIDESHOW);

            //Log Report as PASSED
            test.Log(LogStatus.Pass, "Test Passed.");
        }
    }
}
