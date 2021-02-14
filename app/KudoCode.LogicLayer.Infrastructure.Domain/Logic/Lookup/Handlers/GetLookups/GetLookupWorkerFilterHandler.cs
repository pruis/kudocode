using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Dtos.Lookups;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Domain.Logic.Lookup.Context;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

namespace KudoCode.LogicLayer.Infrastructure.Domain.Logic.Lookup.Handlers.GetLookups
{
    public class GetLookupWorkerFilterHandler : GetLookupsWorkerBase
    {
        private readonly IGetLookupRequestContext _requestContext;
        private readonly IReadOnlyRepository _repository;
        private readonly IApplicationUserContext _applicationUserContext;

        protected override void Execute()
        {
            //Find lookups implementing IBelongToOrganization
            var allowedLookups = _requestContext
                .Lookups
                .List
                .Where(a => (a.IsFilterLookup && !a.BelongToOrganization && !a.IsAuthorizationGroup))
                .Select(a => a.Name)
                .ToList();

            var matched = Request.Lookups.Where(a => allowedLookups.Contains(a.Type)).ToList();
            if (!matched.Any())
                return;
            //Compile SQL
            var sql = matched.Aggregate(string.Empty,
                (current, dtoLookup) =>
                    current +
                    $"select [{dtoLookup.Key}] as [Id] ,[{dtoLookup.Value}] as [Description],'{dtoLookup.Type}' as [Type] " +
                    $"from {dtoLookup.Type} where {dtoLookup.Filter} UNION "
            );

            sql = sql.Substring(0, sql.LastIndexOf("UNION ", StringComparison.Ordinal))
                  + " order by [Type]";

            //Execute and build result
            _repository.Sql(sql, CallBack);
            SetResult();
        }


        public GetLookupWorkerFilterHandler(
            IGetLookupRequestContext requestContext,
            IMapper mapper,
            IReadOnlyRepository repository,
            IComponentContext scope,
            IApplicationUserContext applicationUserContext,
            IWorkerContext<GetLookupResponse> context) : base(mapper, scope, context)

        {
            _requestContext = requestContext;
            _repository = repository;
            _applicationUserContext = applicationUserContext;
            _list = new List<LookupResponse>();
        }
    }
}