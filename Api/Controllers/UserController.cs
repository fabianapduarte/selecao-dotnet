using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
        return await context.Add(model);
      }
      else
      {
        return BadRequest(ModelState);
      }
    }
  }
}