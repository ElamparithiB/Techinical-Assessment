using ASSESSMENTDAL.TechinicalDBContext;
using Microsoft.EntityFrameworkCore;
using TECHINICALBAL.Repository;
using static ASSESSMENTBAL.ModelClass.Books;
using static TECHINICALBAL.Models.CommonFunctions;

namespace ASSESSMENTBAL.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly TechnicalassessmentContext context;
        private readonly ICommonRepository CommonRepository;
        public BookRepository(ICommonRepository commonRepository)
        {
            this.context = new TechnicalassessmentContext();
            this.CommonRepository = commonRepository;
        }

        public JsonResponse SaveBook(BookCRUD A)
        {
            JsonResponse result = new JsonResponse();
            try
            {
                Book reg = new Book();
                reg.Publisher = A.Publisher != null ? A.Publisher.Trim() : "";
                reg.Title = A.Title != null ? A.Title.Trim() : "";
                reg.AuthorFirstName = A.AuthorFirstName != null ? A.AuthorFirstName.Trim() : "";
                reg.AuthorLastName = A.AuthorLastName != null ? A.AuthorLastName.Trim() : "";
                reg.Price = A.Price;
                reg.CreatedDate = DateTime.UtcNow;
                context.Books.Add(reg);
                context.SaveChanges();
                result.result = true;
                result.Message = "Book has been saved successfully";
            }
            catch (Exception ex)
            {
                var _jsonResult = this.CommonRepository.TrackExceptions(ex, "SaveBook(Area A)", "BookRepository");
                result.result = _jsonResult.result;
                result.Message = _jsonResult.Message;
            }
            return result;
        }

        public JsonResponse UpdateBook(BookCRUD A)
        {
            JsonResponse result = new JsonResponse();
            try
            {
                Book reg = new Book();
                Book? BookInfo = context.Books.Where(a => a.BookId == A.BookID).FirstOrDefault();
                if (BookInfo != null)
                {
                    BookInfo.Publisher = A.Publisher != null ? A.Publisher.Trim() : "";
                    BookInfo.Title = A.Title != null ? A.Title.Trim() : "";
                    BookInfo.AuthorFirstName = A.AuthorFirstName != null ? A.AuthorFirstName.Trim() : "";
                    BookInfo.AuthorLastName = A.AuthorLastName != null ? A.AuthorLastName.Trim() : "";
                    BookInfo.Price = A.Price;
                    BookInfo.UpdatedDate = DateTime.UtcNow;
                    context.SaveChanges();
                    result.result = true;
                    result.Message = "Book has been updated successfully";
                }
                else
                {
                    result.result = false;
                    result.Message = "Something went wrong";
                }
            }
            catch (Exception ex)
            {
                var _jsonResult = this.CommonRepository.TrackExceptions(ex, "UpdateBook(Area A)", "BookRepository");
                result.result = _jsonResult.result;
                result.Message = _jsonResult.Message;
            }
            return result;
        }
        public BookCRUD BookDetail(BookCRUD E)
        {
            BookCRUD r = new BookCRUD();
            try
            {
                var res = context.Books.AsNoTracking().Where(x => x.BookId == E.BookID).FirstOrDefault();
                if (res != null)
                {
                    r.Publisher = res.Publisher;
                    r.Title = res.Title;
                    r.AuthorFirstName = res.AuthorFirstName;
                    r.AuthorLastName = res.AuthorLastName;
                    r.Price = res.Price;
                }
                r.result = true;
            }
            catch (Exception ex)
            {
                var _jsonResult = this.CommonRepository.TrackExceptions(ex, "BookDetail(BookCRUD E)", "BookRepository");
                r.Message = _jsonResult.Message;
                r.result = false;
                return r;
            }
            return r;
        }
        public JsonResponse BookDelete(BookCRUD E)
        {
            JsonResponse r = new JsonResponse();
            try
            {
                Book? res = context.Books.AsNoTracking().Where(x => x.BookId == E.BookID).FirstOrDefault();
                if (res != null)
                {
                    context.Books.Remove(res);
                    context.SaveChanges();
                }
                r.Message = "Book has been deleted successfully";
                r.result = true;
            }
            catch (Exception ex)
            {
                var _jsonResult = this.CommonRepository.TrackExceptions(ex, "BookDelete(BookCRUD E)", "BookRepository");
                r.Message = _jsonResult.Message;
                r.result = false;
                return r;
            }
            return r;
        }
        public List BookList(Pagination B)
        {
            List r = new List();
            try
            {
                string StoredProc = "exec sp_ListBook " +
                                    "@PageNumber = '" + B.PageNumber + "'," +
                                    "@PageSize = '" + B.PageSize + "'," +
                                    "@sort = '" + B.Sort + "'," +
                                    "@StrSearch = '" + B.SearchString + "'";

                var FinanicalImpactList = context.BookList.FromSqlRaw(StoredProc).ToList();

                r.BookList = (from s in context.BookList.FromSqlRaw(StoredProc).ToList()
                                                           select new
                                                           BookCRUD
                                                           {
                                                               BookID = s.BookID,
                                                               Publisher = s.Publisher,
                                                               Title = s.Title,
                                                               AuthorFirstName = s.AuthorFirstName,
                                                               AuthorLastName = s.AuthorLastName,
                                                               Price = s.Price
                                                           }).ToList();
                return r;
            }
            catch (Exception ex)
            {
                var _jsonResult = this.CommonRepository.TrackExceptions(ex, "BookDelete(BookCRUD E)", "BookRepository");
                return r;
            }
        }
        public List BookListSortBYAuthor(Pagination B)
        {
            List r = new List();
            try
            {
                string StoredProc = "exec sp_ListBook " +
                                    "@PageNumber = '" + B.PageNumber + "'," +
                                    "@PageSize = '" + B.PageSize + "'," +
                                    "@sort = '" + B.Sort + "'," +
                                    "@StrSearch = '" + B.SearchString + "'";

                var FinanicalImpactList = context.BookList.FromSqlRaw(StoredProc).ToList();

                r.BookList = (from s in context.BookList.FromSqlRaw(StoredProc).ToList()
                                                           select new
                                                           BookCRUD
                                                           {
                                                               BookID = s.BookID,
                                                               Publisher = s.Publisher,
                                                               Title = s.Title,
                                                               AuthorFirstName = s.AuthorFirstName,
                                                               AuthorLastName = s.AuthorLastName,
                                                               Price = s.Price
                                                           }).ToList();
                return r;
            }
            catch (Exception ex)
            {
                var _jsonResult = this.CommonRepository.TrackExceptions(ex, "BookListSortBYAuthor(BookCRUD E)", "BookRepository");
                return r;
            }
        }
        public int? GetSumOfBookPrice()
        {
            int? r = 0;
            try
            {
                var list = context.Books.AsNoTracking().ToList();
                foreach (var book in list) 
                {
                    r = r + book.Price;
                }
            }
            catch (Exception ex)
            {
                var _jsonResult = this.CommonRepository.TrackExceptions(ex, "GetSumOfBookPrice()", "BookRepository");
                return r;
            }
            return r;
        }
        public JsonResponse BulkInsertofBooks(List B)
        {
            JsonResponse result = new JsonResponse();
            try
            {
                foreach (var item in B.BookList)
                {
                    Book reg = new Book();
                    reg.Publisher = item.Publisher != null ? item.Publisher.Trim() : "";
                    reg.Title = item.Title != null ? item.Title.Trim() : "";
                    reg.AuthorFirstName = item.AuthorFirstName != null ? item.AuthorFirstName.Trim() : "";
                    reg.AuthorLastName = item.AuthorLastName != null ? item.AuthorLastName.Trim() : "";
                    reg.Price = item.Price;
                    reg.CreatedDate = DateTime.UtcNow;
                    context.Books.Add(reg);
                    context.SaveChanges();
                }
                result.result = true;
                result.Message = "Book has been updated successfully";
                return result;
            }
            catch (Exception ex)
            {
                var _jsonResult = this.CommonRepository.TrackExceptions(ex, "BulkInsertofBooks(List B)", "BookRepository");
                return _jsonResult;
            }
        }
    }
}
