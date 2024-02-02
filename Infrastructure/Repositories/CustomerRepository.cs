using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class CustomerRepository : BaseRepository<CustomerEntity>
{
    public CustomerRepository(DataContext context) : base(context)
    {
    }
}


