namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IProduct Products { get; }
        ICustomer Customers { get; }
        IEmployee Employees { get; }
        IOrder Orders { get; }
        IShipper Shippers { get; }
    }
}