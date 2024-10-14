using System;
using System.Collections.Generic;

namespace AutoCenterApp.Models;

public partial class Personal
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string PersonalLogin { get; set; } = null!;

    public string PersonalPassword { get; set; } = null!;

    public string PersonalPhone { get; set; } = null!;

    public byte[]? Photo { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
