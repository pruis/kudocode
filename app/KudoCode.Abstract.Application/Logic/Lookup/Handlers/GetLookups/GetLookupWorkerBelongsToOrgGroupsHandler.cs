using Autofac;
using AutoMapper;
using KudoCode.Abstract.Application;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KudoCode.LogicLayer.Infrastructure.Domain.Logic.Lookup.Handlers.GetLookups
{
	public class GetLookupWorkerBelongsToOrgGroupsHandler : GetLookupsWorkerBase
    {
        private readonly IGetLookupRequestContext _requestContext;
        private readonly IReadOnlyRepository _repository;
        private readonly IApplicationUserContext _applicationUserContext;

        protected override void Execute()
        {
            //Find lookups implementing IBelongToOrganization
            var allowedLookups = _requestContext.Lookups.List.Where(a => (!a.IsFilterLookup && a.IsAuthorizationGroup)).Select(a => a.Name)
                .ToList();
            var matched = Request.Lookups.Where(a => allowedLookups.Contains(a.Type)).ToList();
            if (!matched.Any())
                return;

            //Compile SQL
            var sql = matched.Aggregate(string.Empty,
                (current, dtoLookup) =>
                    current +
                    $"select L.[{dtoLookup.Key}] as [Id] ,L.[{dtoLookup.Value}] as [Description], '{dtoLookup.Type}' as [Type] " +
                    $"from {dtoLookup.Type} L inner join {dtoLookup.Type}AuthorizationGroupMap LAGM on L.Id = LAGM.{dtoLookup.Type}Id UNION "
            );

            var ids = _applicationUserContext.AuthorizationGroups.Select(a => a.Id).Aggregate(string.Empty,
                (current, dtoLookup) =>
                    current + $"{dtoLookup}, "
            );
            ids = ids.Substring(0, ids.LastIndexOf(", ", StringComparison.Ordinal));

            sql = sql.Substring(0, sql.LastIndexOf("UNION ", StringComparison.Ordinal))
                  + $" where LAGM.AuthorizationGroupId in ({ids}) "
                  + " order by [Type]";

            //Execute and build result
            _repository.Sql(sql, CallBack);
            SetResult();
        }


        public GetLookupWorkerBelongsToOrgGroupsHandler(
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