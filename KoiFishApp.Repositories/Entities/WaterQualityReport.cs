using System;
using System.Collections.Generic;

namespace KoiFishApp.Repositories.Entities;

public partial class WaterQualityReport
{
    public int PondId { get; set; }

    public double DopHtrungbinh { get; set; }

    public double MucdoOxygen { get; set; }

    public double Nhietdo { get; set; }
}
