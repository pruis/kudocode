using Autofac;
using AutoMapper;
using FluentValidation;
using KudoCode.Contracts;
using KudoCode.Contracts.Api;
using KudoCode.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KudoCode.Abstract.Application
{
	public class SaveDynamicRequestWorkerHandler
		: CommandHandler<SaveDynamicRequest, Dynamic, SaveDynamicResponse>
	{
		private dynamic _dynamicData;
		private IConvertToObject _convertToObject;
		private IListTableConfigStore _listTableConfigStore;

		public SaveDynamicRequestWorkerHandler(
			IMapper mapper,
			IRepository repository,
			ILifetimeScope scope,
			IConvertToObject convertToObject,
			IListTableConfigStore listTableConfigStore,
			IWorkerContext<SaveDynamicResponse> context)
			: base(mapper, repository, scope, context)
		{
			_convertToObject = convertToObject;
			_listTableConfigStore = listTableConfigStore;
		}

		protected override void GetEntity()
		{
			Type type = null;
			_dynamicData = _convertToObject.ToObject(Request.Data, Request.TableConfigId, type);

			int entityId = (int)_dynamicData.Id;
			Entity = entityId > 0
				 ? Repository.GetOne<Dynamic>(a => a.Id == entityId)
				: new Dynamic();
		}

		protected override void Execute()
		{

			var tableConfig = _listTableConfigStore.List.Single(a => a.Id == Request.TableConfigId);
			if (!string.IsNullOrWhiteSpace(tableConfig.SaveInterceptorKey))
			{
				dynamic postInterceptorDynamicData = null;
				object interceptor = null;
				Scope.TryResolveNamed(tableConfig.SaveInterceptorKey, typeof(IDynamicInterceptor), out interceptor);
				if (interceptor != null)
				{
					((IDynamicInterceptor)interceptor).Validate(_dynamicData);
					if (Context.HasErrors())
						return;

					postInterceptorDynamicData = ((IDynamicInterceptor)interceptor).Execute(_dynamicData);

					if (Context.HasErrors())
						return;

					if (postInterceptorDynamicData != null)
						StaticHelpers.Copy<dynamic, dynamic>(postInterceptorDynamicData, _dynamicData);
				}

			}

			//Create ID if new item
			if (Entity.Id == 0)
			{
				Entity.DynamicId = Request.DynamicId;
				Entity.TableConfigId = Request.TableConfigId;
				Repository.Save(Entity);
				Repository.SaveChanges();
				_dynamicData.Id = Entity.Id;
			}

			//save entity 
			Entity.Data = JsonConvert.SerializeObject(_dynamicData);
			Repository.SaveChanges();
			Context.Result = new SaveDynamicResponse() { Data = Entity.Data };
		}
	}
}
