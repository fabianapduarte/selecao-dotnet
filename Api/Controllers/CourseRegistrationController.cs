using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Api.Models;
using Api.Repositories;
using System.Linq;

namespace Api.Controllers
{
  [ApiController]
  public class CourseRegistrationController : Controller
  {
    [HttpPost]
    [Authorize]
    [Route("generate-registration/{idCourse:int}")]
    public async Task<ActionResult<Payment>> GenerateRegistration(
      [FromHeader] int idUser,
      int idCourse,
      [FromServices] CourseRegistrationRepository context,
      [FromServices] PaymentRepository paymentContext
    )
    {
      var payment = await paymentContext.VerifyPayments(idUser, idCourse);

      if (payment == null)
      {
        return NotFound(new { message = "Inscrição e pagamentos não encontrados" });
      }

      if (payment.PaymentsReceived > 0)
      {
        await context.GenerateRegistration(idUser, idCourse);
        return Ok(new { message = "Matrícula gerada com sucesso" });
      }
      else
      {
        return BadRequest(new { message = "Realize um pagamento para gerar a matrícula." });
      }
    }

    [HttpGet]
    [Authorize]
    [Route("list-registration/{idCourse:int}")]
    public async Task<ActionResult<dynamic>> ListRegistration(
      [FromHeader] int idUser,
      int idCourse,
      [FromServices] CourseRegistrationRepository context
    )
    {
      var registration = context.Get().CourseRegistration.Where(x => x.UserId == idUser && x.CourseId == idCourse);

      if (registration == null)
      {
        return NotFound(new { message = "Você não se matriculou nesse curso." });
      }

      return Ok(registration);
    }
  }
}