using NUnit.Framework;
using RelevantCodes.ExtentReports;
using WebsiteAutomate.Project.LT.Pagebase;
using WebsiteAutomate.Utility;

namespace WebsiteAutomate.Project.LT
{
    [TestFixture]
    [Parallelizable]
    [Category("MobileRegression")]
    public  class RegressionMobile2 : BaseTest
    {
        private LTPageBase lt;
        private const string LT_URL = "https://www.littlethings.com/";

        public override void InitFixtureSetup()
        {
            lt = new LTPageBase(Driver);
        }

        [Test]
        public void VerifyMainSectionHomepageMobile()
        {
            //Start Report
            test = GlobalSetup.bt.extent.StartTest("Verify All main section Homepage Mobile version");

            ReportLog("###1. Landing to website homepage.");
            Driver.NavigateTo(LT_URL);
            ReportLog("###2. Checking all components on header.");
            Assert.IsTrue(lt.IsLTLogoDisplay(), ErrorMessage.LT.NOT_FOUND_LT_LOGO);

            ReportLog("###3. Checking all components on center main post.");
            Assert.IsTrue(lt.IsHeroImageDisplayMobile(), ErrorMessage.LT.NOT_FOUND_HERO_IMAGE);
            Assert.IsTrue(lt.IsTitleWarpDisplay(), ErrorMessage.LT.NOT_FOUND_TITLE_WARP);
            Assert.IsTrue(lt.IsPromoPostImageDisplayMobile(), ErrorMessage.LT.NOT_FOUND_PROMO_POST_IMAGE);

            ReportLog("###4. Check all components on Top reciepts.");
            Assert.IsTrue(lt.IsTopRecipesImageSlideShowDisplayMobile(), ErrorMessage.LT.NOT_FOUND_IMAGE_ON_TOP_RECIEPT_SLIDE_SHOW);
            ReportLog("###5. Click next on slide show, and check image again.");
            lt.ClickNextSlideShowMobile();
            Assert.IsTrue(lt.IsTopRecipesImageSlideShowDisplayMobile(), ErrorMessage.LT.NOT_FOUND_IMAGE_ON_TOP_RECIEPT_SLIDE_SHOW);
            ReportLog("###6. Click Prev on slide show, and check image again.");
            lt.ClickPrevSlideShowMobile();
            Assert.IsTrue(lt.IsTopRecipesImageSlideShowDisplayMobile(), ErrorMessage.LT.NOT_FOUND_IMAGE_ON_TOP_RECIEPT_SLIDE_SHOW);
            ReportLog("###7. Click See more link and check the article page is landing properly.");
            lt.ClickSeeMoreLink();
            Assert.IsTrue(lt.IsMainImageArticleDisplayMobile(), ErrorMessage.LT.NOT_FOUND_MAIN_ARTICLE_IMAGE);

            ReportLog("###8. Check all components on Food categories.");
            lt.ClickBrowserBack();
            Assert.IsTrue(lt.IsFoodCatagoryImageDisplayMobile(), ErrorMessage.LT.NOT_FOUND_IMAGE_ON_FOOD_CATAGORY);

            ReportLog("###9. Check video is working on Feature Video section.");
            Assert.IsTrue(lt.IsFeatureVideoDisplay(), ErrorMessage.LT.NOT_FOUND_VIDEO_PLAYING);
            Assert.IsTrue(lt.IsVideoListDisplayMobile(), ErrorMessage.LT.NOT_FOUND_VIDEO_LIST);
            ReportLog("###10. Click next Video on Video list and Landing to that Video Article");
            lt.ClickNextVideoListMobile();
            Assert.IsTrue(lt.IsMainImageArticleDisplayMobile(), ErrorMessage.LT.NOT_FOUND_MAIN_ARTICLE_IMAGE);
            lt.ClickBrowserBack();

            ReportLog("###11. Check Live section image show completely.");
            Assert.IsTrue(lt.IsLiveBrodcastImageDisplay(), ErrorMessage.LT.NOT_FOUND_LIVE_BROADCAST_IMAGE);

            ReportLog("###12. Check all components in Recent stories section.");
            Assert.IsTrue(lt.IsRecentStoryDisplayFirstLoadMobile(), ErrorMessage.LT.WRONG_RECENT_STORY_FIRST_LOAD);
            ReportLog("###13. Click view more stories and Check components again");
            Assert.IsTrue(lt.IsRecentStoryDisplayAfterClickViewmoreMobile(), ErrorMessage.LT.WRONG_RECENT_STORY_AFTER_CLICK_VIEW_MORE);

            ReportLog("###14. Check all component on Footer Section.");
            Assert.IsTrue(lt.CheckFooterSectionMobile(), ErrorMessage.LT.NOT_FOUND_FOOTER_LINK);

            //Log Report as PASSED
            test.Log(LogStatus.Pass, "Test Passed.");
        }
    }
}
