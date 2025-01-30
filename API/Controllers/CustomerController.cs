using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerOrderPrediction>>> GetCustomers()
        {
            try
            {
                var clientes = await _unitOfWork.Customers.GetNextOrderPredictionsAsync();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetFilteredPredictions")]
        public async Task<ActionResult<List<CustomerOrderPrediction>>> GetFilteredPredictions([FromQuery] string searchTerm = "")
        {
            try
            {
                if (searchTerm == "")
                {
                    return Ok(await _unitOfWork.Customers.GetNextOrderPredictionsAsync());
                }

                var predictions = await _unitOfWork.Customers.GetNextOrderPredictionsAsync();

                var filteredResults = predictions
                    .Where(p =>
                    {
                        var customerNameWithoutPrefix = p.CustomerName
                            .Replace("Customer", "", StringComparison.OrdinalIgnoreCase)
                            .Trim()
                            .ToLower();

                        var lowerSearchTerm = searchTerm?.ToLower() ?? string.Empty;

                        return customerNameWithoutPrefix.Contains(lowerSearchTerm);
                    })
                    .ToList();

                return Ok(filteredResults);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}