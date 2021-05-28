using FinalProjectPepco.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;


namespace FinalProjectPepco.Test
{
    public class TestPepco
    {
        private static PepcoHomePage _page;
        
        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            IWebDriver _driver = new ChromeDriver();
            _driver.Url = "https://pepco.lt/";
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _page = new PepcoHomePage(_driver);
        }
        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            _page.CloseBrowser();
        }
        [Test]
        public static void TestPot()
        {
            _page.SetCookie();
            _page.SearchByText("vazonas");
            _page.PressOnSearchIcon();
        }
        [Test]
        public void CheckLikedItemResult()
        {
            _page.NavigateToPage();
            _page.SetCookie();
            _page.SearchByText("vazonas");
            _page.PressOnSearchIcon();
            _page.ClickButton();
            _page.CheckLikedResult();
        }
        [Test]
        public static void LanguageSelection()
        {
            _page.NavigateToPage();
            _page.SetCookie();
            _page.OrderByEnglishLanguage();
            _page.VerifyByLanguages();
        }
        [Test]
        public static void StoreSelection()
        {
            _page.SetCookie();
            _page.SearchPepcoStore("kaunas");
            _page.PressSearchIcon();
        }
    }
}
