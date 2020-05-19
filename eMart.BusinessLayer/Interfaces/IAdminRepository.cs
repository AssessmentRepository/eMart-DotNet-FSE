using eMart.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eMart.BusinessLayer.Interfaces
{
   public interface IAdminRepository
    {
        Task<bool> BlockAndUnblockSpecificSeller(string sellerId);
        Task<bool> BlockAndUnblockSpecificProduct(string productId);
        Task<bool> BlockAndUnblockSpecificBuyer(string buyerId);
        Task<Category> AddCategories(Category category);
        Task<SubCategory> AddSubCategory(SubCategory subcategory);
        Task<bool> AddDiscounts(Discounts discount);
        Task<Discounts> UpdateDiscountsDiscounts(Discounts discount);
        Task ViewDailyTurnOverCategoryWise(Category category);
    }
}

