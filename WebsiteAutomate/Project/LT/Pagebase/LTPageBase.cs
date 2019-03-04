using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using WebsiteAutomate.Utility;

namespace WebsiteAutomate.Project.LT.Pagebase
{
    public class LTPageBase
    {
        #region Declaration
        //Homepage
        private const string XPATH_LT_LOGO = "//div[@class='lt-logo']";
        private const string XPATH_NAV_BAR_MENU_ITEM = "//ul[@class='main-nav']//li";
        private const string XPATH_HERO_IMAGE = "(//img[contains(@class,'lt-lazy-load-image b-loaded')])[2]";
        private const string CSS_TITLE_WARP = ".title-wrap";
        private const string XPATH_PROMO_POST = "//div[@class='carousel-posts center']//div";
        private const string XPATH_TOP_RECIPES = "//div[@class='recipe-slide center bg lt-lazy-load-image b-loaded']";
        private const string CSS_IMAGE_SLIDE_NEXT_BUTTON = ".bx-next";
        private const string CSS_IMAGE_SLIDE_PREV_BUTTON = ".bx-prev";
        private const string XPATH_SEE_MORE_ON_SLIDE = "(//a[@class='article-link'])[2]";
        private const string XPATH_FOOD_CATAGORY_ITEM = "//div[@class='center food-cat']//div";
        private const string XPATH_LIVE_BROAD_CAST = "//section[@class='live-brodcasts']//div//img";
        private const string CSS_RECENT_STORY = ".recentstories";
        private const string XAPTH_DOUBLE_TOP_STORY = "//div[@class='top-story double-top-storys']//div";
        private const string XPATH_SINGLE_TOP_STORY = "//div[@class='top-story single-top-story']";
        private const string CSS_SHOW_MORE_BUTTON = ".show-more";
        private const string XPATH_LASTEST_POST_WARP = "//div[@class='latest_posts_wrapper lt_processed']";
        private const string XPATH_FOOTER_LINK = "//ul[@class='footer-link-list']//li";
        private const string XPATH_SUB_FOOTER_LINK = "//div[@class='sub-footer']//a";
        private const string CSS_SHOWS_MENU = ".main-nav [data-slug='livelt']";
        private const string CSS_FOOD_MENU = ".main-nav [data-slug='Food']";
        private const string CSS_PARENTING_MENU = ".main-nav [data-slug='Parenting']";
        private const string CSS_PETS_MENU = ".main-nav [data-slug='Pets']";
        private const string CSS_DIY_MENU = ".main-nav [data-slug='Diy']";
        private const string XPATH_HEALTHY_MENU = "(//div[@class='center food-cat']//div)[1]";
        private const string XPATH_SWEET_MENU = "(//div[@class='center food-cat']//div)[2]";
        private const string XPATH_SAVORY_MENU = "(//div[@class='center food-cat']//div)[3]";
        private const string CSS_EMAIL_SUB_BOX = ".modal-subscribe.iner-module";
        private const string CSS_EMAIL_INPUT = "[name='target_email']";
        private const string XPATH_SIGN_UP_BUTTON = "//button[contains(text(), 'Sign Up')]";
        private const string CSS_THANK_YOU_SUB = ".thankyounote";
        private const string CSS_CLOSE_SUB_BUTTON = ".keep-reading.subscribe-close";
        private const string XPATH_ERROR_EMAIL = "//div[contains(text(), 'Please submit valid email address.')]";
        private const string CSS_DISSMISS_BUTTON = ".sbscribe-wrap>.click-dismiss";

        //Hamberger Menu
        private const string CSS_HAMBERGER_MENU_BUTTON = ".mainnav-activation";
        private const string CSS_HAMBERGER_NEV_BAR = ".side-navigation";
        private const string CSS_FOOD_CATAGORY = ".section-first [data-slug='Food']";
        private const string CSS_PARENTING_CATAGORY = ".section-first [data-slug='Parenting']";
        private const string CSS_PETS_CATAGORY = ".section-first [data-slug='Pets']";
        private const string CSS_DIY_CATAGORY = ".section-first [data-slug='Diy']";
        private const string CSS_LIVE_CATAGORY = ".section-first [data-slug='']";
        private const string CSS_GAME_CATAGORY = ".section-first [data-slug='Game LT']";
        private const string CSS_GAME_POPUP_CLOSE_BUTTON = ".modal-close.close";
        private const string CSS_GAME_POPUP = ".abtest1-cloud";

        //Seacrh Feature
        private const string CSS_SEARCH_BUTTON = ".fa.fa-search.site-search";
        private const string CSS_SEARCH_BAR = ".search-input";
        private const string CSS_SEARCH_RESULT = ".listing-from";
        private const string CSS_NULL_SEARCH_RESULT = ".num";
        private const string XPATH_ARTICLE_LIST_IMAGE = "//div[@class='articles_wrapper']/article/a";

        //Socials Feature
        private const string CSS_MORE_SOCIAL = ".fa.fa-ellipsis-h.social-button";
        private const string CSS_SOCIAL_FACEBOOK = ".soc-facebook";
        private const string CSS_SOCIAL_PINTEREST = ".soc-pinterest";
        private const string CSS_SOCIAL_TWITTER = ".soc-twitter";
        private const string CSS_SOCIAL_EMAIL = ".soc-email";

        //Video player
        private const string CSS_FEATURE_VIDEO = ".jw-video.jw-reset";
        private const string CSS_VIDEO_LIST = ".videos-list";
        private const string CSS_PLAY_VIDEO_BUTTON = "[aria-label='Play']";
        private const string CSS_PAUSE_VIDEO_BUTTON = "[aria-label='Pause']";
        private const string CSS_LOADING_VIDEO_BUTTON = "[aria-label='Loading']";

        //Company Link
        //Footer
        private const string XPATH_FOOTER_ABOUTUS = "//footer//a[contains(text(), 'About Us')]";
        private const string XPATH_FOOTER_ADVERTISING = "//footer//a[contains(text(), 'Advertising')]";
        private const string XPATH_FOOTER_PARTNERSHIP = "//footer//a[contains(text(), 'Partnerships')]";
        private const string XPATH_FOOTER_PRESS = "//footer//a[contains(text(), 'Press')]";
        private const string XPATH_FOOTER_CAREER = "//footer//a[contains(text(), 'Careers')]";
        private const string XPATH_FOOTER_CONTACTUS = "//footer//a[contains(text(), 'Contact Us')]";
        private const string XPATH_FOOTER_PRIVACY = "//footer//a[contains(text(), 'Privacy Policy')]";
        private const string XPATH_FOOTER_TERMS = "//footer//a[contains(text(), 'Terms Of Service')]";
        private const string XPATH_FOOTER_DMCA = "//footer//a[contains(text(), 'DMCA REMOVAL')]";
        //Hamberger
        private const string XPATH_HAMBERGER_ABOUTUS = "//div[@class='section-second']//a[contains(text(), 'About Us')]";
        private const string XPATH_HAMBERGER_ADVERTISING = "//div[@class='section-second']//a[contains(text(), 'Advertising')]";
        private const string XPATH_HAMBERGER_PARTNERSHIP = "//div[@class='section-second']//a[contains(text(), 'Partnerships')]";
        private const string XPATH_HAMBERGER_PRESS = "//div[@class='section-second']//a[contains(text(), 'Press')]";
        private const string XPATH_HAMBERGER_CAREER = "//div[@class='section-second']//a[contains(text(), 'Careers')]";
        private const string XPATH_HAMBERGER_CONTACTUS = "//div[@class='section-second']//a[contains(text(), 'Contact Us')]";
        private const string XPATH_HAMBERGER_PRIVACY = "//div[@class='section-third']//a[contains(text(), 'Privacy ')]";
        private const string XPATH_HAMBERGER_TERMS = "//div[@class='section-third']//a[contains(text(), 'Terms ')]";
        private const string XPATH_HAMBERGER_DMCA = "//div[@class='section-third']//a[contains(text(), 'DMCA Removal ')]";

        //Article page
        private const string XPATH_CATAGORY_BADGE = "//div//h1";
        private const string CSS_ARTICLE_WRAPPER = ".articles_wrapper";
        private const string CSS_ARTICLE_LIST = ".articles_wrapper>article";
        private const string CSS_LOAD_MORE_BUTTON = ".load-more-btn";
        private const string XPATH_SHOW_HEADER_IMAGE = "//div[@class='header live-hub landscape']//img";
        private const string XPATH_ARTICLE_LINK = "//div[@class='articles_wrapper']//a";
        private const string XPATH_ARTICLE_POST_TITLE = "//div[@class='single-post-wrapper']//h1[@class='post-title']";
        private const string XPATH_MAIN_POST_IMAGE = "//div[@class='center main-post-image-holder']//div";
        private const string CSS_AUTHOR_WRAP = ".author-wrap";
        private const string CSS_MAIN_CONTENT_BODY = ".mainContentIntro.content-wrapper";
        private const string CSS_FB_SHARE_BUTTON = ".share-item.fb";
        private const string XPATH_POST_IMAGE_ARTICLE = "//div[@class='post-media ']//img";
        private const string CSS_PAGINATION_BAR = ".pagination";
        private const string CSS_PAGINATION_NEXT_BUTTON = ".page-navigation.page-next";
        private const string CSS_PAGINATION_PREV_BUTTON = ".page-navigation.page-prev";
        private const string CSS_SLIDESHOW_GALLERY_NEXT_BUTTON = ".buttonlink.right-gallery";
        private const string CSS_SLIDESHOW_GALLERY_PREV_BUTTON = ".buttonlink.left-gallery";
        private const string XPATH_SLIDESHOW_NEXT_IMAGE = "//div[@id='next-image']//img";
        private const string CSS_SPONSOR_AUTHOR = ".sponsored";
        private const string CSS_OUR_PROGRAMS = ".inner-list-new";
        private const string XPATH_VIDEO_BLOCK = "//div[@class='inner-list-new']//article//a[@class='video-figure lt-lazy-load-image b-loaded']";
        private const string XPATH_QUICK_SELECTED_BUTTON = "//div[@class='activator']/span/i";
        private const string CSS_QUICK_SELECTED_BAR = ".serial";
        private const string XPATH_QUICK_SELECTED_FIRST_MENU = "(//ul[@class='serial']/li/a)[1]";
        private const string XPATH_SUB_SHOW_MAIN_IMAGE = "//div[@class='header live-hub-channel landscape']//img";
        private const string XPATH_SUB_SHOW_HEADER = "//div[@class='promo-content']/h1";
        private const string CSS_SUB_SHOW_VIDEO_LIST = ".video-static-list";
        private const string XPATH_SUB_VIDEO_LIST_IMAGE = "//div[@class='video-static-list']/article/a";
        private const string CSS_VIDEO_PALYER_CLOSE_BUTTON = ".mfp-close";
        private const string XPATH_BACK_TO_SHOW_BUTTON = "//span//a[@href ='/live']";
        private const string XPATH_FACEBOOK_SHARE_ARTICLE = "//*[contains(@value,'";

