using System;
using System.Collections.Generic;

namespace KoiFishApp.Repositories.Entities;

public partial class OrderSummary
{
    public int Tongsoluongdonhang { get; set; }

    public int? Soluongdonhanghoanthanh { get; set; }

    public int Soluongdonhangdangxuly { get; set; }
}
