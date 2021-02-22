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

    [HttpGet]
    [Authorize]
    [Route("payment-register/{idCourse:int}")]
    public async Task<ActionResult<dynamic>> ListPayments(
      [FromHeader] int idUser,
      int idCourse,
      [FromServices] PaymentRepository context
    )
    {
      var payment = await context.Get().Payment.FindAsync(idUser, idUser);

      if (payment == null)
      {
        return NotFound(new { message = "Você ainda não se inscreveu nesse curso." });
      }

      return Ok(payment);
    }

    [HttpPut]
    [Authorize]
    [Route("make-payment")]
    public async Task<ActionResult<dynamic>> MakePayment(
      [FromServices] PaymentRepository context,
      [FromBody] Payment paymentData)
    {
      var payment = await context.VerifyPayments(paymentData.UserFK, paymentData.CourseFK);

      if (payment == null)
      {
        return NotFound(new { message = "Você ainda não se inscreveu nesse curso." });
      }

      if (payment.PaymentsReceived < payment.TotalPayments)
      {
        await context.Pay(paymentData.UserFK, paymentData.CourseFK);
        return Ok(new { message = "Pagamento realizado com sucesso" });
      }
      else
      {
        return BadRequest(new { message = "Não há mais pagamentos a serem realizados" });
      }
    }
  }
}