        //Facebook
        private const string CSS_FB_USERNAME_BOX = "#email";
        private const string CSS_FB_PASSWORD_BOX = "#pass";
        private const string CSS_FB_LOGIN_BUTTON = "[name='login']";
        private const string XPATH_FB_POST_BUTTON = "//span[contains(text(), 'Post to Facebook')]";
        //Facebook Mobile
        private const string CSS_FB_USERNAME_BOX_MOBILE = "#m_login_email";
        private const string CSS_FB_PASSWORD_BOX_MOBILE = "#m_login_password";
        private const string CSS_FB_LOGIN_BUTTON_MOBILE = "[name='login']";
        private const string XPATH_FB_POST_BUTTON_MOBILE = "//button[contains(text(), 'Post')]";


        //Mobie version
        private const string XPATH_HERO_IMAGE_MOBILE = "//figure[@class='lt-lazy-load-image bg 1 b-loaded']";
        private const string CSS_HAMBERGER_MENU_MOBILE = ".hamburg-activation";
        private const string CSS_HAMBERGER_NEV_BAR_MOBILE = ".hamburg-dd";
        private const string XPATH_DIY_CAT_MOBILE = "//a[@title='DIY']";
        private const string XPATH_FOOD_CAT_MOBILE = "//a[@title='Food']";
        private const string XPATH_PARENTING_CAT_MOBILE = "//a[@title='Parenting']";
        private const string XPATH_PETS_CAT_MOBILE = "//a[@title='PETS']";
        private const string XPATH_SHOWS_CAT_MOBILE = "//a[@title='SHOWS']";
        private const string XPATH_GAMES_CAT_MOBILE = "//a[@title='games']";
        private const string XPATH_HOME_CAT_MOBILE = "//a[@title='Home']";
        private const string XPATH_LOAD_MORE_MOBILE = "//div[@class='click_to_load']/a";
        private const string CSS_ARTICLE_LISTS_MOBILE = ".articles-list.cat-search>article";
        private const string XPATH_LIVE_BROAD_CAST_MOBILE = "//div[@class='header live-hub']//img";
        private const string CSS_GAME_POPUP_MOBILE = ".wg-inner-wrap";
        private const string CSS_GAME_POPUP_CLOSE_BUTTON_MOBILE = ".wg-close-wrap.close";
        private const string XPATH_PROMO_POST_MOBILE = "//section[@class='promo-posts']/div";
        private const string XPATH_TOP_RECIEPT_SLIDE_MOBILE = "//div[@class='recipe-slide']/a/figure";
        private const string XPATH_NEXT_SLIDE_MOBIE = "//section[@class='recipes-slider-wrapper']//a[@data-slide-index='1']";
        private const string XPATH_PREV_SLIDE_MOBIE = "//section[@class='recipes-slider-wrapper']//a[@data-slide-index='0']";
        private const string XPATH_MAIN_POST_IMAGE_MOBILE = "//div[@class='center main-post-img']";
        private const string XPATH_FOOD_CATAGORY_ITEM_MOBILE = "//section[@class='food-cat']/div";
        private const string CSS_VIDEO_LIST_MOBILE = ".featured-videos>.bx-wrapper";
        private const string XPATH_NEXT_VIDEO_MOBILE = "//section[@class='featured-videos']//a[@data-slide-index='1']";
        private const string XPATH_VIDEO_LIST_PLAY_BUTTON = "(//div[@class='video-article']/a[@class='play-btn'])[2]";
        private const string XPATH_FOOTER_LINK_MOBILE = "//footer[@class='site-footer']//div[@class='footer-link-list']//a";
        private const string XPATH_SUB_FOOTER_LINK_MOBILE = "//footer[@class='site-footer']//div[@class='sub-footer-nav']//a";
        private const string CSS_SEARCH_BUTTON_MOBILE = ".site-search";
        private const string CSS_SEARCH_BAR_MOBILE = ".search-input";
        private const string CSS_SEARCH_ARTICLE_LIST_MOBILE = ".articles-list.cat-search";
        private const string XPATH_ARTICLE_LIST_MOBILE = "//div[@class='articles-list cat-search']/article/a";
        private const string XPATH_ARTICLE_POST_TITLE_MOBILE = "//div[@class='post-content']//h1[@class='post-title']";
        private const string XPATH_NULL_SEARCH_MOBILE = "//h2[contains(text(), 'Sorry')]";
        private const string XPATH_HEALTHY_MENU_MOBILE = "(//section[@class='food-cat']//div)[1]";
        private const string XPATH_SWEET_MENU_MOBILE = "(//section[@class='food-cat']//div)[2]";
        private const string XPATH_SAVORY_MENU_MOBILE = "(//section[@class='food-cat']//div)[3]";
        private const string XPATH_POST_IMAGE_ARTICLE_MOBILE = "//div[@class='galleryWrapper ']//img";
        private const string XPATH_FIRST_SLIDE_IMAGE = "//div[@class='galleryWrapperRelative']//img";
        private const string CSS_SPONSOR_AUTHOR_MOBILE = ".sponsored-by";
        private const string CSS_OUR_PROGRAMS_MOBILE = ".featured-channels";
        private const string XPATH_VIDEO_BLOCK_MOBILE = "//article[@class='video-block']";
        private const string XPATH_SUB_SHOW_MAIN_IMAGE_MOBILE = "//div[@class='header live-hub-channel']//img";
        private const string XPATH_SUB_SHOW_HEADER_MOBILE = "//div[@class='serie-header-mobile-description']/h2";
        private const string XPATH_SUB_VIDEO_LIST_IMAGE_MOBILE = "(//article[@class='video-block']/h3/a)[1]";

        //Company Links Mobile
        //Footer
        private const string XPATH_FOOTER_ABOUTUS_MOBILE = "//footer//a//span[contains(text(), 'About Us')]";
        private const string XPATH_FOOTER_ADVERTISING_MOBILE = "//footer//a//span[contains(text(), 'Advertising')]";
        private const string XPATH_FOOTER_PARTNERSHIP_MOBILE = "//footer//a//span[contains(text(), 'Partnerships')]";
        private const string XPATH_FOOTER_PRESS_MOBILE = "//footer//a//span[contains(text(), 'Press')]";
        private const string XPATH_FOOTER_CAREER_MOBILE = "//footer//a//span[contains(text(), 'Careers')]";
        private const string XPATH_FOOTER_CONTACTUS_MOBILE = "//footer//a//span[contains(text(), 'Contact Us')]";
        private const string XPATH_FOOTER_PRIVACY_MOBILE = "//footer//a//span[contains(text(), 'Privacy')]";
        private const string XPATH_FOOTER_TERMS_MOBILE = "//footer//a//span[contains(text(), 'Terms')]";
        private const string XPATH_FOOTER_DMCA_MOBILE = "//footer//a//span[contains(text(), 'DMCA Removal')]";
        //Hamberger
        private const string XPATH_HAMBERGER_ABOUTUS_MOBILE = "//ul[@class='footer-menu']//a//span[contains(text(), 'About Us')]";
        private const string XPATH_HAMBERGER_ADVERTISING_MOBILE = "//ul[@class='footer-menu']//a//span[contains(text(), 'Advertising')]";
        private const string XPATH_HAMBERGER_PARTNERSHIP_MOBILE = "//ul[@class='footer-menu']//a//span[contains(text(), 'Partnerships')]";
        private const string XPATH_HAMBERGER_PRESS_MOBILE = "//ul[@class='footer-menu']//a//span[contains(text(), 'Press')]";
        private const string XPATH_HAMBERGER_CAREER_MOBILE = "//ul[@class='footer-menu']//a//span[contains(text(), 'Careers')]";
        private const string XPATH_HAMBERGER_CONTACTUS_MOBILE = "//ul[@class='footer-menu']//a//span[contains(text(), 'Contact Us')]";
        private const string XPATH_HAMBERGER_PRIVACY_MOBILE = "//ul[@class='footer-menu']//a//span[contains(text(), 'Privacy')]";
        private const string XPATH_HAMBERGER_TERMS_MOBILE = "//ul[@class='footer-menu']//a//span[contains(text(), 'Terms')]";
        private const string XPATH_HAMBERGER_DMCA_MOBILE = "//ul[@class='footer-menu']//a//span[contains(text(), 'DMCA Removal')]";

