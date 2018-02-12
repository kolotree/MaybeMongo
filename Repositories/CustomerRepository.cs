namespace MaybeMongo.Repositories
{
	using Domain.CustomerAggregate;

	public sealed class CustomerRepository : BaseRepository<Customer>
	{
		public CustomerRepository(DatabaseContext databaseContext) : base(databaseContext)
		{
		}
	}
}