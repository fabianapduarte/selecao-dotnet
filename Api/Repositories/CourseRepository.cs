using System.Threading.Tasks;

using Api.Models;
using Api.Data;
using System.Linq;

namespace Api.Repositories
{
  public class CourseRepository
  {
    protected DataContext context;

    public CourseRepository(DataContext context)
    {
      this.context = context;

      this.context.Course.Add(new Course{
        Id = 1,
        Title = "Curso JavaScript",
        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
        Price = 499.90F
      });

      this.context.Course.Add(new Course{
        Id = 2,
        Title = "Curso ASP.NET 5.0",
        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
        Price = 499.90F
      });

      this.context.Course.Add(new Course{
        Id = 3,
        Title = "Curso PHP",
        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
        Price = 499.90F
      });

      this.context.SaveChanges();
    }

    public DataContext Get()
    {
      return this.context;
    }
  }
}