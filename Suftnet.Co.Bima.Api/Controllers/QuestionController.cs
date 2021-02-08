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

   
    [Route("api/[controller]")]
    public class QuestionController : BaseController

    {   
        private readonly IMapper _mapper;
        private readonly IRepository<Question> _question; 
        private readonly IUnitOfWork _unitOfWork;
       
        public QuestionController(
            IMapper mapper, IRepository<Question> question, IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _question = question;
            _mapper = mapper;
            _unitOfWork = unitOfWork;          
        }

        [HttpGet]
        [Route("ping")]
        public async Task<IActionResult> Ping()
        {
            return Ok(await Task.Run(() => DateTime.UtcNow));
        }

        [Authorize()]
        [HttpGet]     
        [Route("fetch")]
        public async Task<IActionResult> Fetch()
        {          
            var questions = await _question.AllIncludingAsync((x=>x.Answers));
            var model = _mapper.Map<List<QuestionDto>>(questions.OrderByDescending(x=>x.CreatedDt));

            return Ok(model);
        }

        [Authorize()]
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody]CreateQuestionDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = ModelState.Errors() });
            }            

            var question = _mapper.Map<Question>(model);

            question.Id = Guid.NewGuid();
            question.FirstName = this.FirstName;
            question.LastName = this.LastName;
            question.Email = this.Username;
            question.PhoneNumber = this.PhoneNumber;
            question.CreatedDt = DateTime.UtcNow;
            question.CreatedBy = this.Username;

           _question.Add(question);
           _unitOfWork.SaveChanges();

            return Ok(question);
        }       

    }
}
