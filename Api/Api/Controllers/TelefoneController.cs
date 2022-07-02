using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System;

namespace Api.Controllers
{

    [Route("Telefone")]
    [ApiController]

    public class TelefoneController : ControllerBase
    {
        private readonly ITelefoneService _telefoneService;

        public TelefoneController(ITelefoneService telefoneService)
        {
            _telefoneService = telefoneService;
        }

        [HttpGet("tipoTelefone")]
        public IActionResult tipoTelefone()
        {
            try
            {
                return Ok(_telefoneService.GetTiposTelefone());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
