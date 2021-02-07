using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models;

namespace Api.Controllers
{
  [ApiController]
  [Route("user")]
  public class UserController : ControllerBase
  {
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<User>> GetById(
      [FromServices] DataContext context, 
      int id)
    {
      var user = await context.User.FindAsync(id);

      if (user == null)
      {
        return NotFound();
      }

      return user;
    }

    [HttpPost]
    [Route("register")]
    public async Task<ActionResult<User>> Post(
      [FromServices] DataContext context,
      [FromBody] User model)
    {
      if (ModelState.IsValid) 
      {
        context.User.Add(model);
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