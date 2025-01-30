using System.Linq.Expressions;
using Domain.Interfaces;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Aplication.Repository
{
    public class ShipperRepository : IGenericRepo<Shipper>, IShipper
    {
        private readonly ApplicationDbContext _context;

        public ShipperRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Shipper entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Shipper> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shipper> Find(Expression<Func<Shipper, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Shipper>> GetAllAsync()
        {
            return await _context.Shippers.ToListAsync();
        }

        public Task<(int totalRegistros, IEnumerable<Shipper> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            throw new NotImplementedException();
        }

        public Task<(int totalRegistros, IEnumerable<Shipper> registros)> GetAllAsync(int pageIndex, int pageSize, int search)
        {
            throw new NotImplementedException();
        }

        public Task<Shipper> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Shipper entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Shipper> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Shipper entity)
        {
            throw new NotImplementedException();
        }
    }
}