        // CSS Page objects
        //Mobile
        [FindsBy(How = How.XPath, Using = XPATH_HEALTHY_MENU_MOBILE)]
        private IWebElement HealtyMenuButtonMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_SWEET_MENU_MOBILE)]
        private IWebElement SweetMenuButtonMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_SAVORY_MENU_MOBILE)]
        private IWebElement SavoryMenuButtonMobile = null;

        [FindsBy(How = How.CssSelector, Using = CSS_SEARCH_BUTTON_MOBILE)]
        private IWebElement SearchButtonMobile = null;

        [FindsBy(How = How.CssSelector, Using = CSS_SEARCH_BAR_MOBILE)]
        private IWebElement SearchBarMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_NEXT_VIDEO_MOBILE)]
        private IWebElement NextVideoMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_VIDEO_LIST_PLAY_BUTTON)]
        private IWebElement VideoListPlayButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_HAMBERGER_MENU_MOBILE)]
        private IWebElement HambergerMenuMobile = null;

        [FindsBy(How = How.CssSelector, Using = XPATH_NEXT_SLIDE_MOBIE)]
        private IWebElement NextSlideImageMobile = null;

        [FindsBy(How = How.CssSelector, Using = XPATH_PREV_SLIDE_MOBIE)]
        private IWebElement PrevSlideImageMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_FOOD_CAT_MOBILE)]
        private IWebElement FoodCatButtonMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_PETS_CAT_MOBILE)]
        private IWebElement PetsCatButtonMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_DIY_CAT_MOBILE)]
        private IWebElement DiyCatButtonMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_SHOWS_CAT_MOBILE)]
        private IWebElement LiveCatButtonMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_GAMES_CAT_MOBILE)]
        private IWebElement GameCatButtonMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_HOME_CAT_MOBILE)]
        private IWebElement HomeCatButtonMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_PARENTING_CAT_MOBILE)]
        private IWebElement ParentingCatButtonMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_LOAD_MORE_MOBILE)]
        private IWebElement LoadmoreMobile = null;

        [FindsBy(How = How.CssSelector, Using = CSS_ARTICLE_LISTS_MOBILE)]
        private IList<IWebElement> ArticleListsMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_TOP_RECIEPT_SLIDE_MOBILE)]
        private IWebElement TopRecieptMobile = null;

        [FindsBy(How = How.CssSelector, Using = CSS_GAME_POPUP_CLOSE_BUTTON_MOBILE)]
        private IWebElement GameCloseButtonMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_PROMO_POST_MOBILE)]
        private IList<IWebElement> PromoPostMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_FOOD_CATAGORY_ITEM_MOBILE)]
        private IList<IWebElement> FoodCatagoryItemMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_FOOTER_LINK_MOBILE)]
        private IList<IWebElement> FooterLinkItemMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_SUB_FOOTER_LINK_MOBILE)]
        private IList<IWebElement> SubFooterLinkItemMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_ARTICLE_LIST_MOBILE)]
        private IList<IWebElement> ArticleListMobile = null;

        [FindsBy(How = How.CssSelector, Using = CSS_OUR_PROGRAMS_MOBILE)]
        private IWebElement OurProgramListmobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_VIDEO_BLOCK_MOBILE)]
        private IList<IWebElement> VideoBlockMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_SUB_VIDEO_LIST_IMAGE_MOBILE)]
        private IWebElement SubVideoListMobile = null;

        [FindsBy(How = How.CssSelector, Using = CSS_FB_USERNAME_BOX_MOBILE)]
        private IWebElement FacebookUsernameBoxMobile = null;

        [FindsBy(How = How.CssSelector, Using = CSS_FB_PASSWORD_BOX_MOBILE)]
        private IWebElement FacebookPasswordBoxMobile = null;

        [FindsBy(How = How.CssSelector, Using = CSS_FB_LOGIN_BUTTON_MOBILE)]
        private IWebElement FacebookLoginButtonMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_FOOTER_ABOUTUS_MOBILE)]
        private IWebElement AboutUsFooterMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_FOOTER_ADVERTISING_MOBILE)]
        private IWebElement AdvertisingFooterMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_FOOTER_PARTNERSHIP_MOBILE)]
        private IWebElement PartherFooterMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_FOOTER_PRESS_MOBILE)]
        private IWebElement PressFooterMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_FOOTER_CAREER_MOBILE)]
        private IWebElement CareerFooterMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_FOOTER_CONTACTUS_MOBILE)]
        private IWebElement ContactUsFooterMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_FOOTER_PRIVACY_MOBILE)]
        private IWebElement PrivancyFooterMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_FOOTER_TERMS_MOBILE)]
        private IWebElement TermsFooterMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_FOOTER_DMCA_MOBILE)]
        private IWebElement DmcaFooterMobile = null;

        //
        [FindsBy(How = How.XPath, Using = XPATH_HAMBERGER_ABOUTUS_MOBILE)]
        private IWebElement AboutUsHambergerMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_HAMBERGER_ADVERTISING_MOBILE)]
        private IWebElement AdvertisingHambergerMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_HAMBERGER_PARTNERSHIP_MOBILE)]
        private IWebElement PartherHambergerMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_HAMBERGER_PRESS_MOBILE)]
        private IWebElement PressHambergerMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_HAMBERGER_CAREER_MOBILE)]
        private IWebElement CareerHambergerMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_HAMBERGER_CONTACTUS_MOBILE)]
        private IWebElement ContactUsHambergerMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_HAMBERGER_PRIVACY_MOBILE)]
        private IWebElement PrivancyHambergerMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_HAMBERGER_TERMS_MOBILE)]
        private IWebElement TermsHambergerMobile = null;

        [FindsBy(How = How.XPath, Using = XPATH_HAMBERGER_DMCA_MOBILE)]
        private IWebElement DmcaHambergerMobile = null;

        //Desktop
        [FindsBy(How = How.CssSelector, Using = CSS_OUR_PROGRAMS)]
        private IWebElement OurProgramList = null;

        [FindsBy(How = How.CssSelector, Using = CSS_SLIDESHOW_GALLERY_NEXT_BUTTON)]
        private IWebElement SlideShowNextButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_SLIDESHOW_GALLERY_PREV_BUTTON)]
        private IWebElement SlideShowPrevButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_PAGINATION_NEXT_BUTTON)]
        private IWebElement PaginationNextButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_PAGINATION_PREV_BUTTON)]
        private IWebElement PaginationPrevButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_SHOWS_MENU)]
        private IWebElement ShowsMenuButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_FOOD_MENU)]
        private IWebElement FoodMenuButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_PARENTING_MENU)]
        private IWebElement ParentingMenuButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_PETS_MENU)]
        private IWebElement PetsMenuButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_DIY_MENU)]
        private IWebElement DiyMenuButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_PLAY_VIDEO_BUTTON)]
        private IWebElement PlayVideoButton= null;

        [FindsBy(How = How.CssSelector, Using = CSS_RECENT_STORY)]
        private IWebElement RecentStorySection = null;

        [FindsBy(How = How.CssSelector, Using = CSS_IMAGE_SLIDE_NEXT_BUTTON)]
        private IWebElement NextSlideShowButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_IMAGE_SLIDE_PREV_BUTTON)]
        private IWebElement PrevSlideShowButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_FEATURE_VIDEO)]
        private IWebElement FeatureVideoMain = null;

        [FindsBy(How = How.CssSelector, Using = CSS_SHOW_MORE_BUTTON)]
        private IWebElement ShowMoreButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_SEARCH_BUTTON)]
        private IWebElement SearchButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_SEARCH_BAR)]
        private IWebElement SearchBar = null;

        [FindsBy(How = How.CssSelector, Using = CSS_FOOD_CATAGORY)]
        private IWebElement FoodCatButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_MORE_SOCIAL)]
        private IWebElement MoreSocialButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_PARENTING_CATAGORY)]
        private IWebElement ParentCatButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_PETS_CATAGORY)]
        private IWebElement PetsCatButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_DIY_CATAGORY)]
        private IWebElement DiyCatButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_LIVE_CATAGORY)]
        private IWebElement LiveCatButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_GAME_CATAGORY)]
        private IWebElement GameCatButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_LOAD_MORE_BUTTON)]
        private IWebElement LoadMoreButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_GAME_POPUP_CLOSE_BUTTON)]
        private IWebElement GameCloseButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_ARTICLE_LIST)]
        private IList<IWebElement> ArticleList = null;

        [FindsBy(How = How.CssSelector, Using = CSS_PAUSE_VIDEO_BUTTON)]
        private IList<IWebElement> PauseVideoButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_LOADING_VIDEO_BUTTON)]
        private IList<IWebElement> LoadingVideoButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_FB_SHARE_BUTTON)]
        private IList<IWebElement> FacebookShareButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_FB_USERNAME_BOX)]
        private IWebElement FacebookUsernameBox = null;

        [FindsBy(How = How.CssSelector, Using = CSS_FB_PASSWORD_BOX)]
        private IWebElement FacebookPasswordBox = null;

        [FindsBy(How = How.CssSelector, Using = CSS_FB_LOGIN_BUTTON)]
        private IWebElement FacebookLoginButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_SOCIAL_FACEBOOK)]
        private IWebElement SocialFacebookIcon = null;

        [FindsBy(How = How.CssSelector, Using = CSS_SOCIAL_PINTEREST)]
        private IWebElement SocialPinterestIcon = null;

        [FindsBy(How = How.CssSelector, Using = CSS_SOCIAL_TWITTER)]
        private IWebElement SocialTwitterIcon = null;

        [FindsBy(How = How.CssSelector, Using = CSS_SOCIAL_EMAIL)]
        private IWebElement SocialEmailIcon = null;

        [FindsBy(How = How.CssSelector, Using = CSS_EMAIL_INPUT)]
        private IWebElement SocialEmailInput = null;

        [FindsBy(How = How.XPath, Using = XPATH_SIGN_UP_BUTTON)]
        private IWebElement SocialEmailSignupButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_CLOSE_SUB_BUTTON)]
        private IWebElement SocialCloseSubButton = null;

        [FindsBy(How = How.CssSelector, Using = CSS_DISSMISS_BUTTON)]
        private IWebElement SocialEmailDismissButton = null;

        // Xpath Page objects
        [FindsBy(How = How.CssSelector, Using = CSS_VIDEO_PALYER_CLOSE_BUTTON)]
        private IWebElement VideoPlayerClosebutton = null;

        [FindsBy(How = How.XPath, Using = XPATH_QUICK_SELECTED_FIRST_MENU)]
        private IWebElement QuickSelectedFirst = null;

        [FindsBy(How = How.XPath, Using = XPATH_SEE_MORE_ON_SLIDE)]
        private IWebElement SeeMoreLink = null;

        [FindsBy(How = How.XPath, Using = XPATH_LT_LOGO)]
        private IWebElement LTLogo = null;

        [FindsBy(How = How.XPath, Using = XPATH_HEALTHY_MENU)]
        private IWebElement HealthyMenuButton = null;

        [FindsBy(How = How.XPath, Using = XPATH_SWEET_MENU)]
        private IWebElement SweetMenuButton = null;

        [FindsBy(How = How.XPath, Using = XPATH_SAVORY_MENU)]
        private IWebElement SavoryMenuButton = null;

        [FindsBy(How = How.XPath, Using = XPATH_LIVE_BROAD_CAST)]
        private IWebElement BroadcastImage = null;

        [FindsBy(How = How.XPath, Using = XPATH_CATAGORY_BADGE)]
        private IWebElement BageCatagory = null;

        [FindsBy(How = How.XPath, Using = XPATH_TOP_RECIPES)]
        private IWebElement TopRecipes = null;

        [FindsBy(How = How.XPath, Using = XPATH_NAV_BAR_MENU_ITEM)]
        private IList<IWebElement> NavBarItem = null;

        [FindsBy(How = How.XPath, Using = XPATH_PROMO_POST)]
        private IList<IWebElement> PromoPost = null;

        [FindsBy(How = How.XPath, Using = XPATH_FOOD_CATAGORY_ITEM)]
        private IList<IWebElement> FoodCatagory = null;

        [FindsBy(How = How.XPath, Using = XAPTH_DOUBLE_TOP_STORY)]
        private IList<IWebElement> DoubleTopStory = null;

        [FindsBy(How = How.XPath, Using = XPATH_SINGLE_TOP_STORY)]
        private IList<IWebElement> SingleTopStory = null;

        [FindsBy(How = How.XPath, Using = XPATH_LASTEST_POST_WARP)]
        private IList<IWebElement> LastestPostWarp = null;

        [FindsBy(How = How.XPath, Using = XPATH_FOOTER_LINK)]
        private IList<IWebElement> FooterLinkItem = null;

        [FindsBy(How = How.XPath, Using = XPATH_SUB_FOOTER_LINK)]
        private IList<IWebElement> SubFooterLinkItem = null;

        [FindsBy(How = How.XPath, Using = XPATH_ARTICLE_LINK)]
        private IList<IWebElement> ArticleLinks = null;

        [FindsBy(How = How.XPath, Using = XPATH_VIDEO_BLOCK)]
        private IList<IWebElement> VideoBlock = null;

        [FindsBy(How = How.XPath, Using = XPATH_SUB_VIDEO_LIST_IMAGE)]
        private IList<IWebElement> SubVideoList = null;

        [FindsBy(How = How.XPath, Using = XPATH_FOOTER_ABOUTUS)]
        private IWebElement AboutUsFooter = null;

        [FindsBy(How = How.XPath, Using = XPATH_FOOTER_ADVERTISING)]
        private IWebElement AdvertisingFooter = null;

        [FindsBy(How = How.XPath, Using = XPATH_FOOTER_PARTNERSHIP)]
        private IWebElement PartherFooter = null;

        [FindsBy(How = How.XPath, Using = XPATH_FOOTER_PRESS)]
        private IWebElement PressFooter = null;

        [FindsBy(How = How.XPath, Using = XPATH_FOOTER_CAREER)]
        private IWebElement CareerFooter = null;

        [FindsBy(How = How.XPath, Using = XPATH_FOOTER_CONTACTUS)]
        private IWebElement ContactUsFooter = null;

        [FindsBy(How = How.XPath, Using = XPATH_FOOTER_PRIVACY)]
        private IWebElement PrivancyFooter = null;

        [FindsBy(How = How.XPath, Using = XPATH_FOOTER_TERMS)]
        private IWebElement TermsFooter = null;

        [FindsBy(How = How.XPath, Using = XPATH_FOOTER_DMCA)]
        private IWebElement DmcaFooter = null;

        //
        [FindsBy(How = How.XPath, Using = XPATH_HAMBERGER_ABOUTUS)]
        private IWebElement AboutUsHamberger = null;

        [FindsBy(How = How.XPath, Using = XPATH_HAMBERGER_ADVERTISING)]
        private IWebElement AdvertisingHamberger = null;

        [FindsBy(How = How.XPath, Using = XPATH_HAMBERGER_PARTNERSHIP)]
        private IWebElement PartherHamberger = null;

        [FindsBy(How = How.XPath, Using = XPATH_HAMBERGER_PRESS)]
        private IWebElement PressHamberger = null;

        [FindsBy(How = How.XPath, Using = XPATH_HAMBERGER_CAREER)]
        private IWebElement CareerHamberger = null;

        [FindsBy(How = How.XPath, Using = XPATH_HAMBERGER_CONTACTUS)]
        private IWebElement ContactUsHamberger = null;

        [FindsBy(How = How.XPath, Using = XPATH_HAMBERGER_PRIVACY)]
        private IWebElement PrivancyHamberger = null;

        [FindsBy(How = How.XPath, Using = XPATH_HAMBERGER_TERMS)]
        private IWebElement TermsHamberger = null;

        [FindsBy(How = How.XPath, Using = XPATH_HAMBERGER_DMCA)]
        private IWebElement DmcaHamberger = null;

        #endregion 

        public IWebDriver Driver { get; set; }

        public LTPageBase(IWebDriver driver)
        {
            Driver = driver;
            Driver.InitialPageObject(this);
        }

        public bool IsHeroImageDisplay()
        {
            try
            {
                return Utility.Utility.CheckImageDisplay(Driver, XPATH_HERO_IMAGE);
            }
            catch { return false; }
        }

        public bool IsHeroImageDisplayMobile()
        {
            try
            {
                return Utility.Utility.CheckCSSImageDisplay(Driver, XPATH_HERO_IMAGE_MOBILE);
            }
            catch { return false; }
        }

        public bool CheckNumberOfDoubleTopStoryFirstLoad()
        {
            try
            {
                if (DoubleTopStory.Count == 4)
                {
                    return Utility.Utility.CheckImageDisplay(Driver, XAPTH_DOUBLE_TOP_STORY+"//img");
                }
                else { return false; }
            }
            catch { return false; }
        }

        public bool CheckNumberOfSingleTopStoryFirstLoad()
        {
            try
            {
                if (SingleTopStory.Count == 1)
                {
                    return Utility.Utility.CheckImageDisplay(Driver, XPATH_SINGLE_TOP_STORY + "//img");
                }
                else { return false; }
            }
            catch { return false; }
        }

        public bool CheckNumberOfTopStoryFirstLoadMobile()
        {
            try
            {
                if (SingleTopStory.Count == 5)
                {
                    return Utility.Utility.CheckImageDisplay(Driver, XPATH_SINGLE_TOP_STORY + "//img");
                }
                else { return false; }
            }
            catch { return false; }
        }

        public bool CheckFooterSection()
        {
            Utility.Utility.JsScrollToElement(Driver, FooterLinkItem[1]);

            if (CheckNumberOfFooterLinkItem() && CheckNumberOfSubFooterLinkItem())
            {
                return true;
            }
            else { return false; }
        }

        public bool CheckFooterSectionMobile()
        {
            Utility.Utility.JsScrollToElement(Driver, FooterLinkItemMobile[1]);

            if (CheckNumberOfFooterLinkItemMobile() && CheckNumberOfSubFooterLinkItemMobile())
            {
                return true;
            }
            else { return false; }
        }

        public bool CheckNumberOfFooterLinkItem()
        {
            try
            {
                if (FooterLinkItem.Count == 7)
                {
                    return true;
                }
                else { return false; }
            }
            catch { return false; }
        }

        public bool CheckNumberOfFooterLinkItemMobile()
        {
            try
            {
                if (FooterLinkItemMobile.Count == 9)
                {
                    return true;
                }
                else { return false; }
            }
            catch { return false; }
        }

        public bool CheckNumberOfSubFooterLinkItem()
        {
            try
            {
                if (SubFooterLinkItem.Count == 9)
                {
                    return true;
                }
                else { return false; }
            }
            catch { return false; }
        }

        public bool CheckNumberOfSubFooterLinkItemMobile()
        {
            try
            {
                if (SubFooterLinkItemMobile.Count == 9)
                {
                    return true;
                }
                else { return false; }
            }
            catch { return false; }
        }

        public bool CheckNumberOfLastestPostWarpAfterViewMore()
        {
            try
            {
                Utility.Utility.JsScrollToElement(Driver, LastestPostWarp[2]);
                Thread.Sleep(3000);
                if (LastestPostWarp.Count == 4)
                {
                    return Utility.Utility.CheckImageDisplay(Driver, XPATH_LASTEST_POST_WARP + "//img");
                }
                else { return false; }
            }
            catch { return false; }
        }

        public bool CheckNumberOfLastestPostWarpAfterViewMoreMobile()
        {
            try
            {
                if (SingleTopStory.Count == 20)
                {
                    Thread.Sleep(2000);
                    return Utility.Utility.CheckImageDisplay(Driver, XPATH_SINGLE_TOP_STORY + "//img");
                }
                else { return false; }
            }
            catch { return false; }
        }

        public bool IsPromoPostImageDisplay()
        {
            try
            {
                Utility.Utility.JsScrollToElement(Driver, PromoPost[1]);

                if (PromoPost.Count == 3)
                {
                    return Utility.Utility.CheckImageDisplay(Driver, XPATH_PROMO_POST+ "//img");
                }
                else { return false; }
            }
            catch { return false; }
        }

        public bool IsPromoPostImageDisplayMobile()
        {
            try
            {
                Utility.Utility.JsScrollToElement(Driver, PromoPostMobile[2]);

                if (PromoPostMobile.Count == 4)
                {
                    return Utility.Utility.CheckImageDisplay(Driver, XPATH_PROMO_POST_MOBILE + "//img");
                }
                else { return false; }
            }
            catch { return false; }
        }

        public bool IsLiveBrodcastImageDisplay()
        {
            try
            {
                Utility.Utility.JsScrollToElement(Driver, BroadcastImage);

                return Utility.Utility.CheckImageDisplay(Driver, XPATH_LIVE_BROAD_CAST);
            }
            catch { return false; }
        }

        public bool IsFoodCatagoryImageDisplay()
        {
            try
            {
                Utility.Utility.JsScrollToElement(Driver, FoodCatagory[1]);

                if (FoodCatagory.Count == 3)
                {
                    return Utility.Utility.CheckCSSImageDisplay(Driver, XPATH_FOOD_CATAGORY_ITEM);
                }
                else { return false; }
            }
            catch { return false; }
        }
        public bool IsFoodCatagoryImageDisplayMobile()
        {
            try
            {
                Utility.Utility.JsScrollToElement(Driver, FoodCatagoryItemMobile[1]);

                if (FoodCatagoryItemMobile.Count == 3)
                {
                    return Utility.Utility.CheckCSSImageDisplay(Driver, XPATH_FOOD_CATAGORY_ITEM_MOBILE);
                }
                else { return false; }
            }
            catch { return false; }
        }

        public bool IsTopRecipesImageSlideShowDisplay()
        {
            try
            {
                Thread.Sleep(3000);
                Utility.Utility.JsScrollToElement(Driver, TopRecipes);
                Driver.WaitUntil(d => Driver.FindElement(By.XPath(XPATH_TOP_RECIPES)).Displayed, Utility.Utility.MODERATE_COMPONENT_TIMEOUT);
                return Utility.Utility.CheckCSSImageDisplay(Driver, XPATH_TOP_RECIPES);
            }
            catch { return false; }
        }
        public bool IsTopRecipesImageSlideShowDisplayMobile()
        {
            try
            {
                Thread.Sleep(2000);
                Utility.Utility.JsScrollToElement(Driver, TopRecieptMobile);
                Driver.WaitUntil(d => Driver.FindElement(By.XPath(XPATH_TOP_RECIEPT_SLIDE_MOBILE)).Displayed, Utility.Utility.MODERATE_COMPONENT_TIMEOUT);
                return Utility.Utility.CheckCSSImageDisplay(Driver, XPATH_TOP_RECIEPT_SLIDE_MOBILE);
            }
            catch { return false; }
        }


        public bool IsLTLogoDisplay()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.XPath(XPATH_LT_LOGO)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public bool IsRecentStoryDisplayFirstLoad()
        {
            try
            {
                Utility.Utility.JsScrollToElement(Driver, RecentStorySection);
                Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_RECENT_STORY)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                
                //Check some image.
                Utility.Utility.CheckImageDisplay(Driver, XPATH_SINGLE_TOP_STORY + "//img");

                //Check number of item.
                CheckNumberOfSingleTopStoryFirstLoad();
                CheckNumberOfDoubleTopStoryFirstLoad();

                return true;
            }
            catch { return false; }
        }

        public bool IsRecentStoryDisplayFirstLoadMobile()
        {
            try
            {
                Utility.Utility.JsScrollToElement(Driver, RecentStorySection);
                Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_RECENT_STORY)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);

                //Check some image.
                Utility.Utility.CheckImageDisplay(Driver, XPATH_SINGLE_TOP_STORY + "//img");

                //Check number of item.
                CheckNumberOfTopStoryFirstLoadMobile();

                return true;
            }
            catch { return false; }
        }


        public bool IsRecentStoryDisplayAfterClickViewmore()
        {
            try
            {
                ClickViewMoreStoryButton();
                Thread.Sleep(3000);
                Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_RECENT_STORY)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);

                //Check some image.
                Utility.Utility.CheckImageDisplay(Driver, XAPTH_DOUBLE_TOP_STORY + "//img");

                //Check number of item.
                return CheckNumberOfLastestPostWarpAfterViewMore();
            }
            catch { return false; }
        }

        public bool IsRecentStoryDisplayAfterClickViewmoreMobile()
        {
            try
            {
                ClickViewMoreStoryButton();
                Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_RECENT_STORY)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);

                //Check some image.
                Utility.Utility.CheckImageDisplay(Driver, XPATH_SINGLE_TOP_STORY + "//img");

                //Check number of item.
                Thread.Sleep(2000);
                return CheckNumberOfLastestPostWarpAfterViewMoreMobile();
            }
            catch { return false; }
        }

        public void ClickPlayVideo()
        {
            try
            {
                PlayVideoButton.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickArticleLink(int index)
        {
            try
            {
                ArticleLinks[index].Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickArticleLinkMobile(int index)
        {
            try
            {
                ArticleListMobile[index].Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public bool CheckArticleMatchWithSearch(string input)
        {
            try
            {
                var element = Driver.FindElement(By.XPath(XPATH_ARTICLE_POST_TITLE));
                if (!string.IsNullOrEmpty(element.Text) && element.Text.Contains(input))
                {
                    return true;
                }
                else { return false; }
            }
            catch { return false; }
        }

        public bool CheckArticleMatchWithSearchMobile(string input)
        {
            try
            {
                var element = Driver.FindElement(By.XPath(XPATH_ARTICLE_POST_TITLE_MOBILE));
                if (!string.IsNullOrEmpty(element.Text) && element.Text.Contains(input))
                {
                    return true;
                }
                else { return false; }
            }
            catch { return false; }
        }

        public bool CheckArticleTitleDisplay()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.XPath(XPATH_ARTICLE_POST_TITLE)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public bool CheckArticleTitleDisplayMobile()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.XPath(XPATH_ARTICLE_POST_TITLE_MOBILE)).Displayed, Utility.Utility.SMALL_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public bool IsFeatureVideoDisplay()
        {
            try
            {
                Utility.Utility.JsScrollToElement(Driver, FeatureVideoMain);

                Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_FEATURE_VIDEO)).Displayed, Utility.Utility.SMALL_COMPONENT_TIMEOUT);
                ClickPlayVideo();
                Thread.Sleep(3000);

                //if video playing normally "pause" class will appear.
                if (PauseVideoButton.Count > 0)
                {
                    return true;
                }
                //wait video in case of slow internet until "pause" class will appear.
                else if (LoadingVideoButton.Count > 0)
                {
                    //Wait 15 secs
                    Thread.Sleep(15000);
                    if (PauseVideoButton.Count > 0)
                    {
                        return true;
                    }
                    else { return false; }
                }
                else { return false; }
            }
            catch { return false; }
        }

        public void ClickNextVideoListMobile()
        {
            try
            {
                NextVideoMobile.Click();
                Thread.Sleep(2000);
                VideoListPlayButton.Click();
                Driver.WaitAjax(Utility.Utility.SMALL_COMPONENT_TIMEOUT);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public bool IsVideoListDisplay()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_VIDEO_LIST)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public bool IsVideoListDisplayMobile()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_VIDEO_LIST_MOBILE)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public bool IsTitleWarpDisplay()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_TITLE_WARP)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public bool IsAllSocialMenuDisplay()
        {
            try
            {
                //Facebook, Pinterest, Twitter, Email
                Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_SOCIAL_FACEBOOK)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_SOCIAL_PINTEREST)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_SOCIAL_TWITTER)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_SOCIAL_EMAIL)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                return true;
            }
            catch { return false; }
        }

        public void DoSearch(string text)
        {
            try
            {
                SearchButton.Click();
                Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_SEARCH_BAR)).Displayed, Utility.Utility.SMALL_COMPONENT_TIMEOUT);
                SearchBar.Click();
                SearchBar.SendKeys(text);
                SearchBar.SendKeys(Keys.Enter);

            }
            catch(Exception e) { Console.WriteLine(e); }
        }
        public void DoSearchMobile(string text)
        {
            try
            {
                SearchButtonMobile.Click();
                Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_SEARCH_BAR_MOBILE)).Displayed, Utility.Utility.SMALL_COMPONENT_TIMEOUT);
                SearchBarMobile.Click();
                SearchBarMobile.SendKeys(text);
                SearchBarMobile.SendKeys(Keys.Enter);

            }
            catch (Exception e) { Console.WriteLine(e); }
        }


        public bool IsSearchResultPage()
        {
            try
            {
                Driver.WaitAjax(Utility.Utility.SMALL_COMPONENT_TIMEOUT);
                return Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_SEARCH_RESULT)).Displayed, Utility.Utility.MODERATE_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public bool IsNoContentFoundDisplay()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_NULL_SEARCH_RESULT)).Displayed, Utility.Utility.MODERATE_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public bool IsNoContentFoundDisplayMobile()
        {
            try
            {
                Driver.WaitAjax(Utility.Utility.SMALL_COMPONENT_TIMEOUT);
                return Driver.WaitUntil(d => Driver.FindElement(By.XPath(XPATH_NULL_SEARCH_MOBILE)).Displayed, Utility.Utility.MODERATE_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public void ClickMoreSocialButton()
        {
            try
            {
                MoreSocialButton.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickViewMoreStoryButton()
        {
            try
            {
                ShowMoreButton.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public bool CheckItemOnNavBar()
        {
            try
            {
                if (NavBarItem.Count == 5) { return true; }
                else { return false; }
            }
            catch { return false; }
        }

        public void HoverHambergerMenu()
        {
            var element = Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_HAMBERGER_MENU_BUTTON)), Utility.Utility.TINY_COMPONENT_TIMEOUT);

            Actions action = new Actions(Driver);
            action.MoveToElement(element).Perform();
        }

        public void ClickHambergerMenu()
        {
            try
            {
                HambergerMenuMobile.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public bool IsHambergerMenuNavBarDisplay()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_HAMBERGER_NEV_BAR)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public bool IsHambergerMenuNavBarMobileDisplay()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_HAMBERGER_NEV_BAR_MOBILE)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public void ClickNextSlideShow()
        {
            try
            {
                NextSlideShowButton.Click();
                Thread.Sleep(2000);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
        public void ClickNextSlideShowMobile()
        {
            try
            {
                NextSlideImageMobile.Click();
                Thread.Sleep(2000);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickPrevSlideShow()
        {
            try
            {
                PrevSlideShowButton.Click();
                Thread.Sleep(2000);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickPrevSlideShowMobile()
        {
            try
            {
                PrevSlideImageMobile.Click();
                Thread.Sleep(2000);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickFoodCatButton()
        {
            try
            {
                Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_FOOD_CATAGORY)).Displayed, Utility.Utility.SMALL_COMPONENT_TIMEOUT);
                Thread.Sleep(1000);
                FoodCatButton.Click();
            }
            catch(Exception e) { Console.WriteLine(e); }
        }

        public void ClickFoodCatButtonMobile()
        {
            try
            {
                Driver.WaitUntil(d => Driver.FindElement(By.XPath(XPATH_FOOD_CAT_MOBILE)).Displayed, Utility.Utility.SMALL_COMPONENT_TIMEOUT);
                Thread.Sleep(1000);
                FoodCatButtonMobile.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickParentCatButton()
        {
            try
            {
                Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_PARENTING_CATAGORY)).Displayed, Utility.Utility.SMALL_COMPONENT_TIMEOUT);
                Thread.Sleep(1000);
                ParentCatButton.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickParentCatButtonMobile()
        {
            try
            {
                Driver.WaitUntil(d => Driver.FindElement(By.XPath(XPATH_PARENTING_CAT_MOBILE)).Displayed, Utility.Utility.SMALL_COMPONENT_TIMEOUT);
                Thread.Sleep(1000);
                ParentingCatButtonMobile.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickPetsCatButton()
        {
            try
            {
                Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_PETS_CATAGORY)).Displayed, Utility.Utility.SMALL_COMPONENT_TIMEOUT);
                Thread.Sleep(1000);
                PetsCatButton.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickPetsCatButtonMobile()
        {
            try
            {
                Driver.WaitUntil(d => Driver.FindElement(By.XPath(XPATH_PETS_CAT_MOBILE)).Displayed, Utility.Utility.SMALL_COMPONENT_TIMEOUT);
                Thread.Sleep(1000);
                PetsCatButtonMobile.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickDiyCatButton()
        {
            try
            {
                Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_DIY_CATAGORY)).Displayed, Utility.Utility.SMALL_COMPONENT_TIMEOUT);
                Thread.Sleep(1000);
                DiyCatButton.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
        public void ClickDiyCatButtonMobile()
        {
            try
            {
                Driver.WaitUntil(d => Driver.FindElement(By.XPath(XPATH_DIY_CAT_MOBILE)).Displayed, Utility.Utility.SMALL_COMPONENT_TIMEOUT);
                Thread.Sleep(1000);
                DiyCatButtonMobile.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }


        public void ClickLiveCatButton()
        {
            try
            {
                Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_LIVE_CATAGORY)).Displayed, Utility.Utility.SMALL_COMPONENT_TIMEOUT);
                Thread.Sleep(1000);
                LiveCatButton.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickLiveCatButtonMobile()
        {
            try
            {
                Driver.WaitUntil(d => Driver.FindElement(By.XPath(XPATH_SHOWS_CAT_MOBILE)).Displayed, Utility.Utility.SMALL_COMPONENT_TIMEOUT);
                Thread.Sleep(1000);
                LiveCatButtonMobile.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public bool IsHeaderImageOnShowsPageDisplay()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.XPath(XPATH_SHOW_HEADER_IMAGE)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }
        public bool IsHeaderImageOnShowsPageDisplayMobile()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.XPath(XPATH_LIVE_BROAD_CAST_MOBILE)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public bool IsArticleImageOnArticleWarpperDisplay()
        {
            try
            {
                return Utility.Utility.CheckCSSImageDisplay(Driver, XPATH_ARTICLE_LIST_IMAGE);
            }
            catch { return false; }
        }
        public bool IsArticleImageOnArticleListDisplayMobile()
        {
            try
            {
                return Utility.Utility.CheckCSSImageDisplay(Driver, XPATH_ARTICLE_LIST_MOBILE);
            }
            catch { return false; }
        }

        public void ClickGameCatButton()
        {
            try
            {
                Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_GAME_CATAGORY)).Displayed, Utility.Utility.SMALL_COMPONENT_TIMEOUT);
                Thread.Sleep(1000);
                GameCatButton.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickGameCatButtonMobile()
        {
            try
            {
                Driver.WaitUntil(d => Driver.FindElement(By.XPath(XPATH_GAMES_CAT_MOBILE)).Displayed, Utility.Utility.SMALL_COMPONENT_TIMEOUT);
                Thread.Sleep(1000);
                GameCatButtonMobile.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickGameHomeButtonMobile()
        {
            try
            {
                Driver.WaitUntil(d => Driver.FindElement(By.XPath(XPATH_HOME_CAT_MOBILE)).Displayed, Utility.Utility.SMALL_COMPONENT_TIMEOUT);
                Thread.Sleep(1000);
                HomeCatButtonMobile.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public bool IsCatagoryBadgeDisplay()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.XPath(XPATH_CATAGORY_BADGE)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public bool IsCatagoryBadgeDisplayCorrectly(string cat)
        {
            IsCatagoryBadgeDisplay();
            try
            {
                if (BageCatagory.Text.Contains(cat)) { return true; }
                else { return false; }
            }
            catch { return false; }
        }

        public bool IsArticleWrapperDisplay()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_ARTICLE_WRAPPER)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public bool IsSearchArticleListDisplayMobile()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_SEARCH_ARTICLE_LIST_MOBILE)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public bool CheckNumberOfArticleFirstLoadDesktop()
        {
            try
            {
                Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_ARTICLE_LIST)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);

                if (ArticleList.Count == 10) { return true; }
                else { return false; }
            }
            catch { return false; }
        }

        public bool CheckNumberOfArticleFirstLoadMobile()
        {
            try
            {
                Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_ARTICLE_LISTS_MOBILE)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);

                if (ArticleListsMobile.Count == 14) { return true; }
                else { return false; }
            }
            catch { return false; }
        }

        public void ClickLoadmorebutton()
        {
            Driver.JsScrollToElement(LoadMoreButton);
            LoadMoreButton.Click();
        }

        public void ClickLoadmorebuttonMobile()
        {
            Driver.JsScrollToElement(LoadmoreMobile);
            LoadmoreMobile.Click();
        }

        public bool CheckNumberOfArticleAfterClickLoadMoreDesktop()
        {
            try
            {
                Driver.WaitAjax(Utility.Utility.SMALL_COMPONENT_TIMEOUT);

                if (ArticleList.Count == 25) { return true; }
                else { return false; }
            }
            catch { return false; }
        }

        public bool CheckNumberOfArticleAfterClickLoadMoreMobile()
        {
            try
            {
                Driver.WaitAjax(Utility.Utility.SMALL_COMPONENT_TIMEOUT);

                if (ArticleListsMobile.Count == 28) { return true; }
                else { return false; }
            }
            catch { return false; }
        }

        public void ClickBrowserBack()
        {
            Utility.Utility.InjectJavascript(Driver, "javascript: setTimeout(\"history.go(-1)\", 2000)");
            //Driver.Navigate().Back();
            //Driver.WaitAjax(Utility.Utility.SMALL_COMPONENT_TIMEOUT);
            Thread.Sleep(5000);
        }

        public bool IsGamePopupDisplay()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_GAME_POPUP)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }
        public bool IsGamePopupDisplayMobile()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_GAME_POPUP_MOBILE)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }


        public void ClickGameCloseButton()
        {
            try
            {
                GameCloseButton.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickGameCloseButtonMobile()
        {
            try
            {
                Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_FB_SHARE_BUTTON)).Enabled, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                GameCloseButtonMobile.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickShowsMenu()
        {
            try
            {
                ShowsMenuButton.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickFoodMenu()
        {
            try
            {
                FoodMenuButton.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickParentingMenu()
        {
            try
            {
                ParentingMenuButton.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickPetsMenu()
        {
            try
            {
                PetsMenuButton.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickDiyMenu()
        {
            try
            {
                DiyMenuButton.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickHealthyMenu()
        {
            try
            {
                Utility.Utility.JsScrollToElement(Driver, HealthyMenuButton);
                HealthyMenuButton.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickSweetMenu()
        {
            try
            {
                Utility.Utility.JsScrollToElement(Driver, SweetMenuButton);
                SweetMenuButton.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickSavoryMenu()
        {
            try
            {
                Utility.Utility.JsScrollToElement(Driver, SavoryMenuButton);
                SavoryMenuButton.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickHealthyMenuMobile()
        {
            try
            {
                Utility.Utility.JsScrollToElement(Driver, HealtyMenuButtonMobile);
                HealtyMenuButtonMobile.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickSweetMenuMobile()
        {
            try
            {
                Utility.Utility.JsScrollToElement(Driver, SweetMenuButtonMobile);
                SweetMenuButtonMobile.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickSavoryMenuMobile()
        {
            try
            {
                Utility.Utility.JsScrollToElement(Driver, SavoryMenuButtonMobile);
                SavoryMenuButtonMobile.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickLTLogo()
        {
            try
            {
                LTLogo.Click();
                Driver.WaitAjax(Utility.Utility.SMALL_COMPONENT_TIMEOUT);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public bool IsMainImageArticleDisplay()
        {
            try
            {
                return Utility.Utility.CheckCSSImageDisplay(Driver, XPATH_MAIN_POST_IMAGE);
            }
            catch { return false; }
        }

        public bool IsMainImageArticleDisplayMobile()
        {
            try
            {
                return Utility.Utility.CheckCSSImageDisplay(Driver, XPATH_MAIN_POST_IMAGE_MOBILE);
            }
            catch { return false; }
        }

        public bool IsAuthorArticleDisplay()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_AUTHOR_WRAP)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public bool IsSponsorAuthorArticleDisplay()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_SPONSOR_AUTHOR)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }
        public bool IsSponsorAuthorArticleDisplayMobile()
        {
            try
            {
                Thread.Sleep(3000);
                return Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_SPONSOR_AUTHOR_MOBILE)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public bool IsMainContentArticleDisplay()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_MAIN_CONTENT_BODY)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public bool IsFirstSliderImgaeDisplayMobile()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.XPath(XPATH_FIRST_SLIDE_IMAGE)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public bool IsFacebookShareButtonEnable()
        {
            try
            {
                Thread.Sleep(3000);
                if (FacebookShareButton.Count == 3)
                {
                    return Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_FB_SHARE_BUTTON)).Enabled, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                }
                else { return false; }
            }
            catch { return false; }
        }

        public void ClickFacebookShareButton()
        {
            string DeviceType = ConfigurationManager.AppSettings["device_type"];

            try
            {
                if (DeviceType == "Mobile")
                {
                    Utility.Utility.JsScrollToElement(Driver, FacebookShareButton[0]);
                    Thread.Sleep(3000);
                    Utility.Utility.InjectJavascript(Driver, "document.getElementsByClassName('site-header')[0].classList.remove('site-header');");
                }
                Utility.Utility.JsScrollToTop(Driver);
                FacebookShareButton[0].Click();
                Thread.Sleep(1000);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public bool IsFacebookWindowPopupDisplayed(string keyword)
        {
            try
            {
                Driver.SwitchToLastWindow();

                try { Driver.FindElement(By.XPath(XPATH_FB_POST_BUTTON)); }
                catch { LoginFacebook(); }

                Driver.FindElement(By.XPath(XPATH_FACEBOOK_SHARE_ARTICLE + keyword + "')]"));
                return true;
            }
            catch { return false; }
        }

        public bool IsFacebookWindowPopupDisplayedMobile(string keyword)
        {
            try
            {
                Driver.SwitchToLastWindow();

                try { Driver.FindElement(By.XPath(XPATH_FB_POST_BUTTON_MOBILE)); }
                catch { LoginFacebookMobile(); }

                Driver.FindElement(By.XPath(XPATH_FACEBOOK_SHARE_ARTICLE + keyword + "')]"));
                return true;
            }
            catch { return false; }
        }

        public void LoginFacebook()
        {
            string Username = ConfigurationManager.AppSettings["automate_username"];
            string Password = ConfigurationManager.AppSettings["automate_password"];

            try
            {
                Driver.WaitAjax(Utility.Utility.TINY_COMPONENT_TIMEOUT);
                FacebookUsernameBox.SendKeys(Username);
                FacebookPasswordBox.SendKeys(Password);
                FacebookLoginButton.Click();
                Driver.WaitAjax(Utility.Utility.SMALL_COMPONENT_TIMEOUT);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void LoginFacebookMobile()
        {
            string Username = ConfigurationManager.AppSettings["automate_username"];
            string Password = ConfigurationManager.AppSettings["automate_password"];

            try
            {
                Driver.WaitAjax(Utility.Utility.TINY_COMPONENT_TIMEOUT);
                FacebookUsernameBoxMobile.SendKeys(Username);
                FacebookPasswordBoxMobile.SendKeys(Password);
                FacebookLoginButtonMobile.Click();
                Driver.WaitAjax(Utility.Utility.SMALL_COMPONENT_TIMEOUT);
                Thread.Sleep(3000);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClosePopupFacebook()
        {
            try
            {
                Driver.SwitchToFirstWindow();
                Driver.CloseLastWindow();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public bool IsFacebookShareButtonEnableMobile()
        {
            try
            {
                if (FacebookShareButton.Count == 2)
                {
                    return Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_FB_SHARE_BUTTON)).Enabled, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                }
                else { return false; }
            }
            catch { return false; }
        }

        public bool IsContentArticleImageDisplay()
        {
            try
            {
                return Utility.Utility.CheckImageDisplay(Driver, XPATH_POST_IMAGE_ARTICLE);
            }
            catch { return false; }
        }
        public bool IsContentArticleImageDisplayMobile()
        {
            try
            {
                return Utility.Utility.CheckImageDisplay(Driver, XPATH_POST_IMAGE_ARTICLE_MOBILE);
            }
            catch { return false; }
        }

        public bool IsPaginationDisplay()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_PAGINATION_BAR)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public void ClickPaginetionNext()
        {
            try
            {
                PaginationNextButton.Click();
                Driver.WaitAjax(Utility.Utility.SMALL_COMPONENT_TIMEOUT);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickPaginetionPrev()
        {
            try
            {
                PaginationPrevButton.Click();
                Driver.WaitAjax(Utility.Utility.SMALL_COMPONENT_TIMEOUT);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickNextImageSlideShow()
        {
            try
            {
                SlideShowNextButton.Click();
                Driver.WaitAjax(Utility.Utility.SMALL_COMPONENT_TIMEOUT);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickPervImageSlideShow()
        {
            try
            {
                SlideShowPrevButton.Click();
                Driver.WaitAjax(Utility.Utility.SMALL_COMPONENT_TIMEOUT);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickSeeMoreLink()
        {
            try
            {
                SeeMoreLink.Click();
                Driver.WaitAjax(Utility.Utility.SMALL_COMPONENT_TIMEOUT);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public bool IsNextImageSlideShowDisplay()
        {
            try
            {
                return Utility.Utility.CheckImageDisplay(Driver, XPATH_SLIDESHOW_NEXT_IMAGE);
            }
            catch { return false; }
        }

        public bool CheckVerticalImageShowProperly()
        {
            try
            {
                //vertical Image must have more than 3 image in 1 artical
                for (int i=0;i<=3;i++)
                {
                    Utility.Utility.CheckImageDisplay(Driver, XPATH_POST_IMAGE_ARTICLE);
                }
                return true;
            }
            catch { return false; }
        }

        public bool CheckVerticalImageShowProperlyMobile()
        {
            try
            {
                //vertical Image must have more than 3 image in 1 artical
                for (int i = 0; i <= 3; i++)
                {
                    Utility.Utility.CheckImageDisplay(Driver, XPATH_POST_IMAGE_ARTICLE_MOBILE);
                }
                return true;
            }
            catch { return false; }
        }
        public bool IsOurProgramesDisplay()
        {
            try
            {
                Utility.Utility.JsScrollToElement(Driver, OurProgramList);
                return Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_OUR_PROGRAMS)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public bool IsOurProgramesDisplayMobile()
        {
            try
            {
                Utility.Utility.JsScrollToElement(Driver, OurProgramListmobile);
                return Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_OUR_PROGRAMS_MOBILE)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public bool CheckNumberOfVideoBlock()
        {
            try
            {
                if(VideoBlock.Count == 16)
                {
                    return Utility.Utility.CheckCSSImageDisplay(Driver, XPATH_VIDEO_BLOCK);
                }
                return true;
            }
            catch { return false; }
        }

        public bool CheckNumberOfVideoBlockMobile()
        {
            try
            {
                if (VideoBlockMobile.Count == 17)
                {
                    return Utility.Utility.CheckCSSImageDisplay(Driver, XPATH_VIDEO_BLOCK_MOBILE + "/a");
                }
                return true;
            }
            catch { return false; }
        }

        public void ClickQuickSelectedButton()
        {
            try
            {
                Utility.Utility.InjectJavascript(Driver,"document.getElementsByClassName('serial')[0].style.display = 'block';");
                Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_QUICK_SELECTED_BAR)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickFirstQuickSelectedMenu()
        {
            string DeviceType = ConfigurationManager.AppSettings["device_type"];

            try
            {
                QuickSelectedFirst.Click();
                if (DeviceType == "Mobile")
                {
                    QuickSelectedFirst.Click();
                }
                Driver.WaitAjax(Utility.Utility.SMALL_COMPONENT_TIMEOUT);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public bool IsSubShowMainImageDisplay()
        {
            try
            {
                return Utility.Utility.CheckImageDisplay(Driver, XPATH_SUB_SHOW_MAIN_IMAGE);
            }
            catch { return false; }
        }

        public bool IsSubShowMainImageDisplayMobile()
        {
            try
            {
                Driver.JsScrollToTop();
                return Utility.Utility.CheckImageDisplay(Driver, XPATH_SUB_SHOW_MAIN_IMAGE_MOBILE);
            }
            catch { return false; }
        }

        public bool CheckIsMenuHeaderCorrect(string menu)
        {
            try
            {
                var element = Driver.FindElement(By.XPath(XPATH_SUB_SHOW_HEADER));
                if (!string.IsNullOrEmpty(element.Text) && element.Text.Contains(menu))
                {
                    return true;
                }
                else { return false; }
            }
            catch { return false; }
        }

        public bool CheckIsMenuHeaderCorrectMobile(string menu)
        {
            try
            {
                var element = Driver.FindElement(By.XPath(XPATH_SUB_SHOW_HEADER_MOBILE));
                if (!string.IsNullOrEmpty(element.Text) && element.Text.Contains(menu))
                {
                    return true;
                }
                else { return false; }
            }
            catch { return false; }
        }

        public bool IsSubShowVideoListDisplay()
        {
            try
            {
                Utility.Utility.JsScrollToElement(Driver, SubVideoList[1]);
                return Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_SUB_SHOW_VIDEO_LIST)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public bool IsSubShowVideoListImageDisplay()
        {
            try
            {
                return Utility.Utility.CheckImageDisplay(Driver, XPATH_SUB_VIDEO_LIST_IMAGE + "/img");
            }
            catch { return false; }
        }

        public void ClickFirstSubShowVideoList()
        {
            try
            {
                SubVideoList[1].Click();
                Driver.WaitAjax(Utility.Utility.TINY_COMPONENT_TIMEOUT);
                Thread.Sleep(1000);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickFirstSubShowVideoListMobile()
        {
            try
            {
                Driver.JsScrollToTop();
                Thread.Sleep(1000);
                SubVideoListMobile.Click();
                Driver.WaitAjax(Utility.Utility.TINY_COMPONENT_TIMEOUT);
                Thread.Sleep(1000);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickCloseVideoPlayer()
        {
            try
            {
                VideoPlayerClosebutton.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickFirstVideoBlock()
        {
            try
            {
                VideoBlock[1].Click();
                Driver.WaitAjax(Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickFacebookSocialButton()
        {
            try
            {
                SocialFacebookIcon.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickPinterestSocialButton()
        {
            try
            {
                SocialPinterestIcon.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickTwitterSocialButton()
        {
            try
            {
                SocialTwitterIcon.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickEmailSocialButton()
        {
            try
            {
                SocialEmailIcon.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public bool IsUrlMatchAsExpected(string url)
        {
            try
            {
                Thread.Sleep(5000);
                string currentUrl = Utility.Utility.GetCurrentUrl(Driver);
                if (currentUrl == url)
                {
                    if (Driver.WindowHandles.Count > 1)
                    {
                        Driver.SwitchToFirstWindow();
                        Driver.CloseLastWindow();
                    }
                    return true;
                }
                else { return false; }
            }
            catch (Exception) { return false; }
        }

        public bool IsEmailSubscriptBoxDisplay()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_EMAIL_SUB_BOX)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public void ClickBackToStory()
        {
            try
            {
                SocialCloseSubButton.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickNoThankyou()
        {
            try
            {
                SocialEmailDismissButton.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void SubscriptToEmail(string email)
        {
            try
            {
                SocialEmailInput.SendKeys(email);
                SocialEmailSignupButton.Click();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public bool IsThankyouMessageDisplay()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_THANK_YOU_SUB)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }
        public bool IsErrorMessageDisplay()
        {
            try
            {
                return Driver.WaitUntil(d => Driver.FindElement(By.XPath(XPATH_ERROR_EMAIL)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
            }
            catch { return false; }
        }

        public void ClickAboutusLink(string type)
        {
            string DeviceType = ConfigurationManager.AppSettings["device_type"];

            try
            {
                if (DeviceType == "Desktop")
                {
                    if (type == "Footer")
                    {
                        Utility.Utility.JsScrollToElement(Driver, AboutUsFooter);
                        AboutUsFooter.Click();
                    }
                    else
                    {
                        HoverHambergerMenu();
                        Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_HAMBERGER_NEV_BAR)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                        Thread.Sleep(2000);
                        AboutUsHamberger.Click();
                    }
                }
                else
                {
                    if (type == "Footer")
                    {
                        Utility.Utility.JsScrollToElement(Driver, AboutUsFooterMobile);
                        Thread.Sleep(2000);
                        Actions actions = new Actions(Driver);
                        actions.MoveToElement(AboutUsFooterMobile).Click().Build().Perform();
                    }
                    else
                    {
                        ClickHambergerMenu();
                        Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_HAMBERGER_NEV_BAR_MOBILE)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                        Thread.Sleep(2000);
                        AboutUsHambergerMobile.Click();
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickAdvertisingLink(string type)
        {
            string DeviceType = ConfigurationManager.AppSettings["device_type"];

            try
            {
                if (DeviceType == "Desktop")
                {
                    if (type == "Footer")
                    {
                        Utility.Utility.JsScrollToElement(Driver, AdvertisingFooter);
                        AdvertisingFooter.Click();
                    }
                    else
                    {
                        HoverHambergerMenu();
                        Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_HAMBERGER_NEV_BAR)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                        Thread.Sleep(2000);
                        AdvertisingHamberger.Click();
                    }
                }
                else
                {
                    if (type == "Footer")
                    {
                        Utility.Utility.JsScrollToElement(Driver, AdvertisingFooterMobile);
                        Thread.Sleep(2000);
                        Actions actions = new Actions(Driver);
                        actions.MoveToElement(AdvertisingFooterMobile).Click().Build().Perform();
                    }
                    else
                    {
                        ClickHambergerMenu();
                        Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_HAMBERGER_NEV_BAR_MOBILE)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                        Thread.Sleep(2000);
                        AdvertisingHambergerMobile.Click();
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickPartnerLink(string type)
        {
            string DeviceType = ConfigurationManager.AppSettings["device_type"];

            try
            {
                if (DeviceType == "Desktop")
                {
                    if (type == "Footer")
                    {
                        Utility.Utility.JsScrollToElement(Driver, PartherFooter);
                        PartherFooter.Click();
                    }
                    else
                    {
                        HoverHambergerMenu();
                        Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_HAMBERGER_NEV_BAR)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                        Thread.Sleep(2000);
                        PartherHamberger.Click();
                    }
                }
                else
                {
                    if (type == "Footer")
                    {
                        Utility.Utility.JsScrollToElement(Driver, PartherFooterMobile);
                        Thread.Sleep(2000);
                        Actions actions = new Actions(Driver);
                        actions.MoveToElement(PartherFooterMobile).Click().Build().Perform();
                    }
                    else
                    {
                        ClickHambergerMenu();
                        Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_HAMBERGER_NEV_BAR_MOBILE)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                        Thread.Sleep(2000);
                        PartherHambergerMobile.Click();
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickPressLink(string type)
        {
            string DeviceType = ConfigurationManager.AppSettings["device_type"];

            try
            {
                if (DeviceType == "Desktop")
                {
                    if (type == "Footer")
                    {
                        Utility.Utility.JsScrollToElement(Driver, PressFooter);
                        PressFooter.Click();
                    }
                    else
                    {
                        HoverHambergerMenu();
                        Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_HAMBERGER_NEV_BAR)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                        Thread.Sleep(2000);
                        PressHamberger.Click();
                    }
                }
                else
                {
                    if (type == "Footer")
                    {
                        Utility.Utility.JsScrollToElement(Driver, PressFooterMobile);
                        Thread.Sleep(2000);
                        Actions actions = new Actions(Driver);
                        actions.MoveToElement(PressFooterMobile).Click().Build().Perform();
                    }
                    else
                    {
                        ClickHambergerMenu();
                        Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_HAMBERGER_NEV_BAR_MOBILE)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                        Thread.Sleep(2000);
                        PressHambergerMobile.Click();
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickCareerLink(string type)
        {
            string DeviceType = ConfigurationManager.AppSettings["device_type"];

            try
            {
                if (DeviceType == "Desktop")
                {
                    if (type == "Footer")
                    {
                        Utility.Utility.JsScrollToElement(Driver, CareerFooter);
                        CareerFooter.Click();
                    }
                    else
                    {
                        HoverHambergerMenu();
                        Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_HAMBERGER_NEV_BAR)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                        Thread.Sleep(2000);
                        CareerHamberger.Click();
                    }
                }
                else
                {
                    if (type == "Footer")
                    {
                        Utility.Utility.JsScrollToElement(Driver, CareerFooterMobile);
                        Thread.Sleep(2000);
                        Actions actions = new Actions(Driver);
                        actions.MoveToElement(CareerFooterMobile).Click().Build().Perform();
                    }
                    else
                    {
                        ClickHambergerMenu();
                        Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_HAMBERGER_NEV_BAR_MOBILE)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                        Thread.Sleep(2000);
                        CareerHambergerMobile.Click();
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickContactusLink(string type)
        {
            string DeviceType = ConfigurationManager.AppSettings["device_type"];

            try
            {
                if (DeviceType == "Desktop")
                {
                    if (type == "Footer")
                    {
                        Utility.Utility.JsScrollToElement(Driver, ContactUsFooter);
                        ContactUsFooter.Click();
                    }
                    else
                    {
                        HoverHambergerMenu();
                        Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_HAMBERGER_NEV_BAR)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                        Thread.Sleep(2000);
                        ContactUsHamberger.Click();
                    }
                }
                else
                {
                    if (type == "Footer")
                    {
                        Utility.Utility.JsScrollToElement(Driver, ContactUsFooterMobile);
                        Thread.Sleep(2000);
                        Actions actions = new Actions(Driver);
                        actions.MoveToElement(ContactUsFooterMobile).Click().Build().Perform();
                    }
                    else
                    {
                        ClickHambergerMenu();
                        Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_HAMBERGER_NEV_BAR_MOBILE)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                        Thread.Sleep(2000);
                        ContactUsHambergerMobile.Click();
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickPrivacyLink(string type)
        {
            string DeviceType = ConfigurationManager.AppSettings["device_type"];

            try
            {
                if (DeviceType == "Desktop")
                {
                    if (type == "Footer")
                    {
                        Utility.Utility.JsScrollToElement(Driver, PrivancyFooter);
                        PrivancyFooter.Click();
                        Driver.SwitchToLastWindow();
                    }
                    else
                    {
                        HoverHambergerMenu();
                        Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_HAMBERGER_NEV_BAR)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                        Thread.Sleep(2000);
                        PrivancyHamberger.Click();
                        Driver.SwitchToLastWindow();
                    }
                }
                else
                {
                    if (type == "Footer")
                    {
                        Utility.Utility.JsScrollToElement(Driver, PrivancyFooterMobile);
                        Thread.Sleep(2000);
                        Actions actions = new Actions(Driver);
                        actions.MoveToElement(PrivancyFooterMobile).Click().Build().Perform();
                        Driver.SwitchToLastWindow();
                    }
                    else
                    {
                        ClickHambergerMenu();
                        Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_HAMBERGER_NEV_BAR_MOBILE)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                        Thread.Sleep(2000);
                        PrivancyHambergerMobile.Click();
                        Driver.SwitchToLastWindow();
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickTermsLink(string type)
        {
            string DeviceType = ConfigurationManager.AppSettings["device_type"];

            try
            {
                if (DeviceType == "Desktop")
                {
                    if (type == "Footer")
                    {
                        Utility.Utility.JsScrollToElement(Driver, TermsFooter);
                        TermsFooter.Click();
                        Driver.SwitchToLastWindow();
                    }
                    else
                    {
                        HoverHambergerMenu();
                        Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_HAMBERGER_NEV_BAR)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                        Thread.Sleep(2000);
                        TermsHamberger.Click();
                        Driver.SwitchToLastWindow();
                    }
                }
                else
                {
                    if (type == "Footer")
                    {
                        Utility.Utility.JsScrollToElement(Driver, TermsFooterMobile);
                        Thread.Sleep(2000);
                        Actions actions = new Actions(Driver);
                        actions.MoveToElement(TermsFooterMobile).Click().Build().Perform();
                        Driver.SwitchToLastWindow();
                    }
                    else
                    {
                        ClickHambergerMenu();
                        Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_HAMBERGER_NEV_BAR_MOBILE)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                        Thread.Sleep(2000);
                        TermsHambergerMobile.Click();
                        Driver.SwitchToLastWindow();
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void ClickDmcaLink(string type)
        {
            string DeviceType = ConfigurationManager.AppSettings["device_type"];

            try
            {
                if (DeviceType == "Desktop")
                {
                    if (type == "Footer")
                    {
                        Utility.Utility.JsScrollToElement(Driver, DmcaFooter);
                        DmcaFooter.Click();
                    }
                    else
                    {
                        HoverHambergerMenu();
                        Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_HAMBERGER_NEV_BAR)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                        Thread.Sleep(2000);
                        DmcaHamberger.Click();
                    }
                }
                else
                {
                    if (type == "Footer")
                    {
                        Utility.Utility.JsScrollToElement(Driver, DmcaFooterMobile);
                        Thread.Sleep(2000);
                        Actions actions = new Actions(Driver);
                        actions.MoveToElement(DmcaFooterMobile).Click().Build().Perform();
                    }
                    else
                    {
                        ClickHambergerMenu();
                        Driver.WaitUntil(d => Driver.FindElement(By.CssSelector(CSS_HAMBERGER_NEV_BAR_MOBILE)).Displayed, Utility.Utility.TINY_COMPONENT_TIMEOUT);
                        Thread.Sleep(2000);
                        DmcaHambergerMobile.Click();
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
    }
}
