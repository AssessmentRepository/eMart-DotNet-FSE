using eMart.BusinessLayer.Interfaces;
using eMart.DataLayer;
using eMart.Entities;
using eMart.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eMart.BusinessLayer
{
   public interface IBuyerRepository
    {
        Task<bool> RegisterAsync(Buyer obj);
        Task<Buyer> Login(Buyer buyer);
        Task LogOut(string buyerid);

        Task<Buyer> GetBuyerByIdAsync(string BuyerId);
        Task<IEnumerable<Buyer>> GetAllBuyers();

        Task<bool> AddProductsToCart(IList<Products> products);
        Task<IEnumerable<Products>> GetItemfromCart(string buyerId);
        Task<bool> DeleteProductFromCart(List<Products> products, string BuyerId);
        Task<IEnumerable<Products>> ViewProductsInCart(string buyerId);
        Task<IEnumerable<Products>> PlaceOrder(List<Products> product, Buyer buyer);
        Task<IEnumerable<PurchasedHistory>> ViewHistoryOfPurchace(string buyerId);
        Task<bool> PaymentGate(string ProductsId, string buyerId);

        Task<Products> DetailsOfProduct(string productId);
        Task<IEnumerable<Products>> FilterProduct(string ProductName, string CategoryName, int Price, string Manufacturer);
        Task<IEnumerable<Products>> GetAllProducts();
        Task<IEnumerable<Products>> SearchProduct(string ProductName, string CategoryName, string SubCategoryName);
    }
}
