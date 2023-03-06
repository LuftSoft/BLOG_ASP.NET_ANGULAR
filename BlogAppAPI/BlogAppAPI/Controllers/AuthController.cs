using BlogAppAPI.Models.Auth;
using BlogAppAPI.Repository.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BlogAppAPI.Controllers
{
    [Route("api/v1/auth/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAccountRepository accountRepository;

        public AuthController(IAccountRepository repos) { 
            this.accountRepository = repos;
        } 

        [HttpPost(Name = "signup")]
        public async Task<IActionResult> signup(SignupModel signupModel)
        {
            var rel = await accountRepository.SignupAsync(signupModel);
            if (rel.Succeeded)
            {
                return Ok(rel.Succeeded);
            }
            return Unauthorized();
        }
        [HttpPost(Name = "signin")]
        public async Task<IActionResult> signin(SigninModel signinModel)
        {
            var rel = await accountRepository.SigninAsync(signinModel);
            if (string.IsNullOrEmpty(rel))
            {
                return BadRequest();
            }
            return Ok(rel);
        }
    }
}
