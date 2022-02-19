using Autofac;
using AutoMapper;
using KudoCode.Contracts;
using KudoCode.Contracts.Api;
using KudoCode.Helpers;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;

namespace KudoCode.Abstract.Application
{
	public class GetDynamicRequestWorkerHandler
		: CommandHandler<GetDynamicRequest, Dynamic, GetDynamicResponse>
	{
		private dynamic _dynamicData;
		private IConvertToObject _convertToObject;
		private readonly IListTableConfigStore _listTableConfigStore;

		public GetDynamicRequestWorkerHandler(
			IMapper mapper,
			IRepository repository,
			ILifetimeScope scope,
			IConvertToObject convertToObject,
			IListTableConfigStore listTableConfigStore,
			IWorkerContext<GetDynamicResponse> context)
			: base(mapper, repository, scope, context)
		{
			_convertToObject = convertToObject;
			_listTableConfigStore = listTableConfigStore;
		}

		protected override void GetEntity()
		{
			Entity = Repository.GetOne<Dynamic>(a => a.Id == Request.Id);
		}

		protected override void ValidateEntity()
		{
			if (Entity == null)
				Context.AddMessage("E4",
					$"Entity with ID {Request.Id} not found");
		}
		protected override void Execute()
		{

			Type type = null;
			var _dynamicData = _convertToObject.ToObject(Entity.Data, Entity.TableConfigId, type);
			((dynamic)_dynamicData).Id = Entity.Id;

			var tableConfig = _listTableConfigStore.List.Single(a => a.Id == Entity.TableConfigId);
			if (!string.IsNullOrWhiteSpace(tableConfig.GetInterceptorKey))
			{
				dynamic postInterceptorDynamicData = null;
				object interceptor = null;
				Scope.TryResolveNamed(tableConfig.GetInterceptorKey, typeof(IDynamicInterceptor), out interceptor);
				if (interceptor != null)
					postInterceptorDynamicData = ((IDynamicInterceptor)interceptor).Execute(_dynamicData);

				if (Context.HasErrors())
					return;

				if (postInterceptorDynamicData != null)
					StaticHelpers.Copy<dynamic, dynamic>(postInterceptorDynamicData, _dynamicData);
			}


			Context.Result = new GetDynamicResponse() { Data = JsonConvert.SerializeObject(_dynamicData) };
		}
	}
}
