using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Domain.Logic.Companys.Entities;
using KudoCode.LogicLayer.Dtos.Companys.Outbound;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;

namespace KudoCode.LogicLayer.Domain.Logic.Companys.Handlers.Delete
{
	public class DeleteCompanyWorkerHandler : CommandHandler<DeleteCompanyRequest,
        Company, DeleteCompanyResponse>
    {
        public DeleteCompanyWorkerHandler(
            IMapper mapper,
            IRepository repository,
            ILifetimeScope scope,
            IWorkerContext<DeleteCompanyResponse> context)
            : base(mapper, repository, scope, context)
        {
        }

        protected override void GetEntity()
        {
            Entity = 
                Repository.GetOne<Company>(a => a.Id == Request.Id);
        }

        protected override void ValidateEntity()
        {
        }

        protected override void Execute()
        {
            Repository.Delete(Entity);
            Repository.SaveChanges();
        }
    }
}
