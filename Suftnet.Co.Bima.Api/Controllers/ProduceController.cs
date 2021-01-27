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
    public class ProduceController : BaseController

    {   
        private readonly IMapper _mapper;
        private readonly IRepository<Produce> _produce;
        private readonly IUnitOfWork _unitOfWork;

        public ProduceController(
            IMapper mapper, IRepository<Produce> produce, IUnitOfWork unitOfWork,
           IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _produce = produce;
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
        public async Task<IActionResult> Fetch()
        {
            var produces = await _produce.AllIncludingAsync(x=>x.Unit);
            var model = _mapper.Map<List<ProduceDto>>(produces);

            return Ok(model);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody]CreateProduce model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = ModelState.Errors() });
            }               

            var produce = _mapper.Map<Produce>(model);

            produce.Id = Guid.NewGuid();
            produce.CreatedAt = DateTime.UtcNow;
            produce.CreatedBy = model.Email;

           _produce.Add(produce);
           _unitOfWork.SaveChanges();

            return new OkObjectResult(new { ProduceId = produce.Id });
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult Edit([FromBody]UpdateProduce model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = ModelState.Errors() });
            }
                        
            var produce = _mapper.Map<Produce>(model);

           _produce.Edit(produce);
           _unitOfWork.SaveChanges();

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

            var produce = _produce.GetSingle(x => x.Id == model.Id);

            if(produce == null)
            {
                return BadRequest("No match found for your Prodcue Name");
            }

            _produce.Delete(produce);
            _unitOfWork.SaveChanges();

            return new OkObjectResult(new { ok = true });
        }

    }
}
