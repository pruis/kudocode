using Autofac;
using KudoCode.CodeGenerator.Logic.Settings;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Dtos.GenCode;
using KudoCode.LogicLayer.Infrastructure.Execution.Interfaces;

namespace KudoCode.CodeGenerator.Service.Handlers
{
    public class GenerateHandler : IGenerate
    {
        public void Generate(IGenSettings settings)
        {
            ApplicationContext.Container.Resolve<IExecutionPipeline>()
                .Execute<CreateFileDto, FileDto>(new CreateFileDto()
                    {
                        Parameters = settings.Parameters,
                        OutputName = settings.OutputName,
                        OutputFolder = settings.OutputFolder,
                        TemplateName = settings.TemplateName
                    }
                );
        }
    }
}