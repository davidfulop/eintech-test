using System;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PeopleManager.Web.AcceptanceTests.AddPerson
{
    public class AddPersonTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly string _appBaseUrl;

        public AddPersonTests()
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
        public void Should_contain_searchTerms_element()
        {
            Given_an_index_page();
            
            Assert.That(_driver.FindElements(By.Id("searchTerm")).Count, Is.Not.Zero);
        }
        
        [Test]
        public void Should_redirect_to_AddPersonPage_when_adding_a_person()
        {
            Given_an_index_page_set_up_with("Alma Beka");

            When_trying_to_add_person();
            
            Assert.That(_driver.FindElements(By.Id("searchTerm")).Count, Is.Not.Zero);
        }

        
        private void Given_an_index_page()
        {
            _driver.Navigate().GoToUrl($"{_appBaseUrl}/AddPerson");
        }
        
        private void Given_an_index_page_set_up_with(string newPersonName)
        {
            Given_an_index_page();
            EnterNewPersonName(newPersonName);
        }
        
        private void When_trying_to_add_person()
        {
            var success = TryNavigateToAddPersonPage();
            if (!success)
                throw new AssertionException("Navigation to AddPerson page failed.");
        }
        
        
        private void EnterNewPersonName(string name)
        {
            var newPersonNameInput = _driver.FindElement(By.Id("NewPerson_Name"));
            newPersonNameInput.Clear();
            newPersonNameInput.SendKeys(name);
        }

        private bool TryNavigateToAddPersonPage(int timeoutSeconds = 5)
        {
            _driver.FindElement(By.Id("AddPersonButton")).Click();
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds))
                .Until(driver => driver.Url == _appBaseUrl + "/AddPerson/AddPerson");
        }
    }
}
