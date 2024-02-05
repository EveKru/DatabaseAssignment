using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class ProductRepository : BaseRepository<ProductEntity>
{
    public ProductRepository(DataContext context) : base(context)
    {
    }
}


