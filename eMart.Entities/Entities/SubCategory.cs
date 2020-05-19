using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace eMart.Entities.Entities
{
  public  class SubCategory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string CategoryId { get; set; }
        public string BreifDetails { get; set; }
        public int GST { get; set; }
    }
}
