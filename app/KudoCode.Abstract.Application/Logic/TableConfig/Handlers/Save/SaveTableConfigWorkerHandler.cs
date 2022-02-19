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
	public class SaveTableConfigRequestWorkerHandler
		: CommandHandler<SaveTableConfigRequest, TableConfig, SaveTableConfigResponse>
	{
		private TableConfig _TableConfigData;
		private IConvertToObject _convertToObject;

		public SaveTableConfigRequestWorkerHandler(
			IMapper mapper,
			IRepository repository,
			ILifetimeScope scope,
			IConvertToObject convertToObject,
			IWorkerContext<SaveTableConfigResponse> context)
			: base(mapper, repository, scope, context)
		{
			_convertToObject = convertToObject;
		}

		protected override void GetEntity()
		{

			Entity = Request.Id > 0
				 ? Repository.GetOne<TableConfig>(a => a.Id == Request.Id)
				: new TableConfig();
		}

		protected override void Execute()
		{
			Mapper.Map(Request, Entity);
			Repository.Save(Entity);
			Repository.SaveChanges();
			Context.Result = new SaveTableConfigResponse() { Id = Entity.Id };
		}
	}
}
