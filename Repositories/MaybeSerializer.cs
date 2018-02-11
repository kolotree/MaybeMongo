using CSharpFunctionalExtensions;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace MaybeMongo.Repositories
{
    internal class MaybeSerializer<T> : SerializerBase<Maybe<T>>
    {
        private readonly IBsonSerializer _valueSerializer = BsonSerializer.LookupSerializer(typeof(T));

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Maybe<T> maybe)
        {
            if (maybe.HasValue)
            {
                _valueSerializer.Serialize(context, args, maybe.Value);
            }
            else
            {
                _valueSerializer.Serialize(context, args, null);
            }
        }


        public override Maybe<T> Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            
            var value = (T)_valueSerializer.Deserialize(context);
            return Maybe<T>.From(value);   
        }
    }
}