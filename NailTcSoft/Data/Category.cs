using System;
using System.Collections.Generic;

namespace NailTcSoft.Data;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public bool Status { get; set; }
}
