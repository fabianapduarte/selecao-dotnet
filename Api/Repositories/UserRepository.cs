using System.Threading.Tasks;
using System.Linq;

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

    public async Task<User> Add(User user)
    {
      this.context.User.Add(user);
      await this.context.SaveChangesAsync();
      user.Password = "";
      return user;     
    }

    public bool VerifyIfUserExists(string email)
    {
      var userFiltered = (
        from u in context.User
        where u.Email == email
        select u
      ).FirstOrDefault();

      if (userFiltered != null)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public DataContext Get()
    {
      return this.context;
    }
  }
}