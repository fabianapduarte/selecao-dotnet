using System.Threading.Tasks;

using Api.Models;
using Api.Data;

namespace Api.Repositories
{
  public class UserRepository
  {
    protected DataContext context;

    public UserRepository(DataContext context)
    {
      this.context = context;
    }

    public async Task<dynamic> Add(User user)
    {
      this.context.User.Add(user);
      await this.context.SaveChangesAsync();
      return user; 
    }
  }
}