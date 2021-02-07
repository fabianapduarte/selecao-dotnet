using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models;

namespace Api.Controllers
{
  [ApiController]
  [Route("courses")]
  public class CourseController : Controller
  {
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<Course>>> Get([FromServices] DataContext context)
    {
      var courses = await context.Course.ToListAsync();
      
      return Ok(courses);
    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<Course>> Post(
      [FromServices] DataContext context,
      [FromBody] Course model)
    {
      if (ModelState.IsValid) 
      {
        context.Course.Add(model);
        await context.SaveChangesAsync();
        return model;
      }
      else
      {
        return BadRequest(ModelState);
      }
    }
  }
}