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
	public class GetLookupWorkerBelongsToOrgHandler : GetLookupsWorkerBase
	{
		private readonly IGetLookupRequestContext _requestContext;
		private readonly IReadOnlyRepository _repository;
		private readonly IApplicationUserContext _applicationUserContext;

		protected override void Execute()
		{
#if DEBUG
			if (_applicationUserContext.ActiveEntityOrganizationId == 0)
				_applicationUserContext.ActiveEntityOrganizationId = 1;
#endif
			OrganizationId = _applicationUserContext.ActiveEntityOrganizationId;
			//Find lookups implementing IBelongToOrganization
			var allowedLookups = _requestContext.Lookups.List.Where(a => (!a.IsFilterLookup && a.BelongToOrganization)).Select(a => a.Name)
				.ToList();

			var matched = Request.Lookups.Where(a => allowedLookups.Contains(a.Type)).ToList();
			if (!matched.Any())
				return;
			//Compile SQL
			var sql = matched.Aggregate(string.Empty,
				(current, dtoLookup) =>
					current +
					$"select AU.[{dtoLookup.Key}] as [Id] ,AU.[{dtoLookup.Value}] as [Description],'{dtoLookup.Type}' as [Type] " +
					$"from {dtoLookup.Type} AU  where AU.EntityOrganizationId = {_applicationUserContext.ActiveEntityOrganizationId} UNION "
			);

			sql = sql.Substring(0, sql.LastIndexOf("UNION ", StringComparison.Ordinal))
				  + " order by [Type]";

			//Execute and build result
			_repository.Sql(sql, CallBack);
			SetResult();
		}


		public GetLookupWorkerBelongsToOrgHandler(
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