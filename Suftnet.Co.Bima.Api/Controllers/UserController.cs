namespace Suftnet.Co.Bima.Api.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Suftnet.Co.Bima.Api.Extensions;   
    using Suftnet.Co.Bima.Api.Models;
    using Suftnet.Co.Bima.Common;
    using Suftnet.Co.Bima.DataAccess.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
      
        public UserController(UserManager<ApplicationUser> userManager,
            IMapper mapper,
           IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;            
        }

        [HttpGet]
        [Route("ping")]
        public async Task<IActionResult> Ping()
        {
            return Ok(await Task.Run(() => DateTime.UtcNow));
        }

        [HttpGet]
        [Route("list")]
        public IActionResult Fetch()
        {
            var users = _userManager.Users;
            var model = _mapper.Map<List<UserModel>>(users);
            return Ok(model);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateCustomer model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Errors());
            }

            var email = await _userManager.FindByEmailAsync(model.Email);

            if (email != null)
            {
                return new BadRequestObjectResult(ModelStateError.AddErrorToModelState("401", "A match found for your email address, please try another email", ModelState));
            }
           
            var identity = _mapper.Map<ApplicationUser>(model);

            var result = await _userManager.CreateAsync(identity, model.Password);

            if (!result.Succeeded)
            {
                return new BadRequestObjectResult(ModelStateError.AddErrorsToModelState(result, ModelState));
            }
            
            return new OkObjectResult(true);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody]UpdateCustomer model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Errors());
            }

            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                return BadRequest(ValidationError.USER_NOT_FOUND);
            }        

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return new BadRequestObjectResult(ModelStateError.AddErrorsToModelState(result, ModelState));
            }

            return new OkObjectResult(true);
        }

        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> Remove([FromBody] RemoveCustomer model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Errors());
            }

            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                return BadRequest(ValidationError.USER_NOT_FOUND);
            }

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                return new BadRequestObjectResult(ModelStateError.AddErrorsToModelState(result, ModelState));
            }

            return new OkObjectResult(true);
        }

        [HttpPost]
        [Route("resetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetCustomerPassword model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Errors());
            }

            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                return BadRequest(ValidationError.USER_NOT_FOUND);
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            if (string.IsNullOrEmpty(token))
            {
                return BadRequest(ValidationError.PASSWORD_RESET);
            }

            var result = await _userManager.ResetPasswordAsync(user, token, model.Password);

            if (!result.Succeeded)
            {
                return new BadRequestObjectResult(ModelStateError.AddErrorsToModelState(result, ModelState));
            }

            return new OkObjectResult(true);
        }
        
    }
}
