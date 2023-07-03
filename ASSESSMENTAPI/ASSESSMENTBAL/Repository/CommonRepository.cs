
using ASSESSMENTDAL.TechinicalDBContext;
using static TECHINICALBAL.Models.CommonFunctions;

namespace TECHINICALBAL.Repository
{
    public class CommonRepository : ICommonRepository
    {
        private readonly TechnicalassessmentContext context;
        public CommonRepository()
        {
           this.context = new TechnicalassessmentContext();
        }

        public JsonResponse TrackExceptions(Exception ex, string MethodName, string ControllerName)
        {
            JsonResponse obj = new JsonResponse();
            string? returnMsg = ex.Message;
            ExceptionHandling Exc = new ExceptionHandling();
            Exc.Method = MethodName;
            Exc.Module = ControllerName;
            Exc.ExceptionMessage = ex.Message;
            Exc.ExceptionSource = ex.Source;
            Exc.ExceptionStackTrace = ex.StackTrace;
            Exc.TargetSiteName = ex.TargetSite != null ? ex.TargetSite.ToString() : "";
            Exc.CreatedDate = DateTime.UtcNow;
            context.ExceptionHandlings.Add(Exc);
            context.SaveChanges();
            obj.result = false;
            obj.Message = returnMsg;
            return obj;
        }
    }
}
