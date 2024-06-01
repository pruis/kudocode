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
	public class GetChildTableConfigRequestWorkerHandler
		: CommandHandler<GetChildTableConfigRequest, ChildTableConfig, GetChildTableConfigResponse>
	{
		private ChildTableConfig _ChildTableConfigData;
		private IConvertToObject _convertToObject;

		public GetChildTableConfigRequestWorkerHandler(
			IMapper mapper,
			IRepository repository,
			ILifetimeScope scope,
			IConvertToObject convertToObject,
			IWorkerContext<GetChildTableConfigResponse> context)
			: base(mapper, repository, scope, context)
		{
			_convertToObject = convertToObject;
		}

		protected override void GetEntity()
		{
			Entity = Repository.GetOne<ChildTableConfig>(a => a.Id == Request.Id);
		}

		protected override void ValidateEntity()
		{
			if (Entity == null)
				Context.AddMessage("E4",
					$"Entity with ID {Request.Id} not found");
		}
		protected override void Execute()
		{
			Context.Result = Mapper.Map<GetChildTableConfigResponse>(Entity);
		}
	}
}
