using NUnit.Framework;
using RelevantCodes.ExtentReports;
using WebsiteAutomate.Project.LT.Pagebase;
using WebsiteAutomate.Utility;

namespace WebsiteAutomate.Project.LT
{
    [TestFixture]
    [Parallelizable]
    [Category("MobileRegression")]
    public  class RegressionMobile4 : BaseTest
    {
        private LTPageBase lt;
        private const string LT_URL = "https://www.littlethings.com/";

        public override void InitFixtureSetup()
        {
            lt = new LTPageBase(Driver);
        }

        [Test]
        public void VerifyAllCategoryPageMobile()
        {
            //Start Report
            test = GlobalSetup.bt.extent.StartTest("Verify All Catagories page working properly Mobile Version.");

            ReportLog("###1. Landing to website homepage.");
            Driver.NavigateTo(LT_URL);
            Assert.IsTrue(lt.IsHeroImageDisplayMobile(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            ReportLog("###2. Click Healthy catagory on Food Categories, check number of article lists.");
            lt.ClickHealthyMenuMobile();
            Assert.IsTrue(lt.IsCatagoryBadgeDisplayCorrectly("healthy"), ErrorMessage.LT.NOT_FOUND_CATAGORY_BAGE);
            Assert.IsTrue(lt.CheckNumberOfArticleFirstLoadMobile(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_FIRST_LOAD_DESKTOP);
            ReportLog("###3. Click Logo back to home page.");
            lt.ClickLTLogo();
            Assert.IsTrue(lt.IsHeroImageDisplay(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            ReportLog("###4. Click Sweet catagory on Food Categories, check number of article lists.");
            lt.ClickSweetMenuMobile();
            Assert.IsTrue(lt.IsCatagoryBadgeDisplayCorrectly("sweet"), ErrorMessage.LT.NOT_FOUND_CATAGORY_BAGE);
            Assert.IsTrue(lt.CheckNumberOfArticleFirstLoadMobile(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_FIRST_LOAD_DESKTOP);
            ReportLog("###5. Click Logo back to home page.");
            lt.ClickLTLogo();
            Assert.IsTrue(lt.IsHeroImageDisplayMobile(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            ReportLog("###6. Click Savory catagory on Food Categories, check number of article lists.");
            lt.ClickSavoryMenuMobile();
            Assert.IsTrue(lt.IsCatagoryBadgeDisplayCorrectly("savory"), ErrorMessage.LT.NOT_FOUND_CATAGORY_BAGE);
            Assert.IsTrue(lt.CheckNumberOfArticleFirstLoadMobile(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_FIRST_LOAD_DESKTOP);

            //Log Report as PASSED
            test.Log(LogStatus.Pass, "Test Passed.");
        }
    }
}
