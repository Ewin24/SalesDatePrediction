﻿using Dominio.Entities;

namespace Dominio;

public partial class Product : BaseEntity
{
    public int productid { get; set; }

    public string productname { get; set; } = null!;

    public int supplierid { get; set; }

    public int categoryid { get; set; }

    public decimal unitprice { get; set; }

    public bool discontinued { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Category category { get; set; } = null!;

    public virtual Supplier supplier { get; set; } = null!;
}