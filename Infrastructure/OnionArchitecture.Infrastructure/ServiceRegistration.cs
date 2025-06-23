using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Application.Abstract.Services;
using OnionArchitecture.Infrastructure.Services;

namespace OnionArchitecture.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ITextServices, TextService>();
        }
    }
}
