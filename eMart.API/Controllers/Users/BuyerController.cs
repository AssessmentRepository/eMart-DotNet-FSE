using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMart.API.Controllers.Base;
using eMart.BusinessLayer;
using eMart.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eMart.API.Controllers.Users
{

    public class BuyerController : ApiBaseController
    { 
        private readonly IBuyerRepository _service;


        public BuyerController(IBuyerRepository service)
        {
            _service = service;
        }

        //Do code here


        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            //Do code here
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            //Do code here
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("AddProductsToCart")]
        public async Task<IActionResult> AddProductsToCart(IList<Products> products)
        {
            //Do code here
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("DeleteProductFromCart")]
        public async Task<IActionResult> DeleteProductFromCart(List<Products> products, string BuyerId)
        {
            //Do code here
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("DetailsOfProduct")]
        public async Task<IActionResult> DetailsOfProduct(string productId)
        {
            //Do code here
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("FilterProduct")]
        public async Task<IActionResult> FilterProduct(string ProductName, string CategoryName, int Price, string Manufacturer)
        {
            //Do code here
            throw new NotImplementedException();
        }


        [HttpGet]
        [Route("GetAllBuyers")]
        public async Task<IActionResult> GetAllBuyers()
        {
            //Do code here
            throw new NotImplementedException();
        }


        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            //Do code here
            throw new NotImplementedException();
        }


        [HttpGet]
        [Route("GetBuyerById")]

        public async Task<IActionResult> GetBuyerById(string BuyerId)
        {
            //Do code here
            throw new NotImplementedException();
        }


        [HttpGet]
        [Route("GetItemfromCart")]
        public async Task<IActionResult> GetItemfromCart(string buyerId)
        {
            //Do code here
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(Buyer buyer)
        {
            //Do code here
            throw new NotImplementedException();
        }


        [HttpPost]
        [Route("LogOut")]

        public async Task<IActionResult> LogOut(string buyerid)
        {
            //Do code here
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("PaymentGate")]
        public async Task<IActionResult> PaymentGate(string ProductsId, string buyerId)
        {
            //Do code here
            throw new NotImplementedException();
        }


        [HttpPost]
        [Route("PlaceOrder")]
        public async Task<IActionResult> PlaceOrder(List<Products> product)
        {
            //Do code here
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("RegisterAsync")]
        public async Task<IActionResult> RegisterAsync(Buyer obj)
        {
            //Do code here
            throw new NotImplementedException();
        }


        [HttpGet]
        [Route("SearchProduct")]
        public async Task<IActionResult> SearchProduct(string ProductName, string CategoryName, string SubCategoryName)
        {
            //Do code here
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("ViewHistoryOfPurchace")]
        public async Task<IActionResult> ViewHistoryOfPurchace(string buyerId)
        {
            //Do code here
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("ViewProductsInCart")]
        public async Task<IActionResult> ViewProductsInCart(string buyerId)
        {
            //Do code here
            throw new NotImplementedException();
        }

    }
}