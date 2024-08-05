using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Interface;
using Service.Request;
using System;

namespace Api.Controllers
{
    [Route("Autor")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _AutorService;

        public AutorController(IAutorService AutorService)
        {
            _AutorService = AutorService;
        }

        [HttpGet("GetById")]
        public IActionResult AutorGetId(int item)
        {
            try
            {
                return Ok(_AutorService.GetByID(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetLista")]
        public IActionResult AutorLista(int pagina)
        {
            try
            {
                return Ok(_AutorService.LoadPaginate(pagina));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetAll")]
        public IActionResult Autores()
        {
            try
            {
                var resp = _AutorService.GetAll();

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Save")]
        public IActionResult AutorSave(AutorReq item)
        {
            try
            {
                return Ok(_AutorService.Save(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("Update")]
        public IActionResult AutorUpdate(AutorReq item)
        {
            try
            {
                return Ok(_AutorService.Update(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
