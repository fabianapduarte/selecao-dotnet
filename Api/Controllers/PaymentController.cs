using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;

using Api.Models;
using Api.Repositories;

namespace Api.Controllers
{
  [ApiController]
  public class PaymentController : Controller
  {
    [HttpPost]
    [Authorize]
    [Route("register-course")]
    public async Task<ActionResult<Payment>> RegisterCourse(
      [FromBody] Payment payment,
      [FromServices] PaymentRepository context
    )
    {
      if(ModelState.IsValid)
      {
        try
        {
          await context.Add(payment);

          return Ok(new { message = "Inscrição realizada com sucesso. Pague a primeira parcela para concluir o processo de matrícula no curso." });
        }
        catch (ArgumentException)
        {
          return BadRequest(new { message = "Você já se inscreveu nesse curso." });
        }
      }
      else
      {
        return BadRequest(ModelState);
      }
    }

    /*[HttpGet]
    [Authorize]
    [Route("list-payments")]
    public async Task<ActionResult<dynamic>> ListPayments(
      [FromHeader] int idUser,
      [FromServices] PaymentRepository context
    )
    {
      var payments = await context.Get().Payment
        .Where(x => x.UserFK == idUser)
        .ToListAsync();

      return Ok(payments);
    }*/

    [HttpGet]
    [Authorize]
    [Route("")]
    public async Task<ActionResult<Payment>> VerifyPayment(
      [FromServices] PaymentRepository context,
      [FromHeader] int idUser,
      int idCourse)
    {
      var payment = await context.Get().Payment.FindAsync(idUser, idCourse);

      if (payment == null)
      {
        return NotFound();
      }

      if (payment.PaymentsReceived > 0)
      {
        return Ok(true);
      }
      else
      {
        return Ok(false);
      }
    }
  }
}