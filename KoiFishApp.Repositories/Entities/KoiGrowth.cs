﻿using System;
using System.Collections.Generic;

namespace KoiFishApp.Repositories.Entities;

public partial class KoiGrowth
{
    public int KoiGrowthId { get; set; }

    public DateTime? Date { get; set; }

    public double? Size { get; set; }

    public double? Weight { get; set; }

    public int? Age { get; set; }

    public int? KoiId { get; set; }

    public decimal? FoodAmount { get; set; }

    public virtual KoiFish? Koi { get; set; }
}
