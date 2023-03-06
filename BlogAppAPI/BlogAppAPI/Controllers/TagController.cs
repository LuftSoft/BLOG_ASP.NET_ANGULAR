using BlogAppAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppAPI.Controllers
{
    [Route("api/v1/tag/[action]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private MyDbContext context;

        public TagController(MyDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        //[Authorize(Roles = "MODERATOR,ADMIN")]
        public async Task<IActionResult> list(string page)
        {
            int page_size = 10;
            try
            {
                var listTag = (from tag in context.Tags select tag).ToList();
                var Page_num = (int)Math.Ceiling((double)listTag.Count / 10);
                if (string.IsNullOrEmpty(page))
                {
                    return Ok(listTag.Take(page_size));
                }
                var pageInt = Int32.Parse(page);
                if (pageInt >= 0 && pageInt <= Page_num)
                {
                    var relsult = listTag.Skip(page_size * pageInt).Take(page_size);
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
        public async Task<IActionResult> detail(int id)
        {
            try
            {
                var tag = (from p in context.Tags
                            where p.TagId == id
                            select p).FirstOrDefault();
                if (tag != null)
                {
                    return Ok(tag);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> create(Tag tag)
        {
            try
            {
                var rel = await context.Tags.AddAsync(tag);
                await context.SaveChangesAsync();
                return Ok(rel.State);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> delete(Tag tag)
        {
            try
            {   
                var del = context.Tags.FirstOrDefault(t=>t.TagId == tag.TagId);
                var rel = context.Tags.Remove(del);
                await context.SaveChangesAsync();
                return Ok(rel.State);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> edit(Tag tag)
        {
            try
            {
                var p = context.Tags.FirstOrDefault(p => p.TagId == tag.TagId);
                if (p != null)
                {
                    p.TagName = tag.TagName;
                    p.TagDescription = tag.TagDescription;
                    context.Tags.Update(p);
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
