using System;
using System.Collections.Generic;

namespace NailTcSoft.Data;

public partial class ProductType
{
    public int ProductTypeId { get; set; }

    public string ProductTypeName { get; set; } = null!;

    public int? CategoryId { get; set; }

    public bool Status { get; set; }
}
