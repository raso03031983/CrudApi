using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System;

namespace Api.Controllers
{
    [Route("RedeSocial")]
    [ApiController]
    public class RedeSocialController : ControllerBase
    {
        private readonly IRedeSocialService _redeSocialService;

        public RedeSocialController(IRedeSocialService redeSocialService)
        {
            _redeSocialService = redeSocialService;
        }


        [HttpGet("tipoRedeSocial")]
        public IActionResult tipoTelefone()
        {
            try
            {
                return Ok(_redeSocialService.GetRedeSocial());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
