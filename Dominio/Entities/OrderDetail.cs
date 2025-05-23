﻿using Dominio.Entities;

namespace Dominio;

public partial class OrderDetail : BaseEntity
{
    public int orderid { get; set; }

    public int productid { get; set; }

    public decimal unitprice { get; set; }

    public short qty { get; set; }

    public decimal discount { get; set; }

    public virtual Order order { get; set; } = null!;

    public virtual Product product { get; set; } = null!;
}