using System.Collections.Generic;
using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

namespace KudoCode.LogicLayer.Domain.Logic.Leads.Handlers.Create
{
    public class CreateLeadsFromCsvDtoWorkerHandler
        : WorkerHandler<CreateLeadsFromCsvDto, List<int>>
    {
        private readonly ISecondaryExecutionPipeline _executionPipeline;

        protected override void Execute()
        {
            var resultLeads = _executionPipeline
                .Execute<CreateLeadsFromCsvDto, List<CreateLeadRequest>>(Request)
                .AttachResult(Context);

            if (Context.HasErrors()) return;

            foreach (var createLeadDto in resultLeads.Result)
            {
                var resultLead = _executionPipeline
                    .Execute<CreateLeadRequest, int>(createLeadDto)
                    .AttachResult(Context);

                if (!Context.HasErrors())
                    Context.Result.Add(resultLead.Result);
            }
        }


        public CreateLeadsFromCsvDtoWorkerHandler(
            ISecondaryExecutionPipeline executionPipeline,
            IMapper mapper,
            IComponentContext scope,
            IWorkerContext<List<int>> context)
            : base(mapper, scope, context)
        {
            _executionPipeline = executionPipeline;
        }
    }
}