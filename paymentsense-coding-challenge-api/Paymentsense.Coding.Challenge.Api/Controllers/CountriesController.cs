using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paymentsense.Coding.Challenge.Api.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CountriesController : ControllerBase
    {
        private readonly IRestCountriesService _restCountriesService;

        public CountriesController(IRestCountriesService restCountriesService)
        {
            _restCountriesService = restCountriesService ?? throw new ArgumentNullException(nameof(restCountriesService));
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllCountries()
        {
            // usually prefer to do controller error handling in middleware
            try
            {
                var countries = await _restCountriesService.GetAllCountriesAsync();
                // TODO map to DTO
                return Ok(countries);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                return StatusCode(500, "An unexpected error as occured");
            }
        }

        [HttpGet]
        [Route("alpha/{alpha3Code}")]
        public async Task<ActionResult> GetCountry(
            [StringLength(3)]string alpha3Code)
        {
            try
            {
                var countries = await _restCountriesService.GetCountryAsync(alpha3Code);

                return Ok(countries);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                return StatusCode(500, "An unexpected error as occured");
            }
        }

    }
}
