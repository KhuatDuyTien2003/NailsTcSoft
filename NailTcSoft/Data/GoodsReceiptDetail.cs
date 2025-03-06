using System;
using System.Collections.Generic;

namespace NailTcSoft.Data;

public partial class GoodsReceiptDetail
{
    public int Id { get; set; }

    public int? ReceiptId { get; set; }

    public int? ProductId { get; set; }

    public decimal? ImportPrice { get; set; }

    public string? Supplier { get; set; }

    public bool Status { get; set; }
}
