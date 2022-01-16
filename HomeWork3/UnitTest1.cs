using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace HomeWork3
{   
    [TestFixture]
    public class Tests
    {
        private IWebDriver chromeDriver;

        private readonly By _searchInputButton = By.XPath("//input[@id='search_query_top']");
        private readonly By _actualResult = By.XPath("//li[contains(text(), 'T-shirts > Faded Short Sleeve T-')]");
        private readonly By _productPage = By.XPath("//body[@id='product']");
        private readonly By _productName = By.XPath("//h1[contains(text(), 'Faded Short Sleeve T-shirts')]");
        private readonly By _addCardButton = By.XPath("//p[@id='add_to_cart']/button");
        private readonly By _succesResultHeader = By.XPath("//h2[normalize-space()='Product successfully added to your shopping cart']");

        private const string _searchQuery = "shirts";
        private const string _actualQuery = "Faded Short Sleeve T-shirts";
        private readonly string _succesQuery = "Product successfully added to your shopping cart";

        [SetUp]
        public void Setup()
        {
            chromeDriver = new ChromeDriver();
            chromeDriver.Navigate().GoToUrl(@"http://automationpractice.com/index.php");
            chromeDriver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {         
           //In the Search field, enter the value "shirts".
            var searchField = chromeDriver.FindElement(_searchInputButton);
            searchField.SendKeys(_searchQuery);

            //Wait for the element under Search with the text "T-shirts > Faded Short Sleeve T-" to appear
            //and click on this element.
            WebDriverWait waitActualResult = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            IWebElement firstActualResult = waitActualResult.Until(e => e.FindElement(_actualResult));
            firstActualResult.Click();

            //Wait for the product page to appear.
            WebDriverWait waitProductPage = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(5));
            IWebElement firstProductPage = waitProductPage.Until(e => e.FindElement(_productPage));

            //Check that the product name is "Faded Short Sleeve T-shirts".
            var productTitle = chromeDriver.FindElement(_productName);
            Assert.AreEqual(productTitle.Text, _actualQuery);

            //Click on the Add to cart button.
            var addCardButton = chromeDriver.FindElement(_addCardButton);
            addCardButton.Click();

            //Wait for the element with the text "Product successfully added to your shopping cart".
            var succesfulHeader = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(5))
                    .Until(drv => drv.FindElement(_succesResultHeader));
            succesfulHeader.Text.Equals(_succesQuery);
        }

        [TearDown]
        public void TearDown()
        {
            chromeDriver.Quit();
        }
    }
}