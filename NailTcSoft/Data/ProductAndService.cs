using System;
using System.Collections.Generic;

namespace NailTcSoft.Data;

public partial class ProductAndService
{
    public int ProAndSerId { get; set; }

    public string ProAndSerCode { get; set; } = null!;

    public string ProAndSerName { get; set; } = null!;

    public TimeOnly? WorkTime { get; set; }

    public int? InventoryQuantity { get; set; }

    public decimal? OriginalPrice { get; set; }

    public string? Unit { get; set; }

    public string? UrlImage { get; set; }

    public int? ProductTypeId { get; set; }

    public int? Commission { get; set; }

    public byte ProAndSerType { get; set; }

    public bool Status { get; set; }

    public bool IsDeleted { get; set; }
}
