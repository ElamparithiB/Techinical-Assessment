using static TECHINICALBAL.Models.CommonFunctions;

namespace ASSESSMENTBAL.ModelClass
{
    public class Books
    {
        public class BookCRUD : JsonResponse
        {
            public int BookID { get; set; }
            public string? Publisher { get; set; }
            public string? Title { get; set; }
            public string? AuthorLastName { get; set; }
            public string? AuthorFirstName { get; set; }
            public int? Price { get; set; }
        }
        public class List : Pagination
        {
            public List<BookCRUD> BookList { get; set; }
        }
    }
}
