using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace eMart.Entities.Entities
{
   public class Cart
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CartId { get; set; }
       public string buyerId { get; set; }
        public List<Products> listOfItems = new List<Products>();
    }
}
