using NUnit.Framework;
using RelevantCodes.ExtentReports;
using WebsiteAutomate.Project.LT.Pagebase;
using WebsiteAutomate.Utility;

namespace WebsiteAutomate.Project.LT
{
    [TestFixture]
    [Parallelizable]
    [Category("MobileRegression")]
    public  class RegressionMobile3 : BaseTest
    {
        private LTPageBase lt;
        private const string LT_URL = "https://www.littlethings.com/";

        public override void InitFixtureSetup()
        {
            lt = new LTPageBase(Driver);
        }

        [Test]
        public void VerifySearchArticleMobile()
        {
            //Start Report
            test = GlobalSetup.bt.extent.StartTest("Verify Search function and search result page Mobile version.");

            ReportLog("###1. Landing to website homepage.");
            Driver.NavigateTo(LT_URL);
            ReportLog("###2. Do search with normal result.");
            lt.DoSearchMobile("Food");
            Assert.IsTrue(lt.IsSearchResultPage(), ErrorMessage.LT.NOT_SEARCH_RESULT_PAGE);
            Assert.IsTrue(lt.IsSearchArticleListDisplayMobile(), ErrorMessage.LT.NOT_FOUND_SEARCH_LIST_MOBILE);
            ReportLog("###3. Check Random Image on Atricle.");
            Assert.IsTrue(lt.IsArticleImageOnArticleListDisplayMobile(), ErrorMessage.LT.NOT_FOUND_ARTICLE_IMAGE);
            ReportLog("###4. Click on 1st article, and check on that article page.");
            lt.ClickArticleLinkMobile(2);
            ReportLog("###5. Check at least found 'Keyword' in the article");
            Assert.IsTrue(lt.CheckArticleMatchWithSearchMobile("Food"), ErrorMessage.LT.NOT_FOUND_SEARH_TEXT_IN_ARTICLE);
            ReportLog("###6. Do search again with 0 result.");
            lt.DoSearchMobile("garg6965%)(#%&");
            Assert.IsTrue(lt.IsNoContentFoundDisplayMobile(), ErrorMessage.LT.NOT_FOUND_NULL_SEARCH_RESULT_TEXT);

            //Log Report as PASSED
            test.Log(LogStatus.Pass, "Test Passed.");
        }
    }
}
