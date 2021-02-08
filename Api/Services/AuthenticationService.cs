using System;
using System.Text;
using System.Linq;

using Api.Models;
using Api.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
  public class AuthenticationService
  {
    protected DataContext data;

    public AuthenticationService(DataContext data)
    {
      this.data = data;
    }

    public User Get(string email, string password)
    {
      return this.data.User.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
    }
  }
}