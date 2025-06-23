using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Application.Abstract.Services;
using OnionArchitecture.Application.Concrete;
using OnionArchitecture.Persistence.Context;
using OnionArchitecture.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IEventService, EventServices>();
            services.AddDbContext<ApplicationDbContext>();
        }
    }
}
