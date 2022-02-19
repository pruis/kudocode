using Autofac;
using CodeGenerator.Service;
using KudoCode.Contracts.Api;
using KudoCode.Infrastructure.CodeGenerator;
using KudoCode.Infrastructure.CodeGenerator;
using System;
using System.Collections.Generic;

namespace CodeGenerator
{
	class Program
	{
		static void Main(string[] args)
		{
//			return;
			Go("Delete", "Company", "In", "",
				new Dictionary<string, bool>()
				{
					{"Entity", false},
					{"Request", true},
					{"Response", true},
					{"ViewModel", false},

					{"ServiceJs", false},
					{"EditCshtml", false},
					{"WebController", false},

					{"QueryWebHandler", false},
					{"CommandWebHandler", false},

					{"AuthorizationHandler", true},
					{"AuthorizationUnitTest", true},

					{"ValidationHandler", true},
					{"ValidationUnitTest", true},

					{"CommandHandler", true},
					{"QueryHandler", false},
					{"WorkerUnitTest", true},
				}
			);
		}

		private static void Go(string request, string entity, string bond, string preFix,
			Dictionary<string, bool> runGenerators)
		{
			var settings = new RequestResponsePairSettings()
			{
				ProjectFolder = @"C:\Projects\kudocode.pvt\",
				Folder = $"{entity}s",
				Response = $"{request}{entity}Response",
				Bound = bond, //In or Out
				Prefix = preFix,
				Entity = entity,
				Request = request,
			};

			CodeGenSettingsModule.Parameters = new List<string>()
			{
				$"<%request%>:{settings.Request}",
				$"<%entity%>:{settings.Entity}",
				$"<%response%>:{settings.Response}",
				$"<%folder%>:{settings.Folder}",
			};


			CodeGenSettingsModule.Settings = settings;
			ApplicationContext.Container = ContainerInstaller.BuildContainer();

			foreach (var generator in runGenerators)
			{
				try
				{
					if (!generator.Value)
						continue;

					var x = ApplicationContext.Container
						.ResolveNamed<IGenSettings>(generator.Key);
					ApplicationContext.Container
						.Resolve<IGenerate>().Generate(x);
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
					throw;
				}
			}
		}
	}
}