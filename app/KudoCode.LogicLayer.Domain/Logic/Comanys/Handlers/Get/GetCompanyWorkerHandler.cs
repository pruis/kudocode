using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Domain.Logic.Companys.Entities;
using KudoCode.LogicLayer.Dtos.Comanys.Outbound;

namespace KudoCode.LogicLayer.Domain.Logic.Companys.Handlers.Get
{
	public class GetCompanyRequestWorkerHandler : QueryHandler<GetCompanyRequest,
        Company, GetCompanyResponse>
    {
        public GetCompanyRequestWorkerHandler(
            IMapper mapper,
            IReadOnlyRepository repository,
            ILifetimeScope scope,
            IWorkerContext<GetCompanyResponse> context)
            : base(mapper, repository, scope, context)
        {
        }

        protected override void GetEntity()
        {
            Entity = Request.Id > 0
                ? Repository.GetOne<Company>(a => a.Id == Request.Id)
                : new Company();
        }

        protected override void ValidateEntity()
        {

        }

        protected override void Execute()
        {
            Context.Result = Mapper.Map<GetCompanyResponse>(Entity);
        }
    }
}
