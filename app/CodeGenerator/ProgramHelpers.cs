using Autofac;
using CodeGenerator.Service;
using KudoCode.Contracts;
using KudoCode.Contracts.Api;
using KudoCode.Infrastructure.CodeGenerator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace CodeGenerator
{
    internal static class ProgramHelpers
    {
        internal static void Go(RequestResponsePairSettings settings, List<string> runGenerators, List<string> properties)
        {

            CodeGenSettingsModule.Settings = settings;
            ApplicationContext.Container = ContainerInstaller.BuildContainer();

            using (var scope = ApplicationContext.Container.BeginLifetimeScope("ExecutionPipeline"))
            {
                foreach (var generator in runGenerators)
                {
                    try
                    {
                        var genSettings = scope.ResolveNamed<IGenSettings>(generator);
                        genSettings.Properties = properties;
                        genSettings.TemplatePath = @"Logic\Templates\";
                        scope.Resolve<GenerateHandler>().Generate(genSettings);
                    }
                    catch (Exception e)
                    {
                        Debugger.Break();
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            ApplicationContext.Container.Dispose();
            ApplicationContext.Container = null;
        }
    }
}