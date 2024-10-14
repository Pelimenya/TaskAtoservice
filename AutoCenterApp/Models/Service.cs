using System;
using System.Collections.Generic;

namespace AutoCenterApp.Models;

public partial class Service
{
    public int Id { get; set; }

    public int? CategoryId { get; set; }

    public string ServiceName { get; set; } = null!;

    public decimal Cost { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();
}
