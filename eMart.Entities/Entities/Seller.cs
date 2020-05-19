using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace eMart.Entities.Entities
{
    public class Seller
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SellerId { get; set; }
        public string UserName {get;set;}
        public string Password {get;set;}
        public string CompanyName{get;set;}
        public long GSTIN {get;set;}
        public string BriefAboutCompany {get;set;}
        public string Postal_Address {get;set;}
        public string  WebSite {get;set;}
        public string Email {get;set;}
        public long ContactNumber {get;set;}
    }
}
