namespace Suftnet.Co.Bima.Api.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Suftnet.Co.Bima.Api.Extensions;
    using Suftnet.Co.Bima.Api.Infrastructure;
    using Suftnet.Co.Bima.Api.Models;
    using Suftnet.Co.Bima.Common;
    using Suftnet.Co.Bima.DataAccess.Identity;
    using Suftnet.Co.Bima.DataAccess.Interface;
    using Suftnet.Co.Bima.DataAccess.Actions;

    using System;  
    using System.Threading.Tasks;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    public class BuyerController : BaseController

    {       
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IRepository<Buyer> _buyer;   
        private readonly IJwtFactory _jwtFactory;

        public BuyerController(UserManager<ApplicationUser> userManager,
            IMapper mapper, IRepository<Buyer> buyer, IJwtFactory jwtFactory,           
           IHttpContextAccessor httpContextAccessor) :base(httpContextAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;
            _buyer = buyer;         
            _jwtFactory = jwtFactory;
        }

        [HttpGet]
        [Route("ping")]
        public async Task<IActionResult> Ping()
        {
            return Ok(await Task.Run(() => DateTime.UtcNow));
        }

        [HttpGet]
        [Route("fetch")]
        public async Task<IActionResult> Fetch()
        {
            var buyers = await _buyer.AllIncludingAsync(x=>x.Company);
            var model = _mapper.Map<List<BuyerDto>>(buyers);

            return Ok(model);
        }

        [HttpPost]       
        [Route("create")]
        public async Task<IActionResult> Create([FromBody]CreateBuyer model)
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
         
            var user = _mapper.Map<ApplicationUser>(model);
            user.Id = new System.Guid().ToString();
            user.UserType = UserType.BUYER;
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new { message = ModelStateError.AddErrorsToModelState(result, ModelState) });               
            }         

            var buyer = _mapper.Map<Buyer>(model);
          
            buyer.Id = new Guid();           
            buyer.UserId = user.Id;
            buyer.CreatedAt = DateTime.UtcNow;
            buyer.CreatedBy = model.Email;

           _buyer.Add(buyer);

            var jwt = await _jwtFactory.GenerateEncodedToken(model.Email, _jwtFactory.GenerateClaimsIdentity(user));

            return new OkObjectResult(new { token = jwt, userName = model.FirstName +" " + model.LastName });
        }
       
    }
}
