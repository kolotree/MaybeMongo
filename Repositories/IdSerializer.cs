using MaybeMongo.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace MaybeMongo.Repositories
{
    internal class IdSerializer : SerializerBase<Id>
	{
		public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Id value)
		{
            context.Writer.WriteObjectId(new ObjectId(value.StringId));
		}

		public override Id Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
		{
			var idString = context.Reader.ReadObjectId();
			return Id.IdFrom(idString.ToString());
		}
	}
}