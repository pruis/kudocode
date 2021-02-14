using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Infrastructure.Dtos.GenCode;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

namespace KudoCode.CodeGenerator.Logic.CodeGen.Handlers.Create
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