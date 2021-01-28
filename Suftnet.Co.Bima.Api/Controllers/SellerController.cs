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
    using Suftnet.Co.Bima.Core;
    using Microsoft.Extensions.Logging;

    [Route("api/[controller]")]
    public class SellerController : BaseController

    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IRepository<Seller> _seller;
        private readonly IJwtFactory _jwtFactory;
        private readonly IUnitOfWork _unitOfWork;

        public SellerController(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork,
            IMapper mapper, IRepository<Seller> seller, IJwtFactory jwtFactory,
           IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;
            _seller = seller;
            _jwtFactory = jwtFactory;
            _unitOfWork = unitOfWork;
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
            var sellers = await _seller.AllIncludingAsync();
            var model = _mapper.Map<List<SellerDto>>(sellers);

            return Ok(model);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody]CreateSeller model)
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
            user.Id = Guid.NewGuid().ToString();
            user.UserType = UserType.SELLER;
            user.CreatedAt = DateTime.UtcNow;
            user.IsEnabled = model.Active;
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new { message = ModelStateError.AddErrorsToModelState(result, ModelState) });
            }

            var seller = _mapper.Map<Seller>(model);

            seller.Id = Guid.NewGuid();
            seller.UserId = user.Id;
            seller.CreatedAt = DateTime.UtcNow;
            seller.CreatedBy = model.Email;

           _seller.Add(seller);
           _unitOfWork.SaveChanges();

            var jwt = await _jwtFactory.GenerateEncodedToken(model.Email, _jwtFactory.GenerateClaimsIdentity(user));

            var _model = new
            {
                user = new
                {
                    id = user.Id,
                    userName = user.FullName,
                    userType = user.UserType,
                    token = jwt
                }
            };

            return new OkObjectResult(_model);
        }

    }
}
