using Microsoft.AspNetCore.Mvc;
using cs_advanced_asp.net_and_apis.Services;


namespace cs_advanced_asp.net_and_apis.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpellsController(SpellsService spellsService) : Controller
    {
        private readonly SpellsService spellsService = spellsService;

        [HttpGet]
        public IActionResult GetSpells()
        {
            var spells = spellsService.GetSpells();
            return Ok(spells);
        }
    }
}
