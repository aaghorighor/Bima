namespace Suftnet.Co.Bima.Api.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Suftnet.Co.Bima.Api.Extensions;
    using Suftnet.Co.Bima.Api.Models;
    using Suftnet.Co.Bima.Common;
    using Suftnet.Co.Bima.DataAccess.Actions;
    using Suftnet.Co.Bima.DataAccess.Interface;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
      
    [Authorize()]
    [Route("api/[controller]")]
    public class ProduceController : BaseController

    {   
        private readonly IMapper _mapper;
        private readonly IRepository<Produce> _produce;
        private readonly IRepository<Seller> _seller;
        private readonly IUnitOfWork _unitOfWork;
       
        public ProduceController(
            IMapper mapper, IRepository<Produce> produce, IUnitOfWork unitOfWork, IRepository<Seller> seller,
        IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _produce = produce;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _seller = seller;
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
            var produces = await _produce.AllIncludingAsync(x=>x.Seller.UserId == this.UserId,(x=>x.Unit));
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

            var seller = _seller.GetSingle(x => x.UserId == this.UserId);

            if(seller == null)
            {
                return BadRequest(new { message = ValidationError.SELLER_NOT_FOUND });
            }

            var produce = _mapper.Map<Produce>(model);

            produce.Id = Guid.NewGuid();
            produce.SellerId = seller.Id;
            produce.CreatedAt = DateTime.UtcNow;
            produce.CreatedBy = this.Username;

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

            var produce = _produce.GetSingle(x => x.Id == model.Id);

            if(produce == null)
            {
                return BadRequest(new { message = ValidationError.PRODUCE_NOT_FOUND });
            }

            produce.Description = model.Description;
            produce.Active = model.Active;
            produce.AvailableDate = model.AvailableDate;
            produce.Name = model.Name;
            produce.Price = model.Price;
            produce.Quantity = (double)model.Quantity;
            produce.UnitId = model.UnitId;
            produce.Address = model.Address;
            produce.City = model.City;
            produce.State = model.State;
            produce.Country = model.Country;

            _produce.Edit(produce);
           _unitOfWork.SaveChanges();

            return Ok(true);
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
                return BadRequest(new { message = ValidationError.PRODUCE_NOT_FOUND });
            }

            _produce.Delete(produce);
            _unitOfWork.SaveChanges();

            return Ok(true);
        }

    }
}
