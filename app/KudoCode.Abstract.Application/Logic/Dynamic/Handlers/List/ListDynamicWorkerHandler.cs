using Autofac;
using AutoMapper;
using KudoCode.Contracts;
using KudoCode.Contracts.Api;
using KudoCode.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudoCode.Abstract.Application
{
	public class ListDynamicRequestWorkerHandler
		: CommandHandler<ListDynamicRequest, IEnumerable<Dynamic>, ListDynamicResponse>
	{
		private IListTableConfigStore _listTableConfigStore;

		public ListDynamicRequestWorkerHandler(
			IMapper mapper,
			IRepository repository,
			ILifetimeScope scope,
			IListTableConfigStore listTableConfigStore,
			IWorkerContext<ListDynamicResponse> context)
			: base(mapper, repository, scope, context)
		{
			_listTableConfigStore = listTableConfigStore;
		}

		protected override void GetEntity()
		{
			Entity = Repository.Get<Dynamic>(a => a.TableConfigId == Request.TableConfigId && a.DynamicId == Request.DynamicId);
		}

		protected override void Execute()
		{
			var tableConfig = _listTableConfigStore.List.Single(a => a.Id == Request.TableConfigId);
			if (!string.IsNullOrWhiteSpace(tableConfig.ListInterceptorKey) && Entity.Any())
			{
				dynamic postInterceptorDynamicData = null;
				object interceptor = null;
				Scope.TryResolveNamed(tableConfig.ListInterceptorKey, typeof(IDynamicInterceptor), out interceptor);
				if (interceptor != null)
					postInterceptorDynamicData = ((IDynamicInterceptor)interceptor).Execute(Entity.Select(a => a.Data).ToList());

				if (Context.HasErrors())
					return;
			}

			Context.Result = new ListDynamicResponse() { Data = Entity.Select(a => a.Data).ToList() };
		}
	}
}
