﻿namespace Suftnet.Co.Bima.Api.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;   
    using Microsoft.AspNetCore.Mvc;

    using Suftnet.Co.Bima.Api.Extensions;   
    using Suftnet.Co.Bima.Api.Models; 
    using Suftnet.Co.Bima.DataAccess.Interface;
    using Suftnet.Co.Bima.DataAccess.Actions;

    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Authorization;
    using Suftnet.Co.Bima.Common;

    [Authorize()]
    [Route("api/[controller]")]
    public class OrderController : BaseController
    {    
        private readonly IMapper _mapper;
        private readonly IRepository<Order> _order;  
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Buyer> _buyer;
        private readonly IRepository<Produce> _produce;

        public OrderController(IUnitOfWork unitOfWork, IRepository<Buyer> buyer,
            IMapper mapper, IRepository<Order> order, IRepository<Produce> produce,
           IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {        
            _mapper = mapper;
            _order = order;  
            _unitOfWork = unitOfWork;
            _produce = produce;
            _buyer = buyer;
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
            var orders = await _order.AllIncludingAsync();
            var model = _mapper.Map<List<OrderDto>>(orders);

            return Ok(model);
        }             

        [HttpPost]
        [Route("create")]

        public IActionResult Create([FromBody]CreateOrder model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = ModelState.Errors() });
            }

            var buyer = _buyer.GetSingle(x => x.UserId == this.UserId);

            if (buyer != null)
            {
                return BadRequest(new { message = ValidationError.BUYER_NOT_FOUND });
            }

            var order = _mapper.Map<Order>(model);

            order.Id = Guid.NewGuid();
            order.BuyerId = buyer.Id;
            order.CreatedAt = DateTime.UtcNow;
            order.CreatedBy = Username;
            order.OrderStatusId = new Guid(eOrderStatus.Pending);
            order.PaymentStatusId = new Guid(ePaymentStatus.Paid);           

           _order.Add(order);
            ResetStatus(order.ProduceId);               

            return Ok(true);
        }

        #region private function
        private void ResetStatus(Guid produceId)
        {
            var produce = _produce.GetSingle(x => x.Id == produceId);
            produce.Active = false;
           _produce.Edit(produce);
           _unitOfWork.SaveChanges();
        }
        #endregion
    }
}