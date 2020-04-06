using Be.The.Hero.Api.Interfaces.Services;
using Be.The.Hero.Api.Models;
using Microsoft.AspNetCore.Mvc;
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
