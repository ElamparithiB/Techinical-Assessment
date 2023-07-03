using System;
using System.Collections.Generic;

namespace ASSESSMENTDAL.TechinicalDBContext;

public partial class ExceptionHandling
{
    public int ExceptionId { get; set; }

    public string? Method { get; set; }

    public string? Module { get; set; }

    public string? ExceptionMessage { get; set; }

    public string? ExceptionSource { get; set; }

    public string? ExceptionStackTrace { get; set; }

    public string? TargetSiteName { get; set; }

    public DateTime? CreatedDate { get; set; }
}
