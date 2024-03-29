﻿using BlogAppAPI.Models;
using BlogAppAPI.Services.Payload;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppAPI.Controllers
{
    [Route("api/v1/user/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<CustomUser> userManager;
        private MyDbContext context;

        public UserController(UserManager<CustomUser> userManager, MyDbContext context) {
            this.userManager = userManager;
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> userrole(string userid)
        {
            var user = await userManager.FindByNameAsync(userid);
            if (user == null)
            {
                return BadRequest("can't find user");
            }
            var roles = (from r in context.UserRoles
                         where r.UserId == userid
                         select r).ToArray();
            return Ok(roles);
        }
        [HttpGet]
        public async Task<IActionResult> list(int page)
        {
            int page_size = 10;
            var users = context.Users.ToList();
            int page_count = (int)Math.Ceiling((double)users.Count/page_size);
            if(page<=page_count && page >= 0)
            {   
                var rel = users.Skip(page*page_size).Take(page_size);
                return Ok(new APIResponse()
                {
                    Success = true,
                    Payload = new { rel = rel, page_total = page_count },
                    StatusCode = System.Net.HttpStatusCode.OK
                });
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("/api/v1/user/detail/{id}")]
        public async Task<IActionResult> dedtail(string id)
        {
            try
            {
                var user = await context.Users.FindAsync(id);
                if (user != null) return Ok(new APIResponse() { 
                    Success = true,
                    Payload = new
                    {
                        userName = user.UserName,
                        email = user.Email,
                        phoneNumber = user.PhoneNumber,
                        userAdress = user.UserAdress
                    },
                    StatusCode = System.Net.HttpStatusCode.OK
                });
                return BadRequest(new APIResponse()
                {
                    Success = false,
                    Message = "get user failed",
                    StatusCode = System.Net.HttpStatusCode.NotFound
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse()
                {
                    Success = false,
                    Message = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                });
            }
        }
        /*[HttpGet]
        [Route("/api/v1/user/list")]
        public async Task<IActionResult> list_with_no()
        {   
            try
            {
                int page_size = 10;
                return Ok(context.Users.Take(page_size).ToList());
            }
            catch (Exception ex) {return BadRequest();}
        }
        */
        [HttpDelete]
        public async Task<IActionResult> delete(string userId)
        {
            var user = await context.Users.FindAsync(userId);
            if(user != null)
            {
                
            }
            return Ok();
        }
    }
}
