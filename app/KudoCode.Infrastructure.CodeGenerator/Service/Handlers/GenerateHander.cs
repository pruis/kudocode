using Autofac;
using KudoCode.Contracts;
using KudoCode.Contracts.Api;

namespace KudoCode.Infrastructure.CodeGenerator
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