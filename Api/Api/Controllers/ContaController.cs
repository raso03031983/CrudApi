using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.Request;
using System;

namespace Api.Controllers
{
    [Route("Conta")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _ContaService;

        public ContaController(IContaService ContaService)
        {
            _ContaService = ContaService;
        }

        [HttpGet("GetById")]
        public IActionResult ContaGetId(Guid item)
        {
            try
            {
                return Ok(_ContaService.GetByID(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetLista")]
        public IActionResult ContaLista(int pagina)
        {
            try
            {
                return Ok(_ContaService.LoadPaginate(pagina));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Save")]
        public IActionResult ContaSave(ContaReq item)
        {
            try
            {
                return Ok(_ContaService.Save(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("Update")]
        public IActionResult ContaUpdate(ContaReq item)
        {
            try
            {
                return Ok(_ContaService.Update(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
