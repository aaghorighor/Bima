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
    using Suftnet.Co.Bima.DataAccess.Interface;
    using Suftnet.Co.Bima.DataAccess.Models;
    using System;  
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class DriverController : BaseController
    {       
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IRepository<Driver> _driver;
        private readonly IRepository<DriverAccount> _driverAccount;
        
        public DriverController(UserManager<ApplicationUser> userManager,
            IMapper mapper, IRepository<Driver> driver, 
            IRepository<DriverAccount> driverAccount,
           IHttpContextAccessor httpContextAccessor) :base(httpContextAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;
            _driver = driver;
            _driverAccount = driverAccount;            
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

            var driver = _mapper.Map<Driver>(model);

            driver.Id = new System.Guid();
            driver.CreatedBy = Username;
            driver.CreatedDt = DateTime.UtcNow;
           _driver.Add(driver);

            model.UserType = UserType.DRIVER;

            var identity = _mapper.Map<ApplicationUser>(model);

            var result = await _userManager.CreateAsync(identity, model.Password);

            if (!result.Succeeded)
            {
                return new BadRequestObjectResult(ModelStateError.AddErrorsToModelState(result, ModelState));
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            var driverAccount = new DriverAccount();

            driverAccount.DriverId = driver.Id;
            driverAccount.UserId = user.Id;
            driverAccount.CreatedAt = DateTime.UtcNow;
            driverAccount.CreatedBy = model.Email;
            driverAccount.Id = new System.Guid();           

           _driverAccount.Add(driverAccount);
                      
            return new OkObjectResult(true);
        }               
        
    }
}
