using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.ServiceClients;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public class RestCountriesService : IRestCountriesService
    {
        private readonly IRestCountriesClient _countriesClient;

        public RestCountriesService(IRestCountriesClient countriesClient)
        {
            _countriesClient = countriesClient ?? throw new ArgumentNullException(nameof(countriesClient));
        }

        public async Task<IList<Country>> GetAllCountriesAsync()
        {
            // TODO map to domain object
            return await _countriesClient.GetAllCountriesAsync();
        }

        public async Task<Country> GetCountryAsync(string alpha3Code)
        {
            var countries = await _countriesClient.GetCountriesByAlpha3CodeAsync(alpha3Code);

            // handle anything specific here
            return countries.FirstOrDefault();
        }
    }
}
