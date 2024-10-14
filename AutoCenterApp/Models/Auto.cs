using System;
using System.Collections.Generic;

namespace AutoCenterApp.Models;

public partial class Auto
{
    public int Id { get; set; }

    public int? AutoOwner { get; set; }

    public int? AutoModel { get; set; }

    public string Vin { get; set; } = null!;

    public string StateNumber { get; set; } = null!;

    public virtual Model? AutoModelNavigation { get; set; }

    public virtual Client? AutoOwnerNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
