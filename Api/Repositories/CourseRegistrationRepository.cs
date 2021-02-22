using System.Threading.Tasks;
using System;

using Api.Models;
using Api.Data;

namespace Api.Repositories
{
  public class CourseRegistrationRepository : BaseRepository
  {
    public CourseRegistrationRepository(DataContext context) : base(context)
    {
    }

    public async Task<dynamic> GenerateRegistration(int idUser, int idCourse)
    {
      Random random = new Random();
      var registration = random.Next(100000000, 1000000000);

      var dataRegistration = new CourseRegistration {
        IdRegistration = registration,
        UserId = idUser,
        CourseId = idCourse
      };

      this.context.CourseRegistration.Add(dataRegistration);
      
      return await this.context.SaveChangesAsync();
    }
  }
}