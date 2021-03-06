using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

using Api.Models;
using Api.Repositories;

namespace Api.Controllers
{
  [ApiController]
  [Route("courses")]
  public class CourseController : Controller
  {
    [HttpGet]
    [Authorize]
    [Route("list-all")]
    public async Task<ActionResult<List<Course>>> Get([FromServices] CourseRepository repository)
    {
      var courses = await repository.Get().Course.ToListAsync();
      
      return Ok(courses);
    }

    [HttpGet]
    [Authorize]
    [Route("{id:int}")]
    public async Task<ActionResult<Course>> GetById(
      [FromServices] CourseRepository repository,
      int id)
    {
      var course = await repository.Get().Course.FirstOrDefaultAsync(x => x.Id == id);

      return Ok(course);
    }
  }
}