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
        [Route("fetch")]
        public IActionResult Fetch()
        {
            var users = _userManager.Users;
            var model = _mapper.Map<List<UserDto>>(users);
            return Ok(model);
        }        

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody]CreateUser model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = ModelState.Errors() });
            }

            var email = await _userManager.FindByEmailAsync(model.Email);

            if (email != null)
            {
                return BadRequest(new { message = ModelStateError.AddErrorToModelState(StatusCodes.Status400BadRequest.ToString(), ValidationError.EMAIL_FOUND, ModelState) });
            }
           
            var identity = _mapper.Map<ApplicationUser>(model);

            var result = await _userManager.CreateAsync(identity, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new { message = ModelStateError.AddErrorsToModelState(result, ModelState) });
            }
            
            return new OkObjectResult(true);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUser model)
        {
            if (!ModelState.IsValid)
            {               
                return BadRequest(new { message = ModelState.Errors() });
            }

            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                return BadRequest(new { message = ValidationError.USER_NOT_FOUND });               
            }        

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {               
                return BadRequest(new { message = ModelStateError.AddErrorsToModelState(result, ModelState) });
            }

            return new OkObjectResult(true);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody]RemoveUser model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = ModelState.Errors() });
            }

            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                return BadRequest(new { message = ValidationError.USER_NOT_FOUND });
            }

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest(new { message = ModelStateError.AddErrorsToModelState(result, ModelState) });
            }

            return new OkObjectResult(true);
        }

        [HttpPost]
        [Route("reset")]
        public async Task<IActionResult> Reset([FromBody]ResetUserPassword model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = ModelState.Errors() });
            }

            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                return BadRequest(new { message = ValidationError.USER_NOT_FOUND });
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            if (string.IsNullOrEmpty(token))
            {
                return BadRequest(new { message = ValidationError.PASSWORD_RESET });             
            }

            var result = await _userManager.ResetPasswordAsync(user, token, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new { message = ModelStateError.AddErrorsToModelState(result, ModelState) });
            }

            return new OkObjectResult(true);
        }
        
    }
}
