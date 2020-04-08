using System;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PeopleManager.Web.AcceptanceTests.Search
{
    public class SearchTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly string _appBaseUrl;

        public SearchTests()
        {
            _driver = new ChromeDriver();
            var config = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json")
                .Build();
            _appBaseUrl = config["AppBaseUrl"];
        }
        
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
        
        [Test]
        public void Should_list_people()
        {
            Given_a_search_index_page();

            Assert.That(_driver.FindElements(By.Id("peopleTable")).Count, Is.Not.Zero);   
        }
        [Test]
        public void Should_list_groups()
        {
            Given_a_search_index_page();
            
            Assert.That(_driver.FindElements(By.Id("departmentsTable")).Count, Is.Not.Zero);
        }
        
        [Test]
        public void Should_contain_searchTerms_element()
        {
            Given_a_search_index_page();
            
            Assert.That(_driver.FindElements(By.Id("searchTerm")).Count, Is.Not.Zero);
        }
        
        private void Given_a_search_index_page()
        {
            _driver.Navigate().GoToUrl($"{_appBaseUrl}/AddPerson");
            var searchTermBox = _driver.FindElement(By.Id("searchTerm"));
            searchTermBox.Clear();
            searchTermBox.SendKeys("d");
            
            _driver.FindElement(By.Id("startSearch")).Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(3))
                .Until(driver => driver.Url == _appBaseUrl + "/Search");
        }
    }
}
