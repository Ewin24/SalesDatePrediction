using Dominio.Entities;

namespace Dominio;

public class Category : BaseEntity
{
    public int categoryid { get; set; }

    public string categoryname { get; set; } = null!;

    public string description { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
