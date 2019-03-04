using NUnit.Framework;
using RelevantCodes.ExtentReports;
using WebsiteAutomate.Project.LT.Pagebase;
using WebsiteAutomate.Utility;

namespace WebsiteAutomate.Project.LT
{
    [TestFixture]
    [Parallelizable]
    [Category("MobileRegression")]
    public  class RegressionMobile1 : BaseTest
    {
        private LTPageBase lt;
        private const string LT_URL = "https://www.littlethings.com/";

        public override void InitFixtureSetup()
        {
            lt = new LTPageBase(Driver);
        }

        [Test]
        public void VerifyHambergerMenuAndArticleListofEachPageMobile()
        {
            //Start Report
            test = GlobalSetup.bt.extent.StartTest("Verify Hamberger Menu and Number of Article List on Each page catagory Mobile version");

            ReportLog("###1. Landing to website homepage.");
            Driver.NavigateTo(LT_URL);
            Assert.IsTrue(lt.IsHeroImageDisplayMobile(),ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            ReportLog("###2. Check Hamberger Nav apprear when clicked.");
            lt.ClickHambergerMenu();
            Assert.IsTrue(lt.IsHambergerMenuNavBarMobileDisplay(), ErrorMessage.LT.NOT_FOUND_HAMBERGER_NAV_BAR);

            //Food
            ReportLog("###3. Check Article list on Food Catagory page.");
            lt.ClickFoodCatButtonMobile();
            Assert.IsTrue(lt.IsCatagoryBadgeDisplayCorrectly("FOOD"), ErrorMessage.LT.NOT_FOUND_CATAGORY_BAGE);
            Assert.IsTrue(lt.CheckNumberOfArticleFirstLoadMobile(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_FIRST_LOAD_MOBILE);
            ReportLog("###4. Click Load More button and check Article lists again.");
            lt.ClickLoadmorebuttonMobile();
            Assert.IsTrue(lt.CheckNumberOfArticleAfterClickLoadMoreMobile(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_LOAD_MORE_MOBILE);
            ReportLog("###5. Click back to Homepage.");
            lt.ClickBrowserBack();
            Assert.IsTrue(lt.IsHeroImageDisplayMobile(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            //Parents
            lt.ClickHambergerMenu();
            Assert.IsTrue(lt.IsHambergerMenuNavBarMobileDisplay(), ErrorMessage.LT.NOT_FOUND_HAMBERGER_NAV_BAR);
            ReportLog("###6. Check Article list on Parents Catagory page.");
            lt.ClickParentCatButtonMobile();
            Assert.IsTrue(lt.IsCatagoryBadgeDisplayCorrectly("PARENTING"), ErrorMessage.LT.NOT_FOUND_CATAGORY_BAGE);
            Assert.IsTrue(lt.CheckNumberOfArticleFirstLoadMobile(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_FIRST_LOAD_MOBILE);
            ReportLog("###7. Click Load More button and check Article lists again.");
            lt.ClickLoadmorebuttonMobile();
            Assert.IsTrue(lt.CheckNumberOfArticleAfterClickLoadMoreMobile(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_LOAD_MORE_MOBILE);
            ReportLog("###8. Click back to Homepage.");
            lt.ClickBrowserBack();
            Assert.IsTrue(lt.IsHeroImageDisplayMobile(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            //Pets
            lt.ClickHambergerMenu();
            Assert.IsTrue(lt.IsHambergerMenuNavBarMobileDisplay(), ErrorMessage.LT.NOT_FOUND_HAMBERGER_NAV_BAR);
            ReportLog("###9. Check Article list on Pets Catagory page.");
            lt.ClickPetsCatButtonMobile();
            Assert.IsTrue(lt.IsCatagoryBadgeDisplayCorrectly("PETS"), ErrorMessage.LT.NOT_FOUND_CATAGORY_BAGE);
            Assert.IsTrue(lt.CheckNumberOfArticleFirstLoadMobile(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_FIRST_LOAD_MOBILE);
            ReportLog("###10. Click Load More button and check Article lists again.");
            lt.ClickLoadmorebuttonMobile();
            Assert.IsTrue(lt.CheckNumberOfArticleAfterClickLoadMoreMobile(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_LOAD_MORE_MOBILE);
            ReportLog("###11. Click back to Homepage.");
            lt.ClickBrowserBack();
            Assert.IsTrue(lt.IsHeroImageDisplayMobile(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            //DIY
            lt.ClickHambergerMenu();
            Assert.IsTrue(lt.IsHambergerMenuNavBarMobileDisplay(), ErrorMessage.LT.NOT_FOUND_HAMBERGER_NAV_BAR);
            ReportLog("###12. Check Article list on DIY Catagory page.");
            lt.ClickDiyCatButtonMobile();
            Assert.IsTrue(lt.IsCatagoryBadgeDisplayCorrectly("DIY"), ErrorMessage.LT.NOT_FOUND_CATAGORY_BAGE);
            Assert.IsTrue(lt.CheckNumberOfArticleFirstLoadMobile(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_FIRST_LOAD_MOBILE);
            ReportLog("###13. Click Load More button and check Article lists again.");
            lt.ClickLoadmorebuttonMobile();
            Assert.IsTrue(lt.CheckNumberOfArticleAfterClickLoadMoreMobile(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_LOAD_MORE_MOBILE);
            ReportLog("###14. Click back to Homepage.");
            lt.ClickBrowserBack();
            Assert.IsTrue(lt.IsHeroImageDisplayMobile(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            //Show
            lt.ClickHambergerMenu();
            Assert.IsTrue(lt.IsHambergerMenuNavBarMobileDisplay(), ErrorMessage.LT.NOT_FOUND_HAMBERGER_NAV_BAR);
            ReportLog("###15. Check Live stream on Shows Catagory page.");
            lt.ClickLiveCatButtonMobile();
            Assert.IsTrue(lt.IsHeaderImageOnShowsPageDisplayMobile(), ErrorMessage.LT.NOT_FOUND_HEADER_IMAGE_SHOWS_PAGE);
            ReportLog("###16. Click back to Homepage.");
            lt.ClickBrowserBack();
            Assert.IsTrue(lt.IsHeroImageDisplayMobile(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            //Game
            lt.ClickHambergerMenu();
            Assert.IsTrue(lt.IsHambergerMenuNavBarMobileDisplay(), ErrorMessage.LT.NOT_FOUND_HAMBERGER_NAV_BAR);
            ReportLog("###17. Check Popup box on Games Caragory page.");
            lt.ClickGameCatButtonMobile();
            Assert.IsTrue(lt.IsGamePopupDisplayMobile(), ErrorMessage.LT.NOT_FOUND_GAME_POPUP);
            ReportLog("###18. Click Close Games Popup.");
            lt.ClickGameCloseButtonMobile();
            Assert.IsTrue(lt.IsHeroImageDisplayMobile(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            //Home
            lt.ClickHambergerMenu();
            Assert.IsTrue(lt.IsHambergerMenuNavBarMobileDisplay(), ErrorMessage.LT.NOT_FOUND_HAMBERGER_NAV_BAR);
            ReportLog("###19. Check Popup box on Games Caragory page.");
            lt.ClickGameHomeButtonMobile();
            Assert.IsTrue(lt.IsHeroImageDisplayMobile(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            //Log Report as PASSED
            test.Log(LogStatus.Pass, "Test Passed.");
        }
    }
}
