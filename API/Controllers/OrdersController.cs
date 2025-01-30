using API.Dtos.Client;
using API.Dtos.Order;
using Aplication.Repository;
using AutoMapper;
using Domain.Interfaces;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrdersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("OrdersByCustomerId/{custid}")]
        public async Task<ActionResult<List<ClientOrderDto>>> GetOrdersByCustomerId(int custid)
        {
            var orders = await _unitOfWork.Orders.GetClientOrdersAsync(custid);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateOrder([FromBody] OrderDto orderDto)
        {
            Order order = _mapper.Map<Order>(orderDto);
            var newOrderId = await _unitOfWork.Orders.AddNewOrderAsync(order);
            return CreatedAtAction(nameof(CreateOrder), new { id = newOrderId }, newOrderId);
        }
    }
}