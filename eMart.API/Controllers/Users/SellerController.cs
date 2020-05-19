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
    public class SellerController : ApiBaseController
    { 
        private readonly ISellerRepository _service;

        public SellerController(ISellerRepository service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("AddProducts")]
        public async Task<IActionResult> AddProducts(Products obj)
        {
            //Do code here
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("AddProductsStock")]

        public async Task<IActionResult> AddProductsStock(IList<Products> product, int Stock)
        {
            //Do code here
            throw new NotImplementedException();
        }



        [HttpPost]
        [Route("CreateReport")]
        public async Task<IActionResult> CreateReport(Stock stock, DateTime fromDate, DateTime toDate)
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
        [Route("GetAllSellers")]
        public Task<IActionResult> GetAllSellers()
        {
            //Do code here
            throw new NotImplementedException();
        }



        [HttpGet]
        [Route("GetProductsbyId")]
        public Task<IActionResult> GetProductsbyId(string productsId)
        {
            //Do code here
            throw new NotImplementedException();
        }


        [HttpGet]
        [Route("GetSellersById")]
        public Task<IActionResult> GetSellersById(string SellerId)
        {
            //Do code here
            throw new NotImplementedException();
        }



        [HttpPost]
        [Route("Login")]
        public Task<IActionResult> Login(Seller Seller)
        {
            //Do code here
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("LogOut")]
        public Task<IActionResult> LogOut(string sellerid)
        {
            //Do code here
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("Register")]
        public Task<IActionResult> Register(Seller obj)
        {
            //Do code here
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("TaxCalculation")]
        public Task<IActionResult> TaxCalculation()
        {
            //Do code here
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("ViewSalesInventory")]
        public Task<IActionResult> ViewSalesInventory(int SellerId)
        { 
            //Do code here
            throw new NotImplementedException();
        }
    }
}