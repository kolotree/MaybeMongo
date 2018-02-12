using MaybeMongo.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace MaybeMongo.Repositories.MongoMappings
{
    internal sealed class IdSerializer : SerializerBase<Id>
	{
		public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Id value)
		{
			UpdateNoneId(value);
			context.Writer.WriteObjectId(new ObjectId(value.StringId));
		}

		private void UpdateNoneId(Id id)
		{
			if (id == Id.None)
			{
				var objectId = ObjectId.GenerateNewId();
				var bsonObjectId = new BsonObjectId(objectId);
				id.SetIfNone(bsonObjectId.ToString());
			}
		}

		public override Id Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
		{
			var idString = context.Reader.ReadObjectId();
			return Id.IdFrom(idString.ToString());
		}
	}
}