using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Domain.Logic.Companys.Entities;
using KudoCode.LogicLayer.Dtos.Comanys.Outbound;
using System.Collections.Generic;
using System.Linq;

namespace KudoCode.LogicLayer.Domain.Logic.Companys.Handlers.List
{
	public class ListCompanyRequestWorkerHandler : QueryHandler<ListCompanyRequest,List<Company>,
         ListCompanyResponse>
    {
		private IReadOnlyRepository _repository;

		public ListCompanyRequestWorkerHandler(
            IMapper mapper,
            IReadOnlyRepository repository,
            ILifetimeScope scope,
            IWorkerContext<ListCompanyResponse> context)
            : base(mapper, repository,  scope, context)
        {
            _repository = repository;
        }

		protected override void GetEntity()
		{
            Entity = _repository.Get<Company>().ToList();
        }
        protected override void Execute()
        {
            Context.Result = new ListCompanyResponse() { };
            Context.Result.List = Mapper.Map<List<CompanyResponse>>(Entity);

        }
    }
}
