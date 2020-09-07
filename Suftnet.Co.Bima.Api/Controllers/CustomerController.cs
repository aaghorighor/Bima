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
    using Suftnet.Co.Bima.DataAccess.Models;

    using System;  
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class CustomerController : BaseController
    {       
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IRepository<Customer> _customer;
        private readonly IRepository<CustomerAccount> _customerAccount;
        private readonly IJwtFactory _jwtFactory;

        public CustomerController(UserManager<ApplicationUser> userManager,
            IMapper mapper, IRepository<Customer> customer, IJwtFactory jwtFactory,
            IRepository<CustomerAccount> customerAccount,
           IHttpContextAccessor httpContextAccessor) :base(httpContextAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;
            _customer = customer;
            _customerAccount = customerAccount;
            _jwtFactory = jwtFactory;
        }

        [HttpGet]
        [Route("ping")]
        public async Task<IActionResult> Ping()
        {
            return Ok(await Task.Run(() => DateTime.UtcNow));
        }


        [HttpPost]       
        [Route("create")]
        public async Task<IActionResult> Create([FromBody]CreateCustomer model)
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

            var customer = _mapper.Map<Customer>(model);

             customer.Id = new System.Guid();
             customer.CreatedBy = model.Email;
             customer.CreatedDt = DateTime.UtcNow;
            _customer.Add(customer);

            model.UserType = UserType.CUSTOMER;
            var identity = _mapper.Map<ApplicationUser>(model);

            var result = await _userManager.CreateAsync(identity, model.Password);

            if (!result.Succeeded)
            {
                return new BadRequestObjectResult(ModelStateError.AddErrorsToModelState(result, ModelState));
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            var customerAccount = new CustomerAccount();

            customerAccount.Id = new System.Guid();
            customerAccount.CustomerId = customer.Id;
            customerAccount.UserId = user.Id;
            customerAccount.CreatedAt = DateTime.UtcNow;
            customerAccount.CreatedBy = model.Email;           

           _customerAccount.Add(customerAccount);

            var jwt = await _jwtFactory.GenerateEncodedToken(model.Email, _jwtFactory.GenerateClaimsIdentity(user));

            return new OkObjectResult(new { token = jwt, userName = model.FirstName +" " + model.LastName });
        }
       
    }
}
