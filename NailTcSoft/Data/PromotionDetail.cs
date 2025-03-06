using System;
using System.Collections.Generic;

namespace NailTcSoft.Data;

public partial class PromotionDetail
{
    public int Id { get; set; }

    public int PromotionId { get; set; }

    public string PromotionCode { get; set; } = null!;

    public bool IsUsed { get; set; }

    public DateOnly? UsedDate { get; set; }

    public int? CustomerId { get; set; }

    public bool Status { get; set; }
}
