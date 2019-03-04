using NUnit.Framework;
using RelevantCodes.ExtentReports;
using WebsiteAutomate.Project.LT.Pagebase;
using WebsiteAutomate.Utility;

namespace WebsiteAutomate.Project.LT
{
    [TestFixture]
    [Parallelizable]
    [Category("DesktopRegression")]
    public  class RegressionDesktop1 : BaseTest
    {
        private LTPageBase lt;
        private const string LT_URL = "https://www.littlethings.com/";

        public override void InitFixtureSetup()
        {
            lt = new LTPageBase(Driver);
        }

        [Test]
        public void VerifyHambergerMenuAndArticleListofEachPage()
        {
            //Start Report
            test = GlobalSetup.bt.extent.StartTest("Verify Hamberger Menu and Number of Article List on Each page catagory");

            ReportLog("###1. Landing to website homepage.");
            Driver.NavigateTo(LT_URL);
            Assert.IsTrue(lt.IsHeroImageDisplay(),ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            ReportLog("###2. Check Hamberger Nav apprear when clicked.");
            lt.HoverHambergerMenu();
            Assert.IsTrue(lt.IsHambergerMenuNavBarDisplay(), ErrorMessage.LT.NOT_FOUND_HAMBERGER_NAV_BAR);

            //Food
            ReportLog("###3. Check Article list on Food Catagory page.");
            lt.ClickFoodCatButton();
            Assert.IsTrue(lt.IsCatagoryBadgeDisplayCorrectly("Food"), ErrorMessage.LT.NOT_FOUND_CATAGORY_BAGE);
            Assert.IsTrue(lt.CheckNumberOfArticleFirstLoadDesktop(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_FIRST_LOAD_DESKTOP);
            ReportLog("###4. Click Load More button and check Article lists again.");
            lt.ClickLoadmorebutton();
            Assert.IsTrue(lt.CheckNumberOfArticleAfterClickLoadMoreDesktop(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_LOAD_MORE_DESKTOP);
            ReportLog("###5. Click back to Homepage.");
            lt.ClickBrowserBack();
            Assert.IsTrue(lt.IsHeroImageDisplay(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            //Parents
            lt.HoverHambergerMenu();
            Assert.IsTrue(lt.IsHambergerMenuNavBarDisplay(), ErrorMessage.LT.NOT_FOUND_HAMBERGER_NAV_BAR);
            ReportLog("###6. Check Article list on Parents Catagory page.");
            lt.ClickParentCatButton();
            Assert.IsTrue(lt.IsCatagoryBadgeDisplayCorrectly("Parenting"), ErrorMessage.LT.NOT_FOUND_CATAGORY_BAGE);
            Assert.IsTrue(lt.CheckNumberOfArticleFirstLoadDesktop(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_FIRST_LOAD_DESKTOP);
            ReportLog("###7. Click Load More button and check Article lists again.");
            lt.ClickLoadmorebutton();
            Assert.IsTrue(lt.CheckNumberOfArticleAfterClickLoadMoreDesktop(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_LOAD_MORE_DESKTOP);
            ReportLog("###8. Click back to Homepage.");
            lt.ClickBrowserBack();
            Assert.IsTrue(lt.IsHeroImageDisplay(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            //Pets
            lt.HoverHambergerMenu();
            Assert.IsTrue(lt.IsHambergerMenuNavBarDisplay(), ErrorMessage.LT.NOT_FOUND_HAMBERGER_NAV_BAR);
            ReportLog("###9. Check Article list on Pets Catagory page.");
            lt.ClickPetsCatButton();
            Assert.IsTrue(lt.IsCatagoryBadgeDisplayCorrectly("Pets"), ErrorMessage.LT.NOT_FOUND_CATAGORY_BAGE);
            Assert.IsTrue(lt.CheckNumberOfArticleFirstLoadDesktop(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_FIRST_LOAD_DESKTOP);
            ReportLog("###10. Click Load More button and check Article lists again.");
            lt.ClickLoadmorebutton();
            Assert.IsTrue(lt.CheckNumberOfArticleAfterClickLoadMoreDesktop(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_LOAD_MORE_DESKTOP);
            ReportLog("###11. Click back to Homepage.");
            lt.ClickBrowserBack();
            Assert.IsTrue(lt.IsHeroImageDisplay(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            //DIY
            lt.HoverHambergerMenu();
            Assert.IsTrue(lt.IsHambergerMenuNavBarDisplay(), ErrorMessage.LT.NOT_FOUND_HAMBERGER_NAV_BAR);
            ReportLog("###12. Check Article list on DIY Catagory page.");
            lt.ClickDiyCatButton();
            Assert.IsTrue(lt.IsCatagoryBadgeDisplayCorrectly("DIY"), ErrorMessage.LT.NOT_FOUND_CATAGORY_BAGE);
            Assert.IsTrue(lt.CheckNumberOfArticleFirstLoadDesktop(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_FIRST_LOAD_DESKTOP);
            ReportLog("###13. Click Load More button and check Article lists again.");
            lt.ClickLoadmorebutton();
            Assert.IsTrue(lt.CheckNumberOfArticleAfterClickLoadMoreDesktop(), ErrorMessage.LT.WRONG_NUMBER_OF_ARTICLE_LIST_LOAD_MORE_DESKTOP);
            ReportLog("###14. Click back to Homepage.");
            lt.ClickBrowserBack();
            Assert.IsTrue(lt.IsHeroImageDisplay(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            //Show
            lt.HoverHambergerMenu();
            Assert.IsTrue(lt.IsHambergerMenuNavBarDisplay(), ErrorMessage.LT.NOT_FOUND_HAMBERGER_NAV_BAR);
            ReportLog("###15. Check Live stream on Shows Catagory page.");
            lt.ClickLiveCatButton();
            Assert.IsTrue(lt.IsHeaderImageOnShowsPageDisplay(), ErrorMessage.LT.NOT_FOUND_HEADER_IMAGE_SHOWS_PAGE);
            ReportLog("###16. Click back to Homepage.");
            lt.ClickBrowserBack();
            Assert.IsTrue(lt.IsHeroImageDisplay(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            //Game
            lt.HoverHambergerMenu();
            Assert.IsTrue(lt.IsHambergerMenuNavBarDisplay(), ErrorMessage.LT.NOT_FOUND_HAMBERGER_NAV_BAR);
            ReportLog("###17. Check Popup box on Games Caragory page.");
            lt.ClickGameCatButton();
            Assert.IsTrue(lt.IsGamePopupDisplay(), ErrorMessage.LT.NOT_FOUND_GAME_POPUP);
            ReportLog("###18. Click Close Games Popup.");
            lt.ClickGameCloseButton();
            Assert.IsTrue(lt.IsHeroImageDisplay(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);

            //Log Report as PASSED
            test.Log(LogStatus.Pass, "Test Passed.");
        }
    }
}
