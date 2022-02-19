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
using System.Collections;
using System.Threading.Tasks;

namespace KudoCode.Abstract.Application
{
	public class ListChildTableConfigRequestWorkerHandler
		: CommandHandler<ListChildTableConfigRequest, IEnumerable<ChildTableConfig>, ListChildTableConfigResponse>
	{

		public ListChildTableConfigRequestWorkerHandler(
			IMapper mapper,
			IRepository repository,
			ILifetimeScope scope,
			IWorkerContext<ListChildTableConfigResponse> context)
			: base(mapper, repository, scope, context)
		{
		}

		protected override void GetEntity()
		{
			Entity = Repository.Get<ChildTableConfig>(a => a.TableConfigId == Request.TableConfigId);
		}

		protected override void Execute()
		{
			Context.Result = new ListChildTableConfigResponse() { List = Mapper.Map<List<Contracts.ChildTableConfig>>(Entity) };
		}
	}
}
