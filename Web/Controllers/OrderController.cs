using System.Threading.Tasks;
using AutoMapper;
using Core.Entities.Identity;
using Core.Interfaces.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Errors;
using Web.Extensions;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class OrderController : BaseApiController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderController>> CreateOrder(OrderDto orderDto)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();

            var address = _mapper.Map<AddressDto, Address>(orderDto.AddressToShip);

            var order = await _orderService.CreateOrder(email, orderDto.DeliveryMethodId, orderDto.CartId, address);

            if (order == null) return BadRequest(new ApiResponse(400, "An error occured while creating the order"));

            return Ok(order);
        }
    }
}