using KudoCode.Abstract.Web.Blazor.Repository;
using KudoCode.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace KudoCode.Abstract.Web.Blazor
{
    public static class FormGeneratorCoreServiceServiceCollectionExtension
	{
		public static void AddVxFormGenerator(IServiceCollection services, VxFormLayoutOptions vxFormLayoutOptions = null, IFormGeneratorComponentsRepository repository = null, IFormGeneratorOptions options = null)
		{

			if (vxFormLayoutOptions == null)
				throw new System.Exception("No layout options provided, please refer to the documentation.");

			if (repository == null)
				throw new System.Exception("No repository provided, please refer to the documentation.");

			if (options == null)
				throw new System.Exception("No options provided, please refer to the documentation.");


			services.AddSingleton(typeof(IFormGeneratorComponentsRepository), repository);

			services.AddSingleton(typeof(IFormGeneratorComponentsRepository), repository);
			services.AddSingleton(typeof(IFormGeneratorOptions), options);
			services.AddSingleton(typeof(VxFormLayoutOptions), vxFormLayoutOptions);

			services.AddSingleton(typeof(IListTableConfigStore), typeof(ListTableConfigStore));
			services.AddSingleton(typeof(IConvertToObjectDictionary), typeof(ConvertToObjectDictionary));
			services.AddSingleton(typeof(IConvertToObject), typeof(ConvertToObject));

		}
	}

}
