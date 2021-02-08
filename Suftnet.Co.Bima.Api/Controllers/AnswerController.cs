namespace Suftnet.Co.Bima.Api.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using Suftnet.Co.Bima.Api.Extensions;
    using Suftnet.Co.Bima.Api.Models; 
    using Suftnet.Co.Bima.DataAccess.Actions;
    using Suftnet.Co.Bima.DataAccess.Interface;

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;

    [Authorize()]
    [Route("api/[controller]")]
    public class AnswerController : BaseController

    {   
        private readonly IMapper _mapper;
        private readonly IRepository<Answer> _answer; 
        private readonly IUnitOfWork _unitOfWork;
       
        public AnswerController(
            IMapper mapper, IRepository<Answer> answer, IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _answer = answer;
            _mapper = mapper;
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
        public async Task<IActionResult> Fetch([FromQuery] Param param)
        {          
            var answers = await _answer.AllIncludingAsync(x=>x.QuestionId == new Guid(param.Id));
            var model = _mapper.Map<List<AnswerDto>>(answers.OrderByDescending(x=>x.CreatedDt));

            return Ok(model);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] CreateAnswerDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = ModelState.Errors() });
            }            

            var answer = _mapper.Map<Answer>(model);

            answer.Id = Guid.NewGuid();
            answer.FirstName = this.FirstName;
            answer.LastName = this.LastName;
            answer.Email = this.Username;
            answer.PhoneNumber = this.PhoneNumber;
            answer.CreatedDt = DateTime.UtcNow;
            answer.CreatedBy = this.Username;

           _answer.Add(answer);
           _unitOfWork.SaveChanges();

            return Ok(answer);
        }       

    }
}
