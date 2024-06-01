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
	public class ListTableConfigRequestWorkerHandler
		: CommandHandler<ListTableConfigRequest, IEnumerable<TableConfig>, ListTableConfigResponse>
	{

		public ListTableConfigRequestWorkerHandler(
			IMapper mapper,
			IRepository repository,
			ILifetimeScope scope,
			IWorkerContext<ListTableConfigResponse> context)
			: base(mapper, repository, scope, context)
		{
		}

		protected override void GetEntity()
		{
			Entity = Repository.Get<TableConfig>();
		}

		protected override void Execute()
		{
			Context.Result = new ListTableConfigResponse() { List = Mapper.Map<List<Contracts.TableConfig>>(Entity) };
		}
	}
}
