using static TECHINICALBAL.Models.CommonFunctions;

namespace TECHINICALBAL.Repository
{
    public interface ICommonRepository
    {
        JsonResponse TrackExceptions(Exception ex, string MethodName, string ControllerName);
    }
}
