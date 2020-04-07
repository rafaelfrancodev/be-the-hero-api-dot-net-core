using Be.The.Hero.Api.Interfaces.Services;
using Be.The.Hero.Api.Models;
using Be.The.Hero.Api.Models.ValueObject;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Be.The.Hero.Api.Controllers
{
    [Route("incidents")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService _incidentService;

        public IncidentController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<IncidentWithOngValueObject>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAsync([FromQuery] int page = 1)
        {
            var total = await _incidentService.CountAllWithOngAsync();
            Response.Headers.Add("X-Total-Count", total.ToString());
            var resultado = await _incidentService.SelectWithOngPaginatedAsync(page);
            return Ok(resultado);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Incident), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] Incident input)
        {
            var ongId = Request.Headers["Authorization"].ToString();
            input.OngId = ongId;
            var resultado = await _incidentService.InsertAsync(input);
            return Ok(resultado);
        }
    }
}
