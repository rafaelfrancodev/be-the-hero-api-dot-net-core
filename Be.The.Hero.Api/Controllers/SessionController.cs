using Be.The.Hero.Api.Application.SessionAppService.Input;
using Be.The.Hero.Api.Interfaces.Services;
using Be.The.Hero.Api.Models.ValueObject;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Be.The.Hero.Api.Controllers
{
    [Route("sessions")]
    [ApiController]
    public class SessionController: ControllerBase
    {
        private readonly IOngService _ongService;

        public SessionController(IOngService ongService)
        {
            _ongService = ongService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(SessionValueObject), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] SessionInput input)
        {
            var result = await _ongService.SelectByIdAsync(input.Id);
            if(result == null)
            {
                return BadRequest(new { Error = "No ONG found with this ID." });
            }
            return Ok(new SessionValueObject { Ong = result});
        }
    }
}
