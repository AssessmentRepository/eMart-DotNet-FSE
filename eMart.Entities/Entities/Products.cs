using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace eMart.Entities.Entities
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductsId { get; set; }
        public string CategoryId { get; set; }
        public string SellerId { get; set; }
        public string SubCategoryId { get; set; }
        public int Price { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int StockNumber { get; set; }
        public string remarks{get; set;}
        public string Manufacturer { get; set; }
    }
}
