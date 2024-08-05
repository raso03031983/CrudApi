using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.Request;
using System;

namespace Api.Controllers
{
    [Route("Livro")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _LivroService;

        public LivroController(ILivroService LivroService)
        {
            _LivroService = LivroService;
        }

        [HttpGet("GetById")]
        public IActionResult LivroGetId(int item)
        {
            try
            {
                return Ok(_LivroService.GetByID(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetLista")]
        public IActionResult LivroLista(int pagina)
        {
            try
            {
                var resp = _LivroService.LoadPaginate(pagina);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetAll")]
        public IActionResult Livros()
        {
            try
            {
                var resp = _LivroService.GetAll();

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Save")]
        public IActionResult LivroSave(LivroReq item)
        {
            try
            {
                return Ok(_LivroService.Save(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("Update")]
        public IActionResult LivroUpdate(LivroReq item)
        {
            try
            {
                return Ok(_LivroService.Update(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
