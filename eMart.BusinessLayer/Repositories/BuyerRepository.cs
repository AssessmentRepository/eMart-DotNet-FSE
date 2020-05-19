using eMart.BusinessLayer.Repositories;
using eMart.DataLayer;
using eMart.Entities;
using eMart.Entities.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eMart.BusinessLayer
{
  public  class BuyerRepository :IBuyerRepository
    {
        public readonly IMongoDBContext _mongoContext;
        public IMongoCollection<Buyer> _buyerdbCollection;
        public IMongoCollection<Products> _productsdbCollection;

        public BuyerRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _buyerdbCollection = _mongoContext.GetCollection<Buyer>(typeof(Buyer).Name);
            _productsdbCollection = _mongoContext.GetCollection<Products>(typeof(Products).Name);
        }


        public Task<bool> AddProductsToCart(IList<Products> products)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductFromCart(List<Products> products, string BuyerId)
        {
            throw new NotImplementedException();
        }

        public Task<Products> DetailsOfProduct(string productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Products>> FilterProduct(string ProductName, string CategoryName, int Price, string Manufacturer)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Buyer>> GetAllBuyers()
        {
            _buyerdbCollection = _mongoContext.GetCollection<Buyer>(typeof(Buyer).Name);
            var all = await _buyerdbCollection.FindAsync(Builders<Buyer>.Filter.Empty, null);
            return await all.ToListAsync();
        }

        public Task<IEnumerable<Products>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<Buyer> GetBuyerByIdAsync(string BuyerId)
        {
            var objectId = new ObjectId(BuyerId);
            FilterDefinition<Buyer> filter = Builders<Buyer>.Filter.Eq("_id", objectId);
           _buyerdbCollection = _mongoContext.GetCollection<Buyer>(typeof(Buyer).Name);
            return await _buyerdbCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
        }

        public Task<IEnumerable<Products>> GetItemfromCart(string buyerId)
        {
            throw new NotImplementedException();
        }

        public Task<Buyer> Login(Buyer buyer)
        {
            throw new NotImplementedException();
        }

        public Task LogOut(string buyerid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PaymentGate(string ProductsId, string buyerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Products>> PlaceOrder(List<Products> product, Buyer buyer)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterAsync(Buyer obj)
        {
            if (obj == null)
            { 
                return false;
              //  throw new ArgumentNullException(typeof(Buyer).Name + " object is null");
            }
          _buyerdbCollection = _mongoContext.GetCollection<Buyer>(typeof(Buyer).Name);
            await _buyerdbCollection.InsertOneAsync(obj);
            return true;
        }

        public Task<IEnumerable<Products>> SearchProduct(string ProductName, string CategoryName, string SubCategoryName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PurchasedHistory>> ViewHistoryOfPurchace(string buyerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Products>> ViewProductsInCart(string buyerId)
        {
            throw new NotImplementedException();
        }
    }
}
