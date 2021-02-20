using Microsoft.EntityFrameworkCore;

using Api.Models;

namespace Api.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options)
      : base(options)
    {
    }

    public DbSet<User> User { get; set; }
    public DbSet<Course> Course { get; set; }
    public DbSet<Payment> Payment { get; set; }
    public DbSet<CourseRegistration> CourseRegistration { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>()
        .Property(user => user.Id)
        .ValueGeneratedOnAdd();
        
      modelBuilder.Entity<User>()
        .HasKey(user => new { user.Id, user.Email });
    }
  }
}