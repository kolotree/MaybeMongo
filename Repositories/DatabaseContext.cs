using MongoDB.Driver;

namespace MaybeMongo.Repositories
{
	using Domain;
	using Repositories.MongoMappings;

	public sealed class DatabaseContext
	{
		private readonly IMongoClient _mongoClient;

		private readonly IMongoDatabase _database;

		public DatabaseContext(string connectionString)
		{
			Mapper.MapAllClassesToMongoDb();   
			_mongoClient = new MongoClient(connectionString);
			_database = _mongoClient.GetDatabase(nameof(MaybeMongo));
		}

		public IMongoCollection<T> GetCollectionFor<T>() where T : AggregateRoot
			=> _database.GetCollection<T>(typeof(T).Name);
	}
}