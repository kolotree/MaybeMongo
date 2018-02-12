using MongoDB.Driver;

namespace MaybeMongo.Repositories
{
	using Domain;
	using Repositories.MongoMappings;

	public sealed class DatabaseContext
	{
		private readonly IMongoClient _mongoClient;

		private readonly IMongoDatabase _rntlDatabase;

		public DatabaseContext(string connectionString)
		{
			Mapper.MapAllClassesToMongoDb();   
			_mongoClient = new MongoClient(connectionString);
			_rntlDatabase = _mongoClient.GetDatabase(nameof(MaybeMongo));
		}

		public IMongoCollection<T> GetCollectionFor<T>() where T : AggregateRoot
		 => _rntlDatabase.GetCollection<T>(typeof(T).Name);

		public void Dispose()
		{
		}
	}
}