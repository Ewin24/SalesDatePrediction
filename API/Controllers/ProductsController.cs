using API.Dtos.Product;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProducts()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            var productsDto = new List<ProductDto>();
            foreach (var product in products)
            {
                productsDto.Add(new ProductDto
                {
                    ProductId = product.productid,
                    ProductName = product.productname,
                    UnitPrice = product.unitprice,
                    Discontinued = product.discontinued
                });
            }
            return Ok(productsDto);
        }
    }
}