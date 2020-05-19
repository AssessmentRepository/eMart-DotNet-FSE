using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace eMart.Entities.Entities
{
   public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string  CategoryId {get; set;}
        public string CategoryName { get; set; }
        public string BreifDetails { get; set; }
    }
}
