using BlogAppAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlogAppAPI.Controllers
{
    [Route("api/v1/author/[action]")]
    
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private MyDbContext context;

        public AuthorController(MyDbContext context) { this.context = context; }
        [HttpGet]
        public async Task<IActionResult> detail(string slug) {
            try
            {
                var rel = context.Authors.FirstOrDefault(a=>a.AuthorSlug.Equals(slug));
                if(rel != null)
                {
                    return Ok(rel);
                }
                return BadRequest(StatusCode(404));
            }catch(Exception ex)
            {   
                return BadRequest(ex.Message);
            }
        }
        [HttpGet(Name = "author/{url}")]
        public Author GetAuthorByUrl(string authorUrl)
        {
            return new Author()
            {
                AuthorId = 1,
                AuthorName = "author name",
                AuthorEmail = "author@gmail.com"
            };
        }
        [HttpPost]
        public async Task<IActionResult> create(Author author) {
            try
            {
                var cus = context.Users.FirstOrDefault(u=>u.Id == author.CustomUserId);
                author.CustomUser = cus;
                var rel = this.context.Authors.Add(author);
                await this.context.SaveChangesAsync();
                return Ok(author);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> edit(Author author)
        {
            try
            {
                var a = context.Authors.FirstOrDefault(a=>a.AuthorId == author.AuthorId);
                if (a != null)
                {
                    a = author;
                    context.Authors.Update(a);
                    await context.SaveChangesAsync();
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> delete() {
            try
            {
                
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
