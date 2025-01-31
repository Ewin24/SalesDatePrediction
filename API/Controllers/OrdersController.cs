using API.Dtos.Order;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
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
        public async Task<ActionResult<List<OrderDto>>> GetOrdersByCustomerId(int custid)
        {
            var orders = await _unitOfWork.Orders.GetClientOrdersAsync(custid);
            var ordersDto = _mapper.Map<List<OrderDto>>(orders);
            return Ok(ordersDto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateOrder([FromBody] CreateOrderDto createOrderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createOrder = _mapper.Map<CreateOrder>(createOrderDto);
                var newOrderId = await _unitOfWork.Orders.AddNewOrderAsync(createOrder);
                return CreatedAtAction(nameof(CreateOrder), new { id = newOrderId }, newOrderId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating order: {ex.Message}");
            }
        }
    }
}