using API.Dtos.Employee;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmployeesController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> GetEmployees()
        {
            var employees = await _unitOfWork.Employees.GetAllAsync();
            return Ok(employees);
        }
    }
}