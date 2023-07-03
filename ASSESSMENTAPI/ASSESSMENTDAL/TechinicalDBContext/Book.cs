using System;
using System.Collections.Generic;

namespace ASSESSMENTDAL.TechinicalDBContext;

public partial class Book
{
    public int BookId { get; set; }

    public string? Publisher { get; set; }

    public string? Title { get; set; }

    public string? AuthorLastName { get; set; }

    public string? AuthorFirstName { get; set; }

    public int? Price { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
