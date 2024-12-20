using Microsoft.AspNetCore.Mvc;
using cs_advanced_asp.net_and_apis.Services;
using cs_advanced_asp.net_and_apis.Models;


namespace cs_advanced_asp.net_and_apis.Controllers;

[ApiController]
[Route("[controller]")]
public class TeachersController : Controller
{
    private readonly TeachersService teachersService;

    public TeachersController(TeachersService teachersService)
    {
        this.teachersService = teachersService;
    }

    [HttpGet("{id}")]
    public IActionResult GetTeacherById(int id)
    {
        var teacher = teachersService.GetTeacherById(id);
        if (teacher == null) return NotFound();
        return Ok(teacher);
    }

    [HttpPost]
    public IActionResult PostTeacher(Teacher teacher)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var teacherToPost = teachersService.PostTeacher(teacher);
        return Created("", teacherToPost);
    }
}
