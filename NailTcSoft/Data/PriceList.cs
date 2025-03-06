using System;
using System.Collections.Generic;

namespace NailTcSoft.Data;

public partial class PriceList
{
    public int PriceListId { get; set; }

    public string PriceListName { get; set; } = null!;

    public int ValuePriceList { get; set; }

    public bool PriceListType { get; set; }

    public int RankId { get; set; }

    public DateOnly StartTime { get; set; }

    public DateOnly EndTime { get; set; }

    public bool Status { get; set; }

    public bool IsDeleted { get; set; }
}
