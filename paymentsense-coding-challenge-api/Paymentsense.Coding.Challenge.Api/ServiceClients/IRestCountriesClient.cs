using Paymentsense.Coding.Challenge.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.ServiceClients
{
    public interface IRestCountriesClient
    {
        Task<IList<Country>> GetAllCountriesAsync();
        Task<IList<Country>> GetCountriesByAlpha3CodeAsync(string alpha3Code);
    }
}
