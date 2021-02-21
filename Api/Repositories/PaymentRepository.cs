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
  }
}