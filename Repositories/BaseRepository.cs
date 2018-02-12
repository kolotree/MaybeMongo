using System.Collections.Generic;
using CSharpFunctionalExtensions;
using MongoDB.Driver;

namespace MaybeMongo.Repositories
{
	using Domain;

	public abstract class BaseRepository<T> where T : AggregateRoot
	{
		protected readonly IMongoCollection<T> _mongoCollection;
		
		public BaseRepository(DatabaseContext databaseContext)
		{
			_mongoCollection = databaseContext.GetCollectionFor<T>();
		}

		public Maybe<T> GetBy(Id id)
			=> _mongoCollection.Find(item => item.Id == id).SingleOrDefault();

		public IList<T> GetAll()
			=> _mongoCollection.AsQueryable().ToList();

		public T Save(T aggregateRoot)
		{
			var updateOptions = new UpdateOptions { IsUpsert = true };
			_mongoCollection.ReplaceOne(item => item.Id == aggregateRoot.Id, aggregateRoot, updateOptions);
			return aggregateRoot;
		}
	}
}