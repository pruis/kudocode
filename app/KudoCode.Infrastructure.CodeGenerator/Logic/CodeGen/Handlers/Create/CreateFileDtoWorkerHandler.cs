using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;
namespace KudoCode.Infrastructure.CodeGenerator.Logic.CodeGen.Handlers.Create
{
	public class CreateFileDtoWorkerHandler : WorkerHandler<CreateFileDto, FileDto>
    {
        public CreateFileDtoWorkerHandler(
            IMapper mapper,
            ILifetimeScope scope,
            IWorkerContext<FileDto> context) : base(mapper, scope, context)
        {
        }

        protected override void Execute()
        {
            var templateString = System.IO.File.ReadAllText($@"Logic\Templates\{Request.TemplateName}.txt");

            foreach (var parameter in Request.Parameters)
            {
                templateString = templateString.Replace(
                    parameter.Split(':')[0]
                    , parameter.Split(':')[1]);
            }

            Context.Result = new FileDto() {FileString = templateString};
        }
    }
}