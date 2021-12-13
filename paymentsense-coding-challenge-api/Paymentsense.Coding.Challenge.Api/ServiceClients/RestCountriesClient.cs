using Paymentsense.Coding.Challenge.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.ServiceClients
{
    public class RestCountriesClient : ServiceClient, IRestCountriesClient
    {
        const string COUNTRIES_URI = "https://restcountries.com/v2/";
        const string ALL_ENDPOINT = "all";
        const string CODES_ENDPOINT = "alpha";

        public RestCountriesClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<IList<Country>> GetAllCountriesAsync()
        {
            var uri = BuildUri(ALL_ENDPOINT);

            var response = CallService<IList<Country>>(uri, HttpMethod.Get);

            return response;
        }

        public Task<IList<Country>> GetCountriesByAlpha3CodeAsync(string alpha3Code)
        {
            var uri = BuildUri(CODES_ENDPOINT + $"?codes={alpha3Code}");

            var response = CallService<IList<Country>>(uri, HttpMethod.Get);

            return response;
        }

        private string BuildUri(string endpoint)
        {
            var uriSb = new StringBuilder(COUNTRIES_URI);
            uriSb.Append(endpoint);

            return uriSb.ToString();
        }
    }
}
