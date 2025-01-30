using API.Dtos.Shipper;
using Aplication.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ShippersController : ControllerBase
    {
        private readonly ShipperRepository _repository;

        public ShippersController(ShipperRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ShipperDto>>> GetShippers()
        {
            var shippers = await _repository.GetShippersAsync();
            return Ok(shippers);
        }
    }
}