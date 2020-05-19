using eMart.BusinessLayer.Interfaces;
using eMart.DataLayer;
using eMart.Entities.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eMart.BusinessLayer.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        public readonly IMongoDBContext _mongoContext;
        public IMongoCollection<Category> _CategorydbCollection;
        public IMongoCollection<SubCategory> _SubCategoryCollection;

        public AdminRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _CategorydbCollection = _mongoContext.GetCollection<Category>(typeof(Category).Name);
            _SubCategoryCollection = _mongoContext.GetCollection<SubCategory>(typeof(SubCategory).Name);
           
        }

        public Task<Category> AddCategories(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddDiscounts(Discounts discount)
        {
            throw new NotImplementedException();
        }

        public Task<SubCategory> AddSubCategory(SubCategory subcategory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> BlockAndUnblockSpecificBuyer(string buyerId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> BlockAndUnblockSpecificProduct(string productId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> BlockAndUnblockSpecificSeller(string sellerId)
        {
            throw new NotImplementedException();
        }

        public Task<Discounts> UpdateDiscountsDiscounts(Discounts discount)
        {
            throw new NotImplementedException();
        }

        public Task ViewDailyTurnOverCategoryWise(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
