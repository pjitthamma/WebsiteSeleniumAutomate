using NUnit.Framework;
using RelevantCodes.ExtentReports;
using WebsiteAutomate.Project.LT.Pagebase;
using WebsiteAutomate.Utility;

namespace WebsiteAutomate.Project.LT
{
    [TestFixture]
    [Parallelizable]
    [Category("DesktopRegression")]
    public  class RegressionDesktop4 : BaseTest
    {
        private LTPageBase lt;
        private const string LT_URL = "https://www.littlethings.com/";

        public override void InitFixtureSetup()
        {
            lt = new LTPageBase(Driver);
        }

        [Test]
        public void VerifyAllCategoryPage()
        {
            //Start Report
            test = GlobalSetup.bt.extent.StartTest("Verify All Catagories page working properly.");

            ReportLog("###1. Landing to website homepage.");
            Driver.NavigateTo(LT_URL);
            Assert.IsTrue(lt.IsHeroImageDisplay(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);
            ReportLog("###2. Click SHOWS catagory on menu bar, check main image on SHOWS page.");
            lt.ClickShowsMenu();
            Assert.IsTrue(lt.IsHeaderImageOnShowsPageDisplay(), ErrorMessage.LT.NOT_FOUND_HEADER_IMAGE_SHOWS_PAGE);
            ReportLog("###3. Click Logo back to home page.");
            lt.ClickLTLogo();
            Assert.IsTrue(lt.IsHeroImageDisplay(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            ReportLog("###4. Click FOOD catagory on menu bar, check number of article lists.");
            lt.ClickFoodMenu();
            Assert.IsTrue(lt.IsCatagoryBadgeDisplayCorrectly("Food"), ErrorMessage.LT.NOT_FOUND_CATAGORY_BAGE);
            Assert.IsTrue(lt.CheckNumberOfArticleFirstLoadDesktop(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_FIRST_LOAD_DESKTOP);
            ReportLog("###5. Click Logo back to home page.");
            lt.ClickLTLogo();
            Assert.IsTrue(lt.IsHeroImageDisplay(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            ReportLog("###6. Click PARENTING catagory on menu bar, check number of article lists.");
            lt.ClickParentingMenu();
            Assert.IsTrue(lt.IsCatagoryBadgeDisplayCorrectly("Parenting"), ErrorMessage.LT.NOT_FOUND_CATAGORY_BAGE);
            Assert.IsTrue(lt.CheckNumberOfArticleFirstLoadDesktop(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_FIRST_LOAD_DESKTOP);
            ReportLog("###7. Click Logo back to home page.");
            lt.ClickLTLogo();
            Assert.IsTrue(lt.IsHeroImageDisplay(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            ReportLog("###8. Click PETS catagory on menu bar, check number of article lists.");
            lt.ClickPetsMenu();
            Assert.IsTrue(lt.IsCatagoryBadgeDisplayCorrectly("Pets"), ErrorMessage.LT.NOT_FOUND_CATAGORY_BAGE);
            Assert.IsTrue(lt.CheckNumberOfArticleFirstLoadDesktop(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_FIRST_LOAD_DESKTOP);
            ReportLog("###9. Click Logo back to home page.");
            lt.ClickLTLogo();
            Assert.IsTrue(lt.IsHeroImageDisplay(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            ReportLog("###10. Click DIY catagory on menu bar, check number of article lists.");
            lt.ClickDiyMenu();
            Assert.IsTrue(lt.IsCatagoryBadgeDisplayCorrectly("DIY"), ErrorMessage.LT.NOT_FOUND_CATAGORY_BAGE);
            Assert.IsTrue(lt.CheckNumberOfArticleFirstLoadDesktop(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_FIRST_LOAD_DESKTOP);
            ReportLog("###11. Click Logo back to home page.");
            lt.ClickLTLogo();
            Assert.IsTrue(lt.IsHeroImageDisplay(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            ReportLog("###12. Click Healthy catagory on Food Categories, check number of article lists.");
            lt.ClickHealthyMenu();
            Assert.IsTrue(lt.IsCatagoryBadgeDisplayCorrectly("Healthy"), ErrorMessage.LT.NOT_FOUND_CATAGORY_BAGE);
            Assert.IsTrue(lt.CheckNumberOfArticleFirstLoadDesktop(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_FIRST_LOAD_DESKTOP);
            ReportLog("###13. Click Logo back to home page.");
            lt.ClickLTLogo();
            Assert.IsTrue(lt.IsHeroImageDisplay(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            ReportLog("###14. Click Sweet catagory on Food Categories, check number of article lists.");
            lt.ClickSweetMenu();
            Assert.IsTrue(lt.IsCatagoryBadgeDisplayCorrectly("Sweet"), ErrorMessage.LT.NOT_FOUND_CATAGORY_BAGE);
            Assert.IsTrue(lt.CheckNumberOfArticleFirstLoadDesktop(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_FIRST_LOAD_DESKTOP);
            ReportLog("###15. Click Logo back to home page.");
            lt.ClickLTLogo();
            Assert.IsTrue(lt.IsHeroImageDisplay(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            ReportLog("###16. Click Savory catagory on Food Categories, check number of article lists.");
            lt.ClickSavoryMenu();
            Assert.IsTrue(lt.IsCatagoryBadgeDisplayCorrectly("Savory"), ErrorMessage.LT.NOT_FOUND_CATAGORY_BAGE);
            Assert.IsTrue(lt.CheckNumberOfArticleFirstLoadDesktop(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_FIRST_LOAD_DESKTOP);

            //Log Report as PASSED
            test.Log(LogStatus.Pass, "Test Passed.");
        }
    }
}
