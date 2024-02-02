using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class PruductRepository : BaseRepository<PruductEntity>
{
    public PruductRepository(DataContext context) : base(context)
    {
    }
}


