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
    using Microsoft.AspNetCore.Authorization;

    [Route("api/[controller]")]
    public class BuyerController : BaseController

    {       
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IRepository<Buyer> _buyer;
        private readonly IRepository<Order> _order;
        private readonly IJwtFactory _jwtFactory;
        private readonly IUnitOfWork _unitOfWork;

        public BuyerController(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork,
            IMapper mapper, IRepository<Buyer> buyer, IJwtFactory jwtFactory, IRepository<Order> order,
           IHttpContextAccessor httpContextAccessor) :base(httpContextAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;
            _buyer = buyer;
            _order = order;
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
            var buyers = await _buyer.AllIncludingAsync();
            var model = _mapper.Map<List<BuyerDto>>(buyers);

            return Ok(model);
        }

        [Authorize()]
        [HttpGet]
        [Route("buyerPendingOrders")]
        public async Task<IActionResult> BuyerPendingOrders()
        {
            var orders = await _order.AllIncludingAsync(x => x.Buyer.UserId == this.UserId && x.OrderStatusId != new Guid(eOrderStatus.Completed), (x => x.Produce), (x => x.Produce.Unit), (x => x.OrderStatus), (x => x.Produce.Seller));
            var model = _mapper.Map<List<BuyerOrder>>(orders);

            return Ok(model);
        }

        [Authorize()]
        [HttpGet]
        [Route("buyerCompletedOrders")]
        public async Task<IActionResult> BuyerCompletedOrders()
        {
            var orders = await _order.AllIncludingAsync(x => x.Buyer.UserId == this.UserId && x.OrderStatusId == new Guid(eOrderStatus.Completed), (x => x.Produce), (x => x.Produce.Unit), (x => x.OrderStatus), (x => x.Produce.Seller));
            var model = _mapper.Map<List<BuyerOrder>>(orders);

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
            user.Id = Guid.NewGuid().ToString();
            user.UserType = UserType.BUYER;
            user.CreatedAt = DateTime.UtcNow;
            user.IsEnabled = model.Active;
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new { message = ModelStateError.AddErrorsToModelState(result, ModelState) });
            }

            var buyer = _mapper.Map<Buyer>(model);
          
            buyer.Id = Guid.NewGuid();           
            buyer.UserId = user.Id;
            buyer.CreatedAt = DateTime.UtcNow;
            buyer.CreatedBy = model.Email;

           _buyer.Add(buyer);
           _unitOfWork.SaveChanges();

            var jwt = await _jwtFactory.GenerateEncodedToken(model.Email, _jwtFactory.GenerateClaimsIdentity(user));

            var _model = new
            {
                id = user.Id,
                userName = user.FullName,
                userType = user.UserType,
                token = jwt
            };

            return new OkObjectResult(_model);
        }
       
    }
}
