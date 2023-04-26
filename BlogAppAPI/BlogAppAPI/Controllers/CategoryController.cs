using BlogAppAPI.Models;
using BlogAppAPI.Services.Payload;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Ocsp;

namespace BlogAppAPI.Controllers
{
    [Route("api/v1/category/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private MyDbContext context;

        public CategoryController(MyDbContext contex) {
            this.context = contex;
        }
        [HttpGet]
        public async Task<IActionResult> list(string? page)
        {   
            var pageNumber = 10;
            try
            {   
                var pageInt = Int32.Parse(page);
                var listCate = context.Categories.ToList();
                var totalPage =(int) Math.Ceiling((double) listCate.Count / pageNumber);
                if (pageInt >= 0 && pageInt <= totalPage)
                {
                    var rel = listCate.Skip(pageNumber* pageInt).Take(pageNumber).ToList();
                    return Ok(new APIResponse()
                    {
                        Success = true,
                        Payload = new { rel = rel, page_total = totalPage }
                    });
                }
                return BadRequest(new APIResponse()
                {
                    Success = true,
                    Message = "can't get list category"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(
                        new APIResponse()
                        {
                            Success = true,
                            Message = ex.Message
                        }
                    );
            }
        }

        [HttpGet]
        public async Task<IActionResult> detail(string slug)
        {
            try
            {
                var cate = context.Categories.FirstOrDefault(p=>p.CategorySlug.Equals(slug));
                if (cate == null) return BadRequest(StatusCode(404));
                return Ok(cate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> create(Category category)
        {   
            try
            {
                Console.WriteLine($"{category.Name} - {category.Description} - {category.CategorySlug}");
                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();
                return Ok(new APIResponse() {
                    Success = true,
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Message = "add category success!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Message = ex.Message
                });
            }
        }
        [HttpDelete]
        public async Task<IActionResult> delete(Category category)
        {
            try
            {
                var rel = context.Categories.Remove(category);
                await context.SaveChangesAsync();
                return Ok(rel.State);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> edit(Category category)
        {
            try
            {
                var c = context.Categories.FirstOrDefault(p => p.CategoryId == category.CategoryId);
                if (c != null)
                {
                    c = category;
                    context.Categories.Update(c);
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
