using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

//https://remibou.github.io/Configuring-a-Blazor-app/
namespace KudoCode.Mobile.Infrastructure.Blazor
{
    public static class Reader
    {
        public static void AddEnvironmentConfiguration<TResource>(
            this IServiceCollection serviceCollection,
            Func<EnvironmentChooser> environmentChooserFactory)
        {
            serviceCollection.AddSingleton<IConfiguration>((s) =>
            {
                var configurationBuilder = ConfigurationBuilder<TResource>(environmentChooserFactory);

                return configurationBuilder.Build();
            });
        }

        public static ConfigurationBuilder ConfigurationBuilder<TResource>(
            Func<EnvironmentChooser> environmentChooserFactory)
        {
            var environementChooser = environmentChooserFactory();
            var environment = "development";

            try
            {
                //var uri = new Uri(s.GetRequiredService<NavigationManager>().GetAbsoluteUri());
                // environment = environementChooser.GetCurrent(uri);
            }
            catch (Exception)
            {
            }

            System.Reflection.Assembly assembly = typeof(TResource).Assembly;
            var ressourceNames = new[]
            {
                assembly.GetName().Name + ".appsettings.json",
                assembly.GetName().Name + ".appsettings." + environment + ".json"
            };
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddInMemoryCollection(new Dictionary<string, string>()
            {
                {"Environment", environment}
            });
            Console.WriteLine(string.Join(",", assembly.GetManifestResourceNames()));
            Console.WriteLine(string.Join(",", ressourceNames));
            foreach (var resource in ressourceNames)
            {
                if (((IList) assembly.GetManifestResourceNames()).Contains(resource))
                {
                    using (var stream = assembly.GetManifestResourceStream(resource))
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            configurationBuilder.AddJsonFile(
                                new InMemoryFileProvider(reader.ReadToEnd()), resource, false, false);
                            Console.WriteLine($"ADDED: {resource}");
                        }
                    }
                }
            }

            return configurationBuilder;
        }
    }
}