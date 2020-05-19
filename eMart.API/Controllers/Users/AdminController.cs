using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMart.API.Controllers.Base;
using eMart.BusinessLayer.Interfaces;
using eMart.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eMart.API.Controllers.Users
{
  
    public class AdminController : ApiBaseController
    {
        private readonly IAdminRepository _service;

        public AdminController(IAdminRepository service)
        {
            _service = service;
        }


        [HttpPost]
        [Route("AddCategories")]
        public async Task<IActionResult> AddCategories(Category category)
        {
            //Do code here
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("AddDiscounts")]
        public async Task<IActionResult> AddDiscounts(Discounts discount)
        {
            //Do code here
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("AddSubCategory")]
        public async Task<IActionResult> AddSubCategory(SubCategory subcategory)
        {
            //Do code here
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("BlockAndUnblockSpecificBuyer")]
        public async Task<IActionResult> BlockAndUnblockSpecificBuyer(string buyerId)
        {
            //Do code here
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("BlockAndUnblockSpecificProduct")]
        public async Task<IActionResult> BlockAndUnblockSpecificProduct(string productId)
        {
            //Do code here
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("BlockAndUnblockSpecificSeller")]

        public async Task<IActionResult> BlockAndUnblockSpecificSeller(string sellerId)
        {
            //Do code here
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("UpdateDiscountsDiscounts")]
        public async Task<IActionResult> UpdateDiscountsDiscounts(Discounts discount)
        {
            //Do code here
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("ViewDailyTurnOverCategoryWise")]
        public async Task<IActionResult> ViewDailyTurnOverCategoryWise(Category category)
        {
            //Do code here
            throw new NotImplementedException();
        }
    }
}