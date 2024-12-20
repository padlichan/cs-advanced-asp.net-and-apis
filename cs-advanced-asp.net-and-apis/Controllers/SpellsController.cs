using Microsoft.AspNetCore.Mvc;
using cs_advanced_asp.net_and_apis.Services;
using Microsoft.AspNetCore.RateLimiting;


namespace cs_advanced_asp.net_and_apis.Controllers;

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

    [HttpGet]
    [EnableRateLimiting("fixed")]
    [Route("/spell")]
    public IActionResult GetSpell()
    {
        var spell = spellsService.GetSpell();
        if (spell == null) return NoContent();
        return Ok(spellsService.GetSpell());
    }
}
