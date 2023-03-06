using BlogAppAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BlogAppAPI.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet(Name = "index")]
        public object getHome(HttpContext context)
        {   
            context.Response.ContentType = "application/json";
            return new
            {
                message = "home page",
                status = context.Response.StatusCode
            };
        }
        [HttpGet(Name ="index/:id")]
        public Tag getTag(string id)
        {
            return new Tag() { TagId = 1,TagName="Lap trinh voi java"};
        }
    }
}
