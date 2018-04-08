using MongoDB.Bson.Serialization;

namespace MaybeMongo.Repositories.MongoMappings
{
	using Domain;
	using Domain.CustomerAggregate;

	internal static class Mapper
	{
		public static void MapAllClassesToMongoDb()
		{
			// static constructor is called when calling any class method.
			// Also static constructor will ensure that mapping will be executed only once.
		}

		static Mapper()
		{
			MapCommonClasses();
			MapDomain();
		}

		private static void MapCommonClasses()
		{
			BsonClassMap.RegisterClassMap<Entity>(map =>
			{
				map.MapIdProperty(m => m.Id).SetSerializer(new IdSerializer());
				map.SetIsRootClass(true);
			});
		}

		private static void MapDomain()
		{
			BsonClassMap.RegisterClassMap<Address>(map =>
			{
				map.MapProperty(m => m.Street);
				map.MapProperty(m => m.Number);
				map.MapProperty(m => m.City);
				map.MapCreator(m => new Address(m.Street, m.Number, m.City));
			});

			BsonClassMap.RegisterClassMap<Customer>(map =>
			{
				map.MapProperty(m => m.Name);
				map.MapProperty(m => m.Age);
				map.MapProperty(m => m.MaybeBillingAddress).SetSerializer(new MaybeSerializer<Address>());
				map.MapCreator(m => new Customer(m.Id, m.Name, m.Age, m.MaybeBillingAddress));
			});
		}
	}
}