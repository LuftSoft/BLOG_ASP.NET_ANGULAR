using BlogAppAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Utilities;

namespace BlogAppAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/post/[action]")]
    public class PostController : ControllerBase
    {
        private MyDbContext context;

        public PostController(MyDbContext context) {
            this.context = context;
        }
        //can sua cho nay`
        [HttpGet(Name = "")]
        public async Task<IActionResult> list(string page)
        {
            int page_size = 10;
            try
            {
                var listPost = (from post in context.Posts select post).ToList();
                var Page_num = (int)Math.Ceiling((double)listPost.Count / 10);
                if (string.IsNullOrEmpty(page))
                {
                    return Ok(listPost.Take(page_size));
                }
                var pageInt = Int32.Parse(page);
                if(pageInt>=0 && pageInt<=Page_num)
                {
                    var relsult = listPost.Skip(page_size * pageInt).Take(page_size);
                    return Ok(relsult);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> detail (string slug) {
            try
            {   
                var post = (from p in context.Posts
                            where p.PostSlug == slug
                            select p).FirstOrDefault();
                if(post != null)
                {
                    return Ok(post);
                }
                return BadRequest();
            }   
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/api/v1/post/detail_pathvariable/{slug}")]
        public async Task<IActionResult> detail_pathvariable(string slug)
        {
            try
            {
                var post = (from p in context.Posts
                            where p.PostSlug == slug
                            select p).FirstOrDefault();
                if (post != null)
                {
                    return Ok(post);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> create (Post post) {
            try
            {
                var author = context.Authors.FirstOrDefault(a=>a.AuthorId == post.AuthorId);
                post.Author = author;
                var rel = await context.Posts.AddAsync(post);
                await context.SaveChangesAsync();
                return Ok(rel.State);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> delete(Post post)
        {
            try
            {
                var rel = context.Posts.Remove(post);
                await context.SaveChangesAsync();
                return Ok(rel.State);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> edit(Post post)
        {
            try
            {
                var p = context.Posts.FirstOrDefault(p => p.PostId == post.PostId);
                if(p != null)
                {
                    p.UpdateDate = DateTime.Now;
                    p.PostContent = post.PostContent;
                    p.PostDescription = post.PostDescription;
                    p.PostSlug = post.PostSlug;
                    context.Posts.Update(p);
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
    }
}
