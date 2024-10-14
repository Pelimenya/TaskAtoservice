using System;
using System.Collections.Generic;

namespace AutoCenterApp.Models;

public partial class Model
{
    public int Id { get; set; }

    public int? MarkId { get; set; }

    public string ModelName { get; set; } = null!;

    public int YearStart { get; set; }

    public int? YearEnd { get; set; }

    public virtual ICollection<Auto> Autos { get; set; } = new List<Auto>();

    public virtual Mark? Mark { get; set; }
}
