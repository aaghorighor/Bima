namespace Suftnet.Co.Bima.Api.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Suftnet.Co.Bima.Api.Extensions;
    using Suftnet.Co.Bima.Api.Infrastructure;
    using Suftnet.Co.Bima.Api.Models;
    using Suftnet.Co.Bima.Common;
    using Suftnet.Co.Bima.DataAccess.Actions;
    using Suftnet.Co.Bima.DataAccess.Identity;
    using Suftnet.Co.Bima.DataAccess.Interface;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class DriverController : BaseController

    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IRepository<Driver> _driver;
        private readonly IRepository<Delivery> _delivery;
        private readonly IRepository<Order> _order;
        private readonly IJwtFactory _jwtFactory;
        private readonly IUnitOfWork _unitOfWork;

        public DriverController(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork, IRepository<Order> order,
        IMapper mapper, IRepository<Driver> driver, IJwtFactory jwtFactory, IRepository<Delivery> delivery,
        IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;
            _driver = driver;
            _delivery = delivery;
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
            var drivers = await _driver.AllIncludingAsync();      
            var model = _mapper.Map<List<DriverDto>>(drivers.OrderByDescending(x => x.CreatedAt));

            return Ok(model);
        }

        [Authorize()]
        [HttpGet]
        [Route("fetchByUser")]
        public async Task<IActionResult> FetchByUser()
        {
            var drivers = await _driver.AllIncludingAsync(x => x.UserId == this.UserId);
            var driver = drivers.FirstOrDefault();
            var model = _mapper.Map<DriverDto>(driver);

            return Ok(model);
        }

        [Authorize()]
        [HttpGet]
        [Route("pendingJobs")]
        public async Task<IActionResult> PendingJobs()
        {
            var deliveries = await _delivery.AllIncludingAsync(x => x.Driver.UserId == this.UserId && x.Order.OrderStatusId != new Guid(eOrderStatus.Completed), (x => x.Order.Produce),(x => x.Order.OrderStatus), (x => x.Order.Produce.Seller));           
            var model = _mapper.Map<List<DriverOrder>>(deliveries.Select(x => x.Order).OrderByDescending(x=>x.CreatedAt));

            return Ok(model);
        }

        [Authorize()]
        [HttpGet]
        [Route("completedjobs")]
        public async Task<IActionResult> Completedjobs()
        {
            var deliveries = await _delivery.AllIncludingAsync(x => x.Driver.UserId == this.UserId && x.Order.OrderStatusId == new Guid(eOrderStatus.Completed), (x => x.Order.Produce), (x => x.Order.OrderStatus), (x => x.Order.Produce.Seller));
            var model = _mapper.Map<List<DriverOrder>>(deliveries.Select(x => x.Order).OrderByDescending(x => x.CreatedAt));

            return Ok(model);
        }

        [Authorize()]
        [HttpGet]
        [Route("fetchByOrderId")]
        public async Task<IActionResult> FetchByOrderId([FromQuery] Param param)
        {
            var drivers = await _delivery.AllIncludingAsync(x=>x.OrderId == new Guid(param.Id),(x=>x.Driver));
            var driver = drivers.FirstOrDefault();

            if(driver == null)
            {
                return Ok(new DriverDto());
            }

            var model = _mapper.Map<DriverDto>(driver.Driver);

            return Ok(model);
        }

        [Authorize()]
        [HttpPost]
        [Route("createDelivery")]
        public IActionResult CreateDelivery([FromBody]DeliveryDto deliveryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = ModelState.Errors() });
            }

            var delivery = _mapper.Map<Delivery>(deliveryDto);
            var change = _delivery.GetSingle(x => x.OrderId == deliveryDto.OrderId);

            if(change != null)
            {
                 change.DriverId = delivery.DriverId;
                _delivery.Edit(change);
            }
            else
            {
                delivery.Id = Guid.NewGuid();
                delivery.CreatedAt = DateTime.UtcNow;
                delivery.CreatedBy = this.Username;

               _delivery.Add(delivery);
            }

            updateOrderStatus(deliveryDto.OrderId);
           _unitOfWork.SaveChanges();

            return Ok(true);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody]CreateDriver model)
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
            user.UserType = UserType.Logistic;
            user.CreatedAt = DateTime.UtcNow;
            user.IsEnabled = model.Active;
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new { message = ModelStateError.AddErrorsToModelState(result, ModelState) });
            }

            var driver = _mapper.Map<Driver>(model);

            driver.Id = Guid.NewGuid();
            driver.UserId = user.Id;
            driver.CreatedAt = DateTime.UtcNow;
            driver.CreatedBy = model.Email;

           _driver.Add(driver);
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

        [Authorize()]
        [HttpPost]
        [Route("edit")]
        public IActionResult Edit([FromBody] DriverDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = ModelState.Errors() });
            }

            var driver = _driver.GetSingle(x => x.UserId == this.UserId);

            if (driver == null)
            {
                return BadRequest(new { message = ValidationError.DRIVER_NOT_FOUND });
            }

            driver.TransportType = model.TransportType;
            driver.JourneyTime = model.JourneyTime;

           _driver.Edit(driver);
           _unitOfWork.SaveChanges();

            return Ok(true);
        }

        private void updateOrderStatus(Guid orderId)
        {
            var model = _order.GetSingle(x => x.Id == orderId);
            model.OrderStatusId = new Guid(eOrderStatus.Processing);
           _order.Edit(model);
        }

    }
}
