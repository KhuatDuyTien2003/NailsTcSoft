using System;
using System.Collections.Generic;

namespace NailTcSoft.Data;

public partial class PriceListDetail
{
    public int Id { get; set; }

    public int PriceListId { get; set; }

    public int ProductId { get; set; }

    public decimal SellPrice { get; set; }

    public bool Status { get; set; }
}
