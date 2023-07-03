namespace ASSESSMENTWEB.Models
{
    public class CommonFunctions
    {
        public class Pagination : JsonResponse
        {
            public int TotalRow { get; set; }
            public int PageSize { get; set; }
            public int PageNumber { get; set; }
            public int PageCount { get; set; }
            public int? OrganizationID { get; set; }
            public string? SearchString { get; set; }
            public string? TimeZone { get; set; }
            public string? Flag { get; set; }
            public string? Sort { get; set; }
        }
        public class JsonResponse
        {
            public bool result { get; set; }
            public string? Message { get; set; }
        }
    }
}
