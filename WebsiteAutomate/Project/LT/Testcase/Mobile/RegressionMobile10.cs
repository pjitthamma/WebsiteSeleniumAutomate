using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;
using System.Configuration;
using WebsiteAutomate.Project.LT.Pagebase;
using WebsiteAutomate.Utility;

namespace WebsiteAutomate.Project.LT
{
    [TestFixture]
    [Parallelizable]
    [Category("MobileRegression")]
    public  class RegressionMobile10 : BaseTest
    {
        private LTPageBase lt;
        private const string SHOWS_CAT_URL = "https://www.littlethings.com/live";

        public override void InitFixtureSetup()
        {
            lt = new LTPageBase(Driver);
        }

        [Test]
        public void VerifyComponentOnShowsPageMobile()
        {
            //Start Report
            test = GlobalSetup.bt.extent.StartTest("Verify All maain components on SHOWS catagory page mobile version.");

            ReportLog("###1. Landing to SHOWS catagory page.");
            Driver.NavigateTo(SHOWS_CAT_URL);

            ReportLog("###2. Check all Main image on Shows catagory page.");
            Assert.IsTrue(lt.IsHeaderImageOnShowsPageDisplayMobile(), ErrorMessage.LT.NOT_FOUND_MAIN_ARTICLE_IMAGE);
            ReportLog("###3. Check Our programs list on Shows catagory page.");
            Assert.IsTrue(lt.IsOurProgramesDisplayMobile(), ErrorMessage.LT.NOT_FOUND_OUR_PROGRAM);
            Assert.IsTrue(lt.CheckNumberOfVideoBlockMobile(), ErrorMessage.LT.WRONG_NUMBER_OF_OUR_PROGRAM_MOBILE);
            ReportLog("###4. Click 1st menu on Quick select and check landing page.");
            lt.ClickQuickSelectedButton();
            lt.ClickFirstQuickSelectedMenu();
            ReportLog("###5. Check main component on Sub show page.");
            //Check image
            Assert.IsTrue(lt.IsSubShowMainImageDisplayMobile(), ErrorMessage.LT.NOT_FOUND_SUB_SHOW_IMAGE);
            //Check header
            Assert.IsTrue(lt.CheckIsMenuHeaderCorrectMobile("Best or Hot Mess"), ErrorMessage.LT.WRONG_SUB_SHOW_MENU_HEADER);
            //Check sub video list
            Assert.IsTrue(lt.IsSubShowVideoListDisplay(), ErrorMessage.LT.NOT_FOUND_VIDEO_LIST);
            //Check image on video list
            Assert.IsTrue(lt.IsSubShowVideoListImageDisplay(), ErrorMessage.LT.NOT_FOUND_VIDEO_LIST_IMAGE);
            ReportLog("###6. Click 1st sub video list and check video feature.");
            lt.ClickFirstSubShowVideoListMobile();
            Assert.IsTrue(lt.IsFeatureVideoDisplay(), ErrorMessage.LT.NOT_FOUND_VIDEO_PLAYING);
            ReportLog("###7. Close video panel and Click back to show.");
            lt.ClickCloseVideoPlayer();
            //Check image
            Assert.IsTrue(lt.IsSubShowMainImageDisplayMobile(), ErrorMessage.LT.NOT_FOUND_SUB_SHOW_IMAGE);

            //Log Report as PASSED
            test.Log(LogStatus.Pass, "Test Passed.");
        }
    }
}
