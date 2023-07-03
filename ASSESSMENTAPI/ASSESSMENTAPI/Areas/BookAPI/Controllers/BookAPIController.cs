using Microsoft.AspNetCore.Mvc;
using TECHINICALBAL.Repository.Common;
using static ASSESSMENTBAL.ModelClass.Books;
using static TECHINICALBAL.Models.CommonFunctions;

namespace ASSESSMENTAPI.Areas.BookAPI.Controllers
{
    [Route("api/BookAPI/[controller]")]
    [ApiController]
    public class BookAPIController : ControllerBase
    {
        internal IUnitOfWork unitofwork;
        public BookAPIController(IUnitOfWork unitOfWork)
        {
            this.unitofwork = unitOfWork;
        }
        [Route("SaveBook")]
        [HttpPost]
        public ActionResult SaveBook(BookCRUD A)
        {
            JsonResponse result = new JsonResponse();
            try
            {
                result = unitofwork.BookRepository.SaveBook(A);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var _jsonResult = unitofwork.CommonRepository.TrackExceptions(ex, "SaveBook(Area A)", "BookAPIController");
                result.Message = _jsonResult.Message;
                result.result = _jsonResult.result;
                return Ok(result);
            }
        }
        [Route("UpdateBook")]
        [HttpPost]
        public ActionResult UpdateBook(BookCRUD A)
        {
            JsonResponse result = new JsonResponse();
            try
            {
                result = unitofwork.BookRepository.UpdateBook(A);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var _jsonResult = unitofwork.CommonRepository.TrackExceptions(ex, "UpdateBook(Area A)", "BookAPIController");
                result.Message = _jsonResult.Message;
                result.result = _jsonResult.result;
                return Ok(result);
            }
        }
        [Route("BookDetail")]
        [HttpPost]
        public ActionResult BookDetail(BookCRUD E)
        {
            BookCRUD result = new BookCRUD();
            try
            {
                result = unitofwork.BookRepository.BookDetail(E);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var _jsonResult = unitofwork.CommonRepository.TrackExceptions(ex, "BookDetail(BookCRUD E)", "BookAPIController");
                result.Message = _jsonResult.Message;
                result.result = _jsonResult.result;
                return Ok(result);
            }
        }
        [Route("BookDelete")]
        [HttpPost]
        public ActionResult BookDelete(BookCRUD E)
        {
            JsonResponse result = new JsonResponse();
            try
            {
                result = unitofwork.BookRepository.BookDelete(E);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var _jsonResult = unitofwork.CommonRepository.TrackExceptions(ex, "BookDelete(BookCRUD E)", "BookAPIController");
                result.Message = _jsonResult.Message;
                result.result = _jsonResult.result;
                return Ok(result);
            }
        }
        [Route("BookList")]
        [HttpPost]
        public ActionResult BookList(Pagination E)
        {
            List result = new List();
            try
            {
                result = unitofwork.BookRepository.BookList(E);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var _jsonResult = unitofwork.CommonRepository.TrackExceptions(ex, "BookList(BookCRUD E)", "BookAPIController");
                return Ok(result);
            }
        }
        [Route("BookListSortBYAuthor")]
        [HttpPost]
        public ActionResult BookListSortBYAuthor(Pagination E)
        {
            List result = new List();
            try
            {
                result = unitofwork.BookRepository.BookListSortBYAuthor(E);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var _jsonResult = unitofwork.CommonRepository.TrackExceptions(ex, "BookListSortBYAuthor(BookCRUD E)", "BookAPIController");
                return Ok(result);
            }
        }
        [Route("GetSumOfBookPrice")]
        [HttpPost]
        public ActionResult GetSumOfBookPrice()
        {
            try
            {
                int? result = unitofwork.BookRepository.GetSumOfBookPrice();
                return Ok(result);
            }
            catch (Exception ex)
            {
                var _jsonResult = unitofwork.CommonRepository.TrackExceptions(ex, "GetSumOfBookPrice()", "BookAPIController");
                return Ok(_jsonResult);
            }
        }

        [Route("BulkInsertofBooks")]
        [HttpPost]
        public ActionResult BulkInsertofBooks(List B)
        {
            JsonResponse result = new JsonResponse();
            try
            {
                result = unitofwork.BookRepository.BulkInsertofBooks(B);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var _jsonResult = unitofwork.CommonRepository.TrackExceptions(ex, "BulkInsertofBooks(BookCRUD E)", "BookAPIController");
                return Ok(_jsonResult);
            }
        }
    }
}
