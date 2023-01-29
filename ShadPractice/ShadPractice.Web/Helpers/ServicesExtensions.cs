using ShadPractice.Core.Interfaces;
using ShadPractice.Infrastructure.Services;

namespace ShadPractice.Web.Helpers
{
    public static class ServicesExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
