using System.Linq.Expressions;
using Domain.Interfaces;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Aplication.Repository
{
    public class EmployeeRepository : IGenericRepo<Employee>, IEmployee
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Employee> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Find(Expression<Func<Employee, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public Task<(int totalRegistros, IEnumerable<Employee> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            throw new NotImplementedException();
        }

        public Task<(int totalRegistros, IEnumerable<Employee> registros)> GetAllAsync(int pageIndex, int pageSize, int search)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Employee> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}