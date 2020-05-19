using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace eMart.Entities.Entities
{
 public class PurchasedHistory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PurchasedHistoryId { get; set; }
        public string BuyerId { get; set; }
        public string SellerId { get; set; }
        public string TransactionId { get; set; }
        public string PoductsId { get; set; }
        public int NumberOfProducts { get; set; }
        public DateTime DateAndTime { get; set; }
        public string remarks { get; set; }
        
    }
}
