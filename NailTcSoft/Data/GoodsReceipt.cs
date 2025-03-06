using System;
using System.Collections.Generic;

namespace NailTcSoft.Data;

public partial class GoodsReceipt
{
    public int ReceiptId { get; set; }

    public DateTime ImportDate { get; set; }

    public decimal? TotalMoney { get; set; }

    public int? AccountantId { get; set; }

    public bool Status { get; set; }
}
