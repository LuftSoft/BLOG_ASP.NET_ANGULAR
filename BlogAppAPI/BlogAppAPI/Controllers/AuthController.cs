using BlogAppAPI.Models.Auth;
using BlogAppAPI.Repository.Auth;
using BlogAppAPI.Services.Payload;
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
            try
            {
                var rel = await accountRepository.SigninAsync(signinModel);
                if (rel == null)
                {
                    return BadRequest(new APIResponse() 
                    { Success = false,
                      Message = "Incorrect username or password",
                      StatusCode = System.Net.HttpStatusCode.NotFound
                    });
                }
                return Ok(new APIResponse()
                {
                    Success = true,
                    Message = "Login success",
                    Payload = rel,
                    StatusCode = System.Net.HttpStatusCode.OK
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new APIResponse()
                {
                    Success = false,
                    Message = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                });
            }
        }
    }
}
