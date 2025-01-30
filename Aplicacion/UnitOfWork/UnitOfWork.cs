using Aplication.Repository;
using Domain.Interfaces;
using Persistence;

namespace Aplication.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private IProduct _product;
        private IEmployee _employee;
        private IOrder _order;
        private ICustomer _customer;
        private IShipper _shipper;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IProduct Products
        {
            get
            {
                if (_product == null)
                {
                    _product = new ProductRepository(_context);
                }
                return _product;
            }
        }

        public IEmployee Employees
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_context);
                }
                return _employee;
            }
        }

        public IOrder Orders
        {
            get
            {
                if (_order == null)
                {
                    _order = new OrderRepository(_context);
                }
                return _order;
            }
        }

        public ICustomer Customers
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new CustomerRepository(_context);
                }
                return _customer;
            }
        }

        public IShipper Shippers
        {
            get
            {
                if (_shipper == null)
                {
                    _shipper = new ShipperRepository(_context);
                }
                return _shipper;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}