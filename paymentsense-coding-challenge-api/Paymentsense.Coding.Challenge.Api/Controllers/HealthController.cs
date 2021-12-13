using Microsoft.AspNetCore.Mvc;
using Paymentsense.Coding.Challenge.Api.Models;

namespace Paymentsense.Coding.Challenge.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public ActionResult<HealthModel> Get()
        {
            return Ok(new HealthModel());
        }
    }
}
