using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDBTrial.Entity
{
    public abstract class Document
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public ObjectId Id { get; set; }

        DateTime CreatedAt => Id.CreationTime;
    }
}
