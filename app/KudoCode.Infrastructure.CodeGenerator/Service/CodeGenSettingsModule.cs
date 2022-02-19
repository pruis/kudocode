using System.Collections.Generic;
using Autofac;
using KudoCode.Infrastructure.CodeGenerator;

namespace KudoCode.Infrastructure.CodeGenerator
{
    public class CodeGenSettingsModule : Module
    {
        public static RequestResponsePairSettings Settings;
        public static List<string> Parameters;

        protected override void Load(ContainerBuilder builder)
        {
            //**************

            builder.RegisterInstance(
                new CodeGenSettings(Settings)
                {
                    TemplateName = $"Entity",
                    OutputName = $"{Settings.Prefix}{Settings.Entity}.cs",
                    OutputFolder =
                        $@"{Settings.ProjectFolder}\app\{Settings.ServiceDomain}KudoCode.LogicLayer.Domain\Logic\{Settings.Entity}s\Entities\",
                    Parameters = Parameters
                }
            ).Named<IGenSettings>("Entity");

            builder.RegisterInstance(
                new CodeGenSettings(Settings)
                {
                    TemplateName = $"Request",
                    OutputName = $"{Settings.Prefix}{Settings.Request}{Settings.Entity}Request.cs",
                    OutputFolder =
                        $@"{Settings.ProjectFolder}\app\KudoCode.LogicLayer.Dtos\{Settings.Entity}s\{Settings.Bound}Bound\",
                    Parameters = Parameters
                }
            ).Named<IGenSettings>("Request");

            builder.RegisterInstance(
                new CodeGenSettings(Settings)
                {
                    TemplateName = $"Response",
                    OutputName = $"{Settings.Prefix}{Settings.Request}{Settings.Entity}Response.cs",
                    OutputFolder =
                        $@"{Settings.ProjectFolder}\app\KudoCode.LogicLayer.Dtos\{Settings.Entity}s\{Settings.Bound}Bound",
                    Parameters = Parameters
                }
            ).Named<IGenSettings>("Response");

            builder.RegisterInstance(
                new CodeGenSettings(Settings)
                {
                    TemplateName = $"ViewModel",
                    OutputName = $"{Settings.Prefix}{Settings.Request}{Settings.Entity}ViewModel.cs",
                    OutputFolder =
                        $@"{Settings.ProjectFolder}\app\KudoCode.Web.Application\Models\{Settings.Entity}s\",
                    Parameters = Parameters
                }
            ).Named<IGenSettings>("ViewModel");

            //**************
            builder.RegisterInstance(
                new CodeGenSettings(Settings)
                {
                    TemplateName = $"ServiceJs",
                    OutputName = $"{Settings.Prefix}{Settings.Entity}Service.js",
                    OutputFolder =
                        $@"{Settings.ProjectFolder}\app\KudoCode.Web.Application\wwwroot\Scripts\Services\",
                    Parameters = Parameters
                }
            ).Named<IGenSettings>("ServiceJs");

            builder.RegisterInstance(
                new CodeGenSettings(Settings)
                {
                    TemplateName = "EditCshtml",
                    OutputName = $"{Settings.Prefix}Edit.cshtml",
                    OutputFolder =
                        $@"{Settings.ProjectFolder}\app\KudoCode.Web.Application\Views\{Settings.Entity}\",
                    Parameters = Parameters
                }).Named<IGenSettings>("EditCshtml");

            builder.RegisterInstance(
                new CodeGenSettings(Settings)
                {
                    TemplateName = "WebController",
                    OutputName = $"{Settings.Prefix}{Settings.Entity}Controller.cs",
                    OutputFolder = $@"{Settings.ProjectFolder}\app\KudoCode.Web.Application\Controllers\",
                    Parameters = Parameters
                }).Named<IGenSettings>("WebController");

            builder.RegisterInstance(
                new CodeGenSettings(Settings)
                {
                    TemplateName = "QueryWebHandler",
                    OutputName = $"{Settings.Prefix}{Settings.Request}{Settings.Entity}WebHandler.cs", OutputFolder =
                        $@"{Settings.ProjectFolder}\app\KudoCode.Web.Application\Handlers\",
                    Parameters = Parameters
                }).Named<IGenSettings>("QueryWebHandler");

            builder.RegisterInstance(
                new CodeGenSettings(Settings)
                {
                    TemplateName = "CommandWebHandler",
                    OutputName = $"{Settings.Prefix}{Settings.Request}{Settings.Entity}WebHandler.cs", OutputFolder =
                        $@"{Settings.ProjectFolder}\app\KudoCode.Web.Application\Handlers\",
                    Parameters = Parameters
                }).Named<IGenSettings>("CommandWebHandler");

            builder.RegisterInstance(
                new CodeGenSettings(Settings)
                {
                    TemplateName = "Connector",
                    OutputName = $"{Settings.Prefix}{Settings.Entity}Connector.cs", OutputFolder =
                        $@"{Settings.ProjectFolder}\app\KudoCode.Web.Api.Connector\",
                    Parameters = Parameters
                }).Named<IGenSettings>("Connector");

            builder.RegisterInstance(
                new CodeGenSettings(Settings)
                {
                    TemplateName = "ApiController",
                    OutputName = $"{Settings.Prefix}{Settings.Entity}Controller.cs",
                    OutputFolder = $@"{Settings.ProjectFolder}\app\KudoCode.Web.Api\Controllers\",
                    Parameters = Parameters
                }).Named<IGenSettings>("ApiController");

            builder.RegisterInstance(
                new CodeGenSettings(Settings)
                {
                    TemplateName = "AuthorizationHandler",
                    OutputFolder =
                        $@"{Settings.ProjectFolder}\app\{Settings.ServiceDomain}KudoCode.LogicLayer.Domain\Logic\{Settings.Folder}\Handlers\{Settings.Request}",
                    OutputName = $"{Settings.Request}{Settings.Entity}AuthorizationHandler.cs",
                    Parameters = Parameters
                }).Named<IGenSettings>("AuthorizationHandler");

            builder.RegisterInstance(
                new CodeGenSettings(Settings)
                {
                    TemplateName = $"HandlerTest",
                    OutputName = $"{Settings.Request}{Settings.Entity}AuthorizationUnitTest.cs",
                    OutputFolder =
                        $@"{Settings.ProjectFolder}\app\{Settings.ServiceTest}KudoCode.Test.Unit\{Settings.Folder}\{Settings.Request}",
                    Parameters = new List<string>()
                    {
                        $"<%request%>:{Settings.Request}",
                        $"<%entity%>:{Settings.Entity}",
                        $"<%response%>:{Settings.Response}",
                        $"<%folder%>:{Settings.Folder}",
                        $"<%service%>:{Settings.ServiceDomain.Replace(@"Domain\","").Replace(@"\",".")}",
                        $"<%type%>:Authorization"
                    }
                }).Named<IGenSettings>("AuthorizationUnitTest");

            builder.RegisterInstance(
                new CodeGenSettings(Settings)
                {
                    TemplateName = "ValidationHandler",
                    OutputFolder =
                        $@"{Settings.ProjectFolder}\app\{Settings.ServiceDomain}KudoCode.LogicLayer.Domain\Logic\{Settings.Folder}\Handlers\{Settings.Request}",
                    OutputName = $"{Settings.Request}{Settings.Entity}ValidationHandler.cs"
                        .Replace("Command", "Worker")
                        .Replace("Query", "Worker"),
                    Parameters = Parameters
                }).Named<IGenSettings>("ValidationHandler");

            builder.RegisterInstance(
                new CodeGenSettings(Settings)
                {
                    TemplateName = $"HandlerTest",
                    OutputName = $"{Settings.Request}{Settings.Entity}ValidationUnitTest.cs",
                    OutputFolder =
                        $@"{Settings.ProjectFolder}\app\{Settings.ServiceTest}KudoCode.Test.Unit\{Settings.Folder}\{Settings.Request}",
                    Parameters = new List<string>()
                    {
                        $"<%request%>:{Settings.Request}",
                        $"<%entity%>:{Settings.Entity}",
                        $"<%response%>:{Settings.Response}",
                        $"<%folder%>:{Settings.Folder}",
                        $"<%service%>:{Settings.ServiceDomain.Replace(@"Domain\","").Replace(@"\",".")}",
                       $"<%type%>:Validation"
                    }
                }).Named<IGenSettings>("ValidationUnitTest");

            builder.RegisterInstance(
                new CodeGenSettings(Settings)
                {
                    TemplateName = "CommandHandler",
                    OutputFolder =
                        $@"{Settings.ProjectFolder}\app\{Settings.ServiceDomain}KudoCode.LogicLayer.Domain\Logic\{Settings.Folder}\Handlers\{Settings.Request}",
                    OutputName = $"{Settings.Request}{Settings.Entity}WorkerHandler.cs",
                    Parameters = Parameters
                }).Named<IGenSettings>("CommandHandler");

            builder.RegisterInstance(
                new CodeGenSettings(Settings)
                {
                    TemplateName = "QueryHandler",
                    OutputFolder =
                        $@"{Settings.ProjectFolder}\app\{Settings.ServiceDomain}KudoCode.LogicLayer.Domain\Logic\{Settings.Folder}\Handlers\{Settings.Request}",
                    OutputName = $"{Settings.Request}{Settings.Entity}WorkerHandler.cs",
                    Parameters = Parameters
                }).Named<IGenSettings>("QueryHandler");

            builder.RegisterInstance(
                new CodeGenSettings(Settings)
                {
                    TemplateName = $"HandlerTest",
                    OutputName = $"{Settings.Request}{Settings.Entity}WorkerUnitTest.cs",
                    OutputFolder =
                        $@"{Settings.ProjectFolder}\app\{Settings.ServiceTest}KudoCode.Test.Unit\{Settings.Folder}\{Settings.Request}",
                    Parameters = new List<string>()
                    {
                        $"<%request%>:{Settings.Request}",
                        $"<%entity%>:{Settings.Entity}",
                        $"<%response%>:{Settings.Response}",
                        $"<%folder%>:{Settings.Folder}",
                        $"<%service%>:{Settings.ServiceDomain.Replace(@"Domain\","").Replace(@"\",".")}",
                        $"<%type%>:Worker"
                            .Replace("Handler", "")
                            .Replace("Command", "Worker")
                            .Replace("Query", "Worker"),
                    }
                }).Named<IGenSettings>("WorkerUnitTest");
        }
    }
}