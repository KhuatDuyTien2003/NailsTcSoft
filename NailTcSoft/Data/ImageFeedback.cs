using System;
using System.Collections.Generic;

namespace NailTcSoft.Data;

public partial class ImageFeedback
{
    public int Id { get; set; }

    public int FeedbackId { get; set; }

    public string? UrlImage { get; set; }

    public bool Status { get; set; }

    public bool IsDeleted { get; set; }
}
