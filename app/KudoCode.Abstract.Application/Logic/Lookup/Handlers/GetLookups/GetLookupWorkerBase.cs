using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace KudoCode.LogicLayer.Infrastructure.Domain.Logic.Lookup.Handlers.GetLookups
{
	public abstract class GetLookupsWorkerBase : WorkerHandler<GetLookupRequest, GetLookupResponse>
    {
        protected List<LookupResponse> _list;
        protected int OrganizationId = 0;
        protected int ApplicationUserId = 0;

        public GetLookupsWorkerBase(IMapper mapper, IComponentContext scope, IWorkerContext<GetLookupResponse> context)
            : base(mapper, scope, context)
        {
        }

        protected void CallBack(DbDataReader reader)
        {
            while (reader.Read())
            {
                var row = new LookupResponse()
                {
                    Id = reader.GetInt32(0),
                    Description = reader.GetString(1),
                    Type = reader.GetString(2),
                    OranizationId = OrganizationId,
                    ApplicationUserId = ApplicationUserId
                };
                _list.Add(row);
            }
        }

        protected void SetResult()
        {
            if (Context.Result == null)
                Context.Result = new GetLookupResponse
                {
                    Lookups = _list
                };
            else
            {
                Context.Result.Lookups.AddRange(_list);
                Context.Result.Lookups = Context.Result.Lookups.GroupBy(x => new {x.Id, x.Description})
                    .Select(y => y.First()).ToList();
            }
        }
    }
}