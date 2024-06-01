using KudoCode.Abstract.Web.Blazor;
using KudoCode.Contracts;
using KudoCode.Contracts.Web;
using Microsoft.Extensions.DependencyInjection;
using VxFormGenerator.Repository.Bootstrap;

namespace VxFormGenerator.Settings.Bootstrap
{
    public static class ServiceCollectionExtensions
    {
        public static void AddVxFormGeneratorBootstrap(this IServiceCollection services, VxFormLayoutOptions vxFormLayoutOptions = null, VxBootstrapRepository repository = null, VxBootstrapFormOptions options = null)
        {
            services.AddScoped<AppState>();
            //services.AddSingleton(new AppState());
            //services.AddSingleton<IGetLookupResponse>(new GetLookupResponse());

            FormGeneratorCoreServiceServiceCollectionExtension.AddVxFormGenerator(services,
                vxFormLayoutOptions ?? new VxFormLayoutOptions(),
                repository ?? new VxBootstrapRepository(),
                options ?? new VxBootstrapFormOptions()
                );
        }
    }
}
