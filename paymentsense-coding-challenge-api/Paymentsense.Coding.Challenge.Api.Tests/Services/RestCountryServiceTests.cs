using FluentAssertions;
using Moq;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.ServiceClients;
using Paymentsense.Coding.Challenge.Api.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Services
{
    public class RestCountryServiceTests
    {
        private Mock<IRestCountriesClient> _restCountriesClientMock;

        public RestCountryServiceTests()
        {
            _restCountriesClientMock = new Mock<IRestCountriesClient>();
        }

        [Fact]
        public async void RestCountryService_GetAllCountriesAsync_ReturnsOk()
        {
            // arrange
            var countryList = GetCountryList(5);
            var service = new RestCountriesService(_restCountriesClientMock.Object);
            _restCountriesClientMock.Setup(x => x.GetAllCountriesAsync()).ReturnsAsync(countryList);

            // act
            var result = await service.GetAllCountriesAsync();

            // assert
            result.Should().BeEquivalentTo(countryList);
        }

        [Fact]
        public async void RestCountryService_GetCountriesByAlpha3CodeAsync_ReturnsOk()
        {
            // arrange
            var countryList = GetCountryList(1);
            var service = new RestCountriesService(_restCountriesClientMock.Object);
            _restCountriesClientMock.Setup(x => x.GetCountriesByAlpha3CodeAsync(It.IsAny<string>())).ReturnsAsync(countryList);

            // act
            var result = await service.GetCountryAsync("1");

            // assert
            Assert.Equal(result, countryList[0]);
        }

        private List<Country> GetCountryList(int number)
        {
            var countryList = new List<Country>();
            for (var i = 0; i < number; i++)
            {
                countryList.Add(GetCountry(i));
            }
            return countryList;
        }

        private Country GetCountry(int i)
        {
            return new Country
            {
                Alpha3Code = i.ToString(),
                Name = "name-" + i,
                Population = i.ToString(),
                Region = "region-" + i,
            };
        }
    }
}
