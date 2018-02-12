using System;
using Mongo2Go;


namespace MaybeMongo.Tests.MongoDbIntegrationTests
{
	using Repositories;

	public abstract class IntegrationTestsBase : IDisposable
	{
		private readonly MongoDbRunner _mongoDbRunner = MongoDbRunner.Start();
		private readonly DatabaseContext _databaseContext;

		public IntegrationTestsBase()
		{
			_databaseContext = new DatabaseContext(_mongoDbRunner.ConnectionString);
		}

		protected CustomerRepository GetCustomerRepository()
			=> new CustomerRepository(_databaseContext);

		public void Dispose()
		{
			_mongoDbRunner.Dispose();
		}
	}
}