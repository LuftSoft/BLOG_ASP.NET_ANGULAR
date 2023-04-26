using BlogAppAPI.Models;
using BlogAppAPI.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogAppAPI.Repository.Auth
{
    public class AccountRepository : IAccountRepository
    {
        private UserManager<CustomUser> userManager;
        private SignInManager<CustomUser> signinManager;
        private IConfiguration configuration;

        public AccountRepository(UserManager<CustomUser> userManager, IConfiguration configuration,
            SignInManager<CustomUser> signinManager) {
            this.userManager = userManager;
            this.signinManager = signinManager;
            this.configuration = configuration;
        }
        //dang nhap
        public async Task<object?> SigninAsync(SigninModel model)
        {
            var rel = await signinManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            

            if (!rel.Succeeded)
            {
                return null;
            }
            //tim role cua user
            var userRole = await userManager.FindByEmailAsync(model.Email);
            var listRole = await userManager.GetRolesAsync(userRole);
            var authClaim = new List<Claim> { 
                new Claim(ClaimTypes.Email,model.Email),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            //them role user vao claim
            foreach (var role in listRole)
            {
                authClaim.Add(new Claim(ClaimTypes.Role,role));
            }
            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:IssuerSigningKey"]));
            var token = new JwtSecurityToken(
                issuer : configuration["JWT:ValidIssuer"],
                audience : configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(60),
                claims:authClaim,
                signingCredentials: new SigningCredentials(authKey,SecurityAlgorithms.HmacSha512)
                );
            return new {token = new JwtSecurityTokenHandler().WriteToken(token), user = new { userName = userRole.UserName, userId = userRole.Id } };
        }

        //dang ky
        public async Task<IdentityResult> SignupAsync(SignupModel model)
        {
            var user = new CustomUser
            {   
                UserName = model.Email,
                Email = model.Email,
                UserAdress = model.Address
            };
            return await userManager.CreateAsync(user, model.Password);
        }
    }
}
