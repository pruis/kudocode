using Autofac;
using KudoCode.Contracts;
using KudoCode.Contracts.Api;

namespace KudoCode.Infrastructure.CodeGenerator
{
    public class GenerateHandler : IGenerate
    {
        private ILifetimeScope _scope;

        public GenerateHandler(ILifetimeScope scope)
        {
            _scope = scope;
        }
        public void Generate(IGenSettings settings)
        {
            _scope.Resolve<IExecutionPipeline>()
                .Execute<CreateFileDto, FileDto>(new CreateFileDto()
                {
                    Parameters = settings.Parameters,
                    OutputName = settings.OutputName,
                    OutputFolder = settings.OutputFolder,
                    TemplateName = settings.TemplateName,
                    TemplatePath = settings.TemplatePath,
                    Properties = settings.Properties,
                    Settings = settings.Settings,
                }
                );
        }
    }


    public class UpdateHandler : IGenerate
    {
        private ILifetimeScope _scope;

        public UpdateHandler(ILifetimeScope scope)
        {
            _scope = scope;
        }
        public void Generate(IGenSettings settings)
        {
            _scope.Resolve<IExecutionPipeline>()
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