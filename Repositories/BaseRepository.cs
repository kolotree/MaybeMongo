using System.Collections.Generic;
using CSharpFunctionalExtensions;
using MaybeMongo.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MaybeMongo.Repositories
{
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
            SetNewIdFor(aggregateRoot);
			var updateOptions = new UpdateOptions { IsUpsert = true };
			_mongoCollection.ReplaceOne(item => item.Id == aggregateRoot.Id, aggregateRoot, updateOptions);

			return aggregateRoot;
		}

        private void SetNewIdFor(AggregateRoot aggregateRoot)
		{
			if (aggregateRoot.Id == Id.None)
            {
                var objectId = ObjectId.GenerateNewId();
                var bsonObjectId = new BsonObjectId(objectId);
                aggregateRoot.SetId(Id.IdFrom(bsonObjectId.ToString()));
            }
		}
    }
}