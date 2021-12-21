﻿using Microsoft.AspNetCore.Mvc;
using WebApiExample.Business.Action;
using WebApiExample.Shared.DTO.Request;
using WebApiExample.Shared.DTO.Response;

namespace WebApiExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IActionUsers _actionUser;

        public UserController(IActionUsers actionUser)
        {
            _actionUser = actionUser;
        }

        [HttpGet("users")]
        public async Task<List<UserResponse>> Get()
        {
            var response = await _actionUser.GetAllUsersAsync();
            return response.Select(x => (UserResponse)x).ToList();
        }

        [HttpPost("insertar-user")]
        public async Task<bool> InsertUser(UserRequest userRequest)
        {
            return await _actionUser.InsertUser(userRequest);
        }
    }
}