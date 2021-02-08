using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Api.Data;
using Api.Models;

namespace Api.Controllers
{
  [ApiController]
  [Route("payment")]
  public class PaymentController : Controller
  {
    [HttpGet]
    [Route("verify")]
    public async Task<ActionResult<Payment>> VerifyPayment(
      [FromServices] DataContext context,
      [FromHeader] Payment model)
    {
      var idUser = model.UserId;
      var idCourse = model.CourseId;

      var payment = await context.Payment.FindAsync(idUser, idCourse);

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