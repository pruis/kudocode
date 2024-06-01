using Autofac;
using AutoMapper;
using KudoCode.Contracts;
using KudoCode.Contracts.Api;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KudoCode.Abstract.Application
{
	public class LoadTableConfigRequestWorkerHandler
		: CommandHandler<LoadTableConfigRequest, IEnumerable<TableConfig>, LoadTableConfigResponse>
	{
		private IEnumerable<IGrouping<TableConfig, PropertyConfig>> _tableConfigs;
		private IListTableConfigStore _listTableConfigStore;

		public LoadTableConfigRequestWorkerHandler(
			IMapper mapper,
			IRepository repository,
			ILifetimeScope scope,
			IListTableConfigStore listTableConfigStore,
			IWorkerContext<LoadTableConfigResponse> context)
			: base(mapper, repository, scope, context)
		{
			_listTableConfigStore = listTableConfigStore;
		}

		protected override void GetEntity()
		{
			//if (_listTableConfigStore.List.Any())
			//	return;

			Repository.GetAll<PropertyConfig>(null, src => src.Include(a => a.TableConfig));
			Repository.GetAll<ChildTableConfig>(null, src => src.Include(a => a.TableConfig));
			//_tableConfigs = Repository.GetAll<PropertyConfig>(null, src => src.Include(a => a.TableConfig)).GroupBy(a => a.TableConfig);
			//var properties = Repository.GetAll<PropertyConfig>(null, src => src.Include(a => a.TableConfig)).GroupBy(a => a.TableConfig);
			Entity = Repository.GetAll<TableConfig>();

		}

		protected override void Execute()
		{
			//if (Entity != null)
			_listTableConfigStore.List.RemoveAll(a => a == null);
			_listTableConfigStore.List.RemoveAll(a => a.Id > 0);
			_listTableConfigStore.List.AddRange(Mapper.Map<List<Contracts.TableConfig>>(Entity));
			_listTableConfigStore.List.RemoveAll(a => a == null);
			Context.Result = new LoadTableConfigResponse() { List = _listTableConfigStore.List };
		}
	}
}
