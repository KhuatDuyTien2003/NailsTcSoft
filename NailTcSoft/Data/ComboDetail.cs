using System;
using System.Collections.Generic;

namespace NailTcSoft.Data;

public partial class ComboDetail
{
    public int Id { get; set; }

    public int ComboId { get; set; }

    public int ServiceId { get; set; }

    public bool Status { get; set; }

    public bool IsDeleted { get; set; }
}
