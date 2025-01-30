namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IProduct Products { get; }
        ICustomer Customer { get; }
        IEmployee Employees { get; }
        IOrder Order { get; }
    }
}