using Autofac;
using AutoMapper;
using KudoCode.Contracts;
using KudoCode.Contracts.Api;
using KudoCode.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KudoCode.Abstract.Application
{
	public class SaveChildTableConfigRequestWorkerHandler
		: CommandHandler<SaveChildTableConfigRequest, ChildTableConfig, SaveChildTableConfigResponse>
	{
		private ChildTableConfig _ChildTableConfigData;
		private IConvertToObject _convertToObject;

		public SaveChildTableConfigRequestWorkerHandler(
			IMapper mapper,
			IRepository repository,
			ILifetimeScope scope,
			IConvertToObject convertToObject,
			IWorkerContext<SaveChildTableConfigResponse> context)
			: base(mapper, repository, scope, context)
		{
			_convertToObject = convertToObject;
		}

		protected override void GetEntity()
		{

			Entity = Request.Id > 0
				 ? Repository.GetOne<ChildTableConfig>(a => a.Id == Request.Id)
				: new ChildTableConfig();
		}

		protected override void Execute()
		{
			Mapper.Map(Request, Entity);
			Repository.Save(Entity);
			Repository.SaveChanges();
			Context.Result = new SaveChildTableConfigResponse() { Id = Entity.Id };
		}
	}
}
