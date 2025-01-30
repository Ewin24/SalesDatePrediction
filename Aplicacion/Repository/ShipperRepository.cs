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

        public Task<IEnumerable<Shipper>> GetAllAsync()
        {
            throw new NotImplementedException();
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

        public async Task<List<Shipper>> GetShippersAsync()
        {
            var shippers = await _context.Shippers
                .OrderBy(s => s.companyname) // Ordenar por nombre de la compañía
                .Select(s => new Shipper
                {
                    shipperid = s.shipperid,
                    companyname = s.companyname
                })
                .ToListAsync();

            return shippers;
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