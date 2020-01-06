using AutoFixture;
using FluentAssertions;
using HRpest.APP.Controllers;
using HRpest.APP.Helpers;
using HRpest.BL.Model;
using HRpest.DAL.Class;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HRpest.UnitTests
{
    public class BlobHelperTests
    {
        [Fact]
        public void GenerateFileName_ShouldThrowIfNull()
        {
            // Arrange
            var helper = new BlobStorageHelper();

            //Act
            try
            {
                helper.GenerateFileName(null);
            } catch(Exception e)
            {
                //Assert
                e.Should().NotBeNull();
            }
        }

        [Fact]
        public void GenerateFileName_ShoudRecognizeExtensionWithManyPointsInName()
        {
            // Arrange
            var helper = new BlobStorageHelper();

            //Act
            var res = helper.GenerateFileName("djwoajdowa.dwo.dwi.dpp.dwd..pdf");

            //Assert
            res.Should().EndWith(".pdf");   
        }

        [Fact]
        public void GenerateFileName_ShouldReturnNullIfNoExtension()
        {
            // Arrange
            var helper = new BlobStorageHelper();

            //Act
            var res = helper.GenerateFileName("ddddd");

            //Assert
            res.Should().BeNull();
        }
    }
}
