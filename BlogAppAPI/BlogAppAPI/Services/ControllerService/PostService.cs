using BlogAppAPI.Models;
using BlogAppAPI.Services.Payload;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogAppAPI.Services.ControllerService
{
    public class PostService : IPostService
    {   
        private readonly MyDbContext context;
        private readonly int page_size = 10;
        public PostService(MyDbContext _context) {
            this.context = _context;
        } 
        public async Task<APIResponse> create(Post post)
        {
            try
            {
                var author = context.Authors.FirstOrDefault(a => a.AuthorId == post.AuthorId);
                post.Author = author;
                var rel = await context.Posts.AddAsync(post);
                await context.SaveChangesAsync();
                return new APIResponse()
                {
                    Success = true,
                    Message = "create post success",
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return 
                    new APIResponse()
                    {
                        Success = false,
                        Message = ex.Message,
                        StatusCode = System.Net.HttpStatusCode.NoContent
                    };
            }
        }

        public async Task<APIResponse> delete(Post post)
        {
            try
            {
                var rel = context.Posts.Remove(post);
                await context.SaveChangesAsync();
                return new APIResponse() { Success = true, Message = "delete success" };
            }
            catch (Exception ex)
            {
                return new APIResponse() { Success = false, Message = ex.Message };
            }
        }

        public async Task<APIResponse> detail(string slug)
        {
            try
            {
                var post = (from p in context.Posts
                            where p.PostSlug == slug
                            select p).FirstOrDefault();
                if (post != null)
                {
                    return new APIResponse(){   Success = true,Payload = post,StatusCode = System.Net.HttpStatusCode.OK};
                }
                return new APIResponse(){Success = false,};
            }
            catch (Exception ex)
            {
                return new APIResponse(){Success = false,Message = ex.Message};
            }
        }

        public async Task<APIResponse> detail_pathvariable(string slug)
        {
            try
            {
                var post = (from p in context.Posts
                            where p.PostSlug == slug
                            select p).FirstOrDefault();
                if (post != null)
                {
                    return new APIResponse() { Success = true, Payload = post };
                }
                return new APIResponse() { Success = false };
            }
            catch (Exception ex)
            {
                return new APIResponse() { Success = false, Message = ex.Message };
            }
        }

        public async Task<APIResponse> edit(Post post)
        {
            try
            {
                var p = context.Posts.FirstOrDefault(p => p.PostId == post.PostId);
                if (p != null)
                {
                    p.UpdateDate = DateTime.Now;
                    p.PostContent = post.PostContent;
                    p.PostDescription = post.PostDescription;
                    p.PostSlug = post.PostSlug;
                    //context.Posts.Update(p);
                    await context.SaveChangesAsync();
                    return new APIResponse() { Success = true, Message = "edit post success!" };
                }
                return  new APIResponse() { Success = false, Message = "edit post failed!" };
            }
            catch (Exception ex)
            {
                return new APIResponse() { Success = false, Message = ex.Message };
            }
        }

        public async Task<APIResponse> find_by_category(string category, int page)
        {
            var cate = context.Categories.FirstOrDefault(c => c.CategorySlug == category);
            if (cate == null)
            {
                return new APIResponse()
                {
                    Message = "not found",
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
            }
            var posts = (from p in context.Posts
                         join
                        pc in context.PostCategories on p.PostId equals pc.PostId
                         where pc.CategoryId == cate.CategoryId
                         select p);
            if (posts == null)
            {
                return new APIResponse()
                {
                    Message = "not found",
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
            }
            int page_total = posts.Count();
            int page_num = (int)(Math.Ceiling((double)page_total / page_size));
            if (page >= 0 && page <= page_num)
            {
                return new APIResponse()
                {
                    Success = true,
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Payload = new { rel = posts.Skip(page * page_size).Take(page_size), page_total = page_total }
                };
            }
            return new APIResponse() { Message = "not found", Success = false, StatusCode = System.Net.HttpStatusCode.NotFound };
        }

        
        public async Task<APIResponse> list(string page)
        {
            try
            {
                var listPost = (from post in context.Posts select post).ToList();
                var Page_num = (int)Math.Ceiling((double)listPost.Count / 10);
                if (string.IsNullOrEmpty(page))
                {
                    var result = listPost.Take(page_size);
                    foreach (var item in result)
                    {
                        await context.Entry(item)
                            .Reference(p => p.Author)
                            .LoadAsync();
                    }
                    return new APIResponse()
                        {Success = true,
                        Payload = new { rel = result, page_total = 1 },
                        StatusCode = System.Net.HttpStatusCode.OK};
                }
                var pageInt = Int32.Parse(page);
                if (pageInt >= 0 && pageInt <= Page_num)
                {
                    var relsult = listPost.Skip(page_size * pageInt).Take(page_size);
                    foreach (var item in relsult)
                    {
                        await context.Entry(item)
                               .Reference(p => p.Author)
                               .LoadAsync();
                    }
                    return new APIResponse()
                    {Success = true,
                     Payload = new { rel = relsult, page_total = Page_num },
                     StatusCode = System.Net.HttpStatusCode.OK};
                }
                return new APIResponse(){Success = false,Message = "get post failed"};
            }
            catch (Exception ex)
            {
                return new APIResponse() { Success = false, Message = ex.Message };
            }
        }

        public async Task<APIResponse> search(string keyword, int page)
        {
            var listPost = await context.Posts.Where(p => 
                Convert.ToString(p.PostTitle).ToUpper().Contains(keyword.ToUpper())
                || Convert.ToString(p.PostContent).ToUpper().Contains(keyword.ToUpper())
                || Convert.ToString(p.PostDescription).ToUpper().Contains(keyword.ToUpper()))    
                .ToListAsync();
            int page_num = (int)Math.Ceiling((double)listPost.Count / page_size);
            if(page>=0 && page <= page_num)
            {
                var result = listPost.Skip((int)page_size * page).Take(page_size);
                return new APIResponse()
                {
                    Success = true,
                    Message = "searching success",
                    Payload = result,
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            return new APIResponse() { 
                Success = false,
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Message = "searching failed"
            };
        }
    }
}
