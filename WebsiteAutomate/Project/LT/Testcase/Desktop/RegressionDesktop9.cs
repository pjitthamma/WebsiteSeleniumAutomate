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
    [Category("DesktopRegression")]
    public  class RegressionDesktop9 : BaseTest
    {
        private LTPageBase lt;
        private const string NATIVE_SPONSOR_ARTICLE_URL = "https://www.littlethings.com/holiday-peppermint-bark-smores";

        public override void InitFixtureSetup()
        {
            lt = new LTPageBase(Driver);
        }

        [Test]
        public void VerifyNativeSponsorArticle()
        {
            //Start Report
            test = GlobalSetup.bt.extent.StartTest("Verify All maain components on Native/Sponsor Article page.");

            ReportLog("###1. Landing to Native/Sponsor article.");
            Driver.NavigateTo(NATIVE_SPONSOR_ARTICLE_URL);

            ReportLog("###2. Check all components on article page.");
            //Check Image
            Assert.IsTrue(lt.IsMainImageArticleDisplay(), ErrorMessage.LT.NOT_FOUND_MAIN_ARTICLE_IMAGE);
            //Check Title
            Assert.IsTrue(lt.CheckArticleTitleDisplay(), ErrorMessage.LT.NOT_FOUND_ARTICLE_TITLE);
            //Check SponsorAuthor
            Assert.IsTrue(lt.IsSponsorAuthorArticleDisplay(), ErrorMessage.LT.NOT_FOUND_SPONSOR_AUTHOR);
            //Check main content
            Assert.IsTrue(lt.IsMainContentArticleDisplay(), ErrorMessage.LT.NOT_FOUND_ARTICLE_CONTENT_BODY);
            //Check FB share button
            Assert.IsTrue(lt.IsFacebookShareButtonEnable(), ErrorMessage.LT.NOT_FOUND_FB_SHARE_BUTTON);
            // Check Viseo Feature
            Assert.IsTrue(lt.IsFeatureVideoDisplay(), ErrorMessage.LT.NOT_FOUND_VIDEO_PLAYING);

            //Log Report as PASSED
            test.Log(LogStatus.Pass, "Test Passed.");
        }
    }
}
