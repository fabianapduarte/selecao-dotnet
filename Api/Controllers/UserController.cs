using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Api.Models;
using Api.Services;
using Api.Repositories;

namespace Api.Controllers
{
  [ApiController]
  public class UserController : ControllerBase
  {
    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> Authenticate(
      [FromServices] AuthenticationService auth,
      [FromServices] TokenService token,
      [FromBody] User userLogin)
    {
      var user = auth.Get(userLogin.Email, userLogin.Password);

      if (user == null)
      {
        return NotFound(new { message = "Email ou senha inválidos" });
      }

      var t = token.GenerateToken(user);
      user.Password = "";

      return new
      {
        user = user,
        token = t
      };
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("register")]
    public async Task<ActionResult<User>> Post(
      [FromServices] UserRepository context,
      [FromBody] User model)
    {
      if (ModelState.IsValid) 
      {
        if (!context.VerifyIfUserExists(model.Email))
        {
          return await context.Add(model);
        }
        else
        {
          return BadRequest(new { message = "Um usuário com o e-mail digitado já existe." });
        }
      }
      else
      {
        return BadRequest(ModelState);
      }
    }

    [HttpGet]
    [Route("list-users")]
    public async Task<ActionResult<List<User>>> Get([FromServices] UserRepository repository)
    {
      var users = await repository.Get().User.ToListAsync();
      users.ForEach(user => {
        user.CreditCard = "";
        user.Password = "";
      });
    
      return Ok(users);
    }
  }
}