using System;
using System.Collections.Generic;

namespace AutoCenterApp.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? OrderPersonal { get; set; }

    public int? OrderAuto { get; set; }

    public DateTime OrderDate { get; set; }

    public int? OrderStatus { get; set; }

    public byte[]? Photo { get; set; }

    public virtual Auto? OrderAutoNavigation { get; set; }

    public virtual Personal? OrderPersonalNavigation { get; set; }

    public virtual ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();

    public virtual Status? OrderStatusNavigation { get; set; }
}
