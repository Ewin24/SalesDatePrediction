using Dominio.Entities;

namespace Dominio;

public class Shipper : BaseEntity
{
    public int shipperid { get; set; }

    public string companyname { get; set; } = null!;

    public string phone { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
