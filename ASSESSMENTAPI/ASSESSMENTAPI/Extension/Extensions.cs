using ASSESSMENTBAL.Repository;
using TECHINICALBAL.Repository;
using TECHINICALBAL.Repository.Common;

namespace TECHNICAL_ASSESSMENT.Extension
{
    public static class Extensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICommonRepository, CommonRepository>();
            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
