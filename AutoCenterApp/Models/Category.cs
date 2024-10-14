using System;
using System.Collections.Generic;

namespace AutoCenterApp.Models;

public partial class Category
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
