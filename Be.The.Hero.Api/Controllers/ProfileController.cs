using Be.The.Hero.Api.Interfaces.Services;
using Be.The.Hero.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Be.The.Hero.Api.Controllers
{
    [Route("profiles")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IIncidentService _incidentService;

        public ProfileController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Incident), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAsync()
        {
            var ongId = Request.Headers["Authorization"].ToString();
            var result = await _incidentService.SelectAllByOngAsync(ongId);
            return Ok(result);
        }
    }
}
