using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Interface;
using Service.Request;
using System;

namespace Api.Controllers
{
    [Route("Assunto")]
    [ApiController]
    public class AssuntoController : ControllerBase
    {
        private readonly IAssuntoService _AssuntoService;

        public AssuntoController(IAssuntoService AssuntoService)
        {
            _AssuntoService = AssuntoService;
        }

        [HttpGet("GetById")]
        public IActionResult AssuntoGetId(int item)
        {
            try
            {
                return Ok(_AssuntoService.GetByID(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetLista")]
        public IActionResult AssuntoLista(int pagina)
        {
            try
            {
                return Ok(_AssuntoService.LoadPaginate(pagina));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetAll")]
        public IActionResult Assuntoss()
        {
            try
            {
                var resp = _AssuntoService.GetAll();

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPost("Save")]
        public IActionResult AssuntoSave(AssuntoReq item)
        {
            try
            {
                return Ok(_AssuntoService.Save(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("Update")]
        public IActionResult AssuntoUpdate(AssuntoReq item)
        {
            try
            {
                return Ok(_AssuntoService.Update(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
