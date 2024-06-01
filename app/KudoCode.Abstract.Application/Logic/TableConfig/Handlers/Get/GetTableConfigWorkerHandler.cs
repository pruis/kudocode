using Autofac;
using AutoMapper;
using KudoCode.Contracts;
using KudoCode.Contracts.Api;
using KudoCode.Helpers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KudoCode.Abstract.Application
{
	public class GetTableConfigRequestWorkerHandler
		: CommandHandler<GetTableConfigRequest, TableConfig, GetTableConfigResponse>
	{
		private TableConfig _TableConfigData;
		private IConvertToObject _convertToObject;

		public GetTableConfigRequestWorkerHandler(
			IMapper mapper,
			IRepository repository,
			ILifetimeScope scope,
			IConvertToObject convertToObject,
			IWorkerContext<GetTableConfigResponse> context)
			: base(mapper, repository, scope, context)
		{
			_convertToObject = convertToObject;
		}

		protected override void GetEntity()
		{
			Entity = Repository.GetOne<TableConfig>(a => a.Id == Request.Id);
		}

		protected override void ValidateEntity()
		{
			if (Entity == null)
				Context.AddMessage("E4",
					$"Entity with ID {Request.Id} not found");
		}
		protected override void Execute()
		{
			Context.Result = Mapper.Map<GetTableConfigResponse>(Entity);
		}
	}
}
