using API.Dtos.Employee;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmployeesController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> GetEmployees()
        {
            var employees = await _unitOfWork.Employees.GetAllAsync();
            var employeeDtos = _mapper.Map<List<EmployeeDto>>(employees);
            return Ok(employeeDtos);
        }
    }
}