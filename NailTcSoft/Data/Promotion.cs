using System;
using System.Collections.Generic;

namespace NailTcSoft.Data;

public partial class Promotion
{
    public int PromotionId { get; set; }

    public string PromotionName { get; set; } = null!;

    public bool PromotionType { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? Quantity { get; set; }

    public int? ProductTypeId { get; set; }

    public bool IsPoints { get; set; }

    public decimal Condition { get; set; }

    public int? RankId { get; set; }

    public string? UrlImage { get; set; }

    public bool Status { get; set; }
}
