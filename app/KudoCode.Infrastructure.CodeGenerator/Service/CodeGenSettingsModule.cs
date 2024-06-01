using System.Collections.Generic;
using Autofac;
using KudoCode.Contracts;
using KudoCode.Infrastructure.CodeGenerator;

namespace KudoCode.Infrastructure.CodeGenerator
{

    public class GenericTable : CodeGenSettings
    {
        public GenericTable(RequestResponsePairSettings settings) : base()
        {
            TemplateName = $"GenericTable";
            OutputName = $"{settings.Get("Entity")}GenericTable.template";
            OutputFolder = settings.Get("DirGenericTable").Replace("<%entity%>", settings.Get("Entity")).Replace("<%projectfolder%>", settings.Get("ProjectFolder"));
            Parameters = settings.Parameters;
        }
    }

    public class CodeGenSettingsModule : Module
    {
        public static RequestResponsePairSettings Settings;
        //public static List<string> Parameters;

        protected override void Load(ContainerBuilder builder)
        {
            //**************

            builder.RegisterInstance(Settings);
            builder.RegisterType<GenericTable>().Named<IGenSettings>("GenericTable");


            builder.RegisterInstance(

                new CodeGenSettings()
                {
                    TemplateName = $"AutoMapper",
                    OutputName = $"{Settings.Get("Entity")}AutoMappper.cs",
                    //OutputFolder = $@"{Settings.Get("ProjectFolder")}\APIs\{Settings.Get("Service")}Service\Domain\KudoCode.LogicLayer.Domain\Logic\{Settings.Get("FolderEntity")}\AutoMapper",
                    OutputFolder = Settings.Get("DirAutoMapper").Replace("<%entity%>", Settings.Get("Entity")).Replace("<%projectfolder%>", Settings.Get("ProjectFolder")),
                    Parameters = Settings.Parameters
                    ,Settings = Settings
                }
            ).Named<IGenSettings>("AutoMapper");


            builder.RegisterInstance(
                new CodeGenSettings()
                {
                    TemplateName = $"ListResponse",
                    OutputName = $"{Settings.Get("Request")}{Settings.Get("Entity")}Response.cs",
                    OutputFolder = Settings.Get("DirDto").Replace("<%entity%>", Settings.Get("Entity")).Replace("<%projectfolder%>", Settings.Get("ProjectFolder")),
                    Parameters = Settings.Parameters
                    ,
                    Settings = Settings
                }
            ).Named<IGenSettings>("ListResponse");

            builder.RegisterInstance(
                new CodeGenSettings()
                {
                    TemplateName = $"SaveWorkerUnitTest",
                    OutputName = $"{Settings.Get("Request")}{Settings.Get("Entity")}WorkerUnitTest.cs",
                    OutputFolder = Settings.Get("DirUnitTest")
                        .Replace("<%entity%>", Settings.Get("Entity"))
                        .Replace("<%request%>", Settings.Get("Request"))
                        .Replace("<%projectfolder%>", Settings.Get("ProjectFolder")),
                    Parameters = Settings.Parameters
                    ,
                    Settings = Settings
                }).Named<IGenSettings>("SaveWorkerUnitTest");

            builder.RegisterInstance(
                new CodeGenSettings()
                {
                    TemplateName = $"DeleteWorkerUnitTest",
                    OutputName = $"{Settings.Get("Request")}{Settings.Get("Entity")}WorkerUnitTest.cs",
                    OutputFolder = Settings.Get("DirUnitTest")
                        .Replace("<%entity%>", Settings.Get("Entity"))
                        .Replace("<%request%>", Settings.Get("Request"))
                        .Replace("<%projectfolder%>", Settings.Get("ProjectFolder")),
                    Parameters = Settings.Parameters
                    ,
                    Settings = Settings
                }).Named<IGenSettings>("DeleteWorkerUnitTest");

            builder.RegisterInstance(
                new CodeGenSettings()
                {
                    TemplateName = $"ListWorkerUnitTest",
                    OutputName = $"{Settings.Get("Request")}{Settings.Get("Entity")}WorkerUnitTest.cs",
                    OutputFolder = Settings.Get("DirUnitTest")
                        .Replace("<%entity%>", Settings.Get("Entity"))
                        .Replace("<%request%>", Settings.Get("Request"))
                        .Replace("<%projectfolder%>", Settings.Get("ProjectFolder")),
                    Parameters = Settings.Parameters
                    ,
                    Settings = Settings
                }).Named<IGenSettings>("ListWorkerUnitTest");

            builder.RegisterInstance(
                new CodeGenSettings()
                {
                    TemplateName = $"GetWorkerUnitTest",
                    OutputName = $"{Settings.Get("Request")}{Settings.Get("Entity")}WorkerUnitTest.cs",
                    OutputFolder = Settings.Get("DirUnitTest")
                        .Replace("<%entity%>", Settings.Get("Entity"))
                        .Replace("<%request%>", Settings.Get("Request"))
                        .Replace("<%projectfolder%>", Settings.Get("ProjectFolder")),
                    Parameters = Settings.Parameters
                    ,
                    Settings = Settings
                }).Named<IGenSettings>("GetWorkerUnitTest");

            builder.RegisterInstance(
                new CodeGenSettings()
                {
                    TemplateName = "SaveWH",
                    OutputFolder = Settings.Get("DirHandler")
                        .Replace("<%entity%>", Settings.Get("Entity"))
                        .Replace("<%request%>", Settings.Get("Request"))
                        .Replace("<%projectfolder%>", Settings.Get("ProjectFolder")),
                    OutputName = $"{Settings.Get("Request")}{Settings.Get("Entity")}WorkerHandler.cs",
                    Parameters = Settings.Parameters
                    ,
                    Settings = Settings
                }).Named<IGenSettings>("SaveWH");

            builder.RegisterInstance(
                new CodeGenSettings()
                {
                    TemplateName = "DeleteWH",
                    OutputFolder = Settings.Get("DirHandler")
                        .Replace("<%entity%>", Settings.Get("Entity"))
                        .Replace("<%request%>", Settings.Get("Request"))
                        .Replace("<%projectfolder%>", Settings.Get("ProjectFolder")),
                    OutputName = $"{Settings.Get("Request")}{Settings.Get("Entity")}WorkerHandler.cs",
                    Parameters = Settings.Parameters
                    ,
                    Settings = Settings
                }).Named<IGenSettings>("DeleteWH");

            builder.RegisterInstance(
                new CodeGenSettings()
                {
                    TemplateName = "GetWH",
                    OutputFolder = Settings.Get("DirHandler")
                        .Replace("<%entity%>", Settings.Get("Entity"))
                        .Replace("<%request%>", Settings.Get("Request"))
                        .Replace("<%projectfolder%>", Settings.Get("ProjectFolder")),
                    OutputName = $"{Settings.Get("Request")}{Settings.Get("Entity")}WorkerHandler.cs",
                    Parameters = Settings.Parameters
                    ,
                    Settings = Settings
                }).Named<IGenSettings>("GetWH");

            builder.RegisterInstance(
                new CodeGenSettings()
                {
                    TemplateName = "ListWH",
                    OutputFolder = Settings.Get("DirHandler")
                        .Replace("<%entity%>", Settings.Get("Entity"))
                        .Replace("<%request%>", Settings.Get("Request"))
                        .Replace("<%projectfolder%>", Settings.Get("ProjectFolder")),
                    OutputName = $"{Settings.Get("Request")}{Settings.Get("Entity")}WorkerHandler.cs",
                    Parameters = Settings.Parameters
                    ,
                    Settings = Settings
                }).Named<IGenSettings>("ListWH");

            builder.RegisterInstance(
                new CodeGenSettings()
                {
                    TemplateName = $"Entity",
                    OutputName = $"{Settings.Get("Entity")}.cs",
                    OutputFolder = Settings.Get("DirEntity").Replace("<%entity%>", Settings.Get("Entity")).Replace("<%projectfolder%>", Settings.Get("ProjectFolder")),
                    Parameters = Settings.Parameters
                    ,
                    Settings = Settings
                }
            ).Named<IGenSettings>("Entity");

            builder.RegisterInstance(
                new CodeGenSettings()
                {
                    TemplateName = $"Request",
                    OutputName = $"{Settings.Get("Request")}{Settings.Get("Entity")}Request.cs",
                    OutputFolder = Settings.Get("DirDto").Replace("<%entity%>", Settings.Get("Entity")).Replace("<%projectfolder%>", Settings.Get("ProjectFolder")),
                    Parameters = Settings.Parameters
                    ,
                    Settings = Settings
                }
            ).Named<IGenSettings>("Request");

            builder.RegisterInstance(
                new CodeGenSettings()
                {
                    TemplateName = $"Response",
                    OutputName = $"{Settings.Get("Request")}{Settings.Get("Entity")}Response.cs",
                    OutputFolder = Settings.Get("DirDto").Replace("<%entity%>", Settings.Get("Entity")).Replace("<%projectfolder%>", Settings.Get("ProjectFolder")),
                    Parameters = Settings.Parameters
                    ,
                    Settings = Settings
                }
            ).Named<IGenSettings>("Response");

            builder.RegisterInstance(
                new CodeGenSettings()
                {
                    TemplateName = $"ViewModel",
                    OutputName = $"{Settings.Get("Entity")}ViewModel.cs",
                    OutputFolder = Settings.Get("DirViewModel").Replace("<%entity%>", Settings.Get("Entity")).Replace("<%projectfolder%>", Settings.Get("ProjectFolder")),
                    Parameters = Settings.Parameters
                    ,
                    Settings = Settings
                }
            ).Named<IGenSettings>("ViewModel");



            builder.RegisterInstance(
                new CodeGenSettings()
                {
                    TemplateName = "AuthorizationHandler",
                    OutputName = $"{Settings.Get("Request")}{Settings.Get("Entity")}AuthorizationHandler.cs",
                    OutputFolder = Settings.Get("DirHandler")
                        .Replace("<%entity%>", Settings.Get("Entity"))
                        .Replace("<%request%>", Settings.Get("Request"))
                        .Replace("<%projectfolder%>", Settings.Get("ProjectFolder")),
                    Parameters = Settings.Parameters
                    ,
                    Settings = Settings
                }).Named<IGenSettings>("AuthorizationHandler");

            builder.RegisterInstance(
                new CodeGenSettings()
                {
                    TemplateName = $"HandlerTest",
                    OutputName = $"{Settings.Get("Request")}{Settings.Get("Entity")}AuthorizationUnitTest.cs",
                    OutputFolder = Settings.Get("DirUnitTest")
                        .Replace("<%entity%>", Settings.Get("Entity"))
                        .Replace("<%request%>", Settings.Get("Request"))
                        .Replace("<%projectfolder%>", Settings.Get("ProjectFolder"))
                    ,
                    Settings = Settings,
                    Parameters = new List<string>()
                    {
                        $"<%request%>:{Settings.Get("Request")}",
                        $"<%entity%>:{Settings.Get("Entity")}",
                        $"<%response%>:{Settings.Get("Response")}",
                        $"<%folder%>:{Settings.Get("Folder")}",
                        $"<%service%>:{Settings.Get("Service")}",
                        $"<%type%>:Authorization"
                    }
                }).Named<IGenSettings>("AuthorizationUnitTest");

            builder.RegisterInstance(
                new CodeGenSettings()
                {
                    TemplateName = "VH",
                    OutputFolder = Settings.Get("DirHandler")
                        .Replace("<%entity%>", Settings.Get("Entity"))
                        .Replace("<%request%>", Settings.Get("Request"))
                        .Replace("<%projectfolder%>", Settings.Get("ProjectFolder")),
                    OutputName = $"{Settings.Get("Request")}{Settings.Get("Entity")}ValidationHandler.cs"
                        .Replace("Command", "Worker")
                        .Replace("Query", "Worker"),
                    Parameters = Settings.Parameters
                }).Named<IGenSettings>("VH");

            builder.RegisterInstance(
                new CodeGenSettings()
                {
                    TemplateName = $"ValidationUnitTest",
                    OutputName = $"{Settings.Get("Request")}{Settings.Get("Entity")}ValidationUnitTest.cs",
                    OutputFolder = Settings.Get("DirUnitTest")
                        .Replace("<%entity%>", Settings.Get("Entity"))
                        .Replace("<%request%>", Settings.Get("Request"))
                        .Replace("<%projectfolder%>", Settings.Get("ProjectFolder")),
                    Parameters = Settings.Parameters
                    ,
                    Settings = Settings
                }).Named<IGenSettings>("ValidationUnitTest");

            builder.RegisterInstance(
                new CodeGenSettings()
                {
                    TemplateName = "WH",
                    OutputFolder = Settings.Get("DirHandler")
                        .Replace("<%entity%>", Settings.Get("Entity"))
                        .Replace("<%request%>", Settings.Get("Request"))
                        .Replace("<%projectfolder%>", Settings.Get("ProjectFolder")),
                    OutputName = $"{Settings.Get("Request")}{Settings.Get("Entity")}WorkerHandler.cs",
                    Parameters = Settings.Parameters
                    ,
                    Settings = Settings
                }).Named<IGenSettings>("WH");

            builder.RegisterInstance(
                new CodeGenSettings()
                {
                    TemplateName = "QueryHandler",
                    OutputFolder = Settings.Get("DirHandler")
                        .Replace("<%entity%>", Settings.Get("Entity"))
                        .Replace("<%request%>", Settings.Get("Request"))
                        .Replace("<%projectfolder%>", Settings.Get("ProjectFolder")),
                    OutputName = $"{Settings.Get("Request")}{Settings.Get("Entity")}WorkerHandler.cs",
                    Parameters = Settings.Parameters
                    ,
                    Settings = Settings
                }).Named<IGenSettings>("QueryHandler");

            builder.RegisterInstance(
                new CodeGenSettings()
                {
                    TemplateName = $"HandlerTest",
                    OutputName = $"{Settings.Get("Request")}{Settings.Get("Entity")}WorkerUnitTest.cs",
                    OutputFolder = Settings.Get("DirUnitTest")
                        .Replace("<%entity%>", Settings.Get("Entity"))
                        .Replace("<%request%>", Settings.Get("Request"))
                        .Replace("<%projectfolder%>", Settings.Get("ProjectFolder")),
                    Parameters = Settings.Parameters
                    ,
                    Settings = Settings
                }).Named<IGenSettings>("HandlerTest");
        }
    }
}