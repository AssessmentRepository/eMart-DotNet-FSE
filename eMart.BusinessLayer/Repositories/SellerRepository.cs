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
  public  class SellerRepository : ISellerRepository 
    {
        public readonly IMongoDBContext _mongoContext;
        public IMongoCollection<Seller> _sellerdbCollection;
        public IMongoCollection<Products> _productdbCollection;

        public SellerRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _sellerdbCollection = _mongoContext.GetCollection<Seller>(typeof(Seller).Name);
            _productdbCollection = _mongoContext.GetCollection<Products>(typeof(Products).Name);
        }

        public Task AddProducts(Products obj)
        {
            throw new NotImplementedException();
        }

        public Task AddProductsStock(IList<Products> product, Seller seller, int Stock)
        {
            throw new NotImplementedException();
        }

        public Task CreateReport(Stock stock, DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Products>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Seller>> GetAllSellers()
        {
            _sellerdbCollection = _mongoContext.GetCollection<Seller>(typeof(Seller).Name);
            var all = await _sellerdbCollection.FindAsync(Builders<Seller>.Filter.Empty, null);
            return await all.ToListAsync();
        }

            public Task<Products> GetProductsbyId(string productsId)
        {
            throw new NotImplementedException();
        }

        public async Task<Seller> GetSellersById(string SellerId)
        {
            throw new NotImplementedException();
        }

        public Task<Seller> Login(Seller Seller)
        {
            throw new NotImplementedException();
        }

        public Task LogOut(string sellerid)
        {
            throw new NotImplementedException();
        }

        public async Task Register(Seller obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> TaxCalculation()
        {
            throw new NotImplementedException();
        }

        public List<Stock> ViewSalesInventory(int SellerId)
        {
            throw new NotImplementedException();
        }
    }
}
