using System;
using System.Collections.Generic;

namespace NailTcSoft.Data;

public partial class WorkSchedule
{
    public int WorkScheduleId { get; set; }

    public int StaffId { get; set; }

    public int CustomerId { get; set; }

    public byte Shift { get; set; }

    public bool IsDone { get; set; }

    public bool Status { get; set; }
}
