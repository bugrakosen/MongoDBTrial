using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBTrial.Entity
{
    public class User:Document
    {
        [BsonElement]
        [BsonRequired]
        public string UserName { get; set; }

        [BsonElement]
        [BsonRequired]
        public string Password { get; set; }

        [BsonElement]
        [BsonRequired]
        public ObjectId TodoId { get; set; }
    }
}
