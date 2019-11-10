using KudoCode.Web.Infrastructure.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace KudoCode.Web.Infrastructure.Blazor.Extension

{
    public static class NavigationExtensions
    {
        public static IServiceCollection AddKudoCodeNavigation(this IServiceCollection services)
        {
            return services.AddScoped<IKudoCodeNavigation, KudoCodeNavigation>();
        }
    }
}