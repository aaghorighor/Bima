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
    using System.Linq;

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
            var orders = await _order.AllIncludingAsync((x => x.Produce), (x => x.OrderStatus), (x => x.Buyer));
            var model = _mapper.Map<List<OrderReport>>(orders);

            return Ok(model.OrderByDescending(x=>x.OrderDate));
        }

        [Authorize()]
        [HttpPost]
        [Route("updateOrderStatus")]
        public IActionResult UpdateOrderStatus([FromBody] UpdateStatus param)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = ModelState.Errors() });
            }

            switch(param.StatusId.ToUpper())
            {
                case eOrderStatus.Completed:
                    UpdateOrderStatus(new Guid(eOrderStatus.Completed), new Guid(param.OrderId));
                    break;

                case eOrderStatus.Pending:
                    UpdateOrderStatus(new Guid(eOrderStatus.Processing), new Guid(param.OrderId));
                    break;

                case eOrderStatus.Processing:
                    UpdateOrderStatus(new Guid(eOrderStatus.Delivery), new Guid(param.OrderId));
                    break;

                case eOrderStatus.Delivery:
                    UpdateCompletedOrder(new Guid(eOrderStatus.Completed), new Guid(param.OrderId));
                    break;
            }

            return Ok(true);

        }

        [Authorize()]
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody]CreateOrder model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = ModelState.Errors() });
            }

            var buyer = _buyer.GetSingle(x => x.UserId == this.UserId);

            if (buyer == null)
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
            UpdateItemStatus(order.ProduceId);               

            return Ok(true);
        }
        #region private function
        private void UpdateItemStatus(Guid produceId)
        {
            var produce = _produce.GetSingle(x => x.Id == produceId);
            produce.Active = false;
           _produce.Edit(produce);
           _unitOfWork.SaveChanges();
        }
        private void UpdateOrderStatus(Guid orderStatusId, Guid orderId)
        {
            var order = _order.GetSingle(x => x.Id == orderId);
            order.OrderStatusId = orderStatusId;
          
            _order.Edit(order);
            _unitOfWork.SaveChanges();
        }
        private void UpdateCompletedOrder(Guid orderStatusId, Guid orderId)
        {
             var order = _order.GetSingle(x => x.Id == orderId);
             order.OrderStatusId = orderStatusId;
             order.DeliveryDate = DateTime.Now.ToLongDateString();

            _order.Edit(order);
            _unitOfWork.SaveChanges();
        }

        #endregion
    }
}
