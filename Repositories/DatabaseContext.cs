using MongoDB.Driver;

namespace MaybeMongo.Repositories
{
	using Domain;
	using MongoMappings;

	public sealed class DatabaseContext
	{
		private readonly IMongoDatabase _database;

		public DatabaseContext(string connectionString)
		{
			Mapper.MapAllClassesToMongoDb();   
			var mongoClient = new MongoClient(connectionString);
			_database = mongoClient.GetDatabase(nameof(MaybeMongo));
		}

		public IMongoCollection<T> GetCollectionFor<T>() where T : AggregateRoot
			=> _database.GetCollection<T>(typeof(T).Name);
	}
}