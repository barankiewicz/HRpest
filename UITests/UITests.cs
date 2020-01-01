using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace UITests
{
    public class UITests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly JobOfferPage _page;
        public UITests()
        {
            _driver = new ChromeDriver();
            _page = new JobOfferPage(_driver);
            _page.Navigate();
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void Create_WhenExecuted_ReturnsCreateView()
        {
            Assert.Contains("Active Until", _driver.PageSource);
            Assert.Contains("CompanyName", _driver.PageSource);
        }

        [Fact]
        public void Create_WrongModelData_ReturnsErrorMessage()
        {
            _page.PopulateLocation("d");
            _page.PopulateHoursWeekly("-1");
            _page.PopulateRemoteHoursWeekly("-1");
            _page.PopulatePositionName("d");
            _page.PopulateJobDescription("haha");
            _page.PopulateMaximumPay("-1");
            _page.PopulateMinimumPay("-1");

            _page.ClickCreate();

            Assert.Equal("Please enter at least 2 characters.", _page.LocationErrorMessage);
            Assert.Equal("Please enter a value greater than or equal to 1.", _page.HoursWeeklyErrorMessage);
            Assert.Equal("Please enter a value greater than or equal to 0.", _page.RemoteHoursWeeklyErrorMessage);
            Assert.Equal("Please enter at least 5 characters.", _page.PositionNameErrorMessage);
            Assert.Equal("Please enter at least 100 characters.", _page.JobDescriptionErrorMessage);
            Assert.Equal("Please enter a value greater than or equal to 0.", _page.MaximumPayErrorMessage);
            Assert.Equal("Please enter a value greater than or equal to 0.", _page.MinimumPayErrorMessage);

            
        }

        [Fact]
        public void Create_ChoosingACompany_PopulatesForm()
        {
            _page.CompanyNameSelect.SelectByText("Google");

            Assert.Equal("Warsaw", _page.LocationElement.Text);
            Assert.Equal("40", _page.HoursWeeklyElement.Text);
            Assert.Equal("20", _page.RemoteHoursWeeklyElement.Text);
        }
    }
}
