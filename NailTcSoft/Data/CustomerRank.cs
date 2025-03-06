using System;
using System.Collections.Generic;

namespace NailTcSoft.Data;

public partial class CustomerRank
{
    public int RankId { get; set; }

    public string RankName { get; set; } = null!;

    public int DiscountRate { get; set; }

    public decimal TotalMoney { get; set; }

    public bool Status { get; set; }

    public bool? IsDeleted { get; set; }
}
