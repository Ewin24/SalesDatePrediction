using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ClientsController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientsController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerOrderPrediction>>> GetClientes()
        {
            try {
                var clientes = await _unitOfWork.Customer.GetNextOrderPredictionsAsync();
                return Ok(clientes);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}