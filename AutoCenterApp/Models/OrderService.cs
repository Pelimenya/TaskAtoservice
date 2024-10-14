using System;
using System.Collections.Generic;

namespace AutoCenterApp.Models;

public partial class OrderService
{
    public int Id { get; set; }

    public int? Order { get; set; }

    public int? Service { get; set; }

    public virtual Order? OrderNavigation { get; set; }

    public virtual Service? ServiceNavigation { get; set; }
}
