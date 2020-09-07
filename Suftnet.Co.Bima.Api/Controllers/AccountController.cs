namespace EventHub.Api.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Suftnet.Co.Bima.Api.Extensions;
    using Suftnet.Co.Bima.Api.Infrastructure;
    using Suftnet.Co.Bima.Api.Models;
    using Suftnet.Co.Bima.Common;
    using Suftnet.Co.Bima.DataAccess.Identity;

    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class AccountController : Controller
    {       
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtFactory _jwtFactory;
      
        public AccountController(UserManager<ApplicationUser> userManager, IJwtFactory jwtFactory)
        {
            _userManager = userManager;      
            _jwtFactory = jwtFactory;          
        }

        [HttpGet]
        [Route("ping")]
        public async Task<IActionResult> Ping()
        {
            return Ok(await Task.Run(() => DateTime.UtcNow));
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {                
                return BadRequest(new { message = ModelState.Errors() });
            }

            var user = await _userManager.FindByNameAsync(loginModel.UserName);

            var identity = await GetClaimsIdentity(loginModel.UserName, loginModel.Password, user);
            if (identity == null)
            {
                return BadRequest(new { message = ValidationError.PASSWORD_OR_USERNAME });
            }

            var jwt = await _jwtFactory.GenerateEncodedToken(loginModel.UserName, identity);
            var model = new { 
                user = new
                {
                    userName = user.FullName,
                    userType= user.UserType,
                    jwt = jwt
                }            
            };
            return new OkObjectResult(model);
        }

        #region private 
        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password, ApplicationUser user)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);                      
                      
            if (user == null) return await Task.FromResult<ClaimsIdentity>(null);
                        
            if (await _userManager.CheckPasswordAsync(user, password))
            {
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(user));
            }
           
            return await Task.FromResult<ClaimsIdentity>(null);
        }
       
        #endregion
    }
}
