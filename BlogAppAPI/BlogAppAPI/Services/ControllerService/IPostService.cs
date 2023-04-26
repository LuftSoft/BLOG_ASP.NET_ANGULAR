using BlogAppAPI.Models;
using BlogAppAPI.Services.Payload;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppAPI.Services.ControllerService
{
    public interface IPostService
    {
        public Task<APIResponse> list(string page);
        public Task<APIResponse> find_by_category(string category, int page);
        public Task<APIResponse> detail(string slug);
        public Task<APIResponse> detail_pathvariable(string slug);
        public Task<APIResponse> create(Post post);
        public Task<APIResponse> delete(Post post);
        public Task<APIResponse> edit(Post post);
        public Task<APIResponse> search(string keyword, int page);
    }
}
