using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.Request;
using System;

namespace Api.Controllers
{
    [Route("Transacao")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _TransacaoService;

        public TransacaoController(ITransacaoService TransacaoService)
        {
            _TransacaoService = TransacaoService;
        }

        [HttpGet("GetById")]
        public IActionResult TransacaoGetId(Guid item)
        {
            try
            {
                return Ok(_TransacaoService.GetByID(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetLista")]
        public IActionResult TransacaoLista(int pagina)
        {
            try
            {
                return Ok(_TransacaoService.LoadPaginate(pagina));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Save")]
        public IActionResult TransacaoSave(TransacaoReq item)
        {
            try
            {
                return Ok(_TransacaoService.Save(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("Update")]
        public IActionResult TransacaoUpdate(TransacaoReq item)
        {
            try
            {
                return Ok(_TransacaoService.Update(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
