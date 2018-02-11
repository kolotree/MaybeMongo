using MaybeMongo.Domain;
using MongoDB.Bson.Serialization;

namespace MaybeMongo.Repositories
{
    public sealed class Mapper
    {
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