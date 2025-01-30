using API.Dtos.Shipper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ShippersController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShippersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<ShipperDto>>> GetShippers()
        {
            var shippers = await _unitOfWork.Shippers.GetAllAsync();
            return Ok(shippers);
        }
    }
}