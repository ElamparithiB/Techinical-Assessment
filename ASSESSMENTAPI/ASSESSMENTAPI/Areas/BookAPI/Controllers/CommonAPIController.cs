using Microsoft.AspNetCore.Mvc;
using TECHINICALBAL.Repository.Common;
using static TECHINICALBAL.Models.CommonFunctions;

namespace TECHNICAL_ASSESSMENT.Areas.BooksAPI.Controllers
{
    [Route("api/BookAPI/[controller]")]
    [ApiController]
    public class CommonAPIController : ControllerBase
    {
        internal IUnitOfWork unitofwork;
        public CommonAPIController(IUnitOfWork unitOfWork)
        {
            this.unitofwork = unitOfWork;
        }

        [Route("TrackException")]
        [HttpPost]
        public ActionResult TrackException(Exception Ex, string MethodName, string ControllerName, int UserId)
        {
            try
            {
                JsonResponse obj = new JsonResponse();
                obj = unitofwork.CommonRepository.TrackExceptions(Ex, MethodName, ControllerName);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                var _jsonResult = unitofwork.CommonRepository.TrackExceptions(ex, "TrackExceptions(ExceptionTracking Ex)", "CommonAPIController");
                return Ok(_jsonResult);
            }
        }
    }
}
