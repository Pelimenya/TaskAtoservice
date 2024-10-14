using System;
using System.Collections.Generic;

namespace AutoCenterApp.Models;

public partial class Mark
{
    public int Id { get; set; }

    public string MarkName { get; set; } = null!;

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
