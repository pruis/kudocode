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
	public class ListPropertyConfigRequestWorkerHandler
		: CommandHandler<ListPropertyConfigRequest, IEnumerable<PropertyConfig>, ListPropertyConfigResponse>
	{

		public ListPropertyConfigRequestWorkerHandler(
			IMapper mapper,
			IRepository repository,
			ILifetimeScope scope,
			IWorkerContext<ListPropertyConfigResponse> context)
			: base(mapper, repository, scope, context)
		{
		}

		protected override void GetEntity()
		{
			Entity = Repository.Get<PropertyConfig>(a => a.TableConfigId == Request.TableConfigId);
		}

		protected override void Execute()
		{
			Context.Result = new ListPropertyConfigResponse() { List = Mapper.Map<List<Contracts.PropertyConfig>>(Entity) };
		}
	}
}
