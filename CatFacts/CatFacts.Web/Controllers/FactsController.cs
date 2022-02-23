using CatFacts.Core.Interfaces;
using CatFacts.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CatFacts.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactsController : ControllerBase
    {
        private readonly IFactService _factService;

        public FactsController(IFactService factService)
        {
            _factService = factService;
        }

        // GET: api/<FactsController>
        [HttpGet]
        public async Task<ActionResult<CatFact>> GetFact()
        {
            try
            {
                await _factService.SaveFact();
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
