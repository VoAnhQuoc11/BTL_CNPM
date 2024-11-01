using System;
using System.Collections.Generic;

namespace KoiFishApp.Repositories.Entities;

public partial class Pond
{
    public int PondId { get; set; }

    public string? Name { get; set; }

    public string? Image { get; set; }

    public double? Size { get; set; }

    public double? Depth { get; set; }

    public double? Volume { get; set; }

    public int? DrainCount { get; set; }

    public double? PumpCapacity { get; set; }

    public virtual ICollection<KoiFish> KoiFishes { get; set; } = new List<KoiFish>();
}
