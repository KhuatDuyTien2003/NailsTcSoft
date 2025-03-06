using System;
using System.Collections.Generic;

namespace NailTcSoft.Data;

public partial class Bill
{
    public int BillId { get; set; }

    public DateTime BillDate { get; set; }

    public decimal TotalMoney { get; set; }

    public int ReceptionistId { get; set; }

    public int CustomerId { get; set; }

    public int? Points { get; set; }

    public decimal? MoneyPoint { get; set; }

    public int? PromotionId { get; set; }

    public bool PaymentId { get; set; }

    public bool Status { get; set; }
}
