using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace eMart.Entities.Entities
{
    public class Transactions
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string  TransactionsId{get;set;}
        public string BuyerId { get; set; }
        public string sellerId { get; set; }
        public string TransactionsType { get; set; }
        public DateTime TransactionsDateTime { get; set; }
        public string Remarks { get; set; }
    }
}
