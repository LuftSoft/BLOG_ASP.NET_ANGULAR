using BlogAppAPI.Models.Auth;
using Microsoft.AspNetCore.Identity;

namespace BlogAppAPI.Repository.Auth
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignupAsync(SignupModel model);
        public Task<object> SigninAsync(SigninModel model);
    }
}
