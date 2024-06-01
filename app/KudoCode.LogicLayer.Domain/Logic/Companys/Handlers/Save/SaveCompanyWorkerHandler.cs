using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Domain.Logic.Companys.Entities;
using KudoCode.LogicLayer.Dtos.Companys.Outbound;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;

namespace KudoCode.LogicLayer.Domain.Logic.Companys.Handlers.Save
{
	public class SaveCompanyRequestWorkerHandler
		: CommandHandler<SaveCompanyRequest, Company, SaveCompanyResponse>
	{
		public SaveCompanyRequestWorkerHandler(
			IMapper mapper,
			IRepository repository,
			ILifetimeScope scope,
			IWorkerContext<SaveCompanyResponse> context)
			: base(mapper, repository, scope, context)
		{
		}

		protected override void GetEntity()
		{
			Entity = Request.Id > 0
				 ? Repository.GetOne<Company>(a => a.Id == Request.Id)
				: new Company();
		}

		protected override void Execute()
		{
			Mapper.Map(Request, Entity);
			Repository.Save(Entity);
			Repository.SaveChanges();
			Context.Result = new SaveCompanyResponse() { Id = Entity.Id };
		}
	}
}
