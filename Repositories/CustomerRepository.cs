using MaybeMongo.Domain;

namespace MaybeMongo.Repositories
{
    public sealed class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}