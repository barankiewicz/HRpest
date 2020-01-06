using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests
{
    class JobOfferPage : IDisposable
    {
        private readonly IWebDriver _driver;
        private const string URI = "https://localhost:5001/JobOffer/Create";

        public IWebElement ActiveUntilElement => _driver.FindElement(By.Id("ActiveUntil"));
        public IWebElement CompanyNameElement => _driver.FindElement(By.Id("CompanyName"));
        public IWebElement LocationElement => _driver.FindElement(By.Id("Location"));
        public IWebElement HoursWeeklyElement => _driver.FindElement(By.Id("HoursWeekly"));
        public IWebElement RemoteHoursWeeklyElement => _driver.FindElement(By.Id("RemoteHoursWeekly"));
        public IWebElement MinimumPayElement => _driver.FindElement(By.Id("MinimumPay"));
        public IWebElement MaximumPayElement => _driver.FindElement(By.Id("MaximumPay"));
        public IWebElement PositionNameElement => _driver.FindElement(By.Id("PositionName"));
        public IWebElement JobDescriptionElement => _driver.FindElement(By.Id("JobDescription"));
        public IWebElement CreateElement => _driver.FindElement(By.Id("submit-btn"));

        public SelectElement CompanyNameSelect;

        public string Title => _driver.Title;
        public string Source => _driver.PageSource;
        public string LocationErrorMessage => _driver.FindElement(By.Id("Location-error")).Text;
        public string HoursWeeklyErrorMessage => _driver.FindElement(By.Id("HoursWeekly-error")).Text;
        public string RemoteHoursWeeklyErrorMessage => _driver.FindElement(By.Id("RemoteHoursWeekly-error")).Text;
        public string MinimumPayErrorMessage => _driver.FindElement(By.Id("MinimumPay-error")).Text;
        public string MaximumPayErrorMessage => _driver.FindElement(By.Id("MaximumPay-error")).Text;
        public string PositionNameErrorMessage => _driver.FindElement(By.Id("PositionName-error")).Text;
        public string JobDescriptionErrorMessage => _driver.FindElement(By.Id("JobDescription-error")).Text;

        public JobOfferPage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Navigate()
                .GoToUrl("https://localhost:5001/JobOffer/Create");

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            CompanyNameSelect = new SelectElement(CompanyNameElement);
        }

        public void Navigate() => _driver.Navigate()
               .GoToUrl(URI);

        public void PopulateActiveUntil(string val) => ActiveUntilElement.SendKeys(val);
        public void PopulateLocation(string val) => LocationElement.SendKeys(val);
        public void PopulateHoursWeekly(string val) => HoursWeeklyElement.SendKeys(val);
        public void PopulateRemoteHoursWeekly(string val) => RemoteHoursWeeklyElement.SendKeys(val);
        public void PopulateMinimumPay(string val) => MinimumPayElement.SendKeys(val);
        public void PopulateMaximumPay(string val) => MaximumPayElement.SendKeys(val);
        public void PopulatePositionName(string val) => PositionNameElement.SendKeys(val);
        public void PopulateJobDescription(string val) => JobDescriptionElement.SendKeys(val);


        public void ClickCreate() => CreateElement.Click();

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
