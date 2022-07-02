using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System;

namespace Api.Controllers
{
    public class PopulateDbController : ControllerBase
    {
        private readonly IPopulateDbService _populateDbService;
        public PopulateDbController(IPopulateDbService populateDbService)
        {
            _populateDbService = populateDbService;
        }

        [HttpGet("PopulateDb")]
        public IActionResult PopulateDb()
        {
            try
            {
                _populateDbService.PopulateTables();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
