using KudoCode.Contracts.Web;
using Microsoft.Extensions.DependencyInjection;

namespace KudoCode.Abstract.Web.Blazor

{
    public static class NavigationExtensions
    {
        public static IServiceCollection AddKudoCodeNavigation(this IServiceCollection services)
        {
            return services.AddScoped<IKudoCodeNavigation, KudoCodeNavigation>();
        }
    }
}