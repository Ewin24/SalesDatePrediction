using Domain.Entities;
using Dominio;
using Dominio.Interfaces;

namespace Domain.Interfaces
{
    public interface ICustomer : IGenericRepo<Customer>
    {
        Task<List<CustomerOrderPrediction>> GetNextOrderPredictionsAsync();
    }
}