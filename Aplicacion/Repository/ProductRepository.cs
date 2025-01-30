using System.Linq.Expressions;
using Domain.Interfaces;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Aplication.Repository
{
    public class ProductRepository : IGenericRepo<Product>, IProduct
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Find(Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public Task<(int totalRegistros, IEnumerable<Product> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            throw new NotImplementedException();
        }

        public Task<(int totalRegistros, IEnumerable<Product> registros)> GetAllAsync(int pageIndex, int pageSize, int search)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Product entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}