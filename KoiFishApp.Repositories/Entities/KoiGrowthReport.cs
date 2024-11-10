using System;
using System.Collections.Generic;

namespace KoiFishApp.Repositories.Entities;

public partial class KoiGrowthReport
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Danhgiatangtruong { get; set; }
}
