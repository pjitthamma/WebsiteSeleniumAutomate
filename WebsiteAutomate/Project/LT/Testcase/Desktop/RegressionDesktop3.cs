using NUnit.Framework;
using RelevantCodes.ExtentReports;
using WebsiteAutomate.Project.LT.Pagebase;
using WebsiteAutomate.Utility;

namespace WebsiteAutomate.Project.LT
{
    [TestFixture]
    [Parallelizable]
    [Category("DesktopRegression")]
    public  class RegressionDesktop3 : BaseTest
    {
        private LTPageBase lt;
        private const string LT_URL = "https://www.littlethings.com/";

        public override void InitFixtureSetup()
        {
            lt = new LTPageBase(Driver);
        }

        [Test]
        public void VerifySearchArticle()
        {
            //Start Report
            test = GlobalSetup.bt.extent.StartTest("Verify Search function and search result page.");

            ReportLog("###1. Landing to website homepage.");
            Driver.NavigateTo(LT_URL);
            ReportLog("###2. Do search with normal result.");
            lt.DoSearch("Food");
            Assert.IsTrue(lt.IsSearchResultPage(), ErrorMessage.LT.NOT_SEARCH_RESULT_PAGE);
            Assert.IsTrue(lt.IsArticleWrapperDisplay(), ErrorMessage.LT.NOT_FOUND_ARTICLE_WARPPER);
            ReportLog("###3. Check Random Image on Atricle.");
            Assert.IsTrue(lt.IsArticleImageOnArticleWarpperDisplay(), ErrorMessage.LT.NOT_FOUND_ARTICLE_IMAGE);
            ReportLog("###4. Click on 1st article, and check on that article page.");
            lt.ClickArticleLink(1);
            ReportLog("###5. Check at least found 'Keyword' in the article");
            Assert.IsTrue(lt.CheckArticleMatchWithSearch("Food"), ErrorMessage.LT.NOT_FOUND_SEARH_TEXT_IN_ARTICLE);
            ReportLog("###6. Do search again with 0 result.");
            lt.DoSearch("garg6965%)(#%&");
            Assert.IsTrue(lt.IsSearchResultPage(), ErrorMessage.LT.NOT_SEARCH_RESULT_PAGE);
            Assert.IsTrue(lt.IsNoContentFoundDisplay(), ErrorMessage.LT.NOT_FOUND_NULL_SEARCH_RESULT_TEXT);

            //Log Report as PASSED
            test.Log(LogStatus.Pass, "Test Passed.");
        }
    }
}
