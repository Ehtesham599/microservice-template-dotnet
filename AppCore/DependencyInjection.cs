
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AppCore
{
    public static class DependencyInjection
    {
        public static void AddAppCore(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
