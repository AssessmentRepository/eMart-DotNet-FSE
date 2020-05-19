using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace eMart.Entities.Entities
{
    public class Buyer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BuyerId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public long mobileNumber { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Token { get; set; }
    }
}
