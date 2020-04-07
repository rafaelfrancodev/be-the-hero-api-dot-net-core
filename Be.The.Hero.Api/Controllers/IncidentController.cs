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
            var result = await _incidentService.SelectWithOngPaginatedAsync(page);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Incident), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] Incident input)
        {
            var ongId = Request.Headers["Authorization"].ToString();
            input.OngId = ongId;
            var result = await _incidentService.InsertAsync(input);
            return Created("PostAsync", result);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var ongId = Request.Headers["Authorization"].ToString();
            var result = await _incidentService.DeleteAsync(id, ongId);
            if (result)
            {
                return NoContent();
            }
            return Unauthorized(new { Error = "Operation not permited." });
        }
    }
}
