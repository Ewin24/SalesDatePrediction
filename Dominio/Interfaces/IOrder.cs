using Domain.Entities;
using Dominio;
using Dominio.Interfaces;

namespace Domain.Interfaces
{
    public interface IOrder : IGenericRepo<Order>
    {
        Task<int> AddNewOrderAsync(CreateOrder order);
        Task<List<Order>> GetClientOrdersAsync(int custid);
    }
}