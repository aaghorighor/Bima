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
    using System.Linq;
       
    [Route("api/[controller]")]
    public class MarketController : BaseController
    {   
        private readonly IMapper _mapper;
        private readonly IRepository<Produce> _produce;
           
        public MarketController(
            IMapper mapper, IRepository<Produce> produce, 
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _produce = produce;
            _mapper = mapper;        
        }

        [HttpGet]
        [Route("ping")]
        public async Task<IActionResult> Ping()
        {
            return Ok(await Task.Run(() => DateTime.UtcNow));
        }

        [HttpGet]
        [Route("getBy")]
        public async Task<IActionResult> GetBy([FromQuery]Param param)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = ModelState.Errors() });
            }
            
            var produce = await _produce.AllIncludingAsync((x => x.Active == true && x.Id == new Guid(param.Id)), (x => x.Unit),(x=>x.Seller));
            var model = _mapper.Map<List<ProduceDto>>(produce);

            return Ok(model.FirstOrDefault());
        }

        [HttpGet]     
        [Route("fetch")]
        public async Task<IActionResult> Fetch()
        {         
            var produces = await _produce.AllIncludingAsync(x=>x.Active ==true);
            var model = _mapper.Map<List<ProduceDto>>(produces);

            return Ok(model);
        }       
    }
}
