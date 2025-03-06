using System;
using System.Collections.Generic;

namespace NailTcSoft.Data;

public partial class Staff
{
    public int StaffId { get; set; }

    public string StaffName { get; set; } = null!;

    public int Gender { get; set; }

    public string? NumberPhone { get; set; }

    public DateOnly? Birthday { get; set; }

    public decimal? TotalMoney { get; set; }

    public string? UrlAvatar { get; set; }

    public double? TotalStar { get; set; }

    public DateOnly? JoinDate { get; set; }

    public bool Status { get; set; }
}
