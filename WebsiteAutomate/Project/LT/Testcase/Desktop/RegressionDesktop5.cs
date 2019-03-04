using NUnit.Framework;
using RelevantCodes.ExtentReports;
using WebsiteAutomate.Project.LT.Pagebase;
using WebsiteAutomate.Utility;

namespace WebsiteAutomate.Project.LT
{
    [TestFixture]
    [Parallelizable]
    [Category("DesktopRegression")]
    public  class RegressionDesktop5 : BaseTest
    {
        private LTPageBase lt;
        private const string PAGINATED_GALLERIES_URL = "https://www.littlethings.com/unique-wedding-rings";

        public override void InitFixtureSetup()
        {
            lt = new LTPageBase(Driver);
        }

        [Test]
        public void VerifyPaginatedGalleries()
        {
            //Start Report
            test = GlobalSetup.bt.extent.StartTest("Verify All maain components on Paginated Galleries page.");

            ReportLog("###1. Landing to pagination gallery article.");
            Driver.NavigateTo(PAGINATED_GALLERIES_URL);

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

            ReportLog("###3. Check pagination bar is show properly.");
            Assert.IsTrue(lt.IsPaginationDisplay(), ErrorMessage.LT.NOT_FOUND_PAGINAION_NAV_BAR);
            ReportLog("###4. Click 'Next' on pagination, and check result again.");
            lt.ClickPaginetionNext();
            Assert.IsTrue(lt.IsFacebookShareButtonEnable(), ErrorMessage.LT.NOT_FOUND_FB_SHARE_BUTTON);
            Assert.IsTrue(lt.IsContentArticleImageDisplay(), ErrorMessage.LT.NOT_FOUND_ARTICLE_POST_IMAGE);
            ReportLog("###5. Click 'Prev' on pagination, and check result again.");
            lt.ClickPaginetionPrev();
            Assert.IsTrue(lt.IsFacebookShareButtonEnable(), ErrorMessage.LT.NOT_FOUND_FB_SHARE_BUTTON);
            Assert.IsTrue(lt.IsContentArticleImageDisplay(), ErrorMessage.LT.NOT_FOUND_ARTICLE_POST_IMAGE);

            //Log Report as PASSED
            test.Log(LogStatus.Pass, "Test Passed.");
        }
    }
}
