namespace Suftnet.Co.Bima.Api.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Suftnet.Co.Bima.Api.Extensions;
    using Suftnet.Co.Bima.Api.Models;
    using Suftnet.Co.Bima.DataAccess.Actions;
    using Suftnet.Co.Bima.DataAccess.Interface;
    using System;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class MobileLoggerController : BaseController
    {   
        private readonly IMapper _mapper;
        private readonly IRepository<Logger> _mobileLogger;
        private readonly IUnitOfWork _unitOfWork;

        public MobileLoggerController(
            IMapper mapper, IRepository<Logger> mobileLogger, IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mobileLogger = mobileLogger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("ping")]
        public async Task<IActionResult> Ping()
        {
            return Ok(await Task.Run(() => DateTime.UtcNow));
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(MobileLogDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = ModelState.Errors() });
            }

            var description = new System.Text.StringBuilder();

            description.AppendLine("REPORT_ID " + model.REPORT_ID);
            description.AppendLine("PACKAGE_NAME " + model.PACKAGE_NAME);
            description.AppendLine("BUILD " + model.BUILD);
            description.AppendLine("LOGCAT " + model.ANDROID_VERSION);
            description.AppendLine("ANDROID_VERSION " + model.ANDROID_VERSION);
            description.AppendLine("APP_VERSION_CODE " + model.APP_VERSION_CODE);
            description.AppendLine("AVAILABLE_MEM_SIZE " + model.AVAILABLE_MEM_SIZE);
            description.AppendLine("STACK_TRACE " + model.STACK_TRACE);
            description.AppendLine("CRASH_CONFIGURATION " + model.CRASH_CONFIGURATION);
          
            var logger = new Logger
            {
                 Id = Guid.NewGuid(),
                 Description = description.ToString(),
                 CreatedAt = DateTime.UtcNow               
            };       
                    
           _mobileLogger.Add(logger);
           _unitOfWork.SaveChanges();

            return Ok();
        }

    }
}
