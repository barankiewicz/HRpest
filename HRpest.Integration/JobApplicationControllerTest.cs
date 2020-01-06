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
    public class JobApplicationControllerTest : IntegrationTest
    {
        [Fact]
        public async Task Index_ShouldNotBeEmpty()
        {
            //Arrange

            //Act
            var response = await TestClient.GetAsync("JobApplication/Index");

            //Assert
            (await response.Content.ReadAsStringAsync()).Should().NotBeEmpty();
        }

        [Fact]
        public async Task GetJobApplications_ShouldBeBadRequest()
        {
            //Arrange

            //Act
            var response = await TestClient.GetAsync("JobApplication/GetJobApplications?jobOfferId=1");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetJobApplications_ShouldBeEmpty()
        {
            //Arrange

            //Act
            var response = await TestClient.GetAsync("JobApplication/GetJobApplications?jobOfferId=0");

            //Assert
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
            (await response.Content.ReadAsStringAsync()).Should().BeEmpty();
        }

        [Fact]
        public async Task GetJobApplication_ShouldBeNotFound()
        {
            //Arrange

            //Act
            var response = await TestClient.GetAsync("JobApplication/GetJobApplication?id=1");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            (await response.Content.ReadAsStringAsync()).Should().BeEmpty();
        }
    }
}
