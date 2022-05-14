using AutoMapper;
using GlobCartOrderService.Services.API.Models;
using GlobCartOrderService.Services.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlobCartOrderService.Services.API.Controllers.V1
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet("{code}")]
        public ActionResult<OrderViewModel> Get(string code)
        {
            var order = _orderService.FindOrder(code);
            var orderViewModel = _mapper.Map<OrderViewModel>(order);
            
            return Ok(orderViewModel);
        }
    }
}
