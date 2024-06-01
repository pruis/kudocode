using AutoMapper;
using KudoCode.Abstract.Application;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{
	public class TableConfigAutoMap : Profile
	{
		public TableConfigAutoMap()
		{
			CreateMap<Contracts.SaveTableConfigResponse, TableConfigModel>()
				.ForMember(a => a.TableConfigId, o => o.MapFrom(s => s.Id));
			CreateMap<Contracts.TableConfig, GetTableConfigRequest>();
			CreateMap<TableConfig, GetTableConfigResponse>();

			CreateMap<TableConfig, SaveTableConfigResponse>();
			CreateMap<SaveTableConfigRequest, TableConfig>();
			CreateMap<TableConfig, SaveTableConfigResponse>();

			CreateMap<Contracts.TableConfig, TableConfig>().ReverseMap();
			CreateMap<Contracts.PropertyConfig, PropertyConfig>().ReverseMap();
		}
	}
}