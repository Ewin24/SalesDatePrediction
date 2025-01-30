using API.Dtos.Client;
using API.Dtos.Order;
using Aplication.Repository;
using AutoMapper;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly OrderRepository _repository;
        private readonly IMapper _mapper;

        public OrdersController(OrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("cliente/{custid}")]
        public async Task<ActionResult<List<ClientOrderDto>>> GetOrdersByCustomer(int custid)
        {
            var orders = await _repository.GetClientOrdersAsync(custid);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateOrder([FromBody] OrderDto orderDto)
        {
            Order order = _mapper.Map<Order>(orderDto);
            var newOrderId = await _repository.AddNewOrderAsync(order);
            return CreatedAtAction(nameof(CreateOrder), new { id = newOrderId }, newOrderId);
        }
    }
}