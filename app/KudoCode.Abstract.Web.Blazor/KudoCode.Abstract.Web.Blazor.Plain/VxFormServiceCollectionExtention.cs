using Microsoft.Extensions.DependencyInjection;
using VxFormGenerator.Repository.Plain;

namespace KudoCode.Abstract.Web.Blazor
{
    public static class ServiceCollectionExtensions
    {
        public static void AddVxFormGeneratorPlain(this IServiceCollection services, VxFormLayoutOptions vxFormLayoutOptions = null, VxComponentsRepository repository = null, VxFormOptions options = null)
        {
            FormGeneratorCoreServiceServiceCollectionExtension.AddVxFormGenerator(services, 
                vxFormLayoutOptions ?? new VxFormLayoutOptions(),
                repository ?? new VxComponentsRepository(), 
                options ?? new VxFormOptions());
        }

    }
}
