using Microsoft.Extensions.DependencyInjection;
using WebApp.MVC.Services;

namespace WebApp.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddHttpClient<IEncontrarDivisoresService, EncontrarDivisoresService>();
        }
    }
}
