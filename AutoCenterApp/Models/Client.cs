using System;
using System.Collections.Generic;

namespace AutoCenterApp.Models;

public partial class Client
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string PhoneClient { get; set; } = null!;

    public byte[]? Photo { get; set; }

    public virtual ICollection<Auto> Autos { get; set; } = new List<Auto>();
}
