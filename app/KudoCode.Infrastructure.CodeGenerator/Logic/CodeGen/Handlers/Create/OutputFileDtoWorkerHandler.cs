using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace KudoCode.Infrastructure.CodeGenerator.Logic.CodeGen.Handlers.Create
{
	public class OutputFileDtoWorkerHandler : WorkerHandler<CreateFileDto, FileDto>
    {
        public OutputFileDtoWorkerHandler(
            IMapper mapper,
            ILifetimeScope scope,
            IWorkerContext<FileDto> context) : base(mapper, scope, context)
        {
        }

        protected override void Execute()
        {
            System.IO.Directory.CreateDirectory(Request.OutputFolder);
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter($@"{Request.OutputFolder}\{Request.OutputName}", false))
                file.WriteLine(Context.Result.FileString);
        }
    }
}