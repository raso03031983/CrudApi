using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.Request;
using System;

namespace Api.Controllers
{
    [Route("Tipotransacao")]
    [ApiController]
    public class TipotransacaoController : ControllerBase
    {
        private readonly ITipoTransacaoService _TipotransacaoService;

        public TipotransacaoController(ITipoTransacaoService TipotransacaoService)
        {
            _TipotransacaoService = TipotransacaoService;
        }

        [HttpGet("GetById")]
        public IActionResult TipotransacaoGetId(int item)
        {
            try
            {
                return Ok(_TipotransacaoService.GetByID(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetLista")]
        public IActionResult TipotransacaoLista(int pagina)
        {
            try
            {
                return Ok(_TipotransacaoService.LoadPaginate(pagina));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Save")]
        public IActionResult TipotransacaoSave(TipoTransacaoReq item)
        {
            try
            {
                return Ok(_TipotransacaoService.Save(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("Update")]
        public IActionResult TipotransacaoUpdate(TipoTransacaoReq item)
        {
            try
            {
                return Ok(_TipotransacaoService.Update(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
