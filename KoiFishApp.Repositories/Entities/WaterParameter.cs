using System;
using System.Collections.Generic;

namespace KoiFishApp.Repositories.Entities;

public partial class WaterParameter
{
    public DateTime? MeasurementDate { get; set; }

    public double? Temperature { get; set; }

    public double? Salinity { get; set; }

    public double? Ph { get; set; }

    public double? O2 { get; set; }

    public double? No2 { get; set; }

    public double? No3 { get; set; }

    public double? Po4 { get; set; }

    public int? PondId { get; set; }

    public virtual Pond? Pond { get; set; }
}
