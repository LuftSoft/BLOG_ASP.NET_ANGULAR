using BlogAppAPI.Models;
using BlogAppAPI.Services.ControllerService;
using BlogAppAPI.Services.Payload;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Org.BouncyCastle.Ocsp;
using Org.BouncyCastle.Utilities;
using System.Net;

namespace BlogAppAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/post/[action]")]
    public class PostController : ControllerBase
    {
        private readonly MyDbContext context;
        private readonly IPostService postService;

        public PostController(MyDbContext context, IPostService _postService) {
            this.context = context;
            this.postService = _postService;
        }
        //can sua cho nay`
        [HttpGet]
        public async Task<IActionResult> list(string page)
        {   
            var result = await this.postService.list(page);
            if(result.Success){return Ok(result);}
            else{return BadRequest(result);}
        }
        //
        [HttpGet]
        [Route("/api/v1/post/{category}")]
        public async Task<IActionResult> find_by_category(string category, int page) {
            var result = await this.postService.find_by_category(category, page);
            if(result.Success)  { return Ok(result); }
            else  { return BadRequest(result); }
        }
        [HttpGet]
        public async Task<IActionResult> search(string keyword, int page)
        {
            var result = await this.postService.search(keyword, page);
            if(result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> detail (string slug) {
            var result = await this.postService.detail(slug);
            if (result.Success) { return Ok(result); }
            else { return BadRequest(result); }
        }

        [HttpGet]
        [Route("/api/v1/post/detail_pathvariable/{slug}")]
        public async Task<IActionResult> detail_pathvariable(string slug)
        {
            var result = await this.postService.detail_pathvariable(slug);
            if (result.Success) { return Ok(result); }
            else { return BadRequest(result); }
        }
        [HttpPost]
        public async Task<IActionResult> create (Post post) {
            var result = await this.postService.create(post);
            if (result.Success) { return Ok(result); }
            else { return BadRequest(result); }
        }

        [HttpDelete]
        public async Task<IActionResult> delete(Post post)
        {
            var result = await this.postService.delete(post);
            if (result.Success) { return Ok(result); }
            else { return BadRequest(result); }
        }

        [HttpPut]
        public async Task<IActionResult> edit(Post post)
        {
            var result = await this.postService.edit(post);
            if (result.Success) { return Ok(result); }
            else { return BadRequest(result); }
        }
    }
}
