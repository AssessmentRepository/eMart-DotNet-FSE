using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace eMart.Entities.Entities
{
  public  class Discounts
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DiscountsId { get; set; }
        public string productsId { set; get; }
        public string DiscountCode { get; set; }
        public int Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Descriptions { get; set; }
    }
}
