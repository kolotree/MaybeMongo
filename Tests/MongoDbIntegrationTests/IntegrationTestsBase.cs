using System;
using Mongo2Go;
using MaybeMongo.Repositories;

namespace MaybeMongo.Tests.MongoDbIntegrationTests
{
    
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