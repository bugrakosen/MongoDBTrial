using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDBTrial.Entity.Attributes;
using System;

namespace MongoDBTrial.Entity
{
    [BsonCollection("todos")]
    public class TodoModel : Document
    {
        [BsonElement("Title")]
        [BsonRequired]
        public string Title { get; set; }

        [BsonElement("Completed")]
        public bool Completed { get; set; }

        [BsonElement("OptimalLine")]
        public DateTime? OptimalLine { get; set; }
    }
}
