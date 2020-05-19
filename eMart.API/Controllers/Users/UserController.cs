using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMart.API.Controllers.Base;
using eMart.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eMart.Entities.Entities;

namespace eMart.API.Controllers.Users
{
    public class UserController : ApiBaseController
    {
        private readonly IUserRepository _service;

        public UserController(IUserRepository service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(User user)
        {
            return Ok(await _service.Register(user));
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(User credentials)
        {
            return Ok(await _service.Login(credentials));
        }

        [HttpGet]

        // [Route("api/user")]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _service.GetById(id));
        }
    }
}