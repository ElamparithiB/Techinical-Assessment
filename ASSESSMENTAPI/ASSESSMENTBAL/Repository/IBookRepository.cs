using static ASSESSMENTBAL.ModelClass.Books;
using static TECHINICALBAL.Models.CommonFunctions;

namespace ASSESSMENTBAL.Repository
{
    public interface IBookRepository
    {
        JsonResponse SaveBook(BookCRUD A);
        JsonResponse UpdateBook(BookCRUD A);
        BookCRUD BookDetail(BookCRUD A);
        JsonResponse BookDelete(BookCRUD A);
        List BookList(Pagination A);
        List BookListSortBYAuthor(Pagination A);
        int? GetSumOfBookPrice();
        JsonResponse BulkInsertofBooks(List A);
    }
}
