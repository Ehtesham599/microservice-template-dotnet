using Microsoft.Extensions.DependencyInjection;

namespace External
{
    public static class DependencyInjection
    {
        public static void AddExternal(this IServiceCollection services)
        {
            services.AddSingleton<IHttpClient, External.HttpClient>();
        }
    }
}
