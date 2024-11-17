using System;
using System.Collections.Generic;

namespace KoiFishApp.Repositories.Entities;

public partial class GioHang
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public string? Description { get; set; }
}
