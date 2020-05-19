using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace eMart.Entities.Entities
{
   public class Stock
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string StockId { get; set; }
        public string SellerId { get; set; }
        public string ProductId { get; set; }
        public int AddedQuantity { get; set; }
        public int soldQuantity { get; set; }
    }
}
