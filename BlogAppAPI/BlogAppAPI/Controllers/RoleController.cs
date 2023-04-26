using BlogAppAPI.Models;
using BlogAppAPI.Services.Payload;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Ocsp;

namespace BlogAppAPI.Controllers
{
    [Route("api/v1/role/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private MyDbContext context;

        public  RoleController(MyDbContext context) { 
            this.context = context;
        }

       /* [HttpGet]
        [Route("/api/v1/role/list")]
        public async Task<IActionResult> listDefault()
        {
            return Ok(context.Roles.Take(10).ToList());
        }
       */
        [HttpGet]
        public async Task<IActionResult> list(int page) {
            int page_size = 10;
            //lay tat ca caca role
            var roles = context.Roles.ToList();
            int page_count = (int)Math.Ceiling((double)roles.Count / page_size);
            if (page <= page_count && page >= 0)
            {
                var rel = roles.Skip(page * page_size).Take(page_size);
                return Ok(new APIResponse() 
                { 
                    Success = true,
                    Payload = new {rel = rel, page_total = page_count}
                });
            }
            return BadRequest(new APIResponse()
            {
                Success = false,
                Message = "get list role failed"
            });
        }
        [HttpPost]
        public async Task<IActionResult> create(IdentityRole role)
        {   
            var rel = context.Roles.AddAsync(role);
            if(rel.IsCompletedSuccessfully)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> edit(IdentityRole role )
        {
            try
            {
                var r = await context.Roles.FindAsync(role.Id);
                r.Name = role.Name;
                r.NormalizedName = role.NormalizedName;
                r.ConcurrencyStamp = role.ConcurrencyStamp;
                var rel = context.Roles.Update(r);
                return Ok(rel.State);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> delete()
        {   
            return Ok();
        }

    }
}
