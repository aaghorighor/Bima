namespace Suftnet.Co.Bima.Api.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Suftnet.Co.Bima.Api.Extensions;
    using Suftnet.Co.Bima.Api.Models;
    using Suftnet.Co.Bima.DataAccess.Actions;
    using Suftnet.Co.Bima.DataAccess.Interface;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class CompanyController : BaseController

    {   
        private readonly IMapper _mapper;
        private readonly IRepository<Company> _company;     

        public CompanyController(
            IMapper mapper, IRepository<Company> company, 
           IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _company = company;
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
        public async Task<IActionResult> Fetch()
        {
            var companies = await _company.AllIncludingAsync(x=>x.Area);
            var model = _mapper.Map<List<CompanyDto>>(companies);

            return Ok(model);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody]CreateCompany model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = ModelState.Errors() });
            }               

            var company = _mapper.Map<Company>(model);

            company.Id = new Guid();        
            company.CreatedAt = DateTime.UtcNow;
            company.CreatedBy = model.Email;

           _company.Add(company);
          
            return new OkObjectResult(new { CompanyId = company.Id });
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult Edit([FromBody]UpdateCompany model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = ModelState.Errors() });
            }
                        
            var company = _mapper.Map<Company>(model);
                       
           _company.Edit(company);

            return new OkObjectResult(new { ok = true });
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete([FromBody]Delete model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = ModelState.Errors() }); ;
            }

            var company = _company.GetSingle(x => x.Id == model.Id);

            if(company == null)
            {
                return BadRequest("No match found for your Company Name");

            }

            _company.Delete(company);

            return new OkObjectResult(new { ok = true });
        }

    }
}
