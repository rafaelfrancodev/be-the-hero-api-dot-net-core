using Be.The.Hero.Api.Interfaces.Services;
using Be.The.Hero.Api.Models;
using Be.The.Hero.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Be.The.Hero.Api.Controllers
{
    [Route("ongs")]
    [ApiController]
    public class OngController : ControllerBase
    {
        private readonly IOngService _ongService;

        public OngController(IOngService ongService)
        {
            _ongService = ongService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Ong>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAsync()
        {
            var resultado = await _ongService.SelectAllAsync();
            return Ok(resultado);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Ong), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] Ong input)
        {
            var resultado = await _ongService.InsertAsync(input);
            return Ok(resultado);
        }
    }
}
