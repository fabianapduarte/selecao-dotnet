using Api.Data;

namespace Api.Repositories
{
  public abstract class BaseRepository
  {
    protected DataContext context;

    public BaseRepository(DataContext context)
    {
      this.context = context;
    }

    public DataContext Get()
    {
      return this.context;
    }
  }
}