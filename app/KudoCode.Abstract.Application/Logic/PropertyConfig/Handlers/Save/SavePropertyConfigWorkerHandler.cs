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
	public class SavePropertyConfigRequestWorkerHandler
		: CommandHandler<SavePropertyConfigRequest, PropertyConfig, SavePropertyConfigResponse>
	{
		private PropertyConfig _PropertyConfigData;
		private IConvertToObject _convertToObject;

		public SavePropertyConfigRequestWorkerHandler(
			IMapper mapper,
			IRepository repository,
			ILifetimeScope scope,
			IConvertToObject convertToObject,
			IWorkerContext<SavePropertyConfigResponse> context)
			: base(mapper, repository, scope, context)
		{
			_convertToObject = convertToObject;
		}

		protected override void GetEntity()
		{

			Entity = Request.Id > 0
				 ? Repository.GetOne<PropertyConfig>(a => a.Id == Request.Id)
				: new PropertyConfig();
		}

		protected override void Execute()
		{
			Mapper.Map(Request, Entity);
			Repository.Save(Entity);
			Repository.SaveChanges();
			Context.Result = new SavePropertyConfigResponse() { Id = Entity.Id };
		}
	}
}
