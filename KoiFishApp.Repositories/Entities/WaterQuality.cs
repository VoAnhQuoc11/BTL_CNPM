using System;
using System.Collections.Generic;

namespace KoiFishApp.Repositories.Entities;

public partial class WaterQuality
{
    public double PoindId { get; set; }

    public double MucdoPh { get; set; }

    public double? MucdoOxygen { get; set; }

    public double Nhietdo { get; set; }
}
