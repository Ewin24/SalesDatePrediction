using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Aplication.Repository
{
    public class OrderRepository : IGenericRepo<Order>, IOrder
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetClientOrdersAsync(int custid)
        {
            var orders = await _context.Orders
                .Where(o => o.custid == custid)
                .OrderByDescending(o => o.orderdate)
                .Select(o => new Order
                {
                    orderid = o.orderid,
                    custid = o.custid,
                    empid = o.empid,
                    orderdate = o.orderdate,
                    requireddate = o.requireddate,
                    shippeddate = o.shippeddate,
                    shipname = o.shipname,
                    shipaddress = o.shipaddress,
                    shipcity = o.shipcity,
                    shipperid = o.shipperid,
                    freight = o.freight,
                    shipregion = o.shipregion,
                    shippostalcode = o.shippostalcode,
                    shipcountry = o.shipcountry
                })
                .ToListAsync();

            return orders;
        }

        public async Task<int> AddNewOrderAsync(CreateOrder createOrderDto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var order = new Order
                {
                    custid = createOrderDto.CustomerId,
                    empid = createOrderDto.EmployeeId,
                    shipperid = createOrderDto.ShipperId,
                    shipname = createOrderDto.ShipName,
                    shipaddress = createOrderDto.ShipAddress,
                    shipcity = createOrderDto.ShipCity,
                    shipcountry = createOrderDto.ShipCountry,
                    orderdate = createOrderDto.OrderDate,
                    requireddate = createOrderDto.RequiredDate,
                    shippeddate = createOrderDto.ShippedDate,
                    freight = createOrderDto.Freight
                };

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                Product product = await _context.Products.FirstOrDefaultAsync(p => p.productid == createOrderDto.ProductId);

                var orderDetail = new OrderDetail
                {
                    orderid = order.orderid,
                    productid = createOrderDto.ProductId,
                    qty = createOrderDto.Quantity,
                    unitprice = product.unitprice,
                    discount = createOrderDto.Discount
                };

                _context.OrderDetails.Add(orderDetail);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return order.orderid;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public Task<Order> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(int totalRegistros, IEnumerable<Order> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            throw new NotImplementedException();
        }

        public Task<(int totalRegistros, IEnumerable<Order> registros)> GetAllAsync(int pageIndex, int pageSize, int search)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> Find(Expression<Func<Order, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Add(Order entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Order> entities)
        {
            throw new NotImplementedException();
        }

        public void Remove(Order entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Order> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}