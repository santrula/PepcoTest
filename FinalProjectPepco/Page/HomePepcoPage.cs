using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectPepco.Page
{
    public class HomePepcoPage : BasePage
    {

        private const string languageOptionText = ("English");
        private IReadOnlyCollection<IWebElement> resultList =>  Driver.FindElements(By.CssSelector(".col-8.col-sm-4.col-md-3"));
        private IWebElement SearchInput => Driver.FindElement(By.Id("search"));
        private IWebElement SearchIcon => Driver.FindElement(By.CssSelector(".header-search__button"));
        private IWebElement Button => Driver.FindElement(By.CssSelector(".col-12:nth-child(1) .product-box__fav"));

        //private IWebElement ResultElement => Driver.FindElement(By.CssSelector(".main-menu__link.js-show-dropdown"));
        private IWebElement ResultElement => Driver.FindElement(By.CssSelector(".icon-fav.main-menu__icon"));
        private IWebElement ButtonGlobe => Driver.FindElement(By.CssSelector(".icon-globe.main-menu__icon"));
        private SelectElement orderByDropdown => new SelectElement(Driver.FindElement(By.CssSelector(".col-8:nth-child(2) .dropdown-lang-box__image")));
        public HomePepcoPage(IWebDriver webdriver) : base(webdriver) { }


        public void SearchByText(string searchText)
        {
            SearchInput.Clear();
            SearchInput.SendKeys(searchText);
            SearchIcon.Click();

        }
        public void PressOnSearchIcon()
        {
            SearchIcon.Click();
        }

        //public void ClickButton()
        //{
        //    Button.Click();
        //}
        public void CheckLikedResult(string searchText)
        {
            SearchInput.SendKeys(searchText);
            SearchIcon.Click();
            Button.Click();
            Assert.AreEqual("(1)", ResultElement.Text, "Liked item does not equal 1");
          
        }
        public void OrderByEnglishLanguage()
        {
            ButtonGlobe.Click();
            orderByDropdown.SelectByText("languageOptionText");
            
        }
        public void VerifyByLanguages(string title)
        {
            IWebElement secondItem =resultList.ElementAt(1);
            secondItem.Click();
            //IWebElement languageCodeElement = secondItem.FindElement(By.CssSelector(".dropdown-lang-box__translated-name"));
            Assert.AreEqual("https://pepco.eu/", Driver.Url, "Country is wrong");
        }
        



    }
}

