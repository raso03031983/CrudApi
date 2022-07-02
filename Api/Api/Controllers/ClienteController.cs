using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System;

namespace Api.Controllers
{
    [Route("Cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("GetById")]
        public IActionResult ClienteGetId(int item)
        {
            try
            {
                return Ok(_clienteService.GetByID(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetLista")]
        public IActionResult ClienteLista(int pagina)
        {
            try
            {
                return Ok(_clienteService.LoadPaginate(pagina));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Save")]
        public IActionResult ClienteSave(ClienteDto item)
        {
            try
            {
                return Ok(_clienteService.Save(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("Update")]
        public IActionResult ClienteUpdate(ClienteDto item)
        {
            try
            {
                return Ok(_clienteService.Update(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult ClienteDelete(int item)
        {
            try
            {
                return Ok(_clienteService.Delete(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
