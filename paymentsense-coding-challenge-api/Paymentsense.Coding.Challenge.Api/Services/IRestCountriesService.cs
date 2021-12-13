using Paymentsense.Coding.Challenge.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public interface IRestCountriesService
    {
        Task<IList<Country>> GetAllCountriesAsync();
        Task<Country> GetCountryAsync(string alpha3Code);
    }
}
