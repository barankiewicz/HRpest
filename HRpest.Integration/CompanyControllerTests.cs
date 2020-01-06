using FluentAssertions;
using HRpest.BL.Model;
using HRpest.IntegrationTests;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HRpest.Integration
{
    public class CompanyControllerTests : IntegrationTest
    {
        [Fact]
        public async Task Index_ShouldNotBeEmpty()
        {
            //Arrange

            //Act
            var response = await TestClient.GetAsync("Company/Index");

            //Assert
            (await response.Content.ReadAsStringAsync()).Should().NotBeEmpty();
        }

        [Fact]
        public async Task GetJobApplications_ShouldBeBadRequest()
        {
            //Arrange

            //Act
            var response = await TestClient.GetAsync("Company/GetCompanies");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetJobApplication_ShouldBeNotFound()
        {
            //Arrange

            //Act
            var response = await TestClient.GetAsync("Company/GetCompany?id=1");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            (await response.Content.ReadAsStringAsync()).Should().BeEmpty();
        }
    }
}
