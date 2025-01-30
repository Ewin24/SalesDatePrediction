using Dominio;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interfaces
{
    public interface IEmployee : IGenericRepo<Employee>
    {
    }
}