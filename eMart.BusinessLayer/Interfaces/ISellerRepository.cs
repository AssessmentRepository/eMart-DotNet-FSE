using eMart.BusinessLayer.Interfaces;
using eMart.DataLayer;
using eMart.Entities;
using eMart.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMart.BusinessLayer
{
    public interface ISellerRepository 
    {
        Task Register(Seller obj);
        Task<Seller> Login(Seller Seller);
        Task LogOut(string sellerid);

        Task<Seller> GetSellersById(string SellerId);
        Task<IEnumerable<Seller>> GetAllSellers();
        Task<IEnumerable<Products>> GetAllProducts();

        List<Stock> ViewSalesInventory(int SellerId);

        Task CreateReport(Stock stock, DateTime fromDate, DateTime toDate);

        Task AddProductsStock(IList<Products> product, Seller seller, int Stock);
        Task<int> TaxCalculation();

       Task<Products>  GetProductsbyId(string productsId);

        Task AddProducts(Products obj);
    }
}
