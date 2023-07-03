using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ASSESSMENTDAL.DBConnection
{
    public class DatabaseCall
    {
    }
    [Keyless]
    public class BookInfo
    {
        [Key]
        public int BookID { get; set; }
        [Key]
        public string? Publisher { get; set; }
        [Key]
        public string? Title { get; set; }
        [Key]
        public string? AuthorLastName { get; set; }
        [Key]
        public string? AuthorFirstName { get; set; }
        [Key]
        public int? Price { get; set; }

    }
}
