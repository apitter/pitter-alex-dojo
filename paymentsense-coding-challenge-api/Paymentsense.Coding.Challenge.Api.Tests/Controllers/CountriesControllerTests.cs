using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Paymentsense.Coding.Challenge.Api.Controllers;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Controllers
{
    public class CountriesControllerTests
    {
        private Mock<IRestCountriesService> _countriesServiceMock;

        public CountriesControllerTests()
        {
            _countriesServiceMock = new Mock<IRestCountriesService>();

        }

        [Fact]
        public void RestCountryController_GetAllCountries_ReturnsOk()
        {
            // arrange
            var countryList = GetCountryList(5);
            _countriesServiceMock.Setup(x => x.GetAllCountriesAsync()).ReturnsAsync(countryList);
            var controller = new CountriesController(_countriesServiceMock.Object);

            // act
            var result = controller.GetAllCountries().Result as OkObjectResult;

            // assert
            result.Value.Should().Be(countryList);
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public void RestCountryController_GetCountry_ReturnsOk()
        {
            // arrange
            var country = GetCountry(1);
            _countriesServiceMock.Setup(x => x.GetCountryAsync(It.IsAny<string>())).ReturnsAsync(country);
            var controller = new CountriesController(_countriesServiceMock.Object);

            // act
            var result = controller.GetCountry("1").Result as OkObjectResult;

            // assert
            result.Value.Should().Be(country);
            result.StatusCode.Should().Be(200);
        }

        // TODO test verification on parameters

        // TODO test failure paths

        // TODO integration test


        private List<Country> GetCountryList(int number)
        {
            var countryList = new List<Country>();
            for(var i = 0; i < number; i++)
            {
                countryList.Add(GetCountry(i));
            }
            return countryList;
        }

        private Country GetCountry(int i)
        {
            return new Country {
                Alpha3Code = i.ToString(), 
                Name = "name-" + i, 
                Population = i.ToString(), 
                Region = "region-" + i, 
            };
        }
    }
}
