using Microsoft.AspNetCore.Mvc;
using cs_advanced_asp.net_and_apis.Services;
using cs_advanced_asp.net_and_apis.Models;
using Microsoft.AspNetCore.OutputCaching;


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

    [HttpGet]
    [OutputCache(Duration = 120)]
    public IActionResult GetTeachers()
    {
        return Ok(teachersService.GetTeachers());
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
        var teacherToPost = teachersService.PostTeacher(teacher);
        return Created("", teacherToPost);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTeacherById(int id)
    {
        if(teachersService.DeleteTeacher(id)) return NoContent();
        return NotFound();
    }
}
