using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;


namespace FinalProjectPepco.Page
{
    public class PepcoHomePage : BasePage
    {

        private const string addressUrl = "https://pepco.lt/";
        private IReadOnlyCollection<IWebElement> resultList => Driver.FindElements(By.CssSelector(".col-8.col-sm-4.col-md-3"));
        private IWebElement SearchInput => Driver.FindElement(By.Id("search"));
        private IWebElement SearchIcon => Driver.FindElement(By.CssSelector(".header-search__button"));
        private IWebElement Button => Driver.FindElement(By.CssSelector(".col-12:nth-child(1) .product-box__fav"));       
        private IWebElement FavoriteResultElement => Driver.FindElement(By.CssSelector(".main-menu__link.js-show-dropdown"));
        private IWebElement ButtonGlobe => Driver.FindElement(By.XPath("//a[@data-target='#js-header-dropdown-lang']"));        
        private IWebElement SearchStoreInput => Driver.FindElement(By.CssSelector(".search-shop-form__input"));
        private IWebElement ClickSearchIcon => Driver.FindElement(By.CssSelector(".search-shop-form__submit > .icon-search"));
       
        public PepcoHomePage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != addressUrl)
            {
                Driver.Url = addressUrl;
            }
        }
        public void SetCookie()

        {
            Cookie myCookie = new Cookie("pepco_cookies",

                "all",

               "pepco.lt",

               "/",

               DateTime.Now.AddDays(2));

            Driver.Manage().Cookies.AddCookie(myCookie);

            Driver.Navigate().Refresh();
        }
        public void SearchByText(string searchText)
        {
            SearchInput.Clear();
            SearchInput.SendKeys(searchText);
        }
        public void PressOnSearchIcon()
        {
            SearchIcon.Click();
        }
        public void ClickButton()
        {
            Button.Click();
        }
        public void CheckLikedResult()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(_driver => FavoriteResultElement.Text.Contains("1"));
            Assert.IsTrue(FavoriteResultElement.Text.Contains("1"), $"Liked item does not equal 1, item text {FavoriteResultElement.Text}");
        }
        public void OrderByEnglishLanguage()
        {
            ButtonGlobe.Click();
            IWebElement secondItem = resultList.ElementAt(1);
            secondItem.Click();
        }
        public void VerifyByLanguages()
        {
            
            Assert.AreEqual("https://pepco.eu/", Driver.Url, "Country is wrong");
        }
        public void SearchPepcoStore(string searchText)
        {
            SearchStoreInput.SendKeys(searchText);
            ClickSearchIcon.Click();
        }
        public void PressSearchIcon()
        {
            ClickSearchIcon.Click();
           
        }
    }
    }
