using System.Threading.Tasks;

using Api.Models;
using Api.Data;

namespace Api.Repositories
{
  public class PaymentRepository : BaseRepository
  {
    public PaymentRepository(DataContext context) : base(context)
    {
    }

    public async Task<dynamic> Add(Payment payment)
    {
      this.context.Payment.Add(payment);
      
      return await this.context.SaveChangesAsync();
    }

    public async Task<dynamic> VerifyPayments(int UserId, int CourseId)
    {
      var payment = await this.context.Payment.FindAsync(UserId, CourseId);

      if (payment == null)
      {
        return null;
      }

      return payment;
    }

    public async Task<dynamic> Pay(int UserId, int CourseId)
    {
      var payment = this.context.Payment.Find(UserId, CourseId);
      payment.PaymentsReceived ++;

      this.context.Payment.Update(payment);
      return await this.context.SaveChangesAsync();
    }
  }
}