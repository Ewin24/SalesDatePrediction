using System.Linq.Expressions;
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
                    requireddate = o.requireddate,
                    shippeddate = o.shippeddate,
                    shipname = o.shipname
                })
                .ToListAsync();

            return orders;
        }

        public async Task<int> AddNewOrderAsync(Order order)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var newOrder = new Order
                    {
                        empid = order.empid,
                        shipperid = order.shipperid,
                        shipname = order.shipname,
                        shipaddress = order.shipaddress,
                        shipcity = order.shipcity,
                        orderdate = order.orderdate,
                        requireddate = order.requireddate,
                        shippeddate = order.shippeddate,
                        freight = order.freight,
                        shipcountry = order.shipcountry
                    };

                    _context.Orders.Add(newOrder);
                    await _context.SaveChangesAsync();

                    var orderDetail = new OrderDetail
                    {
                        orderid = newOrder.orderid,
                        productid = order.OrderDetails.First().productid,
                        unitprice = order.OrderDetails.First().unitprice,
                        qty = order.OrderDetails.First().qty,
                        discount = order.OrderDetails.First().discount
                    };

                    _context.OrderDetails.Add(orderDetail);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return newOrder.orderid;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(); // Revertir la transacción en caso de error
                    throw new Exception("Error al agregar la orden: " + ex.Message);
                }
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