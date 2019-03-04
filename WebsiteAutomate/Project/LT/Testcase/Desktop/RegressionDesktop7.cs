using NUnit.Framework;
using RelevantCodes.ExtentReports;
using WebsiteAutomate.Project.LT.Pagebase;
using WebsiteAutomate.Utility;

namespace WebsiteAutomate.Project.LT
{
    [TestFixture]
    [Parallelizable]
    [Category("DesktopRegression")]
    public  class RegressionDesktop7 : BaseTest
    {
        private LTPageBase lt;
        private const string SLIDESHOW_GALLERIES_URL = "https://www.littlethings.com/fastest-accelerating-cars-in-the-world";

        public override void InitFixtureSetup()
        {
            lt = new LTPageBase(Driver);
        }

        [Test]
        public void VerifySlideShowGalleries()
        {
            //Start Report
            test = GlobalSetup.bt.extent.StartTest("Verify All maain components on Slideshow Galleries page.");

            ReportLog("###1. Landing to slide show gallery article.");
            Driver.NavigateTo(SLIDESHOW_GALLERIES_URL);

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
            //Check Post images
            Assert.IsTrue(lt.IsContentArticleImageDisplay(), ErrorMessage.LT.NOT_FOUND_ARTICLE_POST_IMAGE);

            ReportLog("###3. Click next on slide show and check the image is show properly.");
            lt.ClickNextImageSlideShow();
            Assert.IsTrue(lt.IsNextImageSlideShowDisplay(), ErrorMessage.LT.NOT_FOUND_ARTICLE_POST_IMAGE);
            Assert.IsTrue(lt.IsFacebookShareButtonEnable(), ErrorMessage.LT.NOT_FOUND_FB_SHARE_BUTTON);

            ReportLog("###4. Click next on slide show and check the image is show properly.");
            lt.ClickPervImageSlideShow();
            Assert.IsTrue(lt.IsContentArticleImageDisplay(), ErrorMessage.LT.NOT_FOUND_ARTICLE_POST_IMAGE);
            Assert.IsTrue(lt.IsFacebookShareButtonEnable(), ErrorMessage.LT.NOT_FOUND_FB_SHARE_BUTTON);

            //Log Report as PASSED
            test.Log(LogStatus.Pass, "Test Passed.");
        }
    }
